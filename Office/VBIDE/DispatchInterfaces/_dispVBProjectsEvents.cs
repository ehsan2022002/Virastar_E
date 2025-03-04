﻿using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.VBIDEApi
{
    /// <summary>
    /// DispatchInterface _dispVBProjectsEvents 
    /// SupportByVersion VBIDE, 12,14,5.3
    /// </summary>
    [SupportByVersion("VBIDE", 12, 14, 5.3)]
    [EntityType(EntityType.IsDispatchInterface)]
    public class _dispVBProjectsEvents : COMObject
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
                    _type = typeof(_dispVBProjectsEvents);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public _dispVBProjectsEvents(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public _dispVBProjectsEvents(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _dispVBProjectsEvents(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _dispVBProjectsEvents(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _dispVBProjectsEvents(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _dispVBProjectsEvents(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _dispVBProjectsEvents() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _dispVBProjectsEvents(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion VBIDE 12, 14, 5.3
        /// </summary>
        /// <param name="vBProject">NetOffice.VBIDEApi.VBProject vBProject</param>
        [SupportByVersion("VBIDE", 12, 14, 5.3)]
        public void ItemAdded(NetOffice.VBIDEApi.VBProject vBProject)
        {
            Factory.ExecuteMethod(this, "ItemAdded", vBProject);
        }

        /// <summary>
        /// SupportByVersion VBIDE 12, 14, 5.3
        /// </summary>
        /// <param name="vBProject">NetOffice.VBIDEApi.VBProject vBProject</param>
        [SupportByVersion("VBIDE", 12, 14, 5.3)]
        public void ItemRemoved(NetOffice.VBIDEApi.VBProject vBProject)
        {
            Factory.ExecuteMethod(this, "ItemRemoved", vBProject);
        }

        /// <summary>
        /// SupportByVersion VBIDE 12, 14, 5.3
        /// </summary>
        /// <param name="vBProject">NetOffice.VBIDEApi.VBProject vBProject</param>
        /// <param name="oldName">string oldName</param>
        [SupportByVersion("VBIDE", 12, 14, 5.3)]
        public void ItemRenamed(NetOffice.VBIDEApi.VBProject vBProject, string oldName)
        {
            Factory.ExecuteMethod(this, "ItemRenamed", vBProject, oldName);
        }

        /// <summary>
        /// SupportByVersion VBIDE 12, 14, 5.3
        /// </summary>
        /// <param name="vBProject">NetOffice.VBIDEApi.VBProject vBProject</param>
        [SupportByVersion("VBIDE", 12, 14, 5.3)]
        public void ItemActivated(NetOffice.VBIDEApi.VBProject vBProject)
        {
            Factory.ExecuteMethod(this, "ItemActivated", vBProject);
        }

        #endregion

#pragma warning restore
    }
}
