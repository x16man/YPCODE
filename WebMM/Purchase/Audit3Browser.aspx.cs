#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved


namespace MZHMM.WebMM.Purchase
{
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
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SelectEngine;
	using MZHMM.Common;
	using MZHMM.Facade;
	using MZHCommon.PageStyle;
	using MySys = Shmzh.Components.SystemComponent;
	using MZHCommon;
	/// <summary>
	/// ROSBrowser ��ժҪ˵����
	/// </summary>
	public partial class Audit3Browser : System.Web.UI.Page
	{
		#region ��Ա����
		protected System.Web.UI.WebControls.Button btn_delete;
		protected System.Web.UI.WebControls.Button btn_cancel;
		protected System.Web.UI.WebControls.Button btn_Submit;
		protected User myUser;
		//protected string action_new_hasRight;
//		private int DocCode;
//		private string AuthorCode;
//		private int AuditResult;
//		private string AuthorDept;
//		private DateTime StartDate;
//		private DateTime EndDate;

        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

        //SelectEngine oSelectEngine = new SelectEngine();

	    private string DocCode;
	    private string EntryNo;

	    private string strSQL;

		/// <summary>
		/// ��ǰ�Ĳ�ѯģ��ID��
		/// </summary>
		protected int QRYModuleID
		{
			get{return QRYModule.ROS;}
		}
		/// <summary>
		/// ��ǰ���û���
		/// </summary>
		protected string UserLoginId
		{
			get
			{
				if (this.Session[MySession.UserLoginId] != null && 
					this.Session[MySession.UserLoginId].ToString() != "")
				{
					return this.Session[MySession.UserLoginId].ToString();
				}
				else
				{
					return null;
				}
			}
		}
		protected string SQL
		{
			get 
			{
				return this.txtSQL.Text;
			}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ���ݰ󶨵�DataGrid��
		/// </summary>
		private void myDataBind()
		{
			
			//����û�û���趨Ĭ�ϵĲ�ѯ������������ģ��Ĭ�ϵĲ�ѯ������
			if (this.SQL == MyParm.NON_SQL )
				DataGrid1.DataSource=oPurchaseSystem.GetAudit3DataByToAudit(this.UserLoginId);
			else if (this.SQL != MyParm.NON_SQL )
				DataGrid1.DataSource = oPurchaseSystem.GetAudit3DataBySQL(this.SQL);
			try
			{
				DataGrid1.DataBind();
			}
			catch(Exception e)
			{
				if(e.Source=="System.Web" && DataGrid1.CurrentPageIndex>=1)
				{
					DataGrid1.CurrentPageIndex--;
					try
					{
						DataGrid1.DataBind();
					}
					catch
					{
						DataGrid1.CurrentPageIndex = 0;
						DataGrid1.DataBind();
					}
				}				
			}		
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
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

		}
		#endregion
	
		#region �¼�
		/// <summary>
		/// Page_Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
		    if(!IsPostBack)
			{
				this.ddlQrySolution.UserCode = Session[MySession.UserLoginId].ToString();
				this.ddlQrySolution.AutoPostBack = false;
				this.ddlQrySolution.QRYModuleID = QRYModuleID;
				this.ddlQrySolution.Module_Tag = (int)SDDLTYPE.QRYSLT;

				strSQL = new SelectEngine().GetDefaultSelectSqlByUserAndModule(QRYModuleID,Session[MySession.UserLoginId].ToString());
				if(!string.IsNullOrEmpty(strSQL))
					this.txtSQL.Text = strSQL;
				else
					this.txtSQL.Text = MyParm.NON_SQL;
				myDataBind();	
			}
		}


		#region DadaGrid�¼� "��","��ҳ","����"
		/// <summary>
		/// �󶨡�
		/// </summary>
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
//				e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
//				e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
//				e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
			    EntryNo = e.Item.Cells[0].Text.Split("|".ToCharArray())[0].ToString();
				DocCode = (e.Item.Cells[0].Text.Split("|".ToCharArray()))[1].ToString();
				switch (DocCode)
				{
					case "1"://�ɹ����뵥��
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('ROSDetail.aspx?Op=View&EntryNo={0}','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=no,location=no, status=no')",EntryNo));
						break;
					case "5"://�ɹ��ƻ���
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('PPReport.aspx?Op=View&EntryNo={0}','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no')",EntryNo));
						break;
					case "7"://�ɹ��˻�����
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('PRTVDetail.aspx?EntryNo={0}','browser','height=560,width=850,left='+(window.screen.width - 850)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')",EntryNo));
						break;
					case "16"://ά��ӹ����뵥��
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('../Storage/WTOWDetail.aspx?Op=View&EntryNo={0}','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')",EntryNo));
						break;
				}
//				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
//				e.Item.Attributes.Add("onclick","execClick(this)");
				if (e.Item.Cells[3].Text == "�½�" || 
					e.Item.Cells[3].Text == "�ύ" )
				{
					e.Item.BackColor =	Color.FromArgb(216,244,255);
				}
				else if (e.Item.Cells[3].Text == "����ͨ��")
				{
					e.Item.BackColor =	Color.FromArgb(181,255,136);
				}
				else if (e.Item.Cells[3].Text == "����")
				{
					e.Item.BackColor =	Color.FromArgb(212,208,200);
				}
				else if (e.Item.Cells[3].Text == "����ͨ��" ||
						e.Item.Cells[3].Text =="����ͨ��")
				{
					e.Item.BackColor = Color.FromArgb(153,204,255);
				}
				else
				{
					e.Item.BackColor =	Color.FromArgb(201,181,196);
				}
			}
		}
		/// <summary>
		/// ��ҳ��
		/// </summary>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			myDataBind();
		}
		/// <summary>
		/// ����
		/// </summary>
		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.myDataBind();
		}
		#endregion

		#region �����ؼ��õ��İ�ť�¼�

		/// <summary>
		/// ���ز�ѯ��ť�¼���
		/// </summary>
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{

			myDataBind();
		}

		/// <summary>
		/// ȷ����ť���ύ�¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSelect_Click(object sender, System.EventArgs e)
		{
			int solutionID = 0;
			string strSQL = "";
			if (ddlQrySolution.SelectedValue !=null && ddlQrySolution.SelectedValue !="")
				solutionID = int.Parse(this.ddlQrySolution.SelectedValue);
			strSQL= new SelectEngine().GetSelectSQLBySolutionID(solutionID);
			//this.Response.Write(strSQL);
			if(strSQL !=null && strSQL !="")
				this.txtSQL.Text = strSQL;

			this.myDataBind();
		}
		
		/// <summary>
		/// ������ķ������µ������б��,��Ϊ���ذ�ť�¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnResetDS_Click(object sender, System.EventArgs e)
		{
			this.ddlQrySolution.UserCode = Session[MySession.UserLoginId].ToString();
			this.ddlQrySolution.AutoPostBack = false;
			this.ddlQrySolution.QRYModuleID = QRYModuleID;
			this.ddlQrySolution.Module_Tag = (int)SDDLTYPE.QRYSLT;
			this.ddlQrySolution.myBindData();
			this.btnSelect.Visible = true;
		}

		#endregion

		#endregion

		
	}
}
