using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop.Youtube.Factory
{
    public class PagesFactory : IFactory
    {

        // Provides access to a object 
        // with multiple pages
        protected Dictionary<int, RawYoutubeType> _list = new Dictionary<int, RawYoutubeType>();
        protected int _currentIdx;


        public virtual int PageTot
        {
            get { return 1; }
        }

        public PagesFactory(UriYoutubeBase uri) : base(uri) { }

        public override int CurrentIndex { get { return _currentIdx; } set { _currentIdx = value; } }

        public override void Invalidate()
        {
            _list.Clear();
        }

        public override RawYoutubeType this[int idx]
        {
            get
            {
                if (_list.ContainsKey(idx))
                {
                    return _list[idx];
                }

                UriYoutubeBase copy = _uri;

                // TODO: Do extra stuff for pages **here**
                ParamYoutube par = copy.Pars;
                if (par.Data.ContainsKey("max-results"))
                {
                    if (par.Data.ContainsKey("start-index"))
                    {
                        par.Data["start-index"] = ((idx * int.Parse(par.Data["max-results"])) + 1).ToString();
                    }
                    else
                    {
                        par.Data.Add("start-index", ((idx * int.Parse(par.Data["max-results"])) + 1).ToString());
                    }
                }
                                

                RawYoutubeType newItem = (RawYoutubeType)copy.DoQuery();
                _list.Add(idx, newItem);
                _currentIdx = idx;

                return newItem;
            }
        }

    }
}
