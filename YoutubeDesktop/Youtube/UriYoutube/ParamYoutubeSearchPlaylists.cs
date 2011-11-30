using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class ParamYoutubeSearchPlaylists : ParamYoutubePageable
    {
        public enum OrderBy
        {
            position,
            commentCount,
            duration,
            published,
            title,
            viewCount
        }

        public ParamYoutubeSearchPlaylists(String query, OrderBy orderBy, int startIndex, int maxResults)
            : base(startIndex, maxResults)
        {
            Data["q"] = query;
            Data["orderby"] = orderBy.ToString();
        }

    }
}
