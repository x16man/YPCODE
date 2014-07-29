using System.Collections.Generic;
using System.Data;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.Bases
{
    public abstract class ViewProjectIncomeProvider :IDAL.IViewProjectIncome
    {
        #region protected method
        protected ViewProjectIncomeInfo ConvertToObject(IDataReader dr)
        {
            var obj = new ViewProjectIncomeInfo();
            obj.Id = int.Parse(dr["Id"].ToString());
            obj.ProjectId = int.Parse(dr["ProjectId"].ToString());
            obj.ProjectCode = dr["ProjectCode"].ToString();
            obj.CompanyCode = dr["CompanyCode"].ToString();
            obj.ProjectName = dr["ProjectName"].ToString();
            obj.Year = int.Parse(dr["Year"].ToString());
            obj.Month = int.Parse(dr["Month"].ToString());
            obj.Amount = decimal.Parse(dr["Amount"].ToString());
            return obj;
        }
        #endregion 

        #region Implementation of IViewProjectIncome

        /// <summary>
        /// 根据项目Id获取项目财务到帐信息集合。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目财务到帐信息集合。</returns>
        public abstract List<ViewProjectIncomeInfo> GetByProjectId(int projectId);

        /// <summary>
        /// 根据项目Id、年份、月份获取项目财务到帐信息实体。
        /// </summary>
        /// <param name="projectId">项目Id。</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>财务到帐信息实体。</returns>
        public abstract ViewProjectIncomeInfo GetByProjectIdYearMonth(int projectId, int year, int month);

        /// <summary>
        /// 根据Id获取项目财务到帐信息实体。
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>财务到帐信息实体。</returns>
        public abstract ViewProjectIncomeInfo GetById(int id);

        #endregion
    }
}
