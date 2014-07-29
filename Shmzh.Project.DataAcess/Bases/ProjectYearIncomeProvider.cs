using System;
using System.Collections.Generic;
using System.Data;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.Bases
{
    public abstract class ProjectYearIncomeProvider: IDAL.IProjectYearIncome
    {
        #region Protected Method
        protected ProjectYearIncomeInfo ConvertToObject(IDataReader dr)
        {
            var obj = new ProjectYearIncomeInfo();
            obj.Id = int.Parse(dr["Id"].ToString());
            obj.ProjectId = int.Parse(dr["ProjectId"].ToString());
            obj.Year = int.Parse(dr["Year"].ToString());
            obj.Amount = decimal.Parse(dr["Amount"].ToString());
            return obj;
        }
        #endregion

        #region Implementation of IProjectYearIncome

        /// <summary>
        /// 新增项目年度财务到帐信息。
        /// </summary>
        /// <param name="obj">财务年度到帐信息实体</param>
        /// <returns>Id</returns>
        public abstract int Insert(ProjectYearIncomeInfo obj);

        /// <summary>
        /// 更改项目年度财务到帐信息
        /// </summary>
        /// <param name="obj">项目年度财务到帐信息</param>
        /// <returns>bool</returns>
        public abstract bool Update(ProjectYearIncomeInfo obj);

        /// <summary>
        /// 根据Id删除项目财务年度到帐信息。
        /// </summary>
        /// <param name="id">财务年度到帐信息Id</param>
        /// <returns>bool</returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// 根据项目Id获取财务年度到帐记录
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目的财务年度到帐记录</returns>
        public abstract List<ProjectYearIncomeInfo> GetByProjectId(int projectId);

        /// <summary>
        /// 根据项目Id、年份、月份获取财务年度到帐信息。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="year">年份</param>
        /// <returns>财务年度到帐信息</returns>
        public abstract ProjectYearIncomeInfo GetByProjectIdYear(int projectId, int year);

        /// <summary>
        /// 根据Id获取财务年度到帐信息。
        /// </summary>
        /// <param name="id">财务年度到帐信息Id</param>
        /// <returns>财务年度到帐信息</returns>
        public abstract ProjectYearIncomeInfo GetById(int id);

        #endregion
    }
}
