using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// ��ѯ���������ݷ��ʽӿڡ�
    /// </summary>
    public interface ISESchema
    {
        /// <summary>
        /// ��Ӳ�ѯ������
        /// </summary>
        /// <param name="obj">��ѯ����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Insert(SESchemaInfo obj);
        /// <summary>
        /// �޸Ĳ�ѯ������
        /// </summary>
        /// <param name="obj">��ѯ����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(SESchemaInfo obj);
        /// <summary>
        /// ɾ����ѯ������
        /// </summary>
        /// <param name="obj">��ѯ����ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(SESchemaInfo obj);
        /// <summary>
        /// ɾ����ѯ������
        /// </summary>
        /// <param name="id">��ѯ����Id��</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// ���ݲ�ѯģ����û���ȡ���в�ѯ�������ϡ�
        /// </summary>
        /// <param name="moduleId">��ѯģ��Id��</param>
        /// <param name="userCode">�û�����</param> 
        /// <returns>��ѯ�������ϡ�</returns>
        IList<SESchemaInfo> GetByModuleAndUser(string moduleId, string userCode);
        /// <summary>
        /// ���ݲ�ѯģ����û���ȡĬ�ϵĲ�ѯ������
        /// </summary>
        /// <param name="moduleId">��ѯģ��Id��</param>
        /// <param name="userCode">�û�����</param>
        /// <returns>��ѯ����Id��</returns>
        SESchemaInfo GetDefaultByModuleAndUser(string moduleId, string userCode);
        /// <summary>
        /// ����id��ȡ��ѯ������
        /// </summary>
        /// <param name="id">��ѯ����Id</param>
        /// <returns>��ѯ����ʵ�塣</returns>
        SESchemaInfo GetById(int id);
        
        /// <summary>
        /// �жϲ�ѯ���������Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="moduleId">��ѯģ��Id��</param>
        /// <param name="userCode">�û�����</param>
        /// <param name="schemaName">��ѯ�������ơ�</param>
        /// <returns>bool</returns>
        bool IsExist(string moduleId,string userCode, string schemaName);
    }
}