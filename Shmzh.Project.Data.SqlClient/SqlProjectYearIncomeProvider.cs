using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Project.Data.Bases;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.SqlClient
{
    class SqlProjectYearIncomeProvider:ProjectYearIncomeProvider
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
        /// Creates a new <see cref="SqlProjectYearIncomeProvider"/> instance.
        /// </summary>
        public SqlProjectYearIncomeProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="SqlProjectYearIncomeProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public SqlProjectYearIncomeProvider(string connectionString, string providerInvariantName)
        {
            this.ConnectionString = connectionString;
            this.ProviderInvariantName = providerInvariantName;
        }
        #endregion

        #region Overrides of ProjectYearIncomeProvider

        /// <summary>
        /// 新增项目年度财务到帐信息。
        /// </summary>
        /// <param name="obj">财务年度到帐信息实体</param>
        /// <returns>Id</returns>
        public override int Insert(ProjectYearIncomeInfo obj)
        {
            var sqlStatement = "Insert Into TProjectYearIncome (ProjectId,[Year],[Amount]) Values (@ProjectId,@Year,@Amount) Set @Id = SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id",SqlDbType.Int){Value = 0,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ProjectId",SqlDbType.Int){Value = obj.ProjectId},
                                new SqlParameter("@Year",SqlDbType.Int){Value = obj.Year},
                                new SqlParameter("@Amount",SqlDbType.Decimal){Value = obj.Amount}
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
        /// 更改项目年度财务到帐信息
        /// </summary>
        /// <param name="obj">项目年度财务到帐信息</param>
        /// <returns>bool</returns>
        public override bool Update(ProjectYearIncomeInfo obj)
        {
            var sqlStatement = "Update TProjectYearIncome Set ProjectId = @ProjectId ,[Year]=@Year, Amount = @Amount Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id",SqlDbType.Int){Value = obj.Id},
                                new SqlParameter("@ProjectId",SqlDbType.Int){Value = obj.ProjectId},
                                new SqlParameter("@Year",SqlDbType.Int){Value = obj.Year},
                                new SqlParameter("@Amount",SqlDbType.Decimal){Value = obj.Amount}
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
        /// 根据Id删除项目财务年度到帐信息。
        /// </summary>
        /// <param name="id">财务年度到帐信息Id</param>
        /// <returns>bool</returns>
        public override bool Delete(int id)
        {
            var sqlStatement = "Delete From TProjectYearIncome Where Id = @Id";
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
        /// 根据项目Id获取财务年度到帐记录
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目的财务年度到帐记录</returns>
        public override List<ProjectYearIncomeInfo> GetByProjectId(int projectId)
        {
            var sqlStatement = "Select * From TProjectYearIncome Where ProjectId = @ProjectId";
            var parms = new[] {new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId}};
            var objs = new ListBase<ProjectYearIncomeInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据项目Id、年份、月份获取财务年度到帐信息。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="year">年份</param>
        /// <returns>财务年度到帐信息</returns>
        public override ProjectYearIncomeInfo GetByProjectIdYear(int projectId, int year)
        {
            var sqlStatement = "Select * From TProjectYearIncome Where ProjectId = @ProjectId And [Year]=@Year";
            var parms = new[]
                            {
                                new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId},
                                new SqlParameter("@Year", SqlDbType.Int) {Value = year}
                            };
            ProjectYearIncomeInfo obj = null;
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
        /// 根据Id获取财务年度到帐信息。
        /// </summary>
        /// <param name="id">财务年度到帐信息Id</param>
        /// <returns>财务年度到帐信息</returns>
        public override ProjectYearIncomeInfo GetById(int id)
        {
            var sqlStatement = "Select * From TProjectYearIncome Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = id}
                            };
            ProjectYearIncomeInfo obj = null;
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