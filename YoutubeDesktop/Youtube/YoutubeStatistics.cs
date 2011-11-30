using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeStatistics : RawYoutubeType
    {
        internal YoutubeStatistics(object rawData) : base(rawData) { }

        public object FavoriteCount { get { return GetByKey("favoriteCount"); } }

        public object ViewCount { get { return GetByKey("viewCount"); } }

    }
}
