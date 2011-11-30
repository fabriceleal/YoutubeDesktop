using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{

    public abstract class PlaylistHeaderOperation : PlaylistOperation
    {
        private string _title;
        private string _summary;
        private bool _isPublic;

        public PlaylistHeaderOperation(
                string title,
                string summary,
                bool isPublic,
                Uri uri
            )
            : base(
                YoutubeWeb.WebMethod.POST,
                uri, true)
        //---
        {
            _title = title;
            _summary = summary;
            _isPublic = isPublic;
        }

        public override XmlDocument GetData()
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, string>> atts = new Dictionary<string, Dictionary<string, string>>();

            tags.Add("title", _title);
            tags.Add("summary", _summary);

            Dictionary<string, string> atTitle = new Dictionary<string,string>();
            atTitle.Add("type", "text");
            atts.Add("title", atTitle);

            return base.GetData(tags, atts);
        }
    }
}
