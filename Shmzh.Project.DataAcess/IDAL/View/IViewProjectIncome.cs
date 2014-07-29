using System.Collections.Generic;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.IDAL
{
    /// <summary>
    /// 项目财务到帐信息视图的数据访问接口。
    /// </summary>
    public interface IViewProjectIncome
    {
        /// <summary>
        /// 根据项目Id获取项目财务到帐信息集合。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目财务到帐信息集合。</returns>
        List<ViewProjectIncomeInfo> GetByProjectId(int projectId);

        /// <summary>
        /// 根据项目Id、年份、月份获取项目财务到帐信息实体。
        /// </summary>
        /// <param name="projectId">项目Id。</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>财务到帐信息实体。</returns>
        ViewProjectIncomeInfo GetByProjectIdYearMonth(int projectId, int year, int month);

        /// <summary>
        /// 根据Id获取项目财务到帐信息实体。
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>财务到帐信息实体。</returns>
        ViewProjectIncomeInfo GetById(int id);
    }
}