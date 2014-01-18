namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IWADJSystem ��ժҪ˵����
	/// </summary>
	public interface IWADJSystem
	{
		/// <summary>
		/// ת�ⵥ�����ӡ�
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWADJ(WADJData oEntry);
		/// <summary>
		/// ת�ⵥ���޸ġ�
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWADJ(WADJData oEntry);
		/// <summary>
		/// ת�ⵥ��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWADJ(int EntryNo);
		/// <summary>
		/// ת�ⵥ���ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWADJ(int EntryNo, string UserLoginId);
		/// <summary>
		/// ת�ⵥ�����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWADJ(int EntryNo);
		/// <summary>
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWADJ(WADJData oEntry);
		/// <summary>
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWADJ(WADJData oEntry);
		/// <summary>
		/// ת�ⵥ�ĳ���������
		/// </summary>
		/// <param name="oEntry">WADJData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWADJ(WADJData oEntry);
		/// <summary>
		/// ��ȡ����ת�ⵥ��
		/// </summary>
		/// <returns>WADJData:	����ʵ�塣</returns>
		WADJData GetWADJAll();
		/// <summary>
		/// ������ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		WADJData GetWADJByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		WADJData GetWADJByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		WADJData GetWADJByDept(string DeptCode);
		/// <summary>
		/// ��ȡ����ת�ⵥ������Դ��
		/// </summary>
		/// <returns></returns>
		WADJData GetWADJSAll();
		/// <summary>
		/// ��ȡָ��ת�ⵥ������Դ��
		/// </summary>
		/// <param name="PKIDs"></param>
		/// <returns></returns>
		WADJData GetWADJSByPKIDs(string PKIDs);

		/// <summary>
		/// ������ˮ�Ż�ȡת��ģʽ�µ�ת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WADJData:	����ʵ�塣</returns>
		WADJData GetWADJByEntryNoOutMode(int EntryNo);		
		
	}
}
