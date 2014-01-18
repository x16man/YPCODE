using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.DataAccess.Storage;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.MM.Common.Storage;

namespace WebMM.Storage
{
    public partial class InventoryList : System.Web.UI.Page
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
        #endregion

        #region Method
        private void myDataBind()
        {
            var objs = new Inventorys().GetAll();
            objs.Sort((x,y)=>y.Date.CompareTo(x.Date));
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
            if(!IsPostBack)
            {
                this.myDataBind();
            }
            this.DataGrid1.AutoDataBind = this.myDataBind;
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            if(item.ItemId == "Delete")
            {
                var id = int.Parse(this.DataGrid1.SelectedID);
                using (var conn = new SqlConnection(ConnectionString.MM))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction();
                    if(new InventoryDetails().Delete(trans,id))
                    {
                        if(new Inventorys().Delete(trans, id))
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
                this.myDataBind();
            }
        }
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var obj = e.Item.DataItem as InventoryInfo;
                var url = string.Format("{0}&rs:Command=Render&rc:Parameters=false&Id={1}", ConfigurationManager.AppSettings["InventoryReportUrl"], obj.Id);
                e.Item.Attributes.Add("ondblclick", "window.open('"+url+"','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=yes,location=no, status=no')");
            }
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }
    }
}
