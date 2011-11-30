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


        public object AddToPlaylistWithPosition(int position)
        {
            PlaylistVideoAdd action = new PlaylistVideoAdd(position, Id, _playlist.Id);

            return action.Execute();
        }

        public object RemoveFromPlaylist()
        {
            PlaylistVideoRemove action = new PlaylistVideoRemove(Id, _playlist.Id);

            return action.Execute();
        }

        public object ChangeVideoPosition(int newPosition)
        {
            PlaylistVideoEdit action = new PlaylistVideoEdit(newPosition, Id, _playlist.Id);

            return action.Execute();
        }


    }
}
