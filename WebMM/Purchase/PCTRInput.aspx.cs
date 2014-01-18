using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MZHMM.Facade;
using MZHMM.Common;
using MZHMM.WebMM.Modules;

namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// PCTRInput 的摘要说明。
	/// </summary>
	public partial class PCTRInput : System.Web.UI.Page
	{

		private string op = "New";
		public    System.Web.UI.WebControls.TextBox txtRemark;

		protected StorageDropdownlist ddlType = new StorageDropdownlist();
		protected StorageDropdownlist ddlPrv = new StorageDropdownlist();

		private string code;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Contract;
			// 在此处放置用户代码以初始化页面
			ddlPrv.Width = "100%";
			ddlType.Width = "100%";
			//获取传入的供应商代码和操作标记。
			if (Request["Code"] != null && Request["Code"] != "")
			{
				code = Request["Code"];
				op = Request["Op"];
			}
			//根据不同的状态进行数据绑定。
			if(!Page.IsPostBack)
			{
				if(op!="New")
				{
					BindDataUpdate();
				}
				else
				{
					BindDataNew();
				}
			}
		}

		/// <summary>
		/// 新增状态下的数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			//类别
			this.ddlType.Module_Tag= (int)SDDLTYPE.CTYP;
			//状态
			this.ddlPrv.Module_Tag=(int)SDDLTYPE.VENDOR;
		}
		/// <summary>
		/// 编辑状态下的数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{
			PCTRData oPCTRData = new PCTRData();
			PCTRSystem oPCTRSystem = new PCTRSystem();
			oPCTRData = oPCTRSystem.GetPCTRByEntryNo(this.code);
			//赋值
			DataRow oDataRow = oPCTRData.Tables[PCTRData.PCTR_TABLE].Rows[0];
			
			this.txtOldEntryCode.Text = oDataRow[PCTRData.ENTRYCODE_FIELD].ToString();						
			this.txtEntryCode.Text=oDataRow[PCTRData.ENTRYCODE_FIELD].ToString();							
			this.txtEntryName.Text=oDataRow[PCTRData.ENTRYNAME_FIELD].ToString();							
			this.ddlType.Module_Tag = (int)SDDLTYPE.CTYP;
			this.ddlType.SelectedValue = oDataRow[PCTRData.TYPECODE_FIELD].ToString();					
			this.ddlPrv.Module_Tag = (int)SDDLTYPE.VENDOR;
			this.ddlPrv.SelectedValue = oDataRow[PCTRData.PRVCODE_FIELD].ToString();			
			
			if (oDataRow[PCTRData.ENTRYDATE_FIELD] != DBNull.Value)								
				this.txtEntryDate.Text = oDataRow[PCTRData.ENTRYDATE_FIELD].ToString();
			if (oDataRow[PCTRData.MANAGER_FIELD] != DBNull.Value)								
				this.txtManager.Text = oDataRow[PCTRData.MANAGER_FIELD].ToString();
			if (oDataRow[PCTRData.TOTALMONEY_FIELD] != DBNull.Value)							
				this.txtTotalMoney.Text = oDataRow[PCTRData.TOTALMONEY_FIELD].ToString();
			if (oDataRow[PCTRData.STAMPTAX_FIELD] != DBNull.Value)								
				this.txtStampTax.Text = oDataRow[PCTRData.STAMPTAX_FIELD].ToString();
			if (oDataRow[PCTRData.PAYMONEY_FIELD] != DBNull.Value)								
				this.txtPayMoney.Text = oDataRow[PCTRData.PAYMONEY_FIELD].ToString();
			if (oDataRow[PCTRData.LEFTMONEY_FIELD] != DBNull.Value)								
				this.txtLeftMoney.Text = oDataRow[PCTRData.LEFTMONEY_FIELD].ToString();
			if (oDataRow[PCTRData.STARTDATE_FIELD] != DBNull.Value)								
				this.txtStartDate.Text = oDataRow[PCTRData.STARTDATE_FIELD].ToString();
			if (oDataRow[PCTRData.ENDDATE_FIELD] != DBNull.Value)								
				this.txtEndDate.Text = oDataRow[PCTRData.ENDDATE_FIELD].ToString();
			if (oDataRow[PCTRData.CLEANDATE_FIELD] != DBNull.Value)								
				this.txtCleanDate.Text = oDataRow[PCTRData.CLEANDATE_FIELD].ToString();
			if (oDataRow[PCTRData.REMARK_FIELD] != DBNull.Value)								
				this.txtRemark.Text = oDataRow[PCTRData.REMARK_FIELD].ToString();
			//if(op=="Edit")	txtCode.Enabled=false;
		}

		/// <summary>
		/// 页面提交事件处理。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			PCTRData oPCTRData = new PCTRData();

			DataRow oDataRow = oPCTRData.Tables[PCTRData.PCTR_TABLE].NewRow();
			//将页面上的数据压到DataRow中。
			if (op == "Edit")//如果是编辑状态，则给OldEntryno赋值。
			{
				oDataRow[PCTRData.ENTRYNO_FIELD] = this.code;	
			}
			else
			{
				//填写人信息
				oDataRow[PCTRData.AUTHORDATE_FIELD] = System.DateTime.Now.ToShortDateString();	
				if (Session["USERCODE"] != null)
					oDataRow[PCTRData.AUTHORCODE_FIELD] = Session["USERCODE"];
				if (Session["USERNAME"] != null)
					oDataRow[PCTRData.AUTHORNAME_FIELD] = Session["USERNAME"];
				if (Session["USERDEPTCODE"] != null)
					oDataRow[PCTRData.AUTHORDEPT_FIELD] = Session["USERDEPTCODE"];
				if (Session["USERCODE"] != null)
					oDataRow[PCTRData.AUTHORDEPTNAME_FIELD] = Session["USERDEPTNAME"];
			}
			oDataRow[PCTRData.ENTRYCODE_FIELD] = this.txtEntryCode.Text;				
			oDataRow[PCTRData.ENTRYNAME_FIELD] = this.txtEntryName.Text;				

			oDataRow[PCTRData.TYPECODE_FIELD] = this.ddlType.SelectedValue;				
			oDataRow[PCTRData.PRVCODE_FIELD] = this.ddlPrv.SelectedValue;		
			oDataRow[PCTRData.TYPENAME_FIELD] = this.ddlType.SelectedText;
			oDataRow[PCTRData.PRVNAME_FIELD] = this.ddlPrv.SelectedText;

			if (this.txtEntryDate.Text != null && this.txtEntryDate.Text != "")	
				oDataRow[PCTRData.ENTRYDATE_FIELD] = this.txtEntryDate.Text;
			if (this.txtManager.Text != null && this.txtManager.Text != "")		
				oDataRow[PCTRData.MANAGER_FIELD] = this.txtManager.Text;
			if (this.txtTotalMoney.Text != null && this.txtTotalMoney.Text != "")		
				oDataRow[PCTRData.TOTALMONEY_FIELD] = this.txtTotalMoney.Text;
			if (this.txtStampTax.Text != null && this.txtStampTax.Text != "")			
				oDataRow[PCTRData.STAMPTAX_FIELD] = this.txtStampTax.Text;
			if (this.txtPayMoney.Text != null && this.txtPayMoney.Text != "")			
				oDataRow[PCTRData.PAYMONEY_FIELD] = this.txtPayMoney.Text;
			if (this.txtLeftMoney.Text != null && this.txtLeftMoney.Text != "")
				oDataRow[PCTRData.LEFTMONEY_FIELD] = this.txtLeftMoney.Text;
			if (this.txtStartDate.Text != null && this.txtStartDate.Text != "")	
				oDataRow[PCTRData.STARTDATE_FIELD] = this.txtStartDate.Text;
			if (this.txtEndDate.Text != null && this.txtEndDate.Text != "")		
				oDataRow[PCTRData.ENDDATE_FIELD] = this.txtEndDate.Text;
			if (this.txtCleanDate.Text != null && this.txtCleanDate.Text != "")	
				oDataRow[PCTRData.CLEANDATE_FIELD] = this.txtCleanDate.Text;
			if (this.txtRemark.Text != null && this.txtRemark.Text != "")		
				oDataRow[PCTRData.REMARK_FIELD] = this.txtRemark.Text;

			oPCTRData.Tables[PCTRData.PCTR_TABLE].Rows.Add(oDataRow);

			PCTRSystem oPCTRSystem = new PCTRSystem();
			//提交。
			if (op=="Edit")
			{
				if (oPCTRSystem.UpdatePCTR(oPCTRData) == false)
				{
					Response.Redirect("../ErrorPage.aspx?ErrorInfo="+oPCTRSystem.Message);
				}
			}
			else
			{
//				if (oPCTRSystem.AddPCTR(oPCTRData) == false)
//				{
//					Response.Redirect("../ErrorPage.aspx?ErrorInfo="+oPCTRSystem.Message);
//				}
			}
			Response.Redirect("PCTRBrowser.aspx");
		}


		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
