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
    /// DispatchInterface KeysBoundTo 
    /// SupportByVersion Word, 9,10,11,12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff197228.aspx </remarks>
    [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), Enumerator(Enumerator.Reference, EnumeratorInvoke.Property), HasIndexProperty(IndexInvoke.Method, "Item")]
    public class KeysBoundTo : COMObject, IEnumerableProvider<NetOffice.WordApi.KeyBinding>
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
                    _type = typeof(KeysBoundTo);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public KeysBoundTo(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public KeysBoundTo(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public KeysBoundTo(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public KeysBoundTo(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public KeysBoundTo(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public KeysBoundTo(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public KeysBoundTo() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public KeysBoundTo(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff839697.aspx </remarks>
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
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff838277.aspx </remarks>
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
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff821406.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff835211.aspx </remarks>
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
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff835166.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdKeyCategory KeyCategory
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdKeyCategory>(this, "KeyCategory");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff836017.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public string Command
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Command");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff839319.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public string CommandParameter
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "CommandParameter");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff835156.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Context
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Context");
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
        public NetOffice.WordApi.KeyBinding this[Int32 index]
        {
            get
            {
                return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.KeyBinding>(this, "Item", NetOffice.WordApi.KeyBinding.LateBindingApiWrapperType, index);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff840239.aspx </remarks>
        /// <param name="keyCode">Int32 keyCode</param>
        /// <param name="keyCode2">optional object keyCode2</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.KeyBinding Key(Int32 keyCode, object keyCode2)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.KeyBinding>(this, "Key", NetOffice.WordApi.KeyBinding.LateBindingApiWrapperType, keyCode, keyCode2);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff840239.aspx </remarks>
        /// <param name="keyCode">Int32 keyCode</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.KeyBinding Key(Int32 keyCode)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.KeyBinding>(this, "Key", NetOffice.WordApi.KeyBinding.LateBindingApiWrapperType, keyCode);
        }

        #endregion

        #region IEnumerableProvider<NetOffice.WordApi.KeyBinding>

        ICOMObject IEnumerableProvider<NetOffice.WordApi.KeyBinding>.GetComObjectEnumerator(ICOMObject parent)
        {
            return NetOffice.Utils.GetComObjectEnumeratorAsProperty(parent, this, false);
        }

        IEnumerable IEnumerableProvider<NetOffice.WordApi.KeyBinding>.FetchVariantComObjectEnumerator(ICOMObject parent, ICOMObject enumerator)
        {
            return NetOffice.Utils.FetchVariantComObjectEnumerator(parent, enumerator, false);
        }

        #endregion

        #region IEnumerable<NetOffice.WordApi.KeyBinding>

        /// <summary>
        /// SupportByVersion Word, 9,10,11,12,14,15,16
        /// </summary>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public IEnumerator<NetOffice.WordApi.KeyBinding> GetEnumerator()
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.WordApi.KeyBinding item in innerEnumerator)
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