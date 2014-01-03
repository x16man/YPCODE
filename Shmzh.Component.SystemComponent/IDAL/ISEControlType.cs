using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// ��ѯ����ؼ����͵����ݽӿڡ�
    /// </summary>
    public interface ISEControlType
    {
        /// <summary>
        /// ��ӿؼ����͡�
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Insert(SEControlTypeInfo obj);
        /// <summary>
        /// �޸Ŀؼ����͡�
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(SEControlTypeInfo obj);
        /// <summary>
        /// ɾ���ؼ�����ʵ�塣
        /// </summary>
        /// <param name="obj">�ؼ�����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(SEControlTypeInfo obj);
        /// <summary>
        /// ɾ���ؼ�����ʵ�塣
        /// </summary>
        /// <param name="id">�ؼ�����ʵ��id��</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// ��ȡ���еĿؼ����͡�
        /// </summary>
        /// <returns>�ؼ����ͼ��ϡ�</returns>
        IList<SEControlTypeInfo> GetAll();
        /// <summary>
        /// ����Id��ȡ�ؼ����͡�
        /// </summary>
        /// <param name="id">�ؼ�����id��</param>
        /// <returns>�ؼ�����ʵ�塣</returns>
        SEControlTypeInfo GetById(int id);
        /// <summary>
        /// �ж�id�Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="id">id��</param>
        /// <returns>bool</returns>
        bool IsExist(int id);
        /// <summary>
        /// �ж������Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsExist(string name);
    }
}