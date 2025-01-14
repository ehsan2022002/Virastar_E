#define SQLITE_OS_WIN

using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DWORD = System.UInt64;
using HANDLE = System.IntPtr;
using i64 = System.Int64;
using sqlite3_int64 = System.Int64;
using u32 = System.UInt32;
using u8 = System.Byte;
#if WINDOWS_PHONE
using System.IO.IsolatedStorage;
#endif
namespace System.Data.SQLite
{
    public partial class Sqlite3
    {
        /*
		** 2004 May 22
		**
		** The author disclaims copyright to this source code.  In place of
		** a legal notice, here is a blessing:
		**
		**    May you do good and not evil.
		**    May you find forgiveness for yourself and forgive others.
		**    May you share freely, never taking more than you give.
		**
		******************************************************************************
		**
		** This file contains code that is specific to windows.
		*************************************************************************
		**  Included in SQLite3 port to C#-SQLite;  2008 Noah B Hart
		**  C#-SQLite is an independent reimplementation of the SQLite software library
		**
		**  SQLITE_SOURCE_ID: 2011-06-23 19:49:22 4374b7e83ea0a3fbc3691f9c0c936272862f32f2
		**
		*************************************************************************
		*/
        //#include "sqliteInt.h"
#if SQLITE_OS_WIN               // * This file is used for windows only */

        /*
** A Note About Memory Allocation:
**
** This driver uses malloc()/free() directly rather than going through
** the SQLite-wrappers sqlite3Malloc()/sqlite3DbFree(db,ref  ).  Those wrappers
** are designed for use on embedded systems where memory is scarce and
** malloc failures happen frequently.  Win32 does not typically run on
** embedded systems, and when it does the developers normally have bigger
** problems to worry about than running out of memory.  So there is not
** a compelling need to use the wrappers.
**
** But there is a good reason to not use the wrappers.  If we use the
** wrappers then we will get simulated malloc() failures within this
** driver.  And that causes all kinds of problems for our tests.  We
** could enhance SQLite to deal with simulated malloc failures within
** the OS driver, but the code to deal with those failure would not
** be exercised on Linux (which does not need to malloc() in the driver)
** and so we would have difficulty writing coverage tests for that
** code.  Better to leave the code out, we think.
**
** The point of this discussion is as follows:  When creating a new
** OS layer for an embedded system, if you use this file as an example,
** avoid the use of malloc()/free().  Those routines work ok on windows
** desktops but not so well in embedded systems.
*/

        //#include <winbase.h>

#if __CYGWIN__
//# include <sys/cygwin.h>
#endif

        /*
** Macros used to determine whether or not to use threads.
*/
#if THREADSAFE
//# define SQLITE_W32_THREADS 1
#endif

        /*
** Include code that is common to all os_*.c files
*/
        //#include "os_common.h"

        /*
		** Some microsoft compilers lack this definition.
		*/
#if !INVALID_FILE_ATTRIBUTES
        //# define INVALID_FILE_ATTRIBUTES ((DWORD)-1)
        const int INVALID_FILE_ATTRIBUTES = -1;
#endif

        /*
** Determine if we are dealing with WindowsCE - which has a much
** reduced API.
*/
#if SQLITE_OS_WINCE
//# define AreFileApisANSI() 1
//# define GetDiskFreeSpaceW() 0
#endif

        /* Forward references */
        //typedef struct winShm winShm;           /* A connection to shared-memory */
        //typedef struct winShmNode winShmNode;   /* A region of shared-memory */

        /*
		** WinCE lacks native support for file locking so we have to fake it
		** with some code of our own.
		*/
#if SQLITE_OS_WINCE
typedef struct winceLock {
int nReaders;       /* Number of reader locks obtained */
BOOL bPending;      /* Indicates a pending lock has been obtained */
BOOL bReserved;     /* Indicates a reserved lock has been obtained */
BOOL bExclusive;    /* Indicates an exclusive lock has been obtained */
} winceLock;
#endif

        private static LockingStrategy lockingStrategy = HelperMethods.IsRunningMediumTrust() ? new MediumTrustLockingStrategy() : new LockingStrategy();

        /*
		** The winFile structure is a subclass of sqlite3_file* specific to the win32
		** portability layer.
		*/
        //typedef struct sqlite3_file sqlite3_file;
        public partial class sqlite3_file
        {
            public sqlite3_vfs pVfs;       /* The VFS used to open this file */
            public FileStream fs;          /* Filestream access to this file*/
            // public HANDLE h;            /* Handle for accessing the file */
            public int locktype;           /* Type of lock currently held on this file */
            public int sharedLockByte;     /* Randomly chosen byte used as a shared lock */
            public DWORD lastErrno;        /* The Windows errno from the last I/O error */
            public DWORD sectorSize;       /* Sector size of the device file is on */
#if !SQLITE_OMIT_WAL
public winShm pShm;            /* Instance of shared memory on this file */
#else
            public object pShm;            /* DUMMY Instance of shared memory on this file */
#endif
            public string zPath;           /* Full pathname of this file */
            public int szChunk;            /* Chunk size configured by FCNTL_CHUNK_SIZE */
#if SQLITE_OS_WINCE
Wstring zDeleteOnClose;  /* Name of file to delete when closing */
HANDLE hMutex;          /* Mutex used to control access to shared lock */
HANDLE hShared;         /* Shared memory segment used for locking */
winceLock local;        /* Locks obtained by this instance of sqlite3_file */
winceLock *shared;      /* Global shared lock memory for the file  */
#endif

            public void Clear()
            {
                pMethods = null;
                fs = null;
                locktype = 0;
                sharedLockByte = 0;
                lastErrno = 0;
                sectorSize = 0;
            }
        };

        /*
		** Forward prototypes.
		*/
        //static int getSectorSize(
        //    sqlite3_vfs *pVfs,
        //    string zRelative     /* UTF-8 file name */
        //);

        /*
		** The following variable is (normally) set once and never changes
		** thereafter.  It records whether the operating system is Win95
		** or WinNT.
		**
		** 0:   Operating system unknown.
		** 1:   Operating system is Win95.
		** 2:   Operating system is WinNT.
		**
		** In order to facilitate testing on a WinNT system, the test fixture
		** can manually set this value to 1 to emulate Win98 behavior.
		*/
#if SQLITE_TEST
	int sqlite3_os_type = 0;
#else
        static int sqlite3_os_type = 0;
#endif

        static bool isNT()
        {
            return Environment.OSVersion.Platform >= PlatformID.Win32NT;
        }

        /*
	** Convert a UTF-8 string to microsoft unicode (UTF-16?).
	**
	** Space to hold the returned string is obtained from malloc.
	*/
        //static WCHAR *utf8ToUnicode(string zFilename){
        //  int nChar;
        //  Wstring zWideFilename;

        //  nChar = MultiByteToWideChar(CP_UTF8, 0, zFilename, -1, NULL, 0);
        //  zWideFilename = malloc( nChar*sizeof(zWideFilename[0]) );
        //  if( zWideFilename==0 ){
        //    return 0;
        //  }
        //  nChar = MultiByteToWideChar(CP_UTF8, 0, zFilename, -1, zWideFilename, nChar);
        //  if( nChar==0 ){
        //    free(zWideFilename);
        //    zWideFileName = "";
        //  }
        //  return zWideFilename;
        //}

        /*
		** Convert microsoft unicode to UTF-8.  Space to hold the returned string is
		** obtained from malloc().
		*/
        //static char *unicodeToUtf8(const Wstring zWideFilename){
        //  int nByte;
        //  string zFilename;

        //  nByte = WideCharToMultiByte(CP_UTF8, 0, zWideFilename, -1, 0, 0, 0, 0);
        //  zFilename = malloc( nByte );
        //  if( zFilename==0 ){
        //    return 0;
        //  }
        //  nByte = WideCharToMultiByte(CP_UTF8, 0, zWideFilename, -1, zFilename, nByte,
        //                              0, 0);
        //  if( nByte == 0 ){
        //    free(zFilename);
        //    zFileName = "";
        //  }
        //  return zFilename;
        //}

        /*
		** Convert an ansi string to microsoft unicode, based on the
		** current codepage settings for file apis.
		**
		** Space to hold the returned string is obtained
		** from malloc.
		*/
        //static WCHAR *mbcsToUnicode(string zFilename){
        //  int nByte;
        //  Wstring zMbcsFilename;
        //  int codepage = AreFileApisANSI() ? CP_ACP : CP_OEMCP;

        //  nByte = MultiByteToWideChar(codepage, 0, zFilename, -1, NULL,0)*WCHAR.Length;
        //  zMbcsFilename = malloc( nByte*sizeof(zMbcsFilename[0]) );
        //  if( zMbcsFilename==0 ){
        //    return 0;
        //  }
        //  nByte = MultiByteToWideChar(codepage, 0, zFilename, -1, zMbcsFilename, nByte);
        //  if( nByte==0 ){
        //    free(zMbcsFilename);
        //    zMbcsFileName = "";
        //  }
        //  return zMbcsFilename;
        //}

        /*
		** Convert microsoft unicode to multibyte character string, based on the
		** user's Ansi codepage.
		**
		** Space to hold the returned string is obtained from
		** malloc().
		*/
        //static char *unicodeToMbcs(const Wstring zWideFilename){
        //  int nByte;
        //  string zFilename;
        //  int codepage = AreFileApisANSI() ? CP_ACP : CP_OEMCP;

        //  nByte = WideCharToMultiByte(codepage, 0, zWideFilename, -1, 0, 0, 0, 0);
        //  zFilename = malloc( nByte );
        //  if( zFilename==0 ){
        //    return 0;
        //  }
        //  nByte = WideCharToMultiByte(codepage, 0, zWideFilename, -1, zFilename, nByte,
        //                              0, 0);
        //  if( nByte == 0 ){
        //    free(zFilename);
        //    zFileName = "";
        //  }
        //  return zFilename;
        //}

        /*
		** Convert multibyte character string to UTF-8.  Space to hold the
		** returned string is obtained from malloc().
		*/
        //static char *sqlite3_win32_mbcs_to_utf8(string zFilename){
        //  string zFilenameUtf8;
        //  Wstring zTmpWide;

        //  zTmpWide = mbcsToUnicode(zFilename);
        //  if( zTmpWide==0 ){
        //    return 0;
        //  }
        //  zFilenameUtf8 = unicodeToUtf8(zTmpWide);
        //  free(zTmpWide);
        //  return zFilenameUtf8;
        //}

        /*
		** Convert UTF-8 to multibyte character string.  Space to hold the
		** returned string is obtained from malloc().
		*/
        //char *sqlite3_win32_utf8_to_mbcs(string zFilename){
        //  string zFilenameMbcs;
        //  Wstring zTmpWide;

        //  zTmpWide = utf8ToUnicode(zFilename);
        //  if( zTmpWide==0 ){
        //    return 0;
        //  }
        //  zFilenameMbcs = unicodeToMbcs(zTmpWide);
        //  free(zTmpWide);
        //  return zFilenameMbcs;
        //}

        /*
		** The return value of getLastErrorMsg
		** is zero if the error message fits in the buffer, or non-zero
		** otherwise (if the message was truncated).
		*/
        static int getLastErrorMsg(int nBuf, ref string zBuf)
        {
            zBuf = Marshal.GetLastWin32Error().ToString();//new Win32Exception( Marshal.GetLastWin32Error() ).Message;
            return 0;
        }

        /*
		**
		** This function - winLogErrorAtLine() - is only ever called via the macro
		** winLogError().
		**
		** This routine is invoked after an error occurs in an OS function.
		** It logs a message using sqlite3_log() containing the current value of
		** error code and, if possible, the human-readable equivalent from 
		** FormatMessage.
		**
		** The first argument passed to the macro should be the error code that
		** will be returned to SQLite (e.g. SQLITE_IOERR_DELETE, SQLITE_CANTOPEN). 
		** The two subsequent arguments should be the name of the OS function that
		** failed and the the associated file-system path, if any.
		*/
        //#define winLogError(a,b,c)     winLogErrorAtLine(a,b,c,__LINE__)
        static int winLogError(int a, string b, string c)
        {
            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            return winLogErrorAtLine(a, b, c, sf.GetFileLineNumber());
        }

        static int winLogErrorAtLine(
          int errcode,                    /* SQLite error code */
          string zFunc,                   /* Name of OS function that failed */
          string zPath,                   /* File path associated with error */
          int iLine                       /* Source line number where error occurred */
        )
        {
            string zMsg = null;             /* Human readable error text */
            int i;                          /* Loop counter */
            DWORD iErrno;// = GetLastError();  /* Error code */
            iErrno = (u32)Marshal.GetLastWin32Error();

            //zMsg[0] = 0;
            getLastErrorMsg(500, ref zMsg);
            Debug.Assert(errcode != SQLITE_OK);
            if (zPath == null)
                zPath = "";
            for (i = 0; i < zMsg.Length && zMsg[i] != '\r' && zMsg[i] != '\n'; i++)
            {
            }
            zMsg = zMsg.Substring(0, i);
            sqlite3_log(errcode,
                "os_win.c:%d: (%d) %s(%s) - %s",
                iLine, iErrno, zFunc, zPath, zMsg
            );

            return errcode;
        }
#if !INVALID_SET_FILE_POINTER
        //# define INVALID_SET_FILE_POINTER ((DWORD)-1)
        const int INVALID_SET_FILE_POINTER = -1;
#endif

        /*
** Move the current position of the file handle passed as the first 
** argument to offset iOffset within the file. If successful, return 0. 
** Otherwise, set pFile->lastErrno and return non-zero.
*/
        static int seekWinFile(sqlite3_file id, sqlite3_int64 iOffset)
        {
            //LONG upperBits;                 /* Most sig. 32 bits of new offset */
            //LONG lowerBits;                 /* Least sig. 32 bits of new offset */
            DWORD dwRet;                    /* Value returned by SetFilePointer() */
            sqlite3_file pFile = id;

            //upperBits = (LONG)((iOffset>>32) & 0x7fffffff);
            //lowerBits = (LONG)(iOffset & 0xffffffff);

            /* API oddity: If successful, SetFilePointer() returns a dword 
			** containing the lower 32-bits of the new file-offset. Or, if it fails,
			** it returns INVALID_SET_FILE_POINTER. However according to MSDN, 
			** INVALID_SET_FILE_POINTER may also be a valid new offset. So to determine 
			** whether an error has actually occured, it is also necessary to call 
			** GetLastError().
			*/
            //dwRet = SetFilePointer(id, lowerBits, &upperBits, FILE_BEGIN);
            //if( (dwRet==INVALID_SET_FILE_POINTER && GetLastError()!=NO_ERROR) ){
            //  pFile->lastErrno = GetLastError();
            //  winLogError(SQLITE_IOERR_SEEK, "seekWinFile", pFile->zPath);
            try
            {
                id.fs.Seek(iOffset, SeekOrigin.Begin); // SetFilePointer(pFile.fs.Name, lowerBits, upperBits, FILE_BEGIN);
            }
            catch
            {
                pFile.lastErrno = (u32)Marshal.GetLastWin32Error();
                winLogError(SQLITE_IOERR_SEEK, "seekWinFile", pFile.zPath);
                return 1;
            }

            return 0;
        }

        /*
		** Close a file.
		**
		** It is reported that an attempt to close a handle might sometimes
		** fail.  This is a very unreasonable result, but windows is notorious
		** for being unreasonable so I do not doubt that it might happen.  If
		** the close fails, we pause for 100 milliseconds and try again.  As
		** many as MX_CLOSE_ATTEMPT attempts to close the handle are made before
		** giving up and returning an error.
		*/
        public static int MX_CLOSE_ATTEMPT = 3;
        static int winClose(sqlite3_file id)
        {
            bool rc;
            int cnt = 0;
            sqlite3_file pFile = (sqlite3_file)id;

            Debug.Assert(id != null);
            Debug.Assert(pFile.pShm == null);
#if SQLITE_DEBUG
	  OSTRACE( "CLOSE %d (%s)\n", pFile.fs.GetHashCode(), pFile.fs.Name );
#endif
            do
            {
                pFile.fs.Close();
                rc = true;
            } while (!rc && ++cnt < MX_CLOSE_ATTEMPT); //, 1) );
#if SQLITE_TEST
	  OSTRACE( "CLOSE %d %s\n", pFile.fs.GetHashCode(), rc ? "ok" : "failed" );
	  OpenCounter( -1 );
#endif
            return rc ? SQLITE_OK : winLogError(SQLITE_IOERR_CLOSE, "winClose", pFile.zPath);
        }


        /*
		** Read data from a file into a buffer.  Return SQLITE_OK if all
		** bytes were read successfully and SQLITE_IOERR if anything goes
		** wrong.
		*/
        static int winRead(
        sqlite3_file id,           /* File to read from */
        byte[] pBuf,               /* Write content into this buffer */
        int amt,                   /* Number of bytes to read */
        sqlite3_int64 offset       /* Begin reading at this offset */
        )
        {

            long rc;
            sqlite3_file pFile = id;
            int nRead;                    /* Number of bytes actually read from file */

            Debug.Assert(id != null);
#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_IOERR_READ;
#endif
#if SQLITE_DEBUG
	  OSTRACE( "READ %d lock=%d\n", pFile.fs.GetHashCode(), pFile.locktype );
#endif
            if (!id.fs.CanRead)
                return SQLITE_IOERR_READ;
            if (seekWinFile(pFile, offset) != 0)
            {
                return SQLITE_FULL;
            }

            try
            {
                nRead = id.fs.Read(pBuf, 0, amt); // i  if( null==ReadFile(pFile->h, pBuf, amt, &nRead, 0) ){
            }
            catch
            {
                pFile.lastErrno = (u32)Marshal.GetLastWin32Error();
                return winLogError(SQLITE_IOERR_READ, "winRead", pFile.zPath);
            }
            if (nRead < amt)
            {
                /* Unread parts of the buffer must be zero-filled */
                Array.Clear(pBuf, (int)nRead, (int)(amt - nRead)); // memset(&((char)pBuf)[nRead], 0, amt-nRead);
                return SQLITE_IOERR_SHORT_READ;
            }
            return SQLITE_OK;
        }

        /*
		** Write data from a buffer into a file.  Return SQLITE_OK on success
		** or some other error code on failure.
		*/
        static int winWrite(
        sqlite3_file id,          /* File to write into */
        byte[] pBuf,              /* The bytes to be written */
        int amt,                  /* Number of bytes to write */
        sqlite3_int64 offset      /* Offset into the file to begin writing at */
        )
        {
            int rc;                         /* True if error has occured, else false */
            sqlite3_file pFile = id;        /* File handle */

            Debug.Assert(amt > 0);
            Debug.Assert(pFile != null);

#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_IOERR_WRITE;
	  if ( SimulateDiskfullError() )
		return SQLITE_FULL;
#endif
#if SQLITE_DEBUG
	  OSTRACE( "WRITE %d lock=%d\n", id.fs.GetHashCode(), id.locktype );
#endif
            rc = seekWinFile(pFile, offset);
            //if( rc==0 ){
            //  u8 *aRem = (u8 )pBuf;        /* Data yet to be written */
            //  int nRem = amt;               /* Number of bytes yet to be written */
            //  DWORD nWrite;                 /* Bytes written by each WriteFile() call */

            //  while( nRem>0 && WriteFile(pFile->h, aRem, nRem, &nWrite, 0) && nWrite>0 ){
            //    aRem += nWrite;
            //    nRem -= nWrite;
            //  }
            long wrote = id.fs.Position;
            try
            {
                Debug.Assert(pBuf.Length >= amt);
                id.fs.Write(pBuf, 0, amt);
                rc = 1;// Success
                wrote = id.fs.Position - wrote;
            }
            catch
            {
                return SQLITE_READONLY;
            }

            if (rc == 0 || amt > (int)wrote)
            {
                id.lastErrno = (u32)Marshal.GetLastWin32Error();
                if ((id.lastErrno == ERROR_HANDLE_DISK_FULL) || (id.lastErrno == ERROR_DISK_FULL))
                {
                    return SQLITE_FULL;
                }
                else
                {
                    return winLogError(SQLITE_IOERR_WRITE, "winWrite", pFile.zPath);
                }
            }
            return SQLITE_OK;
        }

        /*
		** Truncate an open file to a specified size
		*/
        static int winTruncate(sqlite3_file id, sqlite3_int64 nByte)
        {
            sqlite3_file pFile = id;        /* File handle object */
            int rc = SQLITE_OK;             /* Return code for this function */

            Debug.Assert(pFile != null);
#if SQLITE_DEBUG
	  OSTRACE( "TRUNCATE %d %lld\n", id.fs.Name, nByte );
#endif
#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_IOERR_TRUNCATE;
	  if ( SimulateIOError() )
		return SQLITE_IOERR_TRUNCATE;
#endif

            /* If the user has configured a chunk-size for this file, truncate the
** file so that it consists of an integer number of chunks (i.e. the
** actual file size after the operation may be larger than the requested
** size).
*/

            if (pFile.szChunk != 0)
            {
                nByte = ((nByte + pFile.szChunk - 1) / pFile.szChunk) * pFile.szChunk;
            }
            try
            {
                id.fs.SetLength(nByte);
                rc = SQLITE_OK;
            }
            catch
            {
                id.lastErrno = (u32)Marshal.GetLastWin32Error();
                rc = winLogError(SQLITE_IOERR_TRUNCATE, "winTruncate2", pFile.zPath);
            }
            OSTRACE("TRUNCATE %d %lld %s\n", id.fs.GetHashCode(), nByte, rc == SQLITE_OK ? "ok" : "failed");
            return rc;
        }

#if SQLITE_TEST
	/*
** Count the number of fullsyncs and normal syncs.  This is used to test
** that syncs and fullsyncs are occuring at the right times.
*/
#if !TCLSH
	static int sqlite3_sync_count = 0;
	static int sqlite3_fullsync_count = 0;
#else
	static tcl.lang.Var.SQLITE3_GETSET sqlite3_sync_count = new tcl.lang.Var.SQLITE3_GETSET( "sqlite3_sync_count" );
	static tcl.lang.Var.SQLITE3_GETSET sqlite3_fullsync_count = new tcl.lang.Var.SQLITE3_GETSET( "sqlite_fullsync_count" );
#endif
#endif

        /*
** Make sure all writes to a particular file are committed to disk.
*/
        static int winSync(sqlite3_file id, int flags)
        {
#if !(NDEBUG) || !(SQLITE_NO_SYNC) || (SQLITE_DEBUG)
            sqlite3_file pFile = (sqlite3_file)id;
            bool rc;
#else
	  UNUSED_PARAMETER(id);
#endif
            Debug.Assert(pFile != null);
            /* Check that one of SQLITE_SYNC_NORMAL or FULL was passed */
            Debug.Assert((flags & 0x0F) == SQLITE_SYNC_NORMAL || (flags & 0x0F) == SQLITE_SYNC_FULL);
            OSTRACE("SYNC %d lock=%d\n", pFile.fs.GetHashCode(), pFile.locktype);
            /* Unix cannot, but some systems may return SQLITE_FULL from here. This
			** line is to test that doing so does not cause any problems.
			*/
#if SQLITE_TEST
	  if ( SimulateDiskfullError() )
		return SQLITE_FULL;
#endif
#if !SQLITE_TEST
            UNUSED_PARAMETER(flags);
#else
	  if ( (flags&0x0F)==SQLITE_SYNC_FULL )
	  {
#if !TCLSH
		sqlite3_fullsync_count++;
	  }
	  sqlite3_sync_count++;
#else
		sqlite3_fullsync_count.iValue++;
	  }
	  sqlite3_sync_count.iValue++;
#endif
#endif


            /* If we compiled with the SQLITE_NO_SYNC flag, then syncing is a
** no-op
*/
#if SQLITE_NO_SYNC
	  return SQLITE_OK;
#else
            pFile.fs.Flush();
            return SQLITE_OK;
#endif
        }

        // Determine the current size of a file in bytes
        static int winFileSize(sqlite3_file id, ref long pSize)
        {
            Debug.Assert(id != null);
#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_IOERR_FSTAT;
#endif
            pSize = id.fs.CanRead ? id.fs.Length : 0;
            return SQLITE_OK;
        }


        /*
		** Acquire a reader lock.
		** Different API routines are called depending on whether or not this
		** is Win95 or WinNT.
		*/
        static int getReadLock(sqlite3_file pFile)
        {
            int res = 0;
            if (isNT())
            {
                res = lockingStrategy.SharedLockFile(pFile, SHARED_FIRST, SHARED_SIZE);
            }
            if (res == 0)
            {
                pFile.lastErrno = (u32)Marshal.GetLastWin32Error();
            }
            /* No need to log a failure to lock */
            return res;
        }

        /*
		** Undo a readlock
		*/
        static int unlockReadLock(sqlite3_file pFile)
        {
            int res = 1;
            if (isNT())
            {
                try
                {
                    lockingStrategy.UnlockFile(pFile, SHARED_FIRST, SHARED_SIZE); //     res = UnlockFile(pFile.h, SHARED_FIRST, 0, SHARED_SIZE, 0);
                }
                catch
                {
                    res = 0;
                }
            }
            // isNT() is 1 if SQLITE_OS_WINCE==1, so this else is never executed.
            if (res == 0)
            {
                pFile.lastErrno = (u32)Marshal.GetLastWin32Error();
                winLogError(SQLITE_IOERR_UNLOCK, "unlockReadLock", pFile.zPath);
            }
            return res;
        }

        /*
		   Lock the file with the lock specified by parameter locktype - one
		   of the following:
	  
			   (1) SHARED_LOCK
			   (2) RESERVED_LOCK
			   (3) PENDING_LOCK
			   (4) EXCLUSIVE_LOCK
	  
		   Sometimes when requesting one lock state, additional lock states
		   are inserted in between.  The locking might fail on one of the later
		   transitions leaving the lock state different from what it started but
		   still short of its goal.  The following chart shows the allowed
		   transitions and the inserted intermediate states:
	  
			  UNLOCKED . SHARED
			  SHARED . RESERVED
			  SHARED . (PENDING) . EXCLUSIVE
			  RESERVED . (PENDING) . EXCLUSIVE
			  PENDING . EXCLUSIVE
	  
		   This routine will only increase a lock.  The winUnlock() routine
		   erases all locks at once and returns us immediately to locking level 0.
		   It is not possible to lower the locking level one step at a time.  You
		   must go straight to locking level 0.
		*/
        static int winLock(sqlite3_file id, int locktype)
        {
            int rc = SQLITE_OK;         /* Return code from subroutines */
            int res = 1;                /* Result of a windows lock call */
            int newLocktype;            /* Set pFile.locktype to this value before exiting */
            bool gotPendingLock = false;/* True if we acquired a PENDING lock this time */
            sqlite3_file pFile = (sqlite3_file)id;
            DWORD error = NO_ERROR;

            Debug.Assert(id != null);
#if SQLITE_DEBUG
	  OSTRACE( "LOCK %d %d was %d(%d)\n",
	  pFile.fs.GetHashCode(), locktype, pFile.locktype, pFile.sharedLockByte );
#endif
            /* If there is already a lock of this type or more restrictive on the
** OsFile, do nothing. Don't use the end_lock: exit path, as
** sqlite3OsEnterMutex() hasn't been called yet.
*/
            if (pFile.locktype >= locktype)
            {
                return SQLITE_OK;
            }
            /* Lock the PENDING_LOCK byte if we need to acquire a PENDING lock or
			** a SHARED lock.  If we are acquiring a SHARED lock, the acquisition of
			** the PENDING_LOCK byte is temporary.
			*/
            newLocktype = pFile.locktype;
            if (pFile.locktype == NO_LOCK
            || ((locktype == EXCLUSIVE_LOCK)
            && (pFile.locktype == RESERVED_LOCK))
            )
            {
                int cnt = 3;
                res = 0;
                while (cnt-- > 0 && res == 0)//(res = LockFile(pFile.fs.SafeFileHandle.DangerousGetHandle().ToInt32(), PENDING_BYTE, 0, 1, 0)) == 0)
                {
                    try
                    {
                        lockingStrategy.LockFile(pFile, PENDING_BYTE, 1);
                        res = 1;
                    }
                    catch
                    {
                        /* Try 3 times to get the pending lock.  The pending lock might be
						** held by another reader process who will release it momentarily.
						*/
#if SQLITE_DEBUG
			OSTRACE( "could not get a PENDING lock. cnt=%d\n", cnt );
#endif
                        Thread.Sleep(1);
                    }
                }
                gotPendingLock = (res != 0);
                if (0 == res)
                {
                    error = (u32)Marshal.GetLastWin32Error();
                }
            }

            /* Acquire a shared lock
			*/
            if (locktype == SHARED_LOCK && res != 0)
            {
                Debug.Assert(pFile.locktype == NO_LOCK);
                res = getReadLock(pFile);
                if (res != 0)
                {
                    newLocktype = SHARED_LOCK;
                }
                else
                {
                    error = (u32)Marshal.GetLastWin32Error();
                }
            }

            /* Acquire a RESERVED lock
			*/
            if ((locktype == RESERVED_LOCK) && res != 0)
            {
                Debug.Assert(pFile.locktype == SHARED_LOCK);
                try
                {
                    lockingStrategy.LockFile(pFile, RESERVED_BYTE, 1);//res = LockFile(pFile.fs.SafeFileHandle.DangerousGetHandle().ToInt32(), RESERVED_BYTE, 0, 1, 0);
                    newLocktype = RESERVED_LOCK;
                    res = 1;
                }
                catch
                {
                    res = 0;
                    error = (u32)Marshal.GetLastWin32Error();
                }
                if (res != 0)
                {
                    newLocktype = RESERVED_LOCK;
                }
                else
                {
                    error = (u32)Marshal.GetLastWin32Error();
                }
            }

            /* Acquire a PENDING lock
			*/
            if (locktype == EXCLUSIVE_LOCK && res != 0)
            {
                newLocktype = PENDING_LOCK;
                gotPendingLock = false;
            }

            /* Acquire an EXCLUSIVE lock
			*/
            if (locktype == EXCLUSIVE_LOCK && res != 0)
            {
                Debug.Assert(pFile.locktype >= SHARED_LOCK);
                res = unlockReadLock(pFile);
#if SQLITE_DEBUG
		OSTRACE( "unreadlock = %d\n", res );
#endif
                //res = LockFile(pFile.fs.SafeFileHandle.DangerousGetHandle().ToInt32(), SHARED_FIRST, 0, SHARED_SIZE, 0);
                try
                {
                    lockingStrategy.LockFile(pFile, SHARED_FIRST, SHARED_SIZE);
                    newLocktype = EXCLUSIVE_LOCK;
                    res = 1;
                }
                catch
                {
                    res = 0;
                }
                if (res != 0)
                {
                    newLocktype = EXCLUSIVE_LOCK;
                }
                else
                {
                    error = (u32)Marshal.GetLastWin32Error();
#if SQLITE_DEBUG
		  OSTRACE( "error-code = %d\n", error );
#endif
                    getReadLock(pFile);
                }
            }

            /* If we are holding a PENDING lock that ought to be released, then
			** release it now.
			*/
            if (gotPendingLock && locktype == SHARED_LOCK)
            {
                lockingStrategy.UnlockFile(pFile, PENDING_BYTE, 1);
            }

            /* Update the state of the lock has held in the file descriptor then
			** return the appropriate result code.
			*/
            if (res != 0)
            {
                rc = SQLITE_OK;
            }
            else
            {
#if SQLITE_DEBUG
		OSTRACE( "LOCK FAILED %d trying for %d but got %d\n", pFile.fs.GetHashCode(),
		locktype, newLocktype );
#endif
                pFile.lastErrno = error;
                rc = SQLITE_BUSY;
            }
            pFile.locktype = (u8)newLocktype;
            return rc;
        }

        /*
		** This routine checks if there is a RESERVED lock held on the specified
		** file by this or any other process. If such a lock is held, return
		** non-zero, otherwise zero.
		*/
        static int winCheckReservedLock(sqlite3_file id, ref int pResOut)
        {
            int rc;
            sqlite3_file pFile = (sqlite3_file)id;

            if (SimulateIOError())
                return SQLITE_IOERR_CHECKRESERVEDLOCK;

            Debug.Assert(id != null);
            if (pFile.locktype >= RESERVED_LOCK)
            {
                rc = 1;
#if SQLITE_DEBUG
		OSTRACE( "TEST WR-LOCK %d %d (local)\n", pFile.fs.Name, rc );
#endif
            }
            else
            {
                try
                {
                    lockingStrategy.LockFile(pFile, RESERVED_BYTE, 1);
                    lockingStrategy.UnlockFile(pFile, RESERVED_BYTE, 1);
                    rc = 1;
                }
                catch
                {
                    rc = 0;
                }
                rc = 1 - rc; // !rc
#if SQLITE_DEBUG
		OSTRACE( "TEST WR-LOCK %d %d (remote)\n", pFile.fs.GetHashCode(), rc );
#endif
            }
            pResOut = rc;
            return SQLITE_OK;
        }

        /*
		** Lower the locking level on file descriptor id to locktype.  locktype
		** must be either NO_LOCK or SHARED_LOCK.
		**
		** If the locking level of the file descriptor is already at or below
		** the requested locking level, this routine is a no-op.
		**
		** It is not possible for this routine to fail if the second argument
		** is NO_LOCK.  If the second argument is SHARED_LOCK then this routine
		** might return SQLITE_IOERR;
		*/
        static int winUnlock(sqlite3_file id, int locktype)
        {
            int type;
            sqlite3_file pFile = (sqlite3_file)id;
            int rc = SQLITE_OK;
            Debug.Assert(pFile != null);
            Debug.Assert(locktype <= SHARED_LOCK);

#if SQLITE_DEBUG
	  OSTRACE( "UNLOCK %d to %d was %d(%d)\n", pFile.fs.GetHashCode(), locktype,
	  pFile.locktype, pFile.sharedLockByte );
#endif
            type = pFile.locktype;
            if (type >= EXCLUSIVE_LOCK)
            {
                lockingStrategy.UnlockFile(pFile, SHARED_FIRST, SHARED_SIZE); // UnlockFile(pFile.h, SHARED_FIRST, 0, SHARED_SIZE, 0);
                if (locktype == SHARED_LOCK && getReadLock(pFile) == 0)
                {
                    /* This should never happen.  We should always be able to
					** reacquire the read lock */
                    rc = winLogError(SQLITE_IOERR_UNLOCK, "winUnlock", pFile.zPath);
                }
            }
            if (type >= RESERVED_LOCK)
            {
                try
                {
                    lockingStrategy.UnlockFile(pFile, RESERVED_BYTE, 1);// UnlockFile(pFile.h, RESERVED_BYTE, 0, 1, 0);
                }
                catch { }
            }
            if (locktype == NO_LOCK && type >= SHARED_LOCK)
            {
                unlockReadLock(pFile);
            }
            if (type >= PENDING_LOCK)
            {
                try
                {
                    lockingStrategy.UnlockFile(pFile, PENDING_BYTE, 1);//    UnlockFile(pFile.h, PENDING_BYTE, 0, 1, 0);
                }
                catch { }
            }
            pFile.locktype = (u8)locktype;
            return rc;
        }

        /*
		** Control and query of the open file handle.
		*/
        static int winFileControl(sqlite3_file id, int op, ref sqlite3_int64 pArg)
        {
            switch (op)
            {
                case SQLITE_FCNTL_LOCKSTATE:
                    {
                        pArg = (int)((sqlite3_file)id).locktype;
                        return SQLITE_OK;
                    }
                case SQLITE_LAST_ERRNO:
                    {
                        pArg = (int)((sqlite3_file)id).lastErrno;
                        return SQLITE_OK;
                    }
                case SQLITE_FCNTL_CHUNK_SIZE:
                    {
                        ((sqlite3_file)id).szChunk = (int)pArg;
                        return SQLITE_OK;
                    }
                case SQLITE_FCNTL_SIZE_HINT:
                    {
                        sqlite3_int64 sz = (sqlite3_int64)pArg;
                        SimulateIOErrorBenign(1);
                        winTruncate(id, sz);
                        SimulateIOErrorBenign(0);
                        return SQLITE_OK;
                    }
                case SQLITE_FCNTL_SYNC_OMITTED:
                    {
                        return SQLITE_OK;
                    }
            }
            return SQLITE_NOTFOUND;
        }

        /*
		** Return the sector size in bytes of the underlying block device for
		** the specified file. This is almost always 512 bytes, but may be
		** larger for some devices.
		**
		** SQLite code assumes this function cannot fail. It also assumes that
		** if two files are created in the same file-system directory (i.e.
		** a database and its journal file) that the sector size will be the
		** same for both.
		*/
        static int winSectorSize(sqlite3_file id)
        {
            Debug.Assert(id != null);
            return (int)(id.sectorSize);
        }

        /*
		** Return a vector of device characteristics.
		*/
        static int winDeviceCharacteristics(sqlite3_file id)
        {
            UNUSED_PARAMETER(id);
            return 0;
        }

#if !SQLITE_OMIT_WAL


/* 
** Windows will only let you create file view mappings
** on allocation size granularity boundaries.
** During sqlite3_os_init() we do a GetSystemInfo()
** to get the granularity size.
*/
SYSTEM_INFO winSysInfo;

/*
** Helper functions to obtain and relinquish the global mutex. The
** global mutex is used to protect the winLockInfo objects used by 
** this file, all of which may be shared by multiple threads.
**
** Function winShmMutexHeld() is used to Debug.Assert() that the global mutex 
** is held when required. This function is only used as part of Debug.Assert() 
** statements. e.g.
**
**   winShmEnterMutex()
**     Debug.Assert( winShmMutexHeld() );
**   winShmLeaveMutex()
*/
static void winShmEnterMutex(void){
  sqlite3_mutex_enter(sqlite3MutexAlloc(SQLITE_MUTEX_STATIC_MASTER));
}
static void winShmLeaveMutex(void){
  sqlite3_mutex_leave(sqlite3MutexAlloc(SQLITE_MUTEX_STATIC_MASTER));
}
#if SQLITE_DEBUG
static int winShmMutexHeld(void) {
  return sqlite3_mutex_held(sqlite3MutexAlloc(SQLITE_MUTEX_STATIC_MASTER));
}
#endif

/*
** Object used to represent a single file opened and mmapped to provide
** shared memory.  When multiple threads all reference the same
** log-summary, each thread has its own winFile object, but they all
** point to a single instance of this object.  In other words, each
** log-summary is opened only once per process.
**
** winShmMutexHeld() must be true when creating or destroying
** this object or while reading or writing the following fields:
**
**      nRef
**      pNext 
**
** The following fields are read-only after the object is created:
** 
**      fid
**      zFilename
**
** Either winShmNode.mutex must be held or winShmNode.nRef==0 and
** winShmMutexHeld() is true when reading or writing any other field
** in this structure.
**
*/
struct winShmNode {
  sqlite3_mutex *mutex;      /* Mutex to access this object */
  string zFilename;           /* Name of the file */
  winFile hFile;             /* File handle from winOpen */

  int szRegion;              /* Size of shared-memory regions */
  int nRegion;               /* Size of array apRegion */
  struct ShmRegion {
	HANDLE hMap;             /* File handle from CreateFileMapping */
	void *pMap;
  } *aRegion;
  DWORD lastErrno;           /* The Windows errno from the last I/O error */

  int nRef;                  /* Number of winShm objects pointing to this */
  winShm *pFirst;            /* All winShm objects pointing to this */
  winShmNode *pNext;         /* Next in list of all winShmNode objects */
#if SQLITE_DEBUG
  u8 nextShmId;              /* Next available winShm.id value */
#endif
};

/*
** A global array of all winShmNode objects.
**
** The winShmMutexHeld() must be true while reading or writing this list.
*/
static winShmNode *winShmNodeList = 0;

/*
** Structure used internally by this VFS to record the state of an
** open shared memory connection.
**
** The following fields are initialized when this object is created and
** are read-only thereafter:
**
**    winShm.pShmNode
**    winShm.id
**
** All other fields are read/write.  The winShm.pShmNode->mutex must be held
** while accessing any read/write fields.
*/
struct winShm {
  winShmNode *pShmNode;      /* The underlying winShmNode object */
  winShm *pNext;             /* Next winShm with the same winShmNode */
  u8 hasMutex;               /* True if holding the winShmNode mutex */
  u16 sharedMask;            /* Mask of shared locks held */
  u16 exclMask;              /* Mask of exclusive locks held */
#if SQLITE_DEBUG
  u8 id;                     /* Id of this connection with its winShmNode */
#endif
};
	
static int winShmSystemLock(
  winShmNode *pFile,    /* Apply locks to this open shared-memory segment */
  int lockType,         /* _SHM_UNLCK, _SHM_RDLCK, or _SHM_WRLCK */
  int ofst,             /* Offset to first byte to be locked/unlocked */
  int nByte             /* Number of bytes to lock or unlock */
){
  OVERLAPPED ovlp;
  DWORD dwFlags;
  int rc = 0;           /* Result code form Lock/UnlockFileEx() */

  /* Access to the winShmNode object is serialized by the caller */
  Debug.Assert( sqlite3_mutex_held(pFile->mutex) || pFile->nRef==0 );

  /* Initialize the locking parameters */
  dwFlags = LOCKFILE_FAIL_IMMEDIATELY;
  if( lockType == _SHM_WRLCK ) dwFlags |= LOCKFILE_EXCLUSIVE_LOCK;

  memset(&ovlp, 0, sizeof(OVERLAPPED));
  ovlp.Offset = ofst;

  /* Release/Acquire the system-level lock */
  if( lockType==_SHM_UNLCK ){
	rc = UnlockFileEx(pFile->hFile.h, 0, nByte, 0, &ovlp);
  }else{
	rc = LockFileEx(pFile->hFile.h, dwFlags, 0, nByte, 0, &ovlp);
  }
  
  if( rc!= 0 ){
	rc = SQLITE_OK;
  }else{
	pFile->lastErrno =  GetLastError();
	rc = SQLITE_BUSY;
  }

  OSTRACE(("SHM-LOCK %d %s %s 0x%08lx\n", 
		   pFile->hFile.h,
		   rc==SQLITE_OK ? "ok" : "failed",
		   lockType==_SHM_UNLCK ? "UnlockFileEx" : "LockFileEx",
		   pFile->lastErrno));

  return rc;
}

/* Forward references to VFS methods */
static int winOpen(sqlite3_vfs*,const char*,sqlite3_file*,int,int);
static int winDelete(sqlite3_vfs *,const char*,int);

/*
** Purge the winShmNodeList list of all entries with winShmNode.nRef==0.
**
** This is not a VFS shared-memory method; it is a utility function called
** by VFS shared-memory methods.
*/
static void winShmPurge(sqlite3_vfs *pVfs, int deleteFlag){
  winShmNode **pp;
  winShmNode *p;
  BOOL bRc;
  Debug.Assert( winShmMutexHeld() );
  pp = winShmNodeList;
  while( (p = *pp)!=0 ){
	if( p->nRef==0 ){
	  int i;
	  if( p->mutex ) sqlite3_mutex_free(p->mutex);
	  for(i=0; i<p->nRegion; i++){
		bRc = UnmapViewOfFile(p->aRegion[i].pMap);
		OSTRACE(("SHM-PURGE pid-%d unmap region=%d %s\n",
				 (int)GetCurrentProcessId(), i,
				 bRc ? "ok" : "failed"));
		bRc = CloseHandle(p->aRegion[i].hMap);
		OSTRACE(("SHM-PURGE pid-%d close region=%d %s\n",
				 (int)GetCurrentProcessId(), i,
				 bRc ? "ok" : "failed"));
	  }
	  if( p->hFile.h != INVALID_HANDLE_VALUE ){
		SimulateIOErrorBenign(1);
		winClose((sqlite3_file )&p->hFile);
		SimulateIOErrorBenign(0);
	  }
	  if( deleteFlag ){
		SimulateIOErrorBenign(1);
		winDelete(pVfs, p->zFilename, 0);
		SimulateIOErrorBenign(0);
	  }
	  *pp = p->pNext;
	  sqlite3_free(p->aRegion);
	  sqlite3_free(p);
	}else{
	  pp = p->pNext;
	}
  }
}

/*
** Open the shared-memory area associated with database file pDbFd.
**
** When opening a new shared-memory file, if no other instances of that
** file are currently open, in this process or in other processes, then
** the file must be truncated to zero length or have its header cleared.
*/
static int winOpenSharedMemory(winFile *pDbFd){
  struct winShm *p;                  /* The connection to be opened */
  struct winShmNode *pShmNode = 0;   /* The underlying mmapped file */
  int rc;                            /* Result code */
  struct winShmNode *pNew;           /* Newly allocated winShmNode */
  int nName;                         /* Size of zName in bytes */

  Debug.Assert( pDbFd->pShm==null );    /* Not previously opened */

  /* Allocate space for the new sqlite3_shm object.  Also speculatively
  ** allocate space for a new winShmNode and filename.
  */
  p = sqlite3_malloc( sizeof(*p) );
  if( p==0 ) return SQLITE_NOMEM;
  memset(p, 0, sizeof(*p));
  nName = sqlite3Strlen30(pDbFd->zPath);
  pNew = sqlite3_malloc( sizeof(*pShmNode) + nName + 15 );
  if( pNew==0 ){
	sqlite3_free(p);
	return SQLITE_NOMEM;
  }
  memset(pNew, 0, sizeof(*pNew));
  pNew->zFilename = (char)&pNew[1];
  sqlite3_snprintf(nName+15, pNew->zFilename, "%s-shm", pDbFd->zPath);
  sqlite3FileSuffix3(pDbFd->zPath, pNew->zFilename); 

  /* Look to see if there is an existing winShmNode that can be used.
  ** If no matching winShmNode currently exists, create a new one.
  */
  winShmEnterMutex();
  for(pShmNode = winShmNodeList; pShmNode; pShmNode=pShmNode->pNext){
	/* TBD need to come up with better match here.  Perhaps
	** use FILE_ID_BOTH_DIR_INFO Structure.
	*/
	if( sqlite3StrICmp(pShmNode->zFilename, pNew->zFilename)==0 ) break;
  }
  if( pShmNode ){
	sqlite3_free(pNew);
  }else{
	pShmNode = pNew;
	pNew = 0;
	((winFile)(&pShmNode->hFile))->h = INVALID_HANDLE_VALUE;
	pShmNode->pNext = winShmNodeList;
	winShmNodeList = pShmNode;

	pShmNode->mutex = sqlite3_mutex_alloc(SQLITE_MUTEX_FAST);
	if( pShmNode->mutex==0 ){
	  rc = SQLITE_NOMEM;
	  goto shm_open_err;
	}

	rc = winOpen(pDbFd->pVfs,
				 pShmNode->zFilename,             /* Name of the file (UTF-8) */
				 (sqlite3_file)&pShmNode->hFile,  /* File handle here */
				 SQLITE_OPEN_WAL | SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, /* Mode flags */
				 0);
	if( SQLITE_OK!=rc ){
	  rc = SQLITE_CANTOPEN_BKPT;
	  goto shm_open_err;
	}

	/* Check to see if another process is holding the dead-man switch.
	** If not, truncate the file to zero length. 
	*/
	if( winShmSystemLock(pShmNode, _SHM_WRLCK, WIN_SHM_DMS, 1)==SQLITE_OK ){
	  rc = winTruncate((sqlite3_file )&pShmNode->hFile, 0);
	  if( rc!=SQLITE_OK ){
		rc = winLogError(SQLITE_IOERR_SHMOPEN, "winOpenShm", pDbFd->zPath);
	  }
	}
	if( rc==SQLITE_OK ){
	  winShmSystemLock(pShmNode, _SHM_UNLCK, WIN_SHM_DMS, 1);
	  rc = winShmSystemLock(pShmNode, _SHM_RDLCK, WIN_SHM_DMS, 1);
	}
	if( rc ) goto shm_open_err;
  }

  /* Make the new connection a child of the winShmNode */
  p->pShmNode = pShmNode;
#if SQLITE_DEBUG
  p->id = pShmNode->nextShmId++;
#endif
  pShmNode->nRef++;
  pDbFd->pShm = p;
  winShmLeaveMutex();

  /* The reference count on pShmNode has already been incremented under
  ** the cover of the winShmEnterMutex() mutex and the pointer from the
  ** new (struct winShm) object to the pShmNode has been set. All that is
  ** left to do is to link the new object into the linked list starting
  ** at pShmNode->pFirst. This must be done while holding the pShmNode->mutex 
  ** mutex.
  */
  sqlite3_mutex_enter(pShmNode->mutex);
  p->pNext = pShmNode->pFirst;
  pShmNode->pFirst = p;
  sqlite3_mutex_leave(pShmNode->mutex);
  return SQLITE_OK;

  /* Jump here on any error */
shm_open_err:
  winShmSystemLock(pShmNode, _SHM_UNLCK, WIN_SHM_DMS, 1);
  winShmPurge(pDbFd->pVfs, 0);      /* This call frees pShmNode if required */
  sqlite3_free(p);
  sqlite3_free(pNew);
  winShmLeaveMutex();
  return rc;
}

/*
** Close a connection to shared-memory.  Delete the underlying 
** storage if deleteFlag is true.
*/
static int winShmUnmap(
  sqlite3_file *fd,          /* Database holding shared memory */
  int deleteFlag             /* Delete after closing if true */
){
  winFile *pDbFd;       /* Database holding shared-memory */
  winShm *p;            /* The connection to be closed */
  winShmNode *pShmNode; /* The underlying shared-memory file */
  winShm **pp;          /* For looping over sibling connections */

  pDbFd = (winFile)fd;
  p = pDbFd->pShm;
  if( p==0 ) return SQLITE_OK;
  pShmNode = p->pShmNode;

  /* Remove connection p from the set of connections associated
  ** with pShmNode */
  sqlite3_mutex_enter(pShmNode->mutex);
  for(pp=&pShmNode->pFirst; (*pp)!=p; pp = (*pp)->pNext){}
  *pp = p->pNext;

  /* Free the connection p */
  sqlite3_free(p);
  pDbFd->pShm = 0;
  sqlite3_mutex_leave(pShmNode->mutex);

  /* If pShmNode->nRef has reached 0, then close the underlying
  ** shared-memory file, too */
  winShmEnterMutex();
  Debug.Assert( pShmNode->nRef>0 );
  pShmNode->nRef--;
  if( pShmNode->nRef==0 ){
	winShmPurge(pDbFd->pVfs, deleteFlag);
  }
  winShmLeaveMutex();

  return SQLITE_OK;
}

/*
** Change the lock state for a shared-memory segment.
*/
static int winShmLock(
  sqlite3_file *fd,          /* Database file holding the shared memory */
  int ofst,                  /* First lock to acquire or release */
  int n,                     /* Number of locks to acquire or release */
  int flags                  /* What to do with the lock */
){
  winFile *pDbFd = (winFile)fd;        /* Connection holding shared memory */
  winShm *p = pDbFd->pShm;              /* The shared memory being locked */
  winShm *pX;                           /* For looping over all siblings */
  winShmNode *pShmNode = p->pShmNode;
  int rc = SQLITE_OK;                   /* Result code */
  u16 mask;                             /* Mask of locks to take or release */

  Debug.Assert( ofst>=0 && ofst+n<=SQLITE_SHM_NLOCK );
  Debug.Assert( n>=1 );
  Debug.Assert( flags==(SQLITE_SHM_LOCK | SQLITE_SHM_SHARED)
	   || flags==(SQLITE_SHM_LOCK | SQLITE_SHM_EXCLUSIVE)
	   || flags==(SQLITE_SHM_UNLOCK | SQLITE_SHM_SHARED)
	   || flags==(SQLITE_SHM_UNLOCK | SQLITE_SHM_EXCLUSIVE) );
  Debug.Assert( n==1 || (flags & SQLITE_SHM_EXCLUSIVE)!=0 );

  mask = (u16)((1U<<(ofst+n)) - (1U<<ofst));
  Debug.Assert( n>1 || mask==(1<<ofst) );
  sqlite3_mutex_enter(pShmNode->mutex);
  if( flags & SQLITE_SHM_UNLOCK ){
	u16 allMask = 0; /* Mask of locks held by siblings */

	/* See if any siblings hold this same lock */
	for(pX=pShmNode->pFirst; pX; pX=pX->pNext){
	  if( pX==p ) continue;
	  Debug.Assert( (pX->exclMask & (p->exclMask|p->sharedMask))==0 );
	  allMask |= pX->sharedMask;
	}

	/* Unlock the system-level locks */
	if( (mask & allMask)==0 ){
	  rc = winShmSystemLock(pShmNode, _SHM_UNLCK, ofst+WIN_SHM_BASE, n);
	}else{
	  rc = SQLITE_OK;
	}

	/* Undo the local locks */
	if( rc==SQLITE_OK ){
	  p->exclMask &= ~mask;
	  p->sharedMask &= ~mask;
	} 
  }else if( flags & SQLITE_SHM_SHARED ){
	u16 allShared = 0;  /* Union of locks held by connections other than "p" */

	/* Find out which shared locks are already held by sibling connections.
	** If any sibling already holds an exclusive lock, go ahead and return
	** SQLITE_BUSY.
	*/
	for(pX=pShmNode->pFirst; pX; pX=pX->pNext){
	  if( (pX->exclMask & mask)!=0 ){
		rc = SQLITE_BUSY;
		break;
	  }
	  allShared |= pX->sharedMask;
	}

	/* Get shared locks at the system level, if necessary */
	if( rc==SQLITE_OK ){
	  if( (allShared & mask)==0 ){
		rc = winShmSystemLock(pShmNode, _SHM_RDLCK, ofst+WIN_SHM_BASE, n);
	  }else{
		rc = SQLITE_OK;
	  }
	}

	/* Get the local shared locks */
	if( rc==SQLITE_OK ){
	  p->sharedMask |= mask;
	}
  }else{
	/* Make sure no sibling connections hold locks that will block this
	** lock.  If any do, return SQLITE_BUSY right away.
	*/
	for(pX=pShmNode->pFirst; pX; pX=pX->pNext){
	  if( (pX->exclMask & mask)!=0 || (pX->sharedMask & mask)!=0 ){
		rc = SQLITE_BUSY;
		break;
	  }
	}
  
	/* Get the exclusive locks at the system level.  Then if successful
	** also mark the local connection as being locked.
	*/
	if( rc==SQLITE_OK ){
	  rc = winShmSystemLock(pShmNode, _SHM_WRLCK, ofst+WIN_SHM_BASE, n);
	  if( rc==SQLITE_OK ){
		Debug.Assert( (p->sharedMask & mask)==0 );
		p->exclMask |= mask;
	  }
	}
  }
  sqlite3_mutex_leave(pShmNode->mutex);
  OSTRACE(("SHM-LOCK shmid-%d, pid-%d got %03x,%03x %s\n",
		   p->id, (int)GetCurrentProcessId(), p->sharedMask, p->exclMask,
		   rc ? "failed" : "ok"));
  return rc;
}

/*
** Implement a memory barrier or memory fence on shared memory.  
**
** All loads and stores begun before the barrier must complete before
** any load or store begun after the barrier.
*/
static void winShmBarrier(
  sqlite3_file *fd          /* Database holding the shared memory */
){
  UNUSED_PARAMETER(fd);
  /* MemoryBarrier(); // does not work -- do not know why not */
  winShmEnterMutex();
  winShmLeaveMutex();
}

/*
** This function is called to obtain a pointer to region iRegion of the 
** shared-memory associated with the database file fd. Shared-memory regions 
** are numbered starting from zero. Each shared-memory region is szRegion 
** bytes in size.
**
** If an error occurs, an error code is returned and *pp is set to NULL.
**
** Otherwise, if the isWrite parameter is 0 and the requested shared-memory
** region has not been allocated (by any client, including one running in a
** separate process), then *pp is set to NULL and SQLITE_OK returned. If 
** isWrite is non-zero and the requested shared-memory region has not yet 
** been allocated, it is allocated by this function.
**
** If the shared-memory region has already been allocated or is allocated by
** this call as described above, then it is mapped into this processes 
** address space (if it is not already), *pp is set to point to the mapped 
** memory and SQLITE_OK returned.
*/
static int winShmMap(
  sqlite3_file *fd,               /* Handle open on database file */
  int iRegion,                    /* Region to retrieve */
  int szRegion,                   /* Size of regions */
  int isWrite,                    /* True to extend file if necessary */
  void volatile **pp              /* OUT: Mapped memory */
){
  winFile *pDbFd = (winFile)fd;
  winShm *p = pDbFd->pShm;
  winShmNode *pShmNode;
  int rc = SQLITE_OK;

  if( null==p ){
	rc = winOpenSharedMemory(pDbFd);
	if( rc!=SQLITE_OK ) return rc;
	p = pDbFd->pShm;
  }
  pShmNode = p->pShmNode;

  sqlite3_mutex_enter(pShmNode->mutex);
  Debug.Assert( szRegion==pShmNode->szRegion || pShmNode->nRegion==0 );

  if( pShmNode->nRegion<=iRegion ){
	struct ShmRegion *apNew;           /* New aRegion[] array */
	int nByte = (iRegion+1)*szRegion;  /* Minimum required file size */
	sqlite3_int64 sz;                  /* Current size of wal-index file */

	pShmNode->szRegion = szRegion;

	/* The requested region is not mapped into this processes address space.
	** Check to see if it has been allocated (i.e. if the wal-index file is
	** large enough to contain the requested region).
	*/
	rc = winFileSize((sqlite3_file )&pShmNode->hFile, &sz);
	if( rc!=SQLITE_OK ){
	  rc = winLogError(SQLITE_IOERR_SHMSIZE, "winShmMap1", pDbFd->zPath);
	  goto shmpage_out;
	}

	if( sz<nByte ){
	  /* The requested memory region does not exist. If isWrite is set to
	  ** zero, exit early. *pp will be set to NULL and SQLITE_OK returned.
	  **
	  ** Alternatively, if isWrite is non-zero, use ftruncate() to allocate
	  ** the requested memory region.
	  */
	  if( null==isWrite ) goto shmpage_out;
	  rc = winTruncate((sqlite3_file )&pShmNode->hFile, nByte);
	  if( rc!=SQLITE_OK ){
		rc = winLogError(SQLITE_IOERR_SHMSIZE, "winShmMap2", pDbFd->zPath);
		goto shmpage_out;
	  }
	}

	/* Map the requested memory region into this processes address space. */
	apNew = (struct ShmRegion )sqlite3_realloc(
		pShmNode->aRegion, (iRegion+1)*sizeof(apNew[0])
	);
	if( null==apNew ){
	  rc = SQLITE_IOERR_NOMEM;
	  goto shmpage_out;
	}
	pShmNode->aRegion = apNew;

	while( pShmNode->nRegion<=iRegion ){
	  HANDLE hMap;                /* file-mapping handle */
	  void *pMap = 0;             /* Mapped memory region */
	 
	  hMap = CreateFileMapping(pShmNode->hFile.h, 
		  NULL, PAGE_READWRITE, 0, nByte, NULL
	  );
	  OSTRACE(("SHM-MAP pid-%d create region=%d nbyte=%d %s\n",
			   (int)GetCurrentProcessId(), pShmNode->nRegion, nByte,
			   hMap ? "ok" : "failed"));
	  if( hMap ){
		int iOffset = pShmNode->nRegion*szRegion;
		int iOffsetShift = iOffset % winSysInfo.dwAllocationGranularity;
		pMap = MapViewOfFile(hMap, FILE_MAP_WRITE | FILE_MAP_READ,
			0, iOffset - iOffsetShift, szRegion + iOffsetShift
		);
		OSTRACE(("SHM-MAP pid-%d map region=%d offset=%d size=%d %s\n",
				 (int)GetCurrentProcessId(), pShmNode->nRegion, iOffset, szRegion,
				 pMap ? "ok" : "failed"));
	  }
	  if( null==pMap ){
		pShmNode->lastErrno = GetLastError();
		rc = winLogError(SQLITE_IOERR_SHMMAP, "winShmMap3", pDbFd->zPath);
		if( hMap ) CloseHandle(hMap);
		goto shmpage_out;
	  }

	  pShmNode->aRegion[pShmNode->nRegion].pMap = pMap;
	  pShmNode->aRegion[pShmNode->nRegion].hMap = hMap;
	  pShmNode->nRegion++;
	}
  }

shmpage_out:
  if( pShmNode->nRegion>iRegion ){
	int iOffset = iRegion*szRegion;
	int iOffsetShift = iOffset % winSysInfo.dwAllocationGranularity;
	char *p = (char )pShmNode->aRegion[iRegion].pMap;
	*pp = (void )&p[iOffsetShift];
  }else{
	*pp = 0;
  }
  sqlite3_mutex_leave(pShmNode->mutex);
  return rc;
}

#else
        //# define winShmMap     0
        static int winShmMap(
        sqlite3_file fd,                /* Handle open on database file */
        int iRegion,                    /* Region to retrieve */
        int szRegion,                   /* Size of regions */
        int isWrite,                    /* True to extend file if necessary */
        out object pp                   /* OUT: Mapped memory */
        )
        {
            pp = null;
            return 0;
        }

        //# define winShmLock    0
        static int winShmLock(
        sqlite3_file fd,           /* Database file holding the shared memory */
        int ofst,                  /* First lock to acquire or release */
        int n,                     /* Number of locks to acquire or release */
        int flags                  /* What to do with the lock */
        )
        {
            return 0;
        }

        //# define winShmBarrier 0
        static void winShmBarrier(
        sqlite3_file fd          /* Database holding the shared memory */
        )
        {
        }

        //# define winShmUnmap   0
        static int winShmUnmap(
        sqlite3_file fd,           /* Database holding shared memory */
        int deleteFlag             /* Delete after closing if true */
        )
        {
            return 0;
        }

#endif //* #if !SQLITE_OMIT_WAL */

        /*
** Here ends the implementation of all sqlite3_file methods.
**
********************** End sqlite3_file Methods *******************************
******************************************************************************/

        /*
		** This vector defines all the methods that can operate on an
		** sqlite3_file for win32.
		*/
        static sqlite3_io_methods winIoMethod = new sqlite3_io_methods(
        2,                                                  /* iVersion */
        (dxClose)winClose,                                  /* xClose */
        (dxRead)winRead,                                    /* xRead */
        (dxWrite)winWrite,                                  /* xWrite */
        (dxTruncate)winTruncate,                            /* xTruncate */
        (dxSync)winSync,                                    /* xSync */
        (dxFileSize)winFileSize,                            /* xFileSize */
        (dxLock)winLock,                                    /* xLock */
        (dxUnlock)winUnlock,                                /* xUnlock */
        (dxCheckReservedLock)winCheckReservedLock,          /* xCheckReservedLock */
        (dxFileControl)winFileControl,                      /* xFileControl */
        (dxSectorSize)winSectorSize,                        /* xSectorSize */
        (dxDeviceCharacteristics)winDeviceCharacteristics,  /* xDeviceCharacteristics */
        (dxShmMap)winShmMap,                                /* xShmMap */
        (dxShmLock)winShmLock,                              /* xShmLock */
        (dxShmBarrier)winShmBarrier,                        /* xShmBarrier */
        (dxShmUnmap)winShmUnmap                             /* xShmUnmap */
        );

        /****************************************************************************
		**************************** sqlite3_vfs methods ****************************
		**
		** This division contains the implementation of methods on the
		** sqlite3_vfs object.
		*/


        /*
		** Create a temporary file name in zBuf.  zBuf must be big enough to
		** hold at pVfs.mxPathname characters.
		*/
        static int getTempname(int nBuf, StringBuilder zBuf)
        {
            const string zChars = "abcdefghijklmnopqrstuvwxyz0123456789";
            //static char zChars[] =
            //  "abcdefghijklmnopqrstuvwxyz"
            //  "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            //  "0123456789";
            //size_t i, j;
            //char zTempPath[MAX_PATH+1];

            /* It's odd to simulate an io-error here, but really this is just
			** using the io-error infrastructure to test that SQLite handles this
			** function failing. 
			*/
#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_IOERR;
#endif

            //if( sqlite3_temp_directory ){
            //  sqlite3_snprintf(MAX_PATH-30, zTempPath, "%s", sqlite3_temp_directory);
            //}else if( isNT() ){
            //  string zMulti;
            //  WCHAR zWidePath[MAX_PATH];
            //  GetTempPathW(MAX_PATH-30, zWidePath);
            //  zMulti = unicodeToUtf8(zWidePath);
            //  if( zMulti ){
            //    sqlite3_snprintf(MAX_PATH-30, zTempPath, "%s", zMulti);
            //    free(zMulti);
            //  }else{
            //    return SQLITE_NOMEM;
            //  }
            /* isNT() is 1 if SQLITE_OS_WINCE==1, so this else is never executed.
			** Since the ASCII version of these Windows API do not exist for WINCE,
			** it's important to not reference them for WINCE builds.
			*/
#if !SQLITE_OS_WINCE
            //}else{
            //  string zUtf8;
            //  char zMbcsPath[MAX_PATH];
            //  GetTempPathA(MAX_PATH-30, zMbcsPath);
            //  zUtf8 = sqlite3_win32_mbcs_to_utf8(zMbcsPath);
            //  if( zUtf8 ){
            //    sqlite3_snprintf(MAX_PATH-30, zTempPath, "%s", zUtf8);
            //    free(zUtf8);
            //  }else{
            //    return SQLITE_NOMEM;
            //  }
#endif
            //}

            /* Check that the output buffer is large enough for the temporary file 
			** name. If it is not, return SQLITE_ERROR.
			*/
            //if( (sqlite3Strlen30(zTempPath) + sqlite3Strlen30(SQLITE_TEMP_FILE_PREFIX) + 17) >= nBuf ){
            //  return SQLITE_ERROR;
            //}

            StringBuilder zRandom = new StringBuilder(20);
            i64 iRandom = 0;
            for (int i = 0; i < 15; i++)
            {
                sqlite3_randomness(1, ref iRandom);
                zRandom.Append((char)zChars[(int)(iRandom % (zChars.Length - 1))]);
            }
            //  zBuf[j] = 0;
            zBuf.Append(Path.GetTempPath() + SQLITE_TEMP_FILE_PREFIX + zRandom.ToString());
            //for(i=sqlite3Strlen30(zTempPath); i>0 && zTempPath[i-1]=='\\'; i--){}
            //zTempPath[i] = 0;
            //sqlite3_snprintf(nBuf-17, zBuf,
            //                 "%s\\"SQLITE_TEMP_FILE_PREFIX, zTempPath);
            //j = sqlite3Strlen30(zBuf);
            //sqlite3_randomness(15, zBuf[j]);
            //for(i=0; i<15; i++, j++){
            //  zBuf[j] = (char)zChars[ ((unsigned char)zBuf[j])%(sizeof(zChars)-1) ];
            //}
            //zBuf[j] = 0;

#if SQLITE_DEBUG
	  OSTRACE( "TEMP FILENAME: %s\n", zBuf.ToString() );
#endif
            return SQLITE_OK;
        }

        /*
		** Open a file.
		*/
        static int winOpen(
        sqlite3_vfs pVfs,       /* Not used */
        string zName,           /* Name of the file (UTF-8) */
        sqlite3_file pFile, /* Write the SQLite file handle here */
        int flags,              /* Open mode flags */
        out int pOutFlags       /* Status return flags */
        )
        {
            //HANDLE h;
            FileStream fs = null;
            FileAccess dwDesiredAccess;
            FileShare dwShareMode;
            FileMode dwCreationDisposition;
#if !(WINDOWS_MOBILE)
            FileOptions dwFlagsAndAttributes;
#endif
#if SQLITE_OS_WINCE
int isTemp = 0;
#endif
            //winFile* pFile = (winFile)id;
            string zConverted;                 /* Filename in OS encoding */
            string zUtf8Name = zName;    /* Filename in UTF-8 encoding */
            pOutFlags = 0;

            /* If argument zPath is a NULL pointer, this function is required to open
			** a temporary file. Use this buffer to store the file name in.
			*/
            StringBuilder zTmpname = new StringBuilder(MAX_PATH + 1);        /* Buffer used to create temp filename */

            int rc = SQLITE_OK;            /* Function Return Code */
            int eType = (int)(flags & 0xFFFFFF00);  /* Type of file to open */
            bool isExclusive = (flags & SQLITE_OPEN_EXCLUSIVE) != 0;
            bool isDelete = (flags & SQLITE_OPEN_DELETEONCLOSE) != 0;
            bool isCreate = (flags & SQLITE_OPEN_CREATE) != 0;
            bool isReadonly = (flags & SQLITE_OPEN_READONLY) != 0;
            bool isReadWrite = (flags & SQLITE_OPEN_READWRITE) != 0;
            bool isOpenJournal = (isCreate && (
            eType == SQLITE_OPEN_MASTER_JOURNAL
            || eType == SQLITE_OPEN_MAIN_JOURNAL
            || eType == SQLITE_OPEN_WAL
            ));

            /* Check the following statements are true:
	  **
	  **   (a) Exactly one of the READWRITE and READONLY flags must be set, and
	  **   (b) if CREATE is set, then READWRITE must also be set, and
	  **   (c) if EXCLUSIVE is set, then CREATE must also be set.
	  **   (d) if DELETEONCLOSE is set, then CREATE must also be set.
	  */
            Debug.Assert((isReadonly == false || isReadWrite == false) && (isReadWrite || isReadonly));
            Debug.Assert(isCreate == false || isReadWrite);
            Debug.Assert(isExclusive == false || isCreate);
            Debug.Assert(isDelete == false || isCreate);

            /* The main DB, main journal, WAL file and master journal are never
			** automatically deleted. Nor are they ever temporary files.  */
            //Debug.Assert( ( !isDelete && !String.IsNullOrEmpty(zName) ) || eType != SQLITE_OPEN_MAIN_DB );
            Debug.Assert((!isDelete && !String.IsNullOrEmpty(zName)) || eType != SQLITE_OPEN_MAIN_JOURNAL);
            Debug.Assert((!isDelete && !String.IsNullOrEmpty(zName)) || eType != SQLITE_OPEN_MASTER_JOURNAL);
            Debug.Assert((!isDelete && !String.IsNullOrEmpty(zName)) || eType != SQLITE_OPEN_WAL);

            /* Assert that the upper layer has set one of the "file-type" flags. */
            Debug.Assert(eType == SQLITE_OPEN_MAIN_DB || eType == SQLITE_OPEN_TEMP_DB
            || eType == SQLITE_OPEN_MAIN_JOURNAL || eType == SQLITE_OPEN_TEMP_JOURNAL
            || eType == SQLITE_OPEN_SUBJOURNAL || eType == SQLITE_OPEN_MASTER_JOURNAL
            || eType == SQLITE_OPEN_TRANSIENT_DB || eType == SQLITE_OPEN_WAL
            );

            Debug.Assert(pFile != null);
            UNUSED_PARAMETER(pVfs);

            pFile.fs = null;//.h = INVALID_HANDLE_VALUE;

            /* If the second argument to this function is NULL, generate a
			** temporary file name to use
			*/
            if (String.IsNullOrEmpty(zUtf8Name))
            {
                Debug.Assert(isDelete && !isOpenJournal);
                rc = getTempname(MAX_PATH + 1, zTmpname);
                if (rc != SQLITE_OK)
                {
                    return rc;
                }
                zUtf8Name = zTmpname.ToString();
            }

            // /* Convert the filename to the system encoding. */
            zConverted = zUtf8Name;// convertUtf8Filename( zUtf8Name );
                                   //if ( zConverted.StartsWith( "/" ) && !zConverted.StartsWith( "//" ) )
                                   //  zConverted = zConverted.Substring( 1 );
                                   //if ( String.IsNullOrEmpty( zConverted ) )
                                   //{
                                   //  return SQLITE_NOMEM;
                                   //}

            if (isReadWrite)
            {
                dwDesiredAccess = FileAccess.Read | FileAccess.Write; // GENERIC_READ | GENERIC_WRITE;
            }
            else
            {
                dwDesiredAccess = FileAccess.Read; // GENERIC_READ;
            }

            /* SQLITE_OPEN_EXCLUSIVE is used to make sure that a new file is
			** created. SQLite doesn't use it to indicate "exclusive access"
			** as it is usually understood.
			*/
            if (isExclusive)
            {
                /* Creates a new file, only if it does not already exist. */
                /* If the file exists, it fails. */
                dwCreationDisposition = FileMode.CreateNew;// CREATE_NEW;
            }
            else if (isCreate)
            {
                /* Open existing file, or create if it doesn't exist */
                dwCreationDisposition = FileMode.OpenOrCreate;// OPEN_ALWAYS;
            }
            else
            {
                /* Opens a file, only if it exists. */
                dwCreationDisposition = FileMode.Open;//OPEN_EXISTING;
            }

            dwShareMode = FileShare.Read | FileShare.Write;// FILE_SHARE_READ | FILE_SHARE_WRITE;

            if (isDelete)
            {
#if SQLITE_OS_WINCE
dwFlagsAndAttributes = FILE_ATTRIBUTE_HIDDEN;
isTemp = 1;
#else
#if !(WINDOWS_MOBILE)
                dwFlagsAndAttributes = FileOptions.DeleteOnClose; // FILE_ATTRIBUTE_TEMPORARY
                                                                  //| FILE_ATTRIBUTE_HIDDEN
                                                                  //| FILE_FLAG_DELETE_ON_CLOSE;
#endif
#endif
            }
            else
            {
#if !(WINDOWS_MOBILE)
                dwFlagsAndAttributes = FileOptions.None; // FILE_ATTRIBUTE_NORMAL;
#endif
            }
            /* Reports from the internet are that performance is always
			** better if FILE_FLAG_RANDOM_ACCESS is used.  Ticket #2699. */
#if SQLITE_OS_WINCE
dwFlagsAndAttributes |= FileOptions.RandomAccess; // FILE_FLAG_RANDOM_ACCESS;
#endif

            if (isNT())
            {
                //h = CreateFileW((WCHAR)zConverted,
                //   dwDesiredAccess,
                //   dwShareMode,
                //   NULL,
                //   dwCreationDisposition,
                //   dwFlagsAndAttributes,
                //   NULL
                //);

                //
                // retry opening the file a few times; this is because of a racing condition between a delete and open call to the FS
                //
                int retries = 3;
                while ((fs == null) && (retries > 0))
                    try
                    {
                        retries--;
#if (WINDOWS_PHONE)
			fs = new IsolatedStorageFileStream(zConverted, dwCreationDisposition, dwDesiredAccess, dwShareMode, IsolatedStorageFile.GetUserStoreForApplication());
#else
                        fs = new FileStream(zConverted, dwCreationDisposition, dwDesiredAccess, dwShareMode, 4096, dwFlagsAndAttributes);
#endif

#if SQLITE_DEBUG
			OSTRACE( "OPEN %d (%s)\n", fs.GetHashCode(), fs.Name );
#endif
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(100);
                    }

                /* isNT() is 1 if SQLITE_OS_WINCE==1, so this else is never executed.
				** Since the ASCII version of these Windows API do not exist for WINCE,
				** it's important to not reference them for WINCE builds.
				*/
#if !SQLITE_OS_WINCE
            }
            else
            {
                Debugger.Break(); // Not NT
                                  //h = CreateFileA((char)zConverted,
                                  //   dwDesiredAccess,
                                  //   dwShareMode,
                                  //   NULL,
                                  //   dwCreationDisposition,
                                  //   dwFlagsAndAttributes,
                                  //   NULL
                                  //);
#endif
            }

            OSTRACE("OPEN %d %s 0x%lx %s\n",
            pFile.GetHashCode(), zName, dwDesiredAccess,
            fs == null ? "failed" : "ok");
            if (fs == null || !fs.CanRead) //(h == INVALID_HANDLE_VALUE)
            {
                pFile.lastErrno = (u32)Marshal.GetLastWin32Error();
                winLogError(SQLITE_CANTOPEN, "winOpen", zUtf8Name);
                //        free(zConverted);
                if (isReadWrite)
                {
                    return winOpen(pVfs, zName, pFile,
                    ((flags | SQLITE_OPEN_READONLY) & ~(SQLITE_OPEN_CREATE | SQLITE_OPEN_READWRITE)), out pOutFlags);
                }
                else
                {
                    return SQLITE_CANTOPEN_BKPT();
                }
            }

            //if ( pOutFlags )
            //{
            if (isReadWrite)
            {
                pOutFlags = SQLITE_OPEN_READWRITE;
            }
            else
            {
                pOutFlags = SQLITE_OPEN_READONLY;
            }
            //}

            pFile.Clear(); // memset(pFile, 0, sizeof(*pFile));
            pFile.pMethods = winIoMethod;
            pFile.fs = fs;
            pFile.lastErrno = NO_ERROR;
            pFile.pVfs = pVfs;
            pFile.pShm = null;
            pFile.zPath = zName;
            pFile.sectorSize = (ulong)getSectorSize(pVfs, zUtf8Name);
#if SQLITE_OS_WINCE
if( isReadWrite && eType==SQLITE_OPEN_MAIN_DB
&& !winceCreateLock(zName, pFile)
){
CloseHandle(h);
free(zConverted);
return SQLITE_CANTOPEN_BKPT;
}
if( isTemp ){
pFile.zDeleteOnClose = zConverted;
}else
#endif
            {
                // free(zConverted);
            }

#if SQLITE_TEST
	  OpenCounter( +1 );
#endif
            return rc;
        }

        /*
		** Delete the named file.
		**
		** Note that windows does not allow a file to be deleted if some other
		** process has it open.  Sometimes a virus scanner or indexing program
		** will open a journal file shortly after it is created in order to do
		** whatever it does.  While this other process is holding the
		** file open, we will be unable to delete it.  To work around this
		** problem, we delay 100 milliseconds and try to delete again.  Up
		** to MX_DELETION_ATTEMPTs deletion attempts are run before giving
		** up and returning an error.
		*/
        static int MX_DELETION_ATTEMPTS = 5;
        static int winDelete(
        sqlite3_vfs pVfs,         /* Not used on win32 */
        string zFilename,         /* Name of file to delete */
        int syncDir               /* Not used on win32 */
        )
        {
            int cnt = 0;
            int rc;
            int error;
            string zConverted;
            UNUSED_PARAMETER(pVfs);
            UNUSED_PARAMETER(syncDir);

#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_IOERR_DELETE;
#endif
            if (isNT())
            {
                do
                {
#if WINDOWS_PHONE
		   if ( !System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().FileExists( zFilename ) )
#else
                    if (!File.Exists(zFilename))
#endif
                    {
                        rc = SQLITE_IOERR;
                        break;
                    }
                    try
                    {
#if WINDOWS_PHONE
			  System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().DeleteFile(zFilename);
#else
                        File.Delete(zFilename);
#endif
                        rc = SQLITE_OK;
                    }
                    catch
                    {
                        rc = SQLITE_IOERR;
                        Thread.Sleep(100);
                    }
                } while (rc != SQLITE_OK && ++cnt < MX_DELETION_ATTEMPTS);
                /* isNT() is 1 if SQLITE_OS_WINCE==1, so this else is never executed.
				** Since the ASCII version of these Windows API do not exist for WINCE,
				** it's important to not reference them for WINCE builds.
				*/
#if !SQLITE_OS_WINCE
            }
            else
            {
                do
                {
                    if (!File.Exists(zFilename))
                    {
                        rc = SQLITE_IOERR;
                        break;
                    }
                    try
                    {
                        File.Delete(zFilename);
                        rc = SQLITE_OK;
                    }
                    catch
                    {
                        rc = SQLITE_IOERR;
                        Thread.Sleep(100);
                    }
                } while (rc != SQLITE_OK && cnt++ < MX_DELETION_ATTEMPTS);
#endif
            }
#if SQLITE_DEBUG
	  OSTRACE( "DELETE \"%s\"\n", zFilename );
#endif
            if (rc == SQLITE_OK)
                return rc;

            error = (int)ERROR_NOT_SUPPORTED;
            return ((rc == INVALID_FILE_ATTRIBUTES) && (error == ERROR_FILE_NOT_FOUND)) ? SQLITE_OK : winLogError(SQLITE_IOERR_DELETE, "winDelete", zFilename);
        }

        /*
		** Check the existence and status of a file.
		*/
        static int winAccess(
        sqlite3_vfs pVfs,       /* Not used on win32 */
        string zFilename,       /* Name of file to check */
        int flags,              /* Type of test to make on this file */
        out int pResOut         /* OUT: Result */
        )
        {
            FileAttributes attr = 0; // DWORD attr;
            int rc = 0;
            //  void *zConverted;
            UNUSED_PARAMETER(pVfs);

#if SQLITE_TEST
	  if ( SimulateIOError() )
	  {
		pResOut = -1;
		return SQLITE_IOERR_ACCESS;
	  }
#endif
            //zConverted = convertUtf8Filename(zFilename);
            //  if( zConverted==0 ){
            //    return SQLITE_NOMEM;
            //  }
            //if ( isNT() )
            //{
            //
            // Do a quick test to prevent the try/catch block
            if (flags == SQLITE_ACCESS_EXISTS)
            {
#if WINDOWS_PHONE
		  pResOut = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().FileExists(zFilename) ? 1 : 0;
#else
                pResOut = File.Exists(zFilename) ? 1 : 0;
#endif
                return SQLITE_OK;
            }
            //
            try
            {
#if WINDOWS_PHONE || WINDOWS_MOBILE
		if (new DirectoryInfo(zFilename).Exists)
#else
                attr = File.GetAttributes(zFilename);// GetFileAttributesW( (WCHAR)zConverted );
                if (attr == FileAttributes.Directory)
#endif
                {
                    try
                    {
                        string name = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
                        FileStream fs = File.Create(name);
                        fs.Close();
                        File.Delete(name);
                        attr = FileAttributes.Normal;
                    }
                    catch
                    {
                        attr = FileAttributes.ReadOnly;
                    }
                }
            }
            catch
            {
                winLogError(SQLITE_IOERR_ACCESS, "winAccess", zFilename);
            }
            switch (flags)
            {
                case SQLITE_ACCESS_READ:
                case SQLITE_ACCESS_EXISTS:
                    rc = attr != 0 ? 1 : 0;// != INVALID_FILE_ATTRIBUTES;
                    break;
                case SQLITE_ACCESS_READWRITE:
                    rc = attr == 0 ? 0 : (int)(attr & FileAttributes.ReadOnly) != 0 ? 0 : 1; //FILE_ATTRIBUTE_READONLY ) == 0;
                    break;
                default:
                    Debug.Assert("" == "Invalid flags argument");
                    rc = 0;
                    break;
            }
            pResOut = rc;
            return SQLITE_OK;
        }

        /*
		** Turn a relative pathname into a full pathname.  Write the full
		** pathname into zOut[].  zOut[] will be at least pVfs.mxPathname
		** bytes in size.
		*/
        static int winFullPathname(
        sqlite3_vfs pVfs,             /* Pointer to vfs object */
        string zRelative,             /* Possibly relative input path */
        int nFull,                    /* Size of output buffer in bytes */
        StringBuilder zFull           /* Output buffer */
        )
        {

#if __CYGWIN__
SimulateIOError( return SQLITE_ERROR );
UNUSED_PARAMETER(nFull);
cygwin_conv_to_full_win32_path(zRelative, zFull);
return SQLITE_OK;
#endif

#if !SQLITE_OS_WINCE && !__CYGWIN__
            int nByte;
            //string  zConverted;
            string zOut = null;

            /* If this path name begins with "/X:", where "X" is any alphabetic
			** character, discard the initial "/" from the pathname.
			*/
            if (zRelative[0] == '/' && Char.IsLetter(zRelative[1]) && zRelative[2] == ':')
            {
                zRelative = zRelative.Substring(1);
            }

            /* It's odd to simulate an io-error here, but really this is just
			** using the io-error infrastructure to test that SQLite handles this
			** function failing. This function could fail if, for example, the
			** current working directory has been unlinked.
			*/
#if SQLITE_TEST
	  if ( SimulateIOError() )
		return SQLITE_ERROR;
#endif
            UNUSED_PARAMETER(nFull);
            //convertUtf8Filename(zRelative));
            if (isNT())
            {
#if (WINDOWS_PHONE)
		zOut = zRelative;
#else
                zOut = Path.GetFullPath(zRelative); // was unicodeToUtf8(zTemp);
#endif
                // will happen on exit; was   free(zTemp);
                /* isNT() is 1 if SQLITE_OS_WINCE==1, so this else is never executed.
				** Since the ASCII version of these Windows API do not exist for WINCE,
				** it's important to not reference them for WINCE builds.
				*/
#if !SQLITE_OS_WINCE
            }
            else
            {
                Debugger.Break(); // -- Not Running under NT
                                  //string zTemp;
                                  //nByte = GetFullPathNameA(zConverted, 0, 0, 0) + 3;
                                  //zTemp = malloc( nByte*sizeof(zTemp[0]) );
                                  //if( zTemp==0 ){
                                  //  free(zConverted);
                                  //  return SQLITE_NOMEM;
                                  //}
                                  //GetFullPathNameA( zConverted, nByte, zTemp, 0);
                                  // free(zConverted);
                                  //zOut = sqlite3_win32_mbcs_to_utf8(zTemp);
                                  // free(zTemp);
#endif
            }
            if (zOut != null)
            {
                // sqlite3_snprintf(pVfs.mxPathname, zFull, "%s", zOut);
                if (zFull.Length > pVfs.mxPathname)
                    zFull.Length = pVfs.mxPathname;
                zFull.Append(zOut);

                // will happen on exit; was   free(zOut);
                return SQLITE_OK;
            }
            else
            {
                return SQLITE_NOMEM;
            }
#endif
        }


        /*
		** Get the sector size of the device used to store
		** file.
		*/
        static int getSectorSize(
        sqlite3_vfs pVfs,
        string zRelative     /* UTF-8 file name */
        )
        {
#if FALSE
int bytesPerSector = SQLITE_DEFAULT_SECTOR_SIZE;
/* GetDiskFreeSpace is not supported under WINCE */
#if SQLITE_OS_WINCE
UNUSED_PARAMETER(pVfs);
UNUSED_PARAMETER(zRelative);
#else
StringBuilder zFullpath = new StringBuilder( MAX_PATH + 1 );
int rc;
//bool dwRet = false;
//int dwDummy = 0;

/*
** We need to get the full path name of the file
** to get the drive letter to look up the sector
** size.
*/
SimulateIOErrorBenign(1);
rc = winFullPathname( pVfs, zRelative, MAX_PATH, zFullpath );
#if SQLITE_TEST
SimulateIOError( return SQLITE_ERROR )
#endif
if ( rc == SQLITE_OK )
{
StringBuilder zConverted = new StringBuilder( convertUtf8Filename( zFullpath.ToString() ) );
if ( zConverted.Length != 0 )
{
if ( isNT() )
{
int i;
for ( i = 0 ; i < zConverted.Length && i < MAX_PATH ; i++ )
{
if ( zConverted[i] == '\\' )
{
i++;
break;
}
}
zConverted.Length = i;
}
}
bytesPerSector = GetbytesPerSector( zConverted );
}
#endif
return bytesPerSector == 0 ? SQLITE_DEFAULT_SECTOR_SIZE : bytesPerSector;
#endif
            return SQLITE_DEFAULT_SECTOR_SIZE;
        }

#if !SQLITE_OMIT_LOAD_EXTENSION
        /*
** Interfaces for opening a shared library, finding entry points
** within the shared library, and closing the shared library.
*/
        /*
		** Interfaces for opening a shared library, finding entry points
		** within the shared library, and closing the shared library.
		*/
        //static void winDlOpen(sqlite3_vfs pVfs, string zFilename){
        //  HANDLE h;
        //  void *zConverted = convertUtf8Filename(zFilename);
        //  UNUSED_PARAMETER(pVfs);
        //  if( zConverted==0 ){
        //    return 0;
        //  }
        //  if( isNT() ){
        //    h = LoadLibraryW((WCHAR)zConverted);
        /* isNT() is 1 if SQLITE_OS_WINCE==1, so this else is never executed.
		** Since the ASCII version of these Windows API do not exist for WINCE,
		** it's important to not reference them for WINCE builds.
		*/
        //TODO -- Fix This
        static HANDLE winDlOpen(sqlite3_vfs vfs, string zFilename)
        {
            return new HANDLE();
        }
        static int winDlError(sqlite3_vfs vfs, int nByte, string zErrMsg)
        {
            return 0;
        }
        static HANDLE winDlSym(sqlite3_vfs vfs, HANDLE data, string zSymbol)
        {
            return new HANDLE();
        }
        static int winDlClose(sqlite3_vfs vfs, HANDLE data)
        {
            return 0;
        }
#else // * if SQLITE_OMIT_LOAD_EXTENSION is defined: */
static object winDlOpen(ref sqlite3_vfs vfs, string zFilename) { return null; }
static int winDlError(ref sqlite3_vfs vfs, int nByte, ref string zErrMsg) { return 0; }
static object winDlSym(ref sqlite3_vfs vfs, object data, string zSymbol) { return null; }
static int winDlClose(ref sqlite3_vfs vfs, object data) { return 0; }
#endif


        /*
** Write up to nBuf bytes of randomness into zBuf.
*/
        static int winRandomness(sqlite3_vfs pVfs, int nBuf, byte[] zBuf)
        {
            int n = 0;
            UNUSED_PARAMETER(pVfs);
#if (SQLITE_TEST)
	  n = nBuf;
	  Array.Clear( zBuf, 0, n );// memset( zBuf, 0, nBuf );
#else
            byte[] sBuf = BitConverter.GetBytes(System.DateTime.Now.Ticks);
            zBuf[0] = sBuf[0];
            zBuf[1] = sBuf[1];
            zBuf[2] = sBuf[2];
            zBuf[3] = sBuf[3];
            ;// memcpy(&zBuf[n], x, sizeof(x))
            n += 16;// sizeof(x);
            if (sizeof(DWORD) <= nBuf - n)
            {
                //DWORD pid = GetCurrentProcessId();
                u32 processId;
                processId = (u32)Process.GetCurrentProcess().Id;
                put32bits(zBuf, n, processId);//(memcpy(&zBuf[n], pid, sizeof(pid));
                n += 4;// sizeof(pid);
            }
            if (sizeof(DWORD) <= nBuf - n)
            {
                //DWORD cnt = GetTickCount();
                System.DateTime dt = new System.DateTime();
                put32bits(zBuf, n, (u32)dt.Ticks);// memcpy(&zBuf[n], cnt, sizeof(cnt));
                n += 4;// cnt.Length;
            }
            if (sizeof(long) <= nBuf - n)
            {
                long i;
                i = System.DateTime.UtcNow.Millisecond;// QueryPerformanceCounter(out i);
                put32bits(zBuf, n, (u32)(i & 0xFFFFFFFF));//memcpy(&zBuf[n], i, sizeof(i));
                put32bits(zBuf, n, (u32)(i >> 32));
                n += sizeof(long);
            }
#endif
            return n;
        }


        /*
		** Sleep for a little while.  Return the amount of time slept.
		*/
        static int winSleep(sqlite3_vfs pVfs, int microsec)
        {
            Thread.Sleep(((microsec + 999) / 1000));
            UNUSED_PARAMETER(pVfs);
            return ((microsec + 999) / 1000) * 1000;
        }

        /*
		** The following variable, if set to a non-zero value, is interpreted as
		** the number of seconds since 1970 and is used to set the result of
		** sqlite3OsCurrentTime() during testing.
		*/
#if SQLITE_TEST
#if !TCLSH
	static int sqlite3_current_time = 0;//  /* Fake system time in seconds since 1970. */
#else
	static tcl.lang.Var.SQLITE3_GETSET sqlite3_current_time = new tcl.lang.Var.SQLITE3_GETSET( "sqlite3_current_time" );
#endif
#endif

        /*
** Find the current time (in Universal Coordinated Time).  Write into *piNow
** the current time and date as a Julian Day number times 86_400_000.  In
** other words, write into *piNow the number of milliseconds since the Julian
** epoch of noon in Greenwich on November 24, 4714 B.C according to the
** proleptic Gregorian calendar.
**
** On success, return 0.  Return 1 if the time and date cannot be found.
*/
        static int winCurrentTimeInt64(sqlite3_vfs pVfs, ref sqlite3_int64 piNow)
        {
            /* FILETIME structure is a 64-bit value representing the number of
			100-nanosecond intervals since January 1, 1601 (= JD 2305813.5).
			*/
            //var ft = new FILETIME();
            const sqlite3_int64 winFiletimeEpoch = 23058135 * (sqlite3_int64)8640000;
#if SQLITE_TEST
	  const sqlite3_int64 unixEpoch = 24405875 * (sqlite3_int64)8640000;
#endif
            piNow = winFiletimeEpoch + System.DateTime.UtcNow.ToFileTimeUtc() / (sqlite3_int64)10000;
#if SQLITE_TEST
#if !TCLSH
	  if ( ( sqlite3_current_time) != 0 )
	  {
		piNow = 1000 * (sqlite3_int64)sqlite3_current_time + unixEpoch;
	  }
#endif
#endif
            UNUSED_PARAMETER(pVfs);
            return 0;
        }


        /*
		** Find the current time (in Universal Coordinated Time).  Write the
		** current time and date as a Julian Day number into *prNow and
		** return 0.  Return 1 if the time and date cannot be found.
		*/
        static int winCurrentTime(sqlite3_vfs pVfs, ref double prNow)
        {
            int rc;
            sqlite3_int64 i = 0;
            rc = winCurrentTimeInt64(pVfs, ref i);
            if (0 == rc)
            {
                prNow = i / 86400000.0;
            }
            return rc;
        }

        /*
		** The idea is that this function works like a combination of
		** GetLastError() and FormatMessage() on windows (or errno and
		** strerror_r() on unix). After an error is returned by an OS
		** function, SQLite calls this function with zBuf pointing to
		** a buffer of nBuf bytes. The OS layer should populate the
		** buffer with a nul-terminated UTF-8 encoded error message
		** describing the last IO error to have occurred within the calling
		** thread.
		**
		** If the error message is too large for the supplied buffer,
		** it should be truncated. The return value of xGetLastError
		** is zero if the error message fits in the buffer, or non-zero
		** otherwise (if the message was truncated). If non-zero is returned,
		** then it is not necessary to include the nul-terminator character
		** in the output buffer.
		**
		** Not supplying an error message will have no adverse effect
		** on SQLite. It is fine to have an implementation that never
		** returns an error message:
		**
		**   int xGetLastError(sqlite3_vfs pVfs, int nBuf, string zBuf){
		**     Debug.Assert(zBuf[0]=='\0');
		**     return 0;
		**   }
		**
		** However if an error message is supplied, it will be incorporated
		** by sqlite into the error message available to the user using
		** sqlite3_errmsg(), possibly making IO errors easier to debug.
		*/
        static int winGetLastError(sqlite3_vfs pVfs, int nBuf, ref string zBuf)
        {
            UNUSED_PARAMETER(pVfs);
            return getLastErrorMsg(nBuf, ref zBuf);
        }

        static sqlite3_vfs winVfs = new sqlite3_vfs(
        3,                              /* iVersion */
        -1, //sqlite3_file.Length,      /* szOsFile */
        MAX_PATH,                       /* mxPathname */
        null,                           /* pNext */
        "win32",                        /* zName */
        0,                              /* pAppData */

        (dxOpen)winOpen,                /* xOpen */
        (dxDelete)winDelete,            /* xDelete */
        (dxAccess)winAccess,            /* xAccess */
        (dxFullPathname)winFullPathname,/* xFullPathname */
        (dxDlOpen)winDlOpen,            /* xDlOpen */
        (dxDlError)winDlError,          /* xDlError */
        (dxDlSym)winDlSym,              /* xDlSym */
        (dxDlClose)winDlClose,          /* xDlClose */
        (dxRandomness)winRandomness,    /* xRandomness */
        (dxSleep)winSleep,              /* xSleep */
        (dxCurrentTime)winCurrentTime,  /* xCurrentTime */
        (dxGetLastError)winGetLastError,/* xGetLastError */
        (dxCurrentTimeInt64)winCurrentTimeInt64, /* xCurrentTimeInt64 */
        null,                           /* xSetSystemCall */
        null,                           /* xGetSystemCall */
        null                            /* xNextSystemCall */
        );

        /*
		** Initialize and deinitialize the operating system interface.
		*/
        static int sqlite3_os_init()
        {
#if !SQLITE_OMIT_WAL
/* get memory map allocation granularity */
memset(&winSysInfo, 0, sizeof(SYSTEM_INFO));
GetSystemInfo(&winSysInfo);
Debug.Assert(winSysInfo.dwAllocationGranularity > 0);
#endif

            sqlite3_vfs_register(winVfs, 1);
            return SQLITE_OK;
        }

        static int sqlite3_os_end()
        {
            return SQLITE_OK;
        }

#endif // * SQLITE_OS_WIN */
        //
        //          Windows DLL definitions
        //

        const int NO_ERROR = 0;
        /// <summary>
        /// Basic locking strategy for Console/Winform applications
        /// </summary>
        private class LockingStrategy
        {
            public virtual void LockFile(sqlite3_file pFile, long offset, long length)
            {
#if !(WINDOWS_MOBILE)
                pFile.fs.Lock(offset, length);
#endif
            }

            public virtual int SharedLockFile(sqlite3_file pFile, long offset, long length)
            {
                return 1;
            }

            public virtual void UnlockFile(sqlite3_file pFile, long offset, long length)
            {
#if !(WINDOWS_MOBILE)
                pFile.fs.Unlock(offset, length);
#endif
            }
        }

        /// <summary>
        /// Locking strategy for Medium Trust. It uses the same trick used in the native code for WIN_CE
        /// which doesn't support LockFileEx as well.
        /// </summary>
        private class MediumTrustLockingStrategy : LockingStrategy
        {
            public override int SharedLockFile(sqlite3_file pFile, long offset, long length)
            {
#if !(WINDOWS_MOBILE)
                Debug.Assert(length == SHARED_SIZE);
                Debug.Assert(offset == SHARED_FIRST);
                try
                {
                    pFile.fs.Lock(offset + pFile.sharedLockByte, 1);
                }
                catch (IOException)
                {
                    return 0;
                }
#endif
                return 1;
            }
        }
    }
    internal static class HelperMethods
    {
        public static bool IsRunningMediumTrust()
        {
            // placeholder method
            // this is where it needs to check if it's running in an ASP.Net MediumTrust or lower environment
            // in order to pick the appropriate locking strategy
            return false;
        }
    }
}
