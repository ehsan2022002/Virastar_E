﻿using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    #region Delegates

#pragma warning disable
#pragma warning restore

    #endregion

    /// <summary>
    /// CoClass UserDefinedProperty 
    /// SupportByVersion Outlook, 12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868543.aspx </remarks>
    [SupportByVersion("Outlook", 12, 14, 15, 16)]
    [EntityType(EntityType.IsCoClass)]
    public class UserDefinedProperty : _UserDefinedProperty
    {
#pragma warning disable

        #region Fields

        private NetRuntimeSystem.Runtime.InteropServices.ComTypes.IConnectionPoint _connectPoint;
        private string _activeSinkId;
        private static Type _type;

        #endregion

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

        /// <summary>
        /// Type Cache
        /// </summary>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(UserDefinedProperty);
                return _type;
            }
        }

        #endregion

        #region Construction

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public UserDefinedProperty(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
		public UserDefinedProperty(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {

        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public UserDefinedProperty(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public UserDefinedProperty(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public UserDefinedProperty(ICOMObject replacedObject) : base(replacedObject)
        {

        }

        /// <summary>
        /// Creates a new instance of UserDefinedProperty 
        /// </summary>		
        public UserDefinedProperty() : base("Outlook.UserDefinedProperty")
        {

        }

        /// <summary>
        /// Creates a new instance of UserDefinedProperty
        /// </summary>
        ///<param name="progId">registered ProgID</param>
        public UserDefinedProperty(string progId) : base(progId)
        {

        }

        #endregion

        #region Static CoClass Methods
        #endregion

        #region Events

        #endregion

#pragma warning restore
    }
}

