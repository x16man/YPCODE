using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{
	/// <summary>
	/// CatalogData 的摘要说明。
	/// <remarks>
	///		允许对象序列化
	/// </remarks>
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class CategoryData:DataSet
	{
		//
		// Categories table constants
		//
		/// <value>物资目录实体</value>
		public const String CATEGORIES_TABLE  = "WCAT";
		/// <value>类别代码</value>
		public const String CODE_FIELD        = "Code";
		/// <value>类别名称</value>
		public const String DESCRIPTION_FIELD   = "Description";
		/// <value>是否锁定</value>
		public const String LOCKED_FIELD = "Locked";
		/// <value>库存科目</value>
		public const String STORAGEACC_FIELD     = "StorageAcc";
		/// <value>转帐科目</value>
		public const String TRANSFERACC_FIELD     = "TransferAcc";
		/// <value>退货科目</value>
		public const String RETURNACC_FIELD     = "ReturnAcc";
		/// <value>备注</value>
		public const String REMARK_FIELD     = "Remark";
		/// <value>显示序列</value>
		public const String SERIAL_FIELD     = "Serial";


		//
		// Error messages
		//
		public const String CODE_NOT_NULL="分类编号不能为空";
		public const String DESCRIPTION_NOT_NULL="分类描述不能为空";
		public const String CODE_NOT_UNIQUE="分类编号必须唯一";

		public const String STORAGEACC_LABEL="库存科目";
		public const String TRANSFERACC_LABEL="转帐科目";
		public const String RETURNACC_LABEL="退货科目";
		public const String SERIAL_LABEL="显示序列";

		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private CategoryData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		/// <summary>
		///     Constructor for CategoryData.  
		///     <remarks>Initialize a CategoryData instance by building the table schema.</remarks> 
		/// </summary>
		public CategoryData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			BuildDataTables();
		}

		        
		//----------------------------------------------------------------
		// Sub BuildDataTables:
		//   Creates the following datatables:  Categories
		//----------------------------------------------------------------
		private void BuildDataTables()
		{
			//
			// Create the Categories table
			//
			DataTable table   = new DataTable(CATEGORIES_TABLE);
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CODE_FIELD, typeof(System.Int16));
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			columns.Add(LOCKED_FIELD, typeof(System.String)).DefaultValue='N';
			columns.Add(STORAGEACC_FIELD, typeof(System.String));
        	columns.Add(TRANSFERACC_FIELD, typeof(System.String));
			columns.Add(RETURNACC_FIELD, typeof(System.String));
			columns.Add(REMARK_FIELD, typeof(System.String));
			columns.Add(SERIAL_FIELD, typeof(System.Int16));

			this.Tables.Add(table);
		}
	}
}

       
