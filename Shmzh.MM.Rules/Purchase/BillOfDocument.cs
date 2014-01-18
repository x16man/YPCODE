using System;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// BillOfDocument ��ժҪ˵����
	/// </summary>
	public class BillOfDocument
	{
		public BillOfDocument()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		//�õ����ݵ����к�
		public int GetNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetNextNoByCode(DocCode);

		}

		//���µ��ݵ����к�
		public bool UpdateNextNoByCode(int DocCode)
		{
			return (new BillOfDocuments()).UpdateNextNoByCode(DocCode);
		}

		//�õ����ݵ��ĵ�ʵ��
		public BillOfDocumentData GetDocByCode(int DocCode)
		{
			return (new BillOfDocuments()).GetDocByCode(DocCode);
		}		//End GetDocByCode
	}
}
