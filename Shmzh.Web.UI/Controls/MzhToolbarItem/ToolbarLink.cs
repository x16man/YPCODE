using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;

namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// Toolbar
	/// </summary>
	[ToolboxBitmap(typeof(ToolbarLink),"Shmzh.Web.UI.Controls.ToolbarButton.bmp")]
    [Obsolete("������δʵ������ʹ�ã�",true)]
	public class ToolbarLink : ToolbarItem
	{
		#region ��Ա����
		protected string m_TableClass = "buttonTable";
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		protected string m_LinkClass = "linkCell";
		protected string m_NakedLabelClass = "nakedLinkCell";
		protected string m_IconClass = "icon";
		protected bool m_HasIcon = true;
		protected bool m_IsShowText = true;
		protected string m_url = string.Empty;
		protected string m_target = string.Empty;
		protected string m_text = string.Empty;
		#endregion

		#region ����
		/// <summary>
		/// ���ӵ�URL��
		/// </summary>
		public string URL
		{
			get {return this.m_url;}
			set {this.m_url = value;}
		}
		/// <summary>
		/// ���ӵ�Ŀ�ꡣ
		/// </summary>
		public string Target
		{
			get {return this.m_target;}
			set {this.m_target = value;}
		}
		/// <summary>
		/// �����ӵ��ı���
		/// </summary>
		public string Text
		{
			get {return this.m_text;}
			set {this.m_text = value;}
		}
		/// <summary>
		/// Label����ʽ����
		/// </summary>
		public string LinkClass
		{
			get {return this.m_LinkClass;}
			set {m_LinkClass = value;}
		}
		/// <summary>
		/// û��Iconʱ���Label����ʽ����
		/// </summary>
		public string NakedLinkClass
		{
			get { return m_NakedLabelClass; }
			set { m_NakedLabelClass = value; }
		}
		
		/// <summary>
		/// ��ť��Icon����ʽ��
		/// </summary>
		/// ͼ�����ʾ��ͨ��ָ������ͼ��λ����ȷ���ġ�
		public string IconClass
		{
			get { return m_IconClass; }
			set { m_IconClass = value; }
		}
		/// <summary>
		/// �Ƿ���ͼ�ꡣ
		/// </summary>
		public bool HasIcon
		{
			get { return m_HasIcon; }
			set { m_HasIcon = value; }
		}
		
		/// <summary>
		/// ToolbarItem��css��ʽ����
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarItem��css��ʽ���ơ�")]
		public string TableClass
		{
			get {return m_TableClass;}
			set {this.m_TableClass = value;}
		}
		/// <summary>
		/// ToolbarItem��Cellpadding��
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarItem��Cellpadding��")]
		public string Cellpadding
		{
			get {return m_Cellpadding;}
			set {m_Cellpadding = value;}
		}
		/// <summary>
		/// ToolbarItem��Cellpadding��
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarItem��Cellspacing��")]
		public string Cellspacing
		{
			get {return m_Cellspacing;}
			set {m_Cellspacing = value;}
		}
		#endregion

		#region ���캯��
		public ToolbarLink(): base(HtmlTextWriterTag.Table)
		{
			//
			// 
			//
		}
		#endregion

		#region Rending
		/// <summary>
		/// ��������Table������ԡ�
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class, this.TableClass, true);
			writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Cellpadding);
			writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, this.Cellspacing);
			writer.AddAttribute("unselectable","on");

			base.AddAttributesToRender(writer);
		}
		/// <summary>
		/// Renders the item's <see cref="Text"/> to the client.
		/// </summary>
		/// <param name="writer"></param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			
			this.RenderLeftCapCell(writer);//�����������
			this.RenderIconCell(writer);
			this.RenderLinkCell(writer, this.HasIcon);
			this.RenderRightCapCell(writer);//�����ұ�����
			base.RenderContents (writer);
		}
		/// <summary>
		/// ����ͼ�ꡣ
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <example>���ֽ����<code><td class="buttonIconCell" unselectable="on"><div class="button" unselectable="on"></div></td>��</code></example>
		protected void RenderIconCell(HtmlTextWriter writer)
		{
			if (!this.HasIcon) return;//���û��ͼ����ֱ���˳���
			writer.AddAttribute("class","buttonIconCell",true);
			writer.AddAttribute("unselectable","on",true);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
		{
			writer.AddAttribute("class",string.Format("button {0}",this.IconClass),true);
			writer.AddAttribute("unselectable","on",true);
			writer.RenderBeginTag(HtmlTextWriterTag.Div);
			writer.RenderEndTag();//</div>
		}
			writer.RenderEndTag();//</td>
		}
		/// <summary>
		/// �������֡�
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <example><td class="labelCell" unselectable="on">����</td></example>
		protected void RenderLinkCell(HtmlTextWriter writer,bool hasIcon)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class,hasIcon?NakedLinkClass:LinkClass,true);
			writer.AddAttribute("unselectable","on",true);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write(string.Format("<a href='{0}' title='{1}' target='{2}'>{3}</a>",this.URL,this.ToolTip,this.Target,this.Text));
			writer.RenderEndTag();
		}
		/// <summary>
		/// ����ToolbarItem���������
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// /// <example><td class="leftCap" style="width:3px" unselectable="on"></example>
		protected void RenderLeftCapCell(HtmlTextWriter writer)
		{
			RenderCapCell(writer, "leftCap");
		}
		/// <summary>
		/// ����ToolbarItem���ұ�����
		/// </summary>
		/// <param name="writer"></param>
		/// <example><td class="rightCap" style="width:3px" unselectable="on"></example>
		protected void RenderRightCapCell(HtmlTextWriter writer)
		{
			RenderCapCell(writer, "rightCap");
		}
		/// <summary>
		/// ����button��������������
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <param name="capClass">css��ʽ����</param>
		/// <example><td class="capClass" style="width:3px" unselectable="on"></example>
		private void RenderCapCell(HtmlTextWriter writer, string capClass)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class ,capClass);
			writer.AddStyleAttribute("width","3px");
			writer.AddAttribute("unselectable", "on");
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.AddStyleAttribute("width","3px");
			writer.AddStyleAttribute("visibility", "hidden");
			writer.AddAttribute("unselectable", "on");
			writer.RenderBeginTag(HtmlTextWriterTag.Div);
			writer.RenderEndTag();
			writer.RenderEndTag();
		}
		
		#endregion
	}
}
