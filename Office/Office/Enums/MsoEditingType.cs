﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff862057.aspx </remarks>
    [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum MsoEditingType
    {
        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoEditingAuto = 0,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoEditingCorner = 1,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoEditingSmooth = 2,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoEditingSymmetric = 3
    }
}