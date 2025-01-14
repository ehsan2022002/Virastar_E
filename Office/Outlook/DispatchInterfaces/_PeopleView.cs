using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    /// <summary>
    /// DispatchInterface _PeopleView 
    /// SupportByVersion Outlook, 15, 16
    /// </summary>
    [SupportByVersion("Outlook", 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), BaseType]
    public class _PeopleView : COMObject
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
                    _type = typeof(_PeopleView);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public _PeopleView(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public _PeopleView(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _PeopleView(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _PeopleView(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _PeopleView(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _PeopleView(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _PeopleView() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _PeopleView(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj228406.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._Application Application
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._Application>(this, "Application");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj230583.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public NetOffice.OutlookApi.Enums.OlObjectClass Class
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlObjectClass>(this, "Class");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj228591.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._NameSpace Session
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._NameSpace>(this, "Session");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj230405.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj227687.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public string Language
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Language");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Language", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj228057.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public bool LockUserChanges
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "LockUserChanges");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "LockUserChanges", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj231136.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public string Name
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Name");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Name", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj230036.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public NetOffice.OutlookApi.Enums.OlViewSaveOption SaveOption
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlViewSaveOption>(this, "SaveOption");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj229062.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public bool Standard
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "Standard");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj229669.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public NetOffice.OutlookApi.Enums.OlViewType ViewType
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlViewType>(this, "ViewType");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj228325.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public string XML
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "XML");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "XML", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj228064.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public string Filter
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Filter");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Filter", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj229733.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public NetOffice.OutlookApi.OrderFields SortFields
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.OrderFields>(this, "SortFields", NetOffice.OutlookApi.OrderFields.LateBindingApiWrapperType);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj227495.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public void Apply()
        {
            Factory.ExecuteMethod(this, "Apply");
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj231247.aspx </remarks>
        /// <param name="name">string name</param>
        /// <param name="saveOption">optional NetOffice.OutlookApi.Enums.OlViewSaveOption saveOption</param>
        [SupportByVersion("Outlook", 15, 16)]
        public NetOffice.OutlookApi.View Copy(string name, object saveOption)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.View>(this, "Copy", NetOffice.OutlookApi.View.LateBindingApiWrapperType, name, saveOption);
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj231247.aspx </remarks>
        /// <param name="name">string name</param>
        [CustomMethod]
        [SupportByVersion("Outlook", 15, 16)]
        public NetOffice.OutlookApi.View Copy(string name)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.View>(this, "Copy", NetOffice.OutlookApi.View.LateBindingApiWrapperType, name);
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj227780.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public void Delete()
        {
            Factory.ExecuteMethod(this, "Delete");
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj231541.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public void Reset()
        {
            Factory.ExecuteMethod(this, "Reset");
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj230523.aspx </remarks>
        [SupportByVersion("Outlook", 15, 16)]
        public void Save()
        {
            Factory.ExecuteMethod(this, "Save");
        }

        /// <summary>
        /// SupportByVersion Outlook 15,16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/jj230336.aspx </remarks>
        /// <param name="date">DateTime date</param>
        [SupportByVersion("Outlook", 15, 16)]
        public void GoToDate(DateTime date)
        {
            Factory.ExecuteMethod(this, "GoToDate", date);
        }

        #endregion

#pragma warning restore
    }
}
