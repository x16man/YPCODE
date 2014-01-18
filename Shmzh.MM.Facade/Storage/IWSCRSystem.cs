namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IWSCRSystem ��ժҪ˵����
	/// </summary>
	public interface IWSCRSystem
	{
		/// <summary>
		/// ���ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWSCR(WSCRData oEntry);
		/// <summary>
		/// ���ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWSCR(WSCRData oEntry);
		/// <summary>
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWSCR(int EntryNo);
		/// <summary>
		/// ���ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWSCR(int EntryNo, string UserLoginId);
		/// <summary>
		/// ���ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWSCR(int EntryNo);
		/// <summary>
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWSCR(WSCRData oEntry);
		/// <summary>
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWSCR(WSCRData oEntry);
		/// <summary>
		/// ���ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">WSCRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWSCR(WSCRData oEntry);
		/// <summary>
		/// ��ȡ���б��ϵ���
		/// </summary>
		/// <returns>WSCRData:	����ʵ�塣</returns>
		WSCRData GetWSCRAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WSCRData:	����ʵ�塣</returns>
		WSCRData GetWSCRByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WSCRData:	����ʵ�塣</returns>
		WSCRData GetWSCRByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WSCRData:	����ʵ�塣</returns>
		WSCRData GetWSCRByDept(string DeptCode);
		/// <summary>
		/// ��ȡ���б��ϵ�������Դ��
		/// </summary>
		/// <returns></returns>
		WSCRData GetWSCRSAll();
		/// <summary>
		/// ��ȡָ�����ϵ�������Դ��
		/// </summary>
		/// <param name="PKIDs"></param>
		/// <returns></returns>
		WSCRData GetWSCRSByPKIDs(string PKIDs);
		/// <summary>
		/// ���ϵ�ȷ��
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <returns></returns>
		bool AffirmWSCR(int EntryNo, string UserLoginId);
	}
}
