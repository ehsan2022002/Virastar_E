﻿using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    #region Delegates

#pragma warning disable
    public delegate void OlkListBox_ClickEventHandler();
    public delegate void OlkListBox_DoubleClickEventHandler();
    public delegate void OlkListBox_MouseDownEventHandler(NetOffice.OutlookApi.Enums.OlMouseButton button, NetOffice.OutlookApi.Enums.OlShiftState shift, Single x, Single y);
    public delegate void OlkListBox_MouseMoveEventHandler(NetOffice.OutlookApi.Enums.OlMouseButton button, NetOffice.OutlookApi.Enums.OlShiftState shift, Single x, Single y);
    public delegate void OlkListBox_MouseUpEventHandler(NetOffice.OutlookApi.Enums.OlMouseButton button, NetOffice.OutlookApi.Enums.OlShiftState shift, Single x, Single y);
    public delegate void OlkListBox_EnterEventHandler();
    public delegate void OlkListBox_ExitEventHandler(ref bool cancel);
    public delegate void OlkListBox_KeyDownEventHandler(ref Int32 keyCode, NetOffice.OutlookApi.Enums.OlShiftState shift);
    public delegate void OlkListBox_KeyPressEventHandler(ref Int32 keyAscii);
    public delegate void OlkListBox_KeyUpEventHandler(ref Int32 keyCode, NetOffice.OutlookApi.Enums.OlShiftState shift);
    public delegate void OlkListBox_ChangeEventHandler();
    public delegate void OlkListBox_AfterUpdateEventHandler();
    public delegate void OlkListBox_BeforeUpdateEventHandler(ref bool cancel);
#pragma warning restore

    #endregion

    /// <summary>
    /// CoClass OlkListBox 
    /// SupportByVersion Outlook, 12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff863585.aspx </remarks>
    [SupportByVersion("Outlook", 12, 14, 15, 16)]
    [EntityType(EntityType.IsCoClass)]
    [EventSink(typeof(Events.OlkListBoxEvents_SinkHelper))]
    [ComEventInterface(typeof(Events.OlkListBoxEvents))]
    public class OlkListBox : _OlkListBox, IEventBinding
    {
#pragma warning disable

        #region Fields

        private NetRuntimeSystem.Runtime.InteropServices.ComTypes.IConnectionPoint _connectPoint;
        private string _activeSinkId;
        private static Type _type;
        private Events.OlkListBoxEvents_SinkHelper _olkListBoxEvents_SinkHelper;

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
                    _type = typeof(OlkListBox);
                return _type;
            }
        }

        #endregion

        #region Construction

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public OlkListBox(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
		public OlkListBox(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {

        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public OlkListBox(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public OlkListBox(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public OlkListBox(ICOMObject replacedObject) : base(replacedObject)
        {

        }

        /// <summary>
        /// Creates a new instance of OlkListBox 
        /// </summary>		
        public OlkListBox() : base("Outlook.OlkListBox")
        {

        }

        /// <summary>
        /// Creates a new instance of OlkListBox
        /// </summary>
        ///<param name="progId">registered ProgID</param>
        public OlkListBox(string progId) : base(progId)
        {

        }

        #endregion

        #region Static CoClass Methods
        #endregion

        #region Events

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_ClickEventHandler _ClickEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff866067.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_ClickEventHandler ClickEvent
        {
            add
            {
                CreateEventBridge();
                _ClickEvent += value;
            }
            remove
            {
                _ClickEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_DoubleClickEventHandler _DoubleClickEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff866412.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_DoubleClickEventHandler DoubleClickEvent
        {
            add
            {
                CreateEventBridge();
                _DoubleClickEvent += value;
            }
            remove
            {
                _DoubleClickEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_MouseDownEventHandler _MouseDownEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff869274.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_MouseDownEventHandler MouseDownEvent
        {
            add
            {
                CreateEventBridge();
                _MouseDownEvent += value;
            }
            remove
            {
                _MouseDownEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_MouseMoveEventHandler _MouseMoveEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff868747.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_MouseMoveEventHandler MouseMoveEvent
        {
            add
            {
                CreateEventBridge();
                _MouseMoveEvent += value;
            }
            remove
            {
                _MouseMoveEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_MouseUpEventHandler _MouseUpEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff870174.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_MouseUpEventHandler MouseUpEvent
        {
            add
            {
                CreateEventBridge();
                _MouseUpEvent += value;
            }
            remove
            {
                _MouseUpEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_EnterEventHandler _EnterEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff870045.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_EnterEventHandler EnterEvent
        {
            add
            {
                CreateEventBridge();
                _EnterEvent += value;
            }
            remove
            {
                _EnterEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_ExitEventHandler _ExitEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff866452.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_ExitEventHandler ExitEvent
        {
            add
            {
                CreateEventBridge();
                _ExitEvent += value;
            }
            remove
            {
                _ExitEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_KeyDownEventHandler _KeyDownEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff868095.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_KeyDownEventHandler KeyDownEvent
        {
            add
            {
                CreateEventBridge();
                _KeyDownEvent += value;
            }
            remove
            {
                _KeyDownEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_KeyPressEventHandler _KeyPressEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff866003.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_KeyPressEventHandler KeyPressEvent
        {
            add
            {
                CreateEventBridge();
                _KeyPressEvent += value;
            }
            remove
            {
                _KeyPressEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_KeyUpEventHandler _KeyUpEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff866774.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_KeyUpEventHandler KeyUpEvent
        {
            add
            {
                CreateEventBridge();
                _KeyUpEvent += value;
            }
            remove
            {
                _KeyUpEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_ChangeEventHandler _ChangeEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff868533.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_ChangeEventHandler ChangeEvent
        {
            add
            {
                CreateEventBridge();
                _ChangeEvent += value;
            }
            remove
            {
                _ChangeEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_AfterUpdateEventHandler _AfterUpdateEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff861330.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_AfterUpdateEventHandler AfterUpdateEvent
        {
            add
            {
                CreateEventBridge();
                _AfterUpdateEvent += value;
            }
            remove
            {
                _AfterUpdateEvent -= value;
            }
        }

        /// <summary>
        /// SupportByVersion Outlook, 12,14,15,16
        /// </summary>
        private event OlkListBox_BeforeUpdateEventHandler _BeforeUpdateEvent;

        /// <summary>
        /// SupportByVersion Outlook 12 14 15,16
        /// </summary>
        ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff862397.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public event OlkListBox_BeforeUpdateEventHandler BeforeUpdateEvent
        {
            add
            {
                CreateEventBridge();
                _BeforeUpdateEvent += value;
            }
            remove
            {
                _BeforeUpdateEvent -= value;
            }
        }

        #endregion

        #region IEventBinding

        /// <summary>
        /// Creates active sink helper
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public void CreateEventBridge()
        {
            if (false == Factory.Settings.EnableEvents)
                return;

            if (null != _connectPoint)
                return;

            if (null == _activeSinkId)
                _activeSinkId = SinkHelper.GetConnectionPoint(this, ref _connectPoint, Events.OlkListBoxEvents_SinkHelper.Id);


            if (Events.OlkListBoxEvents_SinkHelper.Id.Equals(_activeSinkId, StringComparison.InvariantCultureIgnoreCase))
            {
                _olkListBoxEvents_SinkHelper = new Events.OlkListBoxEvents_SinkHelper(this, _connectPoint);
                return;
            }
        }

        /// <summary>
        /// The instance use currently an event listener 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool EventBridgeInitialized
        {
            get
            {
                return (null != _connectPoint);
            }
        }
        /// <summary>
        /// Instance has one or more event recipients
        /// </summary>
        /// <returns>true if one or more event is active, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool HasEventRecipients()
        {
            return NetOffice.Events.CoClassEventReflector.HasEventRecipients(this, LateBindingApiWrapperType);
        }

        /// <summary>
        /// Instance has one or more event recipients
        /// </summary>
        /// <param name="eventName">name of the event</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool HasEventRecipients(string eventName)
        {
            return NetOffice.Events.CoClassEventReflector.HasEventRecipients(this, LateBindingApiWrapperType, eventName);
        }

        /// <summary>
        /// Target methods from its actual event recipients
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Delegate[] GetEventRecipients(string eventName)
        {
            return NetOffice.Events.CoClassEventReflector.GetEventRecipients(this, LateBindingApiWrapperType, eventName);
        }

        /// <summary>
        /// Returns the current count of event recipients
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int GetCountOfEventRecipients(string eventName)
        {
            return NetOffice.Events.CoClassEventReflector.GetCountOfEventRecipients(this, LateBindingApiWrapperType, eventName);
        }

        /// <summary>
        /// Raise an instance event
        /// </summary>
        /// <param name="eventName">name of the event without 'Event' at the end</param>
        /// <param name="paramsArray">custom arguments for the event</param>
        /// <returns>count of called event recipients</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int RaiseCustomEvent(string eventName, ref object[] paramsArray)
        {
            return NetOffice.Events.CoClassEventReflector.RaiseCustomEvent(this, LateBindingApiWrapperType, eventName, ref paramsArray);
        }
        /// <summary>
        /// Stop listening events for the instance
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public void DisposeEventBridge()
        {
            if (null != _olkListBoxEvents_SinkHelper)
            {
                _olkListBoxEvents_SinkHelper.Dispose();
                _olkListBoxEvents_SinkHelper = null;
            }

            _connectPoint = null;
        }

        #endregion

#pragma warning restore
    }
}

