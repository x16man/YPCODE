using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// MzhOutLookBar ��ժҪ˵����
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:MzhOutLookBar runat=server></{0}:MzhOutLookBar>")]
	public class MzhOutLookBar : System.Web.UI.WebControls.WebControl
	{
		private string text;
	
		[Bindable(true), 
			Category("Appearance"), 
			DefaultValue("")] 
		public string Text 
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		/// <summary> 
		/// ���˿ؼ����ָ�ָ�������������
		/// </summary>
		/// <param name="output"> Ҫд������ HTML ��д�� </param>
		protected override void Render(HtmlTextWriter output)
		{
			output.Write(Text);
		}
	}
}
