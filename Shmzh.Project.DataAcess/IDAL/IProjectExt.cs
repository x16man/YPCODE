using System.Collections.Generic;
using Shmzh.Project.Entity;
namespace Shmzh.Project.Data.IDAL
{
    /// <summary>
    /// 项目扩展属性的数据访问接口。
    /// </summary>
    public interface IProjectExt
    {
        /// <summary>
        /// 添加项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性</param>
        /// <returns>bool</returns>
        bool Insert(ProjectExtInfo obj);
        /// <summary>
        /// 更改项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性.</param>
        /// <returns>bool</returns>
        bool Update(ProjectExtInfo obj);
        /// <summary>
        /// 删除项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性对象.,</param>
        /// <returns>bool</returns>
        bool Delete(ProjectExtInfo obj);
        /// <summary>
        /// 删除项目扩展属性.
        /// </summary>
        /// <param name="projectId">项目Id.</param>
        /// <returns>bool</returns>
        bool Delete(int projectId);
        /// <summary>
        /// 获取所有项目扩展属性.
        /// </summary>
        /// <returns>项目扩展属性集合.</returns>
        List<ProjectExtInfo> GetAll();
        /// <summary>
        /// 根据项目Id获取项目扩展属性.
        /// </summary>
        /// <param name="projectId">项目Id.</param>
        /// <returns>项目扩展属性.</returns>
        ProjectExtInfo GetByProjectId(int projectId);
    }
}