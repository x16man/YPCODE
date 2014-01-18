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
	/// YCLGroupBrowser ��ժҪ˵����
	/// </summary>
	public partial class YCLGroupBrowser : Page
	{
		#region ��Ա����
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

		#region ����
		/// <summary>
		/// ��ʼ���ڡ�
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
		/// �������ڡ�
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
		/// ���ϱ�š�
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
		/// �ͻ���ȷ�϶Ի���ķ���ֵ.
		/// </summary>
		protected string ConfirmResult
		{
			get {return this.txtConfirmResult.Value;}
			set {this.txtConfirmResult.Value=value;}
		}
		#endregion
		
		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.UG_YCLDetail.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UG_YCLDetail_InitializeRow);
			this.UG_YCLDetail.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UG_YCLDetail_InitializeLayout);

		}
		#endregion

		#region ����
		/// <summary>
		/// ��ȡExcel��DataSet��.
		/// </summary>
		/// <param name="Path">Excel�ļ���·��.</param>
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

		#region �¼�
		/// <summary>
		/// ҳ������¼�.
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
		/// �༭��ť�¼�.
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
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('��ѡ��һ�����б༭!');", true);
                    
            }
		}

		/// <summary>
		/// �½���ť�¼�.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			this.Response.Redirect("YCLInput.aspx?Op=New",true);
		}

		/// <summary>
		/// ɾ����ť�¼�.
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
                ClientScript.RegisterStartupScript(this.GetType(), "delete", "alert('��ѡ��һ����¼ɾ��');", true);
                return;
            }
		}

		/// <summary>
		/// Grid�ؼ���ʼ������¼�.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UG_YCLDetail_InitializeLayout(object sender, LayoutEventArgs e)
		{
			this.UG_YCLDetail.DisplayLayout.ViewType = ViewType.Hierarchical;

			this.UG_YCLDetail.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			
			
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemCode").Header.Caption = "���";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemName").Header.Caption = "����";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("ItemUnitName").Header.Caption = "��λ";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("StartItemNum").Header.Caption = "�ڳ�";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("InItemNum").Header.Caption = "����";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("OutItemNum").Header.Caption = "����";
			this.UG_YCLDetail.Bands[0].Columns.FromKey("EndItemNum").Header.Caption = "���";

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
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemCode").Header.Caption = "���";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemName").Header.Caption = "����";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("ItemUnitName").Header.Caption = "��λ";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("StartItemNum").Header.Caption = "�ڳ�";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("InItemNum").Header.Caption = "����";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OutItemNum").Header.Caption = "����";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("EndItemNum").Header.Caption = "���";
			this.UG_YCLDetail.Bands[1].Columns.FromKey("OpDate").Header.Caption = "����";

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
		/// Grid�ؼ����ݰ��¼�.
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
		/// ȷ����ť�¼�.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnYes_Click(object sender, EventArgs e)
		{
			this.UG_YCLDetail.DataBind();	
		}

		/// <summary>
		/// Grid�ؼ��г�ʼ���¼�.
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
		/// �ϴ�EXCEL�ļ�.
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
                //Logger.Info("���" + oRow["���"].ToString());
               // Logger.Info("����" + oRow["����"].ToString());
				#region Key_Item_Date
				try
				{
                    
					key_Item_Date =
						string.Format("{0} {1}", oRow["���"].ToString().Trim(), (Convert.ToDateTime(oRow["����"].ToString())).ToShortDateString());
				}
				catch
				{
					ClientScript.RegisterStartupScript( this.GetType(), "Upload_Null", "alert('���ڻ����ϱ�Ų���Ϊ��!');", true);
					return;
				}
				if(oHT_Item_Date.ContainsKey(key_Item_Date))
				{
                    ClientScript.RegisterStartupScript( this.GetType(), "Upload_Same", string.Format("alert('{0} ���ظ��ļ�¼,һ��������һ��ֻ����һ����¼.');", key_Item_Date), true);
                    return;
				}
				else
				{
					oHT_Item_Date.Add(key_Item_Date,null);	
				}
				#endregion

				#region ������� ��С����
				if(oHT_MinDate.ContainsKey(oRow["���"].ToString()))
				{
					if(DateTime.Parse(oRow["����"].ToString())<=DateTime.Parse(oHT_MinDate[oRow["���"].ToString()].ToString()))
					{
						oHT_MinDate[oRow["���"]] = DateTime.Parse(oRow["����"].ToString());
					}
					else
					{
						oHT_MaxDate[oRow["���"]] = DateTime.Parse(oRow["����"].ToString());
					}
				}
				else//�����Hashtable��������ϵļ�¼�в�����.
				{
					oHT_MinDate.Add(oRow["���"].ToString(),DateTime.Parse(oRow["����"].ToString()));
				}
				#endregion

				#region �ж����ָ�ʽ�Ƿ�Ϸ�
				try
				{
					inNum = oRow["��������"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["��������"].ToString());
					outNum = oRow["��������"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["��������"].ToString());
					inVol = oRow["�������"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["�������"].ToString());
					outVol = oRow["�������"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["�������"].ToString());
					if(inNum<0 || inVol<0 || outNum<0 || outVol<0)
					{
						ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check1", "alert('��������Ϊ��');", true);
						return;
					}
					if (inNum > 1000000000 || inVol >100000000 || outNum > 1000000000 || outVol > 1000000000)
					{
                        ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check2", string.Format("alert('{0} {1}�������ܴ���1000000000.');", oRow["����"].ToString(), oRow["���"].ToString()), true);
                        return;
					}
				}
				catch
				{
					ClientScript.RegisterStartupScript(this.GetType(), "Upload_Check3", string.Format("alert('{0} {1}���������򷢳�������ʽ����!');", oRow["����"].ToString(), oRow["���"].ToString()), true);
                       
					return;
				}
				#endregion

			}
			#region �Ƿ��Ѵ����ظ���¼ �Լ������ϱ���Ƿ����.
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
					if (tempYCLData.Tables[0].Rows.Count > 0 && this.CheckBox_IsOverWrite.Checked==false)//�Ѵ����ظ���¼,����û��ȷ��Ҫ����.
					{
						alertString = "alert('ϵͳ��Excelָ�������ڷ�Χ��,�Ѿ��������շ���¼!');";
						
						if(!Page.IsClientScriptBlockRegistered("ConfirmDelete"))
						{
                           
							ClientScript.RegisterStartupScript( this.GetType(), "ConfirmDelete", alertString, true);
						}
						return;
					}
					else if(tempYCLData.Tables[0].Rows.Count >0 && this.CheckBox_IsOverWrite.Checked==true )
					{
						//TODO:ɾ���ظ���¼.
						for(i=tempYCLData.Tables[0].Rows.Count-1;i>=0;i--)
						{
							if(!oItemSystem.DeleteYCL(int.Parse(tempYCLData.Tables[0].Rows[i]["PKID"].ToString())))
							{
								this.ConfirmResult = string.Empty;
                                ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check4", "alert('ɾ��ԭ�����շ���¼ʧ��!PKID=" + tempYCLData.Tables[0].Rows[i]["PKID"].ToString() + "');", true);
                                return;
							}
						}
					}
				}
				else
				{
					this.ConfirmResult=string.Empty;
                    ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check5", "alert('" + string.Format("{0} �����ڵ����ϱ��!", okey.ToString()) + "');", true);
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
					inNum = oRow["��������"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["��������"].ToString());
					outNum = oRow["��������"].ToString() == string.Empty ? 0 : Convert.ToDecimal(oRow["��������"].ToString());
				}
				catch
				{
					ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check6", string.Format("alert('���������򷢳�������ʽ����!');", oRow["����"].ToString(), oRow["���"].ToString()), true);
                    return;
				}
				if (inNum+outNum != 0)//�շ���Ϊ��ļ�¼��������.
				{
					dr = tempDS.Tables[YCLData.YCL_Table].NewRow();
					dr[YCLData.PKID_Field] = DBNull.Value;
					dr[YCLData.ItemCode_Field] = oRow["���"];//���
					dr[YCLData.ItemName_Field] = oRow["����"];//����
					
					#region ����
					try
					{
						dr[YCLData.OpDate_Field] = DateTime.Parse(oRow["����"].ToString());
					}
					catch
					{
						ClientScript.RegisterStartupScript(this.GetType(), "Upload_Check7", string.Format("alert('{0} ���ڸ�ʽ����!');", oRow["���"].ToString()), true);
						return;
					}
					#endregion
					#region �������
					if(oRow["�������"].ToString()==string.Empty)
					{
						dr[YCLData.InVolNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.InVolNum_Field] = Convert.ToDecimal(oRow["�������"].ToString());
						}
						catch
						{
                            ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check8", string.Format("alert('{0} {1} ���������ʽ����!');", oRow["����"].ToString(), oRow["���"].ToString()), true);
                            return;
						}
					}
					#endregion
					#region ��������
					if(oRow["��������"].ToString()==string.Empty)
					{
						dr[YCLData.InItemNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.InItemNum_Field] = Convert.ToDecimal(oRow["��������"].ToString());
						}
						catch
						{
							ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check9", string.Format("alert('����������ʽ����!');", oRow["����"].ToString(), oRow["���"].ToString()), true);
							return;
						}
					}
					#endregion
					#region �������
					if(oRow["�������"].ToString()==string.Empty)
					{
						dr[YCLData.OutVolNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.OutVolNum_Field] = Convert.ToDecimal(oRow["�������"].ToString());
						}
						catch
						{
                            ClientScript.RegisterStartupScript(this.GetType(), "Upload_Check10", string.Format("alert('{0} {1} ���������ʽ����!');", oRow["����"].ToString(), oRow["���"].ToString()), true);
                            return;
						}
					}
					#endregion
					#region ��������
					if(oRow["��������"].ToString()==string.Empty)
					{
						dr[YCLData.OutItemNum_Field] = 0;
					}
					else
					{
						try
						{
							dr[YCLData.OutItemNum_Field] = Convert.ToDecimal(oRow["��������"].ToString());
						}
						catch
						{
							ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check11", "alert('����������ʽ����!');", true);
							return;
						}
					}
					#endregion
					if(tempDS.Tables[0].Rows.Count > 0)
						tempDS.Tables[0].Rows.RemoveAt(0);
					tempDS.Tables[0].Rows.Add(dr);
					
					if (oItemSystem.AddYCL(tempDS)==false)
					{
                        ClientScript.RegisterStartupScript( this.GetType(), "Upload_Check12", string.Format("alert('{0} {1} ���ݵ���ʧ��!');", oRow["����"].ToString(), oRow["���"].ToString()), true);
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
			ClientScript.RegisterStartupScript( this.GetType(), "Sucess", "alert('���ݵ���ɹ�!');", true);
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
