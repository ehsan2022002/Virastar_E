﻿using NetOffice.Attributes;
namespace NetOffice.WordApi.Enums
{
    /// <summary>
    /// SupportByVersion Word 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff845007.aspx </remarks>
    [SupportByVersion("Word", 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum XlDisplayUnit
    {
        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-2</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlHundreds = -2,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-3</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlThousands = -3,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-4</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlTenThousands = -4,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-5</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlHundredThousands = -5,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-6</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlMillions = -6,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-7</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlTenMillions = -7,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-8</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlHundredMillions = -8,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-9</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlThousandMillions = -9,

        /// <summary>
        /// SupportByVersion Word 14, 15, 16
        /// </summary>
        /// <remarks>-10</remarks>
        [SupportByVersion("Word", 14, 15, 16)]
        xlMillionMillions = -10
    }
}