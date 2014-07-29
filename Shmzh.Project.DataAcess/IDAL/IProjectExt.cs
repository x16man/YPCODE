using System.Collections.Generic;
using Shmzh.Project.Entity;
namespace Shmzh.Project.Data.IDAL
{
    /// <summary>
    /// ��Ŀ��չ���Ե����ݷ��ʽӿڡ�
    /// </summary>
    public interface IProjectExt
    {
        /// <summary>
        /// �����Ŀ��չ����.
        /// </summary>
        /// <param name="obj">��Ŀ��չ����</param>
        /// <returns>bool</returns>
        bool Insert(ProjectExtInfo obj);
        /// <summary>
        /// ������Ŀ��չ����.
        /// </summary>
        /// <param name="obj">��Ŀ��չ����.</param>
        /// <returns>bool</returns>
        bool Update(ProjectExtInfo obj);
        /// <summary>
        /// ɾ����Ŀ��չ����.
        /// </summary>
        /// <param name="obj">��Ŀ��չ���Զ���.,</param>
        /// <returns>bool</returns>
        bool Delete(ProjectExtInfo obj);
        /// <summary>
        /// ɾ����Ŀ��չ����.
        /// </summary>
        /// <param name="projectId">��ĿId.</param>
        /// <returns>bool</returns>
        bool Delete(int projectId);
        /// <summary>
        /// ��ȡ������Ŀ��չ����.
        /// </summary>
        /// <returns>��Ŀ��չ���Լ���.</returns>
        List<ProjectExtInfo> GetAll();
        /// <summary>
        /// ������ĿId��ȡ��Ŀ��չ����.
        /// </summary>
        /// <param name="projectId">��ĿId.</param>
        /// <returns>��Ŀ��չ����.</returns>
        ProjectExtInfo GetByProjectId(int projectId);
    }
}