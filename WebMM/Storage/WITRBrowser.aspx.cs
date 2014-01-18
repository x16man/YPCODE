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
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
//using MZHCommon.PageStyle;
using Shmzh.Components.SystemComponent;
//using Shmzh.Components.SelectEngine;
namespace WebMM.Storage
{
    /// <summary>
    /// WITRBrowser 的摘要说明。
    /// </summary>
    public partial class WITRBrowser : System.Web.UI.Page
    {
        #region 成员变量
		protected System.Web.UI.WebControls.TextBox Textbox1;

         ItemSystem oItemSystem=new ItemSystem();

        private DataRow oRow;

         //SelectEngine oSelectEngine = new SelectEngine();

        private WITRData oData;

        private ItemData oItemData = new ItemData();

        private bool ret;

        string DefStoCode;
        string CatCode;
        string PrefixStr;
        string NewCode;
        #endregion

        #region 属性
        /// <summary>
        /// 要生成的单据类型编号。
        /// </summary>
        public int DocCode
        {
            get {return int.Parse(this.txtDocCode.Value);}
            set { this.txtDocCode.Value = value.ToString(); }
        }
       
        /// <summary>
        /// 当前操作。
        /// </summary>
        private string Op
        {
            get
            {
                if (this.Request["OP"] != null && this.Request["OP"].ToString() != "")
                {
                    return this.Request["OP"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 表单主键。
        /// </summary>
        private int PKID
        {
            get 
            {
                if (this.Request["PKID"] != null && this.Request["PKID"].ToString() != "")
                {
                    return int.Parse(this.Request["PKID"].ToString());
                }
                else
                {
                    return  -1;
                }
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 数据绑定。
        /// </summary>
        public string Keyword(string name,string key)
        {
            name = name.Replace(key,"<font color=Red>"+key+"</font>");
            return name;
        }
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void myDataBindSearch()
        {
           
            if (this.txtItemNameSearch.Text.Trim()==string.Empty&&this.txtItemSpecSearch.Text.Trim()==string.Empty)
            {
                DataGrid1.DataSource = oItemSystem.GetItemsByNameAndSpec(this.txtItemName.Text.Trim(),this.txtItemSpec.Text.Trim());
                this.txtItemNameSearch.Text = this.txtItemName.Text;
                this.txtItemSpecSearch.Text = this.txtItemSpec.Text;
            } 
            else
            {
                 DataGrid1.DataSource = oItemSystem.GetItemsByNameAndSpec(this.txtItemNameSearch.Text.Trim(),this.txtItemSpecSearch.Text.Trim());
            }
            
           // this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
            try
            {
                DataGrid1.DataBind();
            }
            catch(Exception e)
            {
                if(e.Source=="System.Web" && DataGrid1.CurrentPageIndex>=1)
                {
                    DataGrid1.CurrentPageIndex--;
                    try
                    {
                        DataGrid1.DataBind();
                    }
                    catch
                    {
                        DataGrid1.CurrentPageIndex = 0;
                        DataGrid1.DataBind();
                    }
                }				
            }			
        }

        private void myDataBind()
        {
            if (this.Op == OP.New )
            {
                this.txtAuthorName.Text = Master.CurrentUser.thisUserInfo.EmpName;
                this.txtDeptName.Text = Master.CurrentUser.thisUserInfo.DeptName;
                this.txtItemCode.ReadOnly = true;
                this.btnCode.Enabled = false;
                this.ddlStorage.Enable = false;
                this.ddlCon.Enable = false;
                this.ddlCategory.Enable = false;
                this.ddlStatus.Enable = false;
                this.ddlMB.Enable = false;
                this.ddlABC.Enable = false;
                this.btnRefuse.Visible = false;
                this.btnRos.Visible = false;
                this.txtFeedBack.ReadOnly = true;
                this.btnClear.Visible = false;
            }
            else if (this.Op == OP.Edit)
            {
                this.txtAuthorName.Text = Master.CurrentUser.thisUserInfo.EmpName;
                this.txtDeptName.Text = Master.CurrentUser.thisUserInfo.DeptName;
                this.txtItemCode.ReadOnly = true;
                this.btnCode.Enabled = false;
                this.ddlStorage.Enable = false;
                this.ddlCon.Enable = false;
                this.ddlCategory.Enable = false;
                this.ddlStatus.Enable = false;
                this.ddlMB.Enable = false;
                this.ddlABC.Enable = false;
                this.btnRefuse.Visible = false;
                this.btnRos.Visible = false;
                this.txtFeedBack.ReadOnly = true;
                this.btnRefuse.Visible = false;
                this.btnRos.Visible = false;


                oData = new WITRData();
                oData = oItemSystem.GetWITRByPKID(this.PKID);
                this.txtAuthorName.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.AuthorName_Field].ToString();
                this.txtDeptName.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.AuthorDeptName_Field].ToString();
                this.txtItemCode.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemCode_Field].ToString();
                this.txtItemName.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemName_Field].ToString();
                this.txtItemSpec.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemSpec_Field].ToString();
                this.ddlUnit.SelectedText = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.UnitName_Field].ToString();
                this.ddlUnit.SelectedValue =oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.UnitCode_Field].ToString(); 
                this.ddlUse.SelectedText = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqReason_Field].ToString();
                this.ddlUse.SelectedValue = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqReasonCode_Field].ToString();
                this.txtRemark.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.Remark_Field].ToString();
                this.txtFeedBack.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.FeedBack_Field].ToString();
                try
                {
                    if (oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqDate_Field].ToString() != "")
                        this.calcDate.Text = DateTime.Parse(oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqDate_Field].ToString()).ToString("yyyy-MM-dd");
                }
                catch
                {
                }

                try
                {
                    this.ddlCon.StoCode = this.ddlStorage.SelectedValue;
                    ddlCon.IsClear = true;
                }
                catch { }
                this.txtItemPrice.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemPrice_Field].ToString();
                this.txtItemNum.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemNum_Field].ToString();
                this.txtDocCode.Value = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.DocCode_Field].ToString();
                if (this.txtDocCode.Value != "1")
				{
					this.btnRos.Text = "转成计划需求单";
				}
            }
            else
            {
                this.txtItemCode.ReadOnly = false;
                this.btnCode.Enabled = true;
                this.ddlStorage.Enable = true;
                this.ddlCon.Enable = true;
                this.ddlCategory.Enable = true;
                this.ddlStatus.Enable = true;
                this.ddlMB.Enable = true;
                this.ddlABC.Enable = true;


                oData = new WITRData();
                oData = oItemSystem.GetWITRByPKID(this.PKID);
                this.txtAuthorName.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.AuthorName_Field].ToString();
                this.txtDeptName.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.AuthorDeptName_Field].ToString();
                this.txtItemCode.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemCode_Field].ToString();
                this.txtItemName.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemName_Field].ToString();
                this.txtItemSpec.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemSpec_Field].ToString();
                this.ddlUnit.SelectedText = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.UnitName_Field].ToString();
                this.ddlUnit.SelectedValue =oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.UnitCode_Field].ToString(); 
                this.ddlUse.SelectedText = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqReason_Field].ToString();
                this.ddlUse.SelectedValue = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqReasonCode_Field].ToString();
                this.txtRemark.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.Remark_Field].ToString();
                this.txtFeedBack.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.FeedBack_Field].ToString();
                try
                {
                    if (oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqDate_Field].ToString() != "")
                        this.calcDate.Text = DateTime.Parse(oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqDate_Field].ToString()).ToString("yyyy-MM-dd");
                }
                catch
                {
                }
                try
                {
                    this.ddlCon.StoCode = this.ddlStorage.SelectedValue;
                    ddlCon.IsClear = true;
                }
                catch { }
                this.txtItemPrice.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemPrice_Field].ToString();
                this.txtItemNum.Text = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemNum_Field].ToString();
                this.txtDocCode.Value = oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.DocCode_Field].ToString();
                if (this.txtDocCode.Value != "1")
				{
					this.btnRos.Text = "转成计划需求单";
				}
                this.btnSave.Text = "确定新增物料";
                this.btnClear.Visible = false;
            }
        }
        /// <summary>
        /// 数据新物料申请表单填充。
        /// </summary>
        /// <returns></returns>
        private WITRData FillData()
        {
            oData = new WITRData();
            oRow = oData.Tables[WITRData.WITR_Table].NewRow();
            try
            {
                oRow[WITRData.PKID_Field] = Convert.ToInt64(this.PKID);
            }
            catch
            {}
            oRow[WITRData.AuthorCode_Field] = Master.CurrentUser.thisUserInfo.EmpCode;
            oRow[WITRData.AuthorDept_Field] = Master.CurrentUser.thisUserInfo.DeptCode;
            oRow[WITRData.AuthorDeptName_Field] = Master.CurrentUser.thisUserInfo.DeptName;
            oRow[WITRData.AuthorLoginID_Field] = Master.CurrentUser.thisUserInfo.LoginName;
            oRow[WITRData.AuthorName_Field] = Master.CurrentUser.thisUserInfo.EmpName;

            oRow[WITRData.ReqReasonCode_Field] = this.ddlUse.SelectedValue;
            oRow[WITRData.ReqReason_Field] = this.ddlUse.SelectedText;
            if (string.IsNullOrEmpty(this.calcDate.Text))
            {
                oRow[WITRData.ReqDate_Field] = System.DBNull.Value;
            }
            else
            {
                oRow[WITRData.ReqDate_Field] = this.calcDate.Text;
            }
            oRow[WITRData.ItemCode_Field] = this.txtItemCode.Text;
            oRow[WITRData.ItemName_Field] = this.txtItemName.Text;
            oRow[WITRData.ItemSpec_Field] = this.txtItemSpec.Text;
            oRow[WITRData.UnitCode_Field] = int.Parse(this.ddlUnit.SelectedValue);
            oRow[WITRData.UnitName_Field] = this.ddlUnit.SelectedText;
            try
            {
                oRow[WITRData.ItemPrice_Field] = decimal.Parse(this.txtItemPrice.Text);
            }
            catch
            {}
            try
            {
                oRow[WITRData.ItemNum_Field]  = decimal.Parse(this.txtItemNum.Text);
            }
            catch
            {}
            oRow[WITRData.Remark_Field] = this.txtRemark.Text;
            oRow[WITRData.FeedBack_Field] = this.txtFeedBack.Text;
            oRow[WITRData.DocCode_Field] = this.DocCode.ToString();
            oData.Tables[WITRData.WITR_Table].Rows.Add(oRow);
            return oData;
        }
        /// <summary>
        /// 填充物料信息。
        /// </summary>
        /// <returns></returns>
        private ItemData FillItemData()
        {
            oRow = oItemData.Tables[ItemData.ITEM_TABLE].NewRow();
            oRow[ItemData.CODE_FIELD] = this.txtItemCode.Text;
            oRow[ItemData.CNNAME_FIELD] = this.txtItemName.Text;
            oRow[ItemData.SPECIAL_FIELD] = this.txtItemSpec.Text;
            oRow[ItemData.UNITCODE_FIELD] = int.Parse(this.ddlUnit.SelectedValue);
            oRow[ItemData.UnitName_Field] = this.ddlUnit.SelectedText;

            oRow[ItemData.ABC_FIELD] = this.ddlABC.SelectedValue;
            oRow[ItemData.ACCTYPE_FIELD] = "W";
            oRow[ItemData.BATCH_FIELD] = "N";
            oRow[ItemData.CATCODE_FIELD] = int.Parse(this.ddlCategory.SelectedValue);
            oRow[ItemData.STATE_FIELD] = this.ddlStatus.SelectedValue;
            oRow[ItemData.PURMAK_FIELD] = this.ddlMB.SelectedValue;
            oRow[ItemData.CHECKED_FIELD] = "Y";
            oRow[ItemData.CHKRPTCODE_FIELD] = System.DBNull.Value;

            try
            {
                oRow[ItemData.EVAPRICE_FIELD] = decimal.Parse(this.txtItemPrice.Text);
            }
            catch
            {}
            oRow[ItemData.CSTPRICE_FIELD] = System.DBNull.Value;
            oRow[ItemData.UPPNUM_FIELD] = System.DBNull.Value;
            oRow[ItemData.LOWNUM_FIELD] = System.DBNull.Value;
            oRow[ItemData.SAFNUM_FIELD] = System.DBNull.Value;
            oRow[ItemData.ORDBAT_FIELD] = System.DBNull.Value;
            oRow[ItemData.ORDNUM_FIELD] = System.DBNull.Value;
            oRow[ItemData.PRVCODE_FIELD] = "-1";
            oRow[ItemData.DEFSTO_FIELD] = this.ddlStorage.SelectedValue;
            try
            {
                oRow[ItemData.DEFCON_FIELD] = int.Parse(this.ddlCon.SelectedValue);
            }
            catch
            {}
		    
            oItemData.Tables[ItemData.ITEM_TABLE].Rows.Add(oRow);

            return oItemData;

        }
        #endregion

        #region 事件
        /// <summary>
        /// 页面事件加载。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.Request["DocCode"]))
                {
                    this.DocCode = int.Parse(this.Request["DocCode"]);
                }
                this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
                this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
                this.ddlCategory.Module_Tag =(int)SDDLTYPE.CATEGORY;
                this.ddlStatus.Module_Tag = (int)SDDLTYPE.ITEMSTATE;
                this.ddlMB.Module_Tag = (int)SDDLTYPE.PURMAK;
                this.ddlABC.Module_Tag = (int)SDDLTYPE.ABC;
                this.ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
                this.ddlStorage.Width = new Unit("100%");
                this.ddlStorage.AutoPostBack = true;
                this.ddlCon.Width = new Unit("100%");
                this.ddlCategory.Width = new Unit("100%");
                this.ddlUse.Width = new Unit("80%");
                this.ddlStatus.Width = new Unit("100%");
                this.ddlCon.Width = new Unit("100%");
                this.ddlUnit.Width = new Unit("100%");
                this.ddlABC.Width = new Unit("100%");
                this.ddlMB.Width = new Unit("100%");
                this.myDataBind();
            }
        }

       

        /// <summary>
        /// 排序。
        /// </summary>
        private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            this.myDataBindSearch();
        }
        #endregion

        #region 受保护的方法
        protected override bool OnBubbleEvent(object Sender,EventArgs e)
        {
            try
            {
                if (Sender is DropDownList)
                {
                    if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == ddlStorage.thisDDL.ClientID)
                    {
                        this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
                        this.ddlCon.StoCode = this.ddlStorage.SelectedValue;
                        ddlCon.IsClear = true;
                        this.ddlCon.SetDDL();
                    }
                }
            }
            catch
            {}
            return true;
        }

        #endregion	

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }
		
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {    
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);

		}
        #endregion

        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            myDataBindSearch();
        }

        protected void calcDate_ServerChange(object sender, System.EventArgs e)
        {
        
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          
          
            oData = this.FillData();
            if (ddlUnit.SelectedValue == "-1")
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + "没有指定单位！");
            }
            

            ret = false;
            switch (this.Op)
            {
                case OP.New:
                    oData.Tables[0].Rows[0]["EntryState"] = "N";
                    ret = oItemSystem.Insert(oData);
                    if (ret == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        //this.Response.Write("<script>window.close();</script>");
                        //Page.RegisterStartupScript("op_New", "<script>window.close();</script>");
                        ClientScript.RegisterStartupScript( this.GetType(), "op_New", "alert('新增成功!');", true);
                    }
                    break;
                case OP.Edit:
                    oData.Tables[0].Rows[0]["EntryState"] = "N";
                    ret = oItemSystem.Update(oData);
                    if (ret == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        //this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                        //Page.RegisterStartupScript("op_Edit", "<script>window.close();window.opener.history.go(0);</script>");
                        //ScriptManager.RegisterStartupScript(this.btnSave, this.GetType(), "op_Edit", "window.close();window.opener.history.go(0);", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "op_Edit", "alert('修改成功!');window.opener.history.go(0);", true);
                    
                    }
                    break;
                case OP.Affirm:
                    oData.Tables[0].Rows[0]["EntryState"] = "C";
                    oItemData = this.FillItemData();
                    ret = oItemSystem.AddItem(oItemData);
                    if (ret == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        ret = oItemSystem.Affirm(oData);
                        if (ret == false)
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "op_Affirm", "alert('已确认')", true);
                        }
                        //else
                        //{
                        //    if(Master.IsTODO)
                        //        ScriptManager.RegisterStartupScript(this.btnSave, this.GetType(), "op_Affirm", "parent.parent.document.location='todo.aspx';", true);
                    
                        //}
                    }
                    break;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
           
            oData = this.FillData();
           
            ret = false;
            ret = oItemSystem.Cancel(oData);
            if (ret == false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
            }
            else
            {
                //this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
               // Page.RegisterStartupScript("Clear", "<script>window.close();window.opener.history.go(0);</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Clear", "window.close();window.opener.history.go(0);", true);
            }
        }

        protected void btnRos_Click(object sender, EventArgs e)
        {
           
            oData = this.FillData();
            if (oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ReqReasonCode_Field].ToString() == "-1")
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + "没有指定用途，无法自动生成请购单！");
            }
            if (oData.Tables[WITRData.WITR_Table].Rows[0][WITRData.ItemNum_Field].ToString() == "")
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + "没有指定数量，无法自动生成请购单！");
            }
           
            ret = false;
            if (this.DocCode == 1)
                ret = oItemSystem.ToPROS(oData);
            else
                ret = oItemSystem.ToMRP(oData);

            if (ret == false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
            }
            else
            {
                //this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
               // Page.RegisterStartupScript("Ros", "<script>window.close();window.opener.history.go(0);</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Ros", "window.close();window.opener.history.go(0);", true);
            }
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {
           
            oData = this.FillData();
            
            ret = false;
            ret = oItemSystem.Refuse(oData);
            if (ret == false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
            }
            else
            {
                //this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                //Page.RegisterStartupScript("Refuse", "<script>window.close();window.opener.history.go(0);</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Refuse", "window.close();window.opener.history.go(0);", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Page.RegisterStartupScript("Cancel", "<script>window.close();</script>");
            ClientScript.RegisterStartupScript( this.GetType(), "Cancel", "window.close();", true);
        }

        protected void btnCode_Click(object sender, EventArgs e)
        {
            DefStoCode = "";
            CatCode = "";
            PrefixStr = "";
            NewCode = "";
            CatCode = this.ddlCategory.SelectedValue;
            DefStoCode = this.ddlStorage.SelectedValue;
            if (CatCode != "-1" && DefStoCode != "-1")
            {
                if (CatCode.Length == 1)
                {
                    CatCode = "0" + CatCode;
                }
                PrefixStr = DefStoCode + CatCode;
                //TODO:推荐编号。
                NewCode = new ItemSystem().GetItemRecommandCode(PrefixStr);
                if (NewCode == "")
                {
                    NewCode = PrefixStr + "0001";
                }
                this.txtItemCode.Text = NewCode;
            }
            else
            {
                //this.Response.Write("<script>alert('请先设好分类和仓库！');</script>");
               // Page.RegisterStartupScript("Code", "<script>alert('请先设好分类和仓库！');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Code", "alert('请先设好分类和仓库！');", true);
            }
        }

        

		
    }
}
