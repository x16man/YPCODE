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
using Shmzh.MM.DataAccess.Storage;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace WebMM.Storage
{
    public partial class KMUpdate : System.Web.UI.Page
    {


        #region 属性

        private int entryNo;
        private int serialNo;
        private string whereClause;

        private DateTime beginDate;

        private ViewOutedWDRWs providers;

        private ViewOutedWDRWData objs;

        private DateTime endDate;

        private ViewOutedWDRWData obj;

        private string sql;
        /// <summary>
        /// SQL的Select部分.
        /// </summary>
        protected string PreSQL
        {
            get { return this.ViewState["PreSQL"].ToString(); }
            set { this.ViewState["PreSQL"] = value; }
        }
        /// <summary>
        /// 查询语句.
        /// </summary>
        protected string SQL_Statement
        {
            get { return this.ViewState["QuerySQL"].ToString(); }
            set { this.ViewState["QuerySQL"] = value; }
        }
        /// <summary>
        /// 当前选中编辑的领料单明细记录.
        /// </summary>
        protected ViewOutedWDRWData CurrentViewOutedWDRW
        {
            get { return this.ViewState["CurrentViewOutedWDRW"] as ViewOutedWDRWData; }
            set { this.ViewState["CurrentViewOutedWDRW"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Master.HasBrowseRight(SysRight.KMUpdateMaintain))
                {
                    return;
                }
                this.btnUpdate.Attributes.Add("onclick", "return confirm('确定要保存?')");
                this.PreSQL = "Select * From ViewOutedWDRW ";
                this.txtKM3.Visible = false;
                this.txtBeginDate.Text = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1).ToString("yyyy-MM-dd");
                this.txtEndDate.Text = DateTime.Parse(this.txtBeginDate.Text).AddMonths(1).ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 数据绑定.
        /// </summary>
        private void MyDataBind()
        {
            providers = new ViewOutedWDRWs();
            objs = providers.GetEntryBySQL(this.SQL_Statement);
            this.MzhDataGrid1.DataSource = objs.Tables[ViewOutedWDRWData.ViewOutedWDRW_Table].DefaultView;
            this.MzhDataGrid1.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            whereClause = string.Empty;
            this.MzhDataGrid1.CurrentPageIndex = 0;
            if (this.txtBeginDate.Text.Trim().Length > 0)
            {
                try
                {
                    beginDate = DateTime.Parse(this.txtBeginDate.Text.Trim());
                    whereClause += string.Format("DrawDate >='{0}'", beginDate.ToShortDateString());
                }
                catch
                {
                   // this.RegisterStartupScript("alert", "<script>alert('开始日期格式不正确!');</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('开始日期格式不正确')", true);
                    return;
                }
            }
            if (this.txtEndDate.Text.Trim().Length > 0)
            {
                try
                {
                    endDate = DateTime.Parse(this.txtEndDate.Text.Trim());
                    whereClause += (whereClause.Length > 0 ? " And " : string.Empty) + string.Format("DrawDate<='{0}'", endDate.ToShortDateString());
                }
                catch
                {
                   // this.RegisterStartupScript("alert", "<script>alert('结束日期格式不正确!');</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('结束日期格式不正确')", true);
                   
                    return;
                }
            }
            if (this.txtEntryNo.Text.Trim().Length > 0)
            {
                //try
                //{

                    whereClause += (whereClause.Length > 0 ? " And " : string.Empty) + string.Format("ItemCode like '%{0}%'", this.txtEntryNo.Text.Trim());
                //}
                //catch
                //{
                //    //this.RegisterStartupScript("alert", "<script>alert('单据编号格式不正确!');</script>");
                //    ScriptManager.RegisterStartupScript(this.btnQuery, this.GetType(), "msg", "alert('单据编号格式不正确')", true);
                   
                //    return;
                //}

            }
            if (this.txtItemName.Text.Trim().Length > 0)
            {
                whereClause += (whereClause.Length > 0 ? " And " : string.Empty) + string.Format("ItemName like '%{0}%'", this.txtItemName.Text.Trim());
            }
            if (this.txtReqReason.Text.Trim().Length > 0)
            {
                whereClause += (whereClause.Length > 0 ? " And " : string.Empty) + string.Format("(ReqReasonCode = '{0}' or ReqReason like '%{1}%')", this.txtReqReasonCode.Value.Trim(),this.txtReqReason.Text.Trim());
            }


            if(whereClause.Trim().Length > 0)
                this.SQL_Statement = this.PreSQL + " Where " + whereClause;
            else
              this.SQL_Statement = this.PreSQL ;

            this.MyDataBind();
        }

        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.CurrentViewOutedWDRW != null && CurrentViewOutedWDRW.Tables.Count > 0 && this.CurrentViewOutedWDRW.Tables[0].Rows.Count > 0)
            {
                this.CurrentViewOutedWDRW.Tables[0].Rows[0]["KM1"] = this.ddlKM1.SelectedValue;
                this.CurrentViewOutedWDRW.Tables[0].Rows[0]["KM2"] = this.txtKM2.Text;
                if (this.ddlKM3.Enabled)
                    this.CurrentViewOutedWDRW.Tables[0].Rows[0]["KM3"] = this.ddlKM3.SelectedValue;
                else
                    this.CurrentViewOutedWDRW.Tables[0].Rows[0]["KM3"] = this.txtKM3.Text;
                this.CurrentViewOutedWDRW.Tables[0].Rows[0]["KM4"] = this.txtKM4.Text;

                if (new ViewOutedWDRWs().UpdateWDODKM(this.CurrentViewOutedWDRW))
                {
                    //this.RegisterStartupScript("alert", "<script>alert('更改科目成功!');</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('更改科目成功！');", true);
                   // ScriptManager.RegisterStartupScript(this.btnUpdate, this.GetType(), "alert", "alert('更改科目成功!');", true);
                    txtKM2.Text = "";
                    this.txtKM3.Text = "";
                    txtKM4.Text = "";
                    CurrentViewOutedWDRW = null;
                    MyDataBind();
                    
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('更改科目失败！');", true);
                   
                    //this.RegisterStartupScript("alert", " <script>alert('更改科目失败!');</script>");
                    //ScriptManager.RegisterStartupScript(this.btnUpdate, this.GetType(), "alert", "alert('更改科目失败!');", true);
                }


            }
        }

        protected void ddlKM3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.ddlKM3.SelectedValue)
            {
                case "低值易耗":
                case "化验费":
                case "运输费":
                case "机物料消耗":
                    this.txtKM4.Text = string.Empty;
                    break;
                case "修理费":

                    try
                    {
                        entryNo = int.Parse(this.txtCurrentEntryNo.Text);
                        serialNo = int.Parse(this.txtCurrentSerialNo.Text);

                        sql = string.Format("Select * From ViewOutedWDRW Where EntryNo={0} And SerialNo={1}", entryNo, serialNo);
                        obj = new ViewOutedWDRWs().GetEntryBySQL(sql);
                        if (obj.Tables.Count > 0 && obj.Tables[0].Rows.Count > 0)
                        {
                            this.txtKM4.Text = obj.Tables[0].Rows[0]["ReqReason"].ToString();
                        }
                    }
                    catch
                    {
               
                    }
                   
                    break;
            }
        }

        protected void btnEditItemKM_Click(object sender, EventArgs e)
        {
          
            entryNo = int.Parse(this.txtCurrentEntryNo.Text);
            serialNo = int.Parse(this.txtCurrentSerialNo.Text);

            sql = string.Format("Select * From ViewOutedWDRW Where EntryNo={0} And SerialNo={1}", entryNo, serialNo);
            this.CurrentViewOutedWDRW = new ViewOutedWDRWs().GetEntryBySQL(sql);
            obj = this.CurrentViewOutedWDRW;
            if (obj.Tables.Count > 0 && obj.Tables[0].Rows.Count > 0)
            {
                switch (obj.Tables[0].Rows[0]["KM1"].ToString())
                {
                    case "2241"://待审批项目		
                    case "1604"://已审批项目
                    case "1403"://低值易耗品
                    case "1221"://应收账款
                    case "5001"://生产成本
                        this.ddlKM3.Visible = false;
                        this.txtKM3.Visible = true;
                        this.ddlKM1.Enabled = false;
                        //this.ddlKM1.SelectedValue = obj.Tables[0].Rows[0]["KM1"].ToString();
                        this.txtKM2.Enabled = false;
                        this.txtKM3.Enabled = false;
                        this.txtKM3.Enabled = false;
                        this.txtKM2.Text = obj.Tables[0].Rows[0]["KM2"].ToString();
                        this.txtKM3.Text = obj.Tables[0].Rows[0]["KM3"].ToString();
                        //this.ddlKM3.SelectedValue = obj.Tables[0].Rows[0]["KM3"].ToString();
                        this.txtKM4.Text = obj.Tables[0].Rows[0]["KM4"].ToString();
                        break;
                    case "5101"://制造费用
                        this.ddlKM3.Visible = true;
                        this.txtKM3.Visible = false;
                        this.txtKM2.Enabled = false;
                        this.txtKM4.Enabled = false;
                        this.ddlKM1.Enabled = false;
                        this.ddlKM1.SelectedValue = obj.Tables[0].Rows[0]["KM1"].ToString();
                        this.txtKM2.Text = obj.Tables[0].Rows[0]["KM2"].ToString();
                        this.txtKM3.Text = obj.Tables[0].Rows[0]["KM3"].ToString();
                        this.ddlKM3.SelectedValue = obj.Tables[0].Rows[0]["KM3"].ToString();
                        this.txtKM4.Text = obj.Tables[0].Rows[0]["KM4"].ToString();
                        break;
                }

            }
        }

     

        protected void MzhDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.MyDataBind();
        }

        protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            MyDataBind();
        }

        protected void MzhDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[0].Text = string.Format("{0}{1}", e.Item.Cells[1].Text, e.Item.Cells[2].Text);
                e.Item.Attributes.Add("ondblclick", string.Format("EditItemKM({0},{1})", e.Item.Cells[1].Text, e.Item.Cells[2].Text));
            }
        }
    }
}
