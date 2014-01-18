namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// DocItemRouteData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class DocItemRouteData  :DataSet
	{
		#region 成员变量
		public const string DocItemRoute_Table = "DocItemRoute";
		public const string EntryNo_Field = "EntryNo";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string EntryStateName_Field = "EntryStateName";
		public const string EntryDate_Field = "EntryDate";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string Assessor1_Field = "Assessor1";
		public const string Assessor2_Field = "Assessor2";
		public const string Assessor3_Field = "Assessor3";
		public const string AuditDate1_Field = "AuditDate1";
		public const string AuditDate2_Field = "AuditDate2";
		public const string AuditDate3_Field = "AuditDate3";
		public const string ReqDept_Field = "ReqDept";
		public const string ReqDeptName_Field = "ReqDeptName";
		public const string ReqReasonCode_Field = "ReqReasonCode";
		public const string ReqReason_Field = "ReqReason";
		public const string PrvCode_Field = "PrvCode";
		public const string PrvName_Field = "PrvName";
		public const string BuyerCode_Field = "BuyerCode";
		public const string BuyerName_Field = "BuyerName";
		public const string AcceptCode_Field = "AcceptCode";
		public const string AcceptName_Field = "AcceptName";
		public const string AcceptDate_Field = "AcceptDate";
		public const string InvoiceNo_Field = "InvoiceNo";
		public const string ContractCode_Field = "ContractCode";
		public const string PayerCode_Field = "PayerCode";
		public const string PayerName_Field = "PayerName";
		public const string SerialNo_Field = "SerialNo";
		public const string SourceEntry_Field = "SourceEntry";
		public const string SourceDocCode_Field = "SourceDocCode";
		public const string SourceSerialNo_Field = "SourceSerialNo";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemMoney_Field = "ItemMoney";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemLackNum_Field = "ItemLackNum";
		public const string ItemNodrawNum_Field = "ItemNodrawNum";
		public const string ItemNoBorNum_Field = "ItemNoBorNum";
		#endregion
		#region 属性
		public int Count
		{
			get {return this.Tables[0].Rows.Count;}
		}
		#endregion
		#region 私有方法
		private void BuildDataTable()
		{
			DataTable table   = new DataTable(DocItemRoute_Table);
			//添加字段。
			table.Columns.Add(EntryNo_Field, typeof(System.Int32));
			table.Columns.Add(DocCode_Field, typeof(System.Int16));
			table.Columns.Add(DocName_Field, typeof(System.String));
			table.Columns.Add(EntryStateName_Field, typeof(System.String));
			table.Columns.Add(EntryDate_Field, typeof(System.DateTime));
			table.Columns.Add(AuthorCode_Field, typeof(System.String));
			table.Columns.Add(AuthorName_Field, typeof(System.String));
			table.Columns.Add(AuthorDept_Field, typeof(System.String));
			table.Columns.Add(AuthorDeptName_Field, typeof(System.String));
			table.Columns.Add(Assessor1_Field, typeof(System.String));
			table.Columns.Add(Assessor2_Field, typeof(System.String));
			table.Columns.Add(Assessor3_Field, typeof(System.String));
			table.Columns.Add(AuditDate1_Field, typeof(System.DateTime));
			table.Columns.Add(AuditDate2_Field, typeof(System.DateTime));
			table.Columns.Add(AuditDate3_Field, typeof(System.DateTime));
			table.Columns.Add(ReqDept_Field, typeof(System.String));
			table.Columns.Add(ReqDeptName_Field, typeof(System.String));
			table.Columns.Add(ReqReasonCode_Field, typeof(System.String));
			table.Columns.Add(ReqReason_Field, typeof(System.String));
			table.Columns.Add(PrvCode_Field, typeof(System.String));
			table.Columns.Add(PrvName_Field, typeof(System.String));
			table.Columns.Add(BuyerCode_Field, typeof(System.String));
			table.Columns.Add(BuyerName_Field, typeof(System.String));
			table.Columns.Add(AcceptCode_Field, typeof(System.String));
			table.Columns.Add(AcceptName_Field, typeof(System.String));
			table.Columns.Add(AcceptDate_Field, typeof(System.DateTime));
			table.Columns.Add(InvoiceNo_Field, typeof(System.String));
			table.Columns.Add(ContractCode_Field, typeof(System.String));
			table.Columns.Add(PayerCode_Field, typeof(System.String));
			table.Columns.Add(PayerName_Field, typeof(System.String));
			table.Columns.Add(SerialNo_Field, typeof(System.Int16));
			table.Columns.Add(SourceEntry_Field, typeof(System.Int32));
			table.Columns.Add(SourceDocCode_Field, typeof(System.Int16));
			table.Columns.Add(SourceSerialNo_Field, typeof(System.Int16));
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));
			table.Columns.Add(ItemSpec_Field, typeof(System.String));
			table.Columns.Add(ItemUnitName_Field, typeof(System.String));
			table.Columns.Add(ItemPrice_Field, typeof(System.Decimal));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			table.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemLackNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemNodrawNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemNoBorNum_Field, typeof(System.Decimal));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
		#endregion
		#region 构造函数
		public DocItemRouteData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private DocItemRouteData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion
	}
}
