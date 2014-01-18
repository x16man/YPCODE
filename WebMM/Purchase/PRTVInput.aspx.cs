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
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// PRTVInput �ɹ����ϵ���ժҪ˵����
	/// </summary>
	public partial class PRTVInput : System.Web.UI.Page
	{
		#region ��Ա����
		private string _OP;
	//	private int _EntryNo;
		//private bool IsTODO;
		protected DocWebControl doc1;
		protected PRTVWebControl item1;
		protected StorageDropdownlist ddlStock;
		protected StorageDropdownlist ddlPayStyle;
		protected StorageDropdownlist ddlBuyer;
		protected StorageDropdownlist ddlCurrency;
		protected StorageDropdownlist ddlCheckResult;
		protected DocAuditWebControl DocAuditWebControl1;
		
		//protected User myUser;
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

        PRTVData oPRTVData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

        PurchaseSystem oPS = new PurchaseSystem();

	    private RTVSData oRTVSData = new RTVSData();

	    private DataRow dr;

	    private DataRow oDataRow;

	    private Col2List MyCol2List;

	    private bool ret;

        DataTable oDT;

		#endregion
		
		#region ˽�з���
		/// <summary>
		/// ��������״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.RTV;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.RTV;
			this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
			//this.ddlCheckResult.Width = "100%";
			//this.ddlPayStyle.Width = "100%";
			//this.ddlProvider.Module_Tag = (int)SDDLTYPE.VENDOR;
			this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
			//this.ddlStock.Width = "100%";
			this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
            this.lblAuthor.Text = Master.CurrentUser.thisUserInfo.EmpName;
            this.ddlBuyer.SelectedValue = Master.CurrentUser.thisUserInfo.EmpCode;
		}
		/// <summary>
		/// �༭����״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataUpdate()
		{
			
			this.doc1.DocCode=DocType.RTV;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode=DocType.RTV;
			this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
			//this.ddlCheckResult.Width = "100%";
			//this.ddlPayStyle.Width = "100%";
			//this.ddlProvider.Module_Tag = (int)SDDLTYPE.VENDOR;
			this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
			//this.ddlStock.Width = "100%";
			this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
			
			//��������䵽���ݼ�,DataGrid������Դ��
			oPRTVData = oPurchaseSystem.GetPRTVByEntryNo(Master.EntryNo);
			this.CheckOpPrecondition(this._OP, oPRTVData);
			if(this._OP != OP.New )
			{
				for(int i = 0; i<oPRTVData.Tables[0].Rows.Count;i++)
					oPRTVData.Tables[0].Rows[i][InItemData.ITEMNUM_FIELD] =oPRTVData.Tables[0].Rows[i][PRTVData.PLANNUM_FIELD];
			}

			oDT = oPRTVData.Tables[PRTVData.PRTV_TABLE];
			this.item1.thisTable = oDT;
			this.HyperLink1.Text = "�ɹ����ϵ�"+oDT.Rows[0][PRTVData.SOURCEENTRY_FIELD].ToString();
			this.HyperLink1.NavigateUrl = "PBorDetail.aspx?EntryNo="+oDT.Rows[0][PRTVData.SOURCEENTRY_FIELD].ToString()+"&Op=View";
			if (oDT.Rows.Count > 0)
			{
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
                    this.DocAuditWebControl1.txtAuditDate1.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }
                try
                {
                    this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }
                try
                {
                    this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }

                

				//�ɹ�Ա��
				this.ddlBuyer.SelectedText = oDT.Rows[0][PRTVData.BUYERNAME_FIELD].ToString();
				this.ddlBuyer.SelectedValue = oDT.Rows[0][PRTVData.BUYERCODE_FIELD].ToString();
				//�ֿ����Ա��
				this.txtStoManager.Text = oDT.Rows[0][PRTVData.ACCEPTNAME_FIELD].ToString();
				//���ʽ
				this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString());
				this.ddlPayStyle.SelectedValue = oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString();
				this.ddlCurrency.SetItemSelected(oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString());
				this.ddlCurrency.SelectedValue = oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString();
				//��Ӧ�̡�
				//this.ddlProvider.SelectedText = oDT.Rows[0][PRTVData.PRVNAME_FIELD].ToString();
				//this.ddlProvider.SelectedValue = oDT.Rows[0][PRTVData.PRVCODE_FIELD].ToString();
				this.txtVendorCode.Value = oDT.Rows[0][PRTVData.PRVCODE_FIELD].ToString();
				this.txtVendor.Text = oDT.Rows[0][PRTVData.PRVNAME_FIELD].ToString();
				//�ֿ⡣
				this.ddlStock.SelectedText = oDT.Rows[0][PRTVData.STONAME_FIELD].ToString();
				this.ddlStock.SelectedValue = oDT.Rows[0][PRTVData.STOCODE_FIELD].ToString();
				//��ע��
				this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				this.ddlCheckResult.SelectedValue = oDT.Rows[0][PRTVData.CHKRESULT_FIELD].ToString();
				this.txtInvoice.Text = oDT.Rows[0][PRTVData.INVOICENO_FIELD].ToString();
				this.txtJFKM.Text = oDT.Rows[0][PRTVData.JFKM_FIELD].ToString();
				this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
				

				if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
				{
                    this.ddlBuyer.thisDDL.Enabled = false;
					this.ddlPayStyle.thisDDL.Enabled = false;
					//this.ddlProvider.thisDDL.Enabled =false;
					this.ddlStock.thisDDL.Enabled = false;

					this.ddlCheckResult.Enable = false;
					this.txtInvoice.Enabled = false;
					this.txtJFKM.Enabled = false;
				}
			}
		}

		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="OpMode">string: ����ģʽ��</param>
		/// <param name="oPRTVData">PRTVData:	����ʵ�塣</param>
		/// <returns>bool:	ǰ�����������򷵻�True���������򷵻�False��</returns>
		private void CheckOpPrecondition(string OpMode,PRTVData oPRTVData)
		{	
			switch (OpMode)
			{
				case OP.Edit://�༭��
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XUpdate, true); }
					break;
				case OP.Submit://�ύ��
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XPresent, true); }
					break;
				case OP.FirstAudit://һ��������
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XFirstAudit, true); }
					break;
				case OP.SecondAudit://����������
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
					{	return ;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XSecondAudit, true); }
					break;
				case OP.ThirdAudit://����������
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XThirdAudit, true); }
					break;
			}
		}
		
		/// <summary>
		/// ���õ���״̬��
		/// </summary>
		/// <param name="oPRTVData">PRTVData:	�ɹ��˻���ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryState(PRTVData oPRTVData, string OpMode)
		{
			if ( oPRTVData.Count > 0)
			{
				oDataRow = oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPRTVData.Tables[0]).GetEntryState(OpMode);
			}
//			if ( oPRTVData.Count > 0)
//			{
//				DataRow oDataRow = oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0];
//
//				switch (OpMode)
//				{
//					case OP.New:
//						oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.New;
//						break;
//					case OP.Edit:
//						oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.New;
//						break;
//					case OP.FirstAudit:
//						if ( oDataRow[InItemData.AUDIT1_FIELD].ToString() == AuditResult.Passed )
//						{
//
//							oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.FstPass;
//						}
//						else
//						{
//							if ( oDataRow[InItemData.AUDIT1_FIELD].ToString() == AuditResult.NoPassed )
//							{
//								oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.FstNoPass;
//							}
//						}
//						break;
//					case OP.SecondAudit:
//						if ( oDataRow[InItemData.AUDIT2_FIELD].ToString() == AuditResult.Passed )
//						{
//							oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.SecPass;
//						}
//						else
//						{
//							if ( oDataRow[InItemData.AUDIT2_FIELD].ToString() == AuditResult.NoPassed )
//							{
//								oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.SecNoPass;
//							}
//						}
//						break;
//					case OP.ThirdAudit:
//						if ( oDataRow[InItemData.AUDIT3_FIELD].ToString() == AuditResult.Passed )
//						{
//							oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.TrdPass;
//						}
//						else
//						{
//							if ( oDataRow[InItemData.AUDIT3_FIELD].ToString() == AuditResult.NoPassed )
//							{
//								oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.TrdNoPass;
//							}
//						}
//						break;
//					case OP.I:
//						//TODO: ADD Bor's receive status.
//						oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.Received;
//						break;
//				}
//			}
		}

		/// <summary>
		/// ���õ��ݲ����ˡ�
		/// </summary>
		/// <param name="oPRTVData">PRTVData:	�ɹ��˻���ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetOperator(PRTVData oPRTVData, string OpMode)
		{
			if ( oPRTVData.Count > 0)
			{
				oDataRow = oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://�½���
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case OP.Submit://�½���
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
					case OP.Edit://�༭��
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.FirstAudit://һ��������
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.SecondAudit://����������
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.ThirdAudit://����������
                        oDataRow[InItemData.ASSESSOR3_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.I://���ϡ�
						oDataRow[BillOfReceiveData.ACCEPTCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[BillOfReceiveData.ACCEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
				}
			}
		}

		/// <summary>
		/// ���ɹ��˻���ʵ�塣
		/// </summary>
		/// <param name="oPRTVData">PRTVData:	�ɹ��˻���ʵ�塣</param>
		private void FillData(PRTVData oPRTVData)
		{
			

			dr = oPRTVData.Tables[PRTVData.PRTV_TABLE].NewRow();
			//����̨ͷ�������ݡ�
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�

			dr[InItemData.REMARK_FIELD] = this.item1.Remark;						//��ע��
            dr[PRTVData.PRVCODE_FIELD] = this.txtVendorCode.Value;					//��Ӧ��λ��
			dr[PRTVData.PRVNAME_FIELD] = this.txtVendor.Text;					//��Ӧ�����ơ�
			dr[PRTVData.STOCODE_FIELD] = ddlStock.SelectedValue;					//�ֿ⡣
			dr[PRTVData.STONAME_FIELD] = ddlStock.SelectedText;						//�ֿ����ơ�
			dr[PRTVData.CURRENCYCODE_FIELD] = ddlCurrency.SelectedValue;			//���֡�
			dr[PRTVData.INVOICENO_FIELD] = Master.GetNoSpaceString(txtInvoice.Text);							//��Ʊ��
			dr[PRTVData.JFKM_FIELD] = txtJFKM.Text;									//��ƿ�Ŀ��
			dr[PRTVData.PAYSTYLE_FIELD] = ddlPayStyle.SelectedValue;				//���ʽ��
			dr[PRTVData.CHKRESULT_FIELD] = ddlCheckResult.SelectedValue;			//���������
			dr[PRTVData.BUYERCODE_FIELD] = ddlBuyer.SelectedValue;					//�ɹ�Ա��š�
			dr[PRTVData.BUYERNAME_FIELD] = ddlBuyer.SelectedText;					//�ɹ�Ա���ơ�
			
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������

			//Col2List MyCol2List = new Col2List(oPRTVData.Tables[PRTVData.PRTV_TABLE]);
			MyCol2List = new Col2List(this.item1.thisTable);
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(PRTVData.ITEMSUM_FIELD);//�빺���ϼƽ�
			dr[PRTVData.TOTALTAX_FIELD] = MyCol2List.GetSum(PRTVData.ITEMTAX_FIELD);
			dr[PRTVData.TOTALMONEY_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);
			dr[PRTVData.SOURCEENTRY_FIELD] = MyCol2List.GetList(PRTVData.SOURCEENTRY_FIELD);
			dr[PRTVData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(PRTVData.SOURCEDOCCODE_FIELD);
			dr[PRTVData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(PRTVData.SOURCESERIALNO_FIELD);
			dr[PRTVData.PLANNUM_FIELD] = MyCol2List.GetList(PRTVData.PLANNUM_FIELD);
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
			dr[PRTVData.TAXCODE_FIELD] = MyCol2List.GetList(PRTVData.TAXCODE_FIELD);
			dr[PRTVData.TAXRATE_FIELD] = MyCol2List.GetList(PRTVData.TAXRATE_FIELD);
			dr[PRTVData.ITEMTAX_FIELD] = MyCol2List.GetList(PRTVData.ITEMTAX_FIELD);
			dr[PRTVData.ITEMSUM_FIELD] = MyCol2List.GetList(PRTVData.ITEMSUM_FIELD);
			oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows.Add(dr);
			this.SetEntryState(oPRTVData,this._OP);
			this.SetOperator(oPRTVData,this._OP);
		}
		#endregion
		
		
		
		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.RTV;
			// �ڴ˴������û������Գ�ʼ��ҳ��
			_OP = Request["Op"].ToString();

           
			
			SetEditMode();
            item1.IsDisplayPRTVPrice = Master.DisplayPRTVPrice;
			if(!this.IsPostBack)
			{
				switch (_OP)
				{
					case OP.New:
						if (!Master.HasRight(SysRight.RTVMaintain))
						{	
							//this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataNew();
						this.btnSave.Text = OPName.New;
						break;
					case OP.Edit:
                        if (!Master.HasRight(SysRight.RTVMaintain))
						{	
							//.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Edit;
						break;
					case OP.Submit:
                        if (!Master.HasRight(SysRight.RTVPresent))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Submit;
						break;
					case OP.FirstAudit:
                        if (!Master.HasRight(SysRight.RTVFirstAudit))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.FirstAudit;
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
                        Image1.Visible = false;
						break;
					case OP.SecondAudit:
                        if (!Master.HasRight(SysRight.RTVSecondAudit))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
                        Image1.Visible = false;
						this.btnSave.Text = OPName.SecondAudit;
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
						break;
					case OP.ThirdAudit:
						if (!Master.HasRight(SysRight.RTVThirdAudit))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
                        Image1.Visible = false;
						this.btnSave.Text = OPName.ThirdAudit;
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
						break;
					case OP.I:
                        if (!Master.HasRight(SysRight.StockOut))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
                        Image1.Visible = false;
						this.btnSave.Text = "����";
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
						break;
				}
			}
		}
		private void SetEditMode()
		{
			switch(this._OP)
			{
				case OP.New:
					break;
				case OP.Edit:
					break;
				default:
					//this.ddlProvider.Enable = false;
					this.ddlStock.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlCurrency.Enable = false;
					this.txtInvoice.ReadOnly= true;
					this.txtJFKM.ReadOnly = true;
					this.ddlCheckResult.Enable = false;
					this.btnSelectProvider.Disabled = true;
					break;
			}
		}

        private bool CheckInvoice()
        {
            if (this.txtInvoice.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('��Ʊ�Ų���Ϊ��');", true);

                return false;
            }

            if (this.txtInvoice.Text.IndexOf("��") > -1)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('��Ʊ�Ų��������Ķ���');", true);

                return false;
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

			//��������ʵ��.
			oPRTVData = new PRTVData();
			//������ݼ���			
			this.FillData(oPRTVData);
			
			
			ret = true;
			switch (this._OP)
			{
				case OP.New:
                   
					if (Master.HasRight(SysRight.RTVMaintain))
					{
                        if (CheckInvoice())
						    ret = oPurchaseSystem.AddPRTV(oPRTVData);
                        else
                            return;
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.Edit:
                    
                    if (Master.HasRight(SysRight.RTVMaintain))
					{
                        if (CheckInvoice())
                            ret = oPurchaseSystem.UpdatePRTV(oPRTVData, Master.CurrentUser.thisUserInfo.EmpCode);
                        else
                            return;
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Submit:
                   
                    if (Master.HasRight(SysRight.RTVPresent))
					{
                        if (CheckInvoice())
                            ret = oPurchaseSystem.PresentPRTV(Master.EntryNo, Master.CurrentUser.thisUserInfo.LoginName, Master.CurrentUser.thisUserInfo.EmpCode);
                        else
                            return;
                    }
					else
					{
						ret = false;
					}
					break;
				case OP.FirstAudit:
                    if (Master.HasRight(SysRight.RTVFirstAudit))
					{
						ret = oPurchaseSystem.FirstAuditPRTV(oPRTVData);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.SecondAudit:
                    if (Master.HasRight(SysRight.RTVSecondAudit))
					{
						ret = oPurchaseSystem.SecondAuditPRTV(oPRTVData);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.RTVThirdAudit))
					{
						ret = oPurchaseSystem.ThirdAuditPRTV(oPRTVData);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.I:
                    if (Master.HasRight(SysRight.StockOut))
					{
						Session[MySession.DrawDt] = this.item1.thisTable;
						this.Response.Redirect("../Storage/ConChooser.aspx?DocCode=7&EntryNo="+this.doc1.EntryNo.ToString()+"&Op="+OP.I);
					}
					else
					{
						ret = false;
					}
					
					break;
			}
					
			if ( ret== false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
			}
			else
			{
				if (Master.IsTODO)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
					Response.Redirect("PRTVBrowser.aspx?DocCode=7");
				}
				
			}
		}


		protected void btnForPKID_Click(object sender, System.EventArgs e)
		{
           // PurchaseSystem oPS = new PurchaseSystem();
            oRTVSData = oPS.GetRTVSByPKID(txtPKID.Value);
            if (oRTVSData.Tables[RTVSData.RTVS_VIEW].Rows.Count > 0)
            {
                dr = oRTVSData.Tables[RTVSData.RTVS_VIEW].Rows[0];
                //�ֿ⡣
                this.ddlStock.SelectedText = dr[RTVSData.STONAME_FIELD].ToString();
                this.ddlStock.SelectedValue = dr[RTVSData.STOCODE_FIELD].ToString();
                this.ddlStock.SetItemSelected(dr[RTVSData.STOCODE_FIELD].ToString());
                //���֡�
                this.ddlCurrency.SetItemSelected(dr[RTVSData.CURRENCYCODE_FIELD].ToString());
                //�ɹ�Ա��
                this.ddlBuyer.SelectedText = dr[RTVSData.BUYERNAME_FIELD].ToString();
                this.ddlBuyer.SelectedValue = dr[RTVSData.BUYERCODE_FIELD].ToString();
                this.ddlBuyer.SetItemSelected(dr[RTVSData.BUYERCODE_FIELD].ToString());
                //ԭ�ɹ����ϵ����ӡ�
                this.HyperLink1.Text = "�ɹ����ϵ�" + dr[RTVSData.ENTRYNO_FIELD].ToString() + "��";
                this.HyperLink1.NavigateUrl = "PBorDetail.aspx?EntryNo=" + dr[RTVSData.ENTRYNO_FIELD].ToString() + "&Op=View";
                //�����б�
                 item1.PKID = this.txtPKID.Value;

            }
		}

		/// <summary>
		/// ȡ����ť��
		/// </summary>
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (Master.IsTODO)
			{
				this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
			}
			else
			{
				Response.Redirect("PRTVBrowser.aspx?DocCode=7");
			}
		}
		#endregion




	}
}