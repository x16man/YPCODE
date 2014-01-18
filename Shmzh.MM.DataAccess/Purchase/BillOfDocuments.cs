using System;
using System.Data;
using MZHCommon.Database;
using System.Collections;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// ��������������ݷ��ʲ㡣
	/// ��������ʵ���ṩ�˵��ݵ�һЩ������Ϣ��
	/// �������������ͱ�š������������ơ������ĵ���š����ݵ����������ȡ�
	/// ��� <see cref="Common.BillOfDocumentData"/>�ࡣ
	/// </summary>
	public class BillOfDocuments:Messages
	{
		/// <summary>
		/// BillOfDocuments�Ĺ��캯����
		/// </summary>
		public BillOfDocuments()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ��ȡָ�����͵��ݵĵ�ǰ�������кš�
		/// </summary>
		/// <param name="DocCode">int:	�������ͱ�š�</param>
		/// <returns>int:	��һ��������ˮ�š�</returns>
		/// <remarks>δ�����ù���</remarks>
		public int GetNextNoByCode(int DocCode)
		{
			int ret=0;

			BillOfDocumentData oEntry=GetDocByCode(DocCode);
			if (oEntry.Tables[BillOfDocumentData.SBOD_TABLE].Rows.Count>0)
			{
				ret= int.Parse(oEntry.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0][BillOfDocumentData.NEXTNO_FIELD].ToString());
			}
			return ret;
		}

		/// <summary>
		/// ���µ�ǰָ�����͵��ݵĿ������кš�
		/// </summary>
		/// <param name="DocCode">int:	�������ͱ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		/// <remarks>δ�����ù���</remarks>
		public bool UpdateNextNoByCode(int DocCode)
		{
			bool ret=true;

			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
			myHT.Add ("@DocCode", DocCode);

			if ((new SQLServer()).ExecSP("Sys_DocUpdateNextNo",myHT)==false)
			{
				this.Message="Error,Sys_DocUpdateNextNo,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// ��ȡָ�����͵��ݵĵ��������ĵ�ʵ�塣
		/// </summary>
		/// <param name="DocCode">int:	�������ͱ�š�</param>
		/// <returns>BillOfDocumentData:	���������ĵ�ʵ�塣</returns>
		public BillOfDocumentData GetDocByCode(int DocCode)
		{

			Hashtable myHT = new Hashtable();	//�洢���̲����Ĺ�ϣ��

			BillOfDocumentData oBOD=new BillOfDocumentData();

			myHT.Add ("@DocCode", DocCode);

			if ((new SQLServer()).ExecSPReturnDS("Sys_DocGetDocByCode",myHT,oBOD.Tables[BillOfDocumentData.SBOD_TABLE])==false)
			{
				this.Message="Error,Sys_DocGetDocByCode,Please look the log file!";
			}

			return oBOD;
		}		//End GetDocByCode

	}
}
