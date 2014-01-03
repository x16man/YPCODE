using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// 工具条分割符
	/// </summary>
	public class ToolbarSeparator : ToolbarItem
	{
		#region 属性
		/// <summary>
		/// Separator的样式名。
		/// </summary>
		public string SeparatorClass
		{
			get {return m_SeparatorClass;}
			set {m_SeparatorClass = value;}
		}
		protected string m_SeparatorClass = "toolbarIconDivider";
		#endregion

		#region 构造函数
		/// <summary>
		/// 空构造函数。
		/// </summary>
		public ToolbarSeparator():base(HtmlTextWriterTag.Div)
		{
		}
		#endregion

		#region rendering
		/// <summary>
		/// 给分隔符增加样式。
		/// </summary>
		/// <param name="writer"></param>
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class, string.IsNullOrEmpty(this.CssClass)?this.SeparatorClass:this.CssClass, true);
            writer.AddAttribute(HtmlTextWriterAttribute.Style, this.Style.Value, true);
			base.AddAttributesToRender(writer);
		}
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
		protected override void RenderContents(HtmlTextWriter writer) 
		{
			//writer.Write("Custom Contents");
			base.RenderContents(writer);
		}
		#endregion
	}
}
