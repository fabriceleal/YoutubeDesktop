using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class UriYoutubeFeed : UriYoutubeBase
    {
        public UriYoutubeFeed(String address) : base(address, ParamYoutube.Empty) { }
        public UriYoutubeFeed(String address, ParamYoutube arg) : base(address, arg) { }

        public override RawYoutubeType DoQuery()
        {
            YoutubeFeed empty = new YoutubeFeed(null);
            return (RawYoutubeType)empty.FromJson(
                    YoutubeWeb.CallApiMethod(
                        YoutubeWeb.WebMethod.GET,
                        this,
                        null, false, YoutubeWeb.Data.Empty));
            //---
        }

        public override IFactory GetFactory()
        {
            return new YoutubeFeedFactory(this);
        }

        public override IQueryUIObject GetUINavigatorObject()
        {
            return (IQueryUIObject)(new FeedControl());
        }

    }
}
