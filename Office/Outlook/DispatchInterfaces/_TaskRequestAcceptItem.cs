using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OutlookApi
{
    /// <summary>
    /// DispatchInterface _TaskRequestAcceptItem 
    /// SupportByVersion Outlook, 9,10,11,12,14,15,16
    /// </summary>
    [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), BaseType]
    public class _TaskRequestAcceptItem : COMObject
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
                    _type = typeof(_TaskRequestAcceptItem);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public _TaskRequestAcceptItem(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public _TaskRequestAcceptItem(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _TaskRequestAcceptItem(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _TaskRequestAcceptItem(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _TaskRequestAcceptItem(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _TaskRequestAcceptItem(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _TaskRequestAcceptItem() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public _TaskRequestAcceptItem(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867837.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._Application Application
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._Application>(this, "Application");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869378.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlObjectClass Class
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlObjectClass>(this, "Class");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff865393.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._NameSpace Session
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._NameSpace>(this, "Session");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff860933.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869655.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Actions Actions
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.Actions>(this, "Actions", NetOffice.OutlookApi.Actions.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869668.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Attachments Attachments
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.Attachments>(this, "Attachments", NetOffice.OutlookApi.Attachments.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868615.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string BillingInformation
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "BillingInformation");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "BillingInformation", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff864404.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string Body
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Body");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Body", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff861804.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string Categories
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Categories");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Categories", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867120.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string Companies
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Companies");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Companies", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868686.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string ConversationIndex
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "ConversationIndex");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff870094.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string ConversationTopic
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "ConversationTopic");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869526.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public DateTime CreationTime
        {
            get
            {
                return Factory.ExecuteDateTimePropertyGet(this, "CreationTime");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869675.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string EntryID
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "EntryID");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff870025.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.FormDescription FormDescription
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.FormDescription>(this, "FormDescription", NetOffice.OutlookApi.FormDescription.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866025.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._Inspector GetInspector
        {
            get
            {
                return Factory.ExecuteBaseReferencePropertyGet<NetOffice.OutlookApi._Inspector>(this, "GetInspector");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868099.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlImportance Importance
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlImportance>(this, "Importance");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "Importance", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff865631.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public DateTime LastModificationTime
        {
            get
            {
                return Factory.ExecuteDateTimePropertyGet(this, "LastModificationTime");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public object MAPIOBJECT
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "MAPIOBJECT");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867152.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string MessageClass
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "MessageClass");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "MessageClass", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff863725.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string Mileage
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Mileage");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Mileage", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868274.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public bool NoAging
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "NoAging");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "NoAging", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866782.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 OutlookInternalVersion
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "OutlookInternalVersion");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff865043.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string OutlookVersion
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "OutlookVersion");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869207.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public bool Saved
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "Saved");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866766.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlSensitivity Sensitivity
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlSensitivity>(this, "Sensitivity");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "Sensitivity", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867269.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 Size
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Size");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866020.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public string Subject
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Subject");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Subject", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868295.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public bool UnRead
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "UnRead");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "UnRead", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff864407.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.UserProperties UserProperties
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.UserProperties>(this, "UserProperties", NetOffice.OutlookApi.UserProperties.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Links Links
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.Links>(this, "Links", NetOffice.OutlookApi.Links.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868045.aspx </remarks>
        [SupportByVersion("Outlook", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlDownloadState DownloadState
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlDownloadState>(this, "DownloadState");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866914.aspx </remarks>
        [SupportByVersion("Outlook", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.ItemProperties ItemProperties
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.ItemProperties>(this, "ItemProperties", NetOffice.OutlookApi.ItemProperties.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869897.aspx </remarks>
        [SupportByVersion("Outlook", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Enums.OlRemoteStatus MarkForDownload
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OutlookApi.Enums.OlRemoteStatus>(this, "MarkForDownload");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "MarkForDownload", value);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869646.aspx </remarks>
        [SupportByVersion("Outlook", 10, 11, 12, 14, 15, 16)]
        public bool IsConflict
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "IsConflict");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff862983.aspx </remarks>
        [SupportByVersion("Outlook", 11, 12, 14, 15, 16)]
        public bool AutoResolvedWinner
        {
            get
            {
                return Factory.ExecuteBoolPropertyGet(this, "AutoResolvedWinner");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff866081.aspx </remarks>
        [SupportByVersion("Outlook", 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.Conflicts Conflicts
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.Conflicts>(this, "Conflicts", NetOffice.OutlookApi.Conflicts.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff862414.aspx </remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        public NetOffice.OutlookApi.PropertyAccessor PropertyAccessor
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OutlookApi.PropertyAccessor>(this, "PropertyAccessor", NetOffice.OutlookApi.PropertyAccessor.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff860959.aspx </remarks>
        [SupportByVersion("Outlook", 14, 15, 16)]
        public string ConversationID
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "ConversationID");
            }
        }

        /// <summary>
        /// SupportByVersion Outlook 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff861236.aspx </remarks>
        [SupportByVersion("Outlook", 14, 15, 16)]
        public object RTFBody
        {
            get
            {
                return Factory.ExecuteVariantPropertyGet(this, "RTFBody");
            }
            set
            {
                Factory.ExecuteVariantPropertySet(this, "RTFBody", value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867481.aspx </remarks>
        /// <param name="saveMode">NetOffice.OutlookApi.Enums.OlInspectorClose saveMode</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void Close(NetOffice.OutlookApi.Enums.OlInspectorClose saveMode)
        {
            Factory.ExecuteMethod(this, "Close", saveMode);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff862084.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public object Copy()
        {
            return Factory.ExecuteVariantMethodGet(this, "Copy");
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869008.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void Delete()
        {
            Factory.ExecuteMethod(this, "Delete");
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869170.aspx </remarks>
        /// <param name="modal">optional object modal</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void Display(object modal)
        {
            Factory.ExecuteMethod(this, "Display", modal);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869170.aspx </remarks>
        [CustomMethod]
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void Display()
        {
            Factory.ExecuteMethod(this, "Display");
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff865841.aspx </remarks>
        /// <param name="destFldr">NetOffice.OutlookApi.MAPIFolder destFldr</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public object Move(NetOffice.OutlookApi.MAPIFolder destFldr)
        {
            return Factory.ExecuteVariantMethodGet(this, "Move", destFldr);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869617.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void PrintOut()
        {
            Factory.ExecuteMethod(this, "PrintOut");
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff869618.aspx </remarks>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void Save()
        {
            Factory.ExecuteMethod(this, "Save");
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867480.aspx </remarks>
        /// <param name="path">string path</param>
        /// <param name="type">optional object type</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void SaveAs(string path, object type)
        {
            Factory.ExecuteMethod(this, "SaveAs", path, type);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867480.aspx </remarks>
        /// <param name="path">string path</param>
        [CustomMethod]
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public void SaveAs(string path)
        {
            Factory.ExecuteMethod(this, "SaveAs", path);
        }

        /// <summary>
        /// SupportByVersion Outlook 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff867905.aspx </remarks>
        /// <param name="addToTaskList">bool addToTaskList</param>
        [SupportByVersion("Outlook", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OutlookApi.TaskItem GetAssociatedTask(bool addToTaskList)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OutlookApi.TaskItem>(this, "GetAssociatedTask", NetOffice.OutlookApi.TaskItem.LateBindingApiWrapperType, addToTaskList);
        }

        /// <summary>
        /// SupportByVersion Outlook 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868460.aspx </remarks>
        [SupportByVersion("Outlook", 10, 11, 12, 14, 15, 16)]
        public void ShowCategoriesDialog()
        {
            Factory.ExecuteMethod(this, "ShowCategoriesDialog");
        }

        /// <summary>
        /// SupportByVersion Outlook 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff868858.aspx </remarks>
        [SupportByVersion("Outlook", 14, 15, 16)]
        [BaseResult]
        public NetOffice.OutlookApi._Conversation GetConversation()
        {
            return Factory.ExecuteBaseReferenceMethodGet<NetOffice.OutlookApi._Conversation>(this, "GetConversation");
        }

        #endregion

#pragma warning restore
    }
}
