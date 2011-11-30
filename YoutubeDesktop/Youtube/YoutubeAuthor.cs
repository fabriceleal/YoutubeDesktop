﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using YoutubeDesktop.Youtube.DesignerEditors;

namespace YoutubeDesktop.Youtube
{
    [EditorAttribute(typeof(RawYoutubeTypeDesigner), typeof(System.Drawing.Design.UITypeEditor))]  
    public class YoutubeAuthor : RawYoutubeType
    {
        internal YoutubeAuthor(object rawData)
            : base(rawData)
        {
        }

        public object Name { get { return GetAsScalar("name"); } }

        public object Uri { get { return GetAsScalar("uri"); } }
    }
}
