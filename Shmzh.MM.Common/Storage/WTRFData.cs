namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   

	/// <summary>
	/// WTRFData 的摘要说明。
	/// </summary>
	/// 
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WTRFData:DataSet
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
		public const string ROLL_SUCCESSED="转库操作成功";
		#endregion

		#region 成员变量
		/// <value>单据描述实体</value>
		public const string WTRF_TABLE  = "WTRF";								//表名。
		public const string TGTSTONAME_FIELD		= "TgtStoName";				//转入仓库名称。
		public const string TGTSTOCODE_FIELD  = "TgtStoCode";					//转入仓库编号。
		public const string SRCSTOCODE_FIELD		= "SrcStoCode";				//发出仓库编号。
		public const string SRCSTONAME_FIELD    = "SrcStoName";					//发出仓库名称。
		public const string TRANSFERDATE_FIELD = "TransferDate";				//转库日期。
		public const string SRCSTOMANAGERCODE_FIELD     = "SrcStoManagerCode";	//发出仓库管理员编号。
		public const string SRCSTOMANAGER_FIELD       = "SrcStoManager";		//发出仓库管理员名称。
		public const string TGTSTOMANAGERCODE_FIELD		= "TgtStoManagerCode";	//转入仓库管理员编号。
		public const string TGTSTOMANAGER_FIELD  = "TgtStoManager";				//转入仓库管理员名称。
		public const string PLANNUM_FIELD		= "PlanNum";					//应转数量。
//		public const string ITEMNUM_FIELD    = "ItemNum";						//实转数量。
		public const string JFKM_FIELD            = "JFKM";						//借方科目。

		public const string CONNAME_FIELD= "ConName";							//架位名称
		public const string CONCODE_FIELD = "ConCode";							//架位编号
		public const string OUT_FAILED= "转库单发料失败！";
		public const string OUT_SUCCESSED = "转库单发料成功！";

		
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
		/// 转库单的记录数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[WTRFData.WTRF_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建转库单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(WTRF_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;

			columns.Add(TGTSTONAME_FIELD, typeof(System.String));			//转入仓库名称。
			columns.Add(TGTSTOCODE_FIELD, typeof(System.String));			//转入仓库编号。
			columns.Add(SRCSTOCODE_FIELD, typeof(System.String));			//发出仓库编号。
			columns.Add(SRCSTONAME_FIELD, typeof(System.String));			//发出仓库名称。
			columns.Add(TRANSFERDATE_FIELD, typeof(System.String));		//转库日期。
			columns.Add(SRCSTOMANAGERCODE_FIELD, typeof(System.String));	//发出仓库管理员编号。
			columns.Add(SRCSTOMANAGER_FIELD, typeof(System.String));		//发出仓库管理员名称。
			columns.Add(TGTSTOMANAGERCODE_FIELD, typeof(System.String));	//转入仓库管理员编号。
			columns.Add(TGTSTOMANAGER_FIELD, typeof(System.String));		//转入仓库管理员名称。
			columns.Add(PLANNUM_FIELD, typeof(System.String));				//应转数量。
		//	columns.Add(ITEMNUM_FIELD, typeof(System.Decimal));				//实转数量。
			columns.Add(JFKM_FIELD,typeof(System.String));						//借方科目。
		
			System.Data.DataColumn[] myPrimCol = new System.Data.DataColumn[1];
			myPrimCol[0] = table.Columns[InItemData.ENTRYNO_FIELD];
			table.PrimaryKey = myPrimCol;
			
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private WTRFData(SerializationInfo info, StreamingContext context) : base(info, context) 
	{		
	}

		public WTRFData()
		{
			BuildDataTables();
		}
		#endregion
		
	}
}
