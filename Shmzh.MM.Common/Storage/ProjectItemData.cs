namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// ProjectItemData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class ProjectItemData : DataSet
	{
		public const string ProjectItem_Table = "ProjectItem";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string ItemUnit_Field = "ItemUnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemMoney_Field = "ItemMoney";
		
		public ProjectItemData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		private ProjectItemData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		private void BuildDataTable()
		{
			// ��������; ��
			DataTable table   = new DataTable(ProjectItem_Table);
			//����ֶΡ�
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));
			table.Columns.Add(ItemSpec_Field, typeof(System.String));
			table.Columns.Add(ItemUnit_Field, typeof(System.String));
			table.Columns.Add(ItemPrice_Field, typeof(System.Decimal));
			table.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
