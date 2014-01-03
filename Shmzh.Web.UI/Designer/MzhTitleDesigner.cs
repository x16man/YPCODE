using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Shmzh.Web.UI.Controls;

namespace Shmzh.Web.UI.Designer
{
    public class MzhTitleDesigner : System.Web.UI.Design.ControlDesigner
    {
        public MzhTitleDesigner()
        {
            
        }
        public override string GetDesignTimeHtml()
        {
            var control = (MzhTitle)Component;
            return String.Format(CultureInfo.InvariantCulture,"<h1 id=\"{0}\" class=\"title\">Title</h1>",control.ID);
        }
    }
}
