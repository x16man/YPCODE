namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHMM.WebMM.Modules;
	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class BRBWebControl : System.Web.UI.UserControl
	{
		#region 成员变量

		//private static DataTable dt;//定义了一静态的表,用以保存状态数据
		private string tmpCode;
		private string _OP;
		//private int _ConCode;
		public DGModel_Items DGModel_Items1;

	    private bool ret;

	    private DateTime tmpDateTime;

	    private decimal Temp_Area;


	    private DateTime StartTime;
	    private DateTime EndTime;
	    private DateTime ImportTime;
	    private DateTime ExportTime;

        private ItemData oItemData = new ItemData();
        private ItemSystem oItemSystem = new ItemSystem();

	    private DataRow dr;

	    private int iRow;
		#endregion

		#region 属性
		/// <summary>
		/// 静态数据表。
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.BRB_DT] != null)
					return (DataTable)Session[MySession.BRB_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.BRB_DT] = value;
			}
		}
		/// <summary>
		/// 池位编号。
		/// </summary>
		public int ConCode
		{
			get 
			{	if (this.txtConCode.Text.Length > 0)
					return Convert.ToInt32(this.txtConCode.Text);	
				else
					return -1;
			}
			set 
			{	
				this.txtConCode.Text = value.ToString();	
			}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 对数据进行校验.
		/// </summary>
		/// <returns>bool:	校验通过返回true，失败返回false。</returns>
		private bool DoCheck()
		{
			ret=true;
			
			try
			{
				if( this.txtShipNo.Text.Trim() != "" && 
					this.txtStartTime.Text.Trim() !="" && 
					this.txtEndTime.Text.Trim() != "" && 
					this.txtImportTime.Text.Trim() != "" && 
					this.txtExportTime.Text.Trim() != "")
				{
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtStartTime.Text);
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtEndTime.Text);
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtImportTime.Text);
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtExportTime.Text);
				}
				else
				{
					this.Response.Write("<script>alert(\"船名、开工时间、完工时间、进港时间、出港时间不能为空！\");</script>");
					ret=false;
				}
			}
			catch
			{
				this.Response.Write("<script>alert(\"时间格式不正确！\");</script>");
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 获取池位面积。
		/// </summary>
		/// <returns>decimal:	面积。</returns>
		private decimal GetArea()
		{
			Temp_Area = new ItemSystem().GetStoConByCode(this.ConCode).Area;
			return Temp_Area;
		}
		/// <summary>
		/// 计算体积。
		/// </summary>
		/// <returns>decimal:	体积数。</returns>
		private decimal CalcVolumn()
		{
			decimal StartHeight;//抽驳前液位。
			decimal EndHeight;//抽驳后液位。
			decimal Volumn;
		
			StartTime = Convert.ToDateTime((DateTime.Now.ToShortDateString() +" "+ this.txtStartTime.Text.Trim()));
			EndTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() +" "+ this.txtEndTime.Text.Trim());
			if (this.txtStartVolumn.Text.Trim().Length > 0)
			{
				StartHeight = Convert.ToDecimal(this.txtStartVolumn.Text.Trim());
			}
			else
			{
				StartHeight = new STAGData().GetPLCValue(this.ConCode, StartTime);
			}
			if (this.txtEndVolumn.Text.Trim().Length > 0)
			{
				EndHeight = Convert.ToDecimal(this.txtEndVolumn.Text.Trim());
			}
			else
			{
				EndHeight = new STAGData().GetPLCValue(this.ConCode, EndTime);
			}
			try
			{
				Volumn = Math.Round((EndHeight - StartHeight)*this.GetArea(),2);
			}
			catch
			{
				Volumn = 0;
			}
			return Volumn;
		}
		#endregion
		
		

		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.DGModel_Items1.ColumnsScheme = ColumnScheme.BRB;
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//审批模式下，不允许进行单据内容的修改。
			if (this._OP == "FirstAudit" || 
				this._OP == "SecondAudit" || 
				this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
			}
			//DataGrid 的选择模式。
			DGModel_Items1.SelectedType = DGModel.SelectType.SingleSelect;
			//是否显示页码。
			DGModel_Items1.ShowPager = false;
			DGModel_Items1.AllowPaging = false;

			if((!this.IsPostBack) && (this.Request["Op"] == "New"))
			{
				//定义表和数据结构
				if(this.thisTable!=null) this.thisTable = null;
				this.thisTable=new DataTable();

				DataColumnCollection columns = this.thisTable.Columns;
				columns.Add("ShipNo");
				columns.Add("StartTime");
				columns.Add("EndTime");
				columns.Add("ImportTime");
				columns.Add("ExportTime");
				columns.Add("ItemCode");
				columns.Add("ItemName");
				columns.Add("ItemSpecial");
				columns.Add("ItemUnit");
				columns.Add("ItemUnitName");
				columns.Add("StartVolumn");
				columns.Add("EndVolumn");
				columns.Add("ItemVolumn");
				columns.Add("ProductCat");
				columns.Add("DangerCat");
				//绑定
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();
			}
			else
			{
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();
				tmpCode=DGModel_Items1.SelectedID;
			}
		}

        /*
		/// <summary>
		/// 页面UnLoad事件。
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//释放静态变量dt
			this.thisTable=null;
		}
         * */
		
		/// <summary>
		/// 增加按钮。
		/// </summary>
		protected void btnAddItem_Click(object sender, System.EventArgs e)
		{
			//
			//添加一行数据并且赋值
			//
			
			if(DoCheck())
			{
				if(btnAddItem.Text=="新增")
				{
					dr=this.thisTable.NewRow();
					//货名。
					
					

					oItemData = oItemSystem.GetItemByCode(new SysSystem().GetSTAGInfo().ItemCode);
					dr[InItemData.ITEMCODE_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD];
					dr[InItemData.ITEMNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD];
					dr[InItemData.ITEMSPECIAL_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD];
					dr[InItemData.ITEMUNIT_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD];
					dr[InItemData.ITEMUNITNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field];
					
					dr[PBRBData.SHIPNO_FIELD] = this.txtShipNo.Text;
					try
					{
						StartTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtStartTime.Text);
						EndTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtEndTime.Text);
						ImportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtImportTime.Text);
						ExportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtExportTime.Text);
					}
					catch 
					{
						this.Response.Write("<script>alert('请输入正确的时间格式：HH:MM:SS!');</script>");
						return;
					}
					dr[PBRBData.STARTTIME_FIELD] = StartTime;
					dr[PBRBData.ENDTIME_FIELD] = EndTime;
					dr[PBRBData.IMPORTTIME_FIELD] = ImportTime;
					dr[PBRBData.EXPORTTIME_FIELD] = ExportTime;

					if (this.txtStartVolumn.Text.Trim().Length > 0 )//如果是手工输入液位值。
					{
						try
						{
							dr[PBRBData.STARTVOLUMN_FIELD] = Convert.ToDecimal(this.txtStartVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"请输入正确的液位值！\");</script>");
							return;
						}
					}
					else//如果没有手工输入，则认为是从指标库中读取液位值。
					{
						//TODO: 增加从指标库中取指标刻度值。
						dr[PBRBData.STARTVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode,StartTime) ;	
					}
					if (this.txtEndVolumn.Text.Trim().Length > 0)//如果是手工输入液位值。
					{
						try
						{
							dr[PBRBData.ENDVOLUMN_FIELD] = Convert.ToDecimal(this.txtEndVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"请输入正确的液位值！\");</script>");
							return;
						}
					}
					else
					{
						//TODO:	增加从指标库中取指标刻度值。
						dr[PBRBData.ENDVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode, EndTime);;
					}
					//计算体积。
					if (this.CalcVolumn() == 0)
					{
						this.Response.Write("<script>alert(\'该架位没有设定底面积！\');</script>");
						return;
					}
					else
					{
						dr[PBRBData.ITEMVOLUMN_FIELD] = this.CalcVolumn();
						this.thisTable.Rows.Add(dr);
					}
				}
				else//更新。
				{
					iRow=int.Parse(txtItemSerial.Value);
					dr=this.thisTable.Rows[iRow];
					//货名。
				
					oItemData = oItemSystem.GetItemByCode(new SysSystem().GetSTAGInfo().ItemCode);
					dr[InItemData.ITEMCODE_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD];
					dr[InItemData.ITEMNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD];
					dr[InItemData.ITEMSPECIAL_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD];
					dr[InItemData.ITEMUNIT_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD];
					dr[InItemData.ITEMUNITNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field];
					
					dr[PBRBData.SHIPNO_FIELD] = this.txtShipNo.Text;
					try
					{
						StartTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtStartTime.Text);
						EndTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtEndTime.Text);
						ImportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtImportTime.Text);
						ExportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtExportTime.Text);
					}
					catch 
					{
						this.Response.Write("<script>alert('请输入正确的时间格式：HH:MM:SS!');</script>");
						return;
					}

					dr[PBRBData.STARTTIME_FIELD] = StartTime;
					dr[PBRBData.ENDTIME_FIELD] = EndTime;
					dr[PBRBData.IMPORTTIME_FIELD] = ImportTime;
					dr[PBRBData.EXPORTTIME_FIELD] = ExportTime;
					if (this.txtStartVolumn.Text.Trim().Length > 0 )//如果是手工输入液位值。
					{
						try
						{
							dr[PBRBData.STARTVOLUMN_FIELD] = Convert.ToDecimal(this.txtStartVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"请输入正确的液位值！\");</script>");
							return;
						}
					}
					else//如果没有手工输入，则认为是从指标库中读取液位值。
					{
						//TODO: 增加从指标库中取指标刻度值。
						dr[PBRBData.STARTVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode, StartTime);;	
					}
					if (this.txtEndVolumn.Text.Trim().Length > 0)//如果是手工输入液位值。
					{
						try
						{
							dr[PBRBData.ENDVOLUMN_FIELD] = Convert.ToDecimal(this.txtEndVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"请输入正确的液位值！\");</script>");
							return;
						}
					}
					else
					{
						//TODO:	增加从指标库中取指标刻度值。
						dr[PBRBData.ENDVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode, EndTime);;
					}
					dr[PBRBData.ITEMVOLUMN_FIELD] = this.CalcVolumn();
					
					txtItemSerial.Value="-1";
					btnAddItem.Text="新增";
				}
				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();				

				this.txtShipNo.Text="";
				this.txtStartTime.Text="";
				this.txtEndTime.Text="";
				this.txtImportTime.Text = "";
				this.txtExportTime.Text = "";
				this.txtStartVolumn.Text = "";
				this.txtEndVolumn.Text = "";
			}
		}

		/// <summary>
		/// 编辑按钮。
		/// </summary>
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			//不等于-1表示已经处于编辑状态
			if(txtItemSerial.Value=="-1")
			{
				if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
				{
					iRow = int.Parse(DGModel_Items1.SelectedID);
	
					txtItemSerial.Value = iRow.ToString();

					this.txtShipNo.Text = this.thisTable.Rows[iRow][PBRBData.SHIPNO_FIELD].ToString();
					this.txtStartTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.STARTTIME_FIELD].ToString()).ToShortTimeString();
					this.txtEndTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.ENDTIME_FIELD].ToString()).ToShortTimeString();
					this.txtImportTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.IMPORTTIME_FIELD].ToString()).ToShortTimeString();
					this.txtExportTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.EXPORTTIME_FIELD].ToString()).ToShortTimeString();
					this.txtStartVolumn.Text = this.thisTable.Rows[iRow][PBRBData.STARTVOLUMN_FIELD].ToString();
					this.txtEndVolumn.Text = this.thisTable.Rows[iRow][PBRBData.ENDVOLUMN_FIELD].ToString();
					btnAddItem.Text="更新";
				}
			}

		}
		/// <summary>
		/// 删除按钮。
		/// </summary>
		protected void btnDelItem_Click(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
			{
				iRow=int.Parse(DGModel_Items1.SelectedID);

				this.thisTable.Rows.RemoveAt(iRow);

				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();
			}
		}
		/// <summary>
		/// 文本绑定的隐藏按钮。
		/// </summary>
		protected void btnForItemCode_Click(object sender, System.EventArgs e)
		{

		}   //End btnForItemCode_Click
		#endregion
	}
}
