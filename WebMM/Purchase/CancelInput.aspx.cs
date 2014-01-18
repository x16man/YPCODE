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
	/// MRPInput ��ժҪ˵����
	/// </summary>
	public partial class CancelInput : System.Web.UI.Page
	{
		#region ��Ա����
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

		#region ˽�з���
		/// <summary>
		/// ��������״̬�£����ݰ󶨡�
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
		/// �༭����״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataUpdate()
		{
			this.DocAuditWebControl1.DocCode = DocType.CANCEL;
			this._EntryNo = Convert.ToInt32(Request["EntryNo"].ToString());
		   
			this.doc1.DocCode = DocType.CANCEL;
			this.doc1.DataBindUpdate();
			//��������䵽���ݼ�,DataGrid������Դ��
			oCancelData = oPurchaseSystem.GetCancelByEntryNo(_EntryNo);
			//��������ǰ��������
			this.CheckOpPrecondition(this._OP, oCancelData);
			oDT = oCancelData.Tables[CancelData.PCOR_Table];
			this.item1.thisTable = oDT;

			if (oDT.Rows.Count > 0)
			{
				//̨ͷ���֡�
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][CancelData.EntryNo_Field].ToString());
				this.doc1.EntryCode = oDT.Rows[0][CancelData.EntryCode_Field].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][CancelData.EntryDate_Field].ToString());
				//�������벿��.
				this.txtAuthorName.Text = oDT.Rows[0][CancelData.AuthorName_Field].ToString();
				this.txtAuthorDeptName.Text = oDT.Rows[0][CancelData.AuthorDeptName_Field].ToString();
				//��ע��
				this.item1.txtRemark.Text = oDT.Rows[0][CancelData.Remark_Field].ToString();
				//�����Ρ�
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
		/// ����ָ�������б��ѡ���
		/// </summary>
		/// <param name="List">DropDownList�������б�</param>
		/// <param name="TargetValue">string:	ָ��ֵ��</param>
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
		/// ���õ���״̬��
		/// </summary>
		/// <param name="oCancelData">PurchaseOrderData:	�ɹ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryState(CancelData oCancelData, string OpMode)
		{
			if (oCancelData.Count > 0)
			{
				oDataRow = oCancelData.Tables[CancelData.PCOR_Table].Rows[0];
				oDataRow[CancelData.EntryState_Field] = new Entry(oCancelData.Tables[CancelData.PCOR_Table]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// ���õ��ݲ����ˡ�
		/// </summary>
		/// <param name="oCancelData">PurchaseOrderData:	�ɹ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetOperator(CancelData oCancelData, string OpMode)
		{
			if (oCancelData.Count > 0)
			{
				oDataRow = oCancelData.Tables[CancelData.PCOR_Table].Rows[0];

				switch (OpMode)
				{
					case OP.New://�½���
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndPresent://�½������ύ��
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndAssign://�½�����ָ�ɡ�
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Edit://�༭��
						oDataRow[CancelData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[CancelData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						oDataRow[CancelData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
						oDataRow[CancelData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.EditAndPresent://�༭�����ύ��
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
					case OP.FirstAudit://һ��������
						oDataRow[CancelData.Assessor1_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.SecondAudit://����������
						oDataRow[CancelData.Assessor2_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.ThirdAudit://����������
						oDataRow[CancelData.Assessor3_Field] = Master.CurrentUser.thisUserInfo.EmpName;
						oDataRow[CancelData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
				}
			}
		}

		/// <summary>
		/// ������ݼ���
		/// </summary>
		/// <param name="oCancelData">PurchaseOrderData:	�ɹ�����ʵ�塣</param>
		private void FillData(CancelData oCancelData)
		{
			DataRow dr = oCancelData.Tables[CancelData.PCOR_Table].NewRow();
			//����̨ͷ�������ݡ�
			dr[CancelData.EntryNo_Field] = doc1.EntryNo;							//������ˮ�š�
			dr[CancelData.EntryCode_Field] = doc1.EntryCode;						//���ݱ�š�
			dr[CancelData.DocCode_Field] = doc1.DocCode;							//�������͡�
			dr[CancelData.DocName_Field] = doc1.DocName;							//�����������ơ�
			dr[CancelData.DocNo_Field] = doc1.DocNo;								//�����ĵ���š�
			dr[CancelData.EntryDate_Field] = DateTime.Now;							//�������ڡ�

			dr[CancelData.Remark_Field] = this.item1.txtRemark.Text;				//��ע��
			//�����Ρ�
			dr[CancelData.Audit1_Field] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
			dr[CancelData.Audit2_Field] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
			dr[CancelData.Audit3_Field] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������

			dr[CancelData.AuditSuggest1_Field] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
			dr[CancelData.AuditSuggest2_Field] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
			dr[CancelData.AuditSuggest3_Field] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������
			//������ϸ��
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
		/// ��������ǰ��������
		/// </summary>
		/// <param name="OpMode">string:	����ģʽ��</param>
		/// <param name="oCancelData">PurchasePlanData:	��������ʵ�塣</param>
		private void CheckOpPrecondition(string OpMode,CancelData oCancelData)
		{
			switch (OpMode)
			{
				case OP.Edit://�༭��
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�ɹ��������������޸ĵ�ǰ��������", true); }
					break;
				case OP.Assigned://�ύ��
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
						oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�ɹ��������������ύ��ǰ��������", true); }
					break;
				case OP.FirstAudit://һ��������
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Present)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�ɹ�������������һ��������ǰ��������", true); }
					break;
				case OP.SecondAudit://����������
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�ɹ������������϶���������ǰ��������", true); }
					break;
				case OP.ThirdAudit://����������
					if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecPass)
					{ return; }
					else
					{ Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�ɹ�����������������������ǰ��������", true); }
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
			oCancelData = new CancelData();
			//������ݼ���
			this.FillData(oCancelData);
			//���õ���״̬��
			this.SetEntryState(oCancelData, this._OP);
			//���ò����ˡ�
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
							ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
							ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
							
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
							ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
							
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
		/// ȡ����ť�¼���
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
		/// ����ָ���¼���
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//û������
			if (item1.thisTable.Rows.Count == 0)
			{
				this.Page.RegisterStartupScript( "Error", "<script>alert('û����������!');</script>");
				return;
			}

			//��������ʵ��.
		   oCancelData = new CancelData();
			//������ݼ���
			this.FillData(oCancelData);
		   oPurchaseSystem = new PurchaseSystem();

			bret = true;
			switch (this._OP)
			{
				case OP.New:
					if (Master.HasRight(SysRight.CancelMaintain) && Master.HasRight(SysRight.CancelPresent))
					{
						this._OP = OP.NewAndPresent;
						//���õ���״̬��
						this.SetEntryState(oCancelData, this._OP);
						//���ò����ˡ�
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
						//���õ���״̬��
						this.SetEntryState(oCancelData, this._OP);
						//���ò����ˡ�
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


