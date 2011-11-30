using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeFeed : RawYoutubeType, IQueryObject<YoutubeFeed>
    {
        public object FromJson(String json)
        {
            RootKey = "feed";
            Data = JavascriptUtils.DeserializeJson(json);

            return this;
        }

        private YoutubeFeed(string rootElem, object rawData) : base(rootElem, rawData) { }

        internal YoutubeFeed(object rawData) : base(rawData) { }
        
        public object Id { get { return this["id"].GetAsScalar(); } }

        public object Updated { get { return this["updated"].GetAsScalar(); } }

        public object Title { get { return this["title"].GetAsScalar(); } }

        [EditorAttribute(typeof(RawYoutubeTypeArrayDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeCategory[] Category
        {
            get {
                return this["category"].GetAsArray()
                        .AsQueryable()
                        .Select(o => new YoutubeCategory(o))
                        .ToArray();
                //---
        }
        }

        [EditorAttribute(typeof(RawYoutubeTypeArrayDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeEntry[] Entry
        {
            get
            {
                RawYoutubeType arr = this["entry"];
                if (arr == null)
                    return new YoutubeEntry[] { };
                
                object[] arr_o = arr.GetAsArray();
                if (arr_o == null)
                    return new YoutubeEntry[] { };

                return arr_o
                    .AsQueryable()
                    .Select(o => new YoutubeEntry(o))
                    .ToArray();
                //---
            }
        }

        [EditorAttribute(typeof(RawYoutubeTypeArrayDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeLink[] Link
        {
            get
            {
                RawYoutubeType arr = this["link"];
                if (arr == null)
                    return new YoutubeLink[] { };
                
                object[] arr_o = arr.GetAsArray();
                if (arr_o == null)
                    return new YoutubeLink[] { };

                return arr_o
                    .AsQueryable()
                    .Select(o => new YoutubeLink(o))
                    .ToArray();
            }
        }

        public object TotalResults { get { return this["openSearch$totalResults"].GetAsScalar(); } }

        public object StartIndex { get { return this["openSearch$startIndex"].GetAsScalar(); } }

        public object ItemsPerPage { get { return this["openSearch$itemsPerPage"].GetAsScalar(); } }

    }
}
