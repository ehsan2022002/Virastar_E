﻿using NetOffice.Attributes;
using NetOffice.CollectionsGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OfficeApi
{
    /// <summary>
    /// Interface FullSeriesCollection 
    /// SupportByVersion Office, 15, 16
    /// </summary>
    [SupportByVersion("Office", 15, 16)]
    [EntityType(EntityType.IsInterface), Enumerator(Enumerator.Reference, EnumeratorInvoke.Method), HasIndexProperty(IndexInvoke.Property, "_Default")]
    public class FullSeriesCollection : COMObject, IEnumerableProvider<NetOffice.OfficeApi.IMsoSeries>
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
                    _type = typeof(FullSeriesCollection);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public FullSeriesCollection(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public FullSeriesCollection(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public FullSeriesCollection(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public FullSeriesCollection(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public FullSeriesCollection(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public FullSeriesCollection(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public FullSeriesCollection() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public FullSeriesCollection(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Office 15,16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        [SupportByVersion("Office", 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Office 15,16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 15, 16)]
        public Int32 Count
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Count");
            }
        }

        /// <summary>
        /// SupportByVersion Office 15,16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        [SupportByVersion("Office", 15, 16), ProxyResult]
        public object Application
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Application");
            }
        }

        /// <summary>
        /// SupportByVersion Office 15,16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 15, 16)]
        public Int32 Creator
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Creator");
            }
        }

        /// <summary>
        /// SupportByVersion Office 15,16
        /// Get
        /// </summary>
        /// <param name="index">object index</param>
        [SupportByVersion("Office", 15, 16)]
        [NetRuntimeSystem.Runtime.CompilerServices.IndexerName("Item"), IndexProperty]
        public NetOffice.OfficeApi.IMsoSeries this[object index]
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.IMsoSeries>(this, "_Default", NetOffice.OfficeApi.IMsoSeries.LateBindingApiWrapperType, index);
            }
        }

        #endregion

        #region Methods

        #endregion

        #region IEnumerableProvider<NetOffice.OfficeApi.IMsoSeries>

        ICOMObject IEnumerableProvider<NetOffice.OfficeApi.IMsoSeries>.GetComObjectEnumerator(ICOMObject parent)
        {
            return NetOffice.Utils.GetComObjectEnumeratorAsMethod(parent, this, false);
        }

        IEnumerable IEnumerableProvider<NetOffice.OfficeApi.IMsoSeries>.FetchVariantComObjectEnumerator(ICOMObject parent, ICOMObject enumerator)
        {
            return NetOffice.Utils.FetchVariantComObjectEnumerator(parent, enumerator, false);
        }

        #endregion

        #region IEnumerable<NetOffice.OfficeApi.IMsoSeries>

        /// <summary>
        /// SupportByVersion Office, 15, 16
        /// </summary>
        [SupportByVersion("Office", 15, 16)]
        public IEnumerator<NetOffice.OfficeApi.IMsoSeries> GetEnumerator()
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.OfficeApi.IMsoSeries item in innerEnumerator)
                yield return item;
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// SupportByVersion Office, 15, 16
        /// </summary>
        [SupportByVersion("Office", 15, 16)]
        IEnumerator NetRuntimeSystem.Collections.IEnumerable.GetEnumerator()
        {
            return NetOffice.Utils.GetProxyEnumeratorAsMethod(this, false);
        }

        #endregion

#pragma warning restore
    }
}