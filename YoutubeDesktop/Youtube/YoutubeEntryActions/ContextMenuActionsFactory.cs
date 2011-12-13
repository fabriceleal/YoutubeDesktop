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

            foreach(var met in methods){
                ToolStripItem item = _theStrip.Items.Add(
                        ((AttributeMethodCtx) met.Attributes[0]).Label);
                
                item.Click += delegate(object sender, EventArgs e)
                {
                    // TODO: Check arguments. Extra UI may be needed to fill all of methods parameters ...
                    ParameterInfo[] parameters = met.Method.GetParameters();
                    List<object> args = new List<object>();
                    foreach (ParameterInfo par in parameters)
                    {
                        // TODO: For types, open UI "editor"
                        // * pick a Personal playlist
                        // * write an int

                    }
                                        
                    met.Method.Invoke(operations, args.ToArray());
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
