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

namespace YoutubeDesktop
{
    public partial class QueryBuilder : UserControl
    {

        public class EventArgsQueryBuilder : EventArgs
        {
            public UriYoutubeBase uri;
        }

        public delegate void DelegateQueryAsked(object sender, EventArgsQueryBuilder e);
        
        [Browsable(true)]
        public event DelegateQueryAsked QueryAsked;

        private bool debug = false;

        public QueryBuilder()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public bool Debug { get { return debug; } set { 
            debug = value;
            splitContainer1.Panel2Collapsed = !debug;
        } }

        private void btQuery_Click(object sender, EventArgs e)
        {
            UriYoutubeBase address = queryBuilderUserControl.getUrl();

            if (debug)
            {
                // Tab 1: query diagnostics
                Assync<object>.Execute(
                        this,
                        () => { return address.DoQuery(); },
                        (o) =>
                        {
                            grObject.SelectedObject = o;

                            Assync<String>.Execute(
                                this,
                                () => { return JavascriptUtils.SerializeObject(((RawYoutubeType)o).Data); },
                                (s) =>
                                {
                                    txJson.Text = s;
                                });
                        });
                //--
            }

            EventArgsQueryBuilder q = new EventArgsQueryBuilder();
            q.uri = address;
            if (QueryAsked != null)
                QueryAsked(this, q);

        }
    }
}
