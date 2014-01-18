namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// ����Ŀ��ص�ʵ�������������ʵ����.
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class RealDrawItemData : DataSet
	{
		#region ��Ա����
		public const string RealItem_Table = "RealItem";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemMoney_Field = "ItemMoney";

		#endregion
		
		#region ����
		/// <summary>
		/// ��¼��.
		/// </summary>
		public int Count
		{
			get {return this.Tables[RealDrawItemData.RealItem_Table].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �������ݱ�.
		/// </summary>
		private void BuildDataTable() 
		{
			// ������Sto ��
			DataTable table   = new DataTable(RealDrawItemData.RealItem_Table);
			//����ֶΡ�
			table.Columns.Add(RealDrawItemData.ItemCode_Field, typeof(System.String));
			table.Columns.Add(RealDrawItemData.ItemName_Field, typeof(System.String));
			table.Columns.Add(RealDrawItemData.ItemSpec_Field,typeof(System.String));
			table.Columns.Add(RealDrawItemData.ItemUnitName_Field, typeof(System.String));
			table.Columns.Add(RealDrawItemData.ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(RealDrawItemData.ItemPrice_Field, typeof(System.Decimal));
			table.Columns.Add(RealDrawItemData.ItemMoney_Field, typeof(System.Decimal));
			
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private RealDrawItemData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ��Ŀ��صķ��ϼ�¼��ʵ����Ĺ��캯��.
		/// </summary>
		public RealDrawItemData()
		{
			this.BuildDataTable();
		}
		#endregion
	}
}
