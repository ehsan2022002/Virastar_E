﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 12, 14, 15, 16
    /// </summary>
    [SupportByVersion("Office", 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum XlRowCol
    {
        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        xlColumns = 2,

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        xlRows = 1
    }
}