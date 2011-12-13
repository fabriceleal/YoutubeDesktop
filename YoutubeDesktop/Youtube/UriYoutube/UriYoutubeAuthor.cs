using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class UriYoutubeAuthor : UriYoutubeBase
    {
        public UriYoutubeAuthor(String address) : base(address, ParamYoutube.Empty) { }
        public UriYoutubeAuthor(String address, ParamYoutube pars) : base(address, pars) { }

        public override RawYoutubeType DoQuery()
        {
            YoutubeAuthor empty = new YoutubeAuthor(null);
            return (RawYoutubeType)empty.FromJson(
                    YoutubeWeb.CallApiMethod(
                        YoutubeWeb.WebMethod.GET,
                        this,
                        null, false, YoutubeWeb.Data.Empty));
            //---
        }

        public override Factory.IFactory GetFactory()
        {
            return new SimpleFactory(this);
        }

        public override IQueryUIObject GetUINavigatorObject()
        {
            return (IQueryUIObject)(new AuthorControl());
        }

    }
}
