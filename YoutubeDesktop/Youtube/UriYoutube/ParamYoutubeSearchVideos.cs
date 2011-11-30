using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class ParamYoutubeSearchVideos : ParamYoutubePageable
    {       
        public enum OrderBy
        {
            relevance,
            viewCount,
            rating
        }

        public ParamYoutubeSearchVideos(String query, OrderBy orderBy, int startIndex, int maxResults)
            : base(startIndex, maxResults)
        {
            Data["q"] = query;
            Data["orderby"] = orderBy.ToString();
        }

    }
}
