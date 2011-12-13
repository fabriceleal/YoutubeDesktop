using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{

    public class AttributeMethodCtx : Attribute
    {

        public string Label;

        public AttributeMethodCtx(string label)
        {
            this.Label = label;
        }

    }
}
