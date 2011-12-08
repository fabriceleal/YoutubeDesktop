using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void uriBuilderWithGo1_QueryAsked(object sender, UriBuilderWithGo.QueryAskedEventArgs e)
        {
            Assync<UriYoutubeBase>.Execute(
                    this,
                    () => { return e.uri; },
                    (uri) => { navigator1.QueryListener(this, new QueryAskedEventArgs(uri, true)); });
            // ---
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }
    }
}
