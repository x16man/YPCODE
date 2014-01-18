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

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;  
	/// <summary>
	/// SBODData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class SBODData :DataSet
	{
		#region 成员变量
		public const string SBOD_TABLE = "SBOD";
		public const string DOCCODE_FIELD = "DOCCODE";
		public const string DOCNAME_FIELD = "DOCNAME";
		public const string CODERULE_FIELD = "CODERULE";
		public const string DOCNO_FIELD = "DOCNO";
		public const string STARTNO_FIELD = "STARTNO";
		public const string NEXTNO_FIELD = "NEXTNO";
		public const string ONEITEM_FIELD = "ONEITEM";
		public const string AUDITLEVEL_FIELD = "AUDITLEVEL";
		public const string ISAUDIT1_FIELD = "ISAUDIT1";
		public const string ISAUDIT2_FIELD = "ISAUDIT2";
		public const string ISAUDIT3_FIELD = "ISAUDIT3";
		public const string ISACCOUNT_FIELD = "ISACCOUNT";
		public const string REMARK_FIELD = "REMARK";
		public const string AUDITNAME1_FIELD = "AUDITNAME1";
		public const string AUDITNAME2_FIELD = "AUDITNAME2";
		public const string AUDITNAME3_FIELD = "AUDITNAME3";
		#endregion

		#region 属性
		public int Count 
		{
			get { return this.Tables[SBODData.SBOD_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 创建数据表。
		/// </summary>
		private void BuildDataTables()
		{
			//采购计划明细需求表。
			DataTable table   = new DataTable(SBODData.SBOD_TABLE);
			DataColumnCollection columns = table.Columns;
			columns.Add( SBODData.DOCCODE_FIELD, typeof(System.Int16));
			columns.Add( SBODData.DOCNAME_FIELD, typeof(System.String));
			columns.Add( SBODData.CODERULE_FIELD, typeof(System.String));
			columns.Add( SBODData.DOCNO_FIELD, typeof(System.String));
			columns.Add( SBODData.STARTNO_FIELD, typeof(System.Int32));
			columns.Add( SBODData.NEXTNO_FIELD, typeof(System.Int32));
			columns.Add( SBODData.ONEITEM_FIELD, typeof(System.String));
			columns.Add( SBODData.AUDITLEVEL_FIELD, typeof(System.Int16));
			columns.Add( SBODData.ISAUDIT1_FIELD, typeof(System.String));
			columns.Add( SBODData.ISAUDIT2_FIELD, typeof(System.String));
			columns.Add( SBODData.ISAUDIT3_FIELD, typeof(System.String));
			columns.Add( SBODData.ISACCOUNT_FIELD, typeof(System.String));
			columns.Add( SBODData.REMARK_FIELD, typeof(System.String));
			columns.Add( SBODData.AUDITNAME1_FIELD, typeof(System.String));
			columns.Add( SBODData.AUDITNAME2_FIELD, typeof(System.String));
			columns.Add( SBODData.AUDITNAME3_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}

		#endregion

		#region 构造函数
		private SBODData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public SBODData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
