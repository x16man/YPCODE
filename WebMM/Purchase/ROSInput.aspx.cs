using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Web.UI.Controls;
using SysRight = MZHMM.WebMM.Common.SysRight;

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
	/// <summary>
	/// ROSInput ��ժҪ˵����
	/// </summary>
	public partial class ROSInput : Page
	{
		#region ��Ա����
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private string _OP;
        RequestOfStockData oROSData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

	    private DataRow oDataRow;

	    private Col2List MyCol2List;

	    private bool ret;

	    private int i;

	    private DataRow dr;

	    private RequestOfStockData oRos;
        DataTable oDT;

	    private string[] ItemCodes;
	
		#endregion
		
		#region ˽�з���
		/// <summary>
		/// ��������״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataNew()
		{
            
            this.doc1.DocCode = DocType.ROS;
            this.doc1.DataBindNew();
            this.DocAuditWebControl1.DocCode = DocType.ROS;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
            this.ddlDept.DocType = DocType.ROS;
            this.ddlDept.SetItemSelected(Master.CurrentUser.thisUserInfo.DeptCode);
            this.ddlDept.SelectedValue = Master.CurrentUser.thisUserInfo.DeptCode;
            this.ddlPurpose.SelectedValue = "-1";
            this.ddlPurpose.Flag = 0;
            this.txtProposer.Text = Master.CurrentUser.thisUserInfo.EmpName;
		}
		/// <summary>
		/// �༭����״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataUpdate()
		{
           Logger.Debug("BindDataUpdate");
            this.doc1.DocCode = 1;
            this.doc1.DataBindUpdate();
            this.DocAuditWebControl1.DocCode = 1;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
            this.ddlDept.DocType = DocType.ROS;
            this.ddlPurpose.Flag = 0;
            //��������䵽���ݼ�,DataGrid������Դ��
            oROSData = oPurchaseSystem.GetRequestOfStockByEntryNo(Master.EntryNo);
            if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows.Count == 0) return;
            this.CheckOpPrecondition(Master.PurposeOp, oROSData);
            oDT = oROSData.Tables[RequestOfStockData.PROS_TABLE];
            this.item1.thisTable = oDT;

            if (oDT.Rows.Count > 0)
            {
                Logger.Debug(oDT.Rows.Count);
                //̨ͷ���֡�
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //�����Ρ�
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                this.DocAuditWebControl1.Auditor4 = oDT.Rows[0][InItemData.ASSESSOR4_FIELD].ToString();
                Logger.Debug(this.DocAuditWebControl1.Auditor4);
                if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != DBNull.Value)
                {
                    this.DocAuditWebControl1.Audit1 = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString();
                }
                if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != DBNull.Value)
                {
                    this.DocAuditWebControl1.Audit2 = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString();
                }
                if (oDT.Rows[0][InItemData.AUDIT3_FIELD] != DBNull.Value)
                {
                    this.DocAuditWebControl1.Audit3 = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString();
                }
                if (oDT.Rows[0][InItemData.AUDIT4_FIELD] != DBNull.Value)
                {
                    this.DocAuditWebControl1.Audit4 = oDT.Rows[0][InItemData.AUDIT4_FIELD].ToString();
                    Logger.Debug(this.DocAuditWebControl1.Audit4);
                }
                this.DocAuditWebControl1.AuditSuggest1 = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
                this.DocAuditWebControl1.AuditSuggest2 = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
                this.DocAuditWebControl1.AuditSuggest3 = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
                this.DocAuditWebControl1.AuditSuggest4 = oDT.Rows[0][InItemData.AUDITSUGGEST4_FIELD].ToString();

                this.DocAuditWebControl1.AuditDate1 = oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString();
                this.DocAuditWebControl1.AuditDate2 = oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString();
                this.DocAuditWebControl1.AuditDate3 = oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString();
                this.DocAuditWebControl1.AuditDate4 = oDT.Rows[0][InItemData.AUDITDATE4_FIELD].ToString();

                if (Master.PurposeOp == "FirstAudit" || Master.PurposeOp == "SecondAudit" || Master.PurposeOp == "ThirdAudit" || Master.PurposeOp =="WZAudit")
                {
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                }
                //��;��
                this.ddlPurpose.SelectedText = oDT.Rows[0][RequestOfStockData.REQREASON_FIELD].ToString();
                this.ddlPurpose.SelectedValue = oDT.Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString();
                //��ע��
                this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //���벿�š�
                this.ddlDept.SelectedText = oDT.Rows[0][RequestOfStockData.REQDEPTNAME_FIELD].ToString();
                this.ddlDept.SelectedValue = oDT.Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString();
                //�����ˡ�
                this.txtProposer.Text = oDT.Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString();
            }
		}
		/// <summary>
		/// �趨����״̬��
		/// </summary>
		/// <param name="oRosData">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryState(RequestOfStockData oRosData, string OpMode)
		{
            if (oRosData.Count > 0)
            {
                oDataRow = oRosData.Tables[RequestOfStockData.PROS_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oRosData.Tables[0]).GetEntryState(OpMode);
            }
		}
		/// <summary>
		/// �趨�����ˡ�
		/// </summary>
		/// <param name="oRosData">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetOperator(RequestOfStockData oRosData, string OpMode)
		{
            if (oRosData.Count > 0)
            {
                oDataRow = oRosData.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

                switch (OpMode)
                {
                    case OP.New://�½���
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
                    case OP.WZAudit://����������
                        oDataRow[InItemData.ASSESSOR4_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                }
            }
		}
		/// <summary>
		/// ������ݼ���
		/// </summary>
		/// <param name="oRos">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		private void FillData(RequestOfStockData oRos)
		{
            dr = oRos.Tables[RequestOfStockData.PROS_TABLE].NewRow();
            //����̨ͷ�������ݡ�
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�
            dr[RequestOfStockData.REQDEPT_FIELD] = ddlDept.SelectedValue;			//���벿�š�
            dr[RequestOfStockData.REQDEPTNAME_FIELD] = ddlDept.SelectedText;		//���벿�����ơ�
            dr[InItemData.REMARK_FIELD] = this.item1.Remark;				//��ע��
            dr[RequestOfStockData.PROPOSER_FIELD] = txtProposer.Text;			//�����ˡ�
            dr[RequestOfStockData.REQREASON_FIELD] = ddlPurpose.SelectedText;		//��;���ơ�
            dr[RequestOfStockData.REQREASONCODE_FIELD] = ddlPurpose.SelectedValue;	//��;��š�
            
            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.Audit1;
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.Audit2;
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.Audit3;
            dr[InItemData.AUDIT4_FIELD] = this.DocAuditWebControl1.Audit4;

            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.AuditSuggest1;	//һ�����������
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.AuditSuggest2;	//�������������
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.AuditSuggest3;	//�������������
            dr[InItemData.AUDITSUGGEST4_FIELD] = this.DocAuditWebControl1.AuditSuggest4;	//�������������
            
            MyCol2List = new Col2List(this.item1.thisTable);
		    dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//�빺���ϼƽ�

            dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();//˳��š�
		    dr[InItemData.NEWCODE_FIELD] = MyCol2List.GetList(InItemData.NEWCODE_FIELD);
            dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);//���ϱ�š�
            dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);//�������ơ�
            dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);//����ͺš�
            dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);//������
            dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);//��λ��
            dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);//���ۡ�
            dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);//��
            dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);//��λ���ơ�
            dr[RequestOfStockData.REQDATE_FIELD] = MyCol2List.GetList(RequestOfStockData.REQDATE_FIELD);//Ҫ�����ڡ�
            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows.Add(dr);
		}
		/// <summary>
		/// ��������ǰ��������
		/// </summary>
		/// <param name="OpMode">string: ����ģʽ��</param>
		/// <param name="oROSData">RequestOfStockData:	����ʵ�塣</param>
		/// <returns>bool:	ǰ�����������򷵻�True���������򷵻�False��</returns>
		private void CheckOpPrecondition(string OpMode,RequestOfStockData oROSData)
		{
            switch (OpMode)
            {
                case OP.Edit://�༭��
                    if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.WZNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + RequestOfStockData.XUpdate, true); }
                    break;
                case OP.Submit://�ύ��
                    if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass||
                        oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.WZNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + RequestOfStockData.XPresent, true); }
                    break;
                case OP.FirstAudit://һ��������
                    if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + RequestOfStockData.XFirstAudit, true); }
                    break;
                case OP.WZAudit://������� 
                    if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    {
                        return;
                    }
                    else
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + RequestOfStockData.XWZAudit, true);
                    }
                    break;
                case OP.SecondAudit://����������
                    if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.WZPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + RequestOfStockData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://����������
                    if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + RequestOfStockData.XThirdAudit, true); }
                    break;
                
            }
		}
		
		#endregion
		
		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
            Logger.Debug("Page Load1");
            Session[MySession.Help] = HelpCode.ROS;
            // �ڴ˴������û������Գ�ʼ��ҳ��
            this._OP = Master.PurposeOp;
            item1.IsDisplayPrice = Master.DisplayRosPrice;


            this.ddlPurpose.Width = new Unit("90%");
            this.item1.DocCode = 1;
            Logger.Debug(this.IsPostBack);
            if (!this.IsPostBack)
            {
                Logger.Debug(Master.PurposeOp);
                switch (Master.PurposeOp)
                {
                    case OP.New://�½���
                        //�ж�Ȩ�ޡ�
                        if (!Master.HasBrowseRight(SysRight.ROSMaintain))
                        {
                            return;
                        }
                        this.BindDataNew();
                        this.btnSave.Text = OPName.New;
                        break;
                    case OP.Edit://�޸ġ�
                        if (!Master.HasBrowseRight(SysRight.ROSMaintain))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Edit;
                        
                        break;
                    case OP.Submit://�ύ��
                        if (!Master.HasBrowseRight(SysRight.ROSPresent))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Edit;
                        this.btnPresent.Visible = true;
                        this.btnSave.Visible = false;
                        break;
                    case OP.FirstAudit://һ��������
                        if (!Master.HasBrowseRight(SysRight.ROSFirstAudit))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.FirstAudit;
                        this.ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        
                        break;
                    case OP.SecondAudit://����������
                        if (!Master.HasBrowseRight(SysRight.ROSSecondAudit))
                        {
                            return;
                        }
                        
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.SecondAudit;
                        this.ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        
                        break;
                    case OP.ThirdAudit://����������
                        if (!Master.HasBrowseRight(SysRight.ROSThirdAudit))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.ThirdAudit;
                        this.ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        item1.IsDisplayPrice =  Master.DisplayRosPrice;
                       
                        break;
                    case OP.WZAudit://�������
                        if(!Master.HasBrowseRight(SysRight.ROSWZAudit))
                        {
                            return;
                        }
                        this.item1.MyDataGrid.SelectType = MzhDataGrid.SelectMode.MultiSelect;
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.WZAudit;
                        this.ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        item1.IsDisplayPrice =  Master.DisplayRosPrice;
                        this.btn2MRP.Visible = true;
                        break;
                }
            }
		}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Logger.Debug("btnSave");
            //û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            //��������ʵ��.
            oRos = new RequestOfStockData();
            this.FillData(oRos);
            //�ж��Ƿ�����ŵ����׺�Ʒ��
            int DZYH_Count = 0, NoDZYH_Count = 0;

            if (oRos.Tables[0].Rows.Count > 0)
            {
               
                ItemCodes = oRos.Tables[0].Rows[0]["ItemCode"].ToString().Split(",".ToCharArray());
                for (i = 0; i < ItemCodes.Length; i++)
                {
                    if (int.Parse(ItemCodes[i].Substring(2, 2)) == 32 ||
                        int.Parse(ItemCodes[i].Substring(2, 2)) == 33 ||
                        int.Parse(ItemCodes[i].Substring(2, 2)) == 34 ||
                        int.Parse(ItemCodes[i].Substring(2, 2)) == 35)
                    {
                        DZYH_Count += 1;
                    }
                    else
                    {
                        NoDZYH_Count += 1;
                    }
                }
            }
            if (DZYH_Count > 0 && NoDZYH_Count > 0)//�����׺ĺͷǵ�ֵ�׺ļ��ӡ�
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���ѣ���ֵ�׺�Ʒ���뵥��һ�ŵ���!');", true);
                return;
            }

            if (this._OP == OP.Submit)
            {
                this._OP = OP.Edit;
            }
            this.SetEntryState(oRos, Master.PurposeOp);//�趨����״̬��
            this.SetOperator(oRos, Master.PurposeOp);//�趨�����ˡ�

            if (!Master.IsContaintContent(oRos.Tables[0].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oRos.Tables[0].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���������ϲ���������!');", true);
                return;
            }

            ret = true;
            switch (this._OP)
            {
                #region New
                case OP.New:
                    if (Master.HasRight(SysRight.ROSMaintain))
                    {
                        ret = oPurchaseSystem.AddRequestOfStock(oRos);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                #endregion
                #region Edit
                case OP.Edit:
                    if (Master.HasRight(SysRight.ROSMaintain))
                    {
                        ret = oPurchaseSystem.UpdateRequestOfStock(oRos);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                #endregion
                #region Submit
                case OP.Submit://�ύ��
                    if (Master.HasRight(SysRight.ROSPresent))
                    {
                        ret = oPurchaseSystem.PresentRequestOfStock(doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                #endregion
                #region FirstAudit
                case OP.FirstAudit:
                    if (Master.HasRight(SysRight.ROSFirstAudit))
                    {
                        if (oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        ret = oPurchaseSystem.FirstAuditRequestOfStock(oRos);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "NoRight", "alert('û������Ȩ��!');", true);
                        ret = false;
                    }
                    Logger.Info("FirstAudit");
                    break;
                #endregion
                #region SecondAudit
                case OP.SecondAudit:
                    if (Master.HasRight(SysRight.ROSSecondAudit))
                    {
                        if (oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "Y" &&
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        ret = oPurchaseSystem.SecondAuditRequestOfStock(oRos);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                #endregion
                #region ThirdAudit
                case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.ROSThirdAudit))
                    {
                        if (oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "Y" &&
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        ret = oPurchaseSystem.ThirdAuditRequestOfStock(oRos);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                #endregion
                #region WZAudit
                case OP.WZAudit:
                    if(Master.HasRight(SysRight.ROSWZAudit))
                    {
                        if(oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT4_FIELD].ToString() != "Y" &&
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT4_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        
                        ret = oPurchaseSystem.WZAuditRequestOfStock(Master.EntryNo,
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString(), 
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT4_FIELD].ToString(),
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ASSESSOR4_FIELD].ToString(),
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDITSUGGEST4_FIELD].ToString(),
                            string.Empty, Master.CurrentUser.LoginName);
                    }
                    else
                    {
                        ret =  false;
                    }
                    break;

                    #endregion
            }

            if (ret == false)
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
                    Response.Redirect("ROSBrowser.aspx?DocCode=1");
                }
            }
        }

        protected void btnPresent_Click(object sender, EventArgs e)
        {
            Logger.Info("btnPresent");
            //û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            //��������ʵ��.
            oRos = new RequestOfStockData();
            this.FillData(oRos);
            //�ж��Ƿ�����ŵ����׺�Ʒ��
            int DZYH_Count = 0, NoDZYH_Count = 0;

            if (oRos.Tables[0].Rows.Count > 0)
            {
                
                ItemCodes = oRos.Tables[0].Rows[0]["ItemCode"].ToString().Split(",".ToCharArray());
                for (i = 0; i < ItemCodes.Length; i++)
                {
                    if (int.Parse(ItemCodes[i].Substring(2, 2)) == 32 ||
                        int.Parse(ItemCodes[i].Substring(2, 2)) == 33 ||
                        int.Parse(ItemCodes[i].Substring(2, 2)) == 34 ||
                        int.Parse(ItemCodes[i].Substring(2, 2)) == 35)
                    {
                        DZYH_Count += 1;
                    }
                    else
                    {
                        NoDZYH_Count += 1;
                    }
                }
            }
            if (DZYH_Count > 0 && NoDZYH_Count > 0)//�����׺ĺͷǵ�ֵ�׺ļ��ӡ�
            {
                this.Response.Write("<script>alert('���ѣ���ֵ�׺�Ʒ���뵥��һ�ŵ��ݣ�');</script>");
                return;
            }


            if (!Master.IsContaintContent(oRos.Tables[0].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oRos.Tables[0].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���������ϲ���������!');", true);
                return;
            }

           
            ret = true;
            switch (Master.PurposeOp)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    this.SetEntryState(oRos, this._OP);//�趨����״̬��
                    this.SetOperator(oRos, this._OP);//�趨�����ˡ�
                    ret = oPurchaseSystem.AddAndPresentRequestOfStock(oRos);
                    break;
                case OP.Edit:
                    this._OP = OP.NewAndPresent;
                    this.SetEntryState(oRos, this._OP);//�趨����״̬��
                    this.SetOperator(oRos, this._OP);//�趨�����ˡ�
                    ret = oPurchaseSystem.UpdateAndPresentRequestOfStock(oRos);
                    break;
                case OP.Submit:
                    this._OP = OP.NewAndPresent;
                    this.SetEntryState(oRos, this._OP);
                    this.SetOperator(oRos, this._OP);
                    ret = oPurchaseSystem.UpdateAndPresentRequestOfStock(oRos);
                    break;
            }

            if (ret == false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
            }
            else
            {
                //Response.Write("Success!");
                //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
                if (Master.IsTODO)
                {
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {
                    Response.Redirect("ROSBrowser.aspx?DocCode=1");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Master.IsTODO)
            {
                this.Response.Write("<script>window.close();</script>");
            }
            else
            {
                Response.Redirect("ROSBrowser.aspx?DocCode=1");
            }
        }

	    protected void btn2MRP_Click(object sender, EventArgs e)
	    {
            if(this.item1.MyDataGrid.SelectedArray.Length == 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"NoMRP","alert('��ѡ����Ҫת���¶ȼƻ����󵥵ļ�¼');",true);
                return;
            }
            else
            {
                //��������ʵ��.
                oRos = new RequestOfStockData();
                this.FillData(oRos);
                this.SetEntryState(oRos, Master.PurposeOp);//�趨����״̬��
                this.SetOperator(oRos, Master.PurposeOp);//�趨�����ˡ�
                if (oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT4_FIELD].ToString() != "Y" &&
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT4_FIELD].ToString() != "N")
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                    return;
                }
                var ret = oPurchaseSystem.WZAuditRequestOfStock(Master.EntryNo,
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString(),
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDIT4_FIELD].ToString(),
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ASSESSOR4_FIELD].ToString(),
                            oRos.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUDITSUGGEST4_FIELD].ToString(),
                             this.item1.MyDataGrid.SelectedArray, Master.CurrentUser.LoginName);
                if (ret == false)
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
                        Response.Redirect("ROSBrowser.aspx?DocCode=1");
                    }
                }
            }
	    }
        #endregion
	}
}