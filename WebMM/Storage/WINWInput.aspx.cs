#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace MZHMM.WebMM.Storage
{
	
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
	using Shmzh.Components.SystemComponent;
	using MZHMM.WebMM.Modules;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHMM.WebMM.Purchase;
    using SysRight = MZHMM.WebMM.Common.SysRight;

    
	/// <summary>
	/// WINWInput 的摘要说明。
	/// </summary>
	public partial class WINWInput : System.Web.UI.Page
	{
		#region 成员变量
		//private string _OP;
		//private int _EntryNo;
		//private bool IsTODO;
		protected DocWebControl doc1;
		protected DocAuditWebControl DocAuditWebControl1;
		protected WINWWebControl WINWItem;
		protected StorageDropdownlist ddlStorage ;
		protected StorageDropdownlist ddlPayStyle;
		protected StorageDropdownlist ddlChkResult;
		protected StorageDropdownlist ddlBuyer;

        WINWData oWINWData = new WINWData();
	    private int i;
	
	    ItemSystem oItemSystem = new ItemSystem();

        DataTable DT_WINW;
        DataTable DT_WDIW;
        DataTable DT_WRES;

        protected string WinStyle;

	   

	    private bool ret;
	    private WINWData MyWINWData;

	    private DataRow oDataRow;

	    private DataRow dr;

		//protected User myUser;


		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

        private string strParentEntryNo = "";
		#endregion

		#region 属性
		
		/// <summary>
		/// 当前操作。
		/// </summary>
		/// 
		//protected string Order_PrvCode
		//{
			//get {return this.txtVendorCode.Text;}
		//}
		public string Op
		{
			get 
			{
				if (this.Request["Op"] != null && this.Request["Op"] != "")
				{
					return this.Request["Op"].ToString();
				}
				else
				{
					return "View";
				}
			}
		}
		
	
		
		#endregion

		#region 私有方法
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.WINW;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.WINW;
			//初始化下拉列表。
			this.InitializeDDL();
			this.lblAuthorName.Text = Master.CurrentUser.thisUserInfo.EmpName;
			this.SetEditMode(this.Op);
			//			if (this._OP == OP.Red)	 // red


			//			{
			//				WINWData oWINWData;
			//				ItemSystem oItemSystem = new ItemSystem();
			//
			//				DataTable oDT;
			//				oWINWData = oItemSystem.GetWINWByEntryNo(this._EntryNo);
			//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Drawed )
			//				{
			//					oWINWData = oItemSystem.GetWDRWRedByEntryNo(_EntryNo);
			//					oDT = oWINWData.Tables[WINWData.WDRW_TABLE];
			//					this.item1.thisTable = oDT;
			//			
			//					if (oDT.Rows.Count > 0)
			//					{
			//						//台头部分。
			//						this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//						this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
			//						this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
			//						//审批段。
			//						this.DocAuditWebControl1.lblAduitName1.Text = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
			//						this.DocAuditWebControl1.lblAuditName2.Text = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
			//						this.DocAuditWebControl1.lblAuditName3.Text = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
			//
			//						if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != System.DBNull.Value)
			//						{
			//							this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y"? 0:1;
			//						}
			//						if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != System.DBNull.Value)
			//						{
			//							this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y"? 0:1;
			//						}
			//						if(oDT.Rows[0][InItemData.AUDIT3_FIELD] != System.DBNull.Value)
			//						{
			//							this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y"? 0:1;
			//						}
			//						this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
			//						this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
			//						this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
			//						try
			//						{
			//							this.DocAuditWebControl1.txtAuditDate1.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToShortDateString();
			//							this.DocAuditWebControl1.txtAuditDate2.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToShortDateString();
			//							this.DocAuditWebControl1.txtAuditDate3.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToShortDateString();
			//						}
			//						catch
			//						{}
			//						//申请部门。
			//						this.ddlDept.SelectedValue = oDT.Rows[0][WINWData.REQDEPT_FIELD].ToString();
			//						this.ddlDept.SelectedText = oDT.Rows[0][WINWData.REQDEPTNAME_FIELD].ToString();
			//
			//						//申请人。
			//						//this.txtProposer.Text = oDT.Rows[0][WINWData.PROPOSER_FIELD].ToString();
			//
			//						this.ddlProposer.DeptCode = oDT.Rows[0][WINWData.REQDEPT_FIELD].ToString();
			//
			//						this.ddlProposer.SelectedText = oDT.Rows[0][WINWData.PROPOSER_FIELD].ToString();
			//						this.ddlProposer.SelectedValue = oDT.Rows[0][WINWData.PROPOSERCODE_FIELD].ToString();
			//
			//
			//						if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
			//						{
			//							//this.ddlPurpose.Disabled  = true;
			//							this.ddlDept.thisDDL.Enabled = false;
			//							//this.txtProposer.Enabled = false;
			//						}
			//						//发料仓库。
			//						this.ddlStorage.SelectedText = oDT.Rows[0][WINWData.STONAME_FIELD].ToString();
			//						this.ddlStorage.SelectedValue = oDT.Rows[0][WINWData.STOCODE_FIELD].ToString();
			//						//用途。
			//						//this.ddlPurpose.SelectedText = oDT.Rows[0][WINWData.REQREASON_FIELD].ToString();
			//						//this.ddlPurpose.SelectedValue = oDT.Rows[0][WINWData.REQREASONCODE_FIELD].ToString();
			//						this.item1.ReqReasonCode = oDT.Rows[0][WINWData.REQREASONCODE_FIELD].ToString();
			//						this.item1.ReqReason = oDT.Rows[0][WINWData.REQREASON_FIELD].ToString();
			//						this.item1.StoCode = oDT.Rows[0][WINWData.STOCODE_FIELD].ToString();
			//						//备注。
			//						this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
			//						this.txtParentEntryNo.Text = oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString();
			//					}
			//					else
			//					{
			//						this.Response.Write("<Script>alert('领料单出红字的前提条件是该单据已发料！');</Script>");
			//						this.Response.Redirect("DRWBrowser.aspx",true);
			//					}
			//				}
			//			}

		}
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{

		    DT_WINW = new DataTable();
		    DT_WDIW = new DataTable();
		    DT_WRES = new DataTable();

			this.doc1.DocCode = DocType.WINW;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.WINW;
			//初始化下拉列表。			
			this.InitializeDDL();

            if (this.Op == OP.Red)
            {
                oWINWData = oItemSystem.GetWINWOldByEntryNo(Master.EntryNo);
                if (oWINWData.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据已经作过红字操作不可以再次进行红字操作！');document.location='WINWBrowser.aspx?DocCode=17';", true);
                    return;
                }

                oWINWData = oItemSystem.GetWINWRedByEntryNo(Master.EntryNo);
                strParentEntryNo = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ParentEntryNo_Field].ToString();
                if (strParentEntryNo != "")
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据是红字操作单据不可以再次进行红字操作！');document.location='WINWBrowser.aspx?DocCode=17';", true);
                    return;
                }
               


            }
            else
            {
                oWINWData = oItemSystem.GetWINWByEntryNo(Master.EntryNo);
                strParentEntryNo = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ParentEntryNo_Field].ToString();
            }

			//将单据填充到数据集,DataGrid绑定数据源。
			
			if (this.Op == OP.I)
			{
				for (i=0; i< oWINWData.Tables[WINWData.WDIW_TABLE].Rows.Count; i++)
				{
					oWINWData.Tables[WINWData.WDIW_TABLE].Rows[i][WINWData.ItemNum_Field] = oWINWData.Tables[WINWData.WDIW_TABLE].Rows[i][WINWData.PlanNum_Field];
				}
			}
			DT_WINW = oWINWData.Tables[WINWData.WINW_TABLE];
			DT_WDIW = oWINWData.Tables[WINWData.WDIW_TABLE];
			DT_WRES = oWINWData.Tables[WINWData.WRES_TABLE];

			this.WINWItem.thisTable = DT_WDIW;
			this.WINWItem.WRESTable = DT_WRES;
			
			if (DT_WINW.Rows.Count > 0)
			{

               

                if (this.Op == OP.Red)
                {
                    this.txtParentEntryNo.Value = Master.EntryNo.ToString();
                }
                else
                {
                    this.txtParentEntryNo.Value = strParentEntryNo;
                }

				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(DT_WINW.Rows[0][WINWData.EntryNo_Field].ToString());
				this.doc1.EntryCode = DT_WINW.Rows[0][WINWData.EntryCode_Field].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(DT_WINW.Rows[0][WINWData.EntryDate_Field].ToString());
				//审批人。
				this.DocAuditWebControl1.AuditName1= DT_WINW.Rows[0][WINWData.Assessor1_Field].ToString();
                this.DocAuditWebControl1.Auditor1 = DT_WINW.Rows[0][WINWData.Assessor1_Field].ToString();
				this.DocAuditWebControl1.AuditName2 = DT_WINW.Rows[0][WINWData.Assessor2_Field].ToString();
                this.DocAuditWebControl1.Auditor2 = DT_WINW.Rows[0][WINWData.Assessor2_Field].ToString();
                this.DocAuditWebControl1.AuditName3 = DT_WINW.Rows[0][WINWData.Assessor3_Field].ToString();
                this.DocAuditWebControl1.Auditor3 = DT_WINW.Rows[0][WINWData.Assessor3_Field].ToString();
                //审批。
				if (DT_WINW.Rows[0][WINWData.Audit1_Field] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit1.SelectedIndex = DT_WINW.Rows[0][WINWData.Audit1_Field].ToString() == "Y"? 0:1;
				}
				if (DT_WINW.Rows[0][WINWData.Audit2_Field] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit2.SelectedIndex = DT_WINW.Rows[0][WINWData.Audit2_Field].ToString() == "Y"? 0:1;
				}
				if(DT_WINW.Rows[0][WINWData.Audit3_Field] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit3.SelectedIndex = DT_WINW.Rows[0][WINWData.Audit3_Field].ToString() == "Y"? 0:1;
				}
				//审批意见。
				this.DocAuditWebControl1.txtAuditSuggest1.Text = DT_WINW.Rows[0][WINWData.AuditSuggest1_Field].ToString();
				this.DocAuditWebControl1.txtAuditSuggest2.Text = DT_WINW.Rows[0][WINWData.AuditSuggest2_Field].ToString();
				this.DocAuditWebControl1.txtAuditSuggest3.Text = DT_WINW.Rows[0][WINWData.AuditSuggest3_Field].ToString();
				//审批日期。
				try
				{
					this.DocAuditWebControl1.txtAuditDate1.Text = Convert.ToDateTime(DT_WINW.Rows[0][WINWData.AuditDate1_Field].ToString()).ToString("yyyy-MM-dd");
					this.DocAuditWebControl1.txtAuditDate2.Text = Convert.ToDateTime(DT_WINW.Rows[0][WINWData.AuditDate2_Field].ToString()).ToString("yyyy-MM-dd");
					this.DocAuditWebControl1.txtAuditDate3.Text = Convert.ToDateTime(DT_WINW.Rows[0][WINWData.AuditDate3_Field].ToString()).ToString("yyyy-MM-dd");
				}
				catch
				{}
				//供应商。
				this.txtVendorCode.Value = DT_WINW.Rows[0][WINWData.PrvCode_Field].ToString();
				this.txtVendor1.Text = DT_WINW.Rows[0][WINWData.PrvName_Field].ToString();
				//仓库。
				this.ddlStorage.SelectedValue = DT_WINW.Rows[0][WINWData.StoCode_Field].ToString();
				this.ddlStorage.SelectedText = DT_WINW.Rows[0][WINWData.StoName_Field].ToString();				
				//付款方式。
				this.ddlPayStyle.SelectedValue = DT_WINW.Rows[0][WINWData.PayStyle_Field].ToString();
				this.ddlPayStyle.SelectedText = DT_WINW.Rows[0][WINWData.PayStyle_Field].ToString();				
				//检验结果。
				this.ddlChkResult.SelectedValue = DT_WINW.Rows[0][WINWData.ChkNo_Field].ToString();
				this.ddlChkResult.SelectedText = DT_WINW.Rows[0][WINWData.ChkResult_Field].ToString();				
				//采购员。
				this.ddlBuyer.SelectedValue = DT_WINW.Rows[0][WINWData.BuyerCode_Field].ToString();
				this.ddlBuyer.SelectedText = DT_WINW.Rows[0][WINWData.BuyerName_Field].ToString();
				//发票号。
				this.txtInvoiceNo.Text = DT_WINW.Rows[0][WINWData.InvoiceNo_Field].ToString();
				//采购合同编号。
				this.txtContractCode.Text = DT_WINW.Rows[0][WINWData.ContractCode_Field].ToString();
				//加工费用。
				this.WINWItem.TotalFee = Convert.ToDecimal(DT_WINW.Rows[0][WINWData.FeeTotal_Field].ToString());
				//制单人。
				this.lblAuthorName.Text = DT_WINW.Rows[0][WINWData.AuthorName_Field].ToString();
				//备注。
				this.WINWItem.Remark = DT_WINW.Rows[0][WINWData.Remark_Field].ToString();
				//发料模式下初始化发料人和日期。
                if (this.Op == OP.I) this.lblStoManager.Text = Master.CurrentUser.thisUserInfo.EmpName;
				//设置界面的编辑模式。
				this.SetEditMode(this.Op)					;
			}
		}
		/// <summary>
		/// 初始化下拉列表。
		/// </summary>
		private void InitializeDDL()
		{
			this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
			this.ddlStorage.AutoPostBack = false;
			//this.ddlStorage.Width = "100%";

			//this.txtVendor1.Module_Tag = (int)SDDLTYPE.VENDOR;
			//this.txtVendor1.AutoPostBack = false;
			//this.txtVendor1.Width = "100%";

			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			this.ddlPayStyle.AutoPostBack = false;
			//this.ddlPayStyle.Width = "100%";

			this.ddlChkResult.Module_Tag = (int)SDDLTYPE.CheckResult;
			this.ddlChkResult.AutoPostBack = false;
			//this.ddlChkResult.Width = "100%";

			this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlBuyer.AutoPostBack = false;
			//this.ddlBuyer.Width = "100%";
		}
		/// <summary>
		/// 设置界面的编辑模式。
		/// </summary>
        /// <param name="O">string:	当前操作。</param>
		private void SetEditMode(string O)
		{
			switch(O)
			{
				case OP.New:
					//this.txtVendor1.Enable = true;
					this.ddlStorage.Enable = true;
					this.ddlPayStyle.Enable = true;
					this.ddlChkResult.Enable = true;
					this.ddlBuyer.Enable = true;
					break;
				case OP.Red:
					//this.txtVendor1.Enable = true;
					this.ddlStorage.Enable = true;
					this.ddlPayStyle.Enable = true;
					this.ddlChkResult.Enable = true;
					this.ddlBuyer.Enable = true;
					break;
				case OP.Edit:
					//this.txtVendor1.Enable = true;
					this.ddlStorage.Enable = true;
					this.ddlPayStyle.Enable = true;
					this.ddlChkResult.Enable = true;
					this.ddlBuyer.Enable = true;
					break;
				case OP.Submit:
					//this.txtVendor1.Enable = false;
					this.ddlStorage.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlChkResult.Enable = false;
					this.ddlBuyer.Enable = false;
					this.txtContractCode.ReadOnly = true;
					this.txtInvoiceNo.ReadOnly = true;
					break;
				case OP.FirstAudit:
					//this.txtVendor1.Enable = false;
					this.ddlStorage.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlChkResult.Enable = false;
					this.ddlBuyer.Enable = false;
					this.txtContractCode.ReadOnly = true;
					this.txtInvoiceNo.ReadOnly = true;
					break;
				case OP.SecondAudit:
					//this.txtVendor1.Enable = false;
					this.ddlStorage.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlChkResult.Enable = false;
					this.ddlBuyer.Enable = false;
					this.txtContractCode.ReadOnly = true;
					this.txtInvoiceNo.ReadOnly = true;
					break;
				case OP.ThirdAudit:
					//this.txtVendor1.Enable = false;
					this.ddlStorage.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlChkResult.Enable = false;
					this.ddlBuyer.Enable = false;
					this.txtContractCode.ReadOnly = true;
					this.txtInvoiceNo.ReadOnly = true;
					break;
				case OP.I:
					//this.txtVendor1.Enable = false;
					this.ddlStorage.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlChkResult.Enable = false;
					this.ddlBuyer.Enable = false;
					this.txtContractCode.ReadOnly = true;
					this.txtInvoiceNo.ReadOnly = true;
					break;
				default:
					break;
			}
		}
		/// <summary>
		/// 设置审批数据。
		/// </summary>
		private void SetAuditData()
		{
			switch (this.Op)
			{
				case OP.FirstAudit:
					break;
				case OP.SecondAudit:
					break;
				case OP.ThirdAudit:
					break;
			}
		}
		/// <summary>
		/// 数据填充。
		/// </summary>
		/// <param name="oWINWData">WINWData:	领料单实体。</param>
		private void FillData(WINWData oWINWData)
		{
			#region WINW DataTable 数据填充。
			
			dr = oWINWData.Tables[WINWData.WINW_TABLE].NewRow();
			//单据台头部分内容。
			dr[WINWData.EntryNo_Field] = doc1.EntryNo;						//单据流水号。
			dr[WINWData.EntryCode_Field] = doc1.EntryCode;					//单据编号。
			dr[WINWData.DocCode_Field] = doc1.DocCode;						//单据类型。
			dr[WINWData.DocName_Field] = doc1.DocName;						//单据类型名称。
			dr[WINWData.DocNo_Field] = doc1.DocNo;							//单据文档编号。
			dr[WINWData.EntryDate_Field] = DateTime.Now;					//单据日期。
			dr[WINWData.PrvCode_Field] = this.txtVendorCode.Value;
			dr[WINWData.PrvName_Field] = this.txtVendor1.Text;
			dr[WINWData.StoCode_Field] = this.ddlStorage.SelectedValue;
			dr[WINWData.StoName_Field] = this.ddlStorage.SelectedText;
			dr[WINWData.InvoiceNo_Field] = this.txtInvoiceNo.Text;
			dr[WINWData.ContractCode_Field] = this.txtContractCode.Text;
			dr[WINWData.PayStyle_Field] = this.ddlPayStyle.SelectedValue;
			dr[WINWData.FeeTotal_Field] = this.WINWItem.TotalFee;
			dr[WINWData.BuyerCode_Field] = this.ddlBuyer.SelectedValue;
			dr[WINWData.BuyerName_Field] = this.ddlBuyer.SelectedText;
			//dr[WINWData.ChkNo_Field] = Convert.ToInt16(this.ddlChkResult.SelectedValue);
			dr[WINWData.ChkResult_Field] = this.ddlChkResult.SelectedText;
			dr[WINWData.Remark_Field] = this.WINWItem.Remark;					//备注。
			try
			{
				dr[WINWData.ParentEntryNo_Field]= this.txtParentEntryNo.Value;	//红字父单据号。
			}
			catch
			{}
			dr[WINWData.Audit1_Field] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[WINWData.Audit2_Field] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[WINWData.Audit3_Field] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
			dr[WINWData.AuditSuggest1_Field] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[WINWData.AuditSuggest2_Field] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[WINWData.AuditSuggest3_Field] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
			
			oWINWData.Tables[WINWData.WINW_TABLE].Rows.Add(dr);
			#endregion
			#region WDIW DataTable 数据填充。
			for (i = 0; i< this.WINWItem.thisTable.Rows.Count; i++)
			{
				dr = oWINWData.Tables[WINWData.WDIW_TABLE].NewRow();
				dr[WINWData.SerialNo_Field] = i;
				dr[WINWData.ItemCode_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemCode_Field];
				dr[WINWData.ItemName_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemName_Field];
				dr[WINWData.ItemSpec_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemSpec_Field];
				dr[WINWData.ItemUnit_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemUnit_Field];
				dr[WINWData.ItemUnitName_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemUnitName_Field];
				dr[WINWData.PlanNum_Field] = this.WINWItem.thisTable.Rows[i][WINWData.PlanNum_Field];
				dr[WINWData.ItemNum_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemNum_Field];
				dr[WINWData.ItemPrice_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemPrice_Field];
				dr[WINWData.ItemFee_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemFee_Field];
				dr[WINWData.ItemMoney_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemMoney_Field];
				dr[WINWData.ItemSum_Field] = this.WINWItem.thisTable.Rows[i][WINWData.ItemSum_Field];
				oWINWData.Tables[WINWData.WDIW_TABLE].Rows.Add(dr);
			}
			#endregion
			#region WRES DataTable 数据填充。
			for (i = 0; i < this.WINWItem.WRESTable.Rows.Count; i++)
			{
				dr = oWINWData.Tables[WINWData.WRES_TABLE].NewRow();
				dr[WINWData.SourceEntryNo_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.SourceEntryNo_Field];
				dr[WINWData.SourceDocCode_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.SourceDocCode_Field];
				dr[WINWData.SouceSerialNo_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.SouceSerialNo_Field];
				dr[WINWData.PSerialNo_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.PSerialNo_Field];
				dr[WINWData.ResSerialNo_Field] = i;
				dr[WINWData.ResCode_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResCode_Field];
				dr[WINWData.ResName_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResName_Field];
				dr[WINWData.ResSpecial_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResSpecial_Field];
				dr[WINWData.ResUnit_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResUnit_Field];
				dr[WINWData.ResUnitName_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResUnitName_Field];
				dr[WINWData.ResNum_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResNum_Field];
				dr[WINWData.ResPrice_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResPrice_Field];
				dr[WINWData.ResMoney_Field] = this.WINWItem.WRESTable.Rows[i][WINWData.ResMoney_Field];
				oWINWData.Tables[WINWData.WRES_TABLE].Rows.Add(dr);
			}
			#endregion

			this.SetEntryOperator(oWINWData, this.Op);

			this.SetEntryState(oWINWData, this.Op);
		}
		/// <summary>
		/// 设置单据状态。
		/// </summary>
		/// <param name="oWINWData">WINWData:	领料单数据实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(WINWData oWINWData, string OpMode)
		{
			if ( oWINWData.Count > 0)
			{
				oDataRow = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0];
				oDataRow[WINWData.EntryState_Field] = new Entry(oWINWData.Tables[WINWData.WINW_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// 设置单据操作人。
		/// </summary>
		/// <param name="oWINWData">WINWData:	领料单数据实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryOperator(WINWData oWINWData, string OpMode)
		{
			if ( oWINWData.Count > 0)
			{
				oDataRow = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://新建。
						oDataRow[WINWData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[WINWData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[WINWData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[WINWData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[WINWData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Red:  //红字。
						goto case OP.New;
					case OP.NewAndPresent:
						goto case OP.New;
					case OP.Edit://编辑。
						goto case OP.New;
					case OP.EditAndPresent:
						goto case OP.New;
					case OP.FirstAudit://一级审批。
						oDataRow[WINWData.Assessor1_Field] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[WINWData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.SecondAudit://二级审批。
                        oDataRow[WINWData.Assessor2_Field] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[WINWData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.ThirdAudit://三级审批。
                        oDataRow[WINWData.Assessor3_Field] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[WINWData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.I:   //收料。
                        oDataRow[WINWData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[WINWData.StoManagerCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[WINWData.StoManager_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						break;
				}
			}
		}

		#endregion
		
		#region 事件
		/// <summary>
		/// 页面的Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Session[MySession.Help] = HelpCode.DRW;
			// 在此处放置用户代码以初始化页面
            txtVendor1.Attributes.Add("ReadOnly", "ReadOnly");
            WINWItem.IsDisplayWINWPrice = Master.DisplayBORPrice;
          //  txtInvoiceNo.Attributes.Add("ReadOnly","ReadOnly");
           // txtContractCode.Attributes.Add("ReadOnly","ReadOnly");
            if (!this.IsPostBack)
            {

                if (new ItemSystem().CheckPreconditionOfWINW(Master.EntryNo, this.Op, Master.CurrentUser.thisUserInfo.LoginName))
                {
                    switch (Op)
                    {
                        case OP.New:
                            if (!Master.HasBrowseRight(SysRight.WINWMaintain))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataNew();
                            this.btnSave.Text = OPName.New;
                            WinStyle = "";
                            break;
                        case OP.Red:
                            if (!Master.HasBrowseRight(SysRight.WINWRed))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            WinStyle = "display:none;visibility:hidden;";
                            this.btnSave.Text = OPName.New;
                            break;
                        case OP.Edit:
                            if (!Master.HasBrowseRight(SysRight.WINWMaintain))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            WinStyle = "";
                            this.btnSave.Text = OPName.Edit;
                            break;
                        case OP.Submit:
                            if (!Master.HasBrowseRight(SysRight.WINWPresent))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            WinStyle = "";
                            this.btnSave.Text = OPName.Submit;
                            this.Image1.Visible = false;
                            this.btnPresent.Visible = false;
                            break;
                        case OP.FirstAudit:
                            if (!Master.HasBrowseRight(SysRight.WINWFirstAudit))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.FirstAudit;
                            WinStyle = "display:none;visibility:hidden;";
                            this.Image1.Visible = false;
                            this.btnPresent.Visible = false;
                            break;
                        case OP.SecondAudit:
                            if (!Master.HasBrowseRight(SysRight.WINWSecondAudit))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.SecondAudit;
                            WinStyle = "display:none;visibility:hidden;";
                            this.btnPresent.Visible = false;
                            break;
                        case OP.ThirdAudit:
                            if (!Master.HasBrowseRight(SysRight.WINWThirdAudit))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.ThirdAudit;
                            WinStyle = "display:none;visibility:hidden;";
                            this.Image1.Visible = false;
                            this.btnPresent.Visible = false;
                            break;
                        case OP.I:
                            if (!Master.HasBrowseRight(SysRight.StockIn))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.I;
                            WinStyle = "display:none;visibility:hidden;";
                            this.btnPresent.Visible = false;
                            this.Image1.Visible = false;
                            break;
                    }
                }
                else
                {
                    this.BindDataUpdate();
                    //this.Response.Write("<script>alert('单据的当前状态不允许进行当前操作！');window.history.go(-1);</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('单据的当前状态不允许进行当前操作!');window.history.go(-1);", true);
                    return;
                }


               
            }
            else
            {
                if (Op == OP.I)
                {
                    WinStyle = "display:none;visibility:hidden;";
                }
            }

            if (strParentEntryNo != "" || this.Op == OP.Red)
            {
                WinStyle = "display:none;visibility:hidden;";
                this.Image1.Visible = false;
                ddlStorage.Enable = false;
                txtInvoiceNo.Attributes.Add("ReadOnly", "ReadOnly");
                txtContractCode.Attributes.Add("ReadOnly", "ReadOnly");
                ddlPayStyle.Enable = false;
                ddlChkResult.Enable = false;
                ddlBuyer.Enable = false;
             
            }
		}
		/// <summary>
		/// 保存按钮。
		/// </summary>
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//没有内容
            if (this.WINWItem.thisTable.Rows.Count == 0) 
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }


            if (this.WINWItem.WRESTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有消耗物料内容!');", true);
                return;
            }

			//构建数据实体.
			oWINWData = new WINWData();
			this.FillData(oWINWData);
			
			
			ret = false;
			switch (this.Op)
			{
					#region New
				case OP.New:
                    if (this.txtInvoiceNo.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('发票号不能为空');", true);

                        return;
                    }

                    if (txtVendor1.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('供应商信息不能为空');", true);

                        return;
                    }
					if (Master.HasRight(SysRight.WINWMaintain))
					{
						ret = oItemSystem.AddWINW(oWINWData);
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region 红字
				case OP.Red:
                    if (Master.HasRight(SysRight.WINWRed))
					{
						ret = oItemSystem.AddWINW(oWINWData);
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region Edit
				case OP.Edit:
                    if (this.txtInvoiceNo.Text == "")
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "delete", "alert('发票号不能为空');",true);
                        // ScriptManager.RegisterStartupScript(this.btnSave, this.GetType(), "delete", "alert('发票号不能为空');");

                        return;
                    }

                    if (txtVendor1.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('供应商信息不能为空');", true);

                        return;
                    }

					if (Master.HasRight(SysRight.WINWMaintain))
					{
						ret = oItemSystem.UpdateWINW(oWINWData);
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region Submit
				case OP.Submit:
                    if (this.txtInvoiceNo.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('发票号不能为空');", true);

                        return;
                    }
                    if (Master.HasRight(SysRight.WINWPresent))
					{
						ret = oItemSystem.PresentWINW(this.doc1.EntryNo,Master.CurrentUser.thisUserInfo.LoginName);
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region FirstAudit
				case OP.FirstAudit:
                    if (Master.HasRight(SysRight.WINWFirstAudit))
					{
						if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="Y" &&
							oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						else
						{
							ret = oItemSystem.FirstAuditWINW(oWINWData);
						}
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region SecondAudit
				case OP.SecondAudit:
                    if (Master.HasRight(SysRight.WINWSecondAudit))
					{
						if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() !="Y" &&
							oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
							return;
						}
						else
						{
							ret = oItemSystem.SecondAuditWINW(oWINWData);
						}
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region ThirdAudit
				case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.WINWThirdAudit))
					{
						if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() !="Y" &&
							oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
							return;
						}
						else
						{
							ret = oItemSystem.ThirdAuditWINW(oWINWData);
						}
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region I
				case OP.I:
                    if (Master.HasRight(SysRight.StockIn))
					{

                        MyWINWData = oItemSystem.GetWINWByEntryNo(Master.EntryNo);
						ret = oItemSystem.StockInWINW(oWINWData);
						
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
			}
					
			if ( ret== false)
			{
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
			else
			{
                if (Master.IsTODO)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
					if (this.Op == OP.I)
					{
						this.Response.Redirect("../Purchase/PInBrowser.aspx");
					}
					else
					{
						Response.Redirect("WINWBrowser.aspx?DocCode=17");
					}
				}
			}
		}
		/// <summary>
		/// 取消按钮事件。
		/// </summary>
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
            if (Master.IsTODO)
			{
				this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
			}
			else
			{
				if (this.Op == OP.O)
				{
                    this.Response.Redirect("../Purchase/PInBrowser.aspx");
				}
				else
				{
					Response.Redirect("WINWBrowser.aspx?DocCode=17");
				}
			}
		}
		/// <summary>
		/// 马上提交事件。
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//没有内容
            if (this.WINWItem.thisTable.Rows.Count == 0)//|| this.WINWItem.WRESTable.Rows.Count == 0) 
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            if (this.WINWItem.WRESTable.Rows.Count == 0)//|| this.WINWItem.WRESTable.Rows.Count == 0) 
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有消耗物料内容!');", true);
                return;
            }

			//构建数据实体.
			oWINWData = new WINWData();
			this.FillData(oWINWData);
			
			ret = false;
			switch (this.Op)
			{
				case OP.New:
                    if (this.txtInvoiceNo.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('发票号不能为空');", true);

                        return;
                    }
                    if (txtVendor1.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('供应商信息不能为空');", true);

                        return;
                    }
                    if (Master.HasRight(SysRight.WINWMaintain) && Master.HasRight(SysRight.WINWPresent))
					{
						this.SetEntryState(oWINWData, OP.NewAndPresent);
						this.SetEntryOperator(oWINWData, OP.NewAndPresent);
						ret = oItemSystem.AddAndPresentWINW(oWINWData);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Red:
                    if (Master.HasRight(SysRight.WINWMaintain) && Master.HasRight(SysRight.WINWPresent))
					{
						this.SetEntryState(oWINWData, OP.NewAndPresent);
						this.SetEntryOperator(oWINWData, OP.NewAndPresent);
						ret = oItemSystem.AddAndPresentWINW(oWINWData);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Edit:
                    if (this.txtInvoiceNo.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('发票号不能为空');", true);

                        return;
                    }

                    if (txtVendor1.Text == "")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('供应商信息不能为空');", true);

                        return;
                    }
                    if (Master.HasRight(SysRight.WINWMaintain) && Master.HasRight(SysRight.WINWPresent))
					{
						this.SetEntryState(oWINWData, OP.EditAndPresent);
						this.SetEntryOperator(oWINWData, OP.EditAndPresent);
						ret = oItemSystem.UpdateAndPresentWINW(oWINWData);
					}
					else
					{
						ret = false;
					}
					break;
			}
					
			if ( ret== false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
			else
			{
                if (Master.IsTODO)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
					Response.Redirect("WINWBrowser.aspx?DocCode=17");
				}
			}
		}
		#endregion

	}
}


