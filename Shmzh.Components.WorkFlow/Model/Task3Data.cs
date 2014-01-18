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


namespace Shmzh.Components.WorkFlow
{
	using System.Data;

    /// <summary>
	/// 待办事宜的三级审批专用的实体层。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[System.SerializableAttribute] 
	public class Task3Data	: DataSet
	{
		#region Field
		/// <summary>
		/// DataTable的表名。
		/// </summary>
		public const string Task3_Table = "Task3";					//三级审批任务表。
		public const string Task_ID_Field = "Task_ID";				//任务ID。
		public const string Entity_ID_Field = "Entity_ID";			//单据ID。
		public const string DocCode_Field = "DocCode";				//单据类型。
		public const string ReqDeptCode_Field = "ReqDeptCode";		//申请部门编号。
		public const string ReqDeptName_Field = "ReqDeptName";		//申请部门名称。
		public const string SerialNo_Field = "SerialNo";			//序列号。
		public const string ItemCode_Field = "ItemCode";			//物料编号。
		public const string ItemName_Field = "ItemName";			//物料名称。
		public const string ItemSpec_Field = "ItemSpec";			//规格型号。
		public const string UnitCode_Field = "UnitCode";			//单位编号。
		public const string UnitName_Field = "UnitName";			//单位名称。
		public const string ItemNum_Field = "ItemNum";				//数量。
		public const string ItemMoney_Field = "ItemMoney";			//金额。
		public const string UseCode_Field = "UseCode";				//用途编号。
		public const string UseName_Field = "UseName";				//用途名称。
		public const string ReqDate_Field = "ReqDate";				//要求日期。
		public const string Level_Field = "Level";					//紧急程度。
		public const string ABC_Field = "ABC";						//ABC分类。
		public const string Grantor_ID_Field = "Grantor_ID";		//安排操作人。
		public const string Staff_ID_Field = "Staff_ID";			//实际操作人。
		public const string Assessor1_Field = "Assessor1";			//一级审批人。
		public const string Assessor2_Field = "Assessor2";			//二级审批人。
		public const string Assessor3_Field = "Assessor3";			//三级审批人。
		#endregion

		#region private method
		private void BuildDataTable()
		{
			var table   = new DataTable(Task3_Table);
			//添加字段。
			table.Columns.Add(Task_ID_Field, typeof(System.Int32));
			table.Columns.Add(Entity_ID_Field, typeof(System.Int32));
			table.Columns.Add(DocCode_Field, typeof(System.Int16));
			table.Columns.Add(ReqDeptCode_Field, typeof(System.String));
			table.Columns.Add(ReqDeptName_Field, typeof(System.String));
			table.Columns.Add(SerialNo_Field, typeof(System.Int16));
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));			
			table.Columns.Add(ItemSpec_Field, typeof(System.String));
			table.Columns.Add(UnitCode_Field, typeof(System.Int16));
			table.Columns.Add(UnitName_Field, typeof(System.String));
			table.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			table.Columns.Add(UseCode_Field, typeof(System.String));
			table.Columns.Add(UseName_Field, typeof(System.String));
			table.Columns.Add(ReqDate_Field, typeof(System.DateTime));
			table.Columns.Add(Level_Field, typeof(System.String));
			table.Columns.Add(ABC_Field, typeof(System.String));
			table.Columns.Add(Grantor_ID_Field, typeof(System.String));
			table.Columns.Add(Staff_ID_Field, typeof(System.String));
			table.Columns.Add(Assessor1_Field, typeof(System.String));
			table.Columns.Add(Assessor2_Field, typeof(System.String));
			table.Columns.Add(Assessor3_Field, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region CTOR
		public Task3Data()
		{
			BuildDataTable();
		}
		#endregion
	}
}
