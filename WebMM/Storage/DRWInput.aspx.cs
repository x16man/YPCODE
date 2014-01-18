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
	/// MRPInput ��ժҪ˵����
	/// </summary>
	public partial class DRWInput : System.Web.UI.Page
	{
		#region ��Ա����
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
		
		#region ����
		/// <summary>
		/// ����Ϣ����ҳ�洫�ݽ�������Ҫ�������ϵ��ķ�����Ϣ
		/// ID��
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
		/// ��ǰҳ��Ĳ�����ʽ��URL���ݽ�����
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
		/// �Ƿ��ǴӴ������˴����ý��롣
		/// </summary>
		/// <remarks>
		/// ��Ϊ��Ҫ���ݲ�ͬ�����ҳ�棬������ɺ�Ҫ����ˢ�¡�
		/// </remarks>
		private bool IsFromTodo
		{
			get 
			{
				return this.Request["TODO"] == null?false:true;
			}
		}
		/// <summary>
		/// ������ˮ�ţ���URL���ݽ�����
		/// </summary>
		private int EntryNo
		{
			get
			{
				return this.Request["EntryNo"] == null?0:Convert.ToInt32(this.Request["EntryNo"].ToString());
			}
		}
		
		#endregion

		#region ˽�з���
		/// <summary>
		/// ���ݲֿ��š�������Ϣ��ȡ�����Ϣ��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
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
		/// ��������״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.DRW;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.DRW;
			this.ddlDept.AutoPostBack = true;	//��ΪҪˢ��ddlProposer���ݡ�
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
				//TODO: ���Ӵӷ�����Ϣ���������ϵ��Ĵ��롣
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
						oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows.RemoveAt(i);//�����ǰ�е���;�͵�һ����һ������ӷ��ص�����ʵ����ɾ��֮��
					}
				}
				if (Temp_Count > oWDRWData.Count)
				{
					//this.Response.Write("<script>alert('��ѡ�ķ�����Ϣ�漰�������;��ֻ������һ����;�����ϵ���������;�����Ͻ������ԣ�');</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ѡ�ķ�����Ϣ�漰�������;��ֻ������һ����;�����ϵ���������;�����Ͻ�������!');", true);
				}
				oDT = oWDRWData.Tables[WDRWData.WDRW_TABLE];
				//�ֿ�.
				if(oDT.Rows.Count > 0)
				{
					this.item1.StoName = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
					this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
					//���ݲֿ����oDT�еĿ����Ϣ��

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
				//��;��
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
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�˵����Ѿ��������ֲ����������ٴν��к��ֲ�����');document.location='DRWBrowser.aspx?DocCode=4';", true);
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
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�˵����Ǻ��ֲ������ݲ������ٴν��к��ֲ�����');document.location='DRWBrowser.aspx?DocCode=4';", true);
                            return;
                        }

						//̨ͷ���֡�
						this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
						this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
						this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
						//�����Ρ�
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
						//���벿�š�
						this.ddlDept.SelectedValue = oDT.Rows[0][WDRWData.REQDEPT_FIELD].ToString();
						this.ddlDept.SelectedText = oDT.Rows[0][WDRWData.REQDEPTNAME_FIELD].ToString();

						//�����ˡ�
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
						//���ϲֿ⡣
						//this.ddlStorage.SelectedText = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
						//this.ddlStorage.SelectedValue = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
						this.item1.StoName = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
						this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
						//��;��
						//this.ddlPurpose.SelectedText = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
						//this.ddlPurpose.SelectedValue = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
						this.item1.ReqReasonCode = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
						this.item1.ReqReason = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
						//this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
						//��ע��
						this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
						this.txtParentEntryNo.Value = oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString();
					}
					else
					{
						//this.Response.Write("<Script>alert('���ϵ������ֵ�ǰ�������Ǹõ����ѷ��ϣ�');</Script>");
						//this.Response.Redirect("DRWBrowser.aspx?DocCode=4",true);
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���ϵ������ֵ�ǰ�������Ǹõ����ѷ���!');document.location='DRWBrowser.aspx?DocCode=4'", true);
					}
				}
			}
			#endregion
		}
		/// <summary>
		/// �༭����״̬�£����ݰ󶨡�
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
			//��������䵽���ݼ�,DataGrid������Դ��
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
                
				//̨ͷ���֡�
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//�����Ρ�
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
				//���벿�š�
				this.ddlDept.SelectedValue = oDT.Rows[0][WDRWData.REQDEPT_FIELD].ToString();
				//this.ddlDept.SelectedText = oDT.Rows[0][WDRWData.REQDEPTNAME_FIELD].ToString();

				//�����ˡ�
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
				//���ϲֿ⡣
//                this.ddlStorage.SelectedText = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
//				this.ddlStorage.SelectedValue = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
				this.item1.StoName = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
				this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
				//��;��
				//this.ddlPurpose.SelectedText = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
				//this.ddlPurpose.SelectedValue = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
				this.item1.ReqReasonCode = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
				this.item1.ReqReason = oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
				//this.item1.StoCode = oDT.Rows[0][WDRWData.STOCODE_FIELD].ToString();
				//��ע��
				this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//����ģʽ�³�ʼ�������˺����ڡ�
                if (this.OP == MZHMM.Common.OP.O)
				{
                    this.TextBox1.Text = Master.CurrentUser.thisUserInfo.EmpName;
					this.TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
				}
			}
		}

		/// <summary>
		/// �����������ݡ�
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
		/// ������䡣
		/// </summary>
		/// <param name="oWDRWData">WDRWData:	���ϵ�ʵ�塣</param>
		private void FillData(WDRWData oWDRWData)
		{
			DataRow dr = oWDRWData.Tables[WDRWData.WDRW_TABLE].NewRow();
			//����̨ͷ�������ݡ�
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�
//			dr[WDRWData.STONAME_FIELD] = ddlStorage.SelectedText;					//���ϲֿ����ơ�
//			dr[WDRWData.STOCODE_FIELD] = ddlStorage.SelectedValue;					//���ϲֿ��š�
			dr[WDRWData.STONAME_FIELD] = this.item1.StoName;					//���ϲֿ����ơ�
			dr[WDRWData.STOCODE_FIELD] = this.item1.StoCode;					//���ϲֿ��š�
			dr[InItemData.REMARK_FIELD] = this.item1.Remark;						//��ע��
			dr[WDRWData.REQDEPT_FIELD] = this.ddlDept.SelectedValue;				//���첿�š�
			dr[WDRWData.REQDEPTNAME_FIELD] = this.ddlDept.SelectedText;				//���첿�����ơ�
			//dr[WDRWData.PROPOSER_FIELD] = this.txtProposer.Text;					
			dr[WDRWData.PROPOSERCODE_FIELD] = this.ddlProposer.SelectedValue;//�����˱�š�
			dr[WDRWData.PROPOSER_FIELD] = this.ddlProposer.SelectedText;//���������ơ�
			dr[WDRWData.REQREASON_FIELD] = this.item1.ReqReason;					//��;���ơ�
			dr[WDRWData.REQREASONCODE_FIELD] = this.item1.ReqReasonCode;			//��;��š�
			try
			{
                dr[WDRWData.PARENTENTRYNO_FIELD] = this.txtParentEntryNo.Value;			//���ָ����ݺš�
			}
			catch
			{}
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������
			
			Col2List MyCol2List = new Col2List(this.item1.thisTable);
			
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();									//˳��š�
			dr[WDRWData.SOURCEENTRY_FIELD] = MyCol2List.GetList(WDRWData.SOURCEENTRY_FIELD);		//Դ������ˮ�š�
			dr[WDRWData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(WDRWData.SOURCEDOCCODE_FIELD);	//Դ�������͡�
			dr[WDRWData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(WDRWData.SOURCESERIALNO_FIELD);	//Դ����˳��š�
		    dr[InItemData.NEWCODE_FIELD] = MyCol2List.GetList(InItemData.NEWCODE_FIELD);            //�±�š�
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);			//���ϱ�š�
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);			//�������ơ�
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);	//����ͺš�
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);			//��λ��
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);	//��λ���ơ�
			dr[WDRWData.PLANNUM_FIELD] = MyCol2List.GetList(WDRWData.PLANNUM_FIELD);				//����������
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);			//ʵ��������
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);		//���ۡ�
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);		//��
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);			//�ϼƽ�
			
			oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows.Add(dr);
		}
		/// <summary>
		/// ���õ���״̬��
		/// </summary>
		/// <param name="oWDRWData">WDRWData:	���ϵ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryState(WDRWData oWDRWData, string OpMode)
		{
			if ( oWDRWData.Count > 0)
			{
				DataRow oDataRow = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oWDRWData.Tables[WDRWData.WDRW_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// ���õ��ݲ����ˡ�
		/// </summary>
		/// <param name="oWDRWData">WDRWData:	���ϵ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryOperator(WDRWData oWDRWData, string OpMode)
		{
			if ( oWDRWData.Count > 0)
			{
				DataRow oDataRow = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0];

				switch (OpMode)
				{
                    case MZHMM.Common.OP.New://�½���
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case MZHMM.Common.OP.Red:  //���֡�
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
                    case MZHMM.Common.OP.Edit://�༭��
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
                    case MZHMM.Common.OP.FirstAudit://һ��������
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
                    case MZHMM.Common.OP.SecondAudit://����������
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
                    case MZHMM.Common.OP.ThirdAudit://����������
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
		/// ���ֿⷢ�ϵ�ǰ��������
		/// </summary>
		/// <param name="dt">DataTable:	���ϵ����ݱ�</param>
		/// <returns>bool:	������������true,�����Ϸ���false.</returns>
		private bool CheckOutCondition(DataTable dt)
		{
			decimal StockNum,ItemNum;//���������������
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
				//����ͬ�����ۼƵķ�������
				for (int j = i+1; j< dt.Rows.Count; j++)
				{
					if (ItemCode == "-1")//OTI���ϡ�
					{
						if (ItemCode == dt.Rows[j]["ItemCode"].ToString() &&
							ItemName == dt.Rows[j]["ItemName"].ToString() &&
							ItemSpec == dt.Rows[j]["ItemSpecial"].ToString())//����ͬ�����ϡ�
						{
							try
							{	ItemNum += Convert.ToDecimal(dt.Rows[j]["ItemNum"].ToString());}
							catch
							{ }
						}
					}
					else//�������ϡ�
					{
						if (ItemCode == dt.Rows[j]["ItemCode"].ToString() )//����ͬ�����ϡ�
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
		/// �ж����ϵ�������ǰ��������
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>bool:	������������򷵻�true,�������򷵻�false.</returns>
		private bool CheckPreCondition(int EntryNo)
		{
			return false;
		}
//		/// <summary>
//		/// ���ݲֿ��š�������Ϣ��ȡ�����Ϣ��
//		/// </summary>
//		/// <param name="StoCode">string:	�ֿ��š�</param>
//		/// <param name="ItemCode">string:	���ϱ�š�</param>
//		/// <param name="ItemName">string:	�������ơ�</param>
//		/// <param name="ItemSpec">string:	����ͺš�</param>
//		/// <returns>decimal:	ָ���ֿ�ָ�����ϵĿ������</returns>
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
		/// ��֤Ȩ�ޡ�
		/// </summary>
		/// <param name="OP">string:	�������롣</param>
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
		
		#region �¼�
		/// <summary>
		/// ҳ���Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.DRW;
            this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
            this.TextBox2.Attributes.Add("ReadOnly", "ReadOnly");
            item1.IsDisplayDRWPrice = Master.DisplayDRWPrice;
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!this.IsPostBack)
			{	
				//��鵥�ݵ�״̬�Ƿ���ϵ�ǰ������ǰ��������
				if ( new ItemSystem().CheckPreconditionOfWDRW(this.EntryNo, this.OP, Master.CurrentUser.thisUserInfo.LoginName) )
				{
					this.CheckRight(this.OP);//����û����ڵ�ǰ������Ȩ���������û����ֱ����ת����ҳ�棬����Ĳ��������ԡ�
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
					//this.Response.Write("<script>alert('���ݵĵ�ǰ״̬��������е�ǰ������');window.history.go(-1);</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('���ݵĵ�ǰ״̬��������е�ǰ����!');window.history.go(-1);", true);
				}

                if ((strParentEntryNo != "" && strParentEntryNo != "0") || this.OP == MZHMM.Common.OP.Red)
                {
                    item1.OperateRed = true;
                    ddlProposer.Enable = false;
                }
			}
			
		}
		/// <summary>
		/// �ܾ�������
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
		/// ���水ť��
		/// </summary>
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            if (item1.ReqReason == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('û����;����!');", true);
                return;
            }
			//��������ʵ��.
			WDRWData oWDRWData = new WDRWData();
			this.FillData(oWDRWData);

            if (!IsContaintContent(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�������ϲ���������!');", true);
                return;
            }
			this.SetEntryState(oWDRWData, this.OP);
			this.SetEntryOperator(oWDRWData, this.OP);

			ItemSystem oItemSystem = new ItemSystem();
			bool ret = false;

			switch (this.OP)
			{
                case MZHMM.Common.OP.New:	 //�½����档
					ret = Master.HasRight(SysRight.DRWMaintain)?oItemSystem.AddWDRW(oWDRWData):false;
					break;
                case MZHMM.Common.OP.Red: //���ֱ��档
                    ret = Master.HasRight(SysRight.DRWRed) ? oItemSystem.AddWDRW(oWDRWData) : false;
					break;
                case MZHMM.Common.OP.Edit: //�޸ı��档		
                    ret = Master.HasRight(SysRight.DRWMaintain) ? oItemSystem.UpdateWDRW(oWDRWData) : false;
					break;
                case MZHMM.Common.OP.Submit:   //�ύ���档
                    ret = Master.HasRight(SysRight.DRWPresent) ? oItemSystem.PresentWDRW(this.EntryNo, this.Master.CurrentUser.thisUserInfo.LoginName) : false;
					break;
					#region һ������
                case MZHMM.Common.OP.FirstAudit:
                    if (Master.HasRight(SysRight.DRWFirstAudit))
					{
						if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="Y" &&
							oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() !="N")
						{
							//this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
							//this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
							//this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
								//this.Response.Write("<script>alert(\'��ǰ��������������Ƿ��Զ������깺����\')</script>");
                                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ǰ�����������,�����ɽ����깺��!');", true);
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
		/// ȡ����ť�¼���
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
		/// �����ύ�¼���
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            if (item1.ReqReason == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('û����;����!');", true);
                return;
            }

			//��������ʵ��.
			WDRWData oWDRWData = new WDRWData();
			this.FillData(oWDRWData);

            if (!IsContaintContent(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�������ϲ���������!');", true);
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
		/// �ֿ������б�ı��¼���
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
		/// �����ϵ��������뵥��
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
