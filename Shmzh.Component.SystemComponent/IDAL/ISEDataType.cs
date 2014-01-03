using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// ��ѯ����Ŀؼ��������������ݽӿڡ�
    /// </summary>
    public interface ISEDataType
    {
        /// <summary>
        /// ����������͡�
        /// </summary>
        /// <param name="obj">��������ʵ�塣</param>
        /// <returns>bool</returns>
        bool Insert(SEDataTypeInfo obj);
        /// <summary>
        /// �޸��������͡�
        /// </summary>
        /// <param name="obj">��������ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(SEDataTypeInfo obj);
        /// <summary>
        /// ɾ���������͡�
        /// </summary>
        /// <param name="obj">��������ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(SEDataTypeInfo obj);
        /// <summary>
        /// ɾ���������͡�
        /// </summary>
        /// <param name="id">��������Id��</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// ��ȡ�����������ͼ��ϡ�
        /// </summary>
        /// <returns>�������ͼ��ϡ�</returns>
        IList<SEDataTypeInfo> GetAll();
        /// <summary>
        /// ����id��ȡ�������͡�
        /// </summary>
        /// <param name="id">��������Id</param>
        /// <returns>��������ʵ�塣</returns>
        SEDataTypeInfo GetById(int id);
        /// <summary>
        /// �ж�ID�Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        bool IsExist(int id);
        /// <summary>
        /// �ж������Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="name">���ơ�</param>
        /// <returns>bool</returns>
        bool IsExist(string name);
    }
}