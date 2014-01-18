namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using Shmzh.MM.Common;
	//using MZHCommon.PageStyle;
	using MZHCommon.Input;
	using MZHCommon;
    using MZHMM.WebMM.Common;

	/// <summary>
	///		DGModel_Items 的摘要说明。
	/// </summary>
	public partial class DGModel_Items : DGModel
	{
		#region 成员变量
		System.Web.UI.HtmlControls.HtmlInputText tb = new HtmlInputText();
		private decimal SubTotal = 0;//单据合计。
		private decimal TotalMoney = 0;
		private decimal TotalFee = 0;
		private string _OP="";
		
		#endregion
		#region 属性
		public int EntryNo
		{
			get 
			{
				if (this.Request["EntryNo"] != null && this.Request["EntryNo"] != "")
				{
					return int.Parse(this.Request["EntryNo"]);
				}
				else
				{
					return 0;
				}
			}
		}
		#endregion
		#region 私有方法。
		/// <summary>
		/// 默认的字段绑定模式。
		/// </summary>
		private void DefaultBoundColumn()
		{
            //物料编码
			BoundColumn dgCol=new BoundColumn();
			
            dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			
            dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			
            DataGrid1.Columns.Add(dgCol);


			//物料描述
			BoundColumn dgCol1=new BoundColumn();
			
            dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);

			//单位代码
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol3.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//单位名称
			BoundColumn dgCol4=new BoundColumn();
			//dgCol4.HeaderStyle.Width=new Unit(80);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol4);
			//单价
			BoundColumn dgCol5=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(50);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol5.DataField = "ItemPrice";
			dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol5);
			//申购数
			BoundColumn dgCol6=new BoundColumn();
			//dgCol6.HeaderStyle.Width=new Unit(50);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol6.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//申购金额
			BoundColumn dgCol7=new BoundColumn();
			//dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//需用日期
			BoundColumn dgCol8=new BoundColumn();
			//dgCol8.HeaderStyle.Width=new Unit(100);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol8.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol8.DataField = "ReqDate";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.DataFormatString = "{0:d}";
			DataGrid1.Columns.Add(dgCol8);
		}

		/// <summary>
		/// 采购申请单字段绑定模式。
		/// </summary>
		private void ROSBoundColumn()
		{
			//物料编号。
			BoundColumn dgCol=new BoundColumn();
			//dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
            dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			BoundColumn dgCol1=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			//单位代码
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//单位名称
			BoundColumn dgCol4=new BoundColumn();
			//dgCol4.HeaderStyle.Width=new Unit(80);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol4);
			//单价
			BoundColumn dgCol5=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(50);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol5.DataField = "ItemPrice";
			dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol5);
			//申购数
			BoundColumn dgCol6=new BoundColumn();
			//dgCol6.HeaderStyle.Width=new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//申购金额
			BoundColumn dgCol7=new BoundColumn();
			//dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//需用日期
			BoundColumn dgCol8=new BoundColumn();
			//dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol8.DataField = "ReqDate";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol8.ItemStyle.Wrap = false;
			DataGrid1.Columns.Add(dgCol8);
		}

		/// <summary>
		/// 采购申请单编辑模式。
		/// </summary>
		private void ROSEditBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="ROSEdit_Header";
			//物料编号。
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="ROSEdit_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(80);//
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="ROSEdit_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);//
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="ROSEdit_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);//
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			//单位代码
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);//
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//单位名称
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.CssClass="ROSEdit_ItemUnitName";
			//dgCol4.HeaderStyle.Width=new Unit(80);//
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol4);
            //单价
            BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.CssClass="ROSEdit_ItemPrice";
            //dgCol5.HeaderStyle.Width=new Unit(50);//
            //dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
            dgCol5.DataField = "ItemPrice";
            dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
            //dgCol5.DataFormatString="{0:d}";
            DataGrid1.Columns.Add(dgCol5);
			//申购数
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.CssClass="ROSEdit_ItemNum";
			//dgCol6.HeaderStyle.Width=new Unit(80);//
			//dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//需用日期
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="ROSEdit_ReqDate";
			//dgCol8.HeaderStyle.Width=new Unit(80);//
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol8.DataField = "ReqDate";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.ItemStyle.Wrap = false;
			DataGrid1.Columns.Add(dgCol8);
		}

		/// <summary>
		/// 转库单字段绑定模式。
		/// </summary>
		private void TRFBoundColumn()
		{
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);

			//物料描述
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			
			//单位名称
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol3);
			//单价
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.Width=new Unit(50);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol4.DataField = "ItemPrice";
			dgCol4.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol4);
			//应转数量
			BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.Width=new Unit(80);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("SetPlanNum");
			dgCol5.DataField = "PlanNum";
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.Wrap = false;
			DataGrid1.Columns.Add(dgCol5);
			//实转数量
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.Width=new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("SetItemNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//金额
			BoundColumn dgCol7=new BoundColumn();
			dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			
		}

		/// <summary>
		/// 转库单收料模式。
		/// </summary>
		private void TRFInBoundColumn()
		{
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);

			//物料描述
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			
			//单位名称
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol3);
			//单价
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.Width=new Unit(50);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol4.DataField = "ItemPrice";
			dgCol4.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol4);
			//应转数量
			BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.Width=new Unit(80);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("SetPlanNum");
			dgCol5.DataField = "PlanNum";
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.Wrap = false;
			DataGrid1.Columns.Add(dgCol5);
			//实转数量
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.Width=new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("SetItemNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//金额
			BoundColumn dgCol7=new BoundColumn();
			dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//架位
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol8.DataField = "ConName";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			
		}

		/// <summary>
		/// 领料单单的字段Auditor绑定模式。
		/// </summary>
		private void DrawBoundColumn()
		{
			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			BoundColumn dgCol1=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//当前库存数。
			BoundColumn dgCol8=new BoundColumn();
			//dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//请领数
			BoundColumn dgCol4 = new BoundColumn();
			//dgCol4.HeaderStyle.Width = new Unit(70);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//实发数
			BoundColumn dgCol5 = new BoundColumn();
			//dgCol5.HeaderStyle.Width = new Unit(70);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//单价
			BoundColumn dgCol6 = new BoundColumn();
			//dgCol6.HeaderStyle.Width = new Unit(70);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol6.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol6);
			//总价
			BoundColumn dgCol7 = new BoundColumn();
			//dgCol7.HeaderStyle.Width = new Unit(120);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol7.DataField = "ItemMoney";
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			DataGrid1.Columns.Add(dgCol7);
		}
		/// <summary>
		///	DRAW Author Bound Style.
		/// </summary>
		private void DrawEditBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="DrawEdit_Header";
			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="DrawEdit_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="DrawEdit_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="DrawEdit_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.CssClass="DrawEdit_ItemUnitName";
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//当前库存数。
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="DrawEdit_StockNum";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//请领数
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.CssClass="DrawEdit_PlanNum";
			//dgCol4.HeaderStyle.Width = new Unit(70);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//实发数
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.CssClass="DrawEdit_ItemNum";
			//dgCol5.HeaderStyle.Width = new Unit(70);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
		}
		/// <summary>
		/// 发料时库存架位选择字段绑定模式。
		/// </summary>
		private void ConChooserBoundColumn()
		{
			//物料编号。
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称。
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(120);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号。
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(100);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位。
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(50);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//库存数。
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.Width = new Unit(100);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol4.DataField = "StockNum";
			DataGrid1.Columns.Add(dgCol4);
			//实发数。
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.Width = new Unit(100);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//架位。
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.Width = new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol6.DataField = "ConName";
			DataGrid1.Columns.Add(dgCol6);
			//收料日期。
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.DataField = "AcceptDate";
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("AcceptDate");
			DataGrid1.Columns.Add(dgCol7);
		}
		/// <summary>
		/// 生产退料单的字段绑定模式。
		/// </summary>
		private void RTSBoundColumn()
		{
			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//请领数
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.Width = new Unit(100);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNumber1");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//实发数
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.Width = new Unit(100);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNumber1");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//单价
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.Width = new Unit(100);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol6.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol6);
			//总价
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.Width = new Unit(120);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol7.DataField = "ItemMoney";
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			DataGrid1.Columns.Add(dgCol7);

		}

		/// <summary>
		/// 生产退料单收料
		/// </summary>
		private void RTSReceiveBoundColumn()
		{
			RTSBoundColumn();
			//架位。
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol.DataField = "ConName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);

		}
		/// <summary>
		/// 收料单/采购退料单的字段绑定模式。
		/// </summary>
		private void BorBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="BorBound_Header";
			BoundColumn dgCol;

			//物料编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单位名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//批号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_BatchCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BatchCode");
			dgCol.DataField = "BatchCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//应退数。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = "PlanNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//实退数。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNumber");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//金额。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
//			//税率。
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol.HeaderText = "税率";
//			dgCol.DataField = "TaxRate";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
//			//税额。
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol.HeaderText = "税额";
//			dgCol.DataField = "ItemTax";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
			//总金额。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_MoneySum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			dgCol.DataField = "ItemSum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 采购收料单收料模式。
		/// </summary>
		private void BorReceiveBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="BorReceive_Header";
			BoundColumn dgCol;

			//物料编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText =ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单位名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//批号。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_BatchCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BatchCode");
			dgCol.DataField = BillOfReceiveData.BATCHCODE_FIELD;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//应收数。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = BillOfReceiveData.PLANNUM_FIELD;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//实收数。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNumber");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//金额。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
//			//税率。
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "税率";
//			dgCol.DataField = "TaxRate";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
//			//税额。
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "税额";
//			dgCol.DataField = "ItemTax";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
			//总金额。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemSum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			dgCol.DataField = "ItemSum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//架位。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ConName";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol.DataField = "ConName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 采购退货单子段绑定模式.
		/// </summary>
		private void RTVBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="RTVBound_Header";
			BoundColumn dgCol;

			//物料编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单位名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//批号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_BatchCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BatchCode");
			dgCol.DataField = "BatchCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice"); 
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//应退数。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber1");
			dgCol.DataField = "PlanNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//实退数。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNumber1");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//金额。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 采购退料
		/// </summary>
		private void RTVReceiveBoundColunm()
		{
			RTVBoundColumn();
			//架位。
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol.DataField = "ConName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 有效订单视图绑定。
		/// </summary>
		private void PBSABoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//源单据PKID。
			dgCol.HeaderStyle.Width = new Unit(1);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = false;
			dgCol.HeaderText = "PKID";
			dgCol.DataField = "PKID";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//订单编号。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("EntryCode");
			dgCol.DataField = "EntryCode";
			DataGrid1.Columns.Add(dgCol);
			//供应商编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PrvCode");
			dgCol.DataField = "PrvCode";
			DataGrid1.Columns.Add(dgCol);
			//供应商名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PrvName");
			dgCol.DataField = "PrvName";
			DataGrid1.Columns.Add(dgCol);
			//采购员编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BuyerCode");
			dgCol.DataField = "BuyerCode";
			DataGrid1.Columns.Add(dgCol);
			//采购员名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BuyerName");
			dgCol.DataField = "BuyerName";
			DataGrid1.Columns.Add(dgCol);
			//总金额
			dgCol = new BoundColumn();
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			dgCol.DataField = "SubTotal";
			DataGrid1.Columns.Add(dgCol);		

		}
		/// <summary>
		/// 采购计划的字段绑定模式。
		/// </summary>
		private void PPCreateBoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//申请部门名称。
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDeptName");
			dgCol.DataField = "ReqDeptName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//物料编号
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;

			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单位代码
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol.DataField = "ItemUnit";
			dgCol.Visible = false;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//单位名称
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//计划数量。
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemPlanNum");
			dgCol.DataField = "ItemPlanNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//计划金额。
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemPlanMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//申请部门。
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "申请部门";
//			dgCol.DataField = "ReqDept";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
//			DataGrid1.Columns.Add(dgCol);
			
			//用途编号。
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "用途编号";
//			dgCol.DataField = "ReqReasonCode";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
//			DataGrid1.Columns.Add(dgCol);
			//用途名称。
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqReason");
			dgCol.DataField = "ReqReason";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//要求日期。
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol.DataField = "ReqDate";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;

			DataGrid1.Columns.Add(dgCol);
			//申请人。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Proposer");
			dgCol.DataField = "Proposer";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);			
			//备注。
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Remark");
			dgCol.DataField = "Remark";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 采购订单的字段绑定模式。
		/// </summary>
		private void PPBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="PPBound_Header";
			//申请部门名称。
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ReqDeptName";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDeptName");
			dgCol.DataField = "ReqDeptName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//物料编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(100);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单位代码
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol.DataField = "ItemUnit";
			dgCol.Visible = false;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//单位名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//计划数量。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemPlanNum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemPlanNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//计划金额。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemPlanMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//申请部门。
			//			dgCol = new BoundColumn();
			//			dgCol.HeaderStyle.Width = new Unit(50);
			//			dgCol.HeaderText = "申请部门";
			//			dgCol.DataField = "ReqDept";
			//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			//			DataGrid1.Columns.Add(dgCol);
			
			//用途编号。
			//			dgCol = new BoundColumn();
			//			dgCol.HeaderStyle.Width = new Unit(50);
			//			dgCol.HeaderText = "用途编号";
			//			dgCol.DataField = "ReqReasonCode";
			//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			//			DataGrid1.Columns.Add(dgCol);
			//用途名称。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ReqReason";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqReason");
			dgCol.DataField = "ReqReason";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//要求日期。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ReqDate";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol.DataField = "ReqDate";
			//dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.DataFormatString = "{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//申请人。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_Proposer";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Proposer");
			dgCol.DataField = "Proposer";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//备注。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_Remark";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Remark");
			dgCol.DataField = "Remark";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 采购订单数据来源字段模式
		/// </summary>
		private void POSBoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//源单据PKID。
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = false;
			dgCol.HeaderText = "PKID";
			dgCol.DataField = "PKID";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//单据类型
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("DocName");
			dgCol.DataField = "DocName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//申请部门
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDeptName");
			dgCol.DataField = "ReqDeptName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//用途
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqReason");
			dgCol.DataField = "ReqReason";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//物料分类
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CatName");
			dgCol.DataField = "CatName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//需要数量
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqItemNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//要求日期
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol.DataField = "ReqDate";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.DataFormatString = "{0:d}";
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 采购订单字段模式。
		/// </summary>
		private void POBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="POBound_Header";
			BoundColumn dgCol;
			//物料编号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemName";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemSpecial";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol);
			//单位
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemUnitName";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//数量
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemNum";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemPlanNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//物料单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemPrice";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
            dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//金额
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemMoney";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//申请人。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_Proposer";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Proposer");
			dgCol.DataField = "Proposer";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//没有生成收料单数量。
			dgCol = new BoundColumn();
			dgCol.Visible = false;
			dgCol.DataField = "ItemLackNum";
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		///收料验收单字段模式。
		/// </summary>
		private void PCBRBoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//检验项编号
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CitmCode");
			dgCol.DataField = "CitmCode";
			DataGrid1.Columns.Add(dgCol);
			//检验项名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CitmName");
			dgCol.DataField = "CitmName";
			DataGrid1.Columns.Add(dgCol);
			//检验值
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(200);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CitmValue");
			dgCol.DataField = "CitmValue";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//单位
			dgCol = new BoundColumn();
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.DataField = "CitmUnit";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);			
		}
		/// <summary>
		/// 报废单字段绑定模式。
		/// </summary>
		private void SCRBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="SCRBound_Header";
			//物料编号。
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="SCRBound_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料描述
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="SCRBound_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="SCRBound_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			//单位代码
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//单位名称
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.CssClass="SCRBound_ItemUnitName";
			//dgCol4.HeaderStyle.Width=new Unit(80);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol4);
			//单价
			BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.CssClass="SCRBound_ItemPrice";
			//dgCol5.HeaderStyle.Width=new Unit(50);
			//dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol5.DataField = "ItemPrice";
			dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol5);
			//应废数量
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.CssClass="SCRBound_PlanNum";
			//dgCol6.HeaderStyle.Width=new Unit(80);
			//dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("PlanNo");
			dgCol6.DataField = "PlanNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//实废数量
			BoundColumn dgCol7=new BoundColumn();
			dgCol7.HeaderStyle.CssClass="SCRBound_ItemNum";
			//dgCol7.HeaderStyle.Width=new Unit(80);
			//dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemNo");
			dgCol7.DataField = "ItemNum";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//报废金额
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="SCRBound_ItemMoney";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol8.DataField = "ItemMoney";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
//			//报废日期
//			BoundColumn dgCol9=new BoundColumn();
//			dgCol9.HeaderStyle.Width=new Unit(80);
//			dgCol9.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol9.HeaderText = "报废日期";
//			dgCol9.DataField = "ReqDate";
//			dgCol9.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol9.ItemStyle.Wrap = false;
//			DataGrid1.Columns.Add(dgCol9);
		}
		/// <summary>
		/// 批次进料单子段绑定模式。
		/// </summary>
		private void BRBBoundColumn()
		{
			//船名。
			BoundColumn dgCol=new BoundColumn();
			//dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ShipNo");
			dgCol.DataField = "ShipNo";
			DataGrid1.Columns.Add(dgCol);
			//开工时间。
			BoundColumn dgCol1=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("StartTime");
			dgCol1.DataField = "StartTime";
			DataGrid1.Columns.Add(dgCol1);
			//完工时间。
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("EndTime");
			dgCol2.DataField = "EndTime";
			DataGrid1.Columns.Add(dgCol2);
			//进港时间。
			BoundColumn dgCol3=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("ImportTime");
			dgCol3.DataField = "ImportTime";
			DataGrid1.Columns.Add(dgCol3);
			//出港时间。
			BoundColumn dgCol4=new BoundColumn();
			//dgCol4.HeaderStyle.Width=new Unit(150);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("ExportTime");
			dgCol4.DataField = "ExportTime";
			DataGrid1.Columns.Add(dgCol4);
			//货品名称。
			BoundColumn dgCol5=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(150);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("SetItemName");
			dgCol5.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol5);
			//抽驳前液位。
			BoundColumn dgCol6=new BoundColumn();
			//dgCol6.HeaderStyle.Width=new Unit(150);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("StartVolumn");
			dgCol6.DataField = "StartVolumn";
			DataGrid1.Columns.Add(dgCol6);
			//抽驳后液位。
			BoundColumn dgCol7=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(150);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("EndVolumn");
			dgCol7.DataField = "EndVolumn";
			DataGrid1.Columns.Add(dgCol7);
			//体积。
			BoundColumn dgCol8=new BoundColumn();
			//dgCol8.HeaderStyle.Width=new Unit(150);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ItemVolumn");
			dgCol8.DataField = "ItemVolumn";
			DataGrid1.Columns.Add(dgCol8);
		}
		/// <summary>
		/// 架位调整单字段绑定模式。
		/// </summary>
		private void ADJBoundColumn()
		{
			//物料编号。
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称。
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(120);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号。
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(100);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位。
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(50);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//库存数。
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.Width = new Unit(100);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol4.DataField = "StockNum";
			DataGrid1.Columns.Add(dgCol4);
			
			//调整数。
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.Width = new Unit(100);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("GetItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);

			//源架位。
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.Width = new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("SrcConName");
			dgCol6.DataField = "SrcConName";
			DataGrid1.Columns.Add(dgCol6);
			//目标架位。
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.Width = new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("TgtConName");
			dgCol7.DataField = "TgtConName";
			DataGrid1.Columns.Add(dgCol7);
		}
		/// <summary>
		/// 委外加工申请单字段绑定模式。
		/// </summary>
		private void WTOWBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WTOWBound_Header";
			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WTOWBound_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="WTOWBound_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="WTOWBound_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.CssClass="WTOWBound_ItemUnitName";
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//当前库存数。
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="WTOWBound_StockNum";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//请领数
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.CssClass="WTOWBound_PlanNum";
			//dgCol4.HeaderStyle.Width = new Unit(70);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//实发数
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.CssClass="WTOWBound_ItemNum";
			//dgCol5.HeaderStyle.Width = new Unit(70);
			//dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//单价
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.CssClass="WTOWBound_ItemPrice";
			//dgCol6.HeaderStyle.Width = new Unit(70);
			//dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol6.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol6);
			//总价
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.CssClass="WTOWBound_ItemMoney";
			//dgCol7.HeaderStyle.Width = new Unit(120);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol7.DataField = "ItemMoney";
			dgCol7.HeaderText =ConfigCommon.GetMessageValue("MoneySum");
			DataGrid1.Columns.Add(dgCol7);
		}
		/// <summary>
		///	DRAW Author Bound Style.
		/// </summary>
		private void WTOWEditBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WTOWEdit_Header";
			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WTOWEdit_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="WTOWEdit_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//规格型号
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="WTOWEdit_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//计量单位
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.CssClass="WTOWEdit_ItemUnitName";
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//当前库存数。
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="WTOWEdit_StockNum";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//请领数
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.CssClass="WTOWEdit_PlanNum";
			//dgCol4.HeaderStyle.Width = new Unit(70);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//实发数
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.CssClass="WTOWEdit_ItemNum";
			//dgCol5.HeaderStyle.Width = new Unit(70);
			//dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
		}
		/// <summary>
		/// 委外加工收料单字段绑定模式。
		/// </summary>
		private void WINWBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WINWBound_Header";

			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(60);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemName";
			//dgCol.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemSpecial";
			//dgCol.HeaderStyle.Width=new Unit(100);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol);
			//计量单位
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
//			//当前库存数。
//			dgCol=new BoundColumn();
//			dgCol.HeaderStyle.Width=new Unit(80);
//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol.HeaderText = "库存";
//			dgCol.DataField = "StockNum";
//			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
			//应收数
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol);
			//实发数
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol);
			//费用。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemFee";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemFee");
			dgCol.DataField = "ItemFee";
			DataGrid1.Columns.Add(dgCol);
			//总价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemSum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.DataField = "ItemSum";
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// 委外加工收料单字段绑定模式。
		/// </summary>
		private void WINWEditBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WINWEdit_Header";
			//物料编号
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(60);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//物料名称
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemName";
			//dgCol.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemSpecial";
			//dgCol.HeaderStyle.Width=new Unit(100);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol);
			//计量单位
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//			//当前库存数。
			//			dgCol=new BoundColumn();
			//			dgCol.HeaderStyle.Width=new Unit(80);
			//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//			dgCol.HeaderText = "库存";
			//			dgCol.DataField = "StockNum";
			//			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//			DataGrid1.Columns.Add(dgCol);
			//应收数
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol);
			//实发数
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol);
			//费用。
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemFee";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemFee");
			dgCol.DataField = "ItemFee";
			DataGrid1.Columns.Add(dgCol);
			//总价
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemSum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.DataField = "ItemSum";
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			DataGrid1.Columns.Add(dgCol);
		}

		/// <summary>
		/// 采购撤销单的字段绑定模式。
		/// </summary>
		private void CancelBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="CancelBound_Header";
			//物料编号
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			//dgCol.SortExpression="ItemCode";
			DataGrid1.Columns.Add(dgCol);

			//物料名称
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//规格型号
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemSpecial";
			//dgCol.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//单位代码
			dgCol=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnit";
			dgCol.Visible=false;
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//单位名称
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemUnitName";
			//dgCol4.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol);
			//单价
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemPrice";
			//dgCol5.HeaderStyle.Width=new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//申购数
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemNum";
			//dgCol6.HeaderStyle.Width=new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CancelNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//申购金额
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemMoney";
			//dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
		}
		#endregion

		#region  可重载继承的方法。
		/// <summary>
		/// 自定义DataGrid的初始化。
		/// </summary>
		protected override void InitDataGridColumns()
		{
			switch(ColumnsScheme)
			{
					#region 领料单
				case ColumnScheme.DRAW://领料单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.DrawBoundColumn();
					break;
					#endregion
					#region 委外加工申请单
				case ColumnScheme.WTOWAuthor:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.WTOWEditBoundColumn();
					break;
					#endregion
					#region 领料单
				case ColumnScheme.DRAWAuthor:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.DrawEditBoundColumn();
					break;
					#endregion
					#region 委外加工申请单
				case ColumnScheme.WTOW:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.WTOWBoundColumn();
					break;
					#endregion
					#region 架位调整单
				case ColumnScheme.ADJ://架位调整单
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.ADJBoundColumn();
					break;
					#endregion
					#region	架位选择。
				case ColumnScheme.CONCHOOSER://架位选择。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.ConChooserBoundColumn();
					break;
					#endregion
					#region 退料单。
				case ColumnScheme.RTS://退料单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.RTSBoundColumn();
					break;
					#endregion
					#region 收料单
				case ColumnScheme.BOR://收料单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.BorBoundColumn();
					break;
					#endregion
					#region 退料单收料。
				case ColumnScheme.RTSRECEIVE://退料单收料。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.RTSReceiveBoundColumn();
					break;
					#endregion
					#region 收料单收料
				case ColumnScheme.BORRECEIVE://收料单收料。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.BorReceiveBoundColumn();
					break;
					#endregion
					#region 采购计划
				case ColumnScheme.PP://采购计划。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.PPBoundColumn();
					break;
					#endregion
					#region 采购订单来源。
				case ColumnScheme.POS://采购订单来源。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.POSBoundColumn();
					break;
					#endregion
					#region 采购订单
				case ColumnScheme.PO://采购订单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.POBoundColumn();
					break;
					#endregion
					#region 收料单来源。
				case ColumnScheme.PBSA:	//收料单来源。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.PBSABoundColumn();
					break;
					#endregion
					#region 验收单。
				case ColumnScheme.PCBR://验收单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.PCBRBoundColumn();
					break;
					#endregion
					#region 申请单。 
				case ColumnScheme.ROS://申请单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.Printer;
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
                        //this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.ROSBoundColumn();
					break;
					#endregion
					#region 采购订单
				case ColumnScheme.ROSAuthor:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.ROSEditBoundColumn();
					break;
					#endregion
					#region 转库单
				case ColumnScheme.TRF://转库单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.TRFBoundColumn();
					break;
					#endregion
					#region 转库单转入
				case ColumnScheme.TRFIn://转库单转入。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.TRFInBoundColumn();
					break;
					#endregion
					#region 采购退货单据
				case ColumnScheme.RTV://采购退货单据。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.RTVBoundColumn();
					break;
					#endregion
					#region 收料
				case ColumnScheme.RTVRECEIVE:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.RTVReceiveBoundColunm();
					break;
					#endregion
					#region 报废单
				case ColumnScheme.SCR://报废单据。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.SCRBoundColumn();
					break;
					#endregion
					#region 批次进料单
				case ColumnScheme.BRB://批次进料单。
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.BRBBoundColumn();
					break;
					#endregion
					#region 委外加工收料单
				case ColumnScheme.WINWAuthor:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.WINWEditBoundColumn();
					break;
					#endregion
					#region 委外加工收料单
				case ColumnScheme.WINW:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.WINWBoundColumn();
					break;
					#endregion
                #region ColumnScheme.PO
                case ColumnScheme.Cancel:
					if (this._OP == "View")
					//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					this.CancelBoundColumn();
					break;
					#endregion
				default:
					if (this._OP == "View")
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.Printer;
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					else
					{
						//this.DgStyleScheme = CommonStyle.StyleScheme.HotMail;
					}
					this.DefaultBoundColumn();
					break;
			}
		}
	
		#endregion

		#region 事件
		/// <summary>
		/// ItemDataBound事件。
		/// </summary>
		protected override void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if (this.Request["Op"].ToString() != null && this.Request["Op"].ToString() != "")
				{
					this._OP = this.Request["Op"].ToString();
				}
			}
			catch
			{}
			e.Item.Attributes.Add("id",e.Item.ItemIndex.ToString());
			
			//e.Item.Attributes.Add("ondblclick","window.open('DRWDetail.aspx?EntryNo=" + e.Item.Cells[0].Text +"','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
			switch(ColumnsScheme)
			{
					#region 领料单字段模式.
				case ColumnScheme.DRAW://领料单的字段模式。
					//如果当前项是数据表格的项或者是交替项。
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=4&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						decimal StockNum,PlanNum,ItemNum;//库存数，请领数，实发数。
						
						try
						{	StockNum = Convert.ToDecimal(e.Item.Cells[4].Text);	}
						catch
						{	StockNum = 0;	}
						try
						{	PlanNum = Convert.ToDecimal(e.Item.Cells[5].Text);	}
						catch
						{	PlanNum = 0;	}
						try
						{	ItemNum = Convert.ToDecimal(e.Item.Cells[6].Text);	}
						catch
						{	ItemNum = 0;	}
						
						if ( ( StockNum < PlanNum && (this._OP == "New" || this._OP == "Edit") ) || 
							 (StockNum < ItemNum && this._OP == "Out" )
						   )
						{
							e.Item.BackColor = Color.Red;
						}
						try
						{
							SubTotal += decimal.Parse(e.Item.Cells[8].Text);
						}
						catch
						{
							SubTotal += 0;
						}
						
						try//当前库存
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//请领数。
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//实发数。
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
						try//单价。
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.000");
						}
						catch
						{}
						try//金额。
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion
					#region	 DRAW Author 
				case ColumnScheme.DRAWAuthor:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=4&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						decimal StockNum,PlanNum,ItemNum;//库存数，请领数，实发数。
						
						try
						{	StockNum = Convert.ToDecimal(e.Item.Cells[4].Text);	}
						catch
						{	StockNum = 0;	}
						try
						{	PlanNum = Convert.ToDecimal(e.Item.Cells[5].Text);	}
						catch
						{	PlanNum = 0;	}
						try
						{	ItemNum = Convert.ToDecimal(e.Item.Cells[6].Text);	}
						catch
						{	ItemNum = 0;	}
						
						if ( ( StockNum < PlanNum && (this._OP == "New" || this._OP == "Edit") ) || 
							 (StockNum < ItemNum && this._OP == "Out" )
							)
						{
							e.Item.BackColor = Color.Red;
						}
						try//当前库存
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//请领数。
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//实发数。
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
					}
					break;
					#endregion
					#region 委外加工申请单
				case ColumnScheme.WTOW:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						decimal StockNum,PlanNum,ItemNum;//库存数，请领数，实发数。
						
						try
						{	StockNum = Convert.ToDecimal(e.Item.Cells[4].Text);	}
						catch
						{	StockNum = 0;	}
						try
						{	PlanNum = Convert.ToDecimal(e.Item.Cells[5].Text);	}
						catch
						{	PlanNum = 0;	}
						try
						{	ItemNum = Convert.ToDecimal(e.Item.Cells[6].Text);	}
						catch
						{	ItemNum = 0;	}
						
						if ( ( StockNum < PlanNum && (this._OP == "New" || this._OP == "Edit") ) || 
							(StockNum < ItemNum && this._OP == "Out" )
							)
						{
							e.Item.BackColor = Color.Red;
						}
						try
						{
							SubTotal += decimal.Parse(e.Item.Cells[8].Text);
						}
						catch
						{
							SubTotal += 0;
						}
						
						try//当前库存
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//请领数。
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//实发数。
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
						try//单价。
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.000");
						}
						catch
						{}
						try//金额。
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch
                        {
                        }
					}
					break;
					#endregion
					#region 委外加工申请单制单模式
				case ColumnScheme.WTOWAuthor:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						decimal StockNum,PlanNum,ItemNum;//库存数，请领数，实发数。
						
						try
						{	StockNum = Convert.ToDecimal(e.Item.Cells[4].Text);	}
						catch
						{	StockNum = 0;	}
						try
						{	PlanNum = Convert.ToDecimal(e.Item.Cells[5].Text);	}
						catch
						{	PlanNum = 0;	}
						try
						{	ItemNum = Convert.ToDecimal(e.Item.Cells[6].Text);	}
						catch
						{	ItemNum = 0;	}
						
						if ( ( StockNum < PlanNum && (this._OP == "New" || this._OP == "Edit") ) || 
							(StockNum < ItemNum && this._OP == "Out" )
							)
						{
							e.Item.BackColor = Color.Red;
						}
						try//当前库存
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//请领数。
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//实发数。
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
					}
					break;
					#endregion
					#region 委外加工收料单
				case ColumnScheme.WINW:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						//decimal PlanNum,ItemNum;
						
						try
						{
							SubTotal += decimal.Parse(e.Item.Cells[8].Text);
						}
						catch
						{
							SubTotal += 0;
						}
						try
						{
							TotalFee += decimal.Parse(e.Item.Cells[7].Text);
						}
						catch
						{
							TotalFee += 0;
						}
						try//应收数。
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//实收数。
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//单价。
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.000");
						}
						catch
						{}
						try//费用。
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
						}
						catch
						{}
						try//总金额。
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:c}", TotalFee);
                        }
                        catch { }
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion
					#region 委外加工收料单
				case ColumnScheme.WINWAuthor:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						//decimal PlanNum,ItemNum;
						
						try
						{
							SubTotal += decimal.Parse(e.Item.Cells[8].Text);
						}
						catch
						{
							SubTotal += 0;
						}
						try
						{
							TotalFee += decimal.Parse(e.Item.Cells[7].Text);
						}
						catch
						{
							TotalFee += 0;
						}
						try//应收数。
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//实收数。
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//单价。
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.000");
						}
						catch
						{}
						try//费用。
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
						}
						catch
						{}
						try//总金额。
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:c}", TotalFee);
                        }
                        catch { }
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion
					#region 架位选择
				case ColumnScheme.CONCHOOSER:
					if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						if (e.Item.Cells[4].Text != "&nbsp;")//库存数。
						{
                            try
                            {
                                e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
                            }
                            catch { }
						}
						if (e.Item.Cells[5].Text != "&nbsp;")//实发数。
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
                            }
                            catch { }
						}
					}
					break;
					#endregion

					#region 生产退料单
				case ColumnScheme.RTS:  //生产退料单字段模式。
					if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=8&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                        try
                        {
                            e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
                        }
                        catch { }
                        try
                        {
                            SubTotal += decimal.Parse(e.Item.Cells[7].Text);
                        }
                        catch 
                        {
                            SubTotal += 0;
                        }
					}
					else if(e.Item.ItemType == ListItemType.Footer)
					{
						e.Item.HorizontalAlign = HorizontalAlign.Right;
						e.Item.Cells[6].Text = "合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:C}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region 生产退料单收料
				case ColumnScheme.RTSRECEIVE:  //生产退料单字段模式。
					if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
                        try
                        {
                            e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
                        }
                        catch { }
                        try
                        {
                            SubTotal += decimal.Parse(e.Item.Cells[7].Text);
                        }
                        catch
                        {
                            SubTotal += 0;
                        }
					}
					else if(e.Item.ItemType == ListItemType.Footer)
					{
						e.Item.HorizontalAlign = HorizontalAlign.Right;
						e.Item.Cells[6].Text = "合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:C}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region 收料单的字段模式。
				case ColumnScheme.BOR://收料单的字段模式。
					if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=6&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");//单价
                            }
                            catch { }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");//应收数
                            }
                            catch { }
						}
						if (e.Item.Cells[7].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.##");//实收数。	
                            }
                            catch { }
						}
						if (e.Item.Cells[8].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");//金额
                            }
                            catch { }
						}
//						if (e.Item.Cells[9].Text != "&nbsp;")
//						{
//							e.Item.Cells[9].Text = Convert.ToDecimal(e.Item.Cells[9].Text).ToString("0.00");//税率
//						}
//						if (e.Item.Cells[10].Text != "&nbsp;")
//						{
//							e.Item.Cells[10].Text = Convert.ToDecimal(e.Item.Cells[10].Text).ToString("0.00");//税额
//						}
						if (e.Item.Cells[9].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[9].Text = Convert.ToDecimal(e.Item.Cells[9].Text).ToString("0.00");//总金额。
                            }
                            catch { }
						}
                        try
                        {
                            this.TotalMoney += decimal.Parse(e.Item.Cells[8].Text);
                        }
                        catch
                        {
                            this.TotalMoney += 0;
                        }
						//this.TotalTax += decimal.Parse(e.Item.Cells[10].Text);
                        try
                        {
                            this.SubTotal += decimal.Parse(e.Item.Cells[9].Text);
                        }
                        catch
                        {
                            this.SubTotal += 0;
                        }
					}
					else if(e.Item.ItemType == ListItemType.Footer)
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", TotalMoney);
                        }
                        catch
                        {
                        }
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[9].Text="合  计";
						//e.Item.HorizontalAlign = HorizontalAlign.Right;
						//e.Item.Cells[10].Text = string.Format("{0:c}", TotalTax);
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[9].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch
                        {
                        }
					}
					break;
					#endregion

					#region 收料单收料模式
				case ColumnScheme.BORRECEIVE:
					if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=6&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");//应收数
                            }
                            catch { }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");//实收数。	
                            }
                            catch { }
						}
					}
					break;
					#endregion

					#region 采购计划
				case ColumnScheme.PP://采购计划新增时的字段模式。
//					如果当前项是数据表格的项或者是交替项。
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=5&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[1].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                        try
                        {
                            e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.000");
                        }
                        catch{}
                        try
                        {
                            e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.##");
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
                        }
                        catch { }
                        try
                        {
                            SubTotal += decimal.Parse(e.Item.Cells[8].Text);
                        }
                        catch { SubTotal += 0; }

						//e.Item.Cells[10].Text=InputCheck.ConvertDateField(e.Item.Cells[10].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region 采购订单.
				case ColumnScheme.PO://采购订单的字段模式。
					//如果当前项是数据表格的项或者是交替项。
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=3&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						if (e.Item.Cells[8].Text != "&nbsp;")
						{
							try
							{
								if (Convert.ToDecimal(e.Item.Cells[8].Text) <= 0)
								{
									e.Item.ForeColor = Color.Gray;
								}
							}
							catch{}
						}
						if (e.Item.Cells[4].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");//数量。	
                            }
                            catch { }
						}
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");//单价
                            }
                            catch { }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.00");//金额
                            }
                            catch
                            {
                            }
						}
                        try
                        {
                            SubTotal += decimal.Parse(e.Item.Cells[6].Text);
                        }
                        catch
                        {
                            SubTotal += 0;
                        }
	
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[5].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[6].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region 采购订单数据源
				case ColumnScheme.POS:
					e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
					//	如果当前项是数据表格的项或者是交替项。
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						if (e.Item.Cells[8].Text != null || e.Item.Cells[8].Text !="")
						{
							try
							{
								e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
							}
							catch 
							{
							}
						}
					}
					//e.Item.Attributes.Add("ondblclick","window.opener.setCode(this.id);window.close();");
					break;
					#endregion

					#region 收料单来源
				case ColumnScheme.PBSA:
					e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
					e.Item.Attributes.Add("ondblclick","window.open('PBSADetail.aspx?EntryNo=" + e.Item.Cells[0].Text +"','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");

					break;
					#endregion

					#region 收料验收单
				case ColumnScheme.PCBR:
					break;
				case ColumnScheme.ROS:
					//e.Item.Attributes.Add("ondblclick","window.open('AtiShow.aspx?PKID=" + e.Item.Cells[0].Text +"')");
					//如果当前项是数据表格的项或者是交替项。
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=1&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                        try
                        {
                            SubTotal += decimal.Parse(e.Item.Cells[7].Text);
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[8].Text = InputCheck.ConvertDateField(e.Item.Cells[8].Text, "yyyy-MM-dd");
                        }
                        catch { }
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region 转库单
				case ColumnScheme.TRF:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
					//	SubTotal += decimal.Parse(e.Item.Cells[7].Text);
					//	e.Item.Cells[6].Text=Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						//e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
					//	e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
					//	e.Item.HorizontalAlign = HorizontalAlign.Center;
					//	e.Item.Cells[6].Text="合  计";
					//	e.Item.HorizontalAlign = HorizontalAlign.Right;
					//	e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					
					#endregion

					#region 架位调整单
				case ColumnScheme.ADJ:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						//	SubTotal += decimal.Parse(e.Item.Cells[7].Text);
						//	e.Item.Cells[6].Text=Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						//e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
						//	e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						//	e.Item.HorizontalAlign = HorizontalAlign.Center;
						//	e.Item.Cells[6].Text="合  计";
						//	e.Item.HorizontalAlign = HorizontalAlign.Right;
						//	e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					#endregion

					#region 采购退货单
				case ColumnScheme.RTV:
					if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
					{
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");//单价
                            }
                            catch
                            {
                            }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");//应收数
                            }
                            catch
                            {
                            }
						}
						if (e.Item.Cells[7].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.##");//实收数。	
                            }
                            catch
                            {
                            }
						}
						if (e.Item.Cells[8].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");//金额
                            }
                            catch
                            {
                            }

						}
                        try
                        {
                            this.TotalMoney += decimal.Parse(e.Item.Cells[8].Text);
                        }
                        catch
                        {
                        }
						//this.TotalTax += decimal.Parse(e.Item.Cells[10].Text);
						//this.SubTotal += decimal.Parse(e.Item.Cells[9].Text);
					}
					else if(e.Item.ItemType == ListItemType.Footer)
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", TotalMoney);
                        }
                        catch
                        {
                        }
						//e.Item.HorizontalAlign = HorizontalAlign.Center;
						//e.Item.Cells[9].Text="合  计";
						//e.Item.HorizontalAlign = HorizontalAlign.Right;
						//e.Item.Cells[10].Text = string.Format("{0:c}", TotalTax);
						//e.Item.HorizontalAlign = HorizontalAlign.Right;
						//e.Item.Cells[9].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					#endregion

					#region 报废单
				case ColumnScheme.SCR:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						//	SubTotal += decimal.Parse(e.Item.Cells[7].Text);
						//	e.Item.Cells[6].Text=Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						//e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
						//	e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						//	e.Item.HorizontalAlign = HorizontalAlign.Center;
						//	e.Item.Cells[6].Text="合  计";
						//	e.Item.HorizontalAlign = HorizontalAlign.Right;
						//	e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					#endregion

					#region 批次进料单
				case ColumnScheme.BRB:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==ListItemType.AlternatingItem )
					{
						e.Item.Cells[1].Text = Convert.ToDateTime(e.Item.Cells[1].Text).ToString("hh:mm:ss");
						e.Item.Cells[2].Text = Convert.ToDateTime(e.Item.Cells[2].Text).ToString("hh:mm:ss");
						e.Item.Cells[3].Text = Convert.ToDateTime(e.Item.Cells[3].Text).ToString("hh:mm:ss");
						e.Item.Cells[4].Text = Convert.ToDateTime(e.Item.Cells[4].Text).ToString("hh:mm:ss");
					}
					break;
					#endregion
					#region ROSAuthor
				case ColumnScheme.ROSAuthor:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=1&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                        try
                        {
                            e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[7].Text = InputCheck.ConvertDateField(e.Item.Cells[7].Text, "yyyy-MM-dd");
                        }
                        catch { }
					}
					break;
				case ColumnScheme.Cancel:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
                        //e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
                       //e.Item.Cells[6].Text=InputCheck.ConvertDateField(e.Item.Cells[6].Text,"yyyy-MM-dd");
					}
					break;
					#endregion
				#region default
				default:
					//e.Item.Attributes.Add("ondblclick","window.open('AtiShow.aspx?PKID=" + e.Item.Cells[0].Text +"')");
					//如果当前项是数据表格的项或者是交替项。
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=2&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                        try
                        {
                            SubTotal += decimal.Parse(e.Item.Cells[7].Text);
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
                        }
                        catch { }
                        try
                        {
                            e.Item.Cells[8].Text = InputCheck.ConvertDateField(e.Item.Cells[8].Text, "yyyy-MM-dd");
                        }
                       catch { }
					}
					else if(e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="合  计";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {

                            e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch
                        {
                        }
					}
					break;
					#endregion
			}
		}
		
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected override void Page_Load(object sender, EventArgs e)
		{
			this.SubTotal = 0;
			this.TotalFee = 0;
			base.Page_Load (sender, e);

            if (this.DataGrid1 != null)
                this.DataGrid1.PageSize = 100;
			
			switch (ColumnsScheme)
			{
				case ColumnScheme.DRAW:
					this.DataGrid1.ShowFooter = true;
                    
					this.SubTotal = 0;
					break;
				case ColumnScheme.DRAWAuthor:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.WTOWAuthor:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.WTOW:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.WINWAuthor:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					this.TotalFee = 0;
					break;
				case ColumnScheme.WINW:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					this.TotalFee = 0;
					break;
				case ColumnScheme.CONCHOOSER:
					this.DataGrid1.ShowFooter = true;
					break;
				case ColumnScheme.RTS:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.BOR:
					this.DataGrid1.ShowFooter = true;
					TotalMoney = 0;
					this.SubTotal = 0;
					break;
				case ColumnScheme.RTV:
					this.DataGrid1.ShowFooter = true;
					TotalMoney = 0;
					this.SubTotal = 0;
					break;
				case ColumnScheme.BORRECEIVE:
					this.DataGrid1.ShowFooter = true;
					TotalMoney = 0;
					SubTotal = 0;
					break;
				case ColumnScheme.PP:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.PBSA:
					this.DataGrid1.ShowFooter = false;
					break;
				case ColumnScheme.PCBR:
					this.DataGrid1.ShowFooter = false;
					break;
				case ColumnScheme.POS:
					//this.DataGrid1.ShowFooter = false;
					this.DataGrid1.ShowFooter = true;
					break;
				case ColumnScheme.PO:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.ROS:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.SCR:
					this.DataGrid1.ShowFooter =true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.BRB:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.ROSAuthor:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				case ColumnScheme.Cancel:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
				default:
					this.DataGrid1.ShowFooter = true;
					this.SubTotal = 0;
					break;
			}
			
		}

		#endregion
	
		protected override void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// TODO:  添加 DGModel_Items.DataGrid1_ItemCommand 实现
			base.DataGrid1_ItemCommand (source, e);
			if (e.CommandName == "ItemSelected")
			{
				string ItemCode;
				ItemCode = e.Item.Cells[0].Text;
				this.Response.Write("<script>alert(\'"+ItemCode+"\');</script>");
			}
		}
	}
}
