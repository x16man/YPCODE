using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using Shmzh.Components.SystemComponent;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class YCLInput : Page
	{
		#region 成员变量


		private string op = "New";
		private int _PKID;
		//protected User myUser;
		//protected string AlertMessage = "<script>alert(\"" + SysRight.NoRight + "\");</script>";
		private ItemSystem oItemSystem = new ItemSystem();

        YCLData ds = new YCLData();
	    private DataRow dr;

	    private ItemData obj;

    

		#endregion
		/// <summary>
		/// 物料下拉列表的数据绑定.
		/// </summary>
		private void ddlDataBind()
		{
			obj = this.oItemSystem.GetItemsByCatCode(1);
			this.DropDownList1.Items.Clear();
			this.DropDownList2.Items.Clear();
			this.DropDownList3.Items.Clear();
			this.DropDownList4.Items.Clear();
			this.DropDownList5.Items.Clear();
			this.DropDownList6.Items.Clear();
			foreach (DataRow oRow in obj.Tables[0].Rows)
			{
				//ListItem oItem = new ListItem(oRow["CNName"].ToString(),oRow["Code"].ToString());
				this.DropDownList1.Items.Add(new ListItem(oRow["CNName"].ToString(), oRow["Code"].ToString()));
				this.DropDownList2.Items.Add(new ListItem(oRow["CNName"].ToString(), oRow["Code"].ToString()));
				this.DropDownList3.Items.Add(new ListItem(oRow["CNName"].ToString(), oRow["Code"].ToString()));
				this.DropDownList4.Items.Add(new ListItem(oRow["CNName"].ToString(), oRow["Code"].ToString()));
				this.DropDownList5.Items.Add(new ListItem(oRow["CNName"].ToString(), oRow["Code"].ToString()));
				this.DropDownList6.Items.Add(new ListItem(oRow["CNName"].ToString(), oRow["Code"].ToString()));
			}
		}

		/// <summary>
		/// 页面加载事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				op = Request["Op"];
			}
			if (!string.IsNullOrEmpty(Request["PKID"]))
			{
				_PKID = int.Parse(Request["PKID"]);
			}
		

			//this.ddlVendor.Module_Tag = (int)SDDLTYPE.VENDOR;
			if (!Page.IsPostBack)
			{
				this.ddlDataBind();
				if (op != "New") //编辑。
				{
					
					ds = this.oItemSystem.GetYCLByPKID(_PKID);
					//赋值
					dr = ds.Tables[YCLData.YCL_Table].Rows[0];
					//this.Datechooser1.SelectedDate = (Convert.ToDateTime(dr[YCLData.OpDate_Field].ToString())).ToShortDateString();
					this.txtDate.Text = (Convert.ToDateTime(dr[YCLData.OpDate_Field].ToString())).ToString("yyyy-MM-dd");
					try
					{
						this.txtInVolumn1.Text = dr[YCLData.InVolNum_Field].ToString();
					}
					catch
					{
					}
					try
					{
						this.txtInNum1.Text = dr[YCLData.InItemNum_Field].ToString();
					}
					catch
					{
					}
					try
					{
						this.txtOutVolumn1.Text = dr[YCLData.OutVolNum_Field].ToString();
					}
					catch
					{
					}
					try
					{
						this.txtOutNum1.Text = dr[YCLData.OutItemNum_Field].ToString();
					}
					catch
					{
					}
					this.DropDownList1.SelectedValue = dr[YCLData.ItemCode_Field].ToString();
					//this.Datechooser1.SelectedDate = (Convert.ToDateTime(dr[YCLData.OpDate_Field].ToString())).ToShortDateString();
					this.txtDate.Text = (Convert.ToDateTime(dr[YCLData.OpDate_Field].ToString())).ToString("yyyy-MM-dd");
				}
				else //增加。
				{
					//this.Datechooser1.SelectedDate = DateTime.Now.ToShortDateString();
					this.txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

					this.DropDownList1.SelectedIndex = 0;
					this.DropDownList2.SelectedIndex = 1;
					this.DropDownList3.SelectedIndex = 2;
					this.DropDownList4.SelectedIndex = 3;
					this.DropDownList5.SelectedIndex = 4;
					this.DropDownList6.SelectedIndex = 5;
				}
			}
		}

		#region Web 窗体设计器生成的代码

		protected override void OnInit(EventArgs e)
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
			this.Load += new EventHandler(this.Page_Load);
		}

		#endregion

		private bool InsertData()
		{
           

			//第一项物料。
			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList1.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList1.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
				dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn1.Text);
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum1.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn1.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum1.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			if (decimal.Parse(dr[YCLData.InVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.InItemNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutItemNum_Field].ToString()) != 0)
			{
				ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
				if (oItemSystem.AddYCL(ds) == false) return false;
			}
			//第二项物料。
			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList2.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList2.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
				dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn2.Text);
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum2.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn2.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum2.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			if (decimal.Parse(dr[YCLData.InVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.InItemNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutItemNum_Field].ToString()) != 0)
			{
				ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
				if (oItemSystem.AddYCL(ds) == false) return false;
			}
			//第三项物料。
			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList3.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList3.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
				dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn3.Text);
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum3.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn3.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum3.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			if (decimal.Parse(dr[YCLData.InVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.InItemNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutItemNum_Field].ToString()) != 0)
			{
				ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
				if (oItemSystem.AddYCL(ds) == false) return false;
			}
			//第四项物料。
			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList4.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList4.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
				dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn4.Text);
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum4.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn4.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum4.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			if (decimal.Parse(dr[YCLData.InVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.InItemNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutItemNum_Field].ToString()) != 0)
			{
				ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
				if (oItemSystem.AddYCL(ds) == false) return false;
			}
			//第五项物料。
			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList5.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList5.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
				dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn5.Text);
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum5.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn5.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum5.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			if (decimal.Parse(dr[YCLData.InVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.InItemNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutItemNum_Field].ToString()) != 0)
			{
				ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
				if (oItemSystem.AddYCL(ds) == false) return false;
			}
			//第六项物料。
			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList6.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList6.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
				dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn6.Text);
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum6.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn6.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum6.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			if (decimal.Parse(dr[YCLData.InVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.InItemNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutVolNum_Field].ToString()) != 0 ||
			    decimal.Parse(dr[YCLData.OutItemNum_Field].ToString()) != 0)
			{
				ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
				if (oItemSystem.AddYCL(ds) == false)
					return false;
				else
					return true;
			}
			return true;
		}

		private bool UpdateData()
		{
           

			ds = new YCLData();
			dr = ds.Tables[YCLData.YCL_Table].NewRow();
			dr[YCLData.PKID_Field] = this._PKID;
			dr[YCLData.ItemCode_Field] = this.DropDownList1.SelectedValue;
			dr[YCLData.ItemName_Field] = this.DropDownList1.SelectedItem.Text;
			//dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.Datechooser1.SelectedDate);
            try
            {
                dr[YCLData.OpDate_Field] = Convert.ToDateTime(this.txtDate.Text);
            }
            catch { }
			try
			{
                dr[YCLData.InVolNum_Field] = Convert.ToDecimal(this.txtInVolumn1.Text) ;
			}
			catch
			{
				dr[YCLData.InVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.InItemNum_Field] = Convert.ToDecimal(this.txtInNum1.Text);
			}
			catch
			{
				dr[YCLData.InItemNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(this.txtOutVolumn1.Text);
			}
			catch
			{
				dr[YCLData.OutVolNum_Field] = 0;
			}
			try
			{
				dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(this.txtOutNum1.Text);
			}
			catch
			{
				dr[YCLData.OutItemNum_Field] = 0;
			}
			ds.Tables[YCLData.YCL_Table].Rows.Add(dr);
			if (oItemSystem.UpdateYCL(ds) == false)
				return false;
			else
				return true;
		}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (op == "Edit")
            {
                if (txtDate.Text == "")
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('日期不能为空!');", true);
                    return;
                }

                if (this.UpdateData() == false)
                {
                    Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + this.oItemSystem.Message);
                }
            }
            else
            {
                if (txtDate.Text == "")
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('日期不能为空!');", true);
                    return;
                }

                if (this.InsertData() == false)
                {
                    Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + this.oItemSystem.Message);
                }
            }
            Response.Redirect("YCLGroupBrowser.aspx", true);
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("YCLGroupBrowser.aspx", true);
        }

		

       

       
	}
}