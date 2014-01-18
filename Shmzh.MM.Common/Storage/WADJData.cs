namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   

	/// <summary>
	/// WADJData 的摘要说明。
	/// </summary>
	/// 
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WADJData:DataSet
	{
		#region 返回信息
		public const string NOOBJECT = "";
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
		public const string AFFIRM_SUCCESSED = "";
		public const string AFFIRM_FAILED = "";
		public const string ROLL_FAILED="库存不足，不能发货";
		public const string ROLL_SUCCESSED="架位调整操作成功";
		#endregion

		#region 成员变量
		/// <value>单据描述实体</value>
		public const string WADJ_TABLE  = "WADJ";						//表名。
		public const string PKID_FIELD = "PKID";						//库存主键。
		public const string STONAME_FIELD = "StoName";					//仓库名称。
		public const string STOCODE_FIELD = "StoCode";					//仓库编号。
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";	//仓库管理员编号。
		public const string STOMANAGER_FIELD = "StoManager";			//仓库管理员名称。
		public const string STOCKNUM_FIELD = "StockNum";				//库存数量。
		public const string JFKM_FIELD = "JFKM";						//借方科目。
		public const string SRCCONNAME_FIELD= "SrcConName";				//源架位名称
		public const string SRCCONCODE_FIELD = "SrcConCode";			//源架位编号
		public const string TGTCONNAME_FIELD= "TgtConName";				//目标架位名称
		public const string TGTCONCODE_FIELD = "TgtConCode";			//目标架位编号
		public const string OUT_FAILED= "架位调整单发料失败！";
		public const string OUT_SUCCESSED = "架位调整单发料成功！";
		public const string XDelete = "只有在作废的状态下才允许删除！";
		public const string XCancel = "只有在新建或者审批不通过的前提下，才允许对单据进行作废操作！";
		public const string XPresent = "只有在新建或者审批不通过的前提下，才允许对单据进行提交操作！";
		public const string XFirstAudit = "只有在单据已经提交的状态下，才允许对单据进行一级审批！";
		public const string XSecondAudit = "只有在单据一级审批通过的前提下，才允许对单据进行二级审批！";
		public const string XThirdAudit = "只有在单据二级审批通过的前提下，才允许对单据进行三级审批！";
		public const string XUpdate = "只有在单据在新建,作废,审批不通过的前提下，才允许对单据进行修改！";
		
		#endregion

		#region 属性
		/// <summary>
		/// 架位调整单的记录数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[WADJData.WADJ_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建架位调整单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(WADJ_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(PKID_FIELD, typeof(System.String));				//库存记录ID。
			columns.Add(STONAME_FIELD, typeof(System.String));			//仓库名称。
			columns.Add(STOCODE_FIELD, typeof(System.String));			//仓库编号。			
			columns.Add(STOMANAGERCODE_FIELD, typeof(System.String));	//仓库管理员编号。
			columns.Add(STOMANAGER_FIELD, typeof(System.String));		//仓库管理员名称。
			columns.Add(STOCKNUM_FIELD, typeof(System.String));			//库存数量。
			columns.Add(JFKM_FIELD,typeof(System.String));				//借方科目。
			columns.Add(SRCCONCODE_FIELD,typeof(System.String));		//源架位编号。
			columns.Add(SRCCONNAME_FIELD,typeof(System.String));		//源架位名称。
			columns.Add(TGTCONCODE_FIELD,typeof(System.String));		//目标架位编号。
			columns.Add(TGTCONNAME_FIELD,typeof(System.String));		//目标架位名称。

			System.Data.DataColumn[] myPrimCol = new System.Data.DataColumn[1];
			myPrimCol[0] = table.Columns[InItemData.ENTRYNO_FIELD];
			table.PrimaryKey = myPrimCol;
			
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private WADJData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WADJData()
		{
			BuildDataTables();
		}
		#endregion
		
	}
}
