using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using YoutubeDesktop.Youtube;
using YoutubeDesktop.Youtube.UriYoutube;

namespace YoutubeDesktop
{
    public partial class UriBuilder : UserControl
    {
        public UriBuilder()
        {
            InitializeComponent();
        }

        public void AddFuncao(MethodInfo info)
        {
            Funcao f = new Funcao(info);
            f.Dock = DockStyle.Top;
            flowLayoutPanel1.Controls.Add(f);
            f.EChanged += new Funcao.DelEChanged(f_EChanged);
        }

        private UriYoutubeBase current = null;

        void f_EChanged(object sender, EventArgs e)
        {
            current = ((Funcao)sender).GetUrl();
            textBox1.Text = current.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public UriYoutubeBase getUrl()
        {
            return current;
        }

        private void QueryBuilder_Load(object sender, EventArgs e)
        {
            foreach (MethodInfo met in typeof(YoutubeUris)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                AddFuncao(met);
            }    
        }
                
    }
}
