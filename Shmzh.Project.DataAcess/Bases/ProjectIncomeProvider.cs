using System;
using System.Collections.Generic;
using System.Data;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.Bases
{
    public abstract class ProjectIncomeProvider: IDAL.IProjectIncome
    {
        #region Protected Method
        protected ProjectIncomeInfo ConvertToObject(IDataReader dr)
        {
            var obj = new ProjectIncomeInfo();
            obj.Id = int.Parse(dr["Id"].ToString());
            obj.ProjectId = int.Parse(dr["ProjectId"].ToString());
            obj.Year = int.Parse(dr["Year"].ToString());
            obj.Month = int.Parse(dr["Month"].ToString());
            obj.Amount = decimal.Parse(dr["Amount"].ToString());
            return obj;
        }
        #endregion

        #region Implementation of IProjectIncome

        /// <summary>
        /// 新增项目财务到帐信息。
        /// </summary>
        /// <param name="obj">财务到帐信息实体</param>
        /// <returns>Id</returns>
        public abstract int Insert(ProjectIncomeInfo obj);

        /// <summary>
        /// 更改项目财务到帐信息
        /// </summary>
        /// <param name="obj">项目财务到帐信息</param>
        /// <returns>bool</returns>
        public abstract bool Update(ProjectIncomeInfo obj);

        /// <summary>
        /// 根据Id删除项目财务到帐信息。
        /// </summary>
        /// <param name="id">财务到帐信息Id</param>
        /// <returns>bool</returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// 根据项目Id获取财务到帐记录
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns></returns>
        public abstract List<ProjectIncomeInfo> GetByProjectId(int projectId);

        /// <summary>
        /// 根据项目Id、年份、月份获取财务到帐信息。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>财务到帐信息</returns>
        public abstract ProjectIncomeInfo GetByProjectIdYearMonth(int projectId, int year, int month);

        /// <summary>
        /// 根据Id获取财务到帐信息。
        /// </summary>
        /// <param name="id">财务到帐信息Id</param>
        /// <returns>财务到帐信息</returns>
        public abstract ProjectIncomeInfo GetById(int id);

        #endregion
    }
}
