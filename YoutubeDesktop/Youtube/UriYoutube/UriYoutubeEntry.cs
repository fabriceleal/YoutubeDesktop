using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop.Youtube.UriYoutube
{
    public class UriYoutubeEntry : UriYoutubeBase
    {
        public UriYoutubeEntry(String address) : base(address, ParamYoutube.Empty) { }
        public UriYoutubeEntry(String address, ParamYoutube pars) : base(address, pars) { }

        public override RawYoutubeType DoQuery()
        {
            YoutubeEntry empty = new YoutubeEntry(null);
            return (RawYoutubeType)empty.FromJson(            
                    YoutubeWeb.CallApiMethod(
                        YoutubeWeb.WebMethod.GET,
                        this,
                        null, false, YoutubeWeb.Data.Empty));
            //---
        }

        public override Factory.IFactory GetFactory()
        {
            if (this.BaseUri.LocalPath.StartsWith("/feeds/api/videos/"))
            {
                // Is a video
                return new SimpleFactory(this);
            }
            else if (this.BaseUri.LocalPath.StartsWith("/feeds/api/playlists/"))
            {
                // Is a playlist
                ParamYoutubeSearchVideos newPars = new ParamYoutubeSearchVideos(
                        "", ParamYoutubeSearchVideos.OrderBy.relevance, 
                        1, 10);
                //---
                Array.ForEach(
                        Pars.Data.Keys.ToArray(),
                        delegate(string key)
                        {
                            if (newPars.Data.ContainsKey(key))
                            {
                                newPars.Data[key] = Pars.Data[key];
                            }
                            else
                            {
                                newPars.Data.Add(key, Pars.Data[key]);
                            }

                        });
                //---
                return new PagesFactory(this);
            }
            return null;
        }

        public override IQueryUIObject GetUINavigatorObject()
        {
            if (this.BaseUri.LocalPath.StartsWith("/feeds/api/videos/"))
            {
                // Is a video
                return new VideoControl();
            }
            else if (this.BaseUri.LocalPath.StartsWith("/feeds/api/playlists/"))
            {
                // Is a playlist
                return new PlaylistControl();
            }
            return null;
        }

    }
}
