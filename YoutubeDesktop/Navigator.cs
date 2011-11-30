using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDesktop.Youtube;
using YoutubeDesktop.Youtube.UriYoutube;
using YoutubeDesktop.Youtube.Factory;

namespace YoutubeDesktop
{
    public partial class Navigator : UserControl
    {

        public Navigator()
        {
            InitializeComponent();
        }

        public void QueryListener(object sender, QueryAskedEventArgs e)
        {
            try
            {
                UriYoutubeBase uri = e.uri;
                IQueryUIObject obj = uri.GetUINavigatorObject();
                IFactory fac = uri.GetFactory();

                if (obj == null)
                    throw new Exception("No UI object.");

                if (fac == null)
                    throw new Exception("No factory.");

                obj.Inject(fac);
                obj.LinkClicked += new DelegateLinkClicked(QueryListener);

                Control ctrl = (Control)obj;
                ctrl.Dock = DockStyle.Fill;

                TabPage pg = null;
                if (e.newWindow || tabControl1.SelectedTab == null)
                {
                    pg = new TabPage();
                    pg.Text = "";
                    tabControl1.TabPages.Add(pg);
                    tabControl1.SelectedTab = pg;
                }
                else
                {
                    pg = tabControl1.SelectedTab;
                }
                pg.Controls.Clear();
                pg.Controls.Add(ctrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().FullName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage pg = new TabPage("");
            tabControl1.TabPages.Add(pg);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage pg = tabControl1.SelectedTab;
            tabControl1.TabPages.Remove(pg);
        }

    }

    public class QueryAskedEventArgs : EventArgs
    {
        public UriYoutubeBase uri;
        public bool newWindow = true;

        public QueryAskedEventArgs(UriYoutubeBase uri, bool newWindow)
        {
            this.uri = uri;
            this.newWindow = newWindow;
        }
    }
}
