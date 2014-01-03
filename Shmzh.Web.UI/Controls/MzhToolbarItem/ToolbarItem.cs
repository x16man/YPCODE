using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;


namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// Toobar�ռ��������ĳ�����ࡣ
	/// </summary>
	public abstract class ToolbarItem : WebControl, INamingContainer
	{
		#region members
		/// <summary>
		/// ToolbarItem��ΨһID��
		/// ������postback�¼�������ʱ�������ж��¼�Դ����
		/// </summary>
		protected string m_itemId = String.Empty;
//	    protected string m_TableClass = "buttonTable";
//		protected string m_Cellpadding = "0";
//		protected string m_Cellspacing = "0";
		#endregion

		#region properties
		/// <summary>
		/// ToolbarItem��ΨһID��
		/// ������postback�¼�������ʱ�������ж��¼�Դ����
		/// </summary>
		[Description("ToolbarItem���û������ΨһID��")]
		public string ItemId
		{
			get { return m_itemId; }
			set {this.m_itemId = value; }
		}
        /// <summary>
        /// �Ƿ��¼�����֤��
        /// </summary>
        [DefaultValue(false), Themeable(false), Category("Behavior"), Description("�Ƿ��¼�����֤��"),]
        public virtual bool CausesValidation
        {
            get
            {
                object b = ViewState["CausesValidation"];
                return ((b == null) ? true : (bool)b);
            }
            set
            {
                ViewState["CausesValidation"] = value;
            }
        }
        /// <summary>
        /// ���ؼ����·�ʱӦ��֤���顣
        /// </summary>
        [DefaultValue(""), Themeable(false), Category("Behavior"), Description("���ؼ����·�ʱӦ��֤���顣"),]
        public string ValidationGroup
        {
            get
            {
                var s = (string)ViewState["ValidationGroup"];
                return (s ?? String.Empty);
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        } 
        /// <summary>
        /// �ڿͻ���onclick��ִ�еĿͻ��˽ű���
        /// </summary>
        [DefaultValue(""), Themeable(false), Category("Client Behavior"), Description("�ڿͻ���onclick��ִ�еĿͻ��˽ű���"),]
        public virtual string OnClientClick
        {
            get
            {
                var s = (string)ViewState["OnClientClick"];
                return s ?? String.Empty;
            }
            set
            {
                ViewState["OnClientClick"] = value;
            }
        }
        
		/// <summary>
		/// �жϿؼ���ǰ�������ģʽ���ǲ��ǡ�
		/// </summary>
		protected bool IsDesignMode
		{
			get { return System.Web.HttpContext.Current == null; }
		}
		#endregion

		#region initialization

		/// <summary>
		/// �չ��캯����
		/// </summary>
		protected ToolbarItem()
		{
		}

		/// <summary>
		/// ��һ���ض���HTML��ǩ������һ��ToolbarItem��
		/// </summary>
		/// <param name="tag">Html tag of the item control.</param>
		protected ToolbarItem(HtmlTextWriterTag tag) : base(tag)
		{
		}

		#endregion

		#region rendering
		/// <summary>
		/// Adds table attributes to the rendered output.
		/// </summary>
		/// <param name="writer"></param>
//		protected override void AddAttributesToRender(HtmlTextWriter writer)
//		{
//			//<table id="btnTbl_File" class="buttonTable" cellpadding="0" unselectable="on" >
//			if (this.TagKey == HtmlTextWriterTag.Table)
//			{
//				writer.AddAttribute(HtmlTextWriterAttribute.Class, this.TableClass, true);
//				writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Cellpadding);
//				writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, this.Cellspacing);
//				writer.AddAttribute("unselectable","on");
//			}
//			base.AddAttributesToRender(writer);
//		}
		/// <summary>
		/// ����ToolbarItem���������
		/// </summary>
		/// <param name="writer"></param>
//		protected void RenderLeftCap(HtmlTextWriter writer)
//		{
//			//<td class="leftCap" style="width:3px" unselectable="on">
//			writer.AddAttribute(HtmlTextWriterAttribute.Class ,"leftCap");
//			writer.AddStyleAttribute("width","3px");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Td);
//			//<div style="width:3px;visibility:hidden;">
//			writer.AddStyleAttribute("width","3px");
//			writer.AddStyleAttribute("visibility", "hidden");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Div);
//
//			writer.RenderEndTag();//</div>
//			writer.RenderEndTag();//</td>
//		}
		/// <summary>
		/// ����ToolbarItem���ұ�����
		/// </summary>
		/// <param name="writer"></param>
//		protected void RenderRightCap(HtmlTextWriter writer)
//		{
//			//<td class="rightCap" style="width:3px" unselectable="on">
//			//<td class="leftCap" style="width:3px" unselectable="on">
//			writer.AddAttribute(HtmlTextWriterAttribute.Class ,"rightCap");
//			writer.AddStyleAttribute("width","3px");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Td);
//			//<div style="width:3px;visibility:hidden;" unselectable="on">
//			writer.AddStyleAttribute("width","3px");
//			writer.AddStyleAttribute("visibility", "hidden");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Div);
//
//			writer.RenderEndTag();//</div>
//			writer.RenderEndTag();//</td>
//		}
		#endregion

	}
}
