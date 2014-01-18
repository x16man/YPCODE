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
	/// IOData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class IOData  : DataSet
	{
		#region 成员变量
		public const string IO_Table = "WIOD";
		public const string PKID_Field = "PKID";
		public const string EntryNo_Field = "EntryNo";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string OpDate_Field = "OpDate";
		public const string ObjCode_Field = "ObjCode";
		public const string ObjName_Field = "ObjName";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string UnitCode_Field = "UnitCode";
		public const string UnitName_Field = "UnitName";
		public const string StartNum_Field = "StartNum";
		public const string StartPrice_Field = "StartPrice";
		public const string StartMoney_Field = "StartMoney";
		public const string InNum_Field = "InNum";
		public const string InPrice_Field = "InPrice";
		public const string InMoney_Field = "InMoeny";
		public const string OutNum_Field = "OutNum";
		public const string OutPrice_Field = "OutPrice";
		public const string OutMoney_Field = "OutMoney";
		public const string EndNum_Field = "EndNum";
		public const string EndPrice_Field = "EndPrice";
		public const string EndMoney_Field = "EndMoney";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string ConCode_Field = "ConCode";
		public const string ConName_Field = "ConName";
		public const string ReqReason_Field = "ReqReason";
		#endregion

		#region 属性
		public int Count
		{
			get {	return this.Tables[IOData.IO_Table].Rows.Count;	}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table = new DataTable(IOData.IO_Table);
			DataColumnCollection columns = table.Columns;
			columns.Add(PKID_Field, typeof(System.Int64));
			columns.Add(EntryNo_Field, typeof(System.Int32));
			columns.Add(DocCode_Field, typeof(System.Int16));
			columns.Add(DocName_Field, typeof(System.String));
			columns.Add(OpDate_Field, typeof(System.DateTime));
			columns.Add(ObjCode_Field, typeof(System.String));
			columns.Add(ObjName_Field, typeof(System.String));
			columns.Add(ItemCode_Field, typeof(System.String));
			columns.Add(ItemName_Field, typeof(System.String));
			columns.Add(ItemSpec_Field, typeof(System.String));
			columns.Add(UnitCode_Field, typeof(System.Int16));
			columns.Add(UnitName_Field, typeof(System.String));
			columns.Add(StartNum_Field, typeof(System.Decimal));
			columns.Add(StartPrice_Field, typeof(System.Decimal));
			columns.Add(StartMoney_Field, typeof(System.Decimal));
			columns.Add(InNum_Field, typeof(System.Decimal));
			columns.Add(InPrice_Field, typeof(System.Decimal));
			columns.Add(InMoney_Field, typeof(System.Decimal));
			columns.Add(OutNum_Field, typeof(System.Decimal));
			columns.Add(OutPrice_Field, typeof(System.Decimal));
			columns.Add(OutMoney_Field, typeof(System.Decimal));
			columns.Add(EndNum_Field, typeof(System.Decimal));
			columns.Add(EndPrice_Field, typeof(System.Decimal));
			columns.Add(EndMoney_Field, typeof(System.Decimal));
			columns.Add(StoCode_Field, typeof(System.String));
			columns.Add(StoName_Field, typeof(System.String));
			columns.Add(ConCode_Field, typeof(System.Int32));
			columns.Add(ConName_Field, typeof(System.String));
			columns.Add(ReqReason_Field, typeof(System.String));
			this.Tables.Add(table);

		}
		#endregion

		#region 公开方法
		//
		//TODO: 在此处添加公开方法.
		//
		#endregion

		#region 构造函数
		private IOData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public IOData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
