namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		USWebControl ��ժҪ˵����
	/// </summary>
	public partial class USWebControl : System.Web.UI.UserControl
	{
		private Unit _width;
		private int _Flag;

		#region ����
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
		/// �Ƿ������õı�ǡ�
		/// </summary>
		public int Flag
		{
			get { return this._Flag;}
			set { this._Flag = value;}
		}
		#endregion

		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            txtUsing.Attributes.Add("ReadOnly", "ReadOnly");
			
			if (!this.IsPostBack)
			{
				this.btnSubmit.Visible = this.Disabled;
				
				if ( this.SelectedValue == "-1")
				{
					this.SelectedValue = "-1";
					this.SelectedText = "��";
				}
				
			}
		}

		


	}
}
