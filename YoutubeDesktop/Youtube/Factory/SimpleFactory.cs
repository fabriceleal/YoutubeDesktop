using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop.Youtube.Factory
{
    public class SimpleFactory : IFactory
    {
        private RawYoutubeType _obj = null;
        // Provides a simple wrapper to a RawYoutubeType object
        public int PageTot
        {
            get { return 1; }
        }

        public SimpleFactory(UriYoutubeBase uri) : base(uri) { }

        public SimpleFactory(RawYoutubeType obj) : base(null) {
            _obj = obj;
        }

        public override int CurrentIndex { get { return 0; } set { /*Ignore*/ } }

        public override RawYoutubeType this[int idx]
        {
            get
            {
                if (_obj != null)
                    return _obj;

                _obj = _uri.DoQuery();                
                return _obj;
            }
        }

        public override void Invalidate()
        {
            if (_uri == null)
                return;
            _obj = null;
        }
    
    }
}
