﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff864692.aspx </remarks>
    [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum MsoPresetLightingDirection
    {
        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>-2</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoPresetLightingDirectionMixed = -2,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingTopLeft = 1,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingTop = 2,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingTopRight = 3,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingLeft = 4,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>5</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingNone = 5,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>6</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingRight = 6,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>7</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingBottomLeft = 7,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>8</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingBottom = 8,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>9</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoLightingBottomRight = 9
    }
}