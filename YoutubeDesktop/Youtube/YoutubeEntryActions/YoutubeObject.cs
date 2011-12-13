using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{
    // Object should also throw Navigation intents, 
    // that should be handled by the navigation pane

    // Methods that return object and have no parameters
    // Will be harvested and used to fill ContextMenus
    // Extra parameters will be filled by hand

    public abstract class YoutubeObject
    {
        private string _id;
        private RawYoutubeType _raw;

        public string Id { get { return _id; } }
        public RawYoutubeType Raw { get { return _raw; } }

        public YoutubeObject(string id, RawYoutubeType raw) { _id = id; _raw = raw; }


        [AttributeMethodCtx("Open Object")]
        public object OpenObject()
        {
            (new GridObject(Raw)).ShowDialog();
            return true;
        }

    }

}
