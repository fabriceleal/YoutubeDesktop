using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeDesktop.Youtube;

namespace YoutubeDesktop
{
    public partial class PropertyGridExtra : PropertyGrid
    {        
        public PropertyGridExtra() : base()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripItem item = menu.Items.Add("Open Selected Object");
            item.Click += new EventHandler(item_Click);
            this.ContextMenuStrip = menu;
        }

        void item_Click(object sender, EventArgs e)
        {
            if (this.SelectedGridItem.Value.GetType().IsArray)
            {
                (new ArrayGridObject((RawYoutubeType[])this.SelectedGridItem.Value)).ShowDialog();
            }
            else
            {
                (new GridObject(this.SelectedGridItem.Value)).ShowDialog();
            }
        }


    }
}
