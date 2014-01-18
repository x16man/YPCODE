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
	using MZHCommon.Database;
	//using MZHCommon.PageStyle;
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// 生产退料单的主维护界面。
	/// </summary>
	public partial class RTSInput : System.Web.UI.Page
	{
		#region 成员变量
#region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
		private string _OP;
	    private DataRow r;
	    private int DrawEntryNo;

	    private DataSet DS;

	    private Hashtable oHT;

	    private WRTSData oWRTSData;

	    private int i;


	    private ItemSystem oItemSystem = new ItemSystem();

	    private DataRow newRow;

	    private int iRow;

	    private bool ret;

	    private decimal ItemPrice;

	    private DataRow oRow;

        protected string RTSStyle;
		#endregion

		#region 属性
		/// <summary>
		/// DataGrid的数据源。
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.RTS_DT] != null)
					return (DataTable)Session[MySession.RTS_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.RTS_DT] = value;
			}
		}
		/// <summary>
		/// DataGrid中选中的行号。
		/// </summary>
		public int SelectedSerialNo
		{
			get 
			{
				if (ViewState["SelectedSerialNo"] != null)
					return int.Parse(ViewState["SelectedSerialNo"].ToString());
				else 
					return -1;
			}
			set 
			{
				ViewState["SelectedSerialNo"] = value;
			}

		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 获取通过URL传递过来的参数。
		/// </summary>
		private void GetUrlParament()
		{
			_OP = Request["Op"].ToString();
			
			
		}
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
            this.doc1.DocCode = DocType.RTS;
            this.doc1.DataBindNew();
            this.DocAuditWebControl1.DocCode = DocType.RTS;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.DEPT;
            this.ddlDept.Width = new Unit("100%");
            this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
            this.ddlCheckResult.Width = new Unit("100%");
            this.ddlPurpose.SelectedValue = "-1";
            
            ddlPurpose.Width = new Unit("100%");
            this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
            ddlStorage.Width = new Unit("100%");
            txtProposer.Text = Master.CurrentUser.thisUserInfo.EmpName;
            //初始化静态数据表。
            if (this.thisTable != null) this.thisTable = null;
            this.thisTable = new DataTable();
            DataColumnCollection columns = this.thisTable.Columns;
            columns.Add("SerialNo");
            columns.Add("SourceEntry");
            columns.Add("SourceDocCode");
            columns.Add("SourceSerialNo");
            columns.Add("ItemCode");
            columns.Add("ItemName");
            columns.Add("ItemSpecial");
            columns.Add("ItemUnit");
            columns.Add("ItemUnitName");
            columns.Add("ItemPrice");
            columns.Add("PlanNum").DataType = typeof(System.Decimal);
            columns.Add("ItemNum").DataType = typeof(System.Decimal);
            columns.Add("ItemMoney");
            columns.Add("ConCode");
            columns.Add("ConName");
            //for (int i = 0; i < 5; i++)
            //    this.thisTable.Rows.Add(this.thisTable.NewRow());
            this.MzhDataGrid1.DataSource = this.thisTable;
            this.MzhDataGrid1.DataBind();
            this.ddlCon.Visible = false;
		}
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{
            WRTSData oWRTSData;
            ItemSystem oItemSystem = new ItemSystem();

            DataTable oDT;
            this.doc1.DocCode = DocType.RTS;
            this.doc1.DataBindUpdate();
          
            this.DocAuditWebControl1.DocCode = DocType.RTS;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.DEPT;
            ddlDept.Width = new Unit("100%");
            this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
            ddlCheckResult.Width = new Unit("100%");
            this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
            ddlStorage.Width = new Unit("100%");
            //将单据填充到数据集,DataGrid绑定数据源。
            if (this._OP == OP.I)
            {
                oWRTSData = oItemSystem.GetWRTSByEntryNoInMode(Master.EntryNo);
                this.ddlCon.Visible = true;
            }
            else
            {
                oWRTSData = oItemSystem.GetWRTSByEntryNo(Master.EntryNo);
                this.ddlCon.Visible = false;
            }

           

            this.CheckOpPrecondition(this._OP, oWRTSData);

            oDT = oWRTSData.Tables[WRTSData.WRTS_TABLE];
            this.thisTable = oDT;

            if (oDT.Rows.Count > 0)
            {
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
                    this.DocAuditWebControl1.txtAuditDate1.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }

                //仓库。
                this.ddlStorage.SelectedText = oDT.Rows[0][WRTSData.STONAME_FIELD].ToString();
                this.ddlStorage.SelectedValue = oDT.Rows[0][WRTSData.STOCODE_FIELD].ToString();
                if (this._OP == OP.I)
                {
                   
                }
                //架位。
                if (this._OP == OP.I)
                {
                    //this.item1.ddlCon.StoCode = oDT.Rows[0][WRTSData.STOCODE_FIELD].ToString();
                    FillCon(oDT.Rows[0][WRTSData.STOCODE_FIELD].ToString());
                    
                    this.txtReceiver.Text = Master.CurrentUser.thisUserInfo.EmpName;
                    this.TextBox2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                //用途。
                this.ddlPurpose.SelectedText = oDT.Rows[0][WRTSData.REQREASON_FIELD].ToString();
                this.ddlPurpose.SelectedValue = oDT.Rows[0][WRTSData.REQREASONCODE_FIELD].ToString();
                //备注。
                this.txtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //申请部门。
                this.ddlDept.SelectedText = oDT.Rows[0][WRTSData.REQDEPTNAME_FIELD].ToString();
                this.ddlDept.SelectedValue = oDT.Rows[0][WRTSData.REQDEPT_FIELD].ToString();
                //申请人。
                this.txtProposer.Text = oDT.Rows[0][WRTSData.PROPOSER_FIELD].ToString();
                //验收结果
                this.ddlCheckResult.SelectedValue = oDT.Rows[0][WRTSData.CHKRESULT_FIELD].ToString();


                //制单人
                this.TextBox1.Text = oDT.Rows[0]["AuthorName"].ToString();

                //DataGrid
                this.MzhDataGrid1.DataSource = this.thisTable;
                this.MzhDataGrid1.DataBind();
                ShowModel(this._OP);

            }
		}
		/// <summary>
		/// 不同操作模式下的显示模式。
		/// </summary>
		/// <param name="strModel">string:操作模式。</param>
		private void ShowModel(string strModel)
		{
            switch (strModel)
            {
                case OP.FirstAudit:
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlStorage.Enable = false;
                    this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
                    ddlCheckResult.Enable = false;
                    txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                    break;
                case OP.SecondAudit:
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlStorage.Enable = false;
                    this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
                    txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                    ddlCheckResult.Enable = false;
                    break;
                case OP.ThirdAudit:
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlStorage.Enable = false;
                    this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
                    txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                    ddlCheckResult.Enable = false;
                    break;
                case OP.Check:
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlStorage.Enable = false;
                    this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
                    txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                    ddlCheckResult.Enable = false;
                    break;
                case OP.Submit:
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlStorage.Enable = false;
                    this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
                    break;

                case OP.I:
                    this.ddlPurpose.Disabled = true;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlStorage.Enable = false;
                    this.TextBox1.Attributes.Add("ReadOnly", "ReadOnly");
                    txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                    ddlCheckResult.Enable = false;
                    break;



            }
		}
		/// <summary>
		/// 设定单据状态。
		/// </summary>
		/// <param name="oWRTSData">WRTSData:	生产退料单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(WRTSData oWRTSData, string OpMode)
		{
            if (oWRTSData.Count > 0)
            {
                DataRow oDataRow = oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oWRTSData.Tables[0]).GetEntryState(OpMode);
            }
		}
		/// <summary>
		/// 设定操作人。
		/// </summary>
		/// <param name="oWRTSData">WRTSData:	生产退料单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetOperator(WRTSData oWRTSData, string OpMode)
		{
            if (oWRTSData.Count > 0)
            {
                DataRow oDataRow = oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0];

                switch (OpMode)
                {
                    case OP.New://新建。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.NewAndPresent://新建并且提交。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Edit://编辑。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.EditAndPresent://编辑并且提交。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Submit://提交
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.FirstAudit://一级审批。
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.SecondAudit://二级审批。
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.ThirdAudit://三级审批。
                        oDataRow[InItemData.ASSESSOR3_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.I:
                        oDataRow[WRTSData.STOMANAGERCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[WRTSData.STOMANAGER_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.Check:
                        oDataRow[WRTSData.CHKMANCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;  //当前用户作为验收人代码。
                        oDataRow[WRTSData.CHKMANNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;  //当前用户作为验收人。
                        break;

                }
            }
		}
		/// <summary>
		/// 填充数据集。
		/// </summary>
		/// <param name="oWRTSData">WRTSData:	生产退料单实体。</param>
		private void FillData(WRTSData oWRTSData)
		{
            DataRow dr = oWRTSData.Tables[WRTSData.WRTS_TABLE].NewRow();
            //单据台头部分内容。
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。

            dr[PMRPData.REQDEPT_FIELD] = ddlDept.SelectedValue;			//申请部门。
            dr[PMRPData.REQDEPTNAME_FIELD] = ddlDept.SelectedText;		//申请部门名称。

            dr[WRTSData.STONAME_FIELD] = ddlStorage.SelectedText;		//仓库
            dr[WRTSData.STOCODE_FIELD] = ddlStorage.SelectedValue;		//仓库名称
            if (this.txtRemark.Text.Trim() != "")
            {
                dr[InItemData.REMARK_FIELD] = this.txtRemark.Text.Trim();
            }
            if (txtProposer.Text != "")
            {
                dr[PMRPData.PROPOSER_FIELD] = txtProposer.Text;			//申请人。
            }
            dr[WRTSData.REQREASON_FIELD] = ddlPurpose.SelectedText;         //用途名称。
            dr[WRTSData.REQREASONCODE_FIELD] = ddlPurpose.SelectedValue;    //用途编号。
            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
            dr[WRTSData.CHKRESULT_FIELD] = this.ddlCheckResult.SelectedValue;//验收结果。

            Col2List MyCol2List = new Col2List(this.thisTable);
            dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//请购单合计金额。
            dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();//顺序号。
            dr[WRTSData.SOURCEENTRY_FIELD] = MyCol2List.GetList(WRTSData.SOURCEENTRY_FIELD);//源单据号。
            dr[WRTSData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(WRTSData.SOURCEDOCCODE_FIELD);//源单据类型。
            dr[WRTSData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(WRTSData.SOURCESERIALNO_FIELD);//源单据序号。
            dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);//物料编号。
            dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);//物料名称。
            dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);//规格型号。
            dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);//单位。
            dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);//单位名称。
            dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);//单价。
            dr[WRTSData.PLANNUM_FIELD] = MyCol2List.GetList(WRTSData.PLANNUM_FIELD);//应退数量。
            dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);//实退数量。
            dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);//金额。
            if (this._OP == OP.I)
            {
                dr[WRTSData.CONCODE_FIELD] = MyCol2List.GetList(WRTSData.CONCODE_FIELD);//架位
                dr[WRTSData.CONNAME_FIELD] = MyCol2List.GetList(WRTSData.CONNAME_FIELD);//架位名称
            }

            oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows.Add(dr);
		}

		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="OpMode">string: 操作模式。</param>
		/// <param name="oWRTSData">WRTSData:	单据实体。</param>
		/// <returns>bool:	前提条件满足则返回True，不满足则返回False。</returns>
		private void CheckOpPrecondition(string OpMode,WRTSData oWRTSData)
		{
            switch (OpMode)
            {
                case OP.Edit://编辑。
                    if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WRTSData.XUpdate, true); }
                    break;
                case OP.Submit://提交。
                    if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WRTSData.XPresent, true); }
                    break;
                case OP.FirstAudit://一级审批。
                    if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WRTSData.XFirstAudit, true); }
                    break;
                case OP.SecondAudit://二级审批。
                    if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WRTSData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://三级审批。
                    if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WRTSData.XThirdAudit, true); }
                    break;
                case OP.I://收料。
                    if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + WRTSData.XReceive, true); }
                    break;
            }
		}
		
		/// <summary>
		/// 根据仓库编号填充架位列表。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		private void FillCon(string StoCode)
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StoCode", StoCode);
			DataSet DS = DA.ExecSPReturnDS("Sto_StoConGetByStoCode",oHT);
			ListItem Item;
			this.ddlCon.Items.Clear();
			foreach(DataRow r in DS.Tables[0].Rows)
			{
				Item = new ListItem(r["Description"].ToString(),r["Code"].ToString());
				this.ddlCon.Items.Add(Item);
			}
		}
		/// <summary>
		/// 设置架位选中项。
		/// </summary>
		/// <param name="TargetValue">string:	目标值。</param>
		private void SetSelectedItem(string TargetValue)
		{
			this.ddlCon.SelectedValue = TargetValue;
		}
        private int GetRowIndex(string serialNo)
        {
            for (i = 0; i < thisTable.Rows.Count; i++)
            {
                if (serialNo == this.thisTable.Rows[i]["SerialNo"].ToString())
                {
                    return i;
                }
            }

            return -1;
        }
		#endregion
		
		#region 事件
		/// <summary>
		/// 页面的Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.RTS;//设定当前页面的帮助码。
			if (!string.IsNullOrEmpty(Request["Op"] ))
			{
				this._OP = this.Request["Op"];
			}
            txtItemPrice.Visible = Master.DisplayRTSPrice;

            ddlDept.Width = new Unit("80%");
            if (this._OP != OP.I) //20080418 切换实退数量控件的显示模式
            {
                this.txtPlanNum.Visible = true;
                this.txtItemNum.Visible = false;

            }
            else
            {
                this.txtPlanNum.Visible = false;
                this.txtItemNum.Visible = true;
            }

            SetButtonStatus(this._OP);
			if(!this.IsPostBack)
			{
				switch (_OP)
				{
					case OP.New:
						if (!Master.HasBrowseRight(SysRight.RTSMaintain))
						{
							
							return;
						}
						this.BindDataNew();
						this.btnSave.Text = OPName.New;
                        RTSStyle = "";
						break;
					case OP.Edit:
                        if (!Master.HasBrowseRight(SysRight.RTSMaintain))
						{
							
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Edit;
                        RTSStyle = "";
						break;
					case OP.Submit:
                        if (!Master.HasBrowseRight(SysRight.RTSPresent))
						{
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Submit;
						this.btnPresent.Visible = false;
                        RTSStyle = "";
						break;
					case OP.FirstAudit:
                        if (!Master.HasBrowseRight(SysRight.RTSFirstAudit))
						{
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.FirstAudit;
                        RTSStyle = "display:none;visibility:hidden;";
                        this.ddlPurpose.Disabled = false;
						this.btnPresent.Visible = false;
						break;
					case OP.SecondAudit:
                        if (!Master.HasBrowseRight(SysRight.RTSSecondAudit))
						{
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.SecondAudit;
                        RTSStyle = "display:none;visibility:hidden;";
                        this.ddlPurpose.Disabled = false;
						this.btnPresent.Visible = false;
						break;
					case OP.ThirdAudit:
                        if (!Master.HasBrowseRight(SysRight.RTSThirdAudit))
						{
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.ThirdAudit;
                        RTSStyle = "display:none;visibility:hidden;";
                        this.ddlPurpose.Disabled = false;
						this.btnPresent.Visible = false;
						break;
					case OP.I:
                        if (!Master.HasBrowseRight(SysRight.StockIn))
						{
							return;
						}
						this.BindDataUpdate();
                      
                       
						this.btnSave.Text = OPName.I;
                        RTSStyle = "display:none;visibility:hidden;";
                        this.ddlPurpose.Disabled = false;
						this.btnPresent.Visible = false;
                        this.btnUpdate.Enabled = false;
                        this.btnDelete.Enabled = false;
                        this.btnEdit.Enabled = true;
						break;
				}
			}
		}
		
		
		/// <summary>
		/// 设置操作按纽状态
		/// </summary>
		private void SetButtonStatus(string OpMode)
		{
            if (!Page.IsPostBack)
            {
                switch (OpMode)
                {
                    case OP.New:
                    case OP.Edit:
                        btnUpdate.Enabled = true;
                        this.btnEdit.Enabled = true;
                        this.btnDelete.Enabled = true;
                        break;
                    case OP.Submit:
                    case OP.FirstAudit:
                    case OP.SecondAudit:
                    case OP.ThirdAudit:
                    case OP.Red:
                        btnUpdate.Enabled = false;
                        this.btnEdit.Enabled = false;
                        this.btnDelete.Enabled = false;
                        break;
                    case OP.O:
                        btnUpdate.Enabled = true;
                        this.btnEdit.Enabled = true;
                        this.btnDelete.Enabled = false;
                        break;
                }
            }
		}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //SelectedSerialNo = int.Parse(this.MzhDataGrid1.SelectedID);
            if (this.SelectedSerialNo != -1)
            {
                ItemPrice = decimal.Parse(this.thisTable.Rows[this.SelectedSerialNo]["ItemPrice"].ToString());
                if (this._OP != OP.I)
                {
                    decimal PlanNum;
                    try
                    {
                        PlanNum = decimal.Parse(this.txtPlanNum.Text);
                    }
                    catch
                    {
                        PlanNum = 0;
                    }
                    this.thisTable.Rows[this.SelectedSerialNo]["PlanNum"] = PlanNum;
                    this.thisTable.Rows[this.SelectedSerialNo]["ItemMoney"] = Math.Round(PlanNum * ItemPrice, 2);
                    
                }
                else
                {
                    decimal ItemNum;
                    try
                    {
                        ItemNum = decimal.Parse(this.txtItemNum.Text);
                    }
                    catch
                    {
                        ItemNum = 0;
                    }
                    this.thisTable.Rows[this.SelectedSerialNo]["ItemNum"] = ItemNum;
                    this.thisTable.Rows[this.SelectedSerialNo]["ItemMoney"] = Math.Round(ItemNum * ItemPrice, 2);
                    this.thisTable.Rows[this.SelectedSerialNo]["ConCode"] = this.ddlCon.SelectedValue;
                    this.thisTable.Rows[this.SelectedSerialNo]["ConName"] = this.ddlCon.SelectedItem.Text;

                    //this.btnUpdate.Text = "新增";
                   
                }
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.txtItemUnit.Text = "";
                this.txtItemPrice.Text = "";
                this.txtPlanNum.Text = "";
                this.txtItemMoney.Text = "";

                this.MzhDataGrid1.DataSource = this.thisTable;
                this.MzhDataGrid1.DataBind();
                this.SelectedSerialNo = -1;
                btnUpdate.Enabled = false;
                this.btnEdit.Enabled = true;
            }
            else
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请填写物料信息!');", true);
                return;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MzhDataGrid1.SelectedID))
            {

                iRow = this.GetRowIndex(this.MzhDataGrid1.SelectedID);
                this.thisTable.Rows.RemoveAt(iRow);
                Logger.Debug(thisTable.Rows.Count);
                this.SelectedSerialNo = -1;
                this.MzhDataGrid1.DataSource = this.thisTable;
                this.MzhDataGrid1.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.SelectedSerialNo == -1)
            {
                if (!string.IsNullOrEmpty(this.MzhDataGrid1.SelectedID))
                {

                    iRow = int.Parse(this.MzhDataGrid1.SelectedID.ToString());
                    this.SelectedSerialNo = iRow;
                    oRow = this.thisTable.Rows[iRow];
                    this.txtItemCode.Text = oRow["ItemCode"].ToString();
                    this.txtItemName.Text = oRow["ItemName"].ToString();
                    this.txtItemSpecial.Text = oRow["ItemSpecial"].ToString();
                    this.txtItemUnit.Text = oRow["ItemUnitName"].ToString();
                    this.txtItemPrice.Text = oRow["ItemPrice"].ToString();
                    if (this._OP != OP.I)
                    {
                        this.txtPlanNum.Text = oRow["PlanNum"].ToString();

                       
                    }
                    else
                    {
                        this.txtPlanNum.Text = oRow["ItemNum"].ToString();
                    }

                    try
                    {
                        this.ddlCon.SelectedValue = oRow[WRTSData.CONCODE_FIELD].ToString();
                    }
                    catch { }
                    this.txtItemMoney.Text = oRow["ItemMoney"].ToString();

                    this.btnUpdate.Text = "更新";
                    this.btnUpdate.Enabled = true;
                    this.btnEdit.Enabled = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //没有内容
            if (this.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oWRTSData = new WRTSData();
            FillData(oWRTSData);
            SetOperator(oWRTSData, this._OP);
            SetEntryState(oWRTSData, this._OP);

            
            ret = true;
            switch (this._OP)
            {
                case OP.New:

                    if (Master.HasRight(SysRight.RTSMaintain))
                        ret = oItemSystem.AddWRTS(oWRTSData);
                    else
                        ret = false;
                    break;
                case OP.Edit:

                    if (Master.HasRight(SysRight.RTSMaintain))
                        ret = oItemSystem.UpdateWRTS(oWRTSData);
                    else
                        ret = false;
                    break;
                case OP.Submit:

                    if (Master.HasRight(SysRight.RTSPresent))
                        ret = oItemSystem.PresentWRTS(this.doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
                    else
                        ret = false;
                    break;
                case OP.FirstAudit:

                    if (Master.HasRight(SysRight.RTSFirstAudit))
                    {
                        if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
                            oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
                        {
                           // this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
                        else
                        {
                            ret = oItemSystem.FirstAuditWRTS(oWRTSData);
                        }
                    }
                    else
                        ret = false;
                    break;
                case OP.SecondAudit:

                    if (Master.HasRight(SysRight.RTSSecondAudit))
                    {
                        if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "Y" &&
                            oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
                        else
                        {
                            ret = oItemSystem.SecondAuditWRTS(oWRTSData);
                        }
                    }
                    else
                        ret = false;
                    break;
                case OP.ThirdAudit:

                    if (Master.HasRight(SysRight.RTSThirdAudit))
                    {
                        if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "Y" &&
                            oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
                        else
                        {
                            ret = oItemSystem.ThirdAuditWRTS(oWRTSData);
                        }
                    }
                    else
                        ret = false;
                    break;
                case OP.Check:

                    //if (Master.HasRight(SysRight.CBRAdd))
                    //    ret = oItemSystem.Check(oWRTSData);
                    //else
                    //    ret = false;
                    //break;
                case OP.I:

                    if (Master.HasRight(SysRight.StockIn))
                        ret = oItemSystem.ReceiveRTS(oWRTSData);
                    else
                        ret = false;
                    break;

            }

            if (ret == false)
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
            else
            {
                if (Master.IsTODO)
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                else
                    this.Response.Redirect("RTSBrowser.aspx");
            }
        }

        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //没有内容
            if (this.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oWRTSData = new WRTSData();
            FillData(oWRTSData);
            ret = true;
            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    this.SetOperator(oWRTSData, this._OP);//设定操作人。
                    this.SetEntryState(oWRTSData, this._OP);//设定单据状态。
                    if (Master.HasRight(SysRight.RTSPresent))
                        ret = oItemSystem.AddAndPresentWRTS(oWRTSData);
                    else
                        ret = false;
                    break;
                case OP.Edit:
                    this._OP = OP.NewAndPresent;
                    this.SetOperator(oWRTSData, this._OP);//设定操作人。
                    this.SetEntryState(oWRTSData, this._OP);//设定单据状态。
                    if (Master.HasRight(SysRight.RTSPresent))
                        ret = oItemSystem.UpdateAndPresentWRTS(oWRTSData);
                    else
                        ret = false;

                    break;
            }

            if (ret == false)
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
            else
                this.Response.Redirect("RTSBrowser.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Master.IsTODO)
            {
                this.Response.Write("<script>window.close();</script>");
            }
            else
            {
                if (this._OP == OP.I)
                    Response.Redirect("../Purchase/PInBrowser.aspx");
                else
                    Response.Redirect("RTSBrowser.aspx");
            }
        }

        protected void btnMainInfo_Click(object sender, EventArgs e)
        {
            if (this.txtWDRWEntryNo.Value != "")
            {
               
                DrawEntryNo = int.Parse(this.txtWDRWEntryNo.Value);
                oHT = new Hashtable();
                oHT.Add("@EntryNo", DrawEntryNo);
                DS = new SQLServer().ExecSPReturnDS("Sto_RTSGetSourceMainInfoByEntryNo", oHT);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    this.ddlStorage.SelectedValue = DS.Tables[0].Rows[0]["StoCode"].ToString();
                    this.ddlStorage.SelectedText = DS.Tables[0].Rows[0]["StoName"].ToString();
                    this.ddlStorage.SetItemSelected(DS.Tables[0].Rows[0]["StoCode"].ToString());

                    this.ddlPurpose.SelectedValue = DS.Tables[0].Rows[0]["ReqReasonCode"].ToString();
                    this.ddlPurpose.SelectedText = DS.Tables[0].Rows[0]["ReqReason"].ToString();
                }
                DS = new SQLServer().ExecSPReturnDS("Sto_RTSGetSourceDetailByEntryNo", oHT);
                this.thisTable.Rows.Clear();
                
                for (i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    r = DS.Tables[0].Rows[i];
                    newRow = this.thisTable.NewRow();
                    newRow["SerialNo"] = i;
                    newRow["SourceEntry"] = r["SourceEntry"];
                    newRow["SourceDocCode"] = r["SourceDocCode"];
                    newRow["SourceSerialNo"] = r["SourceSerialNo"];
                    newRow["ItemCode"] = r["ItemCode"];
                    newRow["ItemName"] = r["ItemName"];
                    newRow["ItemSpecial"] = r["ItemSpecial"];
                    newRow["ItemUnit"] = r["ItemUnit"];
                    newRow["ItemUnitName"] = r["ItemUnitName"];
                    newRow["ItemPrice"] = r["ItemPrice"];
                    newRow["PlanNum"] = r["ItemNum"];
                    newRow["ItemMoney"] = r["ItemMoney"];
                    this.thisTable.Rows.Add(newRow);
                }
                this.MzhDataGrid1.DataSource = this.thisTable;
                this.MzhDataGrid1.DataBind();
            }
        }
        #endregion

        protected void MzhDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[5].Visible = Master.DisplayRTSPrice;
                e.Item.Cells[8].Visible = Master.DisplayRTSPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[5].Visible = Master.DisplayRTSPrice;
                e.Item.Cells[8].Visible = Master.DisplayRTSPrice;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[5].Visible = Master.DisplayRTSPrice;
                e.Item.Cells[8].Visible = Master.DisplayRTSPrice;
            }
        }
    }
}
