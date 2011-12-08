using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.GData.Client;

namespace YoutubeDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                WebBrowser1.Navigate(
                    "https://accounts.google.com/o/oauth2/auth?client_id=" + Globals.ClientId +
                    "&redirect_uri=" + Globals.Target + "&scope=" + HttpUtility.UrlEncode(Globals.Scope) +
                    "&response_type=code");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().FullName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Assync<Boolean>.Execute(this, 
                        () => { return YoutubeWeb.AskForTokenFromKey(txToken.Text.Trim()); } ,
                        (result) => { 
                            if(result){
                                Close();
                            }
                        });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().FullName);
            }
        }
    }
}
