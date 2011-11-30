using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public class PlaylistVideoEdit : PlaylistOperation
    {
        private int _position;

        public PlaylistVideoEdit(int position, string playlistEntryId, string playlistId) :
            base(YoutubeWeb.WebMethod.POST,
            new Uri(String.Format("https://gdata.youtube.com/feeds/api/playlists/{0}/{1}", playlistId, playlistEntryId)),
            true)
        {
            _position = position;
        }

        public override System.Xml.XmlDocument GetData()
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("yt:position", _position.ToString());
            return base.GetData(tags, null);
        }
    }
}
