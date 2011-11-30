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
    public partial class Funcao : UserControl
    {
        public delegate void DelEChanged(object sender, EventArgs e);
        public event DelEChanged EChanged;

        private class Parameter
        {
            public Control ctrl;
            public Func<Control, object> transformer;
        }

        MethodInfo _method;
        List<Parameter> _params = new List<Parameter>();

        public Funcao(MethodInfo method)
        {
            InitializeComponent();
            this.SuspendLayout();

            _method = method;
            Label l = new Label();
            l.Text = method.Name.ToUpper();
            l.AutoSize = true;
            l.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            flowLayoutPanel1.Controls.Add(l);

            Button bt = new Button();            
            bt.Text = "Update";
            bt.Width = 50;
            bt.Click += new EventHandler(bt_Click);
            flowLayoutPanel1.Controls.Add(bt);

            foreach (ParameterInfo par in _method.GetParameters())
            {
                l = new Label();
                l.Text = par.Name + ":";
                l.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
                l.AutoSize = true;
                flowLayoutPanel1.Controls.Add(l);

                Control c;
                if (par.ParameterType.IsEnum)
                {
                    // nv combobox
                    c = NovaCombobox(par.ParameterType, par.DefaultValue);
                    if (par.DefaultValue != null && par.DefaultValue != DBNull.Value)
                    {
                        c.Text = par.DefaultValue.ToString();
                    }
                    ((ComboBox)c).SelectedValueChanged += new EventHandler(Changed);
                }
                else
                {
                    // caixa de texto
                    c = NovaTextbox(par.ParameterType, par.DefaultValue);
                    if (par.DefaultValue != null && par.DefaultValue != DBNull.Value)
                    {
                        c.Text = (string)par.DefaultValue;
                    }
                    c.TextChanged += new EventHandler(Changed);
                }
                
            }
        }

        void bt_Click(object sender, EventArgs e)
        {
            Changed(this, e);
        }

        private ComboBox NovaCombobox(Type enumType, object defaultValue)
        {
            ComboBox cb = new ComboBox();
            cb.Width = 100;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.flowLayoutPanel1.Controls.Add(cb);

            foreach (object o in Enum.GetValues(enumType))
            {
                cb.Items.Add(o.ToString());
            }

            Parameter p = new Parameter();
            p.ctrl = cb;
            p.transformer = c => (object)(String.IsNullOrEmpty(c.Text) ? 0 : Enum.Parse(enumType, c.Text, true));
            _params.Add(p);

            return cb;
        }

        private TextBox NovaTextbox(Type enumType, object defaultValue)
        {
            TextBox tx = new TextBox();
            tx.Width = 100;
            this.flowLayoutPanel1.Controls.Add(tx);
            string defaultValue2 = defaultValue == DBNull.Value ? "" : (string)defaultValue;

            Parameter p = new Parameter();
            p.ctrl = tx;
            p.transformer = c => (string)(String.IsNullOrEmpty(c.Text) ? defaultValue2 : c.Text);
            _params.Add(p);

            return tx;
        }

        public UriYoutubeBase GetUrl()
        {
            object ret = _method.Invoke(null, GetParams());
            return (UriYoutubeBase)ret;
        }

        private object[] GetParams()
        {
            List<object> pars = new List<object>();
            foreach (Parameter p in _params)
            {
                pars.Add(p.transformer(p.ctrl));
            }
            return pars.ToArray();
        }

        private void Changed(object sender, EventArgs e)
        {
            if (EChanged != null)
                EChanged(this, EventArgs.Empty);
        }

    }
}
