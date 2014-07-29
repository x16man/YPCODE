using System.Collections.Generic;
using Shmzh.Project.Entity;
namespace Shmzh.Project.Data.IDAL
{
    /// <summary>
    /// 项目年度财务到帐信息的数据访问接口。
    /// </summary>
    public interface IProjectYearIncome
    {
        /// <summary>
        /// 新增项目年度财务到帐信息。
        /// </summary>
        /// <param name="obj">财务年度到帐信息实体</param>
        /// <returns>Id</returns>
        int Insert(ProjectYearIncomeInfo obj);
        /// <summary>
        /// 更改项目年度财务到帐信息
        /// </summary>
        /// <param name="obj">项目年度财务到帐信息</param>
        /// <returns>bool</returns>
        bool Update(ProjectYearIncomeInfo obj);
        /// <summary>
        /// 根据Id删除项目财务年度到帐信息。
        /// </summary>
        /// <param name="id">财务年度到帐信息Id</param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// 根据项目Id获取财务年度到帐记录
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目的财务年度到帐记录</returns>
        List<ProjectYearIncomeInfo> GetByProjectId(int projectId);
        /// <summary>
        /// 根据项目Id、年份、月份获取财务年度到帐信息。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="year">年份</param>
        /// <returns>财务年度到帐信息</returns>
        ProjectYearIncomeInfo GetByProjectIdYear(int projectId, int year);
        /// <summary>
        /// 根据Id获取财务年度到帐信息。
        /// </summary>
        /// <param name="id">财务年度到帐信息Id</param>
        /// <returns>财务年度到帐信息</returns>
        ProjectYearIncomeInfo GetById(int id);
    }
}