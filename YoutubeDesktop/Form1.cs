using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;

using System.Web;
using System.Net;
using System.IO;
using System.Security.Permissions;
using Noesis.Javascript;
using YoutubeDesktop.Youtube;
using System.Reflection;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //String authSubUrl = AuthSubUtil.getRequestUrl(Globals.Target, Globals.Scope, false, false);
                //WebBrowser1.Navigate(authSubUrl);

                WebBrowser1.Navigate(
                        "https://accounts.google.com/o/oauth2/auth?client_id=" + Globals.ClientId +
                        "&redirect_uri=" + Globals.Target + "&scope=" + HttpUtility.UrlEncode(Globals.Scope) +
                        "&response_type=code");
                //---
            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Exc auth. = " + ex.Message);
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                ListBox1.Items.Add("Navigated to " + e.Url.ToString());
            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Exc nav. = " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                YoutubeWeb.AskForTokenFromKey(txToken.Text.Trim());

                ListBox1.Items.Add(YoutubeWeb.pars["access_token"]);
                ListBox1.Items.Add(YoutubeWeb.pars["refresh_token"]);

                ListBox1.Items.Add("Request Ok");

                ListBox1.Items.Add(YoutubeWeb.pars["access_token"]);
                ListBox1.Items.Add(YoutubeWeb.pars["expires_in"]);
                ListBox1.Items.Add(YoutubeWeb.pars["token_type"]);
                ListBox1.Items.Add(YoutubeWeb.pars["refresh_token"]);                
                
            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Exc Get Refresh / Access Token = " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UriYoutubeBase address = YoutubeUris.GetStandardFeed(YoutubeUris.STANDARD_FEED_TYPE.most_recent);
                ListBox1.Items.Add(address.ToString());

                String grab = YoutubeWeb.CallApiMethod(YoutubeWeb.WebMethod.GET, address, null, false, YoutubeWeb.Data.Empty);
                textBox1.Text = grab;

                // Creates .NET object
                YoutubeFeed feed = (YoutubeFeed)address.DoQuery();

                address = YoutubeUris.GetVideo("ADos_xW4_J0");
                ListBox1.Items.Add(address.ToString());
              
                //grab = YoutubeWeb.CallApiMethod(YoutubeWeb.WebMethod.GET, address, null);
                //textBox1.Text = grab;

                // Creates .NET object
                YoutubeEntry video = (YoutubeEntry)address.DoQuery();

                                                
                ListBox1.Items.Add("Query Ok");
            }
            catch (Exception ex)
            {
                ListBox1.Items.Add("Exc Call API = " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                                
        }

        private void query1_Load(object sender, EventArgs e)
        {

        }

        private void queryBuilder1_QueryAsked(object sender, QueryBuilder.EventArgsQueryBuilder e)
        {
            Assync<UriYoutubeBase>.Execute(
                this,
                () => { return e.uri; },
                (uri) => { navigator1.QueryListener(this, new QueryAskedEventArgs(uri, true)); });
        }

    }
}
