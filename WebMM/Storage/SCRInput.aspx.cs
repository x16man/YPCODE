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
* penalties.  Any violations of this copyright will be pSCRecuted       *
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
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHMM.WebMM.Modules;
	using Shmzh.Components.SystemComponent;
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// SCRInput 的摘要说明。
	/// </summary>
	public partial class SCRInput : System.Web.UI.Page
	{
		#region 成员变量
		private string _OP;
		//private bool IsTODO;
		//private int _EntryNo;
		protected DocWebControl doc1=new DocWebControl();
		protected SCRWebControl item1=new SCRWebControl();
		protected StorageDropdownlist ddlDept=new StorageDropdownlist();
		protected StorageDropdownlist ddlStorage = new StorageDropdownlist();
		protected USWebControl ddlPurpose = new USWebControl();
		protected DocAuditWebControl DocAuditWebControl1=new DocAuditWebControl();
		//protected User myUser;
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

	    private WSCRData oSCR;
	    private ItemSystem oItemSystem = new ItemSystem();

	    private DataRow dr;

	    private DataRow oDataRow;

	    private Col2List MyCol2List;

	    private WSCRData oSCRData;

	    private DataTable oDT;

	    private bool ret;
		#endregion
		
		#region 私有方法
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.SCR;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.SCR;
			this.ddlDept.Module_Tag=(int)SDDLTYPE.OWNDEPT;
			this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
			this.ddlDept.DocType = DocType.SCR;
            this.ddlDept.SetItemSelected(Master.CurrentUser.thisUserInfo.DeptCode);
            this.ddlDept.SelectedValue = Master.CurrentUser.thisUserInfo.DeptCode;
			this.ddlPurpose.SelectedValue = "-1";
			this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
			this.ddlStorage.Width = new Unit("90%");
            this.txtProposer.Text = Master.CurrentUser.thisUserInfo.EmpName;
		}
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{
			
			this.doc1.DocCode=11;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode=11;
			this.ddlDept.Module_Tag=(int)SDDLTYPE.OWNDEPT;
			this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
			this.ddlStorage.Width = new Unit("90%");
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
			this.ddlDept.DocType = DocType.SCR;

			//将单据填充到数据集,DataGrid绑定数据源。
			if(this._OP == OP.Discard)	//报废。
				oSCRData = oItemSystem.GetWSCRByEntryNoDiscardMode(Master.EntryNo);
			else
				oSCRData = oItemSystem.GetWSCRByEntryNo(Master.EntryNo);

			this.CheckOpPrecondition(this._OP, oSCRData);
			
			oDT = oSCRData.Tables[WSCRData.WSCR_TABLE];
			this.item1.thisTable = oDT;
			
			if (oDT.Rows.Count > 0)
			{
				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//审批段。
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                this.DocAuditWebControl1.AuditName3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
				if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y"? 0:1;
				}
				if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y"? 0:1;
				}
				if(oDT.Rows[0][InItemData.AUDIT3_FIELD] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y"? 0:1;
				}
				this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();

                try
                {
                    this.DocAuditWebControl1.txtAuditDate1.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }

				if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
				{
					this.ddlPurpose.Disabled = true;
					this.ddlDept.thisDDL.Enabled = false;
					this.txtProposer.Enabled = false;
				}
				//发料仓库。
				this.ddlStorage.SelectedText = oDT.Rows[0][WSCRData.STONAME_FIELD].ToString();
				this.ddlStorage.SelectedValue = oDT.Rows[0][WSCRData.STOCODE_FIELD].ToString();
			
				//用途。
				this.ddlPurpose.SelectedText = oDT.Rows[0][WSCRData.REQREASON_FIELD].ToString();
				this.ddlPurpose.SelectedValue= oDT.Rows[0][WSCRData.REQREASONCODE_FIELD].ToString();
				//备注。
				this.item1.TxtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//申请部门。
				this.ddlDept.SelectedText = oDT.Rows[0][WSCRData.REQDEPTNAME_FIELD].ToString();
				this.ddlDept.SelectedValue = oDT.Rows[0][WSCRData.REQDEPT_FIELD].ToString();
				//申请人。
				this.txtProposer.Text = oDT.Rows[0][WSCRData.PROPOSER_FIELD].ToString();
			}
		}
		/// <summary>
		/// 设定单据状态。
		/// </summary>
		/// <param name="oSCRData">WSCRData:	采购申请单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(WSCRData oSCRData, string OpMode)
		{
			if ( oSCRData.Count > 0)
			{
				oDataRow = oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oSCRData.Tables[0]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// 设定操作人。
		/// </summary>
		/// <param name="oSCRData">WSCRData:	采购申请单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetOperator(WSCRData oSCRData, string OpMode)
		{
			if ( oSCRData.Count > 0)
			{
				oDataRow = oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://新建。
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndPresent:
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Edit://编辑。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.EditAndPresent:
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.FirstAudit://一级审批。
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.SecondAudit://二级审批。
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.ThirdAudit://三级审批。
                        oDataRow[InItemData.ASSESSOR3_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
				}
			}
		}
		/// <summary>
		/// 填充数据集。
		/// </summary>
		/// <param name="oSCR">WSCRData:	采购申请单实体。</param>
		private void FillData(WSCRData oSCR)
		{
			dr = oSCR.Tables[WSCRData.WSCR_TABLE].NewRow();
			//单据台头部分内容。
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。
			dr[WSCRData.STONAME_FIELD] = ddlStorage.SelectedText;
			dr[WSCRData.STOCODE_FIELD] = ddlStorage.SelectedValue;
			dr[WSCRData.REQDEPT_FIELD] = ddlDept.SelectedValue;			//申请部门。
			dr[WSCRData.REQDEPTNAME_FIELD] = ddlDept.SelectedText;		//申请部门名称。
			dr[InItemData.REMARK_FIELD] = this.item1.TxtRemark.Text;				//备注。
			dr[WSCRData.PROPOSER_FIELD] = txtProposer.Text;			//申请人。			
			dr[WSCRData.REQREASON_FIELD] = ddlPurpose.SelectedText;		//用途名称。
			dr[WSCRData.REQREASONCODE_FIELD] = ddlPurpose.SelectedValue;	//用途编号。
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
			MyCol2List = new Col2List(this.item1.thisTable);
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//报废单合计金额。
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();//顺序号。
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);//物料编号。
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);//物料名称。
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);//规格型号。
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);//实废数量。
			dr[WSCRData.PLANNUM_FIELD] = MyCol2List.GetList(WSCRData.PLANNUM_FIELD);//应废数量。
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);//单位。
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);//单价。
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);//金额。
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);//单位名称。
			
			oSCR.Tables[WSCRData.WSCR_TABLE].Rows.Add(dr);
		}

		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="OpMode">string: 操作模式。</param>
		/// <param name="oSCRData">WSCRData:	单据实体。</param>
		/// <returns>bool:	前提条件满足则返回True，不满足则返回False。</returns>
		private void CheckOpPrecondition(string OpMode,WSCRData oSCRData)
		{	
			switch (OpMode)
			{
				case OP.Edit://编辑。
					if (oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WSCRData.XUpdate, true); }
					break;
				case OP.Submit://提交。
					if (oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WSCRData.XPresent, true); }
					break;
				case OP.FirstAudit://一级审批。
					if (oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WSCRData.XFirstAudit, true); }
					break;
				case OP.SecondAudit://二级审批。
					if (oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
					{	return ;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WSCRData.XSecondAudit, true); }
					break;
				case OP.ThirdAudit://三级审批。
					if (oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WSCRData.XThirdAudit, true); }
					break;
				case OP.Discard://发料。
					if (oSCRData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=该单据的当前状态，不满足报废的前提条件！", true); }
					break;
			}
		}
		
		#endregion
		
		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			// 在此处放置用户代码以初始化页面
			_OP = Request["Op"].ToString();
			//无权操作的提示信息。
			//this.AlertMessage = "<script>Alert(\""+SysRight.NoRight+"\");</script>";
            item1.IsDisplaySCRPrice = Master.DisplaySCRPrice;
			
			if(!this.IsPostBack)
			{
				
				switch (_OP)
				{
					case OP.New://新建。
						//判断权限。
						if (!Master.HasBrowseRight(SysRight.SCRMaintain))
						{	
							//this.Response.Write(this.AlertMessage);
							//this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}

						this.BindDataNew();
						this.btnSave.Text = OPName.New;
						break;
					case OP.Edit://修改。
                        if (!Master.HasBrowseRight(SysRight.SCRMaintain))
						{	
							//this.Response.Write(this.AlertMessage);
							//this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Edit;
						break;
					case OP.Submit://提交。
                        if (!Master.HasBrowseRight(SysRight.SCRPresent))
						{	
                            //this.Response.Write(this.AlertMessage);
                            //this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Submit;
						this.btnPresent.Visible = false;
						this.ddlStorage.Enable = false;
						break;
					case OP.FirstAudit://一级审批。
                        if (!Master.HasBrowseRight(SysRight.SCRFirstAudit))
						{	
                            //this.Response.Write(this.AlertMessage);
                            //this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}
						this.BindDataUpdate();
                        this.ddlPurpose.Disabled = false;
						this.btnSave.Text = OPName.FirstAudit;
						this.ddlStorage.Enable = false;
						this.btnPresent.Visible = false;
						break;
					case OP.SecondAudit://二级审批。
                        if (!Master.HasBrowseRight(SysRight.SCRSecondAudit))
						{	
                            //this.Response.Write(this.AlertMessage);
                            //this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.SecondAudit;
						this.btnPresent.Visible = false;
                        this.ddlPurpose.Disabled = false;
						this.ddlStorage.Enable = false;
						break;
					case OP.ThirdAudit://三级审批。
                        if (!Master.HasBrowseRight(SysRight.SCRThirdAudit))
						{	
                            //this.Response.Write(this.AlertMessage);
                            //this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.ThirdAudit;
                        this.ddlPurpose.Disabled = false;
						this.btnPresent.Visible = false;
						this.ddlStorage.Enable = false;
						break;
					case OP.Discard://报废。
                        if (!Master.HasBrowseRight(SysRight.StockOut))
						{	
                            //this.Response.Write(this.AlertMessage);
                            //this.Response.Write("<script>window.history.go(-1);</script>");
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Discard;
                        this.ddlPurpose.Disabled = false;
						this.ddlStorage.Enable = false;
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
			oSCR = new WSCRData();
			this.FillData(oSCR);
			this.SetEntryState(oSCR,this._OP);//设定单据状态。
			this.SetOperator(oSCR,this._OP);//设定操作人。

			
			ret = true;
			switch (this._OP)
			{
                case MZHMM.Common.OP.New:	 //新建保存。
					ret = Master.HasRight(SysRight.SCRMaintain)?oItemSystem.AddWSCR(oSCR):false;
					break;
					case OP.Edit:
                    if (Master.HasRight(SysRight.SCRMaintain))
					{
						ret = oItemSystem.UpdateWSCR(oSCR);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Submit:   //提交保存。
					ret = Master.HasRight(SysRight.SCRPresent)?oItemSystem.PresentWSCR(Master.EntryNo,Master.CurrentUser.thisUserInfo.LoginName):false;
					break;
				case OP.FirstAudit:
                    if (Master.HasRight(SysRight.SCRFirstAudit))
					{
						if (oSCR.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
							oSCR.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						ret = oItemSystem.FirstAuditWSCR(oSCR);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.SecondAudit:
					if (Master.HasRight(SysRight.SCRSecondAudit))
					{
						if (oSCR.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "Y" &&
							oSCR.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						ret = oItemSystem.SecondAuditWSCR(oSCR);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.ThirdAudit:
					if (Master.HasRight(SysRight.SCRThirdAudit))
					{
						if (oSCR.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "Y" &&
							oSCR.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
							return;
						}
						ret = oItemSystem.ThirdAuditWSCR(oSCR);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Discard:
                    if (Master.HasRight(SysRight.StockOut))
					{
						Session[MySession.DrawDt] = this.item1.thisTable;
						this.Response.Redirect("ConChooser.aspx?DocCode=11&SrcStoName="+this.ddlStorage.SelectedText+"&EntryNo="+this.doc1.EntryNo.ToString()+"&Op="+OP.Discard);
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
				//Response.Write("Success!");
				//this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
				if (Master.IsTODO)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else 
				{
					if (this._OP == OP.Discard)
					{
						Response.Redirect("OutBrowser.aspx");	
					}
					else
					{
						Response.Redirect("SCRBrowser.aspx");
					}
				}
			}
		}
		/// <summary>
		/// 取消按钮事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
            if (Master.IsTODO)
			{
				this.Response.Write("<script>window.close();</script>");
			}
			else
			{
				if(this._OP==OP.Discard)
					Response.Redirect("OutBrowser.aspx");
				else
					Response.Redirect("SCRBrowser.aspx");
			}
		}
		/// <summary>
		/// 提交
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

			//构建数据实体.
			 oSCR = new WSCRData();
			this.FillData(oSCR);
			
			
			ret = true;
			switch (this._OP)
			{
				case OP.New:
					this._OP = OP.NewAndPresent;
					this.SetEntryState(oSCR,this._OP);//设定单据状态。
					this.SetOperator(oSCR,this._OP);//设定操作人。
					ret = oItemSystem.AddAndPresentWSCR(oSCR);
					break;
				case OP.Edit:
					this._OP = OP.NewAndPresent;
					this.SetEntryState(oSCR,this._OP);//设定单据状态。
					this.SetOperator(oSCR,this._OP);//设定操作人。
					ret = oItemSystem.UpdateAndPresentWSCR(oSCR);
					break;
			}
					
			if ( ret== false)
			{
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
			else
			{
				//Response.Write("Success!");
				//this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
                if (Master.IsTODO)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
					Response.Redirect("SCRBrowser.aspx");
				}
			}
		}
		#endregion
	}
}