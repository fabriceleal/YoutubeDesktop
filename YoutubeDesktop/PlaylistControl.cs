using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDesktop.Youtube;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop
{
    public partial class PlaylistControl : FeedControl, IQueryUIObject
    {
        //public event DelegateLinkClicked LinkClicked;

        public PlaylistControl()
        {
            InitializeComponent();
        }

        public new void Inject(IFactory theObject)
        {
            base.Inject(theObject);
        }
    }
}
