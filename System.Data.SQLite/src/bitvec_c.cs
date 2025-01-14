using System.Diagnostics;
using BITVEC_TELEM = System.Byte;
using i64 = System.Int64;
using u32 = System.UInt32;

namespace System.Data.SQLite
{

    public partial class Sqlite3
    {
        /*
		** 2008 February 16
		**
		** The author disclaims copyright to this source code.  In place of
		** a legal notice, here is a blessing:
		**
		**    May you do good and not evil.
		**    May you find forgiveness for yourself and forgive others.
		**    May you share freely, never taking more than you give.
		**
		*************************************************************************
		** This file implements an object that represents a fixed-length
		** bitmap.  Bits are numbered starting with 1.
		**
		** A bitmap is used to record which pages of a database file have been
		** journalled during a transaction, or which pages have the "dont-write"
		** property.  Usually only a few pages are meet either condition.
		** So the bitmap is usually sparse and has low cardinality.
		** But sometimes (for example when during a DROP of a large table) most
		** or all of the pages in a database can get journalled.  In those cases,
		** the bitmap becomes dense with high cardinality.  The algorithm needs
		** to handle both cases well.
		**
		** The size of the bitmap is fixed when the object is created.
		**
		** All bits are clear when the bitmap is created.  Individual bits
		** may be set or cleared one at a time.
		**
		** Test operations are about 100 times more common that set operations.
		** Clear operations are exceedingly rare.  There are usually between
		** 5 and 500 set operations per Bitvec object, though the number of sets can
		** sometimes grow into tens of thousands or larger.  The size of the
		** Bitvec object is the number of pages in the database file at the
		** start of a transaction, and is thus usually less than a few thousand,
		** but can be as large as 2 billion for a really big database.
		*************************************************************************
		**  Included in SQLite3 port to C#-SQLite;  2008 Noah B Hart
		**  C#-SQLite is an independent reimplementation of the SQLite software library
		**
		**  SQLITE_SOURCE_ID: 2010-08-23 18:52:01 42537b60566f288167f1b5864a5435986838e3a3
		**
		*************************************************************************
		*/
        //#include "sqliteInt.h"

        /* Size of the Bitvec structure in bytes. */
        static int BITVEC_SZ = 512;


        /* Round the union size down to the nearest pointer boundary, since that's how
		** it will be aligned within the Bitvec struct. */
        //#define BITVEC_USIZE     (((BITVEC_SZ-(3*sizeof(u32)))/sizeof(Bitvec*))*sizeof(Bitvec*))
        static int BITVEC_USIZE = (((BITVEC_SZ - (3 * sizeof(u32))) / 4) * 4);

        /* Type of the array "element" for the bitmap representation.
		** Should be a power of 2, and ideally, evenly divide into BITVEC_USIZE.
		** Setting this to the "natural word" size of your CPU may improve
		** performance. */
        //#define BITVEC_TELEM     u8
        //using BITVEC_TELEM     = System.Byte;

        /* Size, in bits, of the bitmap element. */
        //#define BITVEC_SZELEM    8
        const int BITVEC_SZELEM = 8;

        /* Number of elements in a bitmap array. */
        //#define BITVEC_NELEM     (BITVEC_USIZE/sizeof(BITVEC_TELEM))
        static int BITVEC_NELEM = (int)(BITVEC_USIZE / sizeof(BITVEC_TELEM));

        /* Number of bits in the bitmap array. */
        //#define BITVEC_NBIT      (BITVEC_NELEM*BITVEC_SZELEM)
        static int BITVEC_NBIT = (BITVEC_NELEM * BITVEC_SZELEM);

        /* Number of u32 values in hash table. */
        //#define BITVEC_NINT      (BITVEC_USIZE/sizeof(u32))
        static u32 BITVEC_NINT = (u32)(BITVEC_USIZE / sizeof(u32));

        /* Maximum number of entries in hash table before
		** sub-dividing and re-hashing. */
        //#define BITVEC_MXHASH    (BITVEC_NINT/2)
        static int BITVEC_MXHASH = (int)(BITVEC_NINT / 2);

        /* Hashing function for the aHash representation.
		** Empirical testing showed that the *37 multiplier
		** (an arbitrary prime)in the hash function provided
		** no fewer collisions than the no-op *1. */
        //#define BITVEC_HASH(X)   (((X)*1)%BITVEC_NINT)
        static u32 BITVEC_HASH(u32 X)
        {
            return (u32)(((X) * 1) % BITVEC_NINT);
        }

        static int BITVEC_NPTR = (int)(BITVEC_USIZE / 4);//sizeof(Bitvec *));



        public class _u
        {
            public BITVEC_TELEM[] aBitmap = new byte[BITVEC_NELEM];   /* Bitmap representation */
            public u32[] aHash = new u32[BITVEC_NINT];        /* Hash table representation */
            public Bitvec[] apSub = new Bitvec[BITVEC_NPTR];  /* Recursive representation */
        }

        /// <summary>
        /// A bitmap is an instance of the following structure.
        ///
        /// This bitmap records the existence of zero or more bits
        /// with values between 1 and iSize, inclusive.
        ///
        /// There are three possible representations of the bitmap.
        /// If iSize<=BITVEC_NBIT, then Bitvec.u.aBitmap[] is a straight
        /// bitmap.  The least significant bit is bit 1.
        ///
        /// If iSize>BITVEC_NBIT and iDivisor==0 then Bitvec.u.aHash[] is
        /// a hash table that will hold up to BITVEC_MXHASH distinct values.
        ///
        /// Otherwise, the value i is redirected into one of BITVEC_NPTR
        /// sub-bitmaps pointed to by Bitvec.u.apSub[].  Each subbitmap
        /// handles up to iDivisor separate values of i.  apSub[0] holds
        /// values between 1 and iDivisor.  apSub[1] holds values between
        /// iDivisor+1 and 2*iDivisor.  apSub[N] holds values between
        /// N*iDivisor+1 and (N+1)*iDivisor.  Each subbitmap is normalized
        /// to hold deal with values between 1 and iDivisor.
        /// </summary>
        public class Bitvec
        {
            public u32 iSize;     /* Maximum bit index.  Max iSize is 4,294,967,296. */
            public u32 nSet;      /* Number of bits that are set - only valid for aHash
  ** element.  Max is BITVEC_NINT.  For BITVEC_SZ of 512,
  ** this would be 125. */
            public u32 iDivisor;  /* Number of bits handled by each apSub[] entry. */
            /* Should >=0 for apSub element. */
            /* Max iDivisor is max(u32) / BITVEC_NPTR + 1.  */
            /* For a BITVEC_SZ of 512, this would be 34,359,739. */
            public _u u = new _u();

            public static implicit operator bool(Bitvec b)
            {
                return (b != null);
            }
        };

        /// <summary>
        /// Create a new bitmap object able to handle bits between 0 and iSize,
        /// inclusive.  Return a pointer to the new object.  Return NULL if
        /// malloc fails.
        /// </summary>
        static Bitvec sqlite3BitvecCreate(u32 iSize)
        {
            Bitvec p;
            //Debug.Assert( sizeof(p)==BITVEC_SZ );
            p = new Bitvec();//sqlite3MallocZero( sizeof(p) );
            if (p != null)
            {
                p.iSize = iSize;
            }
            return p;
        }

        /// <summary>
        /// Check to see if the i-th bit is set.  Return true or false.
        /// If p is NULL (if the bitmap has not been created) or if
        /// i is out of range, then return false.
        /// </summary>
        static int sqlite3BitvecTest(Bitvec p, u32 i)
        {
            if (p == null || i == 0)
                return 0;
            if (i > p.iSize)
                return 0;
            i--;
            while (p.iDivisor != 0)
            {
                u32 bin = i / p.iDivisor;
                i = i % p.iDivisor;
                p = p.u.apSub[bin];
                if (null == p)
                {
                    return 0;
                }
            }
            if (p.iSize <= BITVEC_NBIT)
            {
                return ((p.u.aBitmap[i / BITVEC_SZELEM] & (1 << (int)(i & (BITVEC_SZELEM - 1)))) != 0) ? 1 : 0;
            }
            else
            {
                u32 h = BITVEC_HASH(i++);
                while (p.u.aHash[h] != 0)
                {
                    if (p.u.aHash[h] == i)
                        return 1;
                    h = (h + 1) % BITVEC_NINT;
                }
                return 0;
            }
        }

        /// <summary>
        /// Set the i-th bit.  Return 0 on success and an error code if
        /// anything goes wrong.
        ///
        /// This routine might cause sub-bitmaps to be allocated.  Failing
        /// to get the memory needed to hold the sub-bitmap is the only
        /// that can go wrong with an insert, assuming p and i are valid.
        ///
        /// The calling function must ensure that p is a valid Bitvec object
        /// and that the value for "i" is within range of the Bitvec object.
        /// Otherwise the behavior is undefined.
        /// </summary>
        static int sqlite3BitvecSet(Bitvec p, u32 i)
        {
            u32 h;
            if (p == null)
                return SQLITE_OK;
            Debug.Assert(i > 0);
            Debug.Assert(i <= p.iSize);
            i--;
            while ((p.iSize > BITVEC_NBIT) && p.iDivisor != 0)
            {
                u32 bin = i / p.iDivisor;
                i = i % p.iDivisor;
                if (p.u.apSub[bin] == null)
                {
                    p.u.apSub[bin] = sqlite3BitvecCreate(p.iDivisor);
                    //if ( p.u.apSub[bin] == null )
                    //  return SQLITE_NOMEM;
                }
                p = p.u.apSub[bin];
            }
            if (p.iSize <= BITVEC_NBIT)
            {
                p.u.aBitmap[i / BITVEC_SZELEM] |= (byte)(1 << (int)(i & (BITVEC_SZELEM - 1)));
                return SQLITE_OK;
            }
            h = BITVEC_HASH(i++);
            /* if there wasn't a hash collision, and this doesn't */
            /* completely fill the hash, then just add it without */
            /* worring about sub-dividing and re-hashing. */
            if (0 == p.u.aHash[h])
            {
                if (p.nSet < (BITVEC_NINT - 1))
                {
                    goto bitvec_set_end;
                }
                else
                {
                    goto bitvec_set_rehash;
                }
            }
            /* there was a collision, check to see if it's already */
            /* in hash, if not, try to find a spot for it */
            do
            {
                if (p.u.aHash[h] == i)
                    return SQLITE_OK;
                h++;
                if (h >= BITVEC_NINT)
                    h = 0;
            } while (p.u.aHash[h] != 0);
        /* we didn't find it in the hash.  h points to the first */
        /* available free spot. check to see if this is going to */
        /* make our hash too "full".  */
        bitvec_set_rehash:
            if (p.nSet >= BITVEC_MXHASH)
            {
                u32 j;
                int rc;
                u32[] aiValues = new u32[BITVEC_NINT];// = sqlite3StackAllocRaw(0, sizeof(p->u.aHash));
                                                      //if ( aiValues == null )
                                                      //{
                                                      //  return SQLITE_NOMEM;
                                                      //}
                                                      //else
                {

                    Buffer.BlockCopy(p.u.aHash, 0, aiValues, 0, aiValues.Length * (sizeof(u32)));// memcpy(aiValues, p->u.aHash, sizeof(p->u.aHash));
                    p.u.apSub = new Bitvec[BITVEC_NPTR];//memset(p->u.apSub, 0, sizeof(p->u.apSub));
                    p.iDivisor = (u32)((p.iSize + BITVEC_NPTR - 1) / BITVEC_NPTR);
                    rc = sqlite3BitvecSet(p, i);
                    for (j = 0; j < BITVEC_NINT; j++)
                    {
                        if (aiValues[j] != 0)
                            rc |= sqlite3BitvecSet(p, aiValues[j]);
                    }
                    //sqlite3StackFree( null, aiValues );
                    return rc;
                }
            }
        bitvec_set_end:
            p.nSet++;
            p.u.aHash[h] = i;
            return SQLITE_OK;
        }

        /// <summary>
        /// Clear the i-th bit.
        ///
        /// pBuf must be a pointer to at least BITVEC_SZ bytes of temporary storage
        /// that BitvecClear can use to rebuilt its hash table.
        /// </summary>
        static void sqlite3BitvecClear(Bitvec p, u32 i, u32[] pBuf)
        {
            if (p == null)
                return;
            Debug.Assert(i > 0);
            i--;
            while (p.iDivisor != 0)
            {
                u32 bin = i / p.iDivisor;
                i = i % p.iDivisor;
                p = p.u.apSub[bin];
                if (null == p)
                {
                    return;
                }
            }
            if (p.iSize <= BITVEC_NBIT)
            {
                p.u.aBitmap[i / BITVEC_SZELEM] &= (byte)~((1 << (int)(i & (BITVEC_SZELEM - 1))));
            }
            else
            {
                u32 j;
                u32[] aiValues = pBuf;
                Array.Copy(p.u.aHash, aiValues, p.u.aHash.Length);//memcpy(aiValues, p->u.aHash, sizeof(p->u.aHash));
                p.u.aHash = new u32[aiValues.Length];// memset(p->u.aHash, 0, sizeof(p->u.aHash));
                p.nSet = 0;
                for (j = 0; j < BITVEC_NINT; j++)
                {
                    if (aiValues[j] != 0 && aiValues[j] != (i + 1))
                    {
                        u32 h = BITVEC_HASH(aiValues[j] - 1);
                        p.nSet++;
                        while (p.u.aHash[h] != 0)
                        {
                            h++;
                            if (h >= BITVEC_NINT)
                                h = 0;
                        }
                        p.u.aHash[h] = aiValues[j];
                    }
                }
            }
        }

        /// <summary>
        /// Destroy a bitmap object.  Reclaim all memory used.
        /// </summary>
        static void sqlite3BitvecDestroy(ref Bitvec p)
        {
            if (p == null)
                return;
            if (p.iDivisor != 0)
            {
                u32 i;
                for (i = 0; i < BITVEC_NPTR; i++)
                {
                    sqlite3BitvecDestroy(ref p.u.apSub[i]);
                }
            }
            //sqlite3_free( ref p );
        }

        /// <summary>
        /// Return the value of the iSize parameter specified when Bitvec *p
        /// was created.
        /// </summary>
        static u32 sqlite3BitvecSize(Bitvec p)
        {
            return p.iSize;
        }

#if !SQLITE_OMIT_BUILTIN_TEST
        /// <summary>
        /// Let V[] be an array of unsigned characters sufficient to hold
        /// up to N bits.  Let I be an integer between 0 and N.  0<=I<N.
        /// Then the following macros can be used to set, clear, or test
        /// individual bits within V.
        /// </summary>
        static void SETBIT(byte[] V, int I)
        {
            V[I >> 3] |= (byte)(1 << (I & 7));
        }

        static void CLEARBIT(byte[] V, int I)
        {
            V[I >> 3] &= (byte)~(1 << (I & 7));
        }

        static int TESTBIT(byte[] V, int I)
        {
            return (V[I >> 3] & (1 << (I & 7))) != 0 ? 1 : 0;
        }

        /// <summary>
        /// This routine runs an extensive test of the Bitvec code.
        ///
        /// The input is an array of integers that acts as a program
        /// to test the Bitvec.  The integers are opcodes followed
        /// by 0, 1, or 3 operands, depending on the opcode.  Another
        /// opcode follows immediately after the last operand.
        ///
        /// There are 6 opcodes numbered from 0 through 5.  0 is the
        /// "halt" opcode and causes the test to end.
        ///
        ///    0          Halt and return the number of errors
        ///    1 N S X    Set N bits beginning with S and incrementing by X
        ///    2 N S X    Clear N bits beginning with S and incrementing by X
        ///    3 N        Set N randomly chosen bits
        ///    4 N        Clear N randomly chosen bits
        ///    5 N S X    Set N bits from S increment X in array only, not in bitvec
        ///
        /// The opcodes 1 through 4 perform set and clear operations are performed
        /// on both a Bitvec object and on a linear array of bits obtained from malloc.
        /// Opcode 5 works on the linear array only, not on the Bitvec.
        /// Opcode 5 is used to deliberately induce a fault in order to
        /// confirm that error detection works.
        ///
        /// At the conclusion of the test the linear array is compared
        /// against the Bitvec object.  If there are any differences,
        /// an error is returned.  If they are the same, zero is returned.
        ///
        /// If a memory allocation error occurs, return -1.
        /// </summary>
        static int sqlite3BitvecBuiltinTest(u32 sz, int[] aOp)
        {
            Bitvec pBitvec = null;
            byte[] pV = null;
            int rc = -1;
            int i, nx, pc, op;
            u32[] pTmpSpace;

            /* Allocate the Bitvec to be tested and a linear array of
			** bits to act as the reference */
            pBitvec = sqlite3BitvecCreate(sz);
            pV = sqlite3_malloc((int)(sz + 7) / 8 + 1);
            pTmpSpace = new u32[BITVEC_SZ];// sqlite3_malloc( BITVEC_SZ );
            if (pBitvec == null || pV == null || pTmpSpace == null)
                goto bitvec_end;
            Array.Clear(pV, 0, (int)(sz + 7) / 8 + 1);// memset( pV, 0, ( sz + 7 ) / 8 + 1 );

            /* NULL pBitvec tests */
            sqlite3BitvecSet(null, (u32)1);
            sqlite3BitvecClear(null, 1, pTmpSpace);

            /* Run the program */
            pc = 0;
            while ((op = aOp[pc]) != 0)
            {
                switch (op)
                {
                    case 1:
                    case 2:
                    case 5:
                        {
                            nx = 4;
                            i = aOp[pc + 2] - 1;
                            aOp[pc + 2] += aOp[pc + 3];
                            break;
                        }
                    case 3:
                    case 4:
                    default:
                        {
                            nx = 2;
                            i64 i64Temp = 0;
                            sqlite3_randomness(sizeof(i64), ref i64Temp);
                            i = (int)i64Temp;
                            break;
                        }
                }
                if ((--aOp[pc + 1]) > 0)
                    nx = 0;
                pc += nx;
                i = (int)((i & 0x7fffffff) % sz);
                if ((op & 1) != 0)
                {
                    SETBIT(pV, (i + 1));
                    if (op != 5)
                    {
                        if (sqlite3BitvecSet(pBitvec, (u32)i + 1) != 0)
                            goto bitvec_end;
                    }
                }
                else
                {
                    CLEARBIT(pV, (i + 1));
                    sqlite3BitvecClear(pBitvec, (u32)i + 1, pTmpSpace);
                }
            }

            /* Test to make sure the linear array exactly matches the
			** Bitvec object.  Start with the assumption that they do
			** match (rc==0).  Change rc to non-zero if a discrepancy
			** is found.
			*/
            rc = sqlite3BitvecTest(null, 0) + sqlite3BitvecTest(pBitvec, sz + 1)
            + sqlite3BitvecTest(pBitvec, 0)
            + (int)(sqlite3BitvecSize(pBitvec) - sz);
            for (i = 1; i <= sz; i++)
            {
                if ((TESTBIT(pV, i)) != sqlite3BitvecTest(pBitvec, (u32)i))
                {
                    rc = i;
                    break;
                }
            }

        /* Free allocated structure */
        bitvec_end:
            //sqlite3_free( ref pTmpSpace );
            //sqlite3_free( ref pV );
            sqlite3BitvecDestroy(ref pBitvec);
            return rc;
        }
#endif //* SQLITE_OMIT_BUILTIN_TEST */
    }
}
