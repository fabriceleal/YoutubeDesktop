using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop.Youtube
{
    public delegate void DelegateLinkClicked(object sender, QueryAskedEventArgs e);

    // Para objectos da UI que carregam objectos Youtube
    public interface IQueryUIObject
    {
        event DelegateLinkClicked LinkClicked;

        void Inject(IFactory theObject);
    }


    // Para objectos carregáveis a partir de Json
    public interface IQueryObject<T> where T : RawYoutubeType
    {
        object FromJson(String json);
    }

}
