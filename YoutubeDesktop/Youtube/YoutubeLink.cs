using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeLink : RawYoutubeType
    {
        internal YoutubeLink(object rawData)
            : base(rawData)
        {
        }

        public object Rel { get { return GetByKey("rel"); } }

        public object Type { get { return GetByKey("type"); } }

        public object Href { get { return GetByKey("href"); } }
    }
}
