using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{
	/// <summary>
	/// CheckReportData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	public class CheckReportData:DataSet
	{
		/// <value></value>
		public const String CHECKREPORT_TABLE  = "WREP";
		/// <value>代码</value>
		public const String CODE_FIELD        = "Code";
		/// <value>名称</value>
		public const String DESCRIPTION_FIELD   = "Description";

		public const String LOCKED_FIELD     = "Locked";
		
		//
		// Error messages
		//

		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private CheckReportData(SerializationInfo info, StreamingContext context) : base(info, context) 
	{		
	}

		/// <summary>
		///     Constructor for UnitData.  
		///     <remarks>Initialize a UnitData instance by building the table schema.</remarks> 
		/// </summary>
		public CheckReportData()
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
			DataTable table   = new DataTable(CHECKREPORT_TABLE);
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CODE_FIELD, typeof(System.Int16));
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));

			columns.Add(LOCKED_FIELD, typeof(System.String)).DefaultValue="N";

			this.Tables.Add(table);
		}
	}
}
