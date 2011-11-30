using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeMediaContent : RawYoutubeType
    {

        internal YoutubeMediaContent(object rawData)
            : base(rawData)
        {

        }

        public object Url { get { return GetByKey("url"); } }

        public object Type { get { return GetByKey("type"); } }

        public object Medium { get { return GetByKey("medium"); } }

        public object IsDefault { get { return GetByKey("isDefault"); } }

        public object Expression { get { return GetByKey("expression"); } }

        public object Duration { get { return GetByKey("duration"); } }

        public object Format { get { return GetByKey("yt$format"); } }
    }
}
