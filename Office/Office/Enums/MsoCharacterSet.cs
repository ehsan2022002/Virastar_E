﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff860886.aspx </remarks>
    [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum MsoCharacterSet
    {
        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetArabic = 1,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetCyrillic = 2,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetEnglishWesternEuropeanOtherLatinScript = 3,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetGreek = 4,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>5</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetHebrew = 5,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>6</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetJapanese = 6,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>7</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetKorean = 7,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>8</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetMultilingualUnicode = 8,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>9</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetSimplifiedChinese = 9,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>10</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetThai = 10,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>11</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetTraditionalChinese = 11,

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>12</remarks>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        msoCharacterSetVietnamese = 12
    }
}