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
	/// WTOWInput ��ժҪ˵����
	/// </summary>
	public partial class WTOWInput : System.Web.UI.Page
	{
		#region ��Ա����
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

	    private decimal StockNum;//�����
	    private decimal ItemNum;//��������
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

		#region ˽�з���
		/// <summary>
		/// ��������״̬�£����ݰ󶨡�
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
//						//̨ͷ���֡�
//						this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
//						this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
//						this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
//						//�����Ρ�
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
//						//���벿�š�
//						this.ddlDept.SelectedValue = oDT.Rows[0][WTOWData.REQDEPT_FIELD].ToString();
//						this.ddlDept.SelectedText = oDT.Rows[0][WTOWData.REQDEPTNAME_FIELD].ToString();
//
//						//�����ˡ�
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
//						//���ϲֿ⡣
//						this.ddlStorage.SelectedText = oDT.Rows[0][WTOWData.STONAME_FIELD].ToString();
//						this.ddlStorage.SelectedValue = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
//						//��;��
//						//this.ddlPurpose.SelectedText = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
//						//this.ddlPurpose.SelectedValue = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
//						this.item1.ReqReasonCode = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
//						this.item1.ReqReason = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
//						this.item1.StoCode = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
//						//��ע��
//						this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
//						this.txtParentEntryNo.Text = oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString();
//					}
//					else
//					{
//						this.Response.Write("<Script>alert('���ϵ������ֵ�ǰ�������Ǹõ����ѷ��ϣ�');</Script>");
//						this.Response.Redirect("DRWBrowser.aspx",true);
//					}
//				}
//			}

		}
		/// <summary>
		/// �༭����״̬�£����ݰ󶨡�
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

			this.ddlProposer.Module_Tag = (int)SDDLTYPE.Drawer;		//�����ˡ�
			this.ddlProposer.IsClear = true;
			//this.ddlPurpose.Width = "90%";

			//��������䵽���ݼ�,DataGrid������Դ��
			if (this._OP == OP.O)
			{
				oWTOWData = oItemSystem.GetWTOWByEntryNoOutMode(Master.EntryNo);
			}
            else if (this._OP == OP.Red)
            {
                oWTOWData = oItemSystem.GetWTOWOldByEntryNo(Master.EntryNo);
                if (oWTOWData.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�˵����Ѿ��������ֲ����������ٴν��к��ֲ�����');document.location='WTOWBrowser.aspx?DocCode=16';", true);
                    return;
                }

                oWTOWData = oItemSystem.GetWTOWRedByEntryNo(Master.EntryNo);

                strParentEntryNo = oWTOWData.Tables[0].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                if (strParentEntryNo != "")
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�˵����Ǻ��ֲ������ݲ������ٴν��к��ֲ�����');document.location='WTOWBrowser.aspx?DocCode=16';", true);
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

				//̨ͷ���֡�
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());

                if (this._OP != OP.Red)
                {
                    //�����Ρ�
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

                

				//���벿�š�
				this.ddlDept.SelectedValue = oDT.Rows[0][WTOWData.REQDEPT_FIELD].ToString();
				this.ddlDept.SelectedText = oDT.Rows[0][WTOWData.REQDEPTNAME_FIELD].ToString();

				//�����ˡ�
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
				//���ϲֿ⡣
//                this.ddlStorage.SelectedText = oDT.Rows[0][WTOWData.STONAME_FIELD].ToString();
//				this.ddlStorage.SelectedValue = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
				//��;��
				this.ddlPurpose.SelectedText = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
				this.ddlPurpose.SelectedValue = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
				//�ӹ����ݡ�
				this.txtProcessContent.Text = oDT.Rows[0][WTOWData.PROCESSCONTENT_FIELD].ToString();
				//���ڡ�
                try
                {
                    this.txtReqDate.Text = DateTime.Parse(oDT.Rows[0][WTOWData.TERM_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }
                    //ͼֽ��
				this.txtDrawingCount.Text = oDT.Rows[0][WTOWData.DRAWINGCOUNT_FIELD].ToString();
				//���š�
				this.txtProspectusCount.Text = oDT.Rows[0][WTOWData.PROSPECTUSCOUNT_FIELD].ToString();
//				this.item1.ReqReasonCode = oDT.Rows[0][WTOWData.REQREASONCODE_FIELD].ToString();
//				this.item1.ReqReason = oDT.Rows[0][WTOWData.REQREASON_FIELD].ToString();
//				this.item1.StoCode = oDT.Rows[0][WTOWData.STOCODE_FIELD].ToString();
				//��ע��
				this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//����ģʽ�³�ʼ�������˺����ڡ�
				if (this._OP == OP.O)
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
		/// ������䡣
		/// </summary>
		/// <param name="oWTOWData">WTOWData:	���ϵ�ʵ�塣</param>
		private void FillData(WTOWData oWTOWData)
		{
			dr = oWTOWData.Tables[WTOWData.WTOW_TABLE].NewRow();
			//����̨ͷ�������ݡ�
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;						//������ˮ�š�
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;					//���ݱ�š�
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;						//�������͡�
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;						//�����������ơ�
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;							//�����ĵ���š�
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;						//�������ڡ�
            dr[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
            dr[WTOWData.STOMANAGERCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;	//�ֹܱ�š�
            dr[WTOWData.STOMANAGER_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;		//�ֹ����ơ�
			//dr[WTOWData.STOCODE_FIELD] = ddlStorage.SelectedValue;				//���ϲֿ��š�
			
			dr[InItemData.REMARK_FIELD] = this.item1.Remark;					//��ע��
			dr[WTOWData.REQDEPT_FIELD] = this.ddlDept.SelectedValue;			//���첿�š�
			dr[WTOWData.REQDEPTNAME_FIELD] = this.ddlDept.SelectedText;			//���첿�����ơ�
						
			dr[WTOWData.PROPOSERCODE_FIELD] = this.ddlProposer.SelectedValue;   //�����˱�š�
			dr[WTOWData.PROPOSERNAME_FIELD] = this.ddlProposer.SelectedText;    //���������ơ�
			dr[WTOWData.PROCESSCONTENT_FIELD] = this.txtProcessContent.Text;    //�ӹ����ݡ�
			dr[WTOWData.REQREASONCODE_FIELD] = this.ddlPurpose.SelectedValue;	//��;��š�
			dr[WTOWData.REQREASON_FIELD] = this.ddlPurpose.SelectedText;		//��;���ơ�
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
//			dr[WTOWData.REQREASON_FIELD] = this.item1.ReqReason;				//��;���ơ�
//			dr[WTOWData.REQREASONCODE_FIELD] = this.item1.ReqReasonCode;		//��;��š�
			try
			{
                dr[WTOWData.PARENTENTRYNO_FIELD] = this.txtParentEntryNo.Value;	//���ָ����ݺš�
			}
			catch
			{}
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������
			
			MyCol2List = new Col2List(this.item1.thisTable);
			
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();									//˳��š�
//			dr[WTOWData.SOURCEENTRY_FIELD] = MyCol2List.GetList(WTOWData.SOURCEENTRY_FIELD);		//Դ������ˮ�š�
//			dr[WTOWData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(WTOWData.SOURCEDOCCODE_FIELD);	//Դ�������͡�
//			dr[WTOWData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(WTOWData.SOURCESERIALNO_FIELD);	//Դ����˳��š�
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);			//���ϱ�š�
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);			//�������ơ�
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);	//����ͺš�
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);			//��λ��
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);	//��λ���ơ�
			dr[WTOWData.PLANNUM_FIELD] = MyCol2List.GetList(WTOWData.PLANNUM_FIELD);				//����������
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);			//ʵ��������
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);		//���ۡ�
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);		//��
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);			//�ϼƽ�
			
			oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows.Add(dr);
		}
		/// <summary>
		/// ���õ���״̬��
		/// </summary>
		/// <param name="oWTOWData">WTOWData:	���ϵ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryState(WTOWData oWTOWData, string OpMode)
		{
			if ( oWTOWData.Count > 0)
			{
				DataRow oDataRow = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oWTOWData.Tables[WTOWData.WTOW_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// ���õ��ݲ����ˡ�
		/// </summary>
		/// <param name="oWTOWData">WTOWData:	���ϵ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryOperator(WTOWData oWTOWData, string OpMode)
		{
			if ( oWTOWData.Count > 0)
			{
				DataRow oDataRow = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://�½���
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Red:  //���֡�
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
					case OP.Edit://�༭��
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
					case OP.O:
                        oDataRow[WTOWData.STOMANAGERCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[WTOWData.STOMANAGER_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
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
				//����ͬ�����ۼƵķ�������
				for (j = i+1; j< dt.Rows.Count; j++)
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

		#endregion
		
		#region �¼�
		/// <summary>
		/// ҳ���Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.DRW;
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
                    this.Response.Write("<script>alert('���ݵĵ�ǰ״̬��������е�ǰ������');window.history.go(-1);</script>");

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
		/// �ܾ�������
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

            if (this.txtReqDate.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"Ҫ��������ڲ���Ϊ�գ�\");", true);
                return;
            }

            if (this.txtProcessContent.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('û�мӹ�����!');", true);
                return;
            }
			//��������ʵ��.
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
					#region ����
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
							//this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
							//this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
							//this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
						//�ж��Ƿ��Ǻ��֡�
						
						if (this.CheckOutCondition(this.item1.thisTable))		   //�ж��Ƿ�������������
						{
							ret = oItemSystem.StockOutWTOW(oWTOWData);
						}
						else
						{
							//this.Response.Write("<script>alert(\'���������ܴ��ڵ�ǰ���������\')</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���������ܴ��ڵ�ǰ�������!');", true);
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
		/// ȡ����ť�¼���
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

            if (this.txtReqDate.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"Ҫ��������ڲ���Ϊ�գ�\");", true);
                return;
            }

            if (this.txtProcessContent.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û�мӹ�����!');", true);
                return;
            }
			//��������ʵ��.
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
  		/// �ֿ������б�ı��¼���
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
//		/// �ֿ������б�ı��¼���
//		/// </summary>
//		/// <returns></returns>
//		protected override bool OnBubbleEvent(object Sender,EventArgs e)
//		{
//			try
//			{
//				//�ֿ������б��¼���
//				if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == "ddlStorage_thisDDL" )
//				{
//					this.item1.StoCode = this.ddlStorage.SelectedValue;
//					if (this.ddlStorage.SelectedValue != "-1")					
//					{
//						if (this.item1.thisTable.Rows.Count > 0)//�����̬�����м�¼����Ҫˢ�µ�ǰ����ֶε�ֵ��
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
