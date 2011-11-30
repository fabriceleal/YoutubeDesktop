using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeMediaThumbnail : RawYoutubeType
    {
        internal YoutubeMediaThumbnail(object rawData)
            : base(rawData)
        {
        }

        public object Url { get { return GetByKey("url"); } }

        public object Height { get { return GetByKey("height"); } }

        public object Width { get { return GetByKey("width"); } }

        public object Time { get { return GetByKey("time"); } }
    }
}
