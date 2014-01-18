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
	using MZHMM.WebMM.Modules;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHCommon.Input;
	/// <summary>
	/// SCRDetail ��ժҪ˵����
	/// </summary>
	public partial class SCRDetail : System.Web.UI.Page
	{
		#region ��Ա����
		protected DocWebControl DocWebControl1 = new DocWebControl();//����̨ͷ��
		protected Shmzh.Web.UI.Controls.MzhDataGrid DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();//�����
		protected DocAuditWebControl DocAuditWebControl1 = new DocAuditWebControl();//�����������֡�
//��ע��
//���벿�š�
//�����ˡ�
//��;��
		private int _EntryNo;//������ˮ�ţ���URL���ݽ�����
		#endregion

		#region ˽�з���
		private void BindData()
		{
			WSCRData oSCRData;
			ItemSystem oItemSystem = new ItemSystem();
			DataTable oDT;
			this.DocWebControl1.DocCode = DocType.SCR;
			this.DocWebControl1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.SCR;
			//��������䵽���ݼ�,DataGrid������Դ��
			oSCRData = oItemSystem.GetWSCRByEntryNo(_EntryNo);
			oDT = oSCRData.Tables[WSCRData.WSCR_TABLE];
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
				this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditDate1.Text = InputCheck.ConvertDateField(oDT.Rows[0][InItemData.AUDITDATE1_FIELD],"yyyy-MM-dd");
				this.DocAuditWebControl1.txtAuditDate2.Text = InputCheck.ConvertDateField(oDT.Rows[0][InItemData.AUDITDATE2_FIELD],"yyyy-MM-dd");
				this.DocAuditWebControl1.txtAuditDate3.Text = InputCheck.ConvertDateField(oDT.Rows[0][InItemData.AUDITDATE3_FIELD],"yyyy-MM-dd");

				//��
				this.DocAuditWebControl1.Auditor1=oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
				this.DocAuditWebControl1.Auditor2=oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
				this.DocAuditWebControl1.Auditor3=oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
				//��;��
				this.lblReason.Text = oDT.Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() +"   "+oDT.Rows[0][WSCRData.REQREASON_FIELD].ToString();
				//��ע��
				this.lblRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//���벿�š�
				this.lblReqDept.Text = oDT.Rows[0][WSCRData.REQDEPTNAME_FIELD].ToString();
				//�����ˡ�
				this.lblProposer.Text = oDT.Rows[0][WSCRData.PROPOSER_FIELD].ToString();
				//�Ƶ����š�
				this.lblAuthorDept.Text = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();
				//�Ƶ��ˡ�
				this.lblAuthorName.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
			}
		}

		#endregion

		#region �¼�
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (Request["EntryNo"] != null && Request["EntryNo"] != "")
			{
				_EntryNo = Convert.ToInt32(Request["EntryNo"].ToString());
			}
			if(!this.IsPostBack)
			{
				this.BindData();
			}
			//this.DGModel_Items1.ShowPager = false;
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.SCR;
		}


        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[7].Visible = Master.DisplaySCRPrice;
                e.Item.Cells[8].Visible = Master.DisplaySCRPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[7].Visible = Master.DisplaySCRPrice;
                e.Item.Cells[8].Visible = Master.DisplaySCRPrice;
            }
        }

       
		#endregion
	}
}
