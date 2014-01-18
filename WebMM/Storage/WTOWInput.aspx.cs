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
    using SysRight = MZHMM.WebMM.Common.SysRight;

	/// <summary>
	/// WTOWInput 的摘要说明。
	/// </summary>
	public partial class WTOWInput : System.Web.UI.Page
	{
		#region 成员变量
		private string _OP;
		//private int _EntryNo;
		//private bool IsTODO;
		protected DocWebControl doc1;
		protected WTOWWebControl item1 ;
		protected StorageDropdownlist ddlDept;
		protected StorageDropdownlist ddlProposer;
		protected MZHMM.WebMM.Modules.USWebControl ddlPurpose;
		protected DocAuditWebControl DocAuditWebControl1;
		//protected StorageDropdownlist ddlStorage ;

		//protected User myUser;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txt;
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

        WTOWData oWTOWData = new WTOWData();
		ItemSystem oItemSystem = new ItemSystem();
	    private DataTable oDT;

	    private Col2List MyCol2List;

	    private decimal StockNum;//库存数
	    private decimal ItemNum;//发出数。
	    private string ItemCode;
	    private string ItemName;
	    private string ItemSpec;

	   // private DataRow oDataRow;

	    private DataRow dr;

	    private int EntryNo;

	    private bool ret;
      

	    private int i;

	    private int j;

        private string strParentEntryNo = "";

	    private WTOWData MyWTOWData;
		#endregion

		#region 私有方法
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			
			this.doc1.DocCode = DocType.WTOW;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.WTOW;
			this.ddlDept.AutoPostBack = true;
			this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
			this.ddlDept.DocType = DocType.WTOW;
            this.ddlDept.SelectedValue = Master.CurrentUser.thisUserInfo.DutyCode;
            this.ddlDept.SelectedText = Master.CurrentUser.thisUserInfo.DeptName;
		
			this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;
			this.ddlProposer.IsClear = true;
            this.ddlProposer.DeptCode = Master.CurrentUser.thisUserInfo.DeptCode;
            this.ddlProposer.SelectedText = Master.CurrentUser.thisUserInfo.EmpName;
            this.ddlProposer.SelectedValue = Master.CurrentUser.thisUserInfo.EmpCode;

			//this.ddlDept.Width = "90%";
			//this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
			//this.ddlStorage.AutoPostBack = true;
			//this.ddlStorage.Width = "90%";
//			if (this._OP == OP.Red)	 // red
//			{
//				WTOWData oWTOWData;
//				ItemSystem oItemSystem = new ItemSystem();
//
//				DataTable oDT;
//				oWTOWData = oItemSystem.GetWTOWByEntryNo(this._EntryNo);
//				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Drawed )
//				{
//					oWTOWData = oItemSystem.GetWDRWRedByEntryNo(_EntryNo);
//					oDT = oWTOWData.Tables[WTOWData.WDRW_TABLE];
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
//						this.ddlDept.SelectedValue = oDT.Rows[0][WTOWData.REQDEPT_FIELD].ToString();
//						this.ddlDept.SelectedText = oDT.Rows[0][WTOWData.REQDEPTNAME_FIELD].ToString();
//
//						//申请人。
//						//this.txtProposer.Text = oDT.Rows[0][WTOWData.PROPOSER_FIELD].ToString();
//
//						this.ddlProposer.DeptCode = oDT.Rows[0][WTOWData.REQDEPT_FIELD].ToString();
//
//						this.ddlProposer.SelectedText = oDT.Rows[0][WTOWData.PROPOSER_FIELD].ToString();
//						this.ddlProposer.SelectedValue = oDT.Rows[0][WTOWData.PROPOSERCODE_FIELD].ToString();
//
//
//						if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
//						{
//							//this.ddlPurpose.Disabled  = true;
//							this.ddlDept.thisDDL.Enabled = false;
//							//this.txtProposer.Enabled = false;
//						}
//						//发料仓库。
//						this.ddlStorage.SelectedText = oDT.Rows[0][WTOWData.STONAME_FIELD].ToString();
//						this.ddlStorage.SelectedValue = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
//						//用途。
//						//this.ddlPurpose.SelectedText = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
//						//this.ddlPurpose.SelectedValue = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
//						this.item1.ReqReasonCode = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
//						this.item1.ReqReason = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
//						this.item1.StoCode = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
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
		    oWTOWData = new WTOWData();
		    oDT = new DataTable();
			this.doc1.DocCode = DocType.WTOW;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.WTOW;
			this.ddlDept.AutoPostBack = true;
            if (this._OP == OP.Edit || this._OP == OP.Submit)
            {
                this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
                this.ddlDept.Enable = true;
            }
            else
            {
                this.ddlDept.Module_Tag = (int)SDDLTYPE.DEPT;
                this.ddlDept.Enable = false;
            }

            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
			this.ddlDept.DocType = DocType.WTOW;
			//this.ddlDept.Width = "90%";

			this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;		//申领人。
			this.ddlProposer.IsClear = true;
			//this.ddlPurpose.Width = "90%";

			//将单据填充到数据集,DataGrid绑定数据源。
			if (this._OP == OP.O)
			{
				oWTOWData = oItemSystem.GetWTOWByEntryNoOutMode(Master.EntryNo);
			}
            else if (this._OP == OP.Red)
            {
                oWTOWData = oItemSystem.GetWTOWOldByEntryNo(Master.EntryNo);
                if (oWTOWData.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据已经作过红字操作不可以再次进行红字操作！');document.location='WTOWBrowser.aspx?DocCode=16';", true);
                    return;
                }

                oWTOWData = oItemSystem.GetWTOWRedByEntryNo(Master.EntryNo);

                strParentEntryNo = oWTOWData.Tables[0].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                if (strParentEntryNo != "")
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据是红字操作单据不可以再次进行红字操作！');document.location='WTOWBrowser.aspx?DocCode=16';", true);
                    return;
                }
            }
            else
            {
                oWTOWData = oItemSystem.GetWTOWByEntryNo(Master.EntryNo);
            }


			oDT = oWTOWData.Tables[WTOWData.WTOW_TABLE];
			this.item1.thisTable = oDT;
			
			if (oDT.Rows.Count > 0)
			{
                strParentEntryNo = oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                if (strParentEntryNo != "" || this._OP == OP.Red)
                {
                    item1.OperateRed = true;
                    this.ddlPurpose.Disabled = false;
                    txtProcessContent.Attributes.Add("ReadOnly", "ReadOnly");
                    txtProspectusCount.Attributes.Add("ReadOnly", "ReadOnly");
                    txtDrawingCount.Attributes.Add("ReadOnly", "ReadOnly");
                    txtProspectusCount.Attributes.Add("ReadOnly", "ReadOnly");
                    txtReqDate.ShowOnly = false;
                    this.ddlPurpose.Disabled = false;

                    if (this._OP == OP.Red)
                    {
                        txtParentEntryNo.Value = Master.EntryNo.ToString();
                    }
                    else
                    {
                        txtParentEntryNo.Value = strParentEntryNo;
                    }
                }

				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());

                if (this._OP != OP.Red)
                {
                    //审批段。
                    this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                    DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                    this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                    DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                    this.DocAuditWebControl1.AuditName3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                    DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();

                    if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != System.DBNull.Value)
                    {
                        this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y" ? 0 : 1;
                    }
                    if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != System.DBNull.Value)
                    {
                        this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y" ? 0 : 1;
                    }
                    if (oDT.Rows[0][InItemData.AUDIT3_FIELD] != System.DBNull.Value)
                    {
                        this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y" ? 0 : 1;
                    }
                    this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
                    this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
                    this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
                    try
                    {
                        this.DocAuditWebControl1.txtAuditDate1.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                        this.DocAuditWebControl1.txtAuditDate2.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                        this.DocAuditWebControl1.txtAuditDate3.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                    }
                    catch
                    { }
                }

                

				//申请部门。
				this.ddlDept.SelectedValue = oDT.Rows[0][WTOWData.REQDEPT_FIELD].ToString();
				this.ddlDept.SelectedText = oDT.Rows[0][WTOWData.REQDEPTNAME_FIELD].ToString();

				//申请人。
				//this.txtProposer.Text = oDT.Rows[0][WTOWData.PROPOSER_FIELD].ToString();

				this.ddlProposer.DeptCode = oDT.Rows[0][WTOWData.REQDEPT_FIELD].ToString();
				this.ddlProposer.SelectedText = oDT.Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString();
				this.ddlProposer.SelectedValue = oDT.Rows[0][WTOWData.PROPOSERCODE_FIELD].ToString();

				if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
				{
					//this.ddlPurpose.Disabled  = true;
					this.ddlDept.thisDDL.Enabled = false;
					//this.txtProposer.Enabled = false;
				}
				//发料仓库。
//                this.ddlStorage.SelectedText = oDT.Rows[0][WTOWData.STONAME_FIELD].ToString();
//				this.ddlStorage.SelectedValue = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
				//用途。
				this.ddlPurpose.SelectedText = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
				this.ddlPurpose.SelectedValue = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
				//加工内容。
				this.txtProcessContent.Text = oDT.Rows[0][WTOWData.PROCESSCONTENT_FIELD].ToString();
				//限期。
                try
                {
                    this.txtReqDate.Text = DateTime.Parse(oDT.Rows[0][WTOWData.TERM_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }
                    //图纸。
				this.txtDrawingCount.Text = oDT.Rows[0][WTOWData.DRAWINGCOUNT_FIELD].ToString();
				//样张。
				this.txtProspectusCount.Text = oDT.Rows[0][WTOWData.PROSPECTUSCOUNT_FIELD].ToString();
//				this.item1.ReqReasonCode = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
//				this.item1.ReqReason = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
//				this.item1.StoCode = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
				//备注。
				this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//发料模式下初始化发料人和日期。
				if (this._OP == OP.O)
				{
                    this.TextBox1.Text = Master.CurrentUser.thisUserInfo.EmpName;
					this.TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
				}
			}
		}

		/// <summary>
		/// 设置审批数据。
		/// </summary>
		private void SetAuditData()
		{
			switch (this._OP)
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
		/// <param name="oWTOWData">WTOWData:	领料单实体。</param>
		private void FillData(WTOWData oWTOWData)
		{
			dr = oWTOWData.Tables[WTOWData.WTOW_TABLE].NewRow();
			//单据台头部分内容。
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;						//单据流水号。
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;					//单据编号。
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;						//单据类型。
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;						//单据类型名称。
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;							//单据文档编号。
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;						//单据日期。
            dr[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
            dr[WTOWData.STOMANAGERCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;	//仓管编号。
            dr[WTOWData.STOMANAGER_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;		//仓管名称。
			//dr[WTOWData.STOCODE_FIELD] = ddlStorage.SelectedValue;				//领料仓库编号。
			
			dr[InItemData.REMARK_FIELD] = this.item1.Remark;					//备注。
			dr[WTOWData.REQDEPT_FIELD] = this.ddlDept.SelectedValue;			//申领部门。
			dr[WTOWData.REQDEPTNAME_FIELD] = this.ddlDept.SelectedText;			//申领部门名称。
						
			dr[WTOWData.PROPOSERCODE_FIELD] = this.ddlProposer.SelectedValue;   //申领人编号。
			dr[WTOWData.PROPOSERNAME_FIELD] = this.ddlProposer.SelectedText;    //申领人名称。
			dr[WTOWData.PROCESSCONTENT_FIELD] = this.txtProcessContent.Text;    //加工内容。
			dr[WTOWData.REQREASONCODE_FIELD] = this.ddlPurpose.SelectedValue;	//用途编号。
			dr[WTOWData.REQREASON_FIELD] = this.ddlPurpose.SelectedText;		//用途名称。
			try
			{
				dr[WTOWData.TERM_FIELD] = Convert.ToDateTime(this.txtReqDate.Text);
			}
			catch
			{
				dr[WTOWData.TERM_FIELD] = null;
			}
			try
			{
				dr[WTOWData.DRAWINGCOUNT_FIELD] = Convert.ToInt32(this.txtDrawingCount.Text);
			}
			catch
			{
				dr[WTOWData.DRAWINGCOUNT_FIELD] = 0;
			}
			try
			{
				dr[WTOWData.PROSPECTUSCOUNT_FIELD] = Convert.ToInt32(this.txtProspectusCount.Text);
			}
			catch
			{
				dr[WTOWData.PROSPECTUSCOUNT_FIELD] = 0;
			}
//			dr[WTOWData.REQREASON_FIELD] = this.item1.ReqReason;				//用途名称。
//			dr[WTOWData.REQREASONCODE_FIELD] = this.item1.ReqReasonCode;		//用途编号。
			try
			{
                dr[WTOWData.PARENTENTRYNO_FIELD] = this.txtParentEntryNo.Value;	//红字父单据号。
			}
			catch
			{}
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
			
			MyCol2List = new Col2List(this.item1.thisTable);
			
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();									//顺序号。
//			dr[WTOWData.SOURCEENTRY_FIELD] = MyCol2List.GetList(WTOWData.SOURCEENTRY_FIELD);		//源单据流水号。
//			dr[WTOWData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(WTOWData.SOURCEDOCCODE_FIELD);	//源单据类型。
//			dr[WTOWData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(WTOWData.SOURCESERIALNO_FIELD);	//源单据顺序号。
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);			//物料编号。
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);			//物料名称。
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);	//规格型号。
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);			//单位。
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);	//单位名称。
			dr[WTOWData.PLANNUM_FIELD] = MyCol2List.GetList(WTOWData.PLANNUM_FIELD);				//申领数量。
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);			//实际数量。
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);		//单价。
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);		//金额。
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);			//合计金额。
			
			oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows.Add(dr);
		}
		/// <summary>
		/// 设置单据状态。
		/// </summary>
		/// <param name="oWTOWData">WTOWData:	领料单数据实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(WTOWData oWTOWData, string OpMode)
		{
			if ( oWTOWData.Count > 0)
			{
				DataRow oDataRow = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oWTOWData.Tables[WTOWData.WTOW_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// 设置单据操作人。
		/// </summary>
		/// <param name="oWTOWData">WTOWData:	领料单数据实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryOperator(WTOWData oWTOWData, string OpMode)
		{
			if ( oWTOWData.Count > 0)
			{
				DataRow oDataRow = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://新建。
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Red:  //红字。
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
					case OP.O:
                        oDataRow[WTOWData.STOMANAGERCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[WTOWData.STOMANAGER_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
						break;
				}
			}
		}

		/// <summary>
		/// 检查仓库发料的前提条件。
		/// </summary>
		/// <param name="dt">DataTable:	领料单数据表。</param>
		/// <returns>bool:	符合条件返回true,不符合返回false.</returns>
		private bool CheckOutCondition(DataTable dt)
		{
		    StockNum = 0;
		    ItemNum = 0;
		    ItemCode = "";
		    ItemName = "";
		    ItemSpec = "";

			for (i = 0; i< dt.Rows.Count; i++)
			{
				try
				{	StockNum = Convert.ToDecimal(dt.Rows[i]["StockNum"].ToString());	}
				catch
				{	StockNum = 0;	}
				try
				{	ItemNum = Convert.ToDecimal(dt.Rows[i]["ItemNum"].ToString());	}
				catch
				{	ItemNum = 0; }
				ItemCode = dt.Rows[i]["ItemCode"].ToString();
				ItemName = dt.Rows[i]["ItemName"].ToString();
				ItemSpec = dt.Rows[i]["ItemSpecial"].ToString();
				//求相同物料累计的发出数。
				for (j = i+1; j< dt.Rows.Count; j++)
				{
					if (ItemCode == "-1")//OTI物料。
					{
						if (ItemCode == dt.Rows[j]["ItemCode"].ToString() &&
							ItemName == dt.Rows[j]["ItemName"].ToString() &&
							ItemSpec == dt.Rows[j]["ItemSpecial"].ToString())//有相同的物料。
						{
							try
							{	ItemNum += Convert.ToDecimal(dt.Rows[j]["ItemNum"].ToString());}
							catch
							{ }
						}
					}
					else//正常物料。
					{
						if (ItemCode == dt.Rows[j]["ItemCode"].ToString() )//有相同的物料。
						{
							try
							{	ItemNum += Convert.ToDecimal(dt.Rows[j]["ItemNum"].ToString());}
							catch
							{ }
						}
					}
				}//end of for( j);
				if ( StockNum < ItemNum)
				{
					return false;
				}
			}//end of for (i)
			return true;
		}
		/// <summary>
		/// 判断领料单操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <returns>bool:	满足操作条件则返回true,不满足则返回false.</returns>
		private bool CheckPreCondition(int EntryNo)
		{
			return false;
		}
//		/// <summary>
//		/// 根据仓库编号、物料信息获取库存信息。
//		/// </summary>
//		/// <param name="StoCode">string:	仓库编号。</param>
//		/// <param name="ItemCode">string:	物料编号。</param>
//		/// <param name="ItemName">string:	物料名称。</param>
//		/// <param name="ItemSpec">string:	规格型号。</param>
//		/// <returns>decimal:	指定仓库指定物料的库存数。</returns>
//		private decimal GetStockNumByStoCodeAndItem(string StoCode,string ItemCode, string ItemName, string ItemSpec)
//		{
//			ItemSystem oItemSystem = new ItemSystem();
//			StockData oStockData;
//			decimal retValue = 0;
//			oStockData = oItemSystem.GetStockSumByStoCodeAndItem(StoCode,ItemCode,ItemName,ItemSpec);
//			if ( oStockData.Count > 0)
//			{
//				retValue = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString());
//			}
//			return retValue;
//		}

		#endregion
		
		#region 事件
		/// <summary>
		/// 页面的Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.DRW;
			// 在此处放置用户代码以初始化页面
			if (this.Request["Op"] != null && this.Request["Op"] != "")
			{
				_OP = Request["Op"].ToString();
			}

            this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
            this.TextBox2.Attributes.Add("ReadOnly", "ReadOnly");
            item1.IsDisplayWTOWPrice = Master.DisplayWTOWPrice;
			
			if(!this.IsPostBack)
			{
                if (new ItemSystem().CheckPreconditionOfWTOW(Master.EntryNo, this._OP, Master.CurrentUser.thisUserInfo.LoginName))
                {
                    switch (_OP)
                    {
                        case OP.New:
                            if (!Master.HasBrowseRight(SysRight.WTOWMaintain))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataNew();
                            this.btnRefuse.Visible = false;
                            this.btnSave.Text = OPName.New;
                            break;
                        case OP.Red:
                            if (!Master.HasBrowseRight(SysRight.WTOWRed))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            //this.btnAddByDoc.Visible = false;
                            this.btnRefuse.Visible = true;
                            this.btnSave.Text = OPName.New;
                            this.ddlPurpose.Disabled = true;
                            // this.ddlPurpose.Disabled = false;
                            break;
                        case OP.Edit:
                            if (!Master.HasBrowseRight(SysRight.WTOWMaintain))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.Edit;
                            this.btnRefuse.Visible = false;
                            this.ddlDept.Enable = true;
                            break;
                        case OP.Submit:
                            if (!Master.HasBrowseRight(SysRight.WTOWPresent))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.Submit;
                            this.btnPresent.Visible = false;
                            this.ddlDept.Enable = true;
                            //this.ddlPurpose.Disabled= true;
                            //this.ddlStorage.Enable = false;
                            //this.btnAddByDoc.Visible = false;
                            this.btnRefuse.Visible = false;
                            break;
                        case OP.FirstAudit:
                            if (!Master.HasBrowseRight(SysRight.WTOWFirstAudit))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.FirstAudit;
                            this.btnPresent.Visible = false;
                            this.ddlDept.Enable = false;
                            this.ddlPurpose.Disabled = false;
                            txtDrawingCount.ReadOnly = true;

                            txtProspectusCount.ReadOnly = true;
                            ddlProposer.Enable = false;
                            txtProcessContent.ReadOnly = true;
                            //this.ddlPurpose.Disabled= true;
                            //this.ddlStorage.Enable = false;
                            //this.btnAddByDoc.Visible = false;
                            this.btnRefuse.Visible = false;
                            this.txtReqDate.ShowOnly = true;
                            break;
                        case OP.SecondAudit:
                            if (!Master.HasBrowseRight(SysRight.WTOWSecondAudit))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.SecondAudit;
                            this.btnPresent.Visible = false;
                            this.ddlDept.Enable = false;
                            this.ddlPurpose.Disabled = false;
                            txtDrawingCount.ReadOnly = true;
                            txtProspectusCount.ReadOnly = true;
                            ddlProposer.Enable = false;
                            txtProcessContent.ReadOnly = true;
                            //this.ddlPurpose.Disabled= true;
                            //this.ddlStorage.Enable = false;
                            //this.btnAddByDoc.Visible = false;
                            this.btnRefuse.Visible = false;
                            this.txtReqDate.ShowOnly = true;
                            break;
                        case OP.ThirdAudit:
                            if (!Master.HasBrowseRight(SysRight.WTOWThirdAudit))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.ThirdAudit;
                            this.btnPresent.Visible = false;
                            this.ddlDept.Enable = false;
                            this.ddlPurpose.Disabled = false;
                            txtDrawingCount.ReadOnly = true;
                            txtProspectusCount.ReadOnly = true;
                            ddlProposer.Enable = false;
                            txtProcessContent.ReadOnly = true;
                            //this.ddlPurpose.Disabled= true;
                            //this.ddlStorage.Enable = false;
                            //this.btnAddByDoc.Visible = false;
                            this.btnRefuse.Visible = false;
                            this.txtReqDate.ShowOnly = true;
                            break;
                        case OP.O:
                            if (!Master.HasBrowseRight(SysRight.StockOut))
                            {
                                //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                                return;
                            }
                            this.BindDataUpdate();
                            this.btnSave.Text = OPName.O;
                            this.btnPresent.Visible = false;
                            this.ddlPurpose.Disabled = false;
                            this.ddlDept.Enable = false;
                            ddlProposer.Enable = false;
                            //this.ddlPurpose.Disabled= true;
                            //this.ddlStorage.Enable = false;
                            //this.btnAddByDoc.Visible = false;
                            this.btnRefuse.Visible = true;
                            break;
                    }
                }
                else
                {
                    this.BindDataUpdate();
                    //this.BindDataNew();
                    this.Response.Write("<script>alert('单据的当前状态不允许进行当前操作！');window.history.go(-1);</script>");

                }

                if ((strParentEntryNo != "" && strParentEntryNo != "0") || this._OP == OP.Red)
                {
                   
                    txtReqDate.ShowOnly = true;
                    this.ddlPurpose.Disabled = false;
                    ddlProposer.Enable = false;
                    ddlDept.Enable = false;
                   

                }
			}
			
		}
		/// <summary>
		/// 拒绝操作。
		/// </summary>
		protected void btnRefuse_Click(object sender, System.EventArgs e)
		{
		    EntryNo = 0;
			
			ret = false;
			oWTOWData = new WTOWData();
			this.FillData(oWTOWData);
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());


            if (Master.HasRight(SysRight.StockOut))
			{
				ret = oItemSystem.RefuseWTOW(EntryNo,Master.CurrentUser.thisUserInfo.LoginName);
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
					this.Response.Redirect("OUTBrowser.aspx");
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

            if (this.txtReqDate.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"要求完成日期不能为空！\");", true);
                return;
            }

            if (this.txtProcessContent.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('没有加工内容!');", true);
                return;
            }
			//构建数据实体.
			oWTOWData = new WTOWData();
			this.FillData(oWTOWData);
			
			this.SetEntryState(oWTOWData, this._OP);
			this.SetEntryOperator(oWTOWData, this._OP);

			
			ret = false;
			switch (this._OP)
			{
					#region New
				case OP.New:
                    if (Master.HasRight(SysRight.WTOWMaintain))
					{
						ret = oItemSystem.AddWTOW(oWTOWData);
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region 红字
				case OP.Red:
                    if (Master.HasRight(SysRight.WTOWRed))
					{
						ret = oItemSystem.AddWTOW(oWTOWData);
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region Edit
				case OP.Edit:
                    if (Master.HasRight(SysRight.WTOWMaintain))
					{
						ret = oItemSystem.UpdateWTOW(oWTOWData);
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region Submit
				case OP.Submit:
                    if (Master.HasRight(SysRight.WTOWPresent))
					{
                        ret = oItemSystem.PresentWTOW(this.doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region FirstAudit
				case OP.FirstAudit:
                    if (Master.HasRight(SysRight.WTOWFirstAudit))
					{
						if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="Y" &&
							oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						else
						{
							ret = oItemSystem.FirstAuditWTOW(oWTOWData);
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
                    if (Master.HasRight(SysRight.WTOWSecondAudit))
					{
						if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() !="Y" &&
							oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						else
						{
							ret = oItemSystem.SecondAuditWTOW(oWTOWData);
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
                    if (Master.HasRight(SysRight.WTOWThirdAudit))
					{
						if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() !="Y" &&
							oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						else
						{
							ret = oItemSystem.ThirdAuditWTOW(oWTOWData);
						}
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region O
				case OP.O:
                    if (Master.HasRight(SysRight.StockOut))
					{
						MyWTOWData = oItemSystem.GetWTOWByEntryNo(Master.EntryNo);
						//判断是否是红字。
						
						if (this.CheckOutCondition(this.item1.thisTable))		   //判断是否满足库存条件。
						{
							ret = oItemSystem.StockOutWTOW(oWTOWData);
						}
						else
						{
							//this.Response.Write("<script>alert(\'发出数不能大于当前库存数量！\')</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('发出数不能大于当前库存数量!');", true);
                            return;
						}
						
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
                    //if (this._OP == OP.O)
                    //{
                    //    this.Response.Redirect("OUTBrowser.aspx");
                    //}
                    //else
                    //{
						Response.Redirect("WTOWBrowser.aspx?DocCode=16");
                    //}
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
				if (this._OP == OP.O)
				{
					this.Response.Redirect("OUTBrowser.aspx");
				}
				else
				{
					Response.Redirect("WTOWBrowser.aspx?DocCode=16");
				}
			}
		}
	
		/// <summary>
		/// 马上提交事件。
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            if (this.txtReqDate.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"要求完成日期不能为空！\");", true);
                return;
            }

            if (this.txtProcessContent.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有加工内容!');", true);
                return;
            }
			//构建数据实体.
			oWTOWData = new WTOWData();
			this.FillData(oWTOWData);
			
			
			ret = false;
			switch (this._OP)
			{
				case OP.New:
                    if (Master.HasRight(SysRight.WTOWMaintain) && Master.HasRight(SysRight.WTOWPresent))
					{
						this._OP = OP.NewAndPresent;
						this.SetEntryState(oWTOWData, this._OP);
						this.SetEntryOperator(oWTOWData, this._OP);
						ret = oItemSystem.AddAndPresentWTOW(oWTOWData);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Red:
                    if (Master.HasRight(SysRight.WTOWMaintain) && Master.HasRight(SysRight.WTOWPresent))
					{
						this._OP = OP.NewAndPresent;
						this.SetEntryState(oWTOWData, this._OP);
						this.SetEntryOperator(oWTOWData, this._OP);
						ret = oItemSystem.AddAndPresentWTOW(oWTOWData);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Edit:
                    if (Master.HasRight(SysRight.WTOWMaintain) && Master.HasRight(SysRight.WTOWPresent))
					{
						this._OP = OP.EditAndPresent;
						this.SetEntryState(oWTOWData, this._OP);
						this.SetEntryOperator(oWTOWData, this._OP);
						ret = oItemSystem.UpdateAndPresentWTOW(oWTOWData);
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
					Response.Redirect("WTOWBrowser.aspx?DocCode=16");
				}
			}
		}


        /// <summary>
  		/// 仓库下拉列表改变事件。
	    /// </summary>
 	    /// <returns></returns>
    	protected override bool OnBubbleEvent(object Sender,EventArgs e)
    	{
            if (Sender is DropDownList)
            {
                if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == this.ddlDept.thisDDL.ClientID)
                {
                    this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;
                    this.ddlProposer.IsClear = true;
                    this.ddlProposer.DeptCode = this.ddlDept.SelectedValue;
                    this.ddlProposer.SetDDL();
                }
            }

            return true;
        }
       

//		/// <summary>
//		/// 仓库下拉列表改变事件。
//		/// </summary>
//		/// <returns></returns>
//		protected override bool OnBubbleEvent(object Sender,EventArgs e)
//		{
//			try
//			{
//				//仓库下拉列表事件。
//				if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == "ddlStorage_thisDDL" )
//				{
//					this.item1.StoCode = this.ddlStorage.SelectedValue;
//					if (this.ddlStorage.SelectedValue != "-1")					
//					{
//						if (this.item1.thisTable.Rows.Count > 0)//如果静态表中有记录，则要刷新当前库存字段的值。
//						{
//							decimal StockNum;
//							for (int i = 0; i< this.item1.thisTable.Rows.Count; i++)
//							{
//								StockNum = this.GetStockNumByStoCodeAndItem(this.item1.StoCode,
//									this.item1.thisTable.Rows[i]["ItemCode"].ToString(),
//									this.item1.thisTable.Rows[i]["ItemName"].ToString(),
//									this.item1.thisTable.Rows[i]["ItemSpecial"].ToString());
//								this.item1.thisTable.Rows[i]["StockNum"] = StockNum;
//							}
//						}
//						this.item1.DGModel_Items1.DataBind();
//					}
//				}
//				else
//				{
//					if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == "ddlDept_thisDDL")
//					{
//						this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;
//						this.ddlProposer.IsClear = true;
//						this.ddlProposer.DeptCode = this.ddlDept.SelectedValue;
//						this.ddlProposer.SetDDL();
//					}
//				}
//			}
//			catch
//			{}
//			return true;
//		}
		#endregion

	}
}
