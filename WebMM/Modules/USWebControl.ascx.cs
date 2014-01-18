namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		USWebControl 的摘要说明。
	/// </summary>
	public partial class USWebControl : System.Web.UI.UserControl
	{
		private Unit _width;
		private int _Flag;

		#region 属性
		public Unit Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}
		public string SelectedText
		{
			get
			{
				return this.txtUsing.Text;
			}
			set
			{
				this.txtUsing.Text = value;
			}
		}
		public string SelectedValue
		{
			get
			{
				return this.txtUsingCode.Value;
			}
			set
			{
				this.txtUsingCode.Value = value;
			}
		}
        public bool Disabled
        {
            get
            {
                return this.btnSubmit.Visible;
                //return this._disabled;
            }
            set
            {
                this.btnSubmit.Visible = value;
                //this._disabled = value;
            }

        }

		/// <summary>
		/// 是否申请用的标记。
		/// </summary>
		public int Flag
		{
			get { return this._Flag;}
			set { this._Flag = value;}
		}
		#endregion

		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            txtUsing.Attributes.Add("ReadOnly", "ReadOnly");
			
			if (!this.IsPostBack)
			{
				this.btnSubmit.Visible = this.Disabled;
				
				if ( this.SelectedValue == "-1")
				{
					this.SelectedValue = "-1";
					this.SelectedText = "空";
				}
				
			}
		}

		


	}
}
