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
            // List methods in operations to get all alowed operations            
            Type t = operations.GetType();
            Type attrType = typeof(AttributeMethodCtx);
            var methods = from m in t.GetMethods()                           
                          select new { 
                              Method = m, 
                              Attributes = m.GetCustomAttributes(attrType, true) };

            _theStrip = new ContextMenuStrip();

            foreach(var method in methods){
                ToolStripItem item = _theStrip.Items.Add(
                        ((AttributeMethodCtx) method.Attributes[0]).Label);
                
                item.Click += delegate(object sender, EventArgs e)
                {
                    // TODO: Check arguments. Extra UI may be needed to fill all of methods parameters

                    object[] context = new object[] { };
                    method.Method.Invoke(operations, context);
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
