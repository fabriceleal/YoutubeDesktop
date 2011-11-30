using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public class PlaylistVideoRemove : PlaylistOperation
    {

        public PlaylistVideoRemove(string playlistEntryId, string playlistId) :
            base(YoutubeWeb.WebMethod.DELETE,
            new Uri(String.Format("https://gdata.youtube.com/feeds/api/playlists/{0}/{1}", playlistId, playlistEntryId)),
            true) { }

        public override XmlDocument GetData() { return null; }
    }
}
