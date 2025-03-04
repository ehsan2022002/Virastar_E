﻿using NetOffice.Attributes;
using NetOffice.CollectionsGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.WordApi
{
    /// <summary>
    /// DispatchInterface Rows 
    /// SupportByVersion Word, 9,10,11,12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff838328.aspx </remarks>
    [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), Enumerator(Enumerator.Reference, EnumeratorInvoke.Property), HasIndexProperty(IndexInvoke.Method, "Item")]
    public class Rows : COMObject, IEnumerableProvider<NetOffice.WordApi.Row>
    {
#pragma warning disable

        #region Type Information

        /// <summary>
        /// Instance Type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), Category("NetOffice"), CoreOverridden]
        public override Type InstanceType
        {
            get
            {
                return LateBindingApiWrapperType;
            }
        }

        private static Type _type;

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(Rows);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public Rows(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public Rows(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Rows(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Rows(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Rows(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Rows(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Rows() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Rows(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198088.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 Count
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Count");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198092.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 AllowBreakAcrossPages
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "AllowBreakAcrossPages");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "AllowBreakAcrossPages", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff845299.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdRowAlignment Alignment
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdRowAlignment>(this, "Alignment");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "Alignment", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192218.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 HeadingFormat
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "HeadingFormat");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "HeadingFormat", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192592.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single SpaceBetweenColumns
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "SpaceBetweenColumns");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "SpaceBetweenColumns", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837714.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single Height
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "Height");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Height", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff194903.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdRowHeightRule HeightRule
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdRowHeightRule>(this, "HeightRule");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "HeightRule", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837450.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single LeftIndent
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "LeftIndent");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "LeftIndent", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff835186.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Row First
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Row>(this, "First", NetOffice.WordApi.Row.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff836402.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Row Last
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Row>(this, "Last", NetOffice.WordApi.Row.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff194218.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Application Application
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Application>(this, "Application", NetOffice.WordApi.Application.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196022.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 Creator
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Creator");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196892.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff195338.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Borders Borders
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Borders>(this, "Borders", NetOffice.WordApi.Borders.LateBindingApiWrapperType);
            }
            set
            {
                Factory.ExecuteReferencePropertySet(this, "Borders", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff821302.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Shading Shading
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.WordApi.Shading>(this, "Shading", NetOffice.WordApi.Shading.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198020.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 WrapAroundText
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "WrapAroundText");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "WrapAroundText", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff195656.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single DistanceTop
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "DistanceTop");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "DistanceTop", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192202.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single DistanceBottom
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "DistanceBottom");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "DistanceBottom", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192572.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single DistanceLeft
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "DistanceLeft");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "DistanceLeft", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff197599.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single DistanceRight
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "DistanceRight");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "DistanceRight", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192394.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single HorizontalPosition
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "HorizontalPosition");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "HorizontalPosition", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196877.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Single VerticalPosition
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "VerticalPosition");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "VerticalPosition", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837944.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdRelativeHorizontalPosition RelativeHorizontalPosition
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdRelativeHorizontalPosition>(this, "RelativeHorizontalPosition");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "RelativeHorizontalPosition", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192758.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdRelativeVerticalPosition RelativeVerticalPosition
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdRelativeVerticalPosition>(this, "RelativeVerticalPosition");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "RelativeVerticalPosition", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff192737.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 AllowOverlap
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "AllowOverlap");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "AllowOverlap", value);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff195972.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 NestingLevel
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "NestingLevel");
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff844889.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdTableDirection TableDirection
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdTableDirection>(this, "TableDirection");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "TableDirection", value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="index">Int32 index</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        [NetRuntimeSystem.Runtime.CompilerServices.IndexerName("Item"), IndexProperty]
        public NetOffice.WordApi.Row this[Int32 index]
        {
            get
            {
                return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Row>(this, "Item", NetOffice.WordApi.Row.LateBindingApiWrapperType, index);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff838946.aspx </remarks>
        /// <param name="beforeRow">optional object beforeRow</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Row Add(object beforeRow)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Row>(this, "Add", NetOffice.WordApi.Row.LateBindingApiWrapperType, beforeRow);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff838946.aspx </remarks>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Row Add()
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Row>(this, "Add", NetOffice.WordApi.Row.LateBindingApiWrapperType);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff835741.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void Select()
        {
            Factory.ExecuteMethod(this, "Select");
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837909.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void Delete()
        {
            Factory.ExecuteMethod(this, "Delete");
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff195355.aspx </remarks>
        /// <param name="leftIndent">Single leftIndent</param>
        /// <param name="rulerStyle">NetOffice.WordApi.Enums.WdRulerStyle rulerStyle</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void SetLeftIndent(Single leftIndent, NetOffice.WordApi.Enums.WdRulerStyle rulerStyle)
        {
            Factory.ExecuteMethod(this, "SetLeftIndent", leftIndent, rulerStyle);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff197905.aspx </remarks>
        /// <param name="rowHeight">Single rowHeight</param>
        /// <param name="heightRule">NetOffice.WordApi.Enums.WdRowHeightRule heightRule</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void SetHeight(Single rowHeight, NetOffice.WordApi.Enums.WdRowHeightRule heightRule)
        {
            Factory.ExecuteMethod(this, "SetHeight", rowHeight, heightRule);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="separator">optional object separator</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range ConvertToTextOld(object separator)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Range>(this, "ConvertToTextOld", NetOffice.WordApi.Range.LateBindingApiWrapperType, separator);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range ConvertToTextOld()
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Range>(this, "ConvertToTextOld", NetOffice.WordApi.Range.LateBindingApiWrapperType);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff840600.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void DistributeHeight()
        {
            Factory.ExecuteMethod(this, "DistributeHeight");
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff193616.aspx </remarks>
        /// <param name="separator">optional object separator</param>
        /// <param name="nestedTables">optional object nestedTables</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range ConvertToText(object separator, object nestedTables)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Range>(this, "ConvertToText", NetOffice.WordApi.Range.LateBindingApiWrapperType, separator, nestedTables);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff193616.aspx </remarks>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range ConvertToText()
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Range>(this, "ConvertToText", NetOffice.WordApi.Range.LateBindingApiWrapperType);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff193616.aspx </remarks>
        /// <param name="separator">optional object separator</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Range ConvertToText(object separator)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Range>(this, "ConvertToText", NetOffice.WordApi.Range.LateBindingApiWrapperType, separator);
        }

        #endregion

        #region IEnumerableProvider<NetOffice.WordApi.Row>

        ICOMObject IEnumerableProvider<NetOffice.WordApi.Row>.GetComObjectEnumerator(ICOMObject parent)
        {
            return NetOffice.Utils.GetComObjectEnumeratorAsProperty(parent, this, false);
        }

        IEnumerable IEnumerableProvider<NetOffice.WordApi.Row>.FetchVariantComObjectEnumerator(ICOMObject parent, ICOMObject enumerator)
        {
            return NetOffice.Utils.FetchVariantComObjectEnumerator(parent, enumerator, false);
        }

        #endregion

        #region IEnumerable<NetOffice.WordApi.Row>

        /// <summary>
        /// SupportByVersion Word, 9,10,11,12,14,15,16
        /// </summary>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public IEnumerator<NetOffice.WordApi.Row> GetEnumerator()
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.WordApi.Row item in innerEnumerator)
                yield return item;
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// SupportByVersion Word, 9,10,11,12,14,15,16
        /// </summary>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        IEnumerator NetRuntimeSystem.Collections.IEnumerable.GetEnumerator()
        {
            return NetOffice.Utils.GetProxyEnumeratorAsProperty(this, false);
        }

        #endregion

#pragma warning restore
    }
}