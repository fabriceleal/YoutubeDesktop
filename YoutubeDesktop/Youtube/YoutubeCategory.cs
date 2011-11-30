using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeCategory : RawYoutubeType
    {
        internal YoutubeCategory(object data)
            : base(data)
        {

        }

        public object Scheme { get { return GetByKey("scheme"); } }

        public object Term { get { return GetByKey("term"); } }

        public object Label { get { return GetByKey("label"); } }

    }
}
