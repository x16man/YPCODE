using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;

#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

/* ---------------------------------------------------------------------*
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
	/// <summary>
	/// ROSDetail ��ժҪ˵����
	/// </summary>
	public partial class CancelDetail : Page
	{
		#region ��Ա����
		protected DocWebControl DocWebControl1 = new DocWebControl();//����̨ͷ��
		protected Shmzh.Web.UI.Controls.MzhDataGrid  DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();//�����
		protected DocAuditWebControl DocAuditWebControl1 = new DocAuditWebControl();//�����������֡�
//��ע��
//���벿�š�
		protected System.Web.UI.WebControls.Label td_Width;//��;��
		private int _EntryNo;//������ˮ�ţ���URL���ݽ�����

        CancelData oCancelData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        DataTable oDT;
   

		#endregion

		#region ˽�з���
		private void BindData()
		{
		
			this.DocWebControl1.DocCode = DocType.CANCEL;
			this.DocWebControl1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.CANCEL;
			//��������䵽���ݼ�,DataGrid������Դ��
			oCancelData = oPurchaseSystem.GetCancelByEntryNo(_EntryNo);
			oDT = oCancelData.Tables[CancelData.PCOR_Table];
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.Cancel;
			this.DGModel_Items1.DataSource = oDT;
			this.DGModel_Items1.DataBind();
			if (oDT.Rows.Count > 0)
			{
				//̨ͷ���֡�
				this.DocWebControl1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.DocWebControl1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.DocWebControl1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//�����Ρ�
			//	this.DocAuditWebControl1.lblAduitName1.Text = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
		//		this.DocAuditWebControl1.lblAuditName2.Text = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
	//			this.DocAuditWebControl1.lblAuditName3.Text = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
				this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][CancelData.Audit1_Field].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][CancelData.Audit2_Field].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][CancelData.Audit3_Field].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][CancelData.AuditSuggest1_Field].ToString();
				this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][CancelData.AuditSuggest2_Field].ToString();
				this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][CancelData.AuditSuggest3_Field].ToString();
				try
				{
					this.DocAuditWebControl1.txtAuditDate1.Text = Convert.ToDateTime(oDT.Rows[0][CancelData.AuditDate1_Field].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate2.Text = Convert.ToDateTime(oDT.Rows[0][CancelData.AuditDate2_Field].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate3.Text = Convert.ToDateTime(oDT.Rows[0][CancelData.AuditDate3_Field].ToString()).ToString("yyyy-MM-dd");
				}
				catch
				{}
				//��
				this.DocAuditWebControl1.Auditor1=oDT.Rows[0][CancelData.Assessor1_Field].ToString();
				this.DocAuditWebControl1.Auditor2=oDT.Rows[0][CancelData.Assessor2_Field].ToString();
				this.DocAuditWebControl1.Auditor3=oDT.Rows[0][CancelData.Assessor3_Field].ToString();
				//��ע��
				this.lblRemark.Text = oDT.Rows[0][CancelData.Remark_Field].ToString();
				//���벿�š�
				this.lblReqDept.Text = oDT.Rows[0][CancelData.AuthorDeptName_Field].ToString();
				//�����ˡ�
				this.lblProposer.Text = oDT.Rows[0][CancelData.AuthorName_Field].ToString();
				//�Ƶ����š�
				this.lblAuthorDept.Text = oDT.Rows[0][CancelData.AuthorDeptName_Field].ToString();
				//�Ƶ��ˡ�
				this.lblAuthorName.Text = oDT.Rows[0][CancelData.AuthorName_Field].ToString();
			}
		}

		#endregion

		#region �¼�
		protected void Page_Load(object sender, EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!string.IsNullOrEmpty(Request["EntryNo"]))
			{
				_EntryNo = Convert.ToInt32(Request["EntryNo"].ToString());
			}
			if(!this.IsPostBack)
			{
				this.BindData();
			}
			//this.DGModel_Items1.ShowPager = false;
			this.DGModel_Items1.AllowPaging = false;
			//this.DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.Cancel;
		}
        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[5].Visible = Master.DisplayCancelPrice;
                e.Item.Cells[7].Visible = Master.DisplayCancelPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[5].Visible = Master.DisplayCancelPrice;
                e.Item.Cells[7].Visible = Master.DisplayCancelPrice;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[5].Visible = Master.DisplayCancelPrice;
                e.Item.Cells[7].Visible = Master.DisplayCancelPrice;
            }
        }

       
		#endregion

	
	}
}
