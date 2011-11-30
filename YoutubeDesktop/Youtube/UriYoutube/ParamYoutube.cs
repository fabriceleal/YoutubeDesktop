using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class ParamYoutube
    {
        public Dictionary<string, string> Data = new Dictionary<string, string>();

        public static ParamYoutube Empty { get { return new ParamYoutube(); } }

        public ParamYoutube()
        {
            Data["alt"] = "json";
            Data["strict"] = false.ToString();
            Data["v"] = "2.1";

            //Data["access_token"] = (string)YoutubeWeb.pars["access_token"];
            //Data["key"] = Globals.DevKey;
        }
    }
}
