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

namespace MZHMM.WebMM.Purchase
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
	using MZHCommon.Database;
	using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// MRPInput 的摘要说明。
	/// </summary>
	public partial class CancelInput : System.Web.UI.Page
	{
		#region 成员变量
		private string _OP;
		//private bool IsTODO;
		protected DocWebControl doc1=new DocWebControl();
		protected DocAuditWebControl DocAuditWebControl1;
		protected CancelWebControl item1=new CancelWebControl();
		protected StorageDropdownlist ddlStoManager =new StorageDropdownlist();
		//protected StorageDropdownlist ddlCurrency = new StorageDropdownlist();
		protected StorageDropdownlist ddlPayStyle = new StorageDropdownlist();
		public    POSBrowser fp;
		protected int _EntryNo;
		//protected User myUser;
		//protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel1;
		//protected System.Web.UI.WebControls.TextBox txtAuthorDeptName;
		
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

		private PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		private POSData oPOSData = new POSData();

		CancelData oCancelData;
		DataTable oDT;

		private DataRow oDataRow;

		private bool bret;
		#endregion

		#region 私有方法
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.CANCEL;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.CANCEL;

		  
			//fp = (POSBrowser)Context.Handler;

			//POSData oPOSData = oPurchaseSystem.GetPOSByPKIDs(fp.DGModel_Items1.SelectedArray);
		   
			this.item1.thisTable = oPOSData.Tables[POSData.VPOS_VIEW];
			this.txtAuthorName.Text = Master.CurrentUser.thisUserInfo.EmpName;
			this.txtAuthorDeptName.Text = Master.CurrentUser.thisUserInfo.DeptName;
		}
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{
			this.DocAuditWebControl1.DocCode = DocType.CANCEL;
			this._EntryNo = Convert.ToInt32(Request["EntryNo"].ToString());
		   
			this.doc1.DocCode = DocType.CANCEL;
			this.doc1.DataBindUpdate();
			//将单据填充到数据集,DataGrid绑定数据源。
			oCancelData = oPurchaseSystem.GetCancelByEntryNo(_EntryNo);
			//检查操作的前提条件。
			this.CheckOpPrecondition(this._OP, oCancelData);
			oDT = oCancelData.Tables[CancelData.PCOR_Table];
			this.item1.thisTable = oDT;

			if (oDT.Rows.Count > 0)
			{
				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][CancelData.EntryNo_Field].ToString());
				this.doc1.EntryCode = oDT.Rows[0][CancelData.EntryCode_Field].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][CancelData.EntryDate_Field].ToString());
				//申请人与部门.
				this.txtAuthorName.Text = oDT.Rows[0][CancelData.AuthorName_Field].ToString();
				this.txtAuthorDeptName.Text = oDT.Rows[0][CancelData.AuthorDeptName_Field].ToString();
				//备注。
				this.item1.txtRemark.Text = oDT.Rows[0][CancelData.Remark_Field].ToString();
				//审批段。
				//this.DocAuditWebControl1.lblAduitName1.Text = oDT.Rows[0][CancelData.Assessor1_Field].ToString();
				//this.DocAuditWebControl1.lblAuditName2.Text = oDT.Rows[0][CancelData.Assessor2_Field].ToString();
				//this.DocAuditWebControl1.lblAuditName3.Text = oDT.Rows[0][CancelData.Assessor3_Field].ToString();

				this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][CancelData.Assessor1_Field].ToString();
				this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][CancelData.Assessor2_Field].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][CancelData.Assessor3_Field].ToString();

				if (oDT.Rows[0][CancelData.Audit1_Field] != DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][CancelData.Audit1_Field].ToString() == "Y" ? 0 : 1;
				}
				if (oDT.Rows[0][CancelData.Audit2_Field] != DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][CancelData.Audit2_Field].ToString() == "Y" ? 0 : 1;
				}
				if (oDT.Rows[0][CancelData.Audit3_Field] != DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][CancelData.Audit3_Field].ToString() == "Y" ? 0 : 1;
				}
				this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][CancelData.AuditSuggest1_Field].ToString();
				this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][CancelData.AuditSuggest2_Field].ToString();
				this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][CancelData.AuditSuggest3_Field].ToString();

				try
				{
					this.DocAuditWebControl1.txtAuditDate1.Text = DateTime.Parse(oDT.Rows[0][CancelData.AuditDate1_Field].ToString()).ToString("yyyy-MM-dd");
					this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][CancelData.AuditDate2_Field].ToString()).ToString("yyyy-MM-dd");
					this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][CancelData.AuditDate3_Field].ToString()).ToString("yyyy-MM-dd");
				}
				catch { }
			}
		}

		/*
		/// <summary>
		/// 设置指定下拉列表的选中项。
		/// </summary>
		/// <param name="List">DropDownList：下拉列表。</param>
		/// <param name="TargetValue">string:	指定值。</param>
		private void SetSelectedItem(DropDownList List ,string TargetValue)
		{
			for (int i = 0; i < List.Items.Count; i++)
			{
				if (List.Items[i].Value == TargetValue)
				{
					List.Items[i].Selected = true;
					List.SelectedIndex = i;
					List.SelectedValue = List.Items[i].Value;
					break;
				}
			}
		}*/
		
		/// <summary>
		/// 设置单据状态。
		/// </summary>
		/// <param name="oCancelData">PurchaseOrderData:	采购订单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(CancelData oCancelData, string OpMode)
		{
			if (oCancelData.Count > 0)
			{
				oDataRow = oCancelData.Tables[CancelData.PCOR_Table].Rows[0];
				oDataRow[CancelData.EntryState_Field] = new Entry(oCancelData.Tables[CancelData.PCOR_Table]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// 设置单据操作人。
		/// </summary>
		/// <param name="oCancelData">PurchaseOrderData:	采购订单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetOperator(CancelData oCancelData, string OpMode)
		{
			if (oCancelData.Count > 0)
			{
				oDataRow = oCancelData.Tables[CancelData.PCOR_Table].Rows[0];

				switch (OpMode)
				{
					case OP.New://新建。
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndPresent://新建并且提交。
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndAssign://新建并且指派。
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Edit://编辑。
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.EditAndPresent://编辑并且提交。
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] =  Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.EditAndAssign:
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.FirstAudit://一级审批。
						oDataRow[CancelData.Assessor1_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.SecondAudit://二级审批。
						oDataRow[CancelData.Assessor2_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.ThirdAudit://三级审批。
						oDataRow[CancelData.Assessor3_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
				}
			}
		}

		/// <summary>
		/// 填充数据集。
		/// </summary>
		/// <param name="oCancelData">PurchaseOrderData:	采购订单实体。</param>
		private void FillData(CancelData oCancelData)
		{
			DataRow dr = oCancelData.Tables[CancelData.PCOR_Table].NewRow();
			//单据台头部分内容。
			dr[CancelData.EntryNo_Field] = doc1.EntryNo;							//单据流水号。
			dr[CancelData.EntryCode_Field] = doc1.EntryCode;						//单据编号。
			dr[CancelData.DocCode_Field] = doc1.DocCode;							//单据类型。
			dr[CancelData.DocName_Field] = doc1.DocName;							//单据类型名称。
			dr[CancelData.DocNo_Field] = doc1.DocNo;								//单据文档编号。
			dr[CancelData.EntryDate_Field] = DateTime.Now;							//单据日期。

			dr[CancelData.Remark_Field] = this.item1.txtRemark.Text;				//备注。
			//审批段。
			dr[CancelData.Audit1_Field] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[CancelData.Audit2_Field] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[CancelData.Audit3_Field] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。

			dr[CancelData.AuditSuggest1_Field] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[CancelData.AuditSuggest2_Field] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[CancelData.AuditSuggest3_Field] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
			//子项明细。
			Col2List MyCol2List = new Col2List(this.item1.thisTable);
			dr[CancelData.SerialNo_Field] = MyCol2List.GetList();
			dr[CancelData.SourceEntry_Field] = MyCol2List.GetList(PurchaseOrderData.SOURCEENTRY_FIELD);
			dr[CancelData.SourceDocCode_Field] = MyCol2List.GetList(PurchaseOrderData.SOURCEDOCCODE_FIELD);
			dr[CancelData.SourceSerialNo_Field] = MyCol2List.GetList(PurchaseOrderData.SOURCESERIALNO_FIELD);
			dr[CancelData.ItemCode_Field] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
			dr[CancelData.ItemName_Field] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
			dr[CancelData.ItemSpec_Field] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
			dr[CancelData.ItemUnit_Field] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);
			dr[CancelData.ItemUnitName_Field] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);
			dr[CancelData.ItemPrice_Field] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);
			dr[CancelData.ItemNum_Field] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
			dr[CancelData.ItemMoney_Field] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);

			oCancelData.Tables[CancelData.PCOR_Table].Rows.Add(dr);
		}
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="OpMode">string:	操作模式。</param>
		/// <param name="oCancelData">PurchasePlanData:	物料需求单实体。</param>
		private void CheckOpPrecondition(string OpMode,CancelData oCancelData)
		{
			switch (OpMode)
			{
				case OP.Edit://编辑。
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=采购撤销单不符合修改的前提条件！", true); }
					break;
				case OP.Assigned://提交。
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=采购撤销单不符合提交的前提条件！", true); }
					break;
				case OP.FirstAudit://一级审批。
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Present)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=采购撤销单不符合一级审批的前提条件！", true); }
					break;
				case OP.SecondAudit://二级审批。
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=采购撤销单不符合二级审批的前提条件！", true); }
					break;
				case OP.ThirdAudit://三级审批。
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=采购撤销单不符合三级审批的前提条件！", true); }
					break;
			}
		}
		#endregion
		
		
		
		#region 事件
		/// <summary>
		/// 页面的Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			_OP = Request["Op"].ToString();
			txtAuthorName.Attributes.Add("ReadOnly", "ReadOnly");
		   
			//			this.ddlPrv.AutoPostBack = true;
			item1.IsDisplayCancelPrice = Master.DisplayCancelPrice;

			if (!this.IsPostBack)
			{
				switch (_OP)
				{
					case OP.New:
						if (!Master.HasBrowseRight(SysRight.CancelMaintain))
						{
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
							return;
						}
						this.BindDataNew();
						this.btnSave.Text = OPName.New;
						this.btnPresent.Visible = true;
						break;
					case OP.Edit:
						if (!Master.HasBrowseRight(SysRight.CancelMaintain))
						{
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Edit;
						this.btnPresent.Visible = true;
						break;
					case OP.Submit:
						if (!Master.HasBrowseRight(SysRight.CancelPresent))
						{
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Submit;
						this.btnPresent.Visible = false;
						break;
					case OP.FirstAudit:
						if (!Master.HasBrowseRight(SysRight.CancelFirstAudit))
						{
						   // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.FirstAudit;
						this.btnPresent.Visible = false;
						break;
					case OP.SecondAudit:
						if (!Master.HasBrowseRight(SysRight.CancelSecondAudit))
						{
						   // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.SecondAudit;
						this.btnPresent.Visible = false;
						break;
					case OP.ThirdAudit:
						if (!Master.HasBrowseRight(SysRight.CancelThirdAudit))
						{
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.ThirdAudit;
						this.btnPresent.Visible = false;
						break;
				}
			}
		}
		/// <summary>
		/// 保存按钮。
		/// </summary>
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//没有内容
			if (item1.thisTable.Rows.Count == 0)
			{
				ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
				return;
			}

			//构建数据实体.
			oCancelData = new CancelData();
			//填充数据集。
			this.FillData(oCancelData);
			//设置单据状态。
			this.SetEntryState(oCancelData, this._OP);
			//设置操作人。
			this.SetOperator(oCancelData, this._OP);

		   oPurchaseSystem = new PurchaseSystem();

			bret = true;
			switch (this._OP)
			{
				case OP.New:
					if (Master.HasRight(SysRight.CancelMaintain))
					{
						bret = oPurchaseSystem.AddCancel(oCancelData);
					}
					else
					{
						bret = false;
					}
					break;
				case OP.Edit:
					if (Master.HasRight(SysRight.CancelMaintain))
					{
						bret = oPurchaseSystem.UpdateCancel(oCancelData);
					}
					else
					{
						bret = false;
					}
					break;
				case OP.Submit:
					if (Master.HasRight(SysRight.CancelPresent))
					{
						bret = oPurchaseSystem.PresentCancel(this.doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
					}
					else
					{
						bret = false;
					}
					break;
				case OP.FirstAudit:
					if (Master.HasRight(SysRight.CancelFirstAudit))
					{
						if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() != "Y" &&
							oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() != "N")
						{
							ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
							return;
						}
						else
						{
							bret = oPurchaseSystem.FirstAuditCancel(oCancelData);
						}
					}
					else
					{
						bret = false;
					}
					break;
				case OP.SecondAudit:
					if (Master.HasRight(SysRight.CancelSecondAudit))
					{
						if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() != "Y" &&
							oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() != "N")
						{
							ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
							
							return;
						}
						else
						{
							bret = oPurchaseSystem.SecondAuditCacel(oCancelData);
						}
					}
					else
					{
						bret = false;
					}
					break;
				case OP.ThirdAudit:
					if (Master.HasRight(SysRight.CancelThirdAudit))
					{
						if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() != "Y" &&
							oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() != "N")
						{
							ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
							
							return;
						}
						else
						{
							bret = oPurchaseSystem.ThirdAuditCancel(oCancelData);
						}
					}
					else
					{
						bret = false;
					}
					break;
			}

			if (bret == false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
			}
			else
			{
				if (Master.IsTODO)
				{
					this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
				}
				else
				{
					Response.Redirect("CancelBrowser.aspx?DocCode=21");
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
				this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
			}
			else
			{
				Response.Redirect("CancelBrowser.aspx?DocCode=21");
			}
		}
		/// <summary>
		/// 马上指派事件。
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//没有内容
			if (item1.thisTable.Rows.Count == 0)
			{
				this.Page.RegisterStartupScript( "Error", "<script>alert('没有物料内容!');</script>");
				return;
			}

			//构建数据实体.
		   oCancelData = new CancelData();
			//填充数据集。
			this.FillData(oCancelData);
		   oPurchaseSystem = new PurchaseSystem();

			bret = true;
			switch (this._OP)
			{
				case OP.New:
					if (Master.HasRight(SysRight.CancelMaintain) && Master.HasRight(SysRight.CancelPresent))
					{
						this._OP = OP.NewAndPresent;
						//设置单据状态。
						this.SetEntryState(oCancelData, this._OP);
						//设置操作人。
						this.SetOperator(oCancelData, this._OP);
						bret = oPurchaseSystem.AddAndPresentCancel(oCancelData);
					}
					else
					{
						bret = false;
					}

					break;
				case OP.Edit:
					if (Master.HasRight(SysRight.CancelMaintain) && Master.HasRight(SysRight.CancelPresent))
					{
						this._OP = OP.NewAndPresent;
						//设置单据状态。
						this.SetEntryState(oCancelData, this._OP);
						//设置操作人。
						this.SetOperator(oCancelData, this._OP);
						bret = oPurchaseSystem.UpdateAndPresentCancel(oCancelData);
					}
					else
					{
						bret = false;
					}
					break;
			}

			if (bret == false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
			}
			else
			{
				if (Master.IsTODO)
				{
					this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
				}
				else
				{
					Response.Redirect("CancelBrowser.aspx?DocCode=21");
				}

			}
		}
		#endregion

	   
	}
}


