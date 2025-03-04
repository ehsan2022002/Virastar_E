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
    /// DispatchInterface TablesOfAuthorities 
    /// SupportByVersion Word, 9,10,11,12,14,15,16
    /// </summary>
    /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837712.aspx </remarks>
    [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
    [EntityType(EntityType.IsDispatchInterface), Enumerator(Enumerator.Reference, EnumeratorInvoke.Property), HasIndexProperty(IndexInvoke.Method, "Item")]
    public class TablesOfAuthorities : COMObject, IEnumerableProvider<NetOffice.WordApi.TableOfAuthorities>
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
                    _type = typeof(TablesOfAuthorities);
                return _type;
            }
        }

        #endregion

        #region Ctor

        /// <param name="factory">current used factory core</param>
        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="proxyShare">proxy share instead if com proxy</param>
        public TablesOfAuthorities(Core factory, ICOMObject parentObject, COMProxyShare proxyShare) : base(factory, parentObject, proxyShare)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        public TablesOfAuthorities(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TablesOfAuthorities(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
        {
        }

        ///<param name="factory">current used factory core</param>
        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TablesOfAuthorities(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
        {

        }

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TablesOfAuthorities(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
        {
        }

        ///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TablesOfAuthorities(ICOMObject replacedObject) : base(replacedObject)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TablesOfAuthorities() : base()
        {
        }

        /// <param name="progId">registered progID</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TablesOfAuthorities(string progId) : base(progId)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff820743.aspx </remarks>
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
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff845059.aspx </remarks>
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
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff838690.aspx </remarks>
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
        /// Get
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837691.aspx </remarks>
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
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff839360.aspx </remarks>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Enums.WdToaFormat Format
        {
            get
            {
                return Factory.ExecuteEnumPropertyGet<NetOffice.WordApi.Enums.WdToaFormat>(this, "Format");
            }
            set
            {
                Factory.ExecuteEnumPropertySet(this, "Format", value);
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
        public NetOffice.WordApi.TableOfAuthorities this[Int32 index]
        {
            get
            {
                return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Item", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, index);
            }
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        /// <param name="separator">optional object separator</param>
        /// <param name="includeSequenceName">optional object includeSequenceName</param>
        /// <param name="entrySeparator">optional object entrySeparator</param>
        /// <param name="pageRangeSeparator">optional object pageRangeSeparator</param>
        /// <param name="includeCategoryHeader">optional object includeCategoryHeader</param>
        /// <param name="pageNumberSeparator">optional object pageNumberSeparator</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting, object separator, object includeSequenceName, object entrySeparator, object pageRangeSeparator, object includeCategoryHeader, object pageNumberSeparator)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting, separator, includeSequenceName, entrySeparator, pageRangeSeparator, includeCategoryHeader, pageNumberSeparator });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, range);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, range, category);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, range, category, bookmark);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, range, category, bookmark, passim);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        /// <param name="separator">optional object separator</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting, object separator)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting, separator });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        /// <param name="separator">optional object separator</param>
        /// <param name="includeSequenceName">optional object includeSequenceName</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting, object separator, object includeSequenceName)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting, separator, includeSequenceName });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        /// <param name="separator">optional object separator</param>
        /// <param name="includeSequenceName">optional object includeSequenceName</param>
        /// <param name="entrySeparator">optional object entrySeparator</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting, object separator, object includeSequenceName, object entrySeparator)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting, separator, includeSequenceName, entrySeparator });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        /// <param name="separator">optional object separator</param>
        /// <param name="includeSequenceName">optional object includeSequenceName</param>
        /// <param name="entrySeparator">optional object entrySeparator</param>
        /// <param name="pageRangeSeparator">optional object pageRangeSeparator</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting, object separator, object includeSequenceName, object entrySeparator, object pageRangeSeparator)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting, separator, includeSequenceName, entrySeparator, pageRangeSeparator });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff822964.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="category">optional object category</param>
        /// <param name="bookmark">optional object bookmark</param>
        /// <param name="passim">optional object passim</param>
        /// <param name="keepEntryFormatting">optional object keepEntryFormatting</param>
        /// <param name="separator">optional object separator</param>
        /// <param name="includeSequenceName">optional object includeSequenceName</param>
        /// <param name="entrySeparator">optional object entrySeparator</param>
        /// <param name="pageRangeSeparator">optional object pageRangeSeparator</param>
        /// <param name="includeCategoryHeader">optional object includeCategoryHeader</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.TableOfAuthorities Add(NetOffice.WordApi.Range range, object category, object bookmark, object passim, object keepEntryFormatting, object separator, object includeSequenceName, object entrySeparator, object pageRangeSeparator, object includeCategoryHeader)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.TableOfAuthorities>(this, "Add", NetOffice.WordApi.TableOfAuthorities.LateBindingApiWrapperType, new object[] { range, category, bookmark, passim, keepEntryFormatting, separator, includeSequenceName, entrySeparator, pageRangeSeparator, includeCategoryHeader });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff837703.aspx </remarks>
        /// <param name="shortCitation">string shortCitation</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void NextCitation(string shortCitation)
        {
            Factory.ExecuteMethod(this, "NextCitation", shortCitation);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198045.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="shortCitation">string shortCitation</param>
        /// <param name="longCitation">optional object longCitation</param>
        /// <param name="longCitationAutoText">optional object longCitationAutoText</param>
        /// <param name="category">optional object category</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Field MarkCitation(NetOffice.WordApi.Range range, string shortCitation, object longCitation, object longCitationAutoText, object category)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Field>(this, "MarkCitation", NetOffice.WordApi.Field.LateBindingApiWrapperType, new object[] { range, shortCitation, longCitation, longCitationAutoText, category });
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198045.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="shortCitation">string shortCitation</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Field MarkCitation(NetOffice.WordApi.Range range, string shortCitation)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Field>(this, "MarkCitation", NetOffice.WordApi.Field.LateBindingApiWrapperType, range, shortCitation);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198045.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="shortCitation">string shortCitation</param>
        /// <param name="longCitation">optional object longCitation</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Field MarkCitation(NetOffice.WordApi.Range range, string shortCitation, object longCitation)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Field>(this, "MarkCitation", NetOffice.WordApi.Field.LateBindingApiWrapperType, range, shortCitation, longCitation);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff198045.aspx </remarks>
        /// <param name="range">NetOffice.WordApi.Range range</param>
        /// <param name="shortCitation">string shortCitation</param>
        /// <param name="longCitation">optional object longCitation</param>
        /// <param name="longCitationAutoText">optional object longCitationAutoText</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public NetOffice.WordApi.Field MarkCitation(NetOffice.WordApi.Range range, string shortCitation, object longCitation, object longCitationAutoText)
        {
            return Factory.ExecuteKnownReferenceMethodGet<NetOffice.WordApi.Field>(this, "MarkCitation", NetOffice.WordApi.Field.LateBindingApiWrapperType, range, shortCitation, longCitation, longCitationAutoText);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196874.aspx </remarks>
        /// <param name="shortCitation">string shortCitation</param>
        /// <param name="longCitation">optional object longCitation</param>
        /// <param name="longCitationAutoText">optional object longCitationAutoText</param>
        /// <param name="category">optional object category</param>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void MarkAllCitations(string shortCitation, object longCitation, object longCitationAutoText, object category)
        {
            Factory.ExecuteMethod(this, "MarkAllCitations", shortCitation, longCitation, longCitationAutoText, category);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196874.aspx </remarks>
        /// <param name="shortCitation">string shortCitation</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void MarkAllCitations(string shortCitation)
        {
            Factory.ExecuteMethod(this, "MarkAllCitations", shortCitation);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196874.aspx </remarks>
        /// <param name="shortCitation">string shortCitation</param>
        /// <param name="longCitation">optional object longCitation</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void MarkAllCitations(string shortCitation, object longCitation)
        {
            Factory.ExecuteMethod(this, "MarkAllCitations", shortCitation, longCitation);
        }

        /// <summary>
        /// SupportByVersion Word 9, 10, 11, 12, 14, 15, 16
        /// </summary>
        /// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/office/ff196874.aspx </remarks>
        /// <param name="shortCitation">string shortCitation</param>
        /// <param name="longCitation">optional object longCitation</param>
        /// <param name="longCitationAutoText">optional object longCitationAutoText</param>
        [CustomMethod]
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public void MarkAllCitations(string shortCitation, object longCitation, object longCitationAutoText)
        {
            Factory.ExecuteMethod(this, "MarkAllCitations", shortCitation, longCitation, longCitationAutoText);
        }

        #endregion

        #region IEnumerableProvider<NetOffice.WordApi.TableOfAuthorities>

        ICOMObject IEnumerableProvider<NetOffice.WordApi.TableOfAuthorities>.GetComObjectEnumerator(ICOMObject parent)
        {
            return NetOffice.Utils.GetComObjectEnumeratorAsProperty(parent, this, false);
        }

        IEnumerable IEnumerableProvider<NetOffice.WordApi.TableOfAuthorities>.FetchVariantComObjectEnumerator(ICOMObject parent, ICOMObject enumerator)
        {
            return NetOffice.Utils.FetchVariantComObjectEnumerator(parent, enumerator, false);
        }

        #endregion

        #region IEnumerable<NetOffice.WordApi.TableOfAuthorities>

        /// <summary>
        /// SupportByVersion Word, 9,10,11,12,14,15,16
        /// </summary>
        [SupportByVersion("Word", 9, 10, 11, 12, 14, 15, 16)]
        public IEnumerator<NetOffice.WordApi.TableOfAuthorities> GetEnumerator()
        {
            NetRuntimeSystem.Collections.IEnumerable innerEnumerator = (this as NetRuntimeSystem.Collections.IEnumerable);
            foreach (NetOffice.WordApi.TableOfAuthorities item in innerEnumerator)
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