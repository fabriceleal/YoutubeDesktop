using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class ParamYoutubePageable : ParamYoutube
    {
        public enum STANDARD_FEED_TIME { 
            all_time,
            today,
            this_week,
            this_month
        }

        public ParamYoutubePageable(int startIndex, int maxResults, STANDARD_FEED_TIME time = STANDARD_FEED_TIME.all_time) : base()
        {
            Data["start-index"] = startIndex.ToString();
            Data["max-results"] = maxResults.ToString();
            Data["time"] = time.ToString();
        }

    }
}
