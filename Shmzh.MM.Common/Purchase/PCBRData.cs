#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace  Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// 收料验收单和批量进货单的数据实体，沿用了DocBaseData和InItemData的属性。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PCBRData:DataSet
	{
		#region 成员变量
		public const string ADD_FAILED = "";
		public const string ADD_SUCCESSED = "";
		public const string UPDATE_FAILED = "";
		public const string UPDATE_SUCCESSED = "";
		public const string DELETE_FAILED = "";
		public const string DELETE_SUCCESSED = "";
		public const string UPDATESTATE_FAILED = "";
		public const string UPDATESTATE_SUCCESSED = "";
		public const string FIRSTAUDIT_FAILED = "";
		public const string FIRSTAUDIT_SUCCESSED = "";
		public const string SECONDAUDIT_FAILED = "";
		public const string SECONDAUDIT_SUCCESSED = "";
		public const string THIRDAUDIT_FAILED = "";
		public const string THIRDAUDIT_SUCCESSED = "";
		public const string PRESENT_FAILED = "";
		public const string PRESENT_SUCCESSED = "";
		public const string CANCEL_FAILED = "";
		public const string CANCEL_SUCCESSED = "";
		public const string NOOBJECT = "";
		/// <value>单据描述实体</value>
		public const string PCBR_TABLE  = "PCBR";						//表名。
		//主表信息。
		public const string RECVDATE_FIELD = "RecvDate";				//收料日期。
		public const string SOURCEENTRY_FIELD = "SourceEntry";			//源单据。
		public const string SOURCEDOCCODE_FIELD = "SourceDocCode";		//源文档代码。
		public const string PRVCODE_FIELD = "PrvCode";					//供应商代码。
		public const string PRVNAME_FIELD = "PrvName";					//供应商名称。
		public const string PRVADD_FIELD = "PrvAdd";					//供应商地址。
		public const string PRVZIP_FIELD = "PrvZip";					//邮政编码。
		public const string PRVTEL_FIELD = "PrvTel";					//电话。
		public const string PRVFAX_FIELD = "PrvFax";					//传真。
		public const string CHKDEPT_FIELD = "ChkDept";					//检验部门。
		public const string CHKDEPTNAME_FIELD = "ChkDeptName";			//检验部门名称。
		public const string BATCHCODE_FIELD = "BatchCode";				//批号。
		//检验项从表信息。
		public const string CITMCODE_FIELD = "CitmCode";
		public const string CITMNAME_FIELD = "CitmName";
		public const string CITMUNIT_FIELD = "CitmUnit";
		public const string CITMVALUE_FIELD = "CitmValue";


		#endregion

		#region 属性
		/// <summary>
		/// 记录数。
		/// </summary>
		public int Count
		{
			get {	return this.Tables[PCBRData.PCBR_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建收料验收单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PCBR_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			//验收单表主表字段增加。
			columns.Add(PCBRData.RECVDATE_FIELD, typeof(System.DateTime));
			columns.Add(PCBRData.SOURCEENTRY_FIELD, typeof(System.Int32));
			columns.Add(PCBRData.SOURCEDOCCODE_FIELD, typeof(System.Int16));
			columns.Add(PCBRData.PRVCODE_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVNAME_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVADD_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVZIP_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVTEL_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVFAX_FIELD, typeof(System.String));
			columns.Add(PCBRData.CHKDEPT_FIELD, typeof(System.String));
			columns.Add(PCBRData.CHKDEPTNAME_FIELD, typeof(System.String));
			columns.Add(PCBRData.BATCHCODE_FIELD, typeof(System.String));
			//验收单从表字段增加。
			columns.Add(PCBRData.CITMCODE_FIELD, typeof(System.String));
			columns.Add(PCBRData.CITMNAME_FIELD, typeof(System.String));
			columns.Add(PCBRData.CITMUNIT_FIELD, typeof(System.String));
			columns.Add(PCBRData.CITMVALUE_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private PCBRData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PCBRData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
