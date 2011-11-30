using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using YoutubeDesktop.Youtube.UriYoutube;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop.Youtube.Factory
{
    public class YoutubeFeedFactory : PagesFactory
    {

        public YoutubeFeedFactory(UriYoutubeFeed uri) : base(uri) { }

        public override int PageTot
        {
            get
            {
                YoutubeFeed feed = (YoutubeFeed)this[0];
                if (feed == null)
                    return 0;

                return (int)Math.Ceiling(((int)feed.TotalResults) / (((int)feed.ItemsPerPage) * 1.0));
            }
        }

    }
}
