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
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHCommon;
using Shmzh.Components.SystemComponent;

namespace WebMM.Analysis
{
	/// <summary>
	/// DocRoute 的摘要说明。
	/// </summary>
	public partial class DocRoute : System.Web.UI.Page
	{
		private PurchaseSystem oPurchaseSystem;

        /// <summary>
        /// 当前用户。
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }

		private DocItemRouteData oDocItemRouteData;
		#region 入口属性，由URL传递进来。
		/// <summary>
		/// 当前单据的流水号。
		/// </summary>
		public int EntryNo
		{
			get {return int.Parse(this.Request["EntryNo"].ToString());}
		}
		/// <summary>
		/// 当前单据的类型。
		/// </summary>
		public int DocCode
		{
			get {return int.Parse(this.Request["DocCode"].ToString());}
		}
		/// <summary>
		/// 当前单据选中项的序号。
		/// </summary>
		public int SerialNo
		{
			get {return int.Parse(this.Request["SerialNo"].ToString());}
		}
		public string ItemCode
		{
			get {return this.Request["ItemCode"].ToString();}
		}
		#endregion

		#region 物料信息方法
		/// <summary>
		/// 物料信息。
		/// </summary>
		private void SetItemInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (this.EntryNo == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.EntryNo_Field].ToString())&&
					this.DocCode == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString())&&
					this.SerialNo == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.SerialNo_Field].ToString()))
				{
					((Label)this.WebPanel_Item.FindControl("lblItemCode")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemCode_Field].ToString();
					((Label)this.WebPanel_Item.FindControl("lblItemName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemName_Field].ToString();
					((Label)this.WebPanel_Item.FindControl("lblItemSpec")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemSpec_Field].ToString();
					((Label)this.WebPanel_Item.FindControl("lblItemUnit")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemUnitName_Field].ToString();
					((Label)this.WebPanel_Item.FindControl("lblItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
				}
			}
		}
		#endregion

		#region 紧急申购单方法
		/// <summary>
		/// 紧急申请单。
		/// </summary>
		private void SetRosInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (1 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
				    this.WebPanel_Ros.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosReqReason")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ReqReason_Field].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosEntryDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.EntryDate_Field].ToString()).ToShortDateString();
					((Label)this.WebPanel_Ros.FindControl("lblRosAssessor1")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor1_Field].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosAssessor2")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor2_Field].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosAssessor3")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor3_Field].ToString();
					try
					{
						((Label)this.WebPanel_Ros.FindControl("lblRosAuditDate1")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate1_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					try
					{
						((Label)this.WebPanel_Ros.FindControl("lblRosAuditDate2")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate2_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					try
					{
						((Label)this.WebPanel_Ros.FindControl("lblRosAuditDate3")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate3_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Ros.FindControl("lblRosItemLackNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemLackNum_Field].ToString();
					((Label)this.WebPanel_Ros.FindControl("lblRosItemNodrawNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNodrawNum_Field].ToString();
				    break;
				}
			}
		}
		#endregion
        
		#region 月度计划需求单方法
		private void SetMrpInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (2 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.WebPanel_Mrp.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();
					((Label)this.WebPanel_Mrp.FindControl("lblMrpAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					((Label)this.WebPanel_Mrp.FindControl("lblMrpItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
					((Label)this.WebPanel_Mrp.FindControl("lblMrpReqReason")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ReqReason_Field].ToString();
					((Label)this.WebPanel_Mrp.FindControl("lblMrpEntryDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.EntryDate_Field].ToString()).ToShortDateString();
					((Label)this.WebPanel_Mrp.FindControl("lblMrpAssessor1")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor1_Field].ToString();
					try
					{
						((Label)this.WebPanel_Mrp.FindControl("lblMrpAuditDate1")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate1_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Mrp.FindControl("lblMrpItemLackNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuditDate3_Field].ToString();
					((Label)this.WebPanel_Mrp.FindControl("lblMrpItemNodrawNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuditDate3_Field].ToString();
				    break;
				}
			}	
		}
		#endregion

		#region 采购计划方法
		private void SetPlanInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (5 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.WebPanel_Plan.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();
                    ((Label)this.WebPanel_Plan.FindControl("lblPlanAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					((Label)this.WebPanel_Plan.FindControl("lblPlanItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
					((Label)this.WebPanel_Plan.FindControl("lblPlanReqDeptName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ReqDeptName_Field].ToString();					
					((Label)this.WebPanel_Plan.FindControl("lblPlanReqReason")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ReqReason_Field].ToString();
					((Label)this.WebPanel_Plan.FindControl("lblPlanAssessor1")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor1_Field].ToString();
					((Label)this.WebPanel_Plan.FindControl("lblPlanAssessor2")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor2_Field].ToString();
					((Label)this.WebPanel_Plan.FindControl("lblPlanAssessor3")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor3_Field].ToString();
					try
					{
						((Label)this.WebPanel_Plan.FindControl("lblPlanAuditDate1")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate1_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					try
					{
						((Label)this.WebPanel_Plan.FindControl("lblPlanAuditDate2")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate2_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					try
					{
						((Label)this.WebPanel_Plan.FindControl("lblPlanAuditDate3")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate3_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Plan.FindControl("lblPlanItemLackNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemLackNum_Field].ToString();
				    break;
				}
			}
		}
		#endregion

		#region 采购订单方法
		private void SetOrderInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (3 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.WebPanel_Order.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();

					((Label)this.WebPanel_Order.FindControl("lblOrderAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					((Label)this.WebPanel_Order.FindControl("lblOrderItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
					((Label)this.WebPanel_Order.FindControl("lblOrderPrvName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.PrvName_Field].ToString();					
					((Label)this.WebPanel_Order.FindControl("lblOrderBuyerName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.BuyerName_Field].ToString();
					((Label)this.WebPanel_Order.FindControl("lblOrderEntryDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.EntryDate_Field].ToString()).ToShortDateString();
					try
					{
						((Label)this.WebPanel_Order.FindControl("lblOrderAffirmDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Order.FindControl("lblOrderAssessor1")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor1_Field].ToString();
					try
					{
						((Label)this.WebPanel_Order.FindControl("lblOrderAuditDate1")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate1_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Order.FindControl("lblOrderItemLackNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemLackNum_Field].ToString();
				    break;
				}
			}
		}
		#endregion

		#region 采购收料单方法
		private void SetBorInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{

				if (6 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.WebPanel_Bor.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();
                    ((Label)this.WebPanel_Bor.FindControl("lblBorAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					((Label)this.WebPanel_Bor.FindControl("lblBorEntryDate")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
					((Label)this.WebPanel_Bor.FindControl("lblBorPrvName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.PrvName_Field].ToString();					
					((Label)this.WebPanel_Bor.FindControl("lblBorBuyerName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.BuyerName_Field].ToString();
					((Label)this.WebPanel_Bor.FindControl("lblBorInvoiceNo")).Text = oData.Tables[0].Rows[i][DocItemRouteData.InvoiceNo_Field].ToString();
					((Label)this.WebPanel_Bor.FindControl("lblBorContractCode")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ContractCode_Field].ToString();

					((Label)this.WebPanel_Bor.FindControl("lblBorItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
                    if (CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.BORCstPrice))
                    {
                        ((Label)this.WebPanel_Bor.FindControl("lblBorItemPrice")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemPrice_Field].ToString();
                        ((Label)this.WebPanel_Bor.FindControl("lblBorItemSum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemMoney_Field].ToString();
                    }
                    ((Label)this.WebPanel_Bor.FindControl("lblBorAssessor1")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor1_Field].ToString();
					try
					{
						((Label)this.WebPanel_Bor.FindControl("lblBorAuditDate1")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate1_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Bor.FindControl("lblBorAcceptName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AcceptName_Field].ToString();
					try
					{
						((Label)this.WebPanel_Bor.FindControl("lblBorAcceptDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field].ToString()).ToShortDateString();
					}
					catch
					{}
				    break;
				}
			}
		}
		#endregion
		
		#region 付款单方法
		private void SetPayInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (14 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.WebPanel_Pay.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();

					((Label)this.WebPanel_Pay.FindControl("lblPayAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					((Label)this.WebPanel_Pay.FindControl("lblPayEntryDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.EntryDate_Field].ToString()).ToShortDateString();
					((Label)this.WebPanel_Pay.FindControl("lblPayAssessor3")).Text = oData.Tables[0].Rows[i][DocItemRouteData.Assessor3_Field].ToString();
					try
					{
						((Label)this.WebPanel_Pay.FindControl("lblPayAuditDate3")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AuditDate3_Field].ToString()).ToShortDateString();
					}
					catch
					{}
					((Label)this.WebPanel_Pay.FindControl("lblPayPayerName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.PayerName_Field].ToString();
					try
					{
						((Label)this.WebPanel_Pay.FindControl("lblPayPayDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field].ToString()).ToShortDateString();
					}
					catch
					{}
				    break;
				}
			}
		}
		#endregion
		
		#region 领料单
		private void SetWdrwInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (4 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.WebPanel_Draw.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();
                    ((Label)this.WebPanel_Draw.FindControl("lblDrawAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					if (oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field] != System.DBNull.Value)
						((Label)this.WebPanel_Draw.FindControl("lblDrawAcceptDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field].ToString()).ToShortDateString();
					((Label)this.WebPanel_Draw.FindControl("lblDrawReqReason")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ReqReason_Field].ToString();
					((Label)this.WebPanel_Draw.FindControl("lblDrawItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
				    break;
				}
			}
		}
		#endregion

		#region 生产退料单
		private void SetWRTSInfo(DocItemRouteData oData)
		{
			for (int i=0; i<oData.Count; i++)
			{
				if (8 == int.Parse(oData.Tables[0].Rows[i][DocItemRouteData.DocCode_Field].ToString()))
				{
                    this.Webpanel_RTS.Header.Text += oData.Tables[0].Rows[i]["EntryNo"].ToString();
                    ((Label)this.Webpanel_RTS.FindControl("lblRTSAuthorName")).Text = oData.Tables[0].Rows[i][DocItemRouteData.AuthorName_Field].ToString();
					if (oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field] != System.DBNull.Value)
						((Label)this.Webpanel_RTS.FindControl("lblRTSDate")).Text = Convert.ToDateTime(oData.Tables[0].Rows[i][DocItemRouteData.AcceptDate_Field].ToString()).ToShortDateString();
					((Label)this.Webpanel_RTS.FindControl("lblRTSReqReason")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ReqReason_Field].ToString();
					((Label)this.Webpanel_RTS.FindControl("lblRTSItemNum")).Text = oData.Tables[0].Rows[i][DocItemRouteData.ItemNum_Field].ToString();
				    break;
				}
			}
		}
		#endregion
		#region 私有方法
		/// <summary>
		/// 根据单据类型、单据流水号、项的序号获取并设置有关物料的信息。
		/// </summary>
		/// <param name="EntryNo">单据流水号。</param>
		/// <param name="DocCode">单据类型。</param>
		/// <param name="SerialNo">项序号</param>
		private void SetItemInfo(int EntryNo,int DocCode, int SerialNo)
		{
			//TODO:在WebPanel_Item标题栏上显示当前单据的信息。单据类型名称 单据号。

			//TODO:设定物料信息。
		}
		
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				oPurchaseSystem = new PurchaseSystem();
				oDocItemRouteData = oPurchaseSystem.GetDocItemRouteData(this.EntryNo,this.DocCode,this.SerialNo,this.ItemCode);

				this.SetItemInfo(oDocItemRouteData);
				this.SetRosInfo(oDocItemRouteData);
				this.SetMrpInfo(oDocItemRouteData);
				this.SetPlanInfo(oDocItemRouteData);
				this.SetOrderInfo(oDocItemRouteData);
				this.SetBorInfo(oDocItemRouteData);
				this.SetPayInfo(oDocItemRouteData);
				this.SetWdrwInfo(oDocItemRouteData);
				this.SetWRTSInfo(oDocItemRouteData);
				this.WebPanel_Ros.Visible = false;
				this.WebPanel_Mrp.Visible = false;
				this.WebPanel_Plan.Visible = false;
				this.WebPanel_Order.Visible = false;
				this.WebPanel_Bor.Visible = false;
				this.WebPanel_Pay.Visible = false;
				this.WebPanel_Draw.Visible = false;
				this.Webpanel_RTS.Visible = false;
				for (int i=0;i<oDocItemRouteData.Count;i++)
				{
					switch (int.Parse(oDocItemRouteData.Tables[0].Rows[i]["DocCode"].ToString()))
					{
						case DocType.ROS:
							this.WebPanel_Ros.Visible = true;
							break;
						case DocType.MRP:
							this.WebPanel_Mrp.Visible = true;
							break;
						case DocType.PP:
							this.WebPanel_Plan.Visible = true;
							break;
						case DocType.PO:
							this.WebPanel_Order.Visible = true;
							break;
						case DocType.BOR:
							this.WebPanel_Bor.Visible = true;
							break;
						case DocType.PAY:
							this.WebPanel_Pay.Visible = true;
							break;
						case DocType.DRW:
							this.WebPanel_Draw.Visible = true;
							break;
						case DocType.RTS:
							this.Webpanel_RTS.Visible = true;
							break;
					}
				}
			}
		}
	}
}
