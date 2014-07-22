using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Project.Data.Bases;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.SqlClient
{
    class SqlViewProjectIncomeProvider : ViewProjectIncomeProvider
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
        /// Creates a new <see cref="SqlViewProjectIncomeProvider"/> instance.
        /// </summary>
        public SqlViewProjectIncomeProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="SqlViewProjectIncomeProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public SqlViewProjectIncomeProvider(string connectionString, string providerInvariantName)
        {
            this.ConnectionString = connectionString;
            this.ProviderInvariantName = providerInvariantName;
        }
        #endregion

        #region Overrides of ViewProjectIncomeProvider

        /// <summary>
        /// 根据项目Id获取项目财务到帐信息集合。
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <returns>项目财务到帐信息集合。</returns>
        public override List<ViewProjectIncomeInfo> GetByProjectId(int projectId)
        {
            var sqlStatement = "Select * From ViewProjectIncome Where ProjectId = @ProjectId";
            var parms = new[] {new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId}};
            var objs = new ListBase<ViewProjectIncomeInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据项目Id、年份、月份获取项目财务到帐信息实体。
        /// </summary>
        /// <param name="projectId">项目Id。</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>财务到帐信息实体。</returns>
        public override ViewProjectIncomeInfo GetByProjectIdYearMonth(int projectId, int year, int month)
        {
            var sqlStatement = "Select * From ViewProjectIncome Where ProjectId = @ProjectId And [Year]=@Year And [Month]=@Month";
            var parms = new[]
                            {
                                new SqlParameter("@ProjectId", SqlDbType.Int) { Value = projectId },
                                new SqlParameter("@Year",SqlDbType.Int){Value = year},
                                new SqlParameter("@Month",SqlDbType.Int){Value = month}

                            };
            ViewProjectIncomeInfo obj = null;
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
        /// 根据Id获取项目财务到帐信息实体。
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>财务到帐信息实体。</returns>
        public override ViewProjectIncomeInfo GetById(int id)
        {
            var sqlStatement = "Select * From ViewProjectIncome Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) { Value = id }

                            };
            ViewProjectIncomeInfo obj = null;
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
