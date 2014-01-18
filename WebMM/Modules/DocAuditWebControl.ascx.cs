namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;

	/// <summary>
	///		DocAuditWebControl 的摘要说明。
	/// </summary>
	public partial class DocAuditWebControl : System.Web.UI.UserControl
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    private int _docCode = 0;

	    private int _auditLevel = 0;

	    private int auditLevel;
	    private string _OP;

        private BillOfDocumentData oBOD = new BillOfDocumentData();

		#region 属性
	    public string AuditName1
	    {
            get { return this.lblAuditName1.Text; }
            set { this.lblAuditName1.Text = value; }
	    }
        public string AuditName2
        {
            get { return this.lblAuditName2.Text; }
            set { this.lblAuditName2.Text = value; }
        }
        public string AuditName3
        {
            get { return this.lblAuditName3.Text; }
            set { this.lblAuditName3.Text = value; }
        }
        public string AuditName4
        {
            get { return this.lblAuditName4.Text; }
            set { this.lblAuditName4.Text = value; }
        }
        /// <summary>
		/// 一级审批人。
		/// </summary>
		public string Auditor1
		{
			get { return this.lblAuditor1.Text;}
			set { this.lblAuditor1.Text = value;}
		}
		/// <summary>
		/// 二级审批人。
		/// </summary>
		public string Auditor2
		{
			get { return this.lblAuditor2.Text;}
			set { this.lblAuditor2.Text = value;}
		}
		/// <summary>
		/// 三级审批人。
		/// </summary>
		public string Auditor3
		{
			get { return this.lblAuditor3.Text;}
			set { this.lblAuditor3.Text = value;}
		}
        /// <summary>
        /// 物资审批人。
        /// </summary>
	    public string Auditor4
	    {
            get { return this.lblAuditor4.Text; }
            set { this.lblAuditor4.Text = value; }
	    }
		/// <summary>
		///　一级审批日期。
		/// </summary>
		public string AuditDate1
		{
			get 
			{
				try
				{
					return Convert.ToDateTime(this.txtAuditDate1.Text).ToString("yyyy-MM-dd");
				}
				catch
				{
					return null;
				}
			}
			set 
			{ 
				try
				{
                    if(value != null && value!=DateTime.MinValue.ToString())
                        this.txtAuditDate1.Text = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
				}
				catch
				{
                    this.txtAuditDate1.Text = "";
                }
			}
		}
		/// <summary>
		/// 二级审批日期。
		/// </summary>
		public string AuditDate2
		{
			get 
			{
				try
				{
                    return Convert.ToDateTime(this.txtAuditDate2.Text).ToString("yyyy-MM-dd");
				}
				catch
				{
                    return  System.DateTime.Now.ToString("yyyy-MM-dd");
				}
			}
			set 
			{
                try
                {
                    if (value != null && value != DateTime.MinValue.ToString())
                        this.txtAuditDate2.Text = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
				catch
				{
                    this.txtAuditDate2.Text = "";
				}
			}
		}
		/// <summary>
		/// 三级审批日期。
		/// </summary>
		public string AuditDate3
		{
			get 
			{
				try
				{
                    return Convert.ToDateTime(this.txtAuditDate3.Text).ToString("yyyy-MM-dd");
				}
				catch
				{
                   return System.DateTime.Now.ToString("yyyy-MM-dd");
				}
			}
			set 
			{ 
				try
				{
                    if (value != null && value != DateTime.MinValue.ToString())
                        this.txtAuditDate3.Text = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
				}
				catch
				{
                    this.txtAuditDate3.Text = "";
				}
			}
		}
        /// <summary>
        /// 物资审批日期。
        /// </summary>
	    public string AuditDate4
	    {
            get
            {
                try
                {
                    return Convert.ToDateTime(this.txtAuditDate4.Text).ToString("yyyy-MM-dd");
                }
                catch
                {
                    return System.DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
            set
            {
                try
                {
                    if (value != null && value != DateTime.MinValue.ToString())
                        this.txtAuditDate4.Text = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch
                {
                    this.txtAuditDate4.Text = "";
                }
            }
	    }
		/// <summary>
		/// 一级审批意见。
		/// </summary>
		public string AuditSuggest1
		{
			get { return this.txtAuditSuggest1.Text;}
			set { this.txtAuditSuggest1.Text = value;}
		}
		/// <summary>
		/// 二级审批意见。
		/// </summary>
		public string AuditSuggest2
		{
			get { return this.txtAuditSuggest2.Text;}
			set { this.txtAuditSuggest2.Text = value;}
		}
		/// <summary>
		/// 三级审批意见。
		/// </summary>
		public string AuditSuggest3
		{
			get { return this.txtAuditSuggest3.Text;}
			set { this.txtAuditSuggest3.Text = value;}
		}
        /// <summary>
        /// 四级审批意见。
        /// </summary>
        public string AuditSuggest4
        {
            get { return this.txtAuditSuggest4.Text; }
            set { this.txtAuditSuggest4.Text = value; }
        }
		/// <summary>
		/// 一级审批。
		/// </summary>
		public string  Audit1
		{
			get { return this.rblAudit1.SelectedValue;}
			set 
			{ 
				this.rblAudit1.ClearSelection();
				switch (value)
				{
					case "Y":
						this.rblAudit1.SelectedIndex = 0;
						this.rblAudit1.SelectedValue = value;
						break;
					case "N":
						this.rblAudit1.SelectedIndex = 1;
						this.rblAudit1.SelectedValue = value;
						break;
					default:
						this.rblAudit1.ClearSelection();
						break;
				}
			}
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		public string  Audit2
		{
			get { return this.rblAudit2.SelectedValue;}
			set 
			{ 
				this.rblAudit2.ClearSelection();
				switch (value)
				{
					case "Y":
						this.rblAudit2.SelectedIndex = 0;
						this.rblAudit2.SelectedValue = value;
						break;
					case "N":
						this.rblAudit2.SelectedIndex = 1;
						this.rblAudit2.SelectedValue = value;
						break;
					default:
						this.rblAudit2.ClearSelection();
						break;
				}
			}
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		public string  Audit3
		{
			get { return this.rblAudit3.SelectedValue;}
			set 
			{ 
				this.rblAudit3.ClearSelection();
				switch (value)
				{
					case "Y":
						this.rblAudit3.SelectedIndex = 0;
						this.rblAudit3.SelectedValue = value;
						break;
					case "N":
						this.rblAudit3.SelectedIndex = 1;
						this.rblAudit3.SelectedValue = value;
						break;
					default:
						this.rblAudit3.ClearSelection();
						break;
				}
			}
		}
        /// <summary>
        /// 四级审批。
        /// </summary>
        public string Audit4
        {
            get { return this.rblAudit4.SelectedValue; }
            set
            {
                this.rblAudit4.ClearSelection();
                Logger.Debug(string.Format("Value is {0}",value));
                switch (value)
                {
                    case "Y":
                        this.rblAudit4.SelectedIndex = 0;
                        this.rblAudit4.SelectedValue = value;
                        break;
                    case "N":
                        this.rblAudit4.SelectedIndex = 1;
                        this.rblAudit4.SelectedValue = value;
                        break;
                    default:
                        this.rblAudit4.ClearSelection();
                        break;
                }
            }
        }
		#endregion

		enum AUDITLEVEL 
		{
			NONE=0,			//没审批	
			FIRST,			//审批一
			SECOND,			//审批二
			THIRD,			//审批三
            Forth          //审批四
		};

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Logger.Debug("DocAuditWebControl PageLoad");
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			if(!this.IsPostBack)
			{
				if (_docCode!=0)
				{
					myBindData();
				}
			}
            Logger.Debug(this._OP);
			switch (this._OP)
			{
				case "FirstAudit":
					this.rblAudit1.Enabled = true;
					this.rblAudit2.Enabled = false;
					this.rblAudit3.Enabled = false;
			        this.rblAudit4.Enabled = false;

					this.txtAuditSuggest1.Enabled = true;
					this.txtAuditSuggest1.ReadOnly = false;
					this.txtAuditSuggest2.ReadOnly = true;
					this.txtAuditSuggest3.ReadOnly = true;
			        this.txtAuditSuggest4.ReadOnly = true;
					
                    this.txtAuditDate1.ReadOnly = true;
					this.txtAuditDate2.ReadOnly = true;
					this.txtAuditDate3.ReadOnly = true;
			        this.txtAuditDate4.ReadOnly = true;
					
                    if (!this.IsPostBack)
					{
						this.Auditor1 = Session[MySession.UserName].ToString();
						this.AuditDate1 = DateTime.Now.ToShortDateString();
						this.Audit1 = null;
						this.AuditSuggest1 = null;
						//-----------------------------------------------
						this.Auditor2 = null;
						this.AuditDate2 = null;
						this.Audit2 = null;
						this.AuditSuggest2 = null;
						//-----------------------------------------------
						this.Auditor3 = null;
						this.AuditDate3 = null;
						this.Audit3 = null;
						this.AuditSuggest3 = null;
                        //-----------------------------------------------
                        this.Auditor4 = null;
					    this.AuditDate4 = null;
					    this.Audit4 = null;
					    this.AuditSuggest4 = null;
					}
					break;
				case "SecondAudit":
					this.rblAudit1.Enabled = false;
					this.rblAudit2.Enabled = true;
					this.rblAudit3.Enabled = false;
			        this.rblAudit4.Enabled = false;

					this.txtAuditSuggest1.ReadOnly = true;
					this.txtAuditSuggest2.Enabled = true;
					this.txtAuditSuggest2.ReadOnly = false;
					this.txtAuditSuggest3.ReadOnly = true;
			        this.txtAuditSuggest4.ReadOnly = true;

                    this.txtAuditDate1.ReadOnly = true;
					this.txtAuditDate2.ReadOnly = true;
					this.txtAuditDate3.ReadOnly = true;
			        this.txtAuditDate4.ReadOnly = true;

                    if (!this.IsPostBack)
					{
						this.Auditor2 = Session[MySession.UserName].ToString();
						this.AuditDate2 = DateTime.Now.ToShortDateString();
						this.Audit2 = null;
						this.AuditSuggest2 = null;
						//-----------------------------------------------
						this.Auditor3 = null;
						this.AuditDate3 = null;
						this.Audit3 = null;
						this.AuditSuggest3 = null;
                        //-----------------------------------------------
					}
					break;
				case "ThirdAudit":
					this.rblAudit1.Enabled = false;
					this.rblAudit2.Enabled = false;
					this.rblAudit3.Enabled = true;
			        this.rblAudit4.Enabled = false;

					this.txtAuditSuggest1.ReadOnly = true;
					this.txtAuditSuggest2.ReadOnly = true;
					this.txtAuditSuggest3.Enabled = true;
					this.txtAuditSuggest3.ReadOnly = false;
			        this.txtAuditSuggest4.ReadOnly = true;

                    this.txtAuditDate1.ReadOnly = true;
					this.txtAuditDate2.ReadOnly = true;
					this.txtAuditDate3.ReadOnly = true;
			        this.txtAuditDate4.ReadOnly = true;

                    if (!this.IsPostBack)
					{
						this.Auditor3 = Session[MySession.UserName].ToString();
						this.AuditDate3 = DateTime.Now.ToShortDateString();
						this.Audit3 = null;
						this.AuditSuggest3 = null;
					}
					break;
                case "WZAudit":
                    this.rblAudit1.Enabled = false;
					this.rblAudit2.Enabled = false;
					this.rblAudit3.Enabled = false;
			        this.rblAudit4.Enabled = true;

					this.txtAuditSuggest1.ReadOnly = true;
					this.txtAuditSuggest2.ReadOnly = true;
					this.txtAuditSuggest3.Enabled = true;
					this.txtAuditSuggest3.ReadOnly = true;
			        this.txtAuditSuggest4.ReadOnly = false;

                    this.txtAuditDate1.ReadOnly = true;
					this.txtAuditDate2.ReadOnly = true;
					this.txtAuditDate3.ReadOnly = true;
			        this.txtAuditDate4.ReadOnly = true;

                    if (!this.IsPostBack)
					{
						this.Auditor4 = Session[MySession.UserName].ToString();
						this.AuditDate4 = DateTime.Now.ToShortDateString();
						this.Audit4 = null;
						this.AuditSuggest4 = null;

                        this.Auditor2 = null;
                        this.AuditDate2 = null;
                        this.Audit2 = null;
                        this.AuditSuggest2 = null;

                        this.Auditor3 = null;
                        this.AuditDate3 = null;
                        this.Audit3 = null;
                        this.AuditSuggest3 = null;
					}
					break;
				default:
					this.rblAudit1.Enabled = false;
					this.rblAudit2.Enabled = false;
					this.rblAudit3.Enabled = false;
			        this.rblAudit4.Enabled = false;

					this.txtAuditSuggest1.ReadOnly = true;
					this.txtAuditSuggest2.ReadOnly = true;
					this.txtAuditSuggest3.ReadOnly = true;
			        this.txtAuditSuggest4.ReadOnly = true;

                    this.txtAuditDate1.ReadOnly = true;
					this.txtAuditDate2.ReadOnly = true;
					this.txtAuditDate3.ReadOnly = true;
			        this.txtAuditDate4.ReadOnly = true;
                    break;
			}
		}

		private void myBindData()
		{
		    Logger.Debug("myBindData");
		    auditLevel = 0;
		    string IsAudit1 = "",IsAudit2 = "",IsAudit3 = "", IsAudit4=string.Empty;

			
			oBOD=(new PurchaseSystem()).GetDocEntryByCode(_docCode);
            Logger.Debug(oBOD.Tables[0].Rows.Count);
			if(oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows.Count>0)
			{
                
				auditLevel=int.Parse(oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.AUDITLEVEL_FIELD].ToString());
				IsAudit1 = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.ISAUDIT1_FIELD].ToString();
				IsAudit2 = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.ISAUDIT2_FIELD].ToString();
				IsAudit3 = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.ISAUDIT3_FIELD].ToString();
			    IsAudit4 = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.ISAUDIT4_FIELD]==DBNull.Value?"N":oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.ISAUDIT4_FIELD].ToString();
			}

			lblAuditName1.Text=oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0]["AuditName1"].ToString();
			lblAuditName2.Text=oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.AUDITNAME2_FIELD].ToString();
			lblAuditName3.Text=oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.AUDITNAME3_FIELD].ToString();
            lblAuditName4.Text=oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.AUDITNAME4_FIELD] == DBNull.Value ? string.Empty : oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.AUDITNAME4_FIELD].ToString();

			lblAuditSuggest1.Visible = (IsAudit1=="Y")?true:false;
			lblAuditDate1.Visible = (IsAudit1=="Y")?true:false;
			lblAuditName1.Visible = (IsAudit1=="Y")?true:false;
			rblAudit1.Visible = (IsAudit1=="Y")?true:false;
			txtAuditSuggest1.Visible = (IsAudit1=="Y")?true:false;
			txtAuditDate1.Visible = (IsAudit1=="Y")?true:false;
			rblAudit1.Enabled = (IsAudit1=="Y")?true:false;
			txtAuditSuggest1.Enabled = (IsAudit1=="Y")?true:false;
			txtAuditDate1.Enabled = (IsAudit1=="Y")?true:false;

			lblAuditSuggest2.Visible = (IsAudit2=="Y")?true:false;
			lblAuditDate2.Visible = (IsAudit2=="Y")?true:false;
			lblAuditName2.Visible = (IsAudit2=="Y")?true:false;
			rblAudit2.Visible = (IsAudit2=="Y")?true:false;
			txtAuditSuggest2.Visible = (IsAudit2=="Y")?true:false;
			txtAuditDate2.Visible = (IsAudit2=="Y")?true:false;
			rblAudit2.Enabled = (IsAudit2=="Y")?true:false;
			txtAuditSuggest2.Enabled = (IsAudit2=="Y")?true:false;
			txtAuditDate2.Enabled = (IsAudit2=="Y")?true:false;

			lblAuditSuggest3.Visible = (IsAudit3=="Y")?true:false;
			lblAuditDate3.Visible = (IsAudit3=="Y")?true:false;
			lblAuditName3.Visible = (IsAudit3=="Y")?true:false;
			rblAudit3.Visible = (IsAudit3=="Y")?true:false;
			txtAuditSuggest3.Visible = (IsAudit3=="Y")?true:false;
			txtAuditDate3.Visible = (IsAudit3=="Y")?true:false;
			rblAudit3.Enabled = (IsAudit3=="Y")?true:false;
			txtAuditSuggest3.Enabled = (IsAudit3=="Y")?true:false;
			txtAuditDate3.Enabled = (IsAudit3=="Y")?true:false;

            lblAuditSuggest4.Visible = (IsAudit4 == "Y") ? true : false;
            lblAuditDate4.Visible = (IsAudit4 == "Y") ? true : false;
            lblAuditName4.Visible = (IsAudit4 == "Y") ? true : false;
            rblAudit4.Visible = (IsAudit4 == "Y") ? true : false;
            txtAuditSuggest4.Visible = (IsAudit4 == "Y") ? true : false;
            txtAuditDate4.Visible = (IsAudit4 == "Y") ? true : false;
            rblAudit4.Enabled = (IsAudit4 == "Y") ? true : false;
            txtAuditSuggest4.Enabled = (IsAudit4 == "Y") ? true : false;
            txtAuditDate4.Enabled = (IsAudit4 == "Y") ? true : false;
		}

		public int DocCode
		{
			get{ return _docCode;}
			set{ _docCode=value;}
		}

		public int AuditLevel
		{
			get{ return _auditLevel;}
		}


		
	}
}
