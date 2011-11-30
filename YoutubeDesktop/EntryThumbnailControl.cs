using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDesktop.Youtube;
using System.Net;
using System.Net.Sockets;
using YoutubeDesktop.Youtube.Factory;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{
    public partial class EntryThumbnailControl : UserControl, IQueryUIObject
    {
        public event DelegateLinkClicked LinkClicked;

        private YoutubeEntry _video;
        private int _currentImageIdx;
        private Dictionary<int, ImageUri> _thumbnails;

        public EntryThumbnailControl()
        {
            InitializeComponent();
        }

        public void Inject(IFactory factory)
        {
            _video = (YoutubeEntry)factory[0];

            int duration = 0;
            int.TryParse((string)_video.MediaGroup.Duration, out duration);

            TimeSpan tmp = new TimeSpan(0, 0, duration);

            label1.Text = (tmp).ToString(@"d\.hh\:mm\:ss");
            linkLabel1.Text = (string)_video.Title;
            if (_video.Statistics.ViewCount == null)
            {
                label2.Text = "?";
            }
            else
            {
                label2.Text = _video.Statistics.ViewCount.ToString() + " views";
            }
            linkLabel2.Text = (string)_video.Author[0].Name;

            _currentImageIdx = 0;
            AskPhoto(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_thumbnails != null)
            {
                _thumbnails = GetThumbnails();
            }

            if (_thumbnails == null)
                return;

            _currentImageIdx = (_currentImageIdx + 1) % (_thumbnails.Count - 1);
            AskPhoto(_currentImageIdx);
        }

        private void AskPhoto(int idx)
        {
            if (_thumbnails == null)
            {
                _thumbnails = GetThumbnails();
            }

            if (_thumbnails == null)
                return;

            if (_thumbnails.Count == 0 || idx >= _thumbnails.Count)
                return;

            Assync<Image>.Execute(
                    this,
                    () =>
                    {
                        return (Image)(_thumbnails[idx]);
                    },
                    (i) =>
                    {
                        pictureBox1.Image = i;
                    });
            //---
        }

        private void VideoControl_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void VideoControl_MouseEnter(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void urlToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((string)_video.MediaGroup.Player[0].Url, TextDataFormat.Text);
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = false;
        }

        private void openVideoPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new GridObject(_video)).ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(LinkClicked != null){

                object id = _video.GetAsScalar("yt$playlistId");
                if (id != null)
                {
                    // Playlist
                    UriYoutubeFeed entry = YoutubeUris.GetPlaylist((string)id);
                    LinkClicked(this, new QueryAskedEventArgs(entry, true));
                }
                else
                {
                    // Video ...
                    id = _video.GetAsScalar("yt$videoid");

                    UriYoutubeEntry entry = YoutubeUris.GetVideo((string)id);
                    LinkClicked(this, new QueryAskedEventArgs(entry, true));
                }

            }
        }

        public Dictionary<int, ImageUri> GetThumbnails()
        {
            // Build skeleton sincronously, get images assyncronously

            Dictionary<int, ImageUri> skeleton = new Dictionary<int, ImageUri>();
            int i = 0;
            foreach (YoutubeMediaThumbnail thumb in _video.MediaGroup.MediaThumbnail)
            {
                skeleton.Add(i, new ImageUri(new Uri((string)thumb.Url)));
                i += 1;
            }

            return skeleton;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(LinkClicked != null){
                // AUTHOR
                LinkClicked(this, new QueryAskedEventArgs(null, true));
            }
        }

        private void getRelatedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
