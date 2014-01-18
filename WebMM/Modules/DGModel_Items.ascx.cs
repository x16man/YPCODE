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
	///		DGModel_Items ��ժҪ˵����
	/// </summary>
	public partial class DGModel_Items : DGModel
	{
		#region ��Ա����
		System.Web.UI.HtmlControls.HtmlInputText tb = new HtmlInputText();
		private decimal SubTotal = 0;//���ݺϼơ�
		private decimal TotalMoney = 0;
		private decimal TotalFee = 0;
		private string _OP="";
		
		#endregion
		#region ����
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
		#region ˽�з�����
		/// <summary>
		/// Ĭ�ϵ��ֶΰ�ģʽ��
		/// </summary>
		private void DefaultBoundColumn()
		{
            //���ϱ���
			BoundColumn dgCol=new BoundColumn();
			
            dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			
            dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			
            DataGrid1.Columns.Add(dgCol);


			//��������
			BoundColumn dgCol1=new BoundColumn();
			
            dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);

			//��λ����
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol3.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//��λ����
			BoundColumn dgCol4=new BoundColumn();
			//dgCol4.HeaderStyle.Width=new Unit(80);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol4);
			//����
			BoundColumn dgCol5=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(50);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol5.DataField = "ItemPrice";
			dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol5);
			//�깺��
			BoundColumn dgCol6=new BoundColumn();
			//dgCol6.HeaderStyle.Width=new Unit(50);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol6.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//�깺���
			BoundColumn dgCol7=new BoundColumn();
			//dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//��������
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
		/// �ɹ����뵥�ֶΰ�ģʽ��
		/// </summary>
		private void ROSBoundColumn()
		{
			//���ϱ�š�
			BoundColumn dgCol=new BoundColumn();
			//dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
            dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			//��λ����
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//��λ����
			BoundColumn dgCol4=new BoundColumn();
			//dgCol4.HeaderStyle.Width=new Unit(80);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol4);
			//����
			BoundColumn dgCol5=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(50);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol5.DataField = "ItemPrice";
			dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol5);
			//�깺��
			BoundColumn dgCol6=new BoundColumn();
			//dgCol6.HeaderStyle.Width=new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//�깺���
			BoundColumn dgCol7=new BoundColumn();
			//dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//��������
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
		/// �ɹ����뵥�༭ģʽ��
		/// </summary>
		private void ROSEditBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="ROSEdit_Header";
			//���ϱ�š�
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="ROSEdit_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(80);//
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="ROSEdit_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);//
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="ROSEdit_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);//
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			//��λ����
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);//
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//��λ����
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.CssClass="ROSEdit_ItemUnitName";
			//dgCol4.HeaderStyle.Width=new Unit(80);//
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol4);
            //����
            BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.CssClass="ROSEdit_ItemPrice";
            //dgCol5.HeaderStyle.Width=new Unit(50);//
            //dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
            dgCol5.DataField = "ItemPrice";
            dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
            //dgCol5.DataFormatString="{0:d}";
            DataGrid1.Columns.Add(dgCol5);
			//�깺��
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.CssClass="ROSEdit_ItemNum";
			//dgCol6.HeaderStyle.Width=new Unit(80);//
			//dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//��������
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
		/// ת�ⵥ�ֶΰ�ģʽ��
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

			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			
			//��λ����
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol3);
			//����
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.Width=new Unit(50);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol4.DataField = "ItemPrice";
			dgCol4.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol4);
			//Ӧת����
			BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.Width=new Unit(80);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("SetPlanNum");
			dgCol5.DataField = "PlanNum";
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.Wrap = false;
			DataGrid1.Columns.Add(dgCol5);
			//ʵת����
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.Width=new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("SetItemNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//���
			BoundColumn dgCol7=new BoundColumn();
			dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			
		}

		/// <summary>
		/// ת�ⵥ����ģʽ��
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

			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			
			//��λ����
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol3);
			//����
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.Width=new Unit(50);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol4.DataField = "ItemPrice";
			dgCol4.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol4);
			//Ӧת����
			BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.Width=new Unit(80);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("SetPlanNum");
			dgCol5.DataField = "PlanNum";
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.Wrap = false;
			DataGrid1.Columns.Add(dgCol5);
			//ʵת����
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.Width=new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("SetItemNum");
			dgCol6.DataField = "ItemNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//���
			BoundColumn dgCol7=new BoundColumn();
			dgCol7.HeaderStyle.Width=new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol7.DataField = "ItemMoney";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//��λ
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol8.DataField = "ConName";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			
		}

		/// <summary>
		/// ���ϵ������ֶ�Auditor��ģʽ��
		/// </summary>
		private void DrawBoundColumn()
		{
			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//��ǰ�������
			BoundColumn dgCol8=new BoundColumn();
			//dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//������
			BoundColumn dgCol4 = new BoundColumn();
			//dgCol4.HeaderStyle.Width = new Unit(70);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//ʵ����
			BoundColumn dgCol5 = new BoundColumn();
			//dgCol5.HeaderStyle.Width = new Unit(70);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//����
			BoundColumn dgCol6 = new BoundColumn();
			//dgCol6.HeaderStyle.Width = new Unit(70);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol6.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol6);
			//�ܼ�
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
			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="DrawEdit_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="DrawEdit_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="DrawEdit_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.CssClass="DrawEdit_ItemUnitName";
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//��ǰ�������
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="DrawEdit_StockNum";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//������
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.CssClass="DrawEdit_PlanNum";
			//dgCol4.HeaderStyle.Width = new Unit(70);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//ʵ����
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
		/// ����ʱ����λѡ���ֶΰ�ģʽ��
		/// </summary>
		private void ConChooserBoundColumn()
		{
			//���ϱ�š�
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//�������ơ�
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(120);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺš�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(100);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ��
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(50);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//�������
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.Width = new Unit(100);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol4.DataField = "StockNum";
			DataGrid1.Columns.Add(dgCol4);
			//ʵ������
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.Width = new Unit(100);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//��λ��
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.Width = new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol6.DataField = "ConName";
			DataGrid1.Columns.Add(dgCol6);
			//�������ڡ�
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.DataField = "AcceptDate";
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("AcceptDate");
			DataGrid1.Columns.Add(dgCol7);
		}
		/// <summary>
		/// �������ϵ����ֶΰ�ģʽ��
		/// </summary>
		private void RTSBoundColumn()
		{
			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(80);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//������
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.Width = new Unit(100);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNumber1");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//ʵ����
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.Width = new Unit(100);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNumber1");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//����
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.Width = new Unit(100);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol6.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol6);
			//�ܼ�
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.Width = new Unit(120);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol7.DataField = "ItemMoney";
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			DataGrid1.Columns.Add(dgCol7);

		}

		/// <summary>
		/// �������ϵ�����
		/// </summary>
		private void RTSReceiveBoundColumn()
		{
			RTSBoundColumn();
			//��λ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol.DataField = "ConName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);

		}
		/// <summary>
		/// ���ϵ�/�ɹ����ϵ����ֶΰ�ģʽ��
		/// </summary>
		private void BorBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="BorBound_Header";
			BoundColumn dgCol;

			//���ϱ��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_BatchCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BatchCode");
			dgCol.DataField = "BatchCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//Ӧ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = "PlanNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//ʵ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNumber");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorBound_ItemMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
//			//˰�ʡ�
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol.HeaderText = "˰��";
//			dgCol.DataField = "TaxRate";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
//			//˰�
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol.HeaderText = "˰��";
//			dgCol.DataField = "ItemTax";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
			//�ܽ�
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
		/// �ɹ����ϵ�����ģʽ��
		/// </summary>
		private void BorReceiveBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="BorReceive_Header";
			BoundColumn dgCol;

			//���ϱ��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText =ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//���š�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_BatchCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BatchCode");
			dgCol.DataField = BillOfReceiveData.BATCHCODE_FIELD;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//Ӧ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = BillOfReceiveData.PLANNUM_FIELD;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//ʵ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNumber");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
//			//˰�ʡ�
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "˰��";
//			dgCol.DataField = "TaxRate";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
//			//˰�
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "˰��";
//			dgCol.DataField = "ItemTax";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
			//�ܽ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="BorReceive_ItemSum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			dgCol.DataField = "ItemSum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//��λ��
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
		/// �ɹ��˻����Ӷΰ�ģʽ.
		/// </summary>
		private void RTVBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="RTVBound_Header";
			BoundColumn dgCol;

			//���ϱ��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_BatchCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BatchCode");
			dgCol.DataField = "BatchCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice"); 
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//Ӧ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber1");
			dgCol.DataField = "PlanNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//ʵ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="RTVBound_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNumber1");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//��
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
		/// �ɹ�����
		/// </summary>
		private void RTVReceiveBoundColunm()
		{
			RTVBoundColumn();
			//��λ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ConName");
			dgCol.DataField = "ConName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// ��Ч������ͼ�󶨡�
		/// </summary>
		private void PBSABoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//Դ����PKID��
			dgCol.HeaderStyle.Width = new Unit(1);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = false;
			dgCol.HeaderText = "PKID";
			dgCol.DataField = "PKID";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//������š�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("EntryCode");
			dgCol.DataField = "EntryCode";
			DataGrid1.Columns.Add(dgCol);
			//��Ӧ�̱��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PrvCode");
			dgCol.DataField = "PrvCode";
			DataGrid1.Columns.Add(dgCol);
			//��Ӧ������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PrvName");
			dgCol.DataField = "PrvName";
			DataGrid1.Columns.Add(dgCol);
			//�ɹ�Ա���
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BuyerCode");
			dgCol.DataField = "BuyerCode";
			DataGrid1.Columns.Add(dgCol);
			//�ɹ�Ա����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("BuyerName");
			dgCol.DataField = "BuyerName";
			DataGrid1.Columns.Add(dgCol);
			//�ܽ��
			dgCol = new BoundColumn();
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MoneySum");
			dgCol.DataField = "SubTotal";
			DataGrid1.Columns.Add(dgCol);		

		}
		/// <summary>
		/// �ɹ��ƻ����ֶΰ�ģʽ��
		/// </summary>
		private void PPCreateBoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//���벿�����ơ�
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDeptName");
			dgCol.DataField = "ReqDeptName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//���ϱ��
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;

			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol.DataField = "ItemUnit";
			dgCol.Visible = false;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//�ƻ�������
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemPlanNum");
			dgCol.DataField = "ItemPlanNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//�ƻ���
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemPlanMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//���벿�š�
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "���벿��";
//			dgCol.DataField = "ReqDept";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
//			DataGrid1.Columns.Add(dgCol);
			
			//��;��š�
//			dgCol = new BoundColumn();
//			dgCol.HeaderStyle.Width = new Unit(50);
//			dgCol.HeaderText = "��;���";
//			dgCol.DataField = "ReqReasonCode";
//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
//			DataGrid1.Columns.Add(dgCol);
			//��;���ơ�
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqReason");
			dgCol.DataField = "ReqReason";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//Ҫ�����ڡ�
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDate");
			dgCol.DataField = "ReqDate";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;

			DataGrid1.Columns.Add(dgCol);
			//�����ˡ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Proposer");
			dgCol.DataField = "Proposer";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);			
			//��ע��
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Remark");
			dgCol.DataField = "Remark";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		/// �ɹ��������ֶΰ�ģʽ��
		/// </summary>
		private void PPBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="PPBound_Header";
			//���벿�����ơ�
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ReqDeptName";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDeptName");
			dgCol.DataField = "ReqDeptName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//���ϱ��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemCode";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemName";
			//dgCol.HeaderStyle.Width = new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemSpecial";
			//dgCol.HeaderStyle.Width = new Unit(100);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemUnit");
			dgCol.DataField = "ItemUnit";
			dgCol.Visible = false;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//�ƻ�������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemPlanNum";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemPlanNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//�ƻ���
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ItemPlanMoney";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol.DataField = "ItemMoney";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//���벿�š�
			//			dgCol = new BoundColumn();
			//			dgCol.HeaderStyle.Width = new Unit(50);
			//			dgCol.HeaderText = "���벿��";
			//			dgCol.DataField = "ReqDept";
			//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			//			DataGrid1.Columns.Add(dgCol);
			
			//��;��š�
			//			dgCol = new BoundColumn();
			//			dgCol.HeaderStyle.Width = new Unit(50);
			//			dgCol.HeaderText = "��;���";
			//			dgCol.DataField = "ReqReasonCode";
			//			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			//			DataGrid1.Columns.Add(dgCol);
			//��;���ơ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_ReqReason";
			//dgCol.HeaderStyle.Width = new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqReason");
			dgCol.DataField = "ReqReason";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//Ҫ�����ڡ�
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
			//�����ˡ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="PPBound_Proposer";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Proposer");
			dgCol.DataField = "Proposer";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//��ע��
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
		/// �ɹ�����������Դ�ֶ�ģʽ
		/// </summary>
		private void POSBoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//Դ����PKID��
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = false;
			dgCol.HeaderText = "PKID";
			dgCol.DataField = "PKID";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("DocName");
			dgCol.DataField = "DocName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//���벿��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqDeptName");
			dgCol.DataField = "ReqDeptName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��;
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(50);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqReason");
			dgCol.DataField = "ReqReason";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//���Ϸ���
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CatName");
			dgCol.DataField = "CatName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			DataGrid1.Columns.Add(dgCol);
			//��Ҫ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ReqItemNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            dgCol.DataFormatString = "{0:n3}";
			DataGrid1.Columns.Add(dgCol);
			//Ҫ������
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
		/// �ɹ������ֶ�ģʽ��
		/// </summary>
		private void POBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="POBound_Header";
			BoundColumn dgCol;
			//���ϱ��
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemName";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemSpecial";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(150);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol);
			//��λ
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_ItemUnitName";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//����
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
			//���ϵ���
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
			//���
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
			//�����ˡ�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="POBound_Proposer";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Proposer");
			dgCol.DataField = "Proposer";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//û���������ϵ�������
			dgCol = new BoundColumn();
			dgCol.Visible = false;
			dgCol.DataField = "ItemLackNum";
			DataGrid1.Columns.Add(dgCol);
		}
		/// <summary>
		///�������յ��ֶ�ģʽ��
		/// </summary>
		private void PCBRBoundColumn()
		{
			BoundColumn dgCol = new BoundColumn();
			//��������
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CitmCode");
			dgCol.DataField = "CitmCode";
			DataGrid1.Columns.Add(dgCol);
			//����������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(100);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CitmName");
			dgCol.DataField = "CitmName";
			DataGrid1.Columns.Add(dgCol);
			//����ֵ
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(200);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CitmValue");
			dgCol.DataField = "CitmValue";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//��λ
			dgCol = new BoundColumn();
			dgCol.Visible = true;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.DataField = "CitmUnit";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);			
		}
		/// <summary>
		/// ���ϵ��ֶΰ�ģʽ��
		/// </summary>
		private void SCRBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="SCRBound_Header";
			//���ϱ�š�
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="SCRBound_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="SCRBound_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="SCRBound_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol2);
			//��λ����
			BoundColumn dgCol3=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnit";
			dgCol3.Visible=false;
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol3);
			//��λ����
			BoundColumn dgCol4=new BoundColumn();
			dgCol4.HeaderStyle.CssClass="SCRBound_ItemUnitName";
			//dgCol4.HeaderStyle.Width=new Unit(80);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol4.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol4);
			//����
			BoundColumn dgCol5=new BoundColumn();
			dgCol5.HeaderStyle.CssClass="SCRBound_ItemPrice";
			//dgCol5.HeaderStyle.Width=new Unit(50);
			//dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol5.DataField = "ItemPrice";
			dgCol5.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol5);
			//Ӧ������
			BoundColumn dgCol6=new BoundColumn();
			dgCol6.HeaderStyle.CssClass="SCRBound_PlanNum";
			//dgCol6.HeaderStyle.Width=new Unit(80);
			//dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("PlanNo");
			dgCol6.DataField = "PlanNum";
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol6);
			//ʵ������
			BoundColumn dgCol7=new BoundColumn();
			dgCol7.HeaderStyle.CssClass="SCRBound_ItemNum";
			//dgCol7.HeaderStyle.Width=new Unit(80);
			//dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("ItemNo");
			dgCol7.DataField = "ItemNum";
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol7);
			//���Ͻ��
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="SCRBound_ItemMoney";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ItemMoney");
			dgCol8.DataField = "ItemMoney";
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
//			//��������
//			BoundColumn dgCol9=new BoundColumn();
//			dgCol9.HeaderStyle.Width=new Unit(80);
//			dgCol9.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol9.HeaderText = "��������";
//			dgCol9.DataField = "ReqDate";
//			dgCol9.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol9.ItemStyle.Wrap = false;
//			DataGrid1.Columns.Add(dgCol9);
		}
		/// <summary>
		/// ���ν��ϵ��Ӷΰ�ģʽ��
		/// </summary>
		private void BRBBoundColumn()
		{
			//������
			BoundColumn dgCol=new BoundColumn();
			//dgCol.HeaderStyle.Width=new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ShipNo");
			dgCol.DataField = "ShipNo";
			DataGrid1.Columns.Add(dgCol);
			//����ʱ�䡣
			BoundColumn dgCol1=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("StartTime");
			dgCol1.DataField = "StartTime";
			DataGrid1.Columns.Add(dgCol1);
			//�깤ʱ�䡣
			BoundColumn dgCol2=new BoundColumn();
			//dgCol2.HeaderStyle.Width=new Unit(150);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("EndTime");
			dgCol2.DataField = "EndTime";
			DataGrid1.Columns.Add(dgCol2);
			//����ʱ�䡣
			BoundColumn dgCol3=new BoundColumn();
			//dgCol1.HeaderStyle.Width=new Unit(150);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("ImportTime");
			dgCol3.DataField = "ImportTime";
			DataGrid1.Columns.Add(dgCol3);
			//����ʱ�䡣
			BoundColumn dgCol4=new BoundColumn();
			//dgCol4.HeaderStyle.Width=new Unit(150);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("ExportTime");
			dgCol4.DataField = "ExportTime";
			DataGrid1.Columns.Add(dgCol4);
			//��Ʒ���ơ�
			BoundColumn dgCol5=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(150);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("SetItemName");
			dgCol5.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol5);
			//�鲵ǰҺλ��
			BoundColumn dgCol6=new BoundColumn();
			//dgCol6.HeaderStyle.Width=new Unit(150);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("StartVolumn");
			dgCol6.DataField = "StartVolumn";
			DataGrid1.Columns.Add(dgCol6);
			//�鲵��Һλ��
			BoundColumn dgCol7=new BoundColumn();
			//dgCol5.HeaderStyle.Width=new Unit(150);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("EndVolumn");
			dgCol7.DataField = "EndVolumn";
			DataGrid1.Columns.Add(dgCol7);
			//�����
			BoundColumn dgCol8=new BoundColumn();
			//dgCol8.HeaderStyle.Width=new Unit(150);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("ItemVolumn");
			dgCol8.DataField = "ItemVolumn";
			DataGrid1.Columns.Add(dgCol8);
		}
		/// <summary>
		/// ��λ�������ֶΰ�ģʽ��
		/// </summary>
		private void ADJBoundColumn()
		{
			//���ϱ�š�
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.Width = new Unit(80);
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//�������ơ�
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.Width=new Unit(120);
			dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺš�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.Width=new Unit(100);
			dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ��
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.Width=new Unit(50);
			dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//�������
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.Width = new Unit(100);
			dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol4.DataField = "StockNum";
			DataGrid1.Columns.Add(dgCol4);
			
			//��������
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.Width = new Unit(100);
			dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("GetItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);

			//Դ��λ��
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.Width = new Unit(80);
			dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("SrcConName");
			dgCol6.DataField = "SrcConName";
			DataGrid1.Columns.Add(dgCol6);
			//Ŀ���λ��
			BoundColumn dgCol7 = new BoundColumn();
			dgCol7.HeaderStyle.Width = new Unit(80);
			dgCol7.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol7.HeaderText = ConfigCommon.GetMessageValue("TgtConName");
			dgCol7.DataField = "TgtConName";
			DataGrid1.Columns.Add(dgCol7);
		}
		/// <summary>
		/// ί��ӹ����뵥�ֶΰ�ģʽ��
		/// </summary>
		private void WTOWBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WTOWBound_Header";
			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WTOWBound_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="WTOWBound_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);
			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="WTOWBound_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.CssClass="WTOWBound_ItemUnitName";
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//��ǰ�������
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="WTOWBound_StockNum";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//������
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.CssClass="WTOWBound_PlanNum";
			//dgCol4.HeaderStyle.Width = new Unit(70);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//ʵ����
			BoundColumn dgCol5 = new BoundColumn();
			dgCol5.HeaderStyle.CssClass="WTOWBound_ItemNum";
			//dgCol5.HeaderStyle.Width = new Unit(70);
			//dgCol5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol5.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol5.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol5.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol5);
			//����
			BoundColumn dgCol6 = new BoundColumn();
			dgCol6.HeaderStyle.CssClass="WTOWBound_ItemPrice";
			//dgCol6.HeaderStyle.Width = new Unit(70);
			//dgCol6.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol6.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol6.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol6.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol6);
			//�ܼ�
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
			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WTOWEdit_ItemCode";
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			BoundColumn dgCol1=new BoundColumn();
			dgCol1.HeaderStyle.CssClass="WTOWEdit_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol1.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol1.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol1);

			//����ͺ�
			BoundColumn dgCol2=new BoundColumn();
			dgCol2.HeaderStyle.CssClass="WTOWEdit_ItemSpecial";
			//dgCol2.HeaderStyle.Width=new Unit(150);
			//dgCol2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol2.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol2.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol2);
			//������λ
			BoundColumn dgCol3=new BoundColumn();
			dgCol3.HeaderStyle.CssClass="WTOWEdit_ItemUnitName";
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol3.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol3.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol3.DataField = "ItemUnitName";
			dgCol3.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol3);
			//��ǰ�������
			BoundColumn dgCol8=new BoundColumn();
			dgCol8.HeaderStyle.CssClass="WTOWEdit_StockNum";
			//dgCol8.HeaderStyle.Width=new Unit(80);
			//dgCol8.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol8.HeaderText = ConfigCommon.GetMessageValue("StockNum");
			dgCol8.DataField = "StockNum";
			dgCol8.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol8);
			//������
			BoundColumn dgCol4 = new BoundColumn();
			dgCol4.HeaderStyle.CssClass="WTOWEdit_PlanNum";
			//dgCol4.HeaderStyle.Width = new Unit(70);
			//dgCol4.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol4.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol4.HeaderText = ConfigCommon.GetMessageValue("PlanNum");
			dgCol4.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol4);
			//ʵ����
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
		/// ί��ӹ����ϵ��ֶΰ�ģʽ��
		/// </summary>
		private void WINWBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WINWBound_Header";

			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(60);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemName";
			//dgCol.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemSpecial";
			//dgCol.HeaderStyle.Width=new Unit(100);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol);
			//������λ
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
//			//��ǰ�������
//			dgCol=new BoundColumn();
//			dgCol.HeaderStyle.Width=new Unit(80);
//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
//			dgCol.HeaderText = "���";
//			dgCol.DataField = "StockNum";
//			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
//			DataGrid1.Columns.Add(dgCol);
			//Ӧ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol);
			//ʵ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol);
			//���á�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWBound_ItemFee";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemFee");
			dgCol.DataField = "ItemFee";
			DataGrid1.Columns.Add(dgCol);
			//�ܼ�
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
		/// ί��ӹ����ϵ��ֶΰ�ģʽ��
		/// </summary>
		private void WINWEditBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="WINWEdit_Header";
			//���ϱ��
			BoundColumn dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(60);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			DataGrid1.Columns.Add(dgCol);
			//��������
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemName";
			//dgCol.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemSpecial";
			//dgCol.HeaderStyle.Width=new Unit(100);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			DataGrid1.Columns.Add(dgCol);
			//������λ
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemUnitName";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			DataGrid1.Columns.Add(dgCol);
			//			//��ǰ�������
			//			dgCol=new BoundColumn();
			//			dgCol.HeaderStyle.Width=new Unit(80);
			//			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//			dgCol.HeaderText = "���";
			//			dgCol.DataField = "StockNum";
			//			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//			DataGrid1.Columns.Add(dgCol);
			//Ӧ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_PlanNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("PlanNumber");
			dgCol.DataField = "PlanNum";
			DataGrid1.Columns.Add(dgCol);
			//ʵ����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemNum";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemNum");
			dgCol.DataField = "ItemNum";
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemPrice";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			DataGrid1.Columns.Add(dgCol);
			//���á�
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.CssClass="WINWEdit_ItemFee";
			//dgCol.HeaderStyle.Width = new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("ItemFee");
			dgCol.DataField = "ItemFee";
			DataGrid1.Columns.Add(dgCol);
			//�ܼ�
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
		/// �ɹ����������ֶΰ�ģʽ��
		/// </summary>
		private void CancelBoundColumn()
		{
			DataGrid1.HeaderStyle.CssClass="CancelBound_Header";
			//���ϱ��
			BoundColumn dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemCode";
			//dgCol.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.Visible=false;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialID");
			dgCol.DataField = "ItemCode";
			//dgCol.SortExpression="ItemCode";
			DataGrid1.Columns.Add(dgCol);

			//��������
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemName";
			//dgCol1.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("MaterialName");
			dgCol.DataField = "ItemName";
			DataGrid1.Columns.Add(dgCol);
			//����ͺ�
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemSpecial";
			//dgCol.HeaderStyle.Width=new Unit(150);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Special");
			dgCol.DataField = "ItemSpecial";
			//dgCol2.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol=new BoundColumn();
			//dgCol3.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnit";
			dgCol.Visible=false;
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Center;
			//dgCol3.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//��λ����
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemUnitName";
			//dgCol4.HeaderStyle.Width=new Unit(80);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("Unit");
			dgCol.DataField = "ItemUnitName";
			DataGrid1.Columns.Add(dgCol);
			//����
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemPrice";
			//dgCol5.HeaderStyle.Width=new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CstPrice");
			dgCol.DataField = "ItemPrice";
			dgCol.ItemStyle.HorizontalAlign=HorizontalAlign.Right;
			//dgCol5.DataFormatString="{0:d}";
			DataGrid1.Columns.Add(dgCol);
			//�깺��
			dgCol=new BoundColumn();
			dgCol.HeaderStyle.CssClass="CancelBound_ItemNum";
			//dgCol6.HeaderStyle.Width=new Unit(50);
			//dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			//dgCol.HeaderText = ConfigCommon.GetMessageValue("RequreNum");
			dgCol.HeaderText = ConfigCommon.GetMessageValue("CancelNum");
			dgCol.DataField = "ItemNum";
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
			DataGrid1.Columns.Add(dgCol);
			//�깺���
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

		#region  �����ؼ̳еķ�����
		/// <summary>
		/// �Զ���DataGrid�ĳ�ʼ����
		/// </summary>
		protected override void InitDataGridColumns()
		{
			switch(ColumnsScheme)
			{
					#region ���ϵ�
				case ColumnScheme.DRAW://���ϵ���
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
					#region ί��ӹ����뵥
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
					#region ���ϵ�
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
					#region ί��ӹ����뵥
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
					#region ��λ������
				case ColumnScheme.ADJ://��λ������
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
					#region	��λѡ��
				case ColumnScheme.CONCHOOSER://��λѡ��
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
					#region ���ϵ���
				case ColumnScheme.RTS://���ϵ���
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
					#region ���ϵ�
				case ColumnScheme.BOR://���ϵ���
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
					#region ���ϵ����ϡ�
				case ColumnScheme.RTSRECEIVE://���ϵ����ϡ�
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
					#region ���ϵ�����
				case ColumnScheme.BORRECEIVE://���ϵ����ϡ�
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
					#region �ɹ��ƻ�
				case ColumnScheme.PP://�ɹ��ƻ���
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
					#region �ɹ�������Դ��
				case ColumnScheme.POS://�ɹ�������Դ��
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
					#region �ɹ�����
				case ColumnScheme.PO://�ɹ�������
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
					#region ���ϵ���Դ��
				case ColumnScheme.PBSA:	//���ϵ���Դ��
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
					#region ���յ���
				case ColumnScheme.PCBR://���յ���
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
					#region ���뵥�� 
				case ColumnScheme.ROS://���뵥��
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
					#region �ɹ�����
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
					#region ת�ⵥ
				case ColumnScheme.TRF://ת�ⵥ��
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
					#region ת�ⵥת��
				case ColumnScheme.TRFIn://ת�ⵥת�롣
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
					#region �ɹ��˻�����
				case ColumnScheme.RTV://�ɹ��˻����ݡ�
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
					#region ����
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
					#region ���ϵ�
				case ColumnScheme.SCR://���ϵ��ݡ�
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
					#region ���ν��ϵ�
				case ColumnScheme.BRB://���ν��ϵ���
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
					#region ί��ӹ����ϵ�
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
					#region ί��ӹ����ϵ�
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

		#region �¼�
		/// <summary>
		/// ItemDataBound�¼���
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
					#region ���ϵ��ֶ�ģʽ.
				case ColumnScheme.DRAW://���ϵ����ֶ�ģʽ��
					//�����ǰ�������ݱ���������ǽ����
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=4&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						decimal StockNum,PlanNum,ItemNum;//���������������ʵ������
						
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
						
						try//��ǰ���
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//��������
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//ʵ������
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
						try//���ۡ�
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.000");
						}
						catch
						{}
						try//��
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="��  ��";
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
						decimal StockNum,PlanNum,ItemNum;//���������������ʵ������
						
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
						try//��ǰ���
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//��������
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//ʵ������
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
					}
					break;
					#endregion
					#region ί��ӹ����뵥
				case ColumnScheme.WTOW:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						decimal StockNum,PlanNum,ItemNum;//���������������ʵ������
						
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
						
						try//��ǰ���
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//��������
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//ʵ������
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
						try//���ۡ�
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.000");
						}
						catch
						{}
						try//��
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="��  ��";
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
					#region ί��ӹ����뵥�Ƶ�ģʽ
				case ColumnScheme.WTOWAuthor:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						decimal StockNum,PlanNum,ItemNum;//���������������ʵ������
						
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
						try//��ǰ���
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//��������
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//ʵ������
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						}
						catch
						{}
					}
					break;
					#endregion
					#region ί��ӹ����ϵ�
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
						try//Ӧ������
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//ʵ������
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//���ۡ�
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.000");
						}
						catch
						{}
						try//���á�
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
						}
						catch
						{}
						try//�ܽ�
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="��  ��";
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
					#region ί��ӹ����ϵ�
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
						try//Ӧ������
						{
							e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
						}
						catch
						{}
						try//ʵ������
						{
							e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
						}
						catch
						{}
						try//���ۡ�
						{
							e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.000");
						}
						catch
						{}
						try//���á�
						{
							e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
						}
						catch
						{}
						try//�ܽ�
						{
							e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");
						}
						catch
						{}
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="��  ��";
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
					#region ��λѡ��
				case ColumnScheme.CONCHOOSER:
					if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						if (e.Item.Cells[4].Text != "&nbsp;")//�������
						{
                            try
                            {
                                e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");
                            }
                            catch { }
						}
						if (e.Item.Cells[5].Text != "&nbsp;")//ʵ������
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

					#region �������ϵ�
				case ColumnScheme.RTS:  //�������ϵ��ֶ�ģʽ��
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
						e.Item.Cells[6].Text = "��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:C}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region �������ϵ�����
				case ColumnScheme.RTSRECEIVE:  //�������ϵ��ֶ�ģʽ��
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
						e.Item.Cells[6].Text = "��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:C}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region ���ϵ����ֶ�ģʽ��
				case ColumnScheme.BOR://���ϵ����ֶ�ģʽ��
					if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=6&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");//����
                            }
                            catch { }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");//Ӧ����
                            }
                            catch { }
						}
						if (e.Item.Cells[7].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.##");//ʵ������	
                            }
                            catch { }
						}
						if (e.Item.Cells[8].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");//���
                            }
                            catch { }
						}
//						if (e.Item.Cells[9].Text != "&nbsp;")
//						{
//							e.Item.Cells[9].Text = Convert.ToDecimal(e.Item.Cells[9].Text).ToString("0.00");//˰��
//						}
//						if (e.Item.Cells[10].Text != "&nbsp;")
//						{
//							e.Item.Cells[10].Text = Convert.ToDecimal(e.Item.Cells[10].Text).ToString("0.00");//˰��
//						}
						if (e.Item.Cells[9].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[9].Text = Convert.ToDecimal(e.Item.Cells[9].Text).ToString("0.00");//�ܽ�
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
						e.Item.Cells[7].Text="��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", TotalMoney);
                        }
                        catch
                        {
                        }
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[9].Text="��  ��";
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

					#region ���ϵ�����ģʽ
				case ColumnScheme.BORRECEIVE:
					if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
					{
						e.Item.Attributes.Add("ondblclick","window.open('../Analysis/DocRoute.aspx?EntryNo="+this.EntryNo.ToString()+"&DocCode=6&SerialNo=" + e.Item.ItemIndex.ToString() +"&ItemCode="+e.Item.Cells[0].Text+"','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");//Ӧ����
                            }
                            catch { }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");//ʵ������	
                            }
                            catch { }
						}
					}
					break;
					#endregion

					#region �ɹ��ƻ�
				case ColumnScheme.PP://�ɹ��ƻ�����ʱ���ֶ�ģʽ��
//					�����ǰ�������ݱ���������ǽ����
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
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[7].Text="��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region �ɹ�����.
				case ColumnScheme.PO://�ɹ��������ֶ�ģʽ��
					//�����ǰ�������ݱ���������ǽ����
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
                                e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.##");//������	
                            }
                            catch { }
						}
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");//����
                            }
                            catch { }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.00");//���
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
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[5].Text="��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[6].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region �ɹ���������Դ
				case ColumnScheme.POS:
					e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
					//	�����ǰ�������ݱ���������ǽ����
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

					#region ���ϵ���Դ
				case ColumnScheme.PBSA:
					e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
					e.Item.Attributes.Add("ondblclick","window.open('PBSADetail.aspx?EntryNo=" + e.Item.Cells[0].Text +"','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");

					break;
					#endregion

					#region �������յ�
				case ColumnScheme.PCBR:
					break;
				case ColumnScheme.ROS:
					//e.Item.Attributes.Add("ondblclick","window.open('AtiShow.aspx?PKID=" + e.Item.Cells[0].Text +"')");
					//�����ǰ�������ݱ���������ǽ����
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
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
                        }
                        catch { }
					}
					break;
					#endregion

					#region ת�ⵥ
				case ColumnScheme.TRF:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
					//	SubTotal += decimal.Parse(e.Item.Cells[7].Text);
					//	e.Item.Cells[6].Text=Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						//e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
					//	e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
					//	e.Item.HorizontalAlign = HorizontalAlign.Center;
					//	e.Item.Cells[6].Text="��  ��";
					//	e.Item.HorizontalAlign = HorizontalAlign.Right;
					//	e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					
					#endregion

					#region ��λ������
				case ColumnScheme.ADJ:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						//	SubTotal += decimal.Parse(e.Item.Cells[7].Text);
						//	e.Item.Cells[6].Text=Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						//e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
						//	e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						//	e.Item.HorizontalAlign = HorizontalAlign.Center;
						//	e.Item.Cells[6].Text="��  ��";
						//	e.Item.HorizontalAlign = HorizontalAlign.Right;
						//	e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					#endregion

					#region �ɹ��˻���
				case ColumnScheme.RTV:
					if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
					{
						if (e.Item.Cells[5].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");//����
                            }
                            catch
                            {
                            }
						}
						if (e.Item.Cells[6].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");//Ӧ����
                            }
                            catch
                            {
                            }
						}
						if (e.Item.Cells[7].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.##");//ʵ������	
                            }
                            catch
                            {
                            }
						}
						if (e.Item.Cells[8].Text != "&nbsp;")
						{
                            try
                            {
                                e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");//���
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
						e.Item.Cells[7].Text="��  ��";
						e.Item.HorizontalAlign = HorizontalAlign.Right;
                        try
                        {
                            e.Item.Cells[8].Text = string.Format("{0:c}", TotalMoney);
                        }
                        catch
                        {
                        }
						//e.Item.HorizontalAlign = HorizontalAlign.Center;
						//e.Item.Cells[9].Text="��  ��";
						//e.Item.HorizontalAlign = HorizontalAlign.Right;
						//e.Item.Cells[10].Text = string.Format("{0:c}", TotalTax);
						//e.Item.HorizontalAlign = HorizontalAlign.Right;
						//e.Item.Cells[9].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					#endregion

					#region ���ϵ�
				case ColumnScheme.SCR:
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						//	SubTotal += decimal.Parse(e.Item.Cells[7].Text);
						//	e.Item.Cells[6].Text=Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
						//e.Item.Cells[7].Text = string.Format("{0:c}", Convert.ToDecimal(e.Item.Cells[7].Text));
						//	e.Item.Cells[8].Text=InputCheck.ConvertDateField(e.Item.Cells[8].Text,"yyyy-MM-dd");
					}
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						//	e.Item.HorizontalAlign = HorizontalAlign.Center;
						//	e.Item.Cells[6].Text="��  ��";
						//	e.Item.HorizontalAlign = HorizontalAlign.Right;
						//	e.Item.Cells[7].Text = string.Format("{0:c}", SubTotal);
					}
					break;
					#endregion

					#region ���ν��ϵ�
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
					//�����ǰ�������ݱ���������ǽ����
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
					else if(e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
					{
						e.Item.HorizontalAlign = HorizontalAlign.Center;
						e.Item.Cells[6].Text="��  ��";
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
		/// ҳ��Load�¼���
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
			// TODO:  ��� DGModel_Items.DataGrid1_ItemCommand ʵ��
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
