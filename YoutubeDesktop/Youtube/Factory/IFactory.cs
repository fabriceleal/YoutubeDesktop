using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop.Youtube.Factory
{
    public abstract class IFactory
    {        
        protected UriYoutubeBase _uri;

        public IFactory(UriYoutubeBase uri) { _uri = uri; }

        public abstract int CurrentIndex
        {
            get;
            set;
        }

        public abstract void Invalidate();

        public abstract RawYoutubeType this[int idx]
        {
            get;
        }
    }
}
