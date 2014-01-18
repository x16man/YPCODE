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
	//using MZHCommon.PageStyle;
	/// <summary>
	/// ROSDetail ��ժҪ˵����
	/// </summary>
	public partial class DRWDetail : System.Web.UI.Page
	{
		#region ��Ա����
		protected DocWebControl DocWebControl1 = new DocWebControl();//����̨ͷ��
		protected Shmzh.Web.UI.Controls.MzhDataGrid  DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();//�����
		protected DocAuditWebControl DocAuditWebControl1 = new DocAuditWebControl();//�����������֡�
//��ע��
//���벿�š�
//�����ˡ�
//��;��
		//private int _EntryNo;//������ˮ�ţ���URL���ݽ�����

        private decimal dsumMoney = 0;
		#endregion

		#region ˽�з���
		private void BindData()
		{
			WDRWData oWDRWData;
		    ItemSystem oItemSystem = new ItemSystem();
			
			DataTable oDT;
			this.DocWebControl1.DocCode = DocType.DRW;
			this.DocWebControl1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode = DocType.DRW;
			//��������䵽���ݼ�,DataGrid������Դ��
			oWDRWData = oItemSystem.GetWDRWByEntryNo(Master.EntryNo);
			oDT = oWDRWData.Tables[WDRWData.WDRW_TABLE];
			this.DGModel_Items1.DataSource = oDT;
			this.DGModel_Items1.DataBind();
			if (oDT.Rows.Count > 0)
			{
				//̨ͷ���֡�
				this.DocWebControl1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.DocWebControl1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.DocWebControl1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//�����Ρ�
                this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.lblAuditName2.Text = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.lblAuditName3.Text = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y" ? 0 : 1;
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
				this.lblReason.Text = oDT.Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() +"   "+oDT.Rows[0][WDRWData.REQREASON_FIELD].ToString();
				//��ע��
				this.lblRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				///���벿�š�
				this.lblReqDept.Text = oDT.Rows[0][PMRPData.REQDEPTNAME_FIELD].ToString();
				//�����ˡ�
				this.lblProposer.Text = oDT.Rows[0][PMRPData.PROPOSER_FIELD].ToString();
				//�Ƶ����š�
				this.lblAuthorDept.Text = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();
				//�Ƶ��ˡ�
				this.lblAuthorName.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
				//�ֿ�����
				this.lbStoName.Text = oDT.Rows[0][WDRWData.STONAME_FIELD].ToString();
				//�ֿ����Ա
				this.lbStoManager.Text = oDT.Rows[0][WDRWData.STOMANAGER_FIELD].ToString();
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
			
			if(!this.IsPostBack)
			{
				this.BindData();
			}
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAW;
			//this.DGModel_Items1.DgStyleScheme = CommonStyle.StyleScheme.Printer;
			//this.DGModel_Items1.ShowPager = false;
			//this.DGModel_Items1.AllowPaging = false;
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
		}


        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                dsumMoney = 0;
                e.Item.Cells[9].Visible = Master.DisplayDRWPrice;
                e.Item.Cells[8].Visible = Master.DisplayDRWPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {

                    e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + Master.EntryNo.ToString() + "&DocCode=4&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");

                    e.Item.Cells[9].Visible = Master.DisplayDRWPrice;
                    e.Item.Cells[8].Visible = Master.DisplayDRWPrice;
                    dsumMoney += decimal.Parse(e.Item.Cells[9].Text);

                    decimal StockNum, PlanNum, ItemNum;//���������������ʵ������

                    try
                    { StockNum = Convert.ToDecimal(e.Item.Cells[5].Text); }
                    catch
                    { StockNum = 0; }
                    try
                    { PlanNum = Convert.ToDecimal(e.Item.Cells[6].Text); }
                    catch
                    { PlanNum = 0; }
                    try
                    { ItemNum = Convert.ToDecimal(e.Item.Cells[7].Text); }
                    catch
                    { ItemNum = 0; }

                    if ((StockNum < PlanNum && (Master.Op == "New" || Master.Op == "Edit")) ||
                         (StockNum < ItemNum && Master.Op == "Out")
                       )
                    {
                        e.Item.BackColor = Color.Red;
                    }
                }
                catch
                {
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[9].Visible = Master.DisplayDRWPrice;
                e.Item.Cells[9].Text = dsumMoney.ToString("n3");
                e.Item.Cells[8].Visible = Master.DisplayDRWPrice;
            }
        }

      
		#endregion
	}
}
