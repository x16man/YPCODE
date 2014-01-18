using System;
using System.Data;
using System.Runtime.Serialization;   

namespace  Shmzh.MM.Common
{
	/// <summary>
	/// 采购收料单的数据实体层。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PPAYData:DataSet
	{
		#region 成员变量
		public const string PPAY_Table  = "PPAY";							//主表名。
		public const string PDPY_Table = "PDPY";							//子表名.
		//主表信息。
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string DocNo_Field = "DocNo";
		public const string EntryState_Field = "EntryState";
		public const string EntryStateName_Field = "EntryStateName";
		public const string EntryDate_Field = "EntryDate";
		public const string PresentDate_Field = "PresentDate";
		public const string CancelDate_Field = "CancelDate";
		public const string PayDate_Field = "PayDate";
		public const string PayerCode_Field = "PayerCode";
		public const string PayerName_Field = "PayerName";
		public const string PayerLoginId_Field = "PayerLoginId";
		public const string PrvCode_Field = "PrvCode";
		public const string PrvName_Field = "PrvName";
		public const string PrvBank_Field = "PrvBank";
		public const string PrvAccount_Field = "PrvAccount";
		public const string PrvRegNo_Field = "PrvReqNo_Field";
		public const string PrvTel_Field = "PrvTel";
		public const string PrvFax_Field = "PrvFax";
		public const string PayStyle_Field = "PayStyle";
		public const string PayStyleName_Field = "PayStyleName";
		public const string InvoiceNo_Field = "InvoiceNo";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorLoginId_Field = "AuthorLoginId";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string SourceAuthorDept_Field = "SourceAuthorDept";
		public const string SourceAuthorDeptName_Field = "SourceAuthorDeptName";
		public const string Audit1_Field = "Audit1";
		public const string Assessor1_Field = "Assessor1";
		public const string AuditDate1_Field = "AuditDate1";
		public const string AuditSuggest1_Field = "AuditSuggest1";

		public const string Audit2_Field = "Audit2";
		public const string Assessor2_Field = "Assessor2";
		public const string AuditDate2_Field = "AuditDate2";
		public const string AuditSuggest2_Field = "AuditSuggest2";

		public const string Audit3_Field = "Audit3";
		public const string Assessor3_Field = "Assessor3";
		public const string AuditDate3_Field = "AuditDate3";
		public const string AuditSuggest3_Field = "AuditSuggest3";

		public const string TotalMoney_Field = "TotalMoney";
		public const string TotalFee_Field = "TotalFee";
		public const string SubTotal_Field = "SubTotal";

		//子表信息.
		public const string SerialNo_Field = "SerialNo";
		public const string SourceEntryNo_Field = "SourceEntryNo";
		public const string SourceDocCode_Field = "SourceDocCode";
		public const string SourceSerialNo_Field = "SourceSerialNo";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpecial_Field = "ItemSpecial";
		public const string ItemUnit_Field = "ItemUnit";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemMoney_Field = "ItemMoney";
		public const string ItemFee_Field = "ItemFee";
		public const string ItemSum_Field = "ItemSum";
		public const string BuyerCode_Field = "BuyerCode";
		public const string BuyerName_Field = "BuyerName";
		public const string AcceptCode_Field = "AcceptCode";
		public const string AcceptName_Field = "AcceptName";
		public const string AcceptDate_Field = "AcceptDate";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string ContractCode_Field = "ContractCode";
		public const string ReqAuthorCode_Field = "ReqAuthorCode";
		public const string ReqAuthorName_Field = "ReqAuthorName";
		public const string ReqReasonCode_Field = "ReqReasonCode";
		public const string ReqReason_Field = "ReqReason";
		public const string ReqEntryDate_Field = "ReqEntryDate";
		
		#endregion

		#region 属性
		/// <summary>
		/// 收料单实体的行集数量。
		/// </summary>
		public int Count
		{
			get {	return this.Tables[PPAYData.PPAY_Table].Rows.Count;}
		}
		public int ItemCount
		{
			get {	return this.Tables[PPAYData.PDPY_Table].Rows.Count;}
		}
		#endregion

		#region 构造函数
		private PPAYData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PPAYData()
		{
			BuildDataTables();
		}
		#endregion

		#region 私有方法
		private void BuildDataTables()
		{
			
			DataTable table   = new DataTable(PPAY_Table);
			DataColumnCollection columns = table.Columns;
			//主表字段增加。
			columns.Add(EntryNo_Field,typeof(System.Int32));
			columns.Add(EntryCode_Field,typeof(System.String));
			columns.Add(DocCode_Field,typeof(System.String));
			columns.Add(DocName_Field,typeof(System.String));
			columns.Add(DocNo_Field,typeof(System.String));
			columns.Add(EntryState_Field,typeof(System.String));
			columns.Add(EntryStateName_Field, typeof(System.String));
			columns.Add(EntryDate_Field,typeof(System.DateTime));
			columns.Add(PresentDate_Field,typeof(System.DateTime));
			columns.Add(CancelDate_Field,typeof(System.DateTime));
			columns.Add(PayDate_Field,typeof(System.DateTime));
			columns.Add(PayerCode_Field,typeof(System.String));
			columns.Add(PayerName_Field,typeof(System.String));
			columns.Add(PayerLoginId_Field,typeof(System.String));
			columns.Add(PrvCode_Field,typeof(System.String));
			columns.Add(PrvName_Field,typeof(System.String));
			columns.Add(PrvBank_Field,typeof(System.String));
			columns.Add(PrvAccount_Field,typeof(System.String));
			columns.Add(PrvRegNo_Field ,typeof(System.String));
			columns.Add(PrvTel_Field,typeof(System.String));
			columns.Add(PrvFax_Field,typeof(System.String));
			columns.Add(PayStyle_Field,typeof(System.String));
			columns.Add(PayStyleName_Field, typeof(System.String));
			columns.Add(InvoiceNo_Field,typeof(System.String));
			columns.Add(AuthorCode_Field,typeof(System.String));
			columns.Add(AuthorName_Field,typeof(System.String));
			columns.Add(AuthorLoginId_Field,typeof(System.String));
			columns.Add(AuthorDept_Field,typeof(System.String));
			columns.Add(AuthorDeptName_Field,typeof(System.String));
			columns.Add(SourceAuthorDept_Field, typeof(System.String));
			columns.Add(SourceAuthorDeptName_Field, typeof(System.String));
			columns.Add(Audit1_Field,typeof(System.String));
			columns.Add(Assessor1_Field,typeof(System.String));
			columns.Add(AuditDate1_Field,typeof(System.DateTime));
			columns.Add(AuditSuggest1_Field,typeof(System.String));
			columns.Add(Audit2_Field,typeof(System.String));
			columns.Add(Assessor2_Field,typeof(System.String));
			columns.Add(AuditDate2_Field,typeof(System.DateTime));
			columns.Add(AuditSuggest2_Field,typeof(System.String));
			columns.Add(Audit3_Field,typeof(System.String));
			columns.Add(Assessor3_Field,typeof(System.String));
			columns.Add(AuditDate3_Field,typeof(System.DateTime));
			columns.Add(AuditSuggest3_Field,typeof(System.String));
			columns.Add(TotalMoney_Field,typeof(System.Decimal));
			columns.Add(TotalFee_Field,typeof(System.Decimal));
			columns.Add(SubTotal_Field,typeof(System.Decimal));
			this.Tables.Add(table);
			//从表字段增加。
			table = new DataTable(PDPY_Table);
			columns = table.Columns;
			columns.Add(EntryNo_Field, typeof(System.Int32));
			columns.Add(SerialNo_Field, typeof(System.String));
			columns.Add(SourceEntryNo_Field, typeof(System.Int32));
			columns.Add(SourceDocCode_Field, typeof(System.String));
			columns.Add(SourceSerialNo_Field, typeof(System.Int32));
			columns.Add(ItemCode_Field, typeof(System.String));
			columns.Add(ItemName_Field, typeof(System.String));
			columns.Add(ItemSpecial_Field, typeof(System.String));
			columns.Add(ItemUnit_Field, typeof(System.Int16));
			columns.Add(ItemUnitName_Field, typeof(System.String));
			columns.Add(ItemNum_Field, typeof(System.Decimal));
			columns.Add(ItemPrice_Field, typeof(System.Decimal));
			columns.Add(ItemMoney_Field, typeof(System.Decimal));
			columns.Add(ItemFee_Field, typeof(System.Decimal));
			columns.Add(ItemSum_Field, typeof(System.Decimal));
			columns.Add(AuthorCode_Field, typeof(System.String));
			columns.Add(AuthorName_Field, typeof(System.String));
			columns.Add(BuyerCode_Field, typeof(System.String));
			columns.Add(BuyerName_Field, typeof(System.String));
			columns.Add(AcceptCode_Field, typeof(System.String));
			columns.Add(AcceptName_Field, typeof(System.String));
			columns.Add(AcceptDate_Field, typeof(System.DateTime));
			columns.Add(StoCode_Field, typeof(System.String));
			columns.Add(StoName_Field, typeof(System.String));
			columns.Add(ContractCode_Field, typeof(System.String));
			columns.Add(ReqAuthorCode_Field, typeof(System.String));
			columns.Add(ReqAuthorName_Field, typeof(System.String));
			columns.Add(ReqReasonCode_Field, typeof(System.String));
			columns.Add(ReqReason_Field, typeof(System.String));
			columns.Add(ReqEntryDate_Field, typeof(System.DateTime));
			this.Tables.Add(table);
		}
		#endregion
	}
}
