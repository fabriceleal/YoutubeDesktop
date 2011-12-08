using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{
    public partial class UriBuilderWithGo : UriBuilder
    {
        public class QueryAskedEventArgs : EventArgs
        {
            public UriYoutubeBase uri;
        }

        public delegate void DelegateQueryAsked(object sender, QueryAskedEventArgs e);
        public event DelegateQueryAsked QueryAsked;
        

        public UriBuilderWithGo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QueryAsked != null)
            {
                var arg = new QueryAskedEventArgs();
                arg.uri = getUrl();
                QueryAsked(this, arg);
            }
        }
    }
}
