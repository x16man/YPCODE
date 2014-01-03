using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
[assembly:TagPrefix("Shmzh.Web.UI.Controls", "MZH")]
namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// MzhDropDownList 的摘要说明。
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:MzhDropDownList runat=server></{0}:MzhDropDownList>")]
	public class MzhDropDownList : System.Web.UI.WebControls.DropDownList
	{
		/// <summary> 
		/// 将此控件呈现给指定的输出参数。
		/// </summary>
		/// <param name="output"> 要写出到的 HTML 编写器 </param>
		protected override void Render(HtmlTextWriter output)
		{
			if (this.Enabled == false)
			{
				output.Write(string.Format("<span>{0}</span>",this.SelectedItem.Text));
				this.Attributes.CssStyle.Add("display","none");
				this.Attributes.CssStyle.Add("visibility","hidden");
			}
			base.Render(output);
		}
	}
}
