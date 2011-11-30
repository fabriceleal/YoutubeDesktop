using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{
    public class YoutubeUris
    {

        public enum STANDARD_FEED_TYPE { 
            most_viewed,
            top_rated,
            recently_featured,
            watch_on_mobile,
            most_discussed,
            top_favorites,
            most_responded,
            most_recent
        }

        public static UriYoutubeFeed GetStandardFeed(
                    STANDARD_FEED_TYPE type, 
                    YoutubeDesktop.Youtube.UriYoutube.ParamYoutubePageable.STANDARD_FEED_TIME time = YoutubeDesktop.Youtube.UriYoutube.ParamYoutubePageable.STANDARD_FEED_TIME.all_time) {
            //---
            ParamYoutubeSearchVideos arg = new ParamYoutubeSearchVideos("", ParamYoutubeSearchVideos.OrderBy.relevance, 1, 10);
            arg.Data["time"] = time.ToString();

            return new UriYoutubeFeed(String.Format("http://gdata.youtube.com/feeds/api/standardfeeds/{0}", type), arg);
        }


        public enum STANDARD_FEED_REGION { 
            none,
            /// <summary>
            /// Argentina
            /// </summary>
            AR,
            /// <summary>
            /// Australia
            /// </summary>
            AU,
            /// <summary>
            /// Brazil
            /// </summary>
            BR,
            /// <summary>
            /// Canada
            /// </summary>
            CA,
            /// <summary>
            /// Czech Republic
            /// </summary>
            CZ,
            /// <summary>
            /// France
            /// </summary>
            FR,
            /// <summary>
            /// Germany
            /// </summary>
            DE,
            /// <summary>
            /// Great Britain
            /// </summary>
            GB,
            /// <summary>
            /// Hong Kong
            /// </summary>
            HK,
            /// <summary>
            /// India
            /// </summary>
            IN,
            /// <summary>
            /// Ireland
            /// </summary>
            IE,
            /// <summary>
            /// Israel
            /// </summary>
            IL,
            /// <summary>
            /// Italy
            /// </summary>
            IT,
            /// <summary>
            /// Japan
            /// </summary>
            JP,
            /// <summary>
            /// Mexico
            /// </summary>
            MX,
            /// <summary>
            /// Netherlands
            /// </summary>
            NL,
            /// <summary>
            /// New Zealand
            /// </summary>
            NZ,
            /// <summary>
            /// Poland
            /// </summary>
            PL,
            /// <summary>
            /// Russia
            /// </summary>
            RU,
            /// <summary>
            /// South Africa
            /// </summary>
            ZA,
            /// <summary>
            /// South Korea
            /// </summary>
            KR,
            /// <summary>
            /// Spain
            /// </summary>
            ES,
            /// <summary>
            /// Sweden
            /// </summary>
            SE,
            /// <summary>
            /// Taiwan
            /// </summary>
            TW,
            /// <summary>
            /// United States
            /// </summary>
            US
        }

        public enum STANDARD_FEED_CATEGORY
        {
            none,
            Film,
            Autos,
            Music,
            Animals,
            Sports,
            Travel,
            Shortmov,
            Videoblog,
            Games,
            Comedy,
            People,
            News,
            Entertainment,
            Education,
            Howto,
            Nonprofit,
            Tech,
            Movies_Anime_animation,
            Movies,
            Movies_Comedy,
            Movies_Documentary,
            Movies_Action_adventure,
            Movies_Classics,
            Movies_Foreign,
            Movies_Horror,
            Movies_Drama,
            Movies_Family,
            Movies_Shorts,
            Shoes,
            Movies_Sci_fi_fantasy,
            Movies_Thriller,
            Trailers
        }

        public static UriYoutubeFeed GetStandardFeed(
                STANDARD_FEED_REGION region, 
                STANDARD_FEED_TYPE type,
                STANDARD_FEED_CATEGORY category, 
                YoutubeDesktop.Youtube.UriYoutube.ParamYoutubePageable.STANDARD_FEED_TIME time = 
                    YoutubeDesktop.Youtube.UriYoutube.ParamYoutubePageable.STANDARD_FEED_TIME.all_time)
        {
            object[] args = new object[] { region, type, category };
            string format = "http://gdata.youtube.com/feeds/api/standardfeeds";

            if (region != STANDARD_FEED_REGION.none)
            {
                format += @"/{0}";
            }

            if (category == STANDARD_FEED_CATEGORY.none)
            {
                format += @"/{1}";
            }
            else
            {
                format += @"/{1}_{2}";
            }
            
            ParamYoutubeSearchVideos par = new ParamYoutubeSearchVideos(
                    "",
                    ParamYoutubeSearchVideos.OrderBy.relevance,
                    1, 10);
            //---
            if (time != YoutubeDesktop.Youtube.UriYoutube.ParamYoutubePageable.STANDARD_FEED_TIME.all_time)
                par.Data["time"] = time.ToString();
            
            return new UriYoutubeFeed(
                    string.Format(format, args), par);
            //---
        }


        public static UriYoutubeEntry GetVideo(String videoId)
        {            
            return new UriYoutubeEntry(
                    String.Format("http://gdata.youtube.com/feeds/api/videos/{0}", videoId));
        }

        public static UriYoutubeFeed GetPlaylist(String playlistId)
        {
            return new UriYoutubeFeed(
                    String.Format("http://gdata.youtube.com/feeds/api/playlists/{0}", 
                    playlistId));
        }

        public static UriYoutubePlaylists GetPlaylists(String username)
        {
            if (String.IsNullOrEmpty(username))
                username = "default";

            ParamYoutubeSearchVideos parm = new ParamYoutubeSearchVideos("", ParamYoutubeSearchVideos.OrderBy.relevance, 1, 10);

            return new UriYoutubePlaylists(
                    string.Format("https://gdata.youtube.com/feeds/api/users/{0}/playlists", username), parm);
            //---
        }

        public static UriYoutubeFeed GetFavorites(String username)
        {
            if (String.IsNullOrEmpty(username))
                username = "default";

            return new UriYoutubeFeed(
                    String.Format("https://gdata.youtube.com/feeds/api/users/{0}/favorites",
                    username));
            //---
        }

        // Video feed (query)
        // http://gdata.youtube.com/feeds/api/videos?q={qwe}
        
        // Related
        // https://gdata.youtube.com/feeds/api/videos/{ID}/related

        // Responses
        // http://gdata.youtube.com/feeds/api/videos/{ID}/responses

        // User's subscriptions
        // https://gdata.youtube.com/feeds/api/users/{user}/subscriptions

        // User profile
        // http://gdata.youtube.com/feeds/api/users/{username}
        
        // USer contacts
        // https://gdata.youtube.com/feeds/api/users/{username}/contacts

    }
}
