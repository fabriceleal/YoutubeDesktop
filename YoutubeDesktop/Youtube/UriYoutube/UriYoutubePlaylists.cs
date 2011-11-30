using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class UriYoutubePlaylists: UriYoutubeFeed
    {
        public UriYoutubePlaylists(String address) : base(address) { }
        public UriYoutubePlaylists(String address, ParamYoutube arg) : base(address, arg) { }

        public override RawYoutubeType DoQuery()
        {
            String json= YoutubeWeb.CallApiMethod(YoutubeWeb.WebMethod.GET, this, null, true, YoutubeWeb.Data.Empty);

            YoutubeFeed empty = new YoutubeFeed(null);
            return (RawYoutubeType)empty.FromJson(json);
        }
    }
}
