using System;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// �����͵���Ӧ��ʵ�ֵĹ����ӿڡ�
	/// </summary>
	public interface IInItems 
	{
		/// <summary>
		/// �����͵������롣
		/// </summary>
		/// <param name="Entry">object:	���ݶ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool InsertEntry(object Entry);
		/// <summary>
		/// �����͵��ݸ��ġ�
		/// </summary>
		/// <param name="Entry">object:	���ݶ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateEntry(object Entry);
		/// <summary>
		/// �����͵���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteEntry(int EntryNo);
		/// <summary>
		/// ���������͵���״̬��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateEntryState(int EntryNo,string newState);
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAudit(object Entry);
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAudit(object Entry);
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAudit(object Entry);
		/// <summary>
		/// �����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Present(int EntryNo, string newState,string UserLoginId);
		/// <summary>
		/// �������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Cancel(int EntryNo, string newState);
		/// <summary>
		/// ���ݵ�����ˮ�Ż�õ�����Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	���ݶ���ʵ�塣</returns>
		object GetEntryByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݵ��ݱ�Ż�õ�����Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	���ݶ���ʵ�塣</returns>
		object GetEntryByEntryCode(string EntryCode);
		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	���ݶ���ʵ�塣</returns></returns>
		object GetEntryAll();
		/// <summary>
		/// �������벿�ű�ţ���ȡ���вɹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	���ű�š�</param>
		/// <returns>object:	���ݶ���ʵ�塣</returns>
		object GetEntryByDept(string DeptCode);

	}
}
