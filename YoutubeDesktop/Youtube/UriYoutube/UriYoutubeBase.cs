using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;
using System.Web;
using Google.GData.Client;

namespace YoutubeDesktop.Youtube.UriYoutube
{

    // Base Class
    public abstract class UriYoutubeBase
    {

        private Uri _uri;
        private ParamYoutube _pars;

        public UriYoutubeBase(String address) { _uri = new Uri(address); _pars = ParamYoutube.Empty; }

        public UriYoutubeBase(String address, ParamYoutube pars) { _uri = new Uri(address); _pars = pars; }


        public ParamYoutube Pars { get { return _pars; } set { _pars = value; } }


        public abstract RawYoutubeType DoQuery();

        public abstract IQueryUIObject GetUINavigatorObject();

        public abstract IFactory GetFactory();


        public override String ToString()
        {
            return GenerateUri().ToString();
        }

        public static implicit operator Uri(UriYoutubeBase obj)
        {
            return obj.GenerateUri();
        }


        public Uri BaseUri { get { return _uri; } }

        public Uri GenerateUri()
        {
            Uri baseUri = _uri;

            String queryString = "";
            if (_pars.Data != null && _pars.Data.Count > 0)
            {
                queryString = "?" + string.Join(
                        "&",
                        Array.ConvertAll(
                                _pars.Data.Keys.AsQueryable().Where(k => !string.IsNullOrEmpty(_pars.Data[k])).ToArray(),
                                key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(_pars.Data[key]))));
                //---
                //queryString = "/" + queryString;
            }

            Uri calc = new Uri(_uri.AbsoluteUri + queryString);
            return calc;
        }

        public static UriYoutubeBase FullUriToObject(Uri fullUri)
        {
            // TODO: ...
            return null;
        }

    }
}
