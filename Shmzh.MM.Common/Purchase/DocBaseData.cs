using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{

	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class DocBaseData 
	{

		/// <value>���ݱ�ʶ��</value>
		public const String DOCCODE_FIELD        = "DocCode";
		/// <value>��������</value>
		public const String DOCNAME_FIELD   = "DocName";
		/// <value>�����ĵ����</value>
		public const String DOCNO_FIELD = "DocNo";

		public DocBaseData(DataTable table)
		{
			DataColumnCollection columns = table.Columns;
        
			columns.Add(DOCCODE_FIELD, typeof(System.Int16));
			columns.Add(DOCNAME_FIELD, typeof(System.String));
			columns.Add(DOCNO_FIELD, typeof(System.String));

		}

	}
}
