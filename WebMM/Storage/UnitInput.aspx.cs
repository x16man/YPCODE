using System;
using System.Data;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class UnitInput : System.Web.UI.Page
	{

	    private UnitData ds = new UnitData();

	    private DataRow dr;

        private readonly ItemSystem oItemSystem = new ItemSystem();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Unit;
			
			if(!Page.IsPostBack)
			{
			    Master.SetTitleContent(this.Title);
				myBindData();
				DropDownList1.Items.FindByText(UnitTypeEnum.NULL).Selected=true;

				if(Master.Op !="New")
				{
					if (!Master.HasBrowseRight(SysRight.UnitMaintain))
					{
						return;
					}
					
					ds = (new ItemSystem()).QueryUnitByCode(int.Parse(Master.Code));
					//赋值
					dr=ds.Tables[UnitData.UNIT_TABLE].Rows[0];
					txtCode.Text=dr[UnitData.CODE_FIELD].ToString();
					txtDescription.Text=dr[UnitData.DESCRIPTION_FIELD].ToString();
					txtAbbreviate.Text=dr[UnitData.ABBREVIATE_FIELD].ToString();

					if (dr[UnitData.EQUIVALENCE_FIELD]!=DBNull.Value) txtEquivalence.Text=double.Parse(dr[UnitData.EQUIVALENCE_FIELD].ToString()).ToString("0.#########");
					if (dr[UnitData.CONVERSION_FIELD]!=DBNull.Value) txtConversion.Text=double.Parse(dr[UnitData.CONVERSION_FIELD].ToString()).ToString("0.#########");

					txtConUnit.Text=dr[UnitData.CONUNIT_FIELD].ToString();

					if(DropDownList1.Items.FindByText(dr[UnitData.UNITTYPE_FIELD].ToString())!=null)
					{
						DropDownList1.Items.FindByText(UnitTypeEnum.NULL).Selected=false;
						DropDownList1.Items.FindByText(dr[UnitData.UNITTYPE_FIELD].ToString()).Selected=true;
					}
					else
						DropDownList1.Items.FindByText(UnitTypeEnum.NULL).Selected=true;

					if(Master.Op == "Edit")	txtCode.Enabled=false;

                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.UnitMaintain))
					{
						return;
					}
				    this.toolbarButtonAdd.Visible = true;
				    this.toolbarButtonedit.Visible = false;
				}
			}
		}

		

		private void myBindData()
		{
			DropDownList1.Items.Add(UnitTypeEnum.LINEAR);
			DropDownList1.Items.Add(UnitTypeEnum.SQUARE);
			DropDownList1.Items.Add(UnitTypeEnum.WEIGHT);
			DropDownList1.Items.Add(UnitTypeEnum.CAPACITY);
			DropDownList1.Items.Add(UnitTypeEnum.NULL);
		}

        private void UnitSubmit()
        {
            
            dr = ds.Tables[UnitData.UNIT_TABLE].NewRow();

            dr[UnitData.CODE_FIELD] = txtCode.Text;
            dr[UnitData.DESCRIPTION_FIELD] = txtDescription.Text;
            dr[UnitData.ABBREVIATE_FIELD] = txtAbbreviate.Text;

            if (txtEquivalence.Text.Trim().Length != 0) dr[UnitData.EQUIVALENCE_FIELD] = decimal.Parse(txtEquivalence.Text.Trim());
            if (txtConversion.Text.Trim().Length != 0) dr[UnitData.CONVERSION_FIELD] = decimal.Parse(txtConversion.Text.Trim());

            if (txtConUnit.Text.Trim().Length != 0) dr[UnitData.CONUNIT_FIELD] = txtConUnit.Text.Trim();

            dr[UnitData.UNITTYPE_FIELD] = DropDownList1.SelectedItem.Text;

            ds.Tables[UnitData.UNIT_TABLE].Rows.Add(dr);

            

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasRight(SysRight.UnitMaintain))
                {
                    if (oItemSystem.EditUnit(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        Response.Redirect("UnitBrowser.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Common/NoRight.aspx");
                }
            }
            else
            {
                if (Master.HasRight(SysRight.UnitMaintain))
                {
                    if (oItemSystem.AddUnit(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        Response.Redirect("UnitBrowser.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Common/NoRight.aspx");
                }
            }
        }

		
	

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    UnitSubmit();
                    break;
                case "add":
                    UnitSubmit();
                    break;

            }
        }
	}
}
