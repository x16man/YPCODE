using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Project.Data.Bases;
using Shmzh.Project.Entity;

namespace Shmzh.Project.Data.SqlClient
{
    class SqlProjectExtProvider : ProjectExtProvider
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
        /// Creates a new <see cref="SqlProjectExtProvider"/> instance.
        /// </summary>
        public SqlProjectExtProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="SqlProjectExtProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public SqlProjectExtProvider(string connectionString, string providerInvariantName)
        {
            this.ConnectionString = connectionString;
            this.ProviderInvariantName = providerInvariantName;
        }
        #endregion

        #region Implementation of IProjectExt

        /// <summary>
        /// 添加项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性</param>
        /// <returns>bool</returns>
        public override bool Insert(ProjectExtInfo obj)
        {
            var sqlStatement = "Insert Into TProjectExtInfo (ProjectId,IsHidden) Values (@ProjectId, @IsHidden)";
            var parms = new[] {
                new SqlParameter("@ProjectId", SqlDbType.Int) {Value = obj.ProjectId},
                new SqlParameter("@IsHidden", SqlDbType.Bit){Value = obj.IsHidden}
            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 更改项目扩展属性.
        /// </summary>
        /// <param name="obj">项目扩展属性.</param>
        /// <returns>bool</returns>
        public override bool Update(ProjectExtInfo obj)
        {
            var sqlStatement = "Update TProjectExtInfo SetIsHidden = @IsHidden Where ProjectId = @ProjectId";
            var parms = new[] {
                new SqlParameter("@ProjectId", SqlDbType.Int) {Value = obj.ProjectId},
                new SqlParameter("@IsHidden", SqlDbType.Bit){Value = obj.IsHidden}
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }


        /// <summary>
        /// 删除项目扩展属性.
        /// </summary>
        /// <param name="projectId">项目Id.</param>
        /// <returns>bool</returns>
        public override bool Delete(int projectId)
        {
            var sqlStatement = "Delete From TProjectExtInfo Where ProjectId = @ProjectId";
            var parms = new[] {
                new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId}
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 获取所有项目扩展属性.
        /// </summary>
        /// <returns>项目扩展属性集合.</returns>
        public override List<ProjectExtInfo> GetAll()
        {
            var sqlStatement = "Select * From TProjectExtInfo";
            var objs = new List<ProjectExtInfo>();

            var dr = SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据项目Id获取项目扩展属性.
        /// </summary>
        /// <param name="projectId">项目Id.</param>
        /// <returns>项目扩展属性.</returns>
        public override ProjectExtInfo GetByProjectId(int projectId)
        {
            var sqlStatement = "Select * From TProjectExtInfo Where ProjectId = @ProjectId";
            var parms = new[] {new SqlParameter("@ProjectId", SqlDbType.Int) {Value = projectId}};
            ProjectExtInfo obj = null;
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
