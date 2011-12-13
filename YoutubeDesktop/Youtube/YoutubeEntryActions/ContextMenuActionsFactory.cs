using System;
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
            Type t = operations.GetType();
            Type attrType = typeof(AttributeMethodCtx);
            var methods = from m in t.GetMethods()                           
                          select new { 
                              Method = m, 
                              Attributes = m.GetCustomAttributes(attrType, true) };

            _theStrip = new ContextMenuStrip();

            foreach(var method in methods){
                ToolStripItem item = _theStrip.Items.Add("item01");
                item.Click += delegate(object sender, EventArgs e)
                {

                };
            }            
        }

        public ContextMenuStrip ContextMenuStrip
        {
            get {
                return _theStrip;
            }
        }

    }
}
