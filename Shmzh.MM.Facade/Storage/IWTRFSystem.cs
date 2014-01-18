namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IWTRFSystem ��ժҪ˵����
	/// </summary>
	public interface IWTRFSystem
	{
		/// <summary>
		/// ת�ⵥ�����ӡ�
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWTRF(WTRFData oEntry);
		/// <summary>
		/// ת�ⵥ���޸ġ�
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWTRF(WTRFData oEntry);
		/// <summary>
		/// ת�ⵥ��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWTRF(int EntryNo);
		/// <summary>
		/// ת�ⵥ���ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWTRF(int EntryNo, string UserLoginId);
		/// <summary>
		/// ת�ⵥ�����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWTRF(int EntryNo);
		/// <summary>
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWTRF(WTRFData oEntry);
		/// <summary>
		/// ת�ⵥ�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWTRF(WTRFData oEntry);
		/// <summary>
		/// ת�ⵥ�ĳ���������
		/// </summary>
		/// <param name="oEntry">WTRFData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWTRF(WTRFData oEntry);
		/// <summary>
		/// ��ȡ����ת�ⵥ��
		/// </summary>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		WTRFData GetWTRFAll();
		/// <summary>
		/// ������ˮ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		WTRFData GetWTRFByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		WTRFData GetWTRFByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡת�ⵥ��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		WTRFData GetWTRFByDept(string DeptCode);
		/// <summary>
		/// ��ȡ����ת�ⵥ������Դ��
		/// </summary>
		/// <returns></returns>
		WTRFData GetWTRFSAll();
		/// <summary>
		/// ��ȡָ��ת�ⵥ������Դ��
		/// </summary>
		/// <param name="PKIDs"></param>
		/// <returns></returns>
		WTRFData GetWTRFSByPKIDs(string PKIDs);

		/// <summary>
		/// ������ˮ�Ż�ȡת��ģʽ�µ�ת�ⵥ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WTRFData:	����ʵ�塣</returns>
		WTRFData GetWTRFByEntryNoOutMode(int EntryNo);		
		/// <summary>
		/// ת�ⵥȷ��
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <returns></returns>
		bool AffirmWTRF(int EntryNo, string UserLoginId);
		}
	}
