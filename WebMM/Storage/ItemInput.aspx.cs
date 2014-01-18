using System;
using System.Data;
using System.Web.UI.WebControls;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class ItemInput : System.Web.UI.Page
	{
        private ItemData ds = new ItemData();

	    private DataRow dr;

	    private string StoCode;

	    private string CatCode;

	    private string ItemCode;
        
        private ItemSystem oItemSystem=new ItemSystem();

	    private string DefStoCode;

	   

	    private string PrefixStr;

	    private string NewCode;

	    private Unit DropDownWidth
	    {
	        get
	        {
	            return new Unit("75%");
	        }
	    }

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Item;
			//设定下拉框宽度。

            ddlStorage.AutoPostBack = true;
            this.ddlABC.Width = DropDownWidth;
            this.ddlAccount.Width = DropDownWidth;
            this.ddlCategory.Width = DropDownWidth;
            this.ddlCheckReport.Width = DropDownWidth;
            this.ddlCon.Width = DropDownWidth;
            this.ddlItemState.Width = DropDownWidth;
            this.ddlProvider.Width = DropDownWidth;
            this.ddlPurMak.Width = DropDownWidth;
            this.ddlStorage.Width = DropDownWidth;
            this.ddlUnit.Width = DropDownWidth;

			
			if(!Page.IsPostBack)
			{
                Master.SetTitleContent(this.Title);
				if(Master.Op !="New")
				{
                    if (!Master.HasBrowseRight(SysRight.ItemMaintain))
                    {
                        return;
                    }

                    BindDataUpdate();
                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
                    if(Master.Op.ToLower() != "copy")
                    {
                        Button1.Visible = false;
                    }
                   
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.ItemMaintain))
                    {
                        return;
                    }

                    
					BindDataNew();
                    Button1.Visible = true;
                    this.toolbarButtonAdd.Visible = true;

                    this.toolbarButtonedit.Visible = false;
                  
				}
			}
		}

		

		private void BindDataNew()
		{
			//物料分类
			ddlCategory.Module_Tag= (int)SDDLTYPE.CATEGORY;
			//物料状态
			ddlItemState.Module_Tag=(int)SDDLTYPE.ITEMSTATE;
			//度量单位
			ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
			//制购属性
			ddlPurMak.Module_Tag=(int)SDDLTYPE.PURMAK;
			//检验报告
			ddlCheckReport.Module_Tag=(int)SDDLTYPE.CHECKREPORT;
			//ABC
			ddlABC.Module_Tag=(int)SDDLTYPE.ABC;
			//记帐方式
			ddlAccount.Module_Tag=(int)SDDLTYPE.ACCOUNT;
			//仓库
			ddlStorage.Module_Tag=(int)SDDLTYPE.STORAGE;
			//常规供应商
			ddlProvider.Module_Tag=(int)SDDLTYPE.VENDOR;
			//价位
			ddlCon.Module_Tag=(int)SDDLTYPE.CONTAINER;
		}

		private void BindDataUpdate()
		{
			
			ds = (new ItemSystem()).GetItemByCode(Master.Code);
			//赋值
		    dr=ds.Tables[ItemData.ITEM_TABLE].Rows[0];


			txtCode.Text=dr[ItemData.CODE_FIELD].ToString();
		    txtNewCode.Text = dr[ItemData.NEWCODE_FIELD].ToString();
			txtCnName.Text=dr[ItemData.CNNAME_FIELD].ToString();
			if (dr[ItemData.ENNAME_FIELD]!=DBNull.Value) txtEnName.Text=dr[ItemData.ENNAME_FIELD].ToString();
			//物料分类
			ddlCategory.SelectedValue=dr[ItemData.CATCODE_FIELD].ToString();
			ddlCategory.Module_Tag= (int)SDDLTYPE.CATEGORY;
			//物料状态
			ddlItemState.SelectedValue=dr[ItemData.STATE_FIELD].ToString();
			ddlItemState.Module_Tag=(int)SDDLTYPE.ITEMSTATE;

			if (dr[ItemData.SPECIAL_FIELD]!=DBNull.Value) txtSpecial.Text=dr[ItemData.SPECIAL_FIELD].ToString();
			//物料状态
			ddlItemState.SelectedValue=dr[ItemData.STATE_FIELD].ToString();
			ddlItemState.Module_Tag=(int)SDDLTYPE.ITEMSTATE;
			//度量单位
			ddlUnit.SelectedValue=dr[ItemData.UNITCODE_FIELD].ToString();
			ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;

			//制购属性
			ddlPurMak.SelectedValue=dr[ItemData.PURMAK_FIELD].ToString();
			ddlPurMak.Module_Tag=(int)SDDLTYPE.PURMAK;
					
			if (dr[ItemData.BATCH_FIELD].ToString()=="Y") 
				rblBatch.SelectedIndex=0;
			else
				rblBatch.SelectedIndex=1;

			if (dr[ItemData.CHECKED_FIELD].ToString()=="Y") 
				rblCheck.SelectedIndex=0;
			else
				rblCheck.SelectedIndex=1;

			//检验报告
			ddlCheckReport.SelectedValue=dr[ItemData.CHKRPTCODE_FIELD].ToString();
			ddlCheckReport.Module_Tag=(int)SDDLTYPE.CHECKREPORT;

			//ABC
			ddlABC.SelectedValue=dr[ItemData.ABC_FIELD].ToString();
			ddlABC.Module_Tag=(int)SDDLTYPE.ABC;

			if (dr[ItemData.CSTPRICE_FIELD]!=DBNull.Value) txtCstPrice.Text=double.Parse(dr[ItemData.CSTPRICE_FIELD].ToString()).ToString("0.#########");
			if (dr[ItemData.EVAPRICE_FIELD]!=DBNull.Value) txtEvPrice.Text=double.Parse(dr[ItemData.EVAPRICE_FIELD].ToString()).ToString("0.#########");
			if (dr[ItemData.UPPNUM_FIELD]!=DBNull.Value) txtUppNum.Text=double.Parse(dr[ItemData.UPPNUM_FIELD].ToString()).ToString("0.#########");
			if (dr[ItemData.LOWNUM_FIELD]!=DBNull.Value) txtLowNum.Text=double.Parse(dr[ItemData.LOWNUM_FIELD].ToString()).ToString("0.#########");
			if (dr[ItemData.SAFNUM_FIELD]!=DBNull.Value) txtSafNum.Text=double.Parse(dr[ItemData.SAFNUM_FIELD].ToString()).ToString("0.#########");
			if (dr[ItemData.ORDNUM_FIELD]!=DBNull.Value) txtOrdNum.Text=double.Parse(dr[ItemData.ORDNUM_FIELD].ToString()).ToString("0.#########");
			if (dr[ItemData.ORDBAT_FIELD]!=DBNull.Value) txtBatch.Text=double.Parse(dr[ItemData.ORDBAT_FIELD].ToString()).ToString("0.#########");

			//记帐方式
			ddlAccount.SelectedValue=dr[ItemData.ACCTYPE_FIELD].ToString();
			ddlAccount.Module_Tag=(int)SDDLTYPE.ACCOUNT;
			//仓库
			ddlStorage.SelectedValue=dr[ItemData.DEFSTO_FIELD].ToString();
			ddlStorage.Module_Tag=(int)SDDLTYPE.STORAGE;

			//常规供应商
			ddlProvider.SelectedValue=dr[ItemData.PRVCODE_FIELD].ToString();
			ddlProvider.Module_Tag=(int)SDDLTYPE.VENDOR;

			//价位
			ddlCon.SelectedValue=dr[ItemData.DEFCON_FIELD].ToString();
			ddlCon.StoCode=dr[ItemData.DEFSTO_FIELD].ToString();
			ddlCon.Module_Tag=(int)SDDLTYPE.CONTAINER;

			if(Master.Op =="Edit")	txtCode.Enabled=false;
		}

		private void ConBindData(string stoCode)
		{
			//架位
			this.ddlCon.StoCode=stoCode;
			this.ddlCon.Module_Tag=(int)SDDLTYPE.CONTAINER;
			this.ddlCon.IsClear = true;
			this.ddlCon.SetDDL();
		}

        private void ItemSubmit()
        {
            ds = new ItemData();
            dr = ds.Tables[ItemData.ITEM_TABLE].NewRow();

            dr[ItemData.CODE_FIELD] = txtCode.Text;
            dr[ItemData.NEWCODE_FIELD] = string.IsNullOrEmpty(txtNewCode.Text) ? DBNull.Value : (object)txtNewCode.Text;
            dr[ItemData.CNNAME_FIELD] = txtCnName.Text;
            if (txtEnName.Text.Trim().Length != 0) dr[ItemData.ENNAME_FIELD] = txtEnName.Text.Trim();
            dr[ItemData.CATCODE_FIELD] = ddlCategory.SelectedValue;
            dr[ItemData.STATE_FIELD] = ddlItemState.SelectedValue;
            if (txtSpecial.Text.Trim().Length != 0) dr[ItemData.SPECIAL_FIELD] = txtSpecial.Text.Trim();
            dr[ItemData.UNITCODE_FIELD] = ddlUnit.SelectedValue;
            dr[ItemData.PURMAK_FIELD] = ddlPurMak.SelectedValue;
            dr[ItemData.BATCH_FIELD] = rblBatch.SelectedItem.Value;
            dr[ItemData.CHECKED_FIELD] = rblCheck.SelectedItem.Value;
            dr[ItemData.CHKRPTCODE_FIELD] = ddlCheckReport.SelectedValue;
            dr[ItemData.ABC_FIELD] = ddlABC.SelectedValue;
            if (txtCstPrice.Text.Trim().Length != 0) dr[ItemData.CSTPRICE_FIELD] = decimal.Parse(txtCstPrice.Text.Trim());
            if (txtEvPrice.Text.Trim().Length != 0) dr[ItemData.EVAPRICE_FIELD] = decimal.Parse(txtEvPrice.Text.Trim());
            dr[ItemData.ACCTYPE_FIELD] = ddlAccount.SelectedValue;
            if (txtUppNum.Text.Trim().Length != 0) dr[ItemData.UPPNUM_FIELD] = decimal.Parse(txtUppNum.Text.Trim());
            if (txtLowNum.Text.Trim().Length != 0) dr[ItemData.LOWNUM_FIELD] = decimal.Parse(txtLowNum.Text.Trim());
            if (txtSafNum.Text.Trim().Length != 0) dr[ItemData.SAFNUM_FIELD] = decimal.Parse(txtSafNum.Text.Trim());
            if (txtBatch.Text.Trim().Length != 0) dr[ItemData.ORDBAT_FIELD] = decimal.Parse(txtBatch.Text.Trim());
            if (txtOrdNum.Text.Trim().Length != 0) dr[ItemData.ORDNUM_FIELD] = decimal.Parse(txtOrdNum.Text.Trim());
            dr[ItemData.PRVCODE_FIELD] = ddlProvider.SelectedValue;
            dr[ItemData.DEFSTO_FIELD] = ddlStorage.SelectedValue;
            if (!string.IsNullOrEmpty(this.ddlCon.SelectedValue))
            {
                 dr[ItemData.DEFCON_FIELD] = ddlCon.SelectedValue;
            }


            ItemCode = this.txtCode.Text;
            StoCode = this.ddlStorage.SelectedValue;
            CatCode = this.ddlCategory.SelectedValue;
            if (CatCode.Length == 1)
            {
                CatCode = '0' + CatCode;
            }

            
                if (ItemCode.Substring(0, 2) != StoCode || ItemCode.Substring(2, 2) != CatCode)
                {
                    if (Master.Op != "Edit")
                    {
                        this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=物料编号不符合规则！");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('物料编号不符合规则');", true);
                        
                    }
                }
           
            

            ds.Tables[ItemData.ITEM_TABLE].Rows.Add(dr);

            oItemSystem = new ItemSystem();

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasRight(SysRight.ItemMaintain))
                {
                    if (oItemSystem.EditItem(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }

            }
            else
            {
                if (Master.HasRight(SysRight.ItemMaintain))
                {
                    if (oItemSystem.AddItem(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }

                }
            }
            Response.Redirect("ItemBrowser.aspx");
        }

		

		
		protected override bool OnBubbleEvent(object Sender,EventArgs e)
		{
			try
			{
				if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == ddlStorage.thisDDL.ClientID)
				{
				    this.ddlCon.IsClear = true;
					this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
					this.ddlCon.StoCode = this.ddlStorage.SelectedValue;
					this.ddlCon.SetDDL();
				}
			}
			catch
			{}
			return true;
		}

		/// <summary>
		/// 推荐编号。
		/// </summary>
		protected void Button1_Click(object sender, System.EventArgs e)
		{

		    PrefixStr = "";
		    NewCode = "";
			CatCode = this.ddlCategory.SelectedValue;
			DefStoCode = this.ddlStorage.SelectedValue;
			if (CatCode != "-1" && DefStoCode != "-1")
			{
				if (CatCode.Length == 1)
				{
					CatCode = "0"+CatCode;
				}
				PrefixStr = DefStoCode + CatCode;
				//TODO:推荐编号。
				NewCode = new ItemSystem().GetItemRecommandCode(PrefixStr);
				this.txtCode.Text = NewCode;
			}
			else
			{
				ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('请先设好分类和仓库')", true);
			}
		}

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    ItemSubmit();
                    break;
                case "add":
                    ItemSubmit();
                    break;

            }
            
        }
	}
}
