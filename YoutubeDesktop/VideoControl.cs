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
    public partial class VideoControl : UserControl, IQueryUIObject
    {
        public event DelegateLinkClicked LinkClicked;

        public VideoControl()
        {
            InitializeComponent();
        }

        public void Inject(IFactory theObject)
        {
            
        }
    }
}
