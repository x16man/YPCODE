using System.Collections.Generic;
using System.Data;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.Bases
{
    public abstract class ViewProjectYearIncomeProvider :IDAL.IViewProjectYearIncome
    {
        #region protected method
        protected ViewProjectYearIncomeInfo ConvertToObject(IDataReader dr)
        {
            var obj = new ViewProjectYearIncomeInfo();
            obj.Id = int.Parse(dr["Id"].ToString());
            obj.ProjectId = int.Parse(dr["ProjectId"].ToString());
            obj.ProjectCode = dr["ProjectCode"].ToString();
            obj.CompanyCode = dr["CompanyCode"].ToString();
            obj.ProjectName = dr["ProjectName"].ToString();
            obj.Year = int.Parse(dr["Year"].ToString());
            obj.Amount = decimal.Parse(dr["Amount"].ToString());
            return obj;
        }
        #endregion

        #region Implementation of IViewProjectYearIncome

        /// <summary>
        /// 根据项目Id获取项目财务年度到帐信息集合。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目财务年度到帐信息集合。</returns>
        public abstract List<ViewProjectYearIncomeInfo> GetByProjectId(int projectId);

        /// <summary>
        /// 根据项目Id、年份、月份获取项目财务年度到帐信息实体。
        /// </summary>
        /// <param name="projectId">项目Id。</param>
        /// <param name="year">年份</param>
        /// <returns>财务年度到帐信息实体。</returns>
        public abstract ViewProjectYearIncomeInfo GetByProjectIdYear(int projectId, int year);

        /// <summary>
        /// 根据Id获取项目财务年度到帐信息实体。
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>财务年度到帐信息实体。</returns>
        public abstract ViewProjectYearIncomeInfo GetById(int id);

        #endregion
    }
}
