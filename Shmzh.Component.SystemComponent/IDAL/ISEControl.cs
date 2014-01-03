using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// ��ѯ����ؼ������ݽӿڡ�
    /// </summary>
    public interface ISEControl
    {
        /// <summary>
        /// ��ӿؼ���
        /// </summary>
        /// <param name="obj">�ؼ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Insert(SEControlInfo obj);
        /// <summary>
        /// �޸Ŀؼ���
        /// </summary>
        /// <param name="obj">�ؼ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(SEControlInfo obj);
        /// <summary>
        /// ɾ���ؼ���
        /// </summary>
        /// <param name="obj">�ؼ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(SEControlInfo obj);
        /// <summary>
        /// ɾ���ؼ���
        /// </summary>
        /// <param name="id">�ؼ�Id��</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// ���ݲ�ѯģ��Id��ȡ���пؼ����ϡ�
        /// </summary>
        /// <param name="moduleId">��ѯģ��id��</param>
        /// <returns>�ؼ����ϡ�</returns>
        IList<SEControlInfo> GetAllByModuleId(string moduleId);
        /// <summary>
        /// ���ݲ�ѯģ��Id��ȡ������Ч�ؼ����ϡ�
        /// </summary>
        /// <param name="moduleId">��ѯģ��id��</param>
        /// <returns>�ؼ����ϡ�</returns>
        IList<SEControlInfo> GetAllAvalibleByModuleId(string moduleId);
        /// <summary>
        /// ���ݿؼ�Id��ȡ�ؼ���
        /// </summary>
        /// <param name="id">�ؼ�id��</param>
        /// <returns>�ؼ�ʵ�塣</returns>
        SEControlInfo GetById(int id);
    }
}