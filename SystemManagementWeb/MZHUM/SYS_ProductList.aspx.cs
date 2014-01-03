using System;
using System.Collections;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_ProductList ��ժҪ˵����
	/// </summary>
	public partial class SYS_ProductList : BasePage
    {
        #region Field
        /// <summary>
        /// ɾ��ʧ�����ѽű���
        /// </summary>
        private static readonly string DELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("ProductDeleteFailed"));
        #endregion

        #region Propetry
        /// <summary>
		/// ��Ʒ������ͼ��
		/// </summary>
		protected ArrayList Products
		{
			get {return this.Session["Products"] as ArrayList;}
			set {this.Session["Products"] = value;}
		}
		#endregion

		#region private method
		/// <summary>
		/// ���ݰ󶨡�
		/// </summary>
		private void myDataBind()
		{
		    var objs = DataProvider.ProductProvider.GetAll();
		    this.dg_Product.DataSource = objs;
			this.dg_Product.DataBind();
		}
		#endregion
        
		#region Event
		/// <summary>
		/// ҳ������¼���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if(CurrentUser.HasRight(RightEnum.ProductView))
				{
					this.myDataBind();
					if (!CurrentUser.HasRight(RightEnum.ProductMaintain))
					{
						this.toolbarItemAdd.Visible = false;
						this.toolbarItemEdit.Visible = false;
						this.toolbarItemDelete.Visible = false;
					}
				}
				else
				{
					this.SetNoRightInfo(true);
				}
			}
		    this.dg_Product.AutoDataBind = myDataBind;
		}
		/// <summary>
		/// �˵��������¼���
		/// </summary>
		/// <param name="item"></param>
		protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
		{
			switch(item.ItemId.ToUpper())
			{
				case "DELETE":
			        if (this.dg_Product.SelectedID.Length > 0)
			        {
			            if (DataProvider.ProductProvider.Delete(short.Parse(this.dg_Product.SelectedID)))
			            {
			                this.myDataBind();
			            }
			            else
			            {
			                AddScript(DELETEFAILED_SCRIPT);
			            }
			        }
			        break;
			}
		}
		/// <summary>
		/// ˢ�°�ť�¼���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }
        #endregion
    }
}
