﻿using NetOffice.Attributes;
using System;
using System.ComponentModel;
using NetRuntimeSystem = System;

namespace NetOffice.OfficeApi
{
    /// <summary>
    /// DispatchInterface Shape 
    /// SupportByVersion Office, 9,10,11,12,14,15,16
    /// </summary>
    [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface)]
    public class Shape : _IMsoDispObj
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
                    _type = typeof(Shape);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public Shape(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public Shape(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Shape(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Shape(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Shape(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Shape(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Shape() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Shape(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// Unknown COM Proxy
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16), ProxyResult]
        public object Parent
        {
            get
            {
                return Factory.ExecuteReferencePropertyGet(this, "Parent");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Adjustments Adjustments
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.Adjustments>(this, "Adjustments", NetOffice.OfficeApi.Adjustments.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoAutoShapeType AutoShapeType
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoAutoShapeType>(this, "AutoShapeType");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "AutoShapeType", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoBlackWhiteMode BlackWhiteMode
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoBlackWhiteMode>(this, "BlackWhiteMode");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "BlackWhiteMode", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.CalloutFormat Callout
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.CalloutFormat>(this, "Callout", NetOffice.OfficeApi.CalloutFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 ConnectionSiteCount
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "ConnectionSiteCount");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState Connector
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "Connector");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.ConnectorFormat ConnectorFormat
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.ConnectorFormat>(this, "ConnectorFormat", NetOffice.OfficeApi.ConnectorFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.FillFormat Fill
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.FillFormat>(this, "Fill", NetOffice.OfficeApi.FillFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.GroupShapes GroupItems
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.GroupShapes>(this, "GroupItems", NetOffice.OfficeApi.GroupShapes.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
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
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState HorizontalFlip
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "HorizontalFlip");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public Single Left
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "Left");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Left", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.LineFormat Line
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.LineFormat>(this, "Line", NetOffice.OfficeApi.LineFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState LockAspectRatio
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "LockAspectRatio");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "LockAspectRatio", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public string Name
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Name");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Name", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.ShapeNodes Nodes
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.ShapeNodes>(this, "Nodes", NetOffice.OfficeApi.ShapeNodes.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public Single Rotation
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "Rotation");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Rotation", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.PictureFormat PictureFormat
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.PictureFormat>(this, "PictureFormat", NetOffice.OfficeApi.PictureFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.ShadowFormat Shadow
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.ShadowFormat>(this, "Shadow", NetOffice.OfficeApi.ShadowFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.TextEffectFormat TextEffect
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.TextEffectFormat>(this, "TextEffect", NetOffice.OfficeApi.TextEffectFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.TextFrame TextFrame
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.TextFrame>(this, "TextFrame", NetOffice.OfficeApi.TextFrame.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.ThreeDFormat ThreeD
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.ThreeDFormat>(this, "ThreeD", NetOffice.OfficeApi.ThreeDFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public Single Top
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "Top");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Top", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoShapeType Type
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoShapeType>(this, "Type");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState VerticalFlip
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "VerticalFlip");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public object Vertices
        {
            get
            {
                return Factory.ExecuteVariantPropertyGet(this, "Vertices");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState Visible
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "Visible");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "Visible", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public Single Width
        {
            get
            {
                return Factory.ExecuteSinglePropertyGet(this, "Width");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Width", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public Int32 ZOrderPosition
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "ZOrderPosition");
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Script Script
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.Script>(this, "Script", NetOffice.OfficeApi.Script.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public string AlternativeText
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "AlternativeText");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "AlternativeText", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState HasDiagram
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "HasDiagram");
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.IMsoDiagram Diagram
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.IMsoDiagram>(this, "Diagram", NetOffice.OfficeApi.IMsoDiagram.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState HasDiagramNode
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "HasDiagramNode");
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.DiagramNode DiagramNode
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.DiagramNode>(this, "DiagramNode", NetOffice.OfficeApi.DiagramNode.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState Child
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "Child");
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Shape ParentGroup
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.Shape>(this, "ParentGroup", NetOffice.OfficeApi.Shape.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public NetOffice.OfficeApi.CanvasShapes CanvasItems
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.CanvasShapes>(this, "CanvasItems", NetOffice.OfficeApi.CanvasShapes.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public Int32 Id
        {
            get
            {
                return Factory.ExecuteInt32PropertyGet(this, "Id");
            }
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public string RTF
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "RTF");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "RTF", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.TextFrame2 TextFrame2
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.TextFrame2>(this, "TextFrame2", NetOffice.OfficeApi.TextFrame2.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState HasChart
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "HasChart");
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.IMsoChart Chart
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.IMsoChart>(this, "Chart", NetOffice.OfficeApi.IMsoChart.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoShapeStyleIndex ShapeStyle
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoShapeStyleIndex>(this, "ShapeStyle");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "ShapeStyle", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoBackgroundStyleIndex BackgroundStyle
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoBackgroundStyleIndex>(this, "BackgroundStyle");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "BackgroundStyle", value);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.SoftEdgeFormat SoftEdge
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.SoftEdgeFormat>(this, "SoftEdge", NetOffice.OfficeApi.SoftEdgeFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.GlowFormat Glow
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.GlowFormat>(this, "Glow", NetOffice.OfficeApi.GlowFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public NetOffice.OfficeApi.ReflectionFormat Reflection
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.ReflectionFormat>(this, "Reflection", NetOffice.OfficeApi.ReflectionFormat.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 14, 15, 16)]
        public NetOffice.OfficeApi.Enums.MsoTriState HasSmartArt
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.OfficeApi.Enums.MsoTriState>(this, "HasSmartArt");
            }
        }

        /// <summary>
        /// SupportByVersion Office 14, 15, 16
        /// Get
        /// </summary>
        [SupportByVersion("Office", 14, 15, 16)]
        public NetOffice.OfficeApi.SmartArt SmartArt
        {
            get
            {
                return Factory.ExecuteKnownReferencePropertyGet<NetOffice.OfficeApi.SmartArt>(this, "SmartArt", NetOffice.OfficeApi.SmartArt.LateBindingApiWrapperType);
            }
        }

        /// <summary>
        /// SupportByVersion Office 14, 15, 16
        /// Get/Set
        /// </summary>
        [SupportByVersion("Office", 14, 15, 16)]
        public string Title
        {
            get
            {
                return Factory.ExecuteStringPropertyGet(this, "Title");
            }
            set
            {
                Factory.ExecuteValuePropertySet(this, "Title", value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void Apply()
        {
            Factory.ExecuteMethod(this, "Apply");
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void Delete()
        {
            Factory.ExecuteMethod(this, "Delete");
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.Shape Duplicate()
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OfficeApi.Shape>(this, "Duplicate", NetOffice.OfficeApi.Shape.LateBindingApiWrapperType);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="flipCmd">NetOffice.OfficeApi.Enums.MsoFlipCmd flipCmd</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void Flip(NetOffice.OfficeApi.Enums.MsoFlipCmd flipCmd)
        {
            Factory.ExecuteMethod(this, "Flip", flipCmd);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void IncrementLeft(Single increment)
        {
            Factory.ExecuteMethod(this, "IncrementLeft", increment);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void IncrementRotation(Single increment)
        {
            Factory.ExecuteMethod(this, "IncrementRotation", increment);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void IncrementTop(Single increment)
        {
            Factory.ExecuteMethod(this, "IncrementTop", increment);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void PickUp()
        {
            Factory.ExecuteMethod(this, "PickUp");
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void RerouteConnections()
        {
            Factory.ExecuteMethod(this, "RerouteConnections");
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="factor">Single factor</param>
        /// <param name="relativeToOriginalSize">NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize</param>
        /// <param name="fScale">optional NetOffice.OfficeApi.Enums.MsoScaleFrom fScale = 0</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void ScaleHeight(Single factor, NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize, object fScale)
        {
            Factory.ExecuteMethod(this, "ScaleHeight", factor, relativeToOriginalSize, fScale);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="factor">Single factor</param>
        /// <param name="relativeToOriginalSize">NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize</param>
        [CustomMethod]
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void ScaleHeight(Single factor, NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize)
        {
            Factory.ExecuteMethod(this, "ScaleHeight", factor, relativeToOriginalSize);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="factor">Single factor</param>
        /// <param name="relativeToOriginalSize">NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize</param>
        /// <param name="fScale">optional NetOffice.OfficeApi.Enums.MsoScaleFrom fScale = 0</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void ScaleWidth(Single factor, NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize, object fScale)
        {
            Factory.ExecuteMethod(this, "ScaleWidth", factor, relativeToOriginalSize, fScale);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="factor">Single factor</param>
        /// <param name="relativeToOriginalSize">NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize</param>
        [CustomMethod]
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void ScaleWidth(Single factor, NetOffice.OfficeApi.Enums.MsoTriState relativeToOriginalSize)
        {
            Factory.ExecuteMethod(this, "ScaleWidth", factor, relativeToOriginalSize);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="replace">optional object replace</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void Select(object replace)
        {
            Factory.ExecuteMethod(this, "Select", replace);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [CustomMethod]
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void Select()
        {
            Factory.ExecuteMethod(this, "Select");
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void SetShapesDefaultProperties()
        {
            Factory.ExecuteMethod(this, "SetShapesDefaultProperties");
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.OfficeApi.ShapeRange Ungroup()
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.OfficeApi.ShapeRange>(this, "Ungroup", NetOffice.OfficeApi.ShapeRange.LateBindingApiWrapperType);
        }

        /// <summary>
        /// SupportByVersion Office 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="zOrderCmd">NetOffice.OfficeApi.Enums.MsoZOrderCmd zOrderCmd</param>
        [SupportByVersion("Office", 9, 10, 11, 12, 14, 15, 16)]
        public void ZOrder(NetOffice.OfficeApi.Enums.MsoZOrderCmd zOrderCmd)
        {
            Factory.ExecuteMethod(this, "ZOrder", zOrderCmd);
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public void CanvasCropLeft(Single increment)
        {
            Factory.ExecuteMethod(this, "CanvasCropLeft", increment);
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public void CanvasCropTop(Single increment)
        {
            Factory.ExecuteMethod(this, "CanvasCropTop", increment);
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public void CanvasCropRight(Single increment)
        {
            Factory.ExecuteMethod(this, "CanvasCropRight", increment);
        }

        /// <summary>
        /// SupportByVersion Office 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <param name="increment">Single increment</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [SupportByVersion("Office", 10, 11, 12, 14, 15, 16)]
        public void CanvasCropBottom(Single increment)
        {
            Factory.ExecuteMethod(this, "CanvasCropBottom", increment);
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public void Cut()
        {
            Factory.ExecuteMethod(this, "Cut");
        }

        /// <summary>
        /// SupportByVersion Office 12, 14, 15, 16
        /// </summary>
        [SupportByVersion("Office", 12, 14, 15, 16)]
        public void Copy()
        {
            Factory.ExecuteMethod(this, "Copy");
        }

        /// <summary>
        /// SupportByVersion Office 14, 15, 16
        /// </summary>
        /// <param name="layout">NetOffice.OfficeApi.SmartArtLayout layout</param>
        [SupportByVersion("Office", 14, 15, 16)]
        public void ConvertTextToSmartArt(NetOffice.OfficeApi.SmartArtLayout layout)
        {
            Factory.ExecuteMethod(this, "ConvertTextToSmartArt", layout);
        }

        #endregion

#pragma warning restore
    }
}
