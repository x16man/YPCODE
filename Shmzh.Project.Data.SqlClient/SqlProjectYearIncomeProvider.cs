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
        /// ������Ŀ��Ȳ�������Ϣ��
        /// </summary>
        /// <param name="obj">������ȵ�����Ϣʵ��</param>
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
        /// ������Ŀ��Ȳ�������Ϣ
        /// </summary>
        /// <param name="obj">��Ŀ��Ȳ�������Ϣ</param>
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
        /// ����Idɾ����Ŀ������ȵ�����Ϣ��
        /// </summary>
        /// <param name="id">������ȵ�����ϢId</param>
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
        /// ������ĿId��ȡ������ȵ��ʼ�¼
        /// </summary>
        /// <param name="projectId">��ĿId</param>
        /// <returns>��Ŀ�Ĳ�����ȵ��ʼ�¼</returns>
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
        /// ������ĿId����ݡ��·ݻ�ȡ������ȵ�����Ϣ��
        /// </summary>
        /// <param name="projectId">��ĿId</param>
        /// <param name="year">���</param>
        /// <returns>������ȵ�����Ϣ</returns>
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
        /// ����Id��ȡ������ȵ�����Ϣ��
        /// </summary>
        /// <param name="id">������ȵ�����ϢId</param>
        /// <returns>������ȵ�����Ϣ</returns>
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