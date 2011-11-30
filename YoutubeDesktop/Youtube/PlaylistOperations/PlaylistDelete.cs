using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public class PlaylistDelete : PlaylistOperation
    {

        public PlaylistDelete(string username, string playlistId) :
            base(YoutubeWeb.WebMethod.DELETE,
            new Uri(String.Format("https://gdata.youtube.com/feeds/api/{0}/playlists/{1}", username, playlistId)),
            true) { }

        public override XmlDocument GetData() { return null; }

    }
}
