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
	using System.Data;
	using System.Web.UI.WebControls;
	using MZHMM.WebMM.Modules;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// MRPInput 的摘要说明。
	/// </summary>
	public partial class DRWInput : System.Web.UI.Page
	{
		#region 成员变量
		private string mOP;
		protected DocWebControl doc1;
		protected DRWWebControl item1 ;
		protected StorageDropdownlist ddlDept;
		protected StorageDropdownlist ddlProposer;
		protected DocAuditWebControl DocAuditWebControl1;
		protected System.Web.UI.WebControls.TextBox txtProcessContent;
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

        private string strParentEntryNo = "";

	    private DataTable dtCatCode = new DataTable();

		#endregion
		
		#region 属性
		/// <summary>
		/// 从信息反馈页面传递进来的需要生成领料单的反馈信息
		/// ID。
		/// </summary>
		private string PKIDs
		{
			get 
			{
				if (this.Request["PKIDs"] != null && this.Request["PKIDs"].ToString() != "")
				{
					return this.Request["PKIDs"].ToString();
				}
				else
				{
					return null;
				}
			}
		}
		/// <summary>
		/// 当前页面的操作方式从URL传递进来。
		/// </summary>
		private string OP
		{
			get 
			{
				return this.mOP==null?this.Request["Op"]:this.mOP;
			}
			set 
			{
				this.mOP = value;
			}
		}
		/// <summary>
		/// 是否是从待办事宜处调用进入。
		/// </summary>
		/// <remarks>
		/// 因为需要根据不同进入的页面，操作完成后要进行刷新。
		/// </remarks>
		private bool IsFromTodo
		{
			get 
			{
				return this.Request["TODO"] == null?false:true;
			}
		}
		/// <summary>
		/// 单据流水号，由URL传递进来。
		/// </summary>
		private int EntryNo
		{
			get
			{
				return this.Request["EntryNo"] == null?0:Convert.ToInt32(this.Request["EntryNo"].ToString());
			}
		}
		
		#endregion

		#region 私有方法
		/// <summary>
		/// 根据仓库编号、物料信息获取库存信息。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ItemName">string:	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns></returns>
		private decimal GetStockNumByStoCodeAndItem(string StoCode,string ItemCode, string ItemName, string ItemSpec)
		{
			ItemSystem oItemSystem = new ItemSystem();
			StockData oStockData;
			decimal retValue = 0;
			oStockData = oItemSystem.GetStockSumByStoCodeAndItem(StoCode,ItemCode,ItemName,ItemSpec);
			if ( oStockData.Count > 0)
			{
				retValue = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString());
			}
			return retValue;
		}
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.DRW;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.DRW;
			this.ddlDept.AutoPostBack = true;	//因为要刷新ddlProposer内容。
			this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
			this.ddlDept.DocType = DocType.DRW;
            this.ddlDept.SelectedValue = Master.CurrentUser.thisUserInfo.DeptCode;
            this.ddlDept.SelectedText = Master.CurrentUser.thisUserInfo.DeptName;
			this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;
			this.ddlProposer.IsClear = true;
			this.ddlProposer.DeptCode = Master.CurrentUser.thisUserInfo.DeptCode;
			this.ddlProposer.SelectedText = Master.CurrentUser.thisUserInfo.EmpName;
			this.ddlProposer.SelectedValue = Master.CurrentUser.thisUserInfo.EmpCode;
			//this.ddlDept.Width = "90%";
			#region If From Feedback.
			if (this.PKIDs != null)
			{
				//TODO: 增加从反馈信息来生成领料单的代码。
				DataTable oDT;
				WDRWData oWDRWData;
				ItemSystem oItemSystem = new ItemSystem();

				oWDRWData = oItemSystem.GetWDRWByFeedbackIDs(this.PKIDs);
				string Temp_ReqReasonCode = "";
				int Temp_Count;
				Temp_Count = oWDRWData.Count;
				if (oWDRWData.Count > 0)
				{
					Temp_ReqReasonCode = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
				}
				for (int i=oWDRWData.Count -1;i>0 ;i--)
				{
					if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[i][WDRWData.REQREASONCODE_FIELD].ToString() != Temp_ReqReasonCode)		
					{
						oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows.RemoveAt(i);//如果当前行的用途和第一条不一样，则从返回的数据实体中删除之。
					}
				}
				if (Temp_Count > oWDRWData.Count)
				{
					//this.Response.Write("<script>alert('所选的反馈信息涉及到多个用途，只能生成一个用途的领料单，其余用途的物料将被忽略！');</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('所选的反馈信息涉及到多个用途，只能生成一个用途的领料单，其余用途的物料将被忽略!');", true);
				}
				oDT = oWDRWData.Tables[WDRWData.WDRW_TABLE];
				//仓库.
				if(oDT.Rows.Count > 0)
				{
					this.item1.StoName = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
					this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
					//根据仓库更形oDT中的库存信息。

					decimal StockNum;
					for (int i=0; i<oDT.Rows.Count; i++)
					{
						StockNum = this.GetStockNumByStoCodeAndItem(oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString(),
																	oDT.Rows[i][InItemData.ITEMCODE_FIELD].ToString(),
																	oDT.Rows[i][InItemData.ITEMNAME_FIELD].ToString(),
																	oDT.Rows[i][InItemData.ITEMSPECIAL_FIELD].ToString());	
						oDT.Rows[i]["StockNum"] = StockNum;
					}
				}
				this.item1.thisTable = oDT;
				//用途。
				if(oDT.Rows.Count > 0)
				{
					this.item1.ReqReasonCode = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
					this.item1.ReqReason = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
				}
			}
			#endregion
			#region If Red
            if (this.OP == MZHMM.Common.OP.Red)
			{
				DataTable oDT;
				WDRWData oWDRWData;
				ItemSystem oItemSystem = new ItemSystem();

                oWDRWData = oItemSystem.GetWDRWOldByEntryNo(this.EntryNo);

                if (oWDRWData.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据已经作过红字操作不可以再次进行红字操作！');document.location='DRWBrowser.aspx?DocCode=4';", true);
                    return;
                }


                oWDRWData = oItemSystem.GetWDRWByEntryNo(this.EntryNo);

                
              
				
				//oWDRWData = oItemSystem.GetWDRWByEntryNo(this.EntryNo);
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Drawed )
				{
					oWDRWData = oItemSystem.GetWDRWRedByEntryNo(EntryNo);
					oDT = oWDRWData.Tables[WDRWData.WDRW_TABLE];
					this.item1.thisTable = oDT;
					if (oDT.Rows.Count > 0)
					{
                        strParentEntryNo = oDT.Rows[0][WDRWData.PARENTENTRYNO_FIELD].ToString();
                        if (strParentEntryNo != "")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据是红字操作单据不可以再次进行红字操作！');document.location='DRWBrowser.aspx?DocCode=4';", true);
                            return;
                        }

						//台头部分。
						this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
						this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
						this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
						//审批段。
						this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
						this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
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
							this.DocAuditWebControl1.txtAuditDate1.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToShortDateString();
							this.DocAuditWebControl1.txtAuditDate2.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToShortDateString();
							this.DocAuditWebControl1.txtAuditDate3.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToShortDateString();
						}
						catch
						{}
						//申请部门。
						this.ddlDept.SelectedValue = oDT.Rows[0][WDRWData.REQDEPT_FIELD].ToString();
						this.ddlDept.SelectedText = oDT.Rows[0][WDRWData.REQDEPTNAME_FIELD].ToString();

						//申请人。
						//this.txtProposer.Text = oDT.Rows[0][WDRWData.PROPOSER_FIELD].ToString();

						this.ddlProposer.DeptCode = oDT.Rows[0][WDRWData.REQDEPT_FIELD].ToString();

						this.ddlProposer.SelectedText = oDT.Rows[0][WDRWData.PROPOSER_FIELD].ToString();
						this.ddlProposer.SelectedValue = oDT.Rows[0][WDRWData.PROPOSERCODE_FIELD].ToString();


						if (this.OP == "FirstAudit" || this.OP == "SecondAudit" || this.OP == "ThirdAudit")
						{
							//this.ddlPurpose.Disabled  = true;
							this.ddlDept.thisDDL.Enabled = false;
							//this.txtProposer.Enabled = false;
						}
						//发料仓库。
						//this.ddlStorage.SelectedText = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
						//this.ddlStorage.SelectedValue = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
						this.item1.StoName = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
						this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
						//用途。
						//this.ddlPurpose.SelectedText = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
						//this.ddlPurpose.SelectedValue = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
						this.item1.ReqReasonCode = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
						this.item1.ReqReason = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
						//this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
						//备注。
						this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
						this.txtParentEntryNo.Value = oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString();
					}
					else
					{
						//this.Response.Write("<Script>alert('领料单出红字的前提条件是该单据已发料！');</Script>");
						//this.Response.Redirect("DRWBrowser.aspx?DocCode=4",true);
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('领料单出红字的前提条件是该单据已发料!');document.location='DRWBrowser.aspx?DocCode=4'", true);
					}
				}
			}
			#endregion
		}
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{
			WDRWData oWDRWData;
            ItemSystem oItemSystem = new ItemSystem();

			DataTable oDT;
			this.doc1.DocCode = DocType.DRW;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.DRW;
			this.ddlDept.AutoPostBack = true;
            if (this.OP == MZHMM.Common.OP.Edit || this.OP == MZHMM.Common.OP.Submit)
				this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
			else
			{
                this.ddlDept.Module_Tag = (int)SDDLTYPE.DEPT;
				this.ddlDept.Enable = false;
				//this.txtProposer.Enabled = false;
			}

            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
			this.ddlDept.DocType = DocType.DRW;
			//this.ddlDept.Width = "90%";

			this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;
			this.ddlProposer.IsClear = true;
			//this.ddlPurpose.Width = "90%";
//			this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
//			this.ddlStorage.Width = "90%";
//			this.ddlStorage.AutoPostBack = true;
//			this.ddlCon.Width = "90%";
//			this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
//			this.ddlCon.StoCode = this.ddlStorage.SelectedValue;
			//将单据填充到数据集,DataGrid绑定数据源。
            if (this.OP == MZHMM.Common.OP.O)
			{
				oWDRWData = oItemSystem.GetWDRWByEntryNoOutMode(EntryNo);
			}
			else
			{
				oWDRWData = oItemSystem.GetWDRWByEntryNo(EntryNo);
			}
			oDT = oWDRWData.Tables[WDRWData.WDRW_TABLE];
			this.item1.thisTable = oDT;
			
			if (oDT.Rows.Count > 0)
			{
                strParentEntryNo = oDT.Rows[0][WDRWData.PARENTENTRYNO_FIELD].ToString();
                
				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//审批段。
				this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
				this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.AuditName3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();

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
					this.DocAuditWebControl1.txtAuditDate1.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate2.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate3.Text = Convert.ToDateTime(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
				}
				catch
				{}
				//申请部门。
				this.ddlDept.SelectedValue = oDT.Rows[0][WDRWData.REQDEPT_FIELD].ToString();
				//this.ddlDept.SelectedText = oDT.Rows[0][WDRWData.REQDEPTNAME_FIELD].ToString();

				//申请人。
				//this.txtProposer.Text = oDT.Rows[0][WDRWData.PROPOSER_FIELD].ToString();

				this.ddlProposer.DeptCode = oDT.Rows[0][WDRWData.REQDEPT_FIELD].ToString();

				//this.ddlProposer.SelectedText = oDT.Rows[0][WDRWData.PROPOSER_FIELD].ToString();
				this.ddlProposer.SelectedValue = oDT.Rows[0][WDRWData.PROPOSERCODE_FIELD].ToString();


				if (this.OP == "FirstAudit" || this.OP == "SecondAudit" || this.OP == "ThirdAudit")
				{
					//this.ddlPurpose.Disabled  = true;
					this.ddlDept.thisDDL.Enabled = false;
					//this.txtProposer.Enabled = false;
				}
				//发料仓库。
//                this.ddlStorage.SelectedText = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
//				this.ddlStorage.SelectedValue = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
				this.item1.StoName = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
				this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
				//用途。
				//this.ddlPurpose.SelectedText = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
				//this.ddlPurpose.SelectedValue = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
				this.item1.ReqReasonCode = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
				this.item1.ReqReason = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
				//this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
				//备注。
				this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//发料模式下初始化发料人和日期。
                if (this.OP == MZHMM.Common.OP.O)
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
			switch (this.OP)
			{
                case MZHMM.Common.OP.FirstAudit:
					break;
                case MZHMM.Common.OP.SecondAudit:
					break;
                case MZHMM.Common.OP.ThirdAudit:
					break;
			}
		}
		/// <summary>
		/// 数据填充。
		/// </summary>
		/// <param name="oWDRWData">WDRWData:	领料单实体。</param>
		private void FillData(WDRWData oWDRWData)
		{
			DataRow dr = oWDRWData.Tables[WDRWData.WDRW_TABLE].NewRow();
			//单据台头部分内容。
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。
//			dr[WDRWData.STONAME_FIELD] = ddlStorage.SelectedText;					//领料仓库名称。
//			dr[WDRWData.STOCODE_FIELD] = ddlStorage.SelectedValue;					//领料仓库编号。
			dr[WDRWData.STONAME_FIELD] = this.item1.StoName;					//领料仓库名称。
			dr[WDRWData.STOCODE_FIELD] = this.item1.StoCode;					//领料仓库编号。
			dr[InItemData.REMARK_FIELD] = this.item1.Remark;						//备注。
			dr[WDRWData.REQDEPT_FIELD] = this.ddlDept.SelectedValue;				//申领部门。
			dr[WDRWData.REQDEPTNAME_FIELD] = this.ddlDept.SelectedText;				//申领部门名称。
			//dr[WDRWData.PROPOSER_FIELD] = this.txtProposer.Text;					
			dr[WDRWData.PROPOSERCODE_FIELD] = this.ddlProposer.SelectedValue;//申领人编号。
			dr[WDRWData.PROPOSER_FIELD] = this.ddlProposer.SelectedText;//申领人名称。
			dr[WDRWData.REQREASON_FIELD] = this.item1.ReqReason;					//用途名称。
			dr[WDRWData.REQREASONCODE_FIELD] = this.item1.ReqReasonCode;			//用途编号。
			try
			{
                dr[WDRWData.PARENTENTRYNO_FIELD] = this.txtParentEntryNo.Value;			//红字父单据号。
			}
			catch
			{}
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
			
			Col2List MyCol2List = new Col2List(this.item1.thisTable);
			
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();									//顺序号。
			dr[WDRWData.SOURCEENTRY_FIELD] = MyCol2List.GetList(WDRWData.SOURCEENTRY_FIELD);		//源单据流水号。
			dr[WDRWData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(WDRWData.SOURCEDOCCODE_FIELD);	//源单据类型。
			dr[WDRWData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(WDRWData.SOURCESERIALNO_FIELD);	//源单据顺序号。
		    dr[InItemData.NEWCODE_FIELD] = MyCol2List.GetList(InItemData.NEWCODE_FIELD);            //新编号。
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);			//物料编号。
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);			//物料名称。
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);	//规格型号。
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);			//单位。
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);	//单位名称。
			dr[WDRWData.PLANNUM_FIELD] = MyCol2List.GetList(WDRWData.PLANNUM_FIELD);				//申领数量。
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);			//实际数量。
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);		//单价。
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);		//金额。
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);			//合计金额。
			
			oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows.Add(dr);
		}
		/// <summary>
		/// 设置单据状态。
		/// </summary>
		/// <param name="oWDRWData">WDRWData:	领料单数据实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(WDRWData oWDRWData, string OpMode)
		{
			if ( oWDRWData.Count > 0)
			{
				DataRow oDataRow = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oWDRWData.Tables[WDRWData.WDRW_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// 设置单据操作人。
		/// </summary>
		/// <param name="oWDRWData">WDRWData:	领料单数据实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryOperator(WDRWData oWDRWData, string OpMode)
		{
			if ( oWDRWData.Count > 0)
			{
				DataRow oDataRow = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0];

				switch (OpMode)
				{
                    case MZHMM.Common.OP.New://新建。
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case MZHMM.Common.OP.Red:  //红字。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case MZHMM.Common.OP.NewAndPresent:
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case MZHMM.Common.OP.Edit://编辑。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case MZHMM.Common.OP.EditAndPresent:
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case MZHMM.Common.OP.FirstAudit://一级审批。
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
                    case MZHMM.Common.OP.SecondAudit://二级审批。
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
                    case MZHMM.Common.OP.ThirdAudit://三级审批。
                        oDataRow[InItemData.ASSESSOR3_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
                    case MZHMM.Common.OP.O:
						oDataRow[WDRWData.STOMANAGERCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[WDRWData.STOMANAGER_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
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
			decimal StockNum,ItemNum;//库存数、发出数。
			string ItemCode,ItemName,ItemSpec;

			for (int i = 0; i< dt.Rows.Count; i++)
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
				for (int j = i+1; j< dt.Rows.Count; j++)
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

		/// <summary>
		/// 验证权限。
		/// </summary>
		/// <param name="OP">string:	操作代码。</param>
		private void CheckRight(string OP)
		{
			switch (OP)
			{
                case MZHMM.Common.OP.New:
					if (!Master.HasBrowseRight(SysRight.DRWMaintain))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.Edit:
                    if (!Master.HasBrowseRight(SysRight.DRWMaintain))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.Red:
                    if (!Master.HasBrowseRight(SysRight.DRWRed))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.Submit:
                    if (!Master.HasBrowseRight(SysRight.DRWPresent))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.FirstAudit:
                    if (!Master.HasBrowseRight(SysRight.DRWFirstAudit))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.SecondAudit:
                    if (!Master.HasBrowseRight(SysRight.DRWSecondAudit))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.ThirdAudit:
                    if (!Master.HasBrowseRight(SysRight.DRWThirdAudit))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}
					break;
                case MZHMM.Common.OP.O:
                    if (!Master.HasBrowseRight(SysRight.StockOut))
					{
						//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
						return;
					}						
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
			Session[MySession.Help] = HelpCode.DRW;
            this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
            this.TextBox2.Attributes.Add("ReadOnly", "ReadOnly");
            item1.IsDisplayDRWPrice = Master.DisplayDRWPrice;
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{	
				//检查单据的状态是否符合当前操作的前提条件。
				if ( new ItemSystem().CheckPreconditionOfWDRW(this.EntryNo, this.OP, Master.CurrentUser.thisUserInfo.LoginName) )
				{
					this.CheckRight(this.OP);//检查用户对于当前操作的权限允许，如果没有则直接跳转错误页面，下面的操作将忽略。
					switch (OP)
					{
                        case MZHMM.Common.OP.New:
							this.BindDataNew();
							this.btnRefuse.Visible = false;
							this.btnSave.Text = OPName.New;
							this.btnToRos.Visible = false;
							break;
                        case MZHMM.Common.OP.Red:
							this.BindDataNew();
							this.btnAddByDoc.Visible = false;
							this.btnRefuse.Visible = false;
							this.btnToRos.Visible = false;
							this.btnSave.Text = OPName.New;
                            this.ddlDept.Enable = false;
                            this.ddlProposer.Enable = false;
							break;
                        case MZHMM.Common.OP.Edit:
							this.BindDataUpdate();
							this.btnSave.Text = OPName.Edit;
							this.btnRefuse.Visible = false;
							this.btnToRos.Visible = false;
							break;
                        case MZHMM.Common.OP.Submit:
							this.BindDataUpdate();
							this.btnSave.Text = OPName.Submit;
							this.btnPresent.Visible = false;
							this.ddlDept.Enable = false;
							this.btnAddByDoc.Visible = false;
							this.btnRefuse.Visible = false;
							this.btnToRos.Visible = false;
							break;
                        case MZHMM.Common.OP.FirstAudit:
							this.BindDataUpdate();
							this.btnSave.Text = OPName.FirstAudit;
							this.btnPresent.Visible = false;
							this.ddlDept.Enable = false;
							this.btnAddByDoc.Visible = false;
							this.btnToRos.Visible = false;
							this.btnRefuse.Visible = false;
                            this.ddlProposer.Enable = false;
							break;
                        case MZHMM.Common.OP.SecondAudit:
							this.BindDataUpdate();
							this.btnSave.Text = OPName.SecondAudit;
							this.btnPresent.Visible = false;
							this.ddlDept.Enable = false;
							this.btnAddByDoc.Visible = false;
							this.btnToRos.Visible = false;
							this.btnRefuse.Visible = false;
                            this.ddlProposer.Enable = false;
							break;
                        case MZHMM.Common.OP.ThirdAudit:
							this.BindDataUpdate();
							this.btnSave.Text = OPName.ThirdAudit;
							this.btnPresent.Visible = false;
							this.ddlDept.Enable = false;
							this.btnAddByDoc.Visible = false;
							this.btnToRos.Visible = false;
							this.btnRefuse.Visible = false;
                            this.ddlProposer.Enable = false;
							break;
                        case MZHMM.Common.OP.O:
							this.BindDataUpdate();
							this.btnSave.Text = OPName.O;
							this.btnPresent.Visible = false;
							this.btnAddByDoc.Visible = false;
							this.btnToRos.Visible = false;
							this.btnRefuse.Visible = true;
                            this.ddlDept.Enable = false;
                            this.ddlProposer.Enable = false;
							break;
					}
				}
				else
				{
					this.BindDataUpdate();
					//this.BindDataNew();
					//this.Response.Write("<script>alert('单据的当前状态不允许进行当前操作！');window.history.go(-1);</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('单据的当前状态不允许进行当前操作!');window.history.go(-1);", true);
				}

                if ((strParentEntryNo != "" && strParentEntryNo != "0") || this.OP == MZHMM.Common.OP.Red)
                {
                    item1.OperateRed = true;
                    ddlProposer.Enable = false;
                }
			}
			
		}
		/// <summary>
		/// 拒绝操作。
		/// </summary>
		protected void btnRefuse_Click(object sender, System.EventArgs e)
		{
			int EntryNo;
			string UserLoginId;
			bool ret = false;
			WDRWData oWDRWData = new WDRWData();
			this.FillData(oWDRWData);
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
            UserLoginId = Master.CurrentUser.thisUserInfo.LoginName;

			ItemSystem oItemSystem = new ItemSystem();

            if (Master.HasRight(SysRight.StockOut))
			{
				ret = oItemSystem.RefuseWDRW(EntryNo,UserLoginId);
			}
			if ( ret== false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
			else
			{
				if (this.IsFromTodo)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
                    this.Response.Redirect("DRWBrowser.aspx?DocCode=4");
				}
			}
		}

        public string GetCatCodeByItemCode(string strItemCode)
        {
            dtCatCode = (new ItemSystem()).GetItemByCode(strItemCode).Tables[0];

            if(dtCatCode.Rows.Count > 0)
            {
                return dtCatCode.Rows[0]["CatCode"].ToString();
            }
            else
            {
                return "";
            }
        }

        private bool IsContaintContent(string strItemCodeList,string strReqCode)
        {
            string[] strItemCode = strItemCodeList.Split(',');

            string strReqCodeValue = System.Configuration.ConfigurationManager.AppSettings[strReqCode];

           // int icodelength = 0;

            if (strReqCodeValue != null && strReqCodeValue.Trim() != "")
            {
                //icodelength = strReqCodeValue.Length;
                for (int i = 0; i < strItemCode.Length; i++)
                {
                    if (GetCatCodeByItemCode(strItemCode[i]) != strReqCodeValue)
                    {
                        return false;
                    }
                }
            }

          

            return true;
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

            if (item1.ReqReason == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('没有用途内容!');", true);
                return;
            }
			//构建数据实体.
			WDRWData oWDRWData = new WDRWData();
			this.FillData(oWDRWData);

            if (!IsContaintContent(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('所领物料不符合限制!');", true);
                return;
            }
			this.SetEntryState(oWDRWData, this.OP);
			this.SetEntryOperator(oWDRWData, this.OP);

			ItemSystem oItemSystem = new ItemSystem();
			bool ret = false;

			switch (this.OP)
			{
                case MZHMM.Common.OP.New:	 //新建保存。
					ret = Master.HasRight(SysRight.DRWMaintain)?oItemSystem.AddWDRW(oWDRWData):false;
					break;
                case MZHMM.Common.OP.Red: //红字保存。
                    ret = Master.HasRight(SysRight.DRWRed) ? oItemSystem.AddWDRW(oWDRWData) : false;
					break;
                case MZHMM.Common.OP.Edit: //修改保存。		
                    ret = Master.HasRight(SysRight.DRWMaintain) ? oItemSystem.UpdateWDRW(oWDRWData) : false;
					break;
                case MZHMM.Common.OP.Submit:   //提交保存。
                    ret = Master.HasRight(SysRight.DRWPresent) ? oItemSystem.PresentWDRW(this.EntryNo, this.Master.CurrentUser.thisUserInfo.LoginName) : false;
					break;
					#region 一级审批
                case MZHMM.Common.OP.FirstAudit:
                    if (Master.HasRight(SysRight.DRWFirstAudit))
					{
						if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="Y" &&
							oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
						}
						else
						{
							ret = oItemSystem.FirstAuditWDRW(oWDRWData);
						}
					}
					else
					{
						ret = false;
					}
					break;
					#endregion
					#region SecondAudit
                case MZHMM.Common.OP.SecondAudit:
                    if (Master.HasRight(SysRight.DRWSecondAudit))
					{
						if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() !="Y" &&
							oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
							return;
						}
						else
						{
							ret = oItemSystem.SecondAuditWDRW(oWDRWData);
						}
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region ThirdAudit
                case MZHMM.Common.OP.ThirdAudit:
                    if (Master.HasRight(SysRight.DRWThirdAudit))
					{
						if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() !="Y" &&
							oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
							return;
						}
						else
						{
							ret = oItemSystem.ThirdAuditWDRW(oWDRWData);
						}
					}
					else
					{
						ret = false;
					}
					
					break;
					#endregion
					#region O
                case MZHMM.Common.OP.O:
                    if (Master.HasRight(SysRight.StockOut))
					{
						WDRWData MyWDRWData ;
						MyWDRWData = oItemSystem.GetWDRWByEntryNo(this.EntryNo);
						if (MyWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PARENTENTRYNO_FIELD].ToString()!= null &&
							MyWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PARENTENTRYNO_FIELD].ToString()!= "")
						{
                            ret = oItemSystem.DrawOutStock(this.EntryNo, "", "", "", "", Master.CurrentUser.thisUserInfo.EmpCode, Master.CurrentUser.thisUserInfo.EmpName, Master.CurrentUser.thisUserInfo.LoginName);
						}
						else
						{
							if (this.CheckOutCondition(this.item1.thisTable) == true)
							{
								Session[MySession.DrawDt] = this.item1.thisTable;
								if (this.IsFromTodo)
								{
                                    this.Response.Redirect("ConChooser.aspx?DocCode=4&EntryNo=" + this.doc1.EntryNo.ToString() + "&Op=" + MZHMM.Common.OP.O + "&TODO=Y");
								}
								else
								{
                                    this.Response.Redirect("Conchooser.aspx?DocCode=4&EntryNo=" + this.doc1.EntryNo.ToString() + "&Op=" + MZHMM.Common.OP.O);
								}
							}
							else
							{
								//this.Response.Write("<script>alert(\'当前库存数量不够，是否自动生成申购单！\')</script>");
                                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('当前库存数量不够,请生成紧急申购单!');", true);
								return;
							}
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
				if (this.IsFromTodo && this.PKIDs == null)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else if (this.IsFromTodo && this.PKIDs != null)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(-1);</script>");
				}
				else
				{
                    if (this.OP == MZHMM.Common.OP.O)
					{
						this.Response.Redirect("OUTBrowser.aspx");
					}
					else
					{
						Response.Redirect("DRWBrowser.aspx?DocCode=4");
					}
				}
			}
		}
		/// <summary>
		/// 取消按钮事件。
		/// </summary>
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (this.IsFromTodo && this.PKIDs == null)
			{
				this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
			}
			else if (this.IsFromTodo && this.PKIDs != null)
			{
				this.Response.Write("<script>window.close();window.opener.history.go(-1);</script>");
			}
			else 
			{
                if (this.OP == MZHMM.Common.OP.O)
				{
                    this.Response.Redirect("DRWBrowser.aspx?DocCode=4");
				}
				else
				{
					Response.Redirect("DRWBrowser.aspx?DocCode=4");
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

            if (item1.ReqReason == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('没有用途内容!');", true);
                return;
            }

			//构建数据实体.
			WDRWData oWDRWData = new WDRWData();
			this.FillData(oWDRWData);

            if (!IsContaintContent(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('所领物料不符合限制!');", true);
                return;
            }

			ItemSystem oItemSystem = new ItemSystem();
			
			bool ret = false;
			switch (this.OP)
			{
                case MZHMM.Common.OP.New:
					if (Master.HasRight(SysRight.DRWMaintain) && Master.HasRight(SysRight.DRWPresent))
					{
                        this.OP = MZHMM.Common.OP.NewAndPresent;
						this.SetEntryState(oWDRWData, this.OP);
						this.SetEntryOperator(oWDRWData, this.OP);
						ret = oItemSystem.AddAndPresentWDRW(oWDRWData);
					}
					else
					{
						ret = false;
					}
					break;
                case MZHMM.Common.OP.Red:
                    if (Master.HasRight(SysRight.DRWMaintain) && Master.HasRight(SysRight.DRWPresent))
					{
                        this.OP = MZHMM.Common.OP.NewAndPresent;
						this.SetEntryState(oWDRWData, this.OP);
						this.SetEntryOperator(oWDRWData, this.OP);
						ret = oItemSystem.AddAndPresentWDRW(oWDRWData);
					}
					else
					{
						ret = false;
					}
					break;
                case MZHMM.Common.OP.Edit:
                    if (Master.HasRight(SysRight.DRWMaintain) && Master.HasRight(SysRight.DRWPresent))
					{
                        this.OP = MZHMM.Common.OP.EditAndPresent;
						this.SetEntryState(oWDRWData, this.OP);
						this.SetEntryOperator(oWDRWData, this.OP);
						ret = oItemSystem.UpdateAndPresentWDRW(oWDRWData);
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
				if (this.IsFromTodo && this.PKIDs == null)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else if (this.IsFromTodo && this.PKIDs != null)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(-1);</script>");
				}
				else
				{
					Response.Redirect("DRWBrowser.aspx?DocCode=4");
				}
			}
		}
		/// <summary>
		/// 仓库下拉列表改变事件。
		/// </summary>
		/// <returns></returns>
		protected override bool OnBubbleEvent(object Sender,EventArgs e)
		{
			try
			{
                if (Sender is DropDownList)
                {
                    if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == ddlDept.thisDDL.ClientID)
                    {
                        this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;
                        this.ddlProposer.IsClear = true;
                        this.ddlProposer.DeptCode = this.ddlDept.SelectedValue;
                        this.ddlProposer.SetDDL();
                    }
                }
			}
			catch
			{}
			return true;
		}
		/// <summary>
		/// 由领料单生成申请单。
		/// </summary>
		protected void btnToRos_Click(object sender, System.EventArgs e)
		{
			ItemSystem oItemSystem = new ItemSystem();
		    bool ret = false;
			ret = oItemSystem.WDRW2PROS(this.EntryNo);
			if ( ret== false)
			{
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
		}

		#endregion

        protected void StaticInput_ValueChanged(object sender, EventArgs e)
        {

        }

	}
}
