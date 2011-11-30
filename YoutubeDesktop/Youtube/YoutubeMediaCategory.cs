using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeMediaCategory : RawYoutubeType
    {
        internal YoutubeMediaCategory(object rawData)
            : base(rawData)
        {
        }

        public object Root { get { return GetAsScalar(); } }

        public object Label { get { return GetByKey("label"); } }

        public object Scheme { get { return GetByKey("scheme"); } }
    }
}
