using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.DataAccess.Common;
using Shmzh.MM.DataAccess.Storage;
using Shmzh.MM.Common;
using MZHMM.WebMM.Common;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.MM.Common.Storage;
using System.Drawing;

namespace WebMM.Storage
{
    public partial class InventoryProfitList : System.Web.UI.Page
    {
        #region Property
        public Shmzh.Components.SystemComponent.User CurrentUser
        {
            get { return Session["User"] as Shmzh.Components.SystemComponent.User; }
        }
        public ListBase<UserInfo> AllUsers
        {
            get
            {
                if(Session["AllUsers"] == null)
                {
                    Session["AllUsers"] = DataProvider.UserProvider.GetAllByCompany(this.CurrentUser.Company);
                }
                return Session["AllUsers"] as ListBase<UserInfo>;
            }
        }

        public List<ESTUInfo> ESTUs
        {
            get { return Session["ESTUs"] as List<ESTUInfo>; }
            set { Session["ESTUs"] = value; }
        }
        #endregion

        #region Method
        protected string GetEntryStateName(string entryState)
        {
            return this.ESTUs.Find(item => item.Code == entryState).Description;
        }
        private void myDataBind()
        {
            var objs = new InventoryProfits().GetAll();
            objs.Sort((x,y)=>y.EntryNo.CompareTo(x.EntryNo));
            this.DataGrid1.DataSource = objs;
            this.DataGrid1.DataBind();
        }
        protected string GetAuthorName(int userId)
        {
            var obj = this.AllUsers.Find(item => item.PKID == userId);
            return obj == null ? string.Empty : obj.EmpName;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ESTUs = new ESTUs().GetAll();
            if(!IsPostBack)
            {
                #region Check Right
                if(!CurrentUser.HasRight(SysRight.InventoryProfitMaintain))
                {
                    this.toolbarButtonadd.Visible = false;
                    this.toolbarButtonedit.Visible = false;
                    this.toolbarButtoncancel.Visible = false;
                    this.toolbarButtonPresent.Visible = false;
                    this.toolbarButtondelete.Visible = false;
                    this.toolbarButtonRed.Visible = false;
                }
                if (!CurrentUser.HasRight(SysRight.InventoryProfitFirstAudit))
                {
                    this.toolbarButtonFirstAudit.Visible = false;
                }
                if(!CurrentUser.HasRight(SysRight.InventoryProfitSecondAudit))
                {
                    this.toolbarButtonSecondAudit.Visible = false;
                }
                if(!CurrentUser.HasRight(SysRight.InventoryProfitThirdAudit))
                {
                    this.toolbarButtonThirdAudit.Visible = false;
                }
                if(!CurrentUser.HasRight(SysRight.StockIn))
                {
                    this.toolbarButtonReceive.Visible = false;
                }
                #endregion
                this.myDataBind();
            }
            this.DataGrid1.AutoDataBind = this.myDataBind;
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            var da = new InventoryProfits();
            var da1 = new InventoryProfitDetails();
            var entryNo = int.Parse(this.DataGrid1.SelectedID);
            var obj = da.GetById(entryNo);
            if(obj != null)
            {
                if (item.ItemId.ToUpper() == "DELETE")
                {
                    if(obj.EntryState == DocStatus.Cancel)
                    {
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (da1.Delete(trans, entryNo) && da.Delete(trans, entryNo))
                            {
                                trans.Commit();
                            }
                            else
                            {
                                trans.Rollback();
                            }
                        }
                        this.myDataBind();
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(),"IncorrectStatus",string.Format("alert(\"{0}\");","选中单据的状态不允许删除！"),true);
                    }
                }
                else if(item.ItemId.ToUpper() == "CANCEL")
                {
                    if(obj.EntryState==DocStatus.New||obj.EntryState==DocStatus.FstNoPass || obj.EntryState==DocStatus.SecNoPass||obj.EntryState==DocStatus.TrdNoPass)
                    {
                        obj.EntryState = DocStatus.Cancel;
                        obj.CancelDate = DateTime.Now;
                        using(var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (da.Update(trans, obj) && new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans,19,obj.EntryNo,1083,"T",CurrentUser.LoginName))
                            {
                                trans.Commit();
                                this.myDataBind();
                            }
                            else
                            {
                                trans.Rollback();
                                this.ClientScript.RegisterStartupScript(this.GetType(), "CancelFailed", string.Format("alert(\"{0}\");", "单据作废失败！"), true);
                            }
                        }
                        
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectStatus", string.Format("alert(\"{0}\");", "选中单据的状态不允许删除！"), true);
                    }
                }
                else if(item.ItemId.ToUpper()=="PRESENT")
                {
                    if (obj.EntryState == DocStatus.New || obj.EntryState == DocStatus.FstNoPass || obj.EntryState == DocStatus.SecNoPass || obj.EntryState == DocStatus.TrdNoPass)
                    {
                        obj.EntryState = DocStatus.Present;
                        obj.PresentDate = DateTime.Now;
                        using(var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (da.Update(trans, obj) && new DataAccess.Common.ToDoLists().Create(trans, 19,obj.EntryNo,1040,"T",CurrentUser.LoginName))
                            {
                                trans.Commit();
                                this.ClientScript.RegisterStartupScript(this.GetType(), "PresentSuccessful", string.Format("alert(\"{0}\");", "单据提交成功！"), true);
                                this.myDataBind();
                            }
                            else
                            {
                                trans.Rollback();
                                this.ClientScript.RegisterStartupScript(this.GetType(), "PresentFailed", string.Format("alert(\"{0}\");", "单据提交失败！"), true);
                            }
                        }
                        
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectStatus", string.Format("alert(\"{0}\");", "选中单据的状态不允许提交！"), true);
                    }
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "None", string.Format("alert(\"{0}\");", "没有找到该单据！"), true);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var obj = e.Item.DataItem as InventoryProfitInfo;
                if (obj != null && obj.ParentEntryNo != 0)
                {
                    e.Item.Cells[0].ForeColor = Color.Red;
                    e.Item.Cells[1].Text += "  冲 " + obj.ParentEntryNo.ToString();
                }
                e.Item.Attributes.Add("ondblclick", "window.open('InventoryProfitInput.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=yes,location=no, status=no')");

            }
        }

        
    }
}
