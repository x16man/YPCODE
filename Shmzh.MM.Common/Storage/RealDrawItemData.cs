namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// 和项目相关的实际领料情况数据实体类.
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class RealDrawItemData : DataSet
	{
		#region 成员变量
		public const string RealItem_Table = "RealItem";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemMoney_Field = "ItemMoney";

		#endregion
		
		#region 属性
		/// <summary>
		/// 记录数.
		/// </summary>
		public int Count
		{
			get {return this.Tables[RealDrawItemData.RealItem_Table].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 创建数据表.
		/// </summary>
		private void BuildDataTable() 
		{
			// 创建　Sto 表．
			DataTable table   = new DataTable(RealDrawItemData.RealItem_Table);
			//添加字段。
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

		#region 构造函数
		private RealDrawItemData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 项目相关的发料记录的实体类的构造函数.
		/// </summary>
		public RealDrawItemData()
		{
			this.BuildDataTable();
		}
		#endregion
	}
}
