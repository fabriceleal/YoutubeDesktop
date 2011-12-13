using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{
    // Object should also throw Navigation intents, 
    // that should be handled by the navigation pane

    // Methods that return object and have no parameters
    // Will be harvested and used to fill ContextMenus
    // Extra parameters will be filled by hand

    public class YoutubePlaylist : YoutubeObject
    {
        
        public YoutubePlaylist(string playlistId, YoutubeFeed raw) : base(playlistId, raw) { }

        [AttributeMethodCtx("Copy Url to Clipboard")]
        public object CopyUrlToClipboard()
        {            
            MessageBox.Show("Doooooh!!! >:(");
            return null;
        }

    }

}
