using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace YoutubeDesktop.Youtube.PlaylistOperations
{
    public abstract class PlaylistOperation
    {
        private YoutubeWeb.WebMethod _method;
        private Uri _uri;
        private bool _needsKey;

        public PlaylistOperation(
                YoutubeWeb.WebMethod method
                , Uri uri
                , bool needsKey
            )
        {
            _method = method;
            _uri = uri;
            _needsKey = needsKey;
        }

        public abstract XmlDocument GetData();

        protected XmlDocument GetData(
                Dictionary<string, string> innerTags,
                Dictionary<string, Dictionary<string, string>> attributes)
        {
            XmlDocument doc = new XmlDocument();

            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));

            // Root *****
            XmlNode root = doc.CreateNode(XmlNodeType.Element, "entry", "");

            XmlAttribute xmlnsAtt = doc.CreateAttribute("xmlns");
            xmlnsAtt.InnerText = "http://www.w3.org/2005/Atom";

            XmlAttribute xmlnsYtAtt = doc.CreateAttribute("xmlns:yt");
            xmlnsYtAtt.InnerText = "http://gdata.youtube.com/schemas/2007";

            root.Attributes.Append(xmlnsAtt);
            root.Attributes.Append(xmlnsYtAtt);

            // *********

            if (innerTags == null)
                innerTags = new Dictionary<string, string>();
            if (attributes == null)
                attributes = new Dictionary<string, Dictionary<string, string>>();

            foreach (String key in innerTags.Keys)
            {
                XmlNode nNode = doc.CreateElement(key);
                nNode.InnerText = innerTags[key];

                if (attributes.ContainsKey(key) && attributes[key] != null)
                {
                    foreach (String aKey in attributes[key].Keys)
                    {
                        XmlAttribute attr = doc.CreateAttribute(aKey);
                        attr.InnerText = attributes[key][aKey];
                        nNode.Attributes.Append(attr);
                    }
                }

                root.AppendChild(nNode);
            }

            doc.AppendChild(root);

            return doc;
        }

        public bool Execute()
        {
            XmlDocument data = GetData();
            String compiledData = "";
            if (data != null)
            {
                StringBuilder sb = new StringBuilder();
                XmlWriter wr = XmlWriter.Create(sb);
                data.WriteTo(wr);
                compiledData = sb.ToString();
            }

            Dictionary<string, string> extraHdrs = new Dictionary<string, string>();

            extraHdrs.Add("Content-Type", "application/atom+xml");

            YoutubeWeb.CallApiMethod(
                    _method, _uri, extraHdrs,
                    _needsKey, new YoutubeWeb.Data(compiledData, !String.IsNullOrEmpty(compiledData)));
            //---

            return true;
        }
    }
}
