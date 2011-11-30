using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public class PlaylistVideoAdd : PlaylistOperation
    {
        private string _videoId;
        private int _position;

        public PlaylistVideoAdd(int position, string videoId, string playlistId) :
            base(YoutubeWeb.WebMethod.POST,
            new Uri(String.Format("https://gdata.youtube.com/feeds/api/playlists/{0}", playlistId)),
            true)
        {
            _videoId = videoId;
            _position = position;
        }

        public override System.Xml.XmlDocument GetData()
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("id", _videoId);
            if (_position > 0)
            {
                tags.Add("yt:position", _position.ToString());
            }            
            return base.GetData(tags, null);
        }
    }
}
