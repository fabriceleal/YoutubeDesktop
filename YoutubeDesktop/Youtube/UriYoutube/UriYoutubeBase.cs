using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;
using System.Web;

namespace YoutubeDesktop.Youtube.UriYoutube
{

    /// <summary>
    /// Base class for representing an object that maps to a resource in youtube.
    /// This object is a "temporary" representation of that resource: you can retrieve 
    /// that object by calling DoQuery(); 
    /// Each object will have a graphical representation in this application; 
    /// that representation can be retrieved by calling GetUINavigatorObject();
    /// this object will use a Factory for asking for resources; this factory implements
    /// functionality such as caching or paging, and can be retrieved by calling GetFactory()
    /// </summary>
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
