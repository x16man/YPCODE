using System;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// BillOfDocument 的摘要说明。
	/// </summary>
	public class BillOfDocument
	{
		public BillOfDocument()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//得到单据的序列号
		public int GetNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetNextNoByCode(DocCode);

		}

		//更新单据的序列号
		public bool UpdateNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).UpdateNextNoByCode(DocCode);
		}

		//得到单据的文档实体
		public BillOfDocumentData GetDocByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetDocByCode(DocCode);
		}		//End GetDocByCode
	}
}
