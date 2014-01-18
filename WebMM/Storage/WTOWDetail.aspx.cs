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


using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using WebMM;

namespace MZHMM.WebMM.Storage
{
	using Modules;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	/// <summary>
	/// ROSDetail ��ժҪ˵����
	/// </summary>
	public partial class WTOWDetail : BasePage
	{
		#region ��Ա����
		protected DocWebControl DocWebControl1 = new DocWebControl();//����̨ͷ��
		protected Shmzh.Web.UI.Controls.MzhDataGrid DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();//�����
		protected DocAuditWebControl DocAuditWebControl1 = new DocAuditWebControl();//�����������֡�

        WTOWData oWTOWData;
        ItemSystem oItemSystem = new ItemSystem();
	    private DataTable oDT;

		private int _EntryNo;//������ˮ�ţ���URL���ݽ�����

        private decimal dsumMoney = 0;
		#endregion

        #region ˽�з���
        private void BindData()
		{
		    oWTOWData = new WTOWData();
		    oDT = new DataTable();
			this.DocWebControl1.DocCode = DocType.WTOW;
			this.DocWebControl1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.WTOW;
			//��������䵽���ݼ�,DataGrid������Դ��
			oWTOWData = oItemSystem.GetWTOWByEntryNo(_EntryNo);
			oDT = oWTOWData.Tables[WTOWData.WTOW_TABLE];
			this.DGModel_Items1.DataSource = oDT;
			this.DGModel_Items1.DataBind();
			if (oDT.Rows.Count > 0)												
			{
				//̨ͷ���֡�
				this.DocWebControl1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.DocWebControl1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.DocWebControl1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//�����Ρ�
//				this.DocAuditWebControl1.lblAduitName1.Text = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
//				this.DocAuditWebControl1.lblAuditName2.Text = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
//				this.DocAuditWebControl1.lblAuditName3.Text = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
				this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y"? 0:1;
				this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y"? 0:1;
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
				//��
				this.DocAuditWebControl1.Auditor1=oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
				this.DocAuditWebControl1.Auditor2=oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
				this.DocAuditWebControl1.Auditor3=oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
				//��;��
				this.lblReason.Text = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() +"   "+oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
				//�ӹ����ݡ�
				this.txtProcessContent.Text = oDT.Rows[0][WTOWData.PROCESSCONTENT_FIELD].ToString();
				//ͼֽ��
				this.lblDrawingCount.Text = oDT.Rows[0][WTOWData.DRAWINGCOUNT_FIELD].ToString();
				//���š�
				this.lblProspectusCount.Text = oDT.Rows[0][WTOWData.PROSPECTUSCOUNT_FIELD].ToString();
				//��ע��
				this.lblRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				///���벿�š�
				this.lblReqDept.Text = oDT.Rows[0][WTOWData.REQDEPTNAME_FIELD].ToString();
				//�����ˡ�
                this.lblProposer.Text = oDT.Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString();
				//�Ƶ����š�
				this.lblAuthorDept.Text = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();
				//�Ƶ��ˡ�
				this.lblAuthorName.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
//				//�ֿ�����
//				this.lbStoName.Text = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
				//�ֿ����Ա
				this.lbStoManager.Text = oDT.Rows[0][WTOWData.STOMANAGER_FIELD].ToString();
			}
		}
		#endregion

		#region �¼�
		/// <summary>
		/// ҳ���Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (Request["EntryNo"] != null && Request["EntryNo"] != "")
			{
				_EntryNo = Convert.ToInt32(Request["EntryNo"]);
			}
         
			if(!this.IsPostBack)
			{
				this.BindData();
			}
		}

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Header)
            {
                dsumMoney = 0;
                e.Item.Cells[8].Visible = CurrentUser.HasRight(Common.SysRight.WTOWCstPrice);

                e.Item.Cells[9].Visible = CurrentUser.HasRight(Common.SysRight.WTOWCstPrice);
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    e.Item.Cells[8].Visible = CurrentUser.HasRight(Common.SysRight.WTOWCstPrice);
                    e.Item.Cells[9].Visible = CurrentUser.HasRight(Common.SysRight.WTOWCstPrice);

                    dsumMoney += decimal.Parse(e.Item.Cells[9].Text);

                }
                catch { }


                //decimal StockNum, PlanNum, ItemNum;//���������������ʵ������

                //try
                //{ StockNum = Convert.ToDecimal(e.Item.Cells[5].Text); }
                //catch
                //{ StockNum = 0; }
                //try
                //{ PlanNum = Convert.ToDecimal(e.Item.Cells[6].Text); }
                //catch
                //{ PlanNum = 0; }
                //try
                //{ ItemNum = Convert.ToDecimal(e.Item.Cells[7].Text); }
                //catch
                //{ ItemNum = 0; }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[9].Text = dsumMoney.ToString("n3");
                e.Item.Cells[8].Visible = CurrentUser.HasRight(Common.SysRight.WTOWCstPrice);
                e.Item.Cells[9].Visible = CurrentUser.HasRight(Common.SysRight.WTOWCstPrice);
            }
        }

       
		#endregion
	}
}
