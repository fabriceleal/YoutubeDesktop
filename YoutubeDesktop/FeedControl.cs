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
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{
    public partial class FeedControl : UserControl, IQueryUIObject
    {
        public event DelegateLinkClicked LinkClicked;

        private PagesFactory _factory;
        
        public FeedControl()
        {
            InitializeComponent();
        }
        
        public void Inject(IFactory feedFact)
        {
            _factory = (PagesFactory)feedFact;
            AskForPage(0);
        }

        public void AskForPage(int idx)
        {
            this.Cursor = Cursors.WaitCursor;
            Assync<YoutubeFeed>.Execute(
                    this,
                    () => { return (YoutubeFeed)_factory[idx]; },
                    (feed) => {
                        // Clear
                        flowLayoutPanel1.Controls.Clear();
                        // Add videos
                        foreach (YoutubeEntry video in feed.Entry)
                        {
                            AddChild(video);
                        }
                        // Update headers
                        lbTopPageNbr.Text = (_factory.CurrentIndex + 1).ToString();
                        lbTopPageTot.Text = (_factory.PageTot).ToString();

                        this.Cursor = Cursors.Default;
                    });
            //---
        }

        public void AddChild(YoutubeEntry video)
        {
            EntryThumbnailControl ctrl = new EntryThumbnailControl();

            ((IQueryUIObject)ctrl).LinkClicked += new DelegateLinkClicked(FeedControl_LinkClicked);

            ctrl.Inject(new SimpleFactory((RawYoutubeType)video));
            flowLayoutPanel1.Controls.Add(ctrl);
        }

        void FeedControl_LinkClicked(object sender, QueryAskedEventArgs e)
        {
            if (LinkClicked != null)
                LinkClicked(sender, e);
        }

        private void btTopFirst_Click(object sender, EventArgs e)
        {
            AskForPage(0);
        }

        private void btTopPrev_Click(object sender, EventArgs e)
        {
            AskForPage(_factory.CurrentIndex - 1);
        }

        private void btTopNext_Click(object sender, EventArgs e)
        {
            AskForPage(_factory.CurrentIndex + 1);
        }

        private void btTopLast_Click(object sender, EventArgs e)
        {
            AskForPage(_factory.PageTot - 1);
        }

    }
}
