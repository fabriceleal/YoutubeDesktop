using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public class PlaylistCreate : PlaylistHeaderOperation
    {
        public PlaylistCreate(string title, string summary, bool isPublic)
            : base(title, summary, isPublic, new Uri("https://gdata.youtube.com/feeds/api/users/default/playlists"))
        { }
    }
}
