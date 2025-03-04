﻿using NetOffice.Attributes;
namespace NetOffice.OutlookApi.Enums
{
    /// <summary>
    /// SupportByVersion Outlook 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff865789.aspx </remarks>
    [SupportByVersion("Outlook", 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum OlAddressListType
    {
        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olExchangeGlobalAddressList = 0,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olExchangeContainer = 1,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olOutlookAddressList = 2,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olOutlookLdapAddressList = 3,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olCustomAddressList = 4
    }
}