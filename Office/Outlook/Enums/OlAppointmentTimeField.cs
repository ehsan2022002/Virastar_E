﻿using NetOffice.Attributes;
namespace NetOffice.OutlookApi.Enums
{
    /// <summary>
    /// SupportByVersion Outlook 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff865834.aspx </remarks>
    [SupportByVersion("Outlook", 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum OlAppointmentTimeField
    {
        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olAppointmentTimeFieldNone = 1,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olAppointmentTimeFieldStart = 2,

        /// <summary>
        /// SupportByVersion Outlook 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Outlook", 12, 14, 15, 16)]
        olAppointmentTimeFieldEnd = 3
    }
}