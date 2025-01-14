﻿using NetOffice.Attributes;
namespace NetOffice.OfficeApi.Enums
{
    /// <summary>
    /// SupportByVersion Office 10, 11, 12, 14, 15, 16
    /// </summary>
    [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsEnum)]
    public enum MsoDiagramType
    {
        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>-2</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramMixed = -2,

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>1</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramOrgChart = 1,

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>2</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramCycle = 2,

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>3</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramRadial = 3,

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>4</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramPyramid = 4,

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>5</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramVenn = 5,

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks>6</remarks>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        msoDiagramTarget = 6
    }
}