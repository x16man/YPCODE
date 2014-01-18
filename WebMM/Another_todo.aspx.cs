using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Shmzh.Components.WorkFlow;
using MZHMM.Common;
using MZHMM.Facade;
using MZHCommon.PageStyle;
using MySys = Shmzh.Components.SystemComponent;
namespace MZHMM.WebMM
{
	/// <summary>
	/// 主管厂长的代办事宜页。
	/// </summary>
	public partial class Another_todo : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		//	this.Response.Write("主管厂长代办事宜");

			// 在此处放置用户代码以初始化页面
			if (!IsPostBack) 
			{
				
				BindData();
			}
		}

		private void BindData()
		{
			Shmzh.Components.WorkFlow.Task myTask = new Shmzh.Components.WorkFlow.Task();
			this.MzhDataGrid1.DataSource = myTask.GetAllTasksByUser(Session[MySession.UserLoginId].ToString()).Tables[0];
			this.MzhDataGrid2.DataSource = myTask.GetLatestDoneTasksByUser(Session[MySession.UserLoginId].ToString()).Tables[0];
			int count = myTask.GetLatestDoneTasksByUser(Session[MySession.UserLoginId].ToString()).Tables[0].Rows.Count;
			this.MzhDataGrid3.DataSource = myTask.GetLatestDoneTasksByUser(Session[MySession.UserLoginId].ToString()).Tables[0];
			this.MzhDataGrid1.DataBind();
			this.MzhDataGrid2.DataBind();
            this.MzhDataGrid3.DataBind();
		}

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

		}
		#endregion
		/// <summary>
		/// 获取被选中的Task_ID.
		/// </summary>
		/// <returns>string:	选中的Task_ID串。</returns>
		private string GetSelectedTaskID()
		{
			string SelectedTaskID = "";
			
			foreach(DataGridItem i in this.MzhDataGrid1.Items)
			{
				CheckBox deleteChkBxItem = (CheckBox) i.FindControl ("DeleteThis");
				if (deleteChkBxItem.Checked) 
				{
					SelectedTaskID += ((TextBox) i.FindControl ("txtTask_ID")).Text.ToString() + ",";
				}
			}
			return SelectedTaskID;
		}
		protected void btnYes_Top_Click(object sender, System.EventArgs e)
		{
			string TaskIDs;
			string UserLoginId;
			string Assessor;
			string EntryState;
			string Flag;

			TaskIDs = this.GetSelectedTaskID();
			Assessor = Session[MySession.UserName].ToString();
			UserLoginId = Session[MySession.UserLoginId].ToString();
			EntryState = "T";
			Flag = "Y";
		    
			new PurchaseSystem().BatchThirdAudit(TaskIDs,Assessor,UserLoginId,EntryState,Flag);

			
		
			BindData();
			
		}

		protected void btnNo_Top_Click(object sender, System.EventArgs e)
		{
			string TaskIDs;
			string UserLoginId;
			string Assessor;
			string EntryState;
			string Flag;

			TaskIDs = this.GetSelectedTaskID();
			Assessor = Session[MySession.UserName].ToString();
			UserLoginId = Session[MySession.UserLoginId].ToString();
			EntryState = "Z";
			Flag = "N";
			//三级审批。
			new PurchaseSystem().BatchThirdAudit(TaskIDs,Assessor,UserLoginId,EntryState,Flag);

			
			
			BindData();
			
		}
	}
}
