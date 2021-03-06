/******************************************************************************
**		文件: InItemData.cs
**		类名: InItemData
**		描述: 收料模式单据的公用属性字段类，继承自DocBaseData。为后续的具体收料
**			  类单据提供方便。省去重复的输入工作。在本类中继续实现父类的Table
**			  对象，向Table中添加收料类公用字段。
** 
**		调用 由:   
**              
**		Auth: 袁杰
**		Date: 2004-12-22
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------
**    
*******************************************************************************/

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// 收料模式单据的公用属性类。
	/// 列入收料模式的单据有如下几种：
	///	---	请购单
	/// ---	物料需求单
	/// ---	采购订单
	/// ---	收料单
	/// ---	采购退货单
	/// ---	采购发票
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class InItemData:DocBaseData 
	{
		public const string ENTRYNO_FIELD			= "EntryNo";			//单据流水号。
		public const string ENTRYCODE_FIELD			= "EntryCode";			//单据编号(可能有前缀)。
		public const string ENTRYSTATE_FIELD		= "EntryState";			//单据状态。
		public const string ENTRYSTATENAME_FIELD	= "EntryStateName";		//单据状态名称。
		public const string AUTHORCODE_FIELD		= "AuthorCode";			//制单人编号。
		public const string AUTHORNAME_FIELD		= "AuthorName";			//制单人名称。
		public const string AUTHORLOGINID_FIELD		= "AuthorLoginID";		//制单人登录名。
		public const string AUTHORDEPT_FIELD		= "AuthorDept";			//制单人部门编号。
		public const string AUTHORDEPTNAME_FIELD	= "AuthorDeptName";		//制单人部门名称。
		public const string ENTRYDATE_FIELD			= "EntryDate";			//制单日期。
		public const string PRESENTDATE_FIELD		= "PresentDate";		//提交日期。
		public const string CANCELDATE_FIELD		= "CancelDate";			//作废日期。
		public const string AUDIT1_FIELD			= "Audit1";				//一级审批。
		public const string AUDIT2_FIELD			= "Audit2";				//二级审批。
		public const string AUDIT3_FIELD			= "Audit3";				//三级审批。
	    public const string AUDIT4_FIELD = "Audit4";
		public const string ASSESSOR1_FIELD			= "Assessor1";			//一级审批人。
		public const string ASSESSOR2_FIELD			= "Assessor2";			//二级审批人。
		public const string ASSESSOR3_FIELD			= "Assessor3";			//三级审批人。
	    public const string ASSESSOR4_FIELD = "Assessor4";
		public const string AUDITDATE1_FIELD		= "AuditDate1";			//一级审批日期。
		public const string AUDITDATE2_FIELD		= "AuditDate2";			//二级审批日期。
		public const string AUDITDATE3_FIELD		= "AuditDate3";			//三级审批日期。
        public const string AUDITDATE4_FIELD = "AuditDate4";
		public const string AUDITSUGGEST1_FIELD		= "AuditSuggest1";		//一级审批意见。
		public const string AUDITSUGGEST2_FIELD		= "AuditSuggest2";		//二级审批意见。
		public const string AUDITSUGGEST3_FIELD		= "AuditSuggest3";		//三级审批意见。
	    public const string AUDITSUGGEST4_FIELD = "AuditSuggest4";
		public const string SUBTOTAL_FIELD			= "SubTotal";			//单据总金额。
		public const string REMARK_FIELD			= "Remark";				//单据备注。

		public const string SERIALNO_FIELD			= "SerialNo";			//单据明细内容顺序号。
	    public const string NEWCODE_FIELD = "NewCode";
		public const string ITEMCODE_FIELD			= "ItemCode";			//物料编号。
		public const string ITEMNAME_FIELD			= "ItemName";			//物料名称。
		public const string ITEMSPECIAL_FIELD		= "ItemSpecial";		//物料规格型号。
		public const string ITEMUNIT_FIELD			= "ItemUnit";			//物料单位。
		public const string ITEMUNITNAME_FIELD		= "ItemUnitName";		//物料单位名称。
		public const string ITEMNUM_FIELD			= "ItemNum";			//物料数量。
		public const string ITEMPRICE_FIELD			= "ItemPrice";			//物料价格。
		public const string ITEMMONEY_FIELD			= "ItemMoney";			//物料单项金额。public const string Parent_EntryNo			= "ParentEntryNo";		//Òª³·Ïûµ¥¾ÝÁ÷Ë®ºÅ¡£
        public const string Parent_EntryNo          = "ParentEntryNo";	    //要撤消单据流水号。
		
		
		public InItemData(DataTable table) : base(table)
		{
			var columns = table.Columns;
			
			columns.Add(ENTRYNO_FIELD,			typeof(System.Int32));
			columns.Add(ENTRYCODE_FIELD,		typeof(System.String));
			columns.Add(ENTRYSTATE_FIELD,		typeof(System.String)).DefaultValue="N";
			columns.Add(ENTRYSTATENAME_FIELD,	typeof(System.String));
			columns.Add(ENTRYDATE_FIELD,		typeof(System.DateTime)).DefaultValue=DateTime.Now;
			columns.Add(PRESENTDATE_FIELD,		typeof(System.DateTime));
			columns.Add(CANCELDATE_FIELD,		typeof(System.DateTime));
			columns.Add(SUBTOTAL_FIELD,			typeof(System.Decimal));
			columns.Add(REMARK_FIELD,			typeof(System.String));
			//审批段。
			columns.Add(AUDIT1_FIELD,			typeof(System.String));
			columns.Add(AUDIT2_FIELD,			typeof(System.String));
			columns.Add(AUDIT3_FIELD,			typeof(System.String));
		    columns.Add(AUDIT4_FIELD, typeof (System.String));
			columns.Add(ASSESSOR1_FIELD,		typeof(System.String));
			columns.Add(ASSESSOR2_FIELD,		typeof(System.String));
			columns.Add(ASSESSOR3_FIELD,		typeof(System.String));
		    columns.Add(ASSESSOR4_FIELD, typeof (System.String));
			columns.Add(AUDITDATE1_FIELD,		typeof(System.DateTime));
			columns.Add(AUDITDATE2_FIELD,		typeof(System.DateTime));
			columns.Add(AUDITDATE3_FIELD,		typeof(System.DateTime));
		    columns.Add(AUDITDATE4_FIELD, typeof (System.DateTime));
			columns.Add(AUDITSUGGEST1_FIELD,	typeof(System.String));
			columns.Add(AUDITSUGGEST2_FIELD,	typeof(System.String));
			columns.Add(AUDITSUGGEST3_FIELD,	typeof(System.String));
		    columns.Add(AUDITSUGGEST4_FIELD, typeof (System.String));
			//填写人段。
			columns.Add(AUTHORCODE_FIELD,		typeof(System.String));
			columns.Add(AUTHORNAME_FIELD,		typeof(System.String));
			columns.Add(AUTHORLOGINID_FIELD,	typeof(System.String));
			columns.Add(AUTHORDEPT_FIELD,		typeof(System.String));
			columns.Add(AUTHORDEPTNAME_FIELD,	typeof(System.String));
			//明细
            columns.Add(NEWCODE_FIELD,         typeof(System.String));
			columns.Add(ITEMCODE_FIELD,			typeof(System.String));
			columns.Add(ITEMNAME_FIELD,			typeof(System.String));
			columns.Add(SERIALNO_FIELD,			typeof(System.String));
			columns.Add(ITEMSPECIAL_FIELD,		typeof(System.String));
			columns.Add(ITEMNUM_FIELD,			typeof(System.String));
			columns.Add(ITEMPRICE_FIELD,		typeof(System.String));
			columns.Add(ITEMMONEY_FIELD,		typeof(System.String));
			columns.Add(ITEMUNIT_FIELD,			typeof(System.String));
			columns.Add(ITEMUNITNAME_FIELD,		typeof(System.String));

		}

	}
}
