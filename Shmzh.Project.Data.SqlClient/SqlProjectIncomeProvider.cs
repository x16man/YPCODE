using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Project.Data.Bases;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.SqlClient
{
    class SqlProjectIncomeProvider:ProjectIncomeProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        #region Property

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
        /// </summary>
        /// <value>The name of the provider invariant.</value>
        public string ProviderInvariantName { get; set; }

        #endregion

        #region CTOR
        /// <summary>
        /// Creates a new <see cref="SqlProjectIncomeProvider"/> instance.
        /// </summary>
        public SqlProjectIncomeProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="SqlProjectIncomeProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public SqlProjectIncomeProvider(string connectionString, string providerInvariantName)
        {
            this.ConnectionString = connectionString;
            this.ProviderInvariantName = providerInvariantName;
        }
        #endregion

        #region Overrides of ProjectIncomeProvider

        /// <summary>
        /// 新增项目财务到帐信息。
        /// </summary>
        /// <param name="obj">财务到帐信息实体</param>
        /// <returns>Id</returns>
        public override int Insert(ProjectIncomeInfo obj)
        {
            var sqlStatement = "Insert Into TProjectIncome (ProjectId,[Year],[Month],[Amount]) Values (@ProjectId,@Year,@Month,@Amount) Set @Id = SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id",SqlDbType.Int){Value = 0,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ProjectId",SqlDbType.Int){Value = obj.ProjectId},
                                new SqlParameter("@Year",SqlDbType.Int){Value = obj.Year},
                                new SqlParameter("@Month",SqlDbType.Int){Value = obj.Month},
                                new SqlParameter("@Amount",SqlDbType.Decimal){Value = obj.Amount},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement,parms);
                obj.Id = int.Parse(parms[0].Value.ToString());
                return obj.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return 0;
            }
        }

        /// <summary>
        /// 更改项目财务到帐信息
        /// </summary>
        /// <param name="obj">项目财务到帐信息</param>
        /// <returns>bool</returns>
        public override bool Update(ProjectIncomeInfo obj)
        {
            var sqlStatement = "Update TProjectIncome Set ProjectId = @ProjectId ,[Year]=@Year, [Month]=@Month, Amount = @Amount Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id",SqlDbType.Int){Value = obj.Id},
                                new SqlParameter("@ProjectId",SqlDbType.Int){Value = obj.ProjectId},
                                new SqlParameter("@Year",SqlDbType.Int){Value = obj.Year},
                                new SqlParameter("@Month",SqlDbType.Int){Value = obj.Month},
                                new SqlParameter("@Amount",SqlDbType.Decimal){Value = obj.Amount},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement,parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 根据Id删除项目财务到帐信息。
        /// </summary>
        /// <param name="id">财务到帐信息Id</param>
        /// <returns>bool</returns>
        public override bool Delete(int id)
        {
            var sqlStatement = "Delete From TProjectIncome Where Id = @Id";
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }

        /// <summary>
        /// 根据项目Id获取财务到帐记录
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns></returns>
        public override List<ProjectIncomeInfo> GetByProjectId(int projectId)
        {
            var sqlStatement = "Select * From TProjectIncome Where ProjectId = @ProjectId";
            var parms = new[] {new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId}};
            var objs = new ListBase<ProjectIncomeInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据项目Id、年份、月份获取财务到帐信息。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>财务到帐信息</returns>
        public override ProjectIncomeInfo GetByProjectIdYearMonth(int projectId, int year, int month)
        {
            var sqlStatement = "Select * From TProjectIncome Where ProjectId = @ProjectId And [Year]=@Year And [Month]=@Month";
            var parms = new[]
                            {
                                new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId},
                                new SqlParameter("@Year", SqlDbType.Int) {Value = year},
                                new SqlParameter("@Month", SqlDbType.Int) {Value = month},
                            };
            ProjectIncomeInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToObject(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据Id获取财务到帐信息。
        /// </summary>
        /// <param name="id">财务到帐信息Id</param>
        /// <returns>财务到帐信息</returns>
        public override ProjectIncomeInfo GetById(int id)
        {
            var sqlStatement = "Select * From TProjectIncome Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = id},
                            };
            ProjectIncomeInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToObject(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}