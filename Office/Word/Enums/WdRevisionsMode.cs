﻿using NetOffice.Attributes;
namespace NetOffice.WordApi.Enums
{
    /// <summary>
    /// SupportByVersion Word 10, 11, 12, 14, 15, 16
    /// </summary>
    ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff839945.aspx </remarks>
    [SupportByVersion("Word", 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum WdRevisionsMode
    {
        /// <summary>
        /// SupportByVersion Word 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>0</remarks>
        [SupportByVersion("Word", 10, 11, 12, 14, 15, 16)]
        wdBalloonRevisions = 0,

        /// <summary>
        /// SupportByVersion Word 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Word", 10, 11, 12, 14, 15, 16)]
        wdInLineRevisions = 1,

        /// <summary>
        /// SupportByVersion Word 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Word", 11, 12, 14, 15, 16)]
        wdMixedRevisions = 2
    }
}