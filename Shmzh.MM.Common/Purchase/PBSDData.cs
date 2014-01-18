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
	/// PBSData 的摘要说明。ViewValidOrderDetail视图。
	/// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public class PBSDData : DataSet
	{
		#region 成员变量
		public const string PBSD_VIEW = "ViewValidOrderDetail";
		public const string PKID_FIELD				= "PKID";
		public const string BATCHCODE_FIELD			= "BatchCode";		//批号。
		public const string PLANNUM_FIELD			= "PlanNum";		//应收数量。
		public const string TAXCODE_FIELD			= "TaxCode";		//税收代码。
		public const string TAXRATE_FIELD			= "TaxRate";		//税率。
		public const string ITEMTAX_FIELD			= "ItemTax";		//税额。
		public const string ITEMSUM_FIELD			= "ItemSum";		//物料金额合计。
		#endregion

		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PBSD_VIEW);
            
			InItemData oItemData = new InItemData(table);

			DataColumnCollection columns = table.Columns;
			//收料单数据来源的特有字段。
			columns.Add(PBSDData.PKID_FIELD,		typeof(System.String));	//主键。
			columns.Add(PBSDData.BATCHCODE_FIELD,	typeof(System.String));	//批号。
			columns.Add(PBSDData.PLANNUM_FIELD, typeof(System.String)); //应收数量。
			columns.Add(PBSDData.TAXCODE_FIELD,		typeof(System.String));	//税码。
			columns.Add(PBSDData.TAXRATE_FIELD,		typeof(System.String));	//单项税率。
			columns.Add(PBSDData.ITEMTAX_FIELD,		typeof(System.String));	//单项税额。
			columns.Add(PBSDData.ITEMSUM_FIELD,		typeof(System.String));	//物料总金额。
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private PBSDData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PBSDData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
