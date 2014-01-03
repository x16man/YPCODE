using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// ��ѯ����ؼ����͵����ݽӿڡ�
    /// </summary>
    public interface ISEControlParam
    {
        /// <summary>
        /// ��ӿؼ�������
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Insert(SEControlParamInfo obj);
        /// <summary>
        /// �޸Ŀؼ�������
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(SEControlParamInfo obj);
        /// <summary>
        /// ɾ���ؼ�����ʵ�塣
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(SEControlParamInfo obj);
        /// <summary>
        /// ɾ���ؼ�����ʵ�塣
        /// </summary>
        /// <param name="id">�ؼ�����ʵ��id��</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// ��ȡ���еĿؼ�������
        /// </summary>
        /// <returns>�ؼ��������ϡ�</returns>
        IList<SEControlParamInfo> GetByControlId(int controlId);
        /// <summary>
        /// ����Id��ȡ�ؼ�������
        /// </summary>
        /// <param name="id">�ؼ�����id��</param>
        /// <returns>�ؼ�����ʵ�塣</returns>
        SEControlParamInfo GetById(int id);
        
    }
}