﻿using NetOffice.Attributes;
using NetOffice.CollectionsGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.WordApi
{
    /// <summary>
    /// DispatchInterface Sentences 
    /// SupportByVersion Word, 9,10,11,12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837481.aspx </remarks>
    [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), Enumerator(Enumerator.Reference, EnumeratorInvoke.Property), HasIndexProperty(IndexInvoke.Method, "Item")]
    public class Sentences : COMObject, IEnumerableProvider<NetOffice.WordApi.Range>
    {
#pragma warning disable

        #region Type Information

        /// <summary>
        /// Instance Type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), Category("NetOffice"), CoreOverridden]
        public override Type InstanceType
        {
            get
            {
                return LateBindingApiWrapperType;
            }
        }

        private static Type _type;

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(Sentences);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public Sentences(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public Sentences(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Sentences(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Sentences(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Sentences(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Sentences(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Sentences() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Sentences(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff839395.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 Count
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Count");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff195388.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range First
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Range>(this, "First", NetOffice.WordApi.Range.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff836641.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range Last
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Range>(this, "Last", NetOffice.WordApi.Range.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff194716.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Application Application
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Application>(this, "Application", NetOffice.WordApi.Application.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff197688.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 Creator
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Creator");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff839613.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="index">Int32 index</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        [NetRuntimeSystem.Runtime.CompilerServices.IndexerName("Item"), IndexProperty]
        public NetOffice.WordApi.Range this[Int32 index]
        {
            get
            {
                return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Range>(this, "Item", NetOffice.WordApi.Range.LateBindingApiWrapperType, index);
            }
        }

        #endregion

        #region IEnumerableProvider<NetOffice.WordApi.Range>

        ICOMObject IEnumerableProvider<NetOffice.WordApi.Range>.GetComObjectEnumerator(ICOMObject parent)
        {
            return NetOffice.Utils.GetComObjectEnumeratorAsProperty(parent, this, false);
        }

        IEnumerable IEnumerableProvider<NetOffice.WordApi.Range>.FetchVariantComObjectEnumerator(ICOMObject parent, ICOMObject enumerator)
        {
            return NetOffice.Utils.FetchVariantComObjectEnumerator(parent, enumerator, false);
        }

        #endregion

        #region IEnumerable<NetOffice.WordApi.Range>

        /// <summary>
        /// SupportByVersion Word, 9,10,11,12,14,15,16
        /// </summary>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public IEnumerator<NetOffice.WordApi.Range> GetEnumerator()
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.WordApi.Range item in innerEnumerator)
                yield return item;
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// SupportByVersion Word, 9,10,11,12,14,15,16
        /// </summary>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        IEnumerator NetRuntimeSystem.Collections.IEnumerable.GetEnumerator()
        {
            return NetOffice.Utils.GetProxyEnumeratorAsProperty(this, false);
        }

        #endregion

#pragma warning restore
    }
}