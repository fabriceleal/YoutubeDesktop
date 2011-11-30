﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace YoutubeDesktop.Youtube.YoutubeEntryActions
{
    public class ContextMenuActionsFactory
    {
        private ContextMenuStrip _theStrip;


        public ContextMenuActionsFactory(YoutubeObject operations)
        {
            // TODO: List methods in operations to get all alowed operations

            // TODO: Check arguments. Extra UI may be needed to fill all of methods parameters

            // ...
            _theStrip = new ContextMenuStrip();

            ToolStripItem item = _theStrip.Items.Add("item01");
            item.Click += new EventHandler(item_Click);
            
        }

        private void item_Click(object sender, EventArgs e)
        {
            // Generic handler
            
        }


        public ContextMenuStrip ContextMenuStrip
        {
            get {
                return _theStrip;
            }
        }

    }
}