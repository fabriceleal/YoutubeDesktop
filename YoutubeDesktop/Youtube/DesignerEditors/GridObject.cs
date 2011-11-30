using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YoutubeDesktop
{
    public partial class GridObject : Form
    {
        public GridObject(object o)
        {
            InitializeComponent();
            //---
            propertyGrid1.SelectedObject = o;
        }

        private void GridObject_Load(object sender, EventArgs e)
        {

        }
    }
}
