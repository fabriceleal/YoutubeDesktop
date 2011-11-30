using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]
    public class YoutubeEntry : RawYoutubeType, IQueryObject<YoutubeEntry>
    {
        public object FromJson(String json)
        {
            RootKey = "entry";
            Data = JavascriptUtils.DeserializeJson(json);

            return this;
        }

        private YoutubeEntry(string rootElem, object rawData) : base(rootElem, rawData) { }

        internal YoutubeEntry(object rawData) : base(rawData) { }


        public object Id { get { return this["id"].GetAsScalar(); } }

        public object Published { get { return this["published"].GetAsScalar(); } }

        public object Updated { get { return this["updated"].GetAsScalar(); } }

        public object Title { get { return this["title"].GetAsScalar(); } }

        public object Content { get { return this["content"].GetAsScalar(); } }

        [EditorAttribute(typeof(RawYoutubeTypeArrayDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeAuthor[] Author
        {
            get
            {
                object pointer = this["author"].Data;
                if (pointer == null)
                    return new YoutubeAuthor[] { };

                return ((object[])pointer)
                        .AsQueryable()
                        .Select(o => new YoutubeAuthor(o))
                        .ToArray();
                //---
            }
        }

        [EditorAttribute(typeof(RawYoutubeTypeArrayDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeCategory[] Category
        {
            get
            {
                return this["category"].GetAsArray()
                        .AsQueryable()
                        .Select(o => new YoutubeCategory(o))
                        .ToArray();
                //---
            }
        }

        [EditorAttribute(typeof(RawYoutubeTypeArrayDesigner), typeof(System.Drawing.Design.UITypeEditor))]
        public YoutubeLink[] Link
        {
            get
            {
                return this["link"].GetAsArray()
                    .AsQueryable()
                    .Select(o => new YoutubeLink(o))
                    .ToArray();
                //---
            }
        }

        [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeMediaGroup MediaGroup { get { return new YoutubeMediaGroup(this["media$group"].GetAsHash()); } }

        [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
        public YoutubeStatistics Statistics { get { return new YoutubeStatistics(this["yt$statistics"].GetAsHash()); } }

    }
}
