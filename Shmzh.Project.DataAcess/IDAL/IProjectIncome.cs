using System.Collections.Generic;
using Shmzh.Project.Entity;
namespace Shmzh.Project.Data.IDAL
{
    /// <summary>
    /// 项目财务到帐信息的数据访问接口。
    /// </summary>
    public interface IProjectIncome
    {
        /// <summary>
        /// 新增项目财务到帐信息。
        /// </summary>
        /// <param name="obj">财务到帐信息实体</param>
        /// <returns>Id</returns>
        int Insert(ProjectIncomeInfo obj);
        /// <summary>
        /// 更改项目财务到帐信息
        /// </summary>
        /// <param name="obj">项目财务到帐信息</param>
        /// <returns>bool</returns>
        bool Update(ProjectIncomeInfo obj);
        /// <summary>
        /// 根据Id删除项目财务到帐信息。
        /// </summary>
        /// <param name="id">财务到帐信息Id</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 根据项目Id获取财务到帐记录
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns></returns>
        List<ProjectIncomeInfo> GetByProjectId(int projectId);
        /// <summary>
        /// 根据项目Id、年份、月份获取财务到帐信息。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>财务到帐信息</returns>
        ProjectIncomeInfo GetByProjectIdYearMonth(int projectId, int year, int month);
        /// <summary>
        /// 根据Id获取财务到帐信息。
        /// </summary>
        /// <param name="id">财务到帐信息Id</param>
        /// <returns>财务到帐信息</returns>
        ProjectIncomeInfo GetById(int id);
    }
}