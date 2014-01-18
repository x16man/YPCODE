using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;
using System.Collections.Generic;
using Shmzh.MM.Common.Storage;
using Shmzh.MM.DataAccess.Storage;
//using MZHCommon.PageStyle;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit ��ժҪ˵����
	/// </summary>
	public partial class ConChooser : System.Web.UI.Page
	{
		#region ��Ա����

		protected ConChooserWebControl UCStockChoice;
		protected int DocCode;
		//protected int EntryNo;
		protected string SerialNoList;
		protected string ItemCodeList;
		protected string ItemNameList;
		protected string ItemSpecList;
		protected string ItemNumList;
		private static DataTable DrawDT;
		//private bool IsTODO = false;

        ItemSystem oItemSystem = new ItemSystem();

	    private Col2List MyCol2List;

	    private Col2List MyCol2List1;

	    private Col2List MyCol2List2;

      
        string PKIDList;
        string ItemDrawNumList;
        string UserCode;
        string UserName;
        string UserLoginId;
        string ItemPriceList;
        bool ret;

	    private decimal sumItemDrawNum;
	    private decimal sumItemNum;
	    private int i;
		#endregion

		#region ˽�з���
		private void myDataBind()
		{
			if(DrawDT.Rows.Count > 0)
			{
				MyCol2List = new Col2List(DrawDT);
				SerialNoList = MyCol2List.GetList();
				ItemCodeList = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
				ItemNameList = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
				ItemSpecList = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
				ItemNumList = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
				
				
				this.UCStockChoice.thisTable = oItemSystem.GetStockChoice(this.DocCode,Master.EntryNo,SerialNoList,ItemCodeList,ItemNumList).Tables[StockChoiceData.StockChoice_Table];

				try
				{
					this.UCStockChoice.DataBind();
				}
				catch(Exception e)
				{
					if(e.Source=="System.Web" )
					{
						this.UCStockChoice.DataBind();
					}	
				}
			}
		}
        private void InventoryShortageDataBind()
        {
            if (Session["InventoryShortageDetailInfos"] != null)
            {
                var objs = Session["InventoryShortageDetailInfos"] as List<InventoryShortageDetailInfo>;
                foreach (var obj in objs)
                {
                    SerialNoList += obj.SerialNo.ToString() + ",";
                    ItemCodeList += obj.ItemCode.ToString() + ",";
                    ItemNameList += obj.ItemName.ToString() + ",";
                    ItemSpecList += obj.ItemSpec.ToString() + ",";
                    ItemNumList += obj.ItemNum.ToString() + ",";
                }
                SerialNoList = SerialNoList.Substring(0, SerialNoList.Length - 1);
                ItemCodeList = ItemCodeList.Substring(0, ItemCodeList.Length - 1);
                ItemNameList = ItemNameList.Substring(0, ItemNameList.Length - 1);
                ItemSpecList = ItemSpecList.Substring(0, ItemSpecList.Length - 1);
                ItemNumList = ItemNumList.Substring(0, ItemNumList.Length - 1);

                this.UCStockChoice.thisTable = oItemSystem.GetStockChoice(this.DocCode, Master.EntryNo, SerialNoList, ItemCodeList, ItemNumList).Tables[StockChoiceData.StockChoice_Table];

                try
                {
                    this.UCStockChoice.DataBind();
                }
                catch (Exception e)
                {
                    if (e.Source == "System.Web")
                    {
                        this.UCStockChoice.DataBind();
                    }
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "none", "alert('no record');", true);
            }
        }
		#endregion

		#region �¼�
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!string.IsNullOrEmpty(this.Request["DocCode"]))
			{
				DocCode = int.Parse(this.Request["DocCode"].ToString());
			}
			
			if (!this.IsPostBack)
			{
                if(DocCode != 20)
                {
				    if (Session[MySession.DrawDt] != null)
				    {
					    DrawDT = (DataTable)Session[MySession.DrawDt];
				    }
				    this.myDataBind();
                }
                else
                {
                    this.InventoryShortageDataBind();
                }
			}
			
		}
		/// <summary>
		/// ��ҳ�¼���
		/// </summary>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
            if (DocCode == 20)
                myDataBind();
            else
                this.InventoryShortageDataBind();
		}
		/// <summary>
		/// ȷ����ť�¼���
		/// </summary>
		protected void btnYes_Click(object sender, System.EventArgs e)
		{
		    SerialNoList = "";
            ItemNumList = "";
            PKIDList = "";
            ItemDrawNumList = "";
            UserCode = "";
            UserName = "";
            UserLoginId = "";
            ItemPriceList = "";
           
			#region �жϼ�λ�ϵ�ʵ������ǰ��ҳ����ѡȡ��ʵ�������Ƿ�һ��
			sumItemDrawNum=0;
			sumItemNum=0;
            if (DocCode != 20)
            {
                for (i = 0; i < DrawDT.Rows.Count; i++)
                {
                    if (DrawDT.Rows[i][InItemData.ITEMNUM_FIELD] != DBNull.Value)
                    {
                        sumItemNum += Convert.ToDecimal(DrawDT.Rows[i][InItemData.ITEMNUM_FIELD].ToString());
                    }
                }
                for (i = 0; i < this.UCStockChoice.thisTable.Rows.Count; i++)
                {
                    if (this.UCStockChoice.thisTable.Rows[i][StockData.ITEMNUM_FIELD] != DBNull.Value)
                    {
                        sumItemDrawNum += Convert.ToDecimal(this.UCStockChoice.thisTable.Rows[i][StockData.ITEMNUM_FIELD].ToString());
                    }
                }
            }
            else
            {
                var objs = Session["InventoryShortageDetailInfos"] as List<InventoryShortageDetailInfo>;
                sumItemNum = objs.Sum(obj => obj.ItemNum);

                for (i = 0; i < this.UCStockChoice.thisTable.Rows.Count; i++)
                {
                    if (this.UCStockChoice.thisTable.Rows[i][StockData.ITEMNUM_FIELD] != DBNull.Value)
                    {
                        sumItemDrawNum += Convert.ToDecimal(this.UCStockChoice.thisTable.Rows[i][StockData.ITEMNUM_FIELD].ToString());
                    }
                }
            }
			if(sumItemNum!=sumItemDrawNum)
			{
				switch(this.DocCode)
				{
					case DocType.TRF:
						this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=���ѡ���ʵ����Ӧ��ת�ⵥ�ϵ�ʵת����һ��" ,true);
						break;
					case DocType.SCR:
                        this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=���ѡ���ʵ����Ӧ�뱨�ϵ��ϵ�ʵ������һ��", true);
						break;
					case DocType.DRW:
                        this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=���ѡ���ʵ����Ӧ�����ϵ��ϵ�ʵ������һ��", true);
						break;
					case DocType.RTV:
						this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=���ѡ���ʵ����Ӧ��ɹ��˻����ϵ�ʵ������һ��" ,true);
						break;
                    case DocType.INVENTORYSHORTAGE:
                        this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=���ѡ���ʵ����Ӧ���̿����ϵ�ʵ������һ��", true);
                        break;
				}
				
			}
				

			#endregion

            if (DocCode != 20)
            {
                //���ϵ��ϵ�ʵ�����ݡ�
                MyCol2List1 = new Col2List(DrawDT);
                SerialNoList = MyCol2List1.GetList(InItemData.SERIALNO_FIELD);
                ItemNumList = MyCol2List1.GetList(InItemData.ITEMNUM_FIELD);
                ItemPriceList = MyCol2List1.GetList(InItemData.ITEMPRICE_FIELD);


                //���ѡ���ϵ����ݡ�
                MyCol2List2 = new Col2List(this.UCStockChoice.thisTable);
                PKIDList = MyCol2List2.GetList(StockData.PKID_FIELD);
                ItemDrawNumList = MyCol2List2.GetList(StockData.ITEMNUM_FIELD);
                UserCode = Master.CurrentUser.thisUserInfo.EmpCode;
                UserName = Master.CurrentUser.thisUserInfo.EmpName;
                UserLoginId = Master.CurrentUser.thisUserInfo.LoginName;
            }
            else
            {
                var objs = Session["InventoryShortageDetailInfos"] as List<InventoryShortageDetailInfo>;
                foreach (var obj in objs)
                {
                    SerialNoList += obj.SerialNo.ToString() + ",";
                    ItemNumList += obj.ItemNum.ToString() + ",";
                    ItemPriceList += obj.ItemPrice.ToString() + ",";
                }
                SerialNoList = SerialNoList.Substring(0, SerialNoList.Length - 1);
                ItemNumList = ItemNumList.Substring(0, ItemNumList.Length - 1);
                ItemPriceList = ItemPriceList.Substring(0, ItemPriceList.Length - 1);
                //���ѡ���ϵ����ݡ�
                MyCol2List2 = new Col2List(this.UCStockChoice.thisTable);
                PKIDList = MyCol2List2.GetList(StockData.PKID_FIELD);
                ItemDrawNumList = MyCol2List2.GetList(StockData.ITEMNUM_FIELD);
                UserCode = Master.CurrentUser.thisUserInfo.EmpCode;
                UserName = Master.CurrentUser.thisUserInfo.EmpName;
                UserLoginId = Master.CurrentUser.thisUserInfo.LoginName;
            }
			
			switch(this.DocCode)
			{
				case DocType.TRF:
					ret = oItemSystem.TransDrawOutStock(Master.EntryNo,SerialNoList,ItemNumList,PKIDList,ItemDrawNumList,UserCode,UserName,UserLoginId);
					break;
				case DocType.SCR:
                    ret = oItemSystem.DiscardWSCR(Master.EntryNo, SerialNoList, ItemNumList, PKIDList, ItemDrawNumList, UserCode, UserName, UserLoginId);
					break;
				//�������ϵ�����
				case DocType.RTV:
					if(MyCol2List1.GetSum(InItemData.ITEMNUM_FIELD)!=MyCol2List2.GetSum(StockData.ITEMNUM_FIELD))
						Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo="+"���ϵ�ʵ�������Ͳֿ�ѡ��ķ����������ȣ����ܷ��ϣ�");
                    ret = oItemSystem.RTVReceive(Master.EntryNo, SerialNoList, ItemNumList, PKIDList, ItemDrawNumList, UserCode, UserName, UserLoginId, ItemPriceList);
					break;
                case DocType.INVENTORYSHORTAGE:
                    ret = new InventoryShortages().DrawOutStock(Master.EntryNo, SerialNoList, ItemNumList, PKIDList, ItemDrawNumList, UserCode, UserName, UserLoginId);
                    break;
				default://���ϵ���
                    ret = oItemSystem.DrawOutStock(Master.EntryNo, SerialNoList, ItemNumList, PKIDList, ItemDrawNumList, UserCode, UserName, UserLoginId);
					break;
			}

			if (ret == false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
			else
			{
				if (Master.IsTODO)
				{
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
					switch(this.DocCode)
					{
						case DocType.TRF:
							Response.Redirect("TransBrowser.aspx");
							break;
						case DocType.SCR:
							Response.Redirect("OutBrowser.aspx");
							break;
						case DocType.RTV:
							Response.Redirect("../Purchase/PRTVBrowser.aspx?DocCode=7");
							break;
                        case DocType.INVENTORYSHORTAGE:
                            Response.Redirect("OutBrowser.aspx");
                            break;
						default:
							Response.Redirect("OUTBrowser.aspx");
							break;
					}

				}
			}
		}

		#endregion

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
            if (Master.IsTODO)
			{
				this.Response.Write("<script>window.close();</script>");
			}
			else
			{
				if(Request.QueryString["Op"]==OP.Discard)
					Response.Redirect("OutBrowser.aspx");
				else if(Request.QueryString["Op"]==OP.O)
                    Response.Redirect("../Purchase/PINBrowser.aspx");
                else if(Request.QueryString["Op"]==OP.I)
                {
                    Response.Redirect("OutBrowser.aspx");
                }
				
			}
		}

		
	}
}
