using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.PlaylistOperations;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{
    public class YoutubeVideoInPlaylist : YoutubeVideo
    {
        private YoutubeUserPlaylist _playlist;

        public YoutubeVideoInPlaylist(string videoId, YoutubeUserPlaylist playlist, YoutubeEntry raw) : base(videoId, raw) {
            _playlist = playlist;
        }

        [AttributeMethodCtx("Remove from this Playlist")]
        public object RemoveFromPlaylist()
        {
            PlaylistVideoRemove action = new PlaylistVideoRemove(Id, _playlist.Id);

            return action.Execute();
        }

        [AttributeMethodCtx("Change video position")]
        public object ChangeVideoPosition(int newPosition)
        {
            PlaylistVideoEdit action = new PlaylistVideoEdit(newPosition, Id, _playlist.Id);

            return action.Execute();
        }


    }
}
