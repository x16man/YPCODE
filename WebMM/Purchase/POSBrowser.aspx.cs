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

using Shmzh.Components.SystemComponent.DALFactory;

namespace MZHMM.WebMM.Purchase
{
	using System.Data;
	using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;

	/// <summary>
	/// MRPBrowser 的摘要说明。
	/// </summary>
	public partial class POSBrowser : System.Web.UI.Page
	{
		#region 成员变量
		PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		
		POSData oPOSData;
		#endregion

		#region Property
		/// <summary>
		/// 是否显示供应商筛选器。
		/// </summary>
		public bool ShowPrvFilter
		{
			get
			{
				var obj = DataProvider.SettingProvider.GetByKey("ShowPrvFilter");
				return obj != null && obj.Value != "0";
			}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 绑定供应商。
		/// </summary>
		private void BindPrv()
		{
			this.tbiPrv.Items.Clear();
			if(this.oPOSData != null && oPOSData.Tables.Count>0&&oPOSData.Tables[0].Rows.Count > 0)
			{
				foreach(DataRow obj in oPOSData.Tables[0].Rows)
				{
					if(this.tbiPrv.Items.Count > 0)
					{
						var isExist = false;
						foreach(ListItem item in this.tbiPrv.Items)
						{
							if(item.Value == obj["PrvCode"].ToString())
							{
								isExist = true;
								break;
							}
						}
						if(!isExist)
						{
							this.tbiPrv.Items.Add(new ListItem(obj["PrvName"].ToString(), obj["PrvCode"].ToString()));
						}
					}
					else
					{
						this.tbiPrv.Items.Add(new ListItem(obj["PrvName"].ToString(), obj["PrvCode"].ToString()));
					}
				}
				this.tbiPrv.Items.Insert(0,new ListItem("全部","-99"));
			}
		}

		private void FilterSelected()
		{
			if (Session[MySession.ORD_DT] != null)
			{
				var dt = Session[MySession.ORD_DT] as DataTable;
				if (dt != null)
				{
					for (var i = oPOSData.Tables[0].Rows.Count - 1; i >= 0;i-- )
					{
						foreach (DataRow obj in dt.Rows)
						{
							if (oPOSData.Tables[0].Rows[i]["SourceEntry"].ToString() == obj["SourceEntry"].ToString() &&
									oPOSData.Tables[0].Rows[i]["SourceSerialNo"].ToString() == obj["SourceSerialNo"].ToString() &&
									oPOSData.Tables[0].Rows[i]["SourceDocCode"].ToString() == obj["SourceDocCode"].ToString())
							{
								oPOSData.Tables[0].Rows[i].Delete();
								Logger.Info("Delete");
								break;
							}
						}
					}
						
				}
			}
		}
		#endregion
		
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				oPOSData = oPurchaseSystem.GetPOSAll(Master.CurrentUser.thisUserInfo.LoginName);
				
				if(ShowPrvFilter)
				{
					this.BindPrv();
					this.FilterSelected();
					if (!string.IsNullOrEmpty(this.Request.QueryString["PrvCode"]))
					{
						this.tbiPrv.SelectedValue = this.Request.QueryString["PrvCode"];
						if(this.tbiPrv.SelectedValue != "-99")
						{
							var objs = new DataView(oPOSData.Tables[0], string.Format("PrvCode='{0}'", this.Request.QueryString["PrvCode"]), string.Empty, DataViewRowState.CurrentRows);
							
							this.DGModel_Items1.DataSource = objs;
							this.DGModel_Items1.DataBind();
						}
						else
						{
							this.DGModel_Items1.DataSource = oPOSData.Tables[0].DefaultView;
							this.DGModel_Items1.DataBind();
						}
					}
					else
					{
						this.DGModel_Items1.DataSource = oPOSData.Tables[0].DefaultView;
						this.DGModel_Items1.DataBind();
					}
				}
				else
				{
					this.FilterSelected();
					this.DGModel_Items1.DataSource = oPOSData.Tables[0].DefaultView;
					this.DGModel_Items1.DataBind();
				}
				
			}
		}

		/// <summary>
		/// 工具条事件。
		/// </summary>
		/// <param name="item"></param>
		protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
		{
			if (item.ItemId == "Prv")
			{
				oPOSData = oPurchaseSystem.GetPOSAll(Master.CurrentUser.thisUserInfo.LoginName);
				this.FilterSelected();

				if (this.tbiPrv.SelectedValue == "-99")
				{
					this.DGModel_Items1.DataSource = oPOSData;
					this.DGModel_Items1.DataBind();
				}
				else
				{
					var objs = new DataView(oPOSData.Tables[0], string.Format("PrvCode='{0}'", this.tbiPrv.SelectedValue), string.Empty, DataViewRowState.CurrentRows);
					this.DGModel_Items1.DataSource = objs;
					this.DGModel_Items1.DataBind();
				}
			}
		}
		#endregion

		

	   
	   

	}
}
