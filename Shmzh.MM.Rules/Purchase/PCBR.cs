
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// �������յ���ҵ�����㡣
	/// </summary>
	public class PCBR :Messages,IInItem
	{
		#region ���캯��
		public PCBR()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region IInItem ��Ա
		/// <summary>
		/// �������յ������ӡ�
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(object Entry)
		{
			// TODO:  ��� PCBR.Insert ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.InsertEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ������Ӳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.InsertAndPresentEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(object Entry)
		{
			// TODO:  ��� PCBR.Update ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.UpdateEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  ��� PCBR.Update ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.UpdateAndPresentEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  ��� PCBR.Delete ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.DeleteEntry(EntryNo);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ���״̬�ı䡣
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬ ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  ��� PCBR.UpdateEntryState ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.UpdateEntryState(EntryNo,newState);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ���һ��������
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  ��� PCBR.FirstAduit ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.FirstAudit(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ��Ķ���������
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  ��� PCBR.SecondAduit ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.SecondAudit(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ�������������
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  ��� PCBR.ThirdAduit ʵ��
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.ThirdAudit(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�������յ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.Present(EntryNo, newState, UserLoginId);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �������յ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�������յ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.Cancel(EntryNo, newState);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// �����������յ�����ˮ������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  ��� PCBR.GetEntryByEntryNo ʵ��
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryByEntryNo(EntryNo);
			return oPCBRData;
		}
		/// <summary>
		/// �����������յ��ı������ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  ��� PCBR.GetEntryByEntryCode ʵ��
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryByEntryCode(EntryCode);
			return oPCBRData;
		}
		/// <summary>
		/// ��ȡ�����������յ���
		/// </summary>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryAll()
		{
			// TODO:  ��� PCBR.GetEntryAll ʵ��
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryAll();
			return oPCBRData;
		}
		/// <summary>
		/// ��ȡָ���Ƶ����ŵ��������յ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  ��� PCBR.GetEntryByDept ʵ��
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryByDept(DeptCode);
			return oPCBRData;
		}

		#endregion

		#region ר�г�Ա
		public CBRSData GetCBRSByPrvCode(string PrvCode)
		{
			CBRSData oCBRSData;
			PCBRs oPCBRs = new PCBRs();
			oCBRSData = oPCBRs.GetCBRSByPrvCode(PrvCode);
			return oCBRSData;
		}
		public CBRSData GetCBRSByPrvCodeAndDate(string PrvCode,DateTime StartDate,DateTime EndDate)
		{
			CBRSData oCBRSData;
			PCBRs oPCBRs = new PCBRs();
			oCBRSData = oPCBRs.GetCBRSByPrvCodeAndDate(PrvCode,StartDate,EndDate);
			return oCBRSData;
		}
		#endregion
	}
}