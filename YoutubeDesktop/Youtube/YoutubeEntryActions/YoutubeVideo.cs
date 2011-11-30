using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.PlaylistOperations;
using System.Windows.Forms;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{
    // Object should also throw Navigation intents, 
    // that should be handled by the navigation pane

    // Methods that return object and have no parameters / one parameter of type YoutubePlaylist
    // Will be harvested and used to fill ContextMenus
    // Extra parameters will be filled by hand

    public class YoutubeVideo : YoutubeObject
    {

        public YoutubeVideo(string videoId, YoutubeEntry raw) : base(videoId, raw) { }

        // ******* Generic youtube video actions *************

        public object AddToPlaylist(YoutubePlaylist pl)
        {
            PlaylistVideoAdd action = new PlaylistVideoAdd(-1, Id, pl.Id);

            return action.Execute();
        }


        public object CopyUrlToClipboard()
        {
            Clipboard.SetText((string)((YoutubeEntry)Raw).MediaGroup.Player[0].Url, TextDataFormat.Text);
            return true;
        }

    }
}
