using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{
    // Object should also throw Navigation intents, 
    // that should be handled by the navigation pane

    // Methods that return object and have no parameters
    // Will be harvested and used to fill ContextMenus
    // Extra parameters will be filled by hand

    public class YoutubeUserPlaylist : YoutubePlaylist
    {

        public YoutubeUserPlaylist(string playlistId, YoutubeFeed raw) : base(playlistId, raw) { }

    }
}
