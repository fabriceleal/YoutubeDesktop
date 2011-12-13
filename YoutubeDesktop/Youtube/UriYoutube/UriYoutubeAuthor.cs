using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class UriYoutubeAuthor : UriYoutubeBase
    {
        public UriYoutubeAuthor(String address) : base(address, ParamYoutube.Empty) { }
        public UriYoutubeAuthor(String address, ParamYoutube pars) : base(address, pars) { }

        public override RawYoutubeType DoQuery()
        {
            // TODO: Implement
            return null;
        }

        public override Factory.IFactory GetFactory()
        {
            // TODO: Implement
            return null;
        }

        public override IQueryUIObject GetUINavigatorObject()
        {
            // TODO: Implement
            return null;
        }

    }
}
