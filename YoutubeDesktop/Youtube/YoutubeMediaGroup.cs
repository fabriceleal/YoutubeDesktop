using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]
    public class YoutubeMediaGroup : RawYoutubeType
    {
        internal YoutubeMediaGroup(object rawData) : base(rawData) { }

        public YoutubeMediaCategory[] MediaCategory
        {
            get
            {
                return GetAsArray("media$category").AsQueryable().Select(o => new YoutubeMediaCategory(o)).ToArray();
            }
        }

        public YoutubeMediaContent[] MediaContent
        {
            get
            {
                object[] arr = GetAsArray("media$content");
                if (arr == null)
                    return new YoutubeMediaContent[] {  };

                return arr.AsQueryable().Select(o => new YoutubeMediaContent(o)).ToArray();
            }
        }

        public YoutubeMediaThumbnail[] MediaThumbnail
        {
            get
            {
                return GetAsArray("media$thumbnail").AsQueryable().Select(o => new YoutubeMediaThumbnail(o)).ToArray();
            }
        }

        public object Description { get { return GetAsScalar("media$description"); } }

        public object Keywords { get { return GetAsScalar("media$keywords"); } }

        public YoutubeMediaGroupPlayer[] Player
        {
            get
            {
                return this["media$player"].GetAsHash()
                    .AsQueryable()
                    .Select(o => new YoutubeMediaGroupPlayer(o))
                    .ToArray();
                //---
            }
        }

        public object Title { get { return GetAsScalar("media$title"); } }

        public object Duration { get { return this["yt$duration"].GetByKey("seconds"); } }

    }
}
