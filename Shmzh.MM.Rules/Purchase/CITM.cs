
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// �������ҵ�����㡣
	/// </summary>
	public class CITM :Messages
	{
		#region ���캯��
		public CITM()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		public  object GetByRepCode(int RepCode)
		{
			CITMData oCITMData ;
			CITMs oCITMs = new CITMs();
			oCITMData = (CITMData)oCITMs.GetByRepCode(RepCode);
			return oCITMData;

		}
	}
}
