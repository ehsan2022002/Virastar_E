﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff860276.aspx </remarks>
    [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum MsoCalloutDropType
    {
        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>-2</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCalloutDropMixed = -2,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCalloutDropCustom = 1,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCalloutDropTop = 2,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCalloutDropCenter = 3,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCalloutDropBottom = 4
    }
}