﻿using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    /// <summary>
    /// DispatchInterface _DInspectorCtrl 
    /// SupportByVersion Outlook, 10
    /// </summary>
    [SupportByVersion("Outlook", 10)]
    [EntityType(EntityType.IsDispatchInterface), BaseType]
    public class _DInspectorCtrl : COMObject
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
                    _type = typeof(_DInspectorCtrl);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public _DInspectorCtrl(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public _DInspectorCtrl(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _DInspectorCtrl(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _DInspectorCtrl(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _DInspectorCtrl(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _DInspectorCtrl(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _DInspectorCtrl() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _DInspectorCtrl(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Outlook 10
        /// Get/Set
        /// </summary>
        [SupportByVersion("Outlook", 10)]
        public string URL
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "URL");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "URL", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 10
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        [SupportByVersion("Outlook", 10), ProxyResult]
        public object Item
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Item");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Outlook 10
        /// </summary>
        /// <param name="pdispItem">object pdispItem</param>
        [SupportByVersion("Outlook", 10)]
        public void OnItemChange(object pdispItem)
        {
            Factory.ExecuteMethod(this, "OnItemChange", pdispItem);
        }

        #endregion

#pragma warning restore
    }
}
