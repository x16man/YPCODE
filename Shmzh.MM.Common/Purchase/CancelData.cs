#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息
/******************************************************************************
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion 文档信息


namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// RequestOfStockData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class CancelData	 : DataSet
	{
		#region 成员变量
		public const string PCOR_Table = "PCOR";
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string DocNo_Field = "DocNo";
		public const string EntryDate_Field = "EntryDate";
		public const string PresentDate_Field = "PresentDate";
		public const string CancelDate_Field = "CancelDate";
		public const string EntryState_Field = "EntryState";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorLoginID_Field = "AuthorLoginID";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string Audit1_Field = "Audit1";
		public const string Assessor1_Field = "Assessor1";
		public const string AuditSuggest1_Field = "AuditSuggest1";
		public const string AuditDate1_Field = "AuditDate1";
		public const string Audit2_Field = "Audit2";
		public const string Assessor2_Field = "Assessor2";
		public const string AuditSuggest2_Field = "AuditSuggest2";
		public const string AuditDate2_Field = "AuditDate2";
		public const string Audit3_Field = "Audit3";
		public const string Assessor3_Field = "Assessor3";
		public const string AuditSuggest3_Field = "AuditSuggest3";
		public const string AuditDate3_Field = "AuditDate3";
	    public const string SubTotal_Field = "SubTotal";
		public const string Remark_Field = "Remark";

		public const string SerialNo_Field = "SerialNo";
		public const string SourceEntry_Field = "SourceEntry";
		public const string SourceDocCode_Field = "SourceDocCode";
		public const string SourceSerialNo_Field = "SourceSerialNo";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string ItemUnit_Field = "ItemUnit";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemMoney_Field = "ItemMoney";

		#endregion

		#region 属性
		public int Count
		{
			get { return this.Tables[CancelData.PCOR_Table].Rows.Count;}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(CancelData.PCOR_Table);
			DataColumnCollection columns = table.Columns;
			columns.Add(CancelData.EntryNo_Field, typeof(System.Int32));			
			columns.Add(CancelData.EntryCode_Field, typeof(System.String));
			columns.Add(CancelData.DocCode_Field, typeof(System.Int16));
			columns.Add(CancelData.DocName_Field, typeof(System.String));
			columns.Add(CancelData.DocNo_Field, typeof(System.String));
			columns.Add(CancelData.EntryDate_Field, typeof(System.DateTime));
			columns.Add(CancelData.PresentDate_Field, typeof(System.DateTime));
			columns.Add(CancelData.CancelDate_Field, typeof(System.DateTime));
			columns.Add(CancelData.EntryState_Field, typeof(System.String));
			columns.Add(CancelData.AuthorCode_Field, typeof(System.String));
			columns.Add(CancelData.AuthorName_Field, typeof(System.String));
			columns.Add(CancelData.AuthorLoginID_Field, typeof(System.String));
			columns.Add(CancelData.AuthorDept_Field, typeof(System.String));
			columns.Add(CancelData.AuthorDeptName_Field, typeof(System.String));
			columns.Add(CancelData.Audit1_Field, typeof(System.String));
			columns.Add(CancelData.Assessor1_Field, typeof(System.String));
			columns.Add(CancelData.AuditSuggest1_Field, typeof(System.String));
			columns.Add(CancelData.AuditDate1_Field, typeof(System.DateTime));
			columns.Add(CancelData.Audit2_Field, typeof(System.String));
			columns.Add(CancelData.Assessor2_Field, typeof(System.String));
			columns.Add(CancelData.AuditSuggest2_Field, typeof(System.String));
			columns.Add(CancelData.AuditDate2_Field, typeof(System.DateTime));
			columns.Add(CancelData.Audit3_Field, typeof(System.String));
			columns.Add(CancelData.Assessor3_Field, typeof(System.String));
			columns.Add(CancelData.AuditSuggest3_Field, typeof(System.String));
			columns.Add(CancelData.AuditDate3_Field, typeof(System.DateTime));
		    columns.Add(CancelData.SubTotal_Field, typeof (decimal));
			columns.Add(CancelData.Remark_Field, typeof(System.String));
			/////////////////////////////////////////////////////////////
			columns.Add(CancelData.SerialNo_Field, typeof(System.String));
			columns.Add(CancelData.SourceEntry_Field, typeof(System.String));
			columns.Add(CancelData.SourceDocCode_Field, typeof(System.String));
			columns.Add(CancelData.SourceSerialNo_Field, typeof(System.String));
			columns.Add(CancelData.ItemCode_Field, typeof(System.String));
			columns.Add(CancelData.ItemName_Field, typeof(System.String));
			columns.Add(CancelData.ItemSpec_Field, typeof(System.String));
			columns.Add(CancelData.ItemUnit_Field, typeof(System.String));
			columns.Add(CancelData.ItemUnitName_Field, typeof(System.String));
			columns.Add(CancelData.ItemPrice_Field, typeof(System.String));
			columns.Add(CancelData.ItemNum_Field, typeof(System.String));
			columns.Add(CancelData.ItemMoney_Field, typeof(System.String));

			this.Tables.Add(table);
		}
		#endregion

		#region 公开方法
		//
		//TODO: 在此处添加公开方法.
		//
		#endregion

		#region 构造函数
		private CancelData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public CancelData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
