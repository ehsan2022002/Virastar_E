﻿using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.WordApi
{
    /// <summary>
    /// DispatchInterface CoAuthLock 
    /// SupportByVersion Word, 14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff194244.aspx </remarks>
    [SupportByVersion("Word", 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface)]
    public class CoAuthLock : COMObject
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
                    _type = typeof(CoAuthLock);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public CoAuthLock(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public CoAuthLock(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public CoAuthLock(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public CoAuthLock(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public CoAuthLock(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public CoAuthLock(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public CoAuthLock() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public CoAuthLock(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198211.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public NetOffice.WordApi.Application Application
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Application>(this, "Application", NetOffice.WordApi.Application.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff844943.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public Int32 Creator
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Creator");
            }
        }

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff835183.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff836005.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdLockType Type
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdLockType>(this, "Type");
            }
        }

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196001.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public NetOffice.WordApi.CoAuthor Owner
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.CoAuthor>(this, "Owner", NetOffice.WordApi.CoAuthor.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff845250.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public NetOffice.WordApi.Range Range
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Range>(this, "Range", NetOffice.WordApi.Range.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff841035.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public bool HeaderFooter
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "HeaderFooter");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff821692.aspx </remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        public void Unlock()
        {
            Factory.ExecuteMethod(this, "Unlock");
        }

        #endregion

#pragma warning restore
    }
}
