using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Infragistics.WebUI.UltraWebGrid;
using MZHCommon.Database;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using NDateTime = NullableTypes.NullableDateTime;
using NString = NullableTypes.NullableString;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace WebMM.Storage
{
	/// <summary>
	/// YCLGroupBrowser 的摘要说明。
	/// </summary>
	public partial class YCLGroupBrowser : Page
	{
		#region 成员变量
		protected System.Web.UI.WebControls.Button Button_ConfirmTrue;
       // private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
		private DataSet oData;

	    private DataRow dr;

	    private string strConn;

	    private OleDbConnection conn;
	    private OleDbDataAdapter myCommand;
	    private DataSet ds;

	    private ItemSystem oItemSystem = new ItemSystem();

	    private Hashtable oHT = new Hashtable();

	    private string strExcel;

	    private string fileName;

	    private string fullFileName;

	    private int i;

	    private decimal inNum;
	    private decimal outNum;
	    private decimal inVol;
	    private decimal outVol;

        private DataSet myDS;
        Hashtable oHT_MinDate = new Hashtable();
        Hashtable oHT_MaxDate = new Hashtable();
        Hashtable oHT_Item_Date = new Hashtable();

	   
        string key_Item_Date;


	    private YCLData tempDS;
	    private string alertString;
		#endregion

		#region 属性
		/// <summary>
		/// 开始日期。
		/// </summary>
		private DateTime StartDate
		{
			get 
			{
				return this.txtStartDate.Text == string.Empty?new DateTime(DateTime.Now.Year,DateTime.Now.Month,1)
																  : Convert.ToDateTime(this.txtStartDate.Text);
			}
			set
			{
				this.txtStartDate.Text = value.ToString("yyyy-MM-dd");
			}
		}
		/// <summary>
		/// 结束日期。
		/// </summary>
		private DateTime EndDate
		{
			get 
			{
				return this.txtEndDate.Text == string.Empty?new DateTime(DateTime.Now.Year,DateTime.Now.Month,1)
																: Convert.ToDateTime(this.txtEndDate.Text);
			}
			set
			{
                this.txtEndDate.Text = value.ToString("yyyy-MM-dd");
			}
		}
		/// <summary>
		/// 物料编号。
		/// </summary>
		private string ItemCode
		{
			get
			{
				if (this.Request["ItemCode"] == null)
				{
					return "";
				}
				else
				{
					return this.Request["ItemCode"];
				}
			}
		}
		/// <summary>
		/// 客户端确认对话框的返回值.
		/// </summary>
		protected string ConfirmResult
		{
			get {return this.txtConfirmResult.Value;}
			set {this.txtConfirmResult.Value=value;}
		}
		#endregion
		
		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
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
			this.UG_YCLDetail.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UG_YCLDetail_InitializeRow);
			this.UG_YCLDetail.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UG_YCLDetail_InitializeLayout);

		}
		#endregion

		#region 方法
		/// <summary>
		/// 读取Excel到DataSet中.
		/// </summary>
		/// <param name="Path">Excel文件的路径.</param>
		/// <returns>DataSet</returns>
		public DataSet ExcelToDS(string Path) 
		{ 
			strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +"Data Source="+ Path +";"+"Extended Properties=Excel 8.0;"; 
			conn = new OleDbConnection(strConn); 
			conn.Open();
		    myCommand = new OleDbDataAdapter();
			ds = new DataSet();
			strExcel ="select * from [sheet1$]"; 
			myCommand = new OleDbDataAdapter(strExcel, strConn); 
			ds = new DataSet(); 
			myCommand.Fill(ds,"table1"); 
			conn.Close();
			return ds; 
		} 
		#endregion

		#region 事件
		/// <summary>
		/// 页面加载事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack) 
			{
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.YCLIO))
                {
                    return;
                }

                if (!Master.HasRight(SysRight.YCLIOMaintain))
                {
                    toolbarButtonadd.Visible = false;
                   toolbarButtonedit.Visible = false;
                   toolbarButtondelete.Visible = false;
                }

				if (this.Request["StartDate"] == null)
				{
					this.StartDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
				}
				else
				{
					this.StartDate =  Convert.ToDateTime(this.Request["StartDate"]);	
				}
				if (this.Request["EndDate"] == null)
				{
					this.EndDate =  this.StartDate.AddMonths(1);
				}
				else
				{
					this.EndDate = Convert.ToDateTime(this.Request["EndDate"]);		
				}
				this.UG_YCLDetail.DataBind();
				this.UG_YCLDetail.Bands[0].Key = "Parent";
				this.UG_YCLDetail.Bands[1].Key = "Child";
			}
		}

		/// <summary>
		/// 编辑按钮事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnEdit_Click(object sender, EventArgs e)
		{
            if (this.UG_YCLDetail.DisplayLayout.SelectedRows.Count > 0)
            {
                if (this.UG_YCLDetail.DisplayLayout.SelectedRows[0].Band.Key == "Child")
                {
                    this.Response.Redirect("YCLInput.aspx?Op=Edit&PKID=" + this.UG_YCLDetail.DisplayLayout.SelectedRows[0].Cells.FromKey("PKID").Text);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('请选择一条进行编辑!');", true);
                    
            }
		}

		/// <summary>
		/// 新建按钮事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			this.Response.Redirect("YCLInput.aspx?Op=New",true);
		}

		/// <summary>
		/// 删除按钮事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
            if (this.UG_YCLDetail.DisplayLayout.SelectedRows.Count > 0)
            {
                if (this.UG_YCLDetail.DisplayLayout.SelectedRows[0].Band.Key == "Child")
                {
                    if (!oItemSystem.DeleteYCL(int.Parse(this.UG_YCLDetail.DisplayLayout.SelectedRows[0].Cells.FromKey("PKID").Text)))
                    {
                        //Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");	
                        //Page.RegisterStartupScript("delete","<script>alert('"+oItemSystem.Message+"');</script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "delete", "alert('" + oItemSystem.Message + "');", true);
                        return;
                    }
                    this.UG_YCLDetail.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "delete", "alert('请选择一条记录删除');", true);
                return;
            }
		}

		/// <summary>
		/// Grid控件初始化外观事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UG_YCLDetail_InitializeLayout(object sender, LayoutEventArgs e)
		{
			this.UG_YCLDetail.DisplayLayout.ViewType = ViewType.Hierarchical;

			this.UG_YCLDetail.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			
			
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemCode").Header.Caption = "编号";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemName").Header.Caption = "名称";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemUnitName").Header.Caption = "单位";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("StartItemNum").Header.Caption = "期初";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("InItemNum").Header.Caption = "收入";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("OutItemNum").Header.Caption = "发出";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("EndItemNum").Header.Caption = "结存";

			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemUnitName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCLDetail.Bands[0].Columns.FromKey("StartItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[0].Columns.FromKey("InItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[0].Columns.FromKey("OutItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[0].Columns.FromKey("EndItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemCode").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemName").Width = new Unit("120px");
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemUnitName").Width = new Unit("50px");
			this.UG_YCLDetail.Bands[0].Columns.FromKey("StartItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[0].Columns.FromKey("InItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[0].Columns.FromKey("OutItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[0].Columns.FromKey("EndItemNum").Width = new Unit("80px");

			this.UG_YCLDetail.Bands[1].Columns.FromKey("PKID").Hidden = true;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemCode").Header.Caption = "编号";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemName").Header.Caption = "名称";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemUnitName").Header.Caption = "单位";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("StartItemNum").Header.Caption = "期初";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("InItemNum").Header.Caption = "收入";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OutItemNum").Header.Caption = "发出";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("EndItemNum").Header.Caption = "结存";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OpDate").Header.Caption = "日期";

			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemUnitName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("StartItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("InItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OutItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("EndItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OpDate").CellStyle.HorizontalAlign = HorizontalAlign.Center;

			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemCode").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemName").Width = new Unit("120px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemUnitName").Width = new Unit("50px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("StartItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("InItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OutItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("EndItemNum").Width = new Unit("80px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OpDate").Width = new Unit("100px");
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OpDate").Format = "yyyy-MM-dd";
		}

		/// <summary>
		/// Grid控件数据绑定事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void UG_YCLDetail_DataBinding(object sender, EventArgs e)
		{
			oHT = new Hashtable();
			//oHT.Add("@ItemCode",this.ItemCode==null?null:this.ItemCode.ToString());
			oHT.Add("@ItemCode","");
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);
			oData = new DataSet();
			oData = new SQLServer().ExecSPReturnDS("Sto_YCLGetGroupByDate",oHT,oData,"Parent");
			oData =	 new SQLServer().ExecSPReturnDS("Sto_YCLGetByItemAndDate",oHT,oData,"Child");
			try 
			{
				oData.Relations.Add("PC",
				oData.Tables["Parent"].Columns["ItemCode"],
				oData.Tables["Child"].Columns["ItemCode"]);
			}
			catch 
			{
				
			}
			this.UG_YCLDetail.DataSource = oData.Tables["Parent"].DefaultView;
		}

		/// <summary>
		/// 确定按钮事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnYes_Click(object sender, EventArgs e)
		{
			this.UG_YCLDetail.DataBind();	
		}

		/// <summary>
		/// Grid控件行初始化事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UG_YCLDetail_InitializeRow(object sender, RowEventArgs e)
		{
			if (e.Row.Band.Key == "Parent")
			{
				if (e.Row.Cells.FromKey("ItemCode").Value.ToString() == this.ItemCode)
				{
					e.Row.Expand(true);
				}
			}
		}
		
		/// <summary>
		/// 上传EXCEL文件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnUpload_Click(object sender, EventArgs e)
		{
			if (this.uploadFile.PostedFile.FileName.Length==0)
				return;
			fileName =this.uploadFile.PostedFile.FileName.Substring(this.uploadFile.PostedFile.FileName.LastIndexOf("\\")+1);
			fullFileName = AppDomain.CurrentDomain.BaseDirectory+"UpLoadFile/"+fileName;
		    inNum = 0;
		    outNum = 0;
		    inVol = 0;
		    outVol = 0;
			

			
			if (File.Exists( fullFileName))
			{
				File.Delete(fullFileName);
			}
			this.uploadFile.PostedFile.SaveAs(fullFileName);
			myDS = this.ExcelToDS(fullFileName);
			//this.DataGrid1.DataSource = myDS.Tables[0].DefaultView;
			//this.DataGrid1.DataBind();

			oHT_MinDate = new Hashtable();
			oHT_MaxDate = new Hashtable();
			oHT_Item_Date = new Hashtable();
		    key_Item_Date = "";

            //Logger.Info(myDS.Tables[0].Rows.Count);
			foreach(DataRow oRow in myDS.Tables[0].Rows )
			{
                //Logger.Info("编号" + oRow["编号"].ToString());
               // Logger.Info("日期" + oRow["日期"].ToString());
				#region Key_Item_Date
				try
				{
                    
					key_Item_Date =
						string.Format("{0} {1}", oRow["编号"].ToString().Trim(), (Convert.ToDateTime(oRow["日期"].ToString())).ToShortDateString());
				}
				catch
				{
					ClientScript.RegisterStartupScript( this.GetType(), "Upload_Null", "alert('日期或物料编号不能为空!');", true);
					return;
				}
				if(oHT_Item_Date.ContainsKey(key_Item_Date))
				{
                    ClientScript.RegisterStartupScript( this.GetType(), "Upload_Same", string.Format("alert('{0} 有重复的记录,一个物料在一天只能有一条记录.');", key_Item_Date), true);
                    return;
				}
				else
				{
					oHT_Item_Date.Add(key_Item_Date,null);	
				}
				#endregion

				#region 最大日期 最小日期
				if(oHT_MinDate.ContainsKey(oRow["编号"].ToString()))
				{
					if(DateTime.Parse(oRow["日期"].ToString())<=DateTime.Parse(oHT_MinDate[oRow["编号"].ToString()].ToString()))
					{
						oHT_MinDate[oRow["编号"]] = DateTime.Parse(oRow["日期"].ToString());
					}
					else
					{
						oHT_MaxDate[oRow["编号"]] = DateTime.Parse(oRow["日期"].ToString());
					}
				}
				else//如果在Hashtable中这个物料的记录尚不存在.
				{
					oHT_MinDate.Add(oRow["编号"].ToString(),DateTime.Parse(oRow["日期"].ToString()));
				}
				#endregion

				#region 判断数字格式是否合法
				try
				{
					inNum = oRow["收入数量"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["收入数量"].ToString());
					outNum = oRow["发出数量"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["发出数量"].ToString());
					inVol = oRow["收入体积"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["收入体积"].ToString());
					outVol = oRow["发出体积"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["发出体积"].ToString());
					if(inNum<0 || inVol<0 || outNum<0 || outVol<0)
					{
						ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check1", "alert('数量不能为负');", true);
						return;
					}
					if (inNum > 1000000000 || inVol >100000000 || outNum > 1000000000 || outVol > 1000000000)
					{
                        ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check2", string.Format("alert('{0} {1}数量不能大于1000000000.');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
                        return;
					}
				}
				catch
				{
					ClientScript.RegisterStartupScript(this.GetType(), "Upload_Check3", string.Format("alert('{0} {1}收入数量或发出数量格式不对!');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
                       
					return;
				}
				#endregion

			}
			#region 是否已存在重复记录 以及该物料编号是否存在.
			YCLData tempYCLData;
			foreach(object okey in oHT_MinDate.Keys)
			{
                //Logger.Info("okey=" + okey.ToString());
				if(oItemSystem.GetItemByCode(okey.ToString().PadLeft(8,'0')).Count>0)
				{
                    //Logger.Info("oHT_MinDate:okey");
                    //Logger.Info(oHT_MinDate[okey.ToString()]);
                    //Logger.Info("oHT_MaxDate:okey");
                    //Logger.Info(oHT_MaxDate[okey.ToString()]);
                    tempYCLData = new YCLData();
                    if (oHT_MinDate[okey.ToString()].ToString() == "")
                    {
                        tempYCLData = oItemSystem.GetYCLByItemAndDate(okey.ToString().PadLeft(8, '0'), DateTime.Parse(oHT_MinDate[okey.ToString()].ToString()).AddDays(-1),DateTime.Parse(oHT_MaxDate[okey.ToString()].ToString()));
                    }
                    else if (oHT_MaxDate[okey.ToString()].ToString() == "")
                    {

                        tempYCLData = oItemSystem.GetYCLByItemAndDate(okey.ToString().PadLeft(8, '0'), DateTime.Parse(oHT_MinDate[okey.ToString()].ToString()),
                            DateTime.Parse(oHT_MinDate[okey.ToString()].ToString()).AddDays(1));
                    }
                    //Logger.Info("Tables[0].Rows.Count=");
                    //Logger.Info(tempYCLData.Tables[0].Rows.Count);
					if (tempYCLData.Tables[0].Rows.Count > 0 && this.CheckBox_IsOverWrite.Checked==false)//已存在重复记录,而且没有确认要覆盖.
					{
						alertString = "alert('系统在Excel指定的日期范围中,已经存在有收发记录!');";
						
						if(!Page.IsClientScriptBlockRegistered("ConfirmDelete"))
						{
                           
							ClientScript.RegisterStartupScript( this.GetType(), "ConfirmDelete", alertString, true);
						}
						return;
					}
					else if(tempYCLData.Tables[0].Rows.Count >0 && this.CheckBox_IsOverWrite.Checked==true )
					{
						//TODO:删除重复记录.
						for(i=tempYCLData.Tables[0].Rows.Count-1;i>=0;i--)
						{
							if(!oItemSystem.DeleteYCL(int.Parse(tempYCLData.Tables[0].Rows[i]["PKID"].ToString())))
							{
								this.ConfirmResult = string.Empty;
                                ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check4", "alert('删除原材料收发记录失败!PKID=" + tempYCLData.Tables[0].Rows[i]["PKID"].ToString() + "');", true);
                                return;
							}
						}
					}
				}
				else
				{
					this.ConfirmResult=string.Empty;
                    ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check5", "alert('" + string.Format("{0} 不存在的物料编号!", okey.ToString()) + "');", true);
					return;
				}
			}
			this.ConfirmResult=string.Empty;
			#endregion

			tempDS = new YCLData();
			
			foreach(DataRow oRow in myDS.Tables[0].Rows )
			{
				try
				{
					inNum = oRow["收入数量"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["收入数量"].ToString());
					outNum = oRow["发出数量"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["发出数量"].ToString());
				}
				catch
				{
					ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check6", string.Format("alert('收入数量或发出数量格式不对!');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
                    return;
				}
				if (inNum+outNum != 0)//收发都为零的记录不做处理.
				{
					dr = tempDS.Tables[YCLData.YCL_Table].NewRow();
					dr[YCLData.PKID_Field] = DBNull.Value;
					dr[YCLData.ItemCode_Field] = oRow["编号"];//编号
					dr[YCLData.ItemName_Field] = oRow["名称"];//名称
					
					#region 日期
					try
					{
						dr[YCLData.OpDate_Field] = DateTime.Parse(oRow["日期"].ToString());
					}
					catch
					{
						ClientScript.RegisterStartupScript(this.GetType(), "Upload_Check7", string.Format("alert('{0} 日期格式不对!');", oRow["编号"].ToString()), true);
						return;
					}
					#endregion
					#region 收入体积
					if(oRow["收入体积"].ToString()==string.Empty)
					{
						dr[YCLData.InVolNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.InVolNum_Field] = Convert.ToDecimal(oRow["收入体积"].ToString());
						}
						catch
						{
                            ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check8", string.Format("alert('{0} {1} 收入体积格式不对!');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
                            return;
						}
					}
					#endregion
					#region 收入数量
					if(oRow["收入数量"].ToString()==string.Empty)
					{
						dr[YCLData.InItemNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.InItemNum_Field] = Convert.ToDecimal(oRow["收入数量"].ToString());
						}
						catch
						{
							ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check9", string.Format("alert('收入数量格式不对!');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
							return;
						}
					}
					#endregion
					#region 发出体积
					if(oRow["发出体积"].ToString()==string.Empty)
					{
						dr[YCLData.OutVolNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(oRow["发出体积"].ToString());
						}
						catch
						{
                            ClientScript.RegisterStartupScript(this.GetType(), "Upload_Check10", string.Format("alert('{0} {1} 发出体积格式不对!');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
                            return;
						}
					}
					#endregion
					#region 发出数量
					if(oRow["发出数量"].ToString()==string.Empty)
					{
						dr[YCLData.OutItemNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(oRow["发出数量"].ToString());
						}
						catch
						{
							ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check11", "alert('发出数量格式不对!');", true);
							return;
						}
					}
					#endregion
					if(tempDS.Tables[0].Rows.Count > 0)
						tempDS.Tables[0].Rows.RemoveAt(0);
					tempDS.Tables[0].Rows.Add(dr);
					
					if (oItemSystem.AddYCL(tempDS)==false)
					{
                        ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check12", string.Format("alert('{0} {1} 数据导入失败!');", oRow["日期"].ToString(), oRow["编号"].ToString()), true);
                        return;
					}
					else
					{
						
					}
				}
			}
			this.UG_YCLDetail.DataBind();
			this.UG_YCLDetail.Bands[0].Key = "Parent";
			this.UG_YCLDetail.Bands[1].Key = "Child";
			ClientScript.RegisterStartupScript( this.GetType(), "Sucess", "alert('数据导入成功!');", true);
		}
		#endregion

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "search":
                    this.UG_YCLDetail.DataBind();	
                    break;
            }
        }
		
	}
}
