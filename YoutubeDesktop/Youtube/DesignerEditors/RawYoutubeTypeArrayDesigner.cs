using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;

namespace YoutubeDesktop.Youtube.DesignerEditors
{
    public class RawYoutubeTypeArrayDesigner : UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            //if (value.GetType() != typeof(ScriptCollection))
            //    return null;

            ArrayGridObject designer = new ArrayGridObject((RawYoutubeType[])value);
            designer.ShowDialog();
            designer.Dispose();

            return value;
        }
    }
}
