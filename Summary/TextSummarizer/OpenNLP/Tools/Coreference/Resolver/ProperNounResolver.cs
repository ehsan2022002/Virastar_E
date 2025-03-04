//Copyright (C) 2006 Richard J. Northedge
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

//This file is based on the ProperNounResolver.java source file found in the
//original java implementation of OpenNLP.  That source file contains the following header:

//Copyright (C) 2003 Thomas Morton
//
//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.
//
//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU Lesser General Public License for more details.
//
//You should have received a copy of the GNU Lesser General Public
//License along with this program; if not, write to the Free Software
//Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System;
//UPGRADE_TODO: The type 'java.util.regex.Pattern' could not be found. If it was not included in the conversion, there may be compiler issues. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1262'"
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MentionContext = OpenNLP.Tools.Coreference.Mention.MentionContext;
namespace OpenNLP.Tools.Coreference.Resolver
{

    /// <summary> Resolves coreference between proper nouns.</summary>
    public class ProperNounResolver : MaximumEntropyResolver
    {

        //UPGRADE_NOTE: Final was removed from the declaration of 'initialCaps '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
        private static readonly Regex InitialCaps = new Regex("^[A-Z]", RegexOptions.Compiled);
        private static IDictionary _acroMap;
        private static bool _acroMapLoaded = false;

        public ProperNounResolver(string projectName, ResolverMode mode) : base(projectName, "pnmodel", mode, 500)
        {
            if (!_acroMapLoaded)
            {
                initAcronyms(projectName + "/acronyms");
                _acroMapLoaded = true;
            }
            ShowExclusions = false;
        }

        public ProperNounResolver(string projectName, ResolverMode mode, INonReferentialResolver nonReferentialResolver) : base(projectName, "pnmodel", mode, 500, nonReferentialResolver)
        {
            if (!_acroMapLoaded)
            {
                initAcronyms(projectName + "/acronyms");
                _acroMapLoaded = true;
            }
            ShowExclusions = false;
        }

        public override bool CanResolve(MentionContext mention)
        {
            return (PartsOfSpeech.IsProperNoun(mention.HeadTokenTag) || mention.HeadTokenTag.StartsWith(PartsOfSpeech.CardinalNumber));
        }

        private void initAcronyms(string name)
        {
            //UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
            _acroMap = new Hashtable(15000);
            try
            {
                StreamReader str;
                //if (MaxentResolver.loadAsResource())
                //{
                //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.io.BufferedReader.BufferedReader'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
                //UPGRADE_WARNING: At least one expression was used more than once in the target code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1181'"
                //UPGRADE_ISSUE: Method 'java.lang.Class.getResourceAsStream' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javalangClassgetResourceAsStream_javalangString'"
                //str = new System.IO.StreamReader(new System.IO.StreamReader(this.GetType().getResourceAsStream(name), System.Text.Encoding.Default).BaseStream, new System.IO.StreamReader(this.GetType().getResourceAsStream(name), System.Text.Encoding.Default).CurrentEncoding);
                //}
                //else
                //{
                //UPGRADE_TODO: The differences in the expected value  of parameters for constructor 'java.io.BufferedReader.BufferedReader'  may cause compilation errors.  "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1092'"
                //UPGRADE_WARNING: At least one expression was used more than once in the target code. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1181'"
                //UPGRADE_TODO: Constructor 'java.io.FileReader.FileReader' was converted to 'System.IO.StreamReader' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
                str = new StreamReader(new StreamReader(name, Encoding.Default).BaseStream, new StreamReader(name, Encoding.Default).CurrentEncoding);
                //}
                string line;
                while (null != (line = str.ReadLine()))
                {
                    var st = new Util.StringTokenizer(line, "\t");
                    string acro = st.NextToken();
                    string full = st.NextToken();
                    var exSet = (Util.Set<string>)_acroMap[acro];
                    if (exSet == null)
                    {
                        //UPGRADE_TODO: Class 'java.util.HashSet' was converted to 'SupportClass.HashSetSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashSet'"
                        exSet = new Util.HashSet<string>();
                        _acroMap[acro] = exSet;
                    }
                    exSet.Add(full);
                    exSet = (Util.Set<string>)_acroMap[full];
                    if (exSet == null)
                    {
                        //UPGRADE_TODO: Class 'java.util.HashSet' was converted to 'SupportClass.HashSetSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashSet'"
                        exSet = new Util.HashSet<string>();
                        _acroMap[full] = exSet;
                    }
                    exSet.Add(acro);
                }
            }
            catch (IOException e)
            {
                //UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.ToString' may return a different value. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1043'"
                Console.Error.WriteLine("ProperNounResolver.initAcronyms: Acronym Database not found: " + e);
            }
        }

        private MentionContext getProperNounExtent(DiscourseEntity de)
        {
            foreach (MentionContext xec in de.Mentions)
            {
                //use first extent which is propername
                string xecHeadTag = xec.HeadTokenTag;
                if (PartsOfSpeech.IsProperNoun(xecHeadTag) || InitialCaps.IsMatch(xec.HeadTokenText))
                {
                    return xec;
                }
            }
            return null;
        }


        private bool isAcronym(string ecStrip, string xecStrip)
        {
            var exSet = (Util.Set<string>)_acroMap[ecStrip];
            if (exSet != null && exSet.Contains(xecStrip))
            {
                return true;
            }
            return false;
        }

        protected internal virtual List<string> getAcronymFeatures(MentionContext mention, DiscourseEntity entity)
        {
            MentionContext xec = getProperNounExtent(entity);
            string ecStrip = StripNounPhrase(mention);
            string xecStrip = StripNounPhrase(xec);
            if (ecStrip != null && xecStrip != null)
            {
                if (isAcronym(ecStrip, xecStrip))
                {
                    var features = new List<string>(1) { "knownAcronym" };
                    return features;
                }
            }
            return new List<string>();
        }

        protected internal override List<string> GetFeatures(MentionContext mention, DiscourseEntity entity)
        {
            List<string> features = base.GetFeatures(mention, entity);

            if (entity != null)
            {
                features.AddRange(GetStringMatchFeatures(mention, entity));
                features.AddRange(getAcronymFeatures(mention, entity));
            }
            return features;
        }

        protected internal override bool IsExcluded(MentionContext mention, DiscourseEntity entity)
        {
            if (base.IsExcluded(mention, entity))
            {
                return true;
            }

            foreach (MentionContext xec in entity.Mentions)
            {
                if (PartsOfSpeech.IsProperNoun(xec.HeadTokenTag))
                {
                    // || initialCaps.matcher(xec.headToken.ToString()).find()) {
                    return false;
                }
            }
            return true;
        }
    }
}