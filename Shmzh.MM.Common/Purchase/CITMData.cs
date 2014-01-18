using System;
using System.Data;
using System.Runtime.Serialization;

namespace Shmzh.MM.Common
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class CITMData:DataSet
	{
		//
		// CITM table constants
		//
		public const String CITM_TABLE			= "CITM";


		public const String CODE_FIELD			= "code";
		public const String DESCRIPTION_FIELD   = "description";
		public const String REPCODE_FIELD		= "RepCode";
		public const string SERIALNO_FIELD		= "SerialNo";
		public const string UNIT_FIELD			= "Unit";
		public const string ENABLE_FIELD		= "Enable";

		public CITMData()
		{
			BuildDataTables();
		}

		private CITMData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		private void BuildDataTables()
		{
			DataTable table   = new DataTable(CITM_TABLE);
			
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CITMData.CODE_FIELD, typeof(System.Int32));
			columns.Add(CITMData.DESCRIPTION_FIELD, typeof(System.String));
			columns.Add(CITMData.REPCODE_FIELD, typeof(System.Int32));
			columns.Add(CITMData.SERIALNO_FIELD, typeof(System.Int32));
			columns.Add(CITMData.UNIT_FIELD, typeof(System.String));
			columns.Add(CITMData.ENABLE_FIELD, typeof(System.String));
			
			this.Tables.Add(table);
		}

	}
}

       

