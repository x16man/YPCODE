using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common.Storage;
using Shmzh.MM.DataAccess.Storage;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using Shmzh.Components.SystemComponent;

namespace WebMM.Storage
{
    public partial class Inventory : BasePage
    {
        #region method
        /// <summary>
        /// 绑定仓库的下拉列表。
        /// </summary>
        private void BindStorage()
        {
            this.ddlSto.Items.Clear();
            var objs = new ItemSystem().GetStoAll();

            for (var i = 0; i < objs.Tables[StoData.STO_TABLE].Rows.Count; i++)
            {
                var item = new ListItem(objs.Tables[StoData.STO_TABLE].Rows[i][StoData.DESCRIPTION_FIELD].ToString(), objs.Tables[StoData.STO_TABLE].Rows[i][StoData.CODE_FIELD].ToString());
                this.ddlSto.Items.Add(item);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.BindStorage();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var obj = new InventoryInfo();
            obj.Name = this.txtName.Text;
            obj.StoCode = this.ddlSto.SelectedValue;
            obj.Remark = this.txtRemark.Text;
            obj.UserId = this.CurrentUser.thisUserInfo.PKID;
            obj.Date = DateTime.Now;

            using(var conn = new SqlConnection(ConnectionString.MM))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                if(new Inventorys().Insert(trans, obj) > 0)
                {
                    if(new InventoryDetails().CopyFromCurrentStock(trans, obj.Id))
                    {
                        trans.Commit();
                        this.ClientScript.RegisterStartupScript(this.GetType(),"close","window.opener.refresh();window.close();",true);
                    }
                    else
                    {
                        trans.Rollback();
                        this.ClientScript.RegisterStartupScript(this.GetType(),"error","alert('保存失败！');",true);
                    }
                }
                else
                {
                    trans.Rollback();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('保存失败！');", true);
                }
            }
        }
    }
}
