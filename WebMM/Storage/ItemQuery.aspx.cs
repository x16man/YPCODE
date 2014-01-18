using System;
using System.Web.UI.WebControls;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using MZHMM.WebMM.Modules;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// ItemQuery 的摘要说明。
	/// </summary>
	public partial class ItemQuery : System.Web.UI.Page
	{
		#region 成员变量
		protected StorageDropdownlist ddlCategory = new StorageDropdownlist();
		protected StorageDropdownlist ddlClass = new StorageDropdownlist();
		//protected DGModel_ItemQuery dgItemQuery;
		private ItemData oItemData = new ItemData();
		private ItemSystem oItemSystem = new ItemSystem();
		private int CatCode;
		private string Content;
		private string Class;

		#endregion

		#region 属性
		/// <summary>
		/// 单据类型。
		/// </summary>
		public int DocCode 
		{
			get {return int.Parse(this.Request["DocCode"]);}
		}


        private string Operatype
        {
            get
            {
                if (ViewState["Operatype"] != null)
                    return ViewState["Operatype"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["Operatype"] = value;
            }
        }

		#endregion

        #region Method
        private void BindData()
        {
            //分类选中。
            if (this.chkCategory.Checked && !this.chkContent.Checked)
            {
                CatCode = int.Parse(this.ddlCategory.SelectedValue);
                oItemData = oItemSystem.GetItemsByCatCode(CatCode);
                this.dgItemQuery.DataSource = oItemData.Tables[ItemData.ITEM_TABLE];
                this.dgItemQuery.DataBind();
            }
            //内容项选中。
            if (!this.chkCategory.Checked && this.chkContent.Checked && this.txtContent.Text.Length > 0)
            {
                Content = this.txtContent.Text.Trim();
                Class = this.ddlClass.SelectedValue;

                switch (Class)
                {
                    case "NEWCODE":
                        oItemData = oItemSystem.GetItemsByNewCode(Content);
                        break;
                    case "CODE":
                        oItemData = oItemSystem.GetItemsByCode(Content);
                        break;
                    case "NAME":
                        oItemData = oItemSystem.GetItemsByName(Content);
                        break;
                    case "PY":
                        oItemData = oItemSystem.GetItemsByPY(Content);
                        break;
                    case "SPEC":
                        oItemData = oItemSystem.GetItemsBySpec(Content);
                        break;
                    case "ALL":
                        oItemData = oItemSystem.GetItemsByCodeAndNameAndSpec(Content);
                        break;
                }
                this.dgItemQuery.DataSource = oItemData.Tables[ItemData.ITEM_TABLE];
                this.dgItemQuery.DataBind();
            }
            //使用频次的物料项(缺省的查询模式。).
            if (!this.chkCategory.Checked && this.chkContent.Checked && this.txtContent.Text.Length == 0)
            {
                oItemData = oItemSystem.GetItemByUseCount();
                this.dgItemQuery.DataSource = oItemData.Tables[ItemData.ITEM_TABLE];
                this.dgItemQuery.DataBind();
            }
        }
        #endregion

        #region 事件
        /// <summary>
		/// 页面加载事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.ddlCategory.Width = new Unit("100%");
			this.ddlClass.Width = new Unit("100%");
			this.txtContent.Width = new Unit("100%");
			if(!Page.IsPostBack)
			{				
				this.ddlCategory.Module_Tag= (int)SDDLTYPE.ACAT;
				this.ddlClass.Module_Tag = (int)SDDLTYPE.ITEMQUERY;
				oItemData = oItemSystem.GetItemByUseCount();
				this.dgItemQuery.DataSource = oItemData.Tables[ItemData.ITEM_TABLE];
				this.dgItemQuery.DataBind();
				if (this.Request["DocCode"] != null && this.Request["DocCode"]!=string.Empty)
				{
					if (this.DocCode !=1 && this.DocCode != 2)
					{
						this.btnItemRequire.Visible = false;
					}
				}
				else
				{
					this.btnItemRequire.Visible = false;
				}
                BindData();
			}
		    this.dgItemQuery.AutoDataBind = this.BindData;
		}

        protected void btnItemRequire_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("WITRBrowser.aspx?OP=New&DocCode=" + this.DocCode.ToString());
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
          
            this.dgItemQuery.CurrentPageIndex = 0;
            Operatype = "query";
            BindData();
           
        }

        protected void dgItemQuery_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if(!Master.HasRight(Common.SysRight.QueryCstPrice))
                    e.Item.Cells[7].Text = "";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.opener.setCode(this.id);window.close();");
               
                if (!Master.HasRight(Common.SysRight.QueryCstPrice))
                    e.Item.Cells[7].Text = "";
            }
        }
#endregion
	}
}
