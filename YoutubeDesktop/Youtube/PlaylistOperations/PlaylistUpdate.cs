using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public class PlaylistUpdate : PlaylistHeaderOperation
    {
        public PlaylistUpdate(
            string title, string summary, bool isPublic,
            string username, string playlistId)
            : base(title, summary, isPublic,
            new Uri(String.Format("https://gdata.youtube.com/feeds/api/users/{0}/playlists/{1}", username, playlistId)))
        { }
    }
}
