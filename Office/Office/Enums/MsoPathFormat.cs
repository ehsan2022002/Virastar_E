﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff862492.aspx </remarks>
    [SupportByVersion("Office", 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum MsoPathFormat
    {
        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>-2</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        msoPathTypeMixed = -2,

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        msoPathTypeNone = 0,

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        msoPathType1 = 1,

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        msoPathType2 = 2,

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        msoPathType3 = 3,

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        msoPathType4 = 4
    }
}