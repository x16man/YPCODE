using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlRelationProvider:RelationProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string _connectionString;
        string _providerInvariantName;
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return this._connectionString; }
            set { this._connectionString = value; }
        }
        /// <summary>
        /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
        /// </summary>
        /// <value>The name of the provider invariant.</value>
        public string ProviderInvariantName
        {
            get { return this._providerInvariantName; }
            set { this._providerInvariantName = value; }
        }
        #endregion

        #region CTOR
        /// <summary>
		/// Creates a new <see cref="SqlCategoryProvider"/> instance.
		/// </summary>
		public SqlRelationProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlCategoryProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlRelationProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到报表模板与分类关系实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>报表模板与分类关系实体。</returns>
        private static RelationInfo ConvertToRelationInfo(IDataRecord dr)
        {
            var obj = new RelationInfo();
            obj.Id = dr.GetInt32(0);
            obj.CategoryId = dr.GetInt32(1);
            obj.SchemaId = dr.GetString(2);
            obj.SchemaName = dr.GetString(3);
            obj.SchemaType = dr.GetString(4);
            obj.SchemaCycle = dr["I_Cycle_Type"] == DBNull.Value ? string.Empty : dr.GetString(5);
            obj.SchemaUrl = dr["I_Schema_Url"] == DBNull.Value ? string.Empty : dr.GetString(6);
            obj.Sort = dr["Sort"] == DBNull.Value ? int.MaxValue : dr.GetInt32(7);
            obj.Remark = dr["I_Schema_Des"] == DBNull.Value ? string.Empty : dr["I_Schema_Des"].ToString();

            return obj;
        }
        #endregion

        #region Implementation of IRelation

        /// <summary>
        /// 添加报表模板与分类关系。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        public override int Insert(RelationInfo obj)
        {
            var sqlStatement = @"
Insert Into T_CategoryRelation 
        (CategoryId,CSchema,Sort) 
Values  (@CategoryId,@SchemaId,@Sort) 
Set @Id = SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@CategoryId", SqlDbType.Int){Value = obj.CategoryId},
                                new SqlParameter("@SchemaId",SqlDbType.VarChar,50){Value = obj.SchemaId},
                                new SqlParameter("@Sort", SqlDbType.Int){Value = obj.Sort},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                obj.Id = (int)parms[0].Value;
                return obj.Id;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return 0;
            }
        }

        /// <summary>
        /// 更改报表模板与分类关系。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        public override bool Update(RelationInfo obj)
        {
            var sqlStatement = @"
Update  T_CategoryRelation 
Set     CategoryId = @CategoryId
,       CSchema = @SchemaId
,       Sort =@Sort 
Where   Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = obj.Id},
                                new SqlParameter("@CategoryId", SqlDbType.Int){Value = obj.CategoryId},
                                new SqlParameter("@SchemaId",SqlDbType.VarChar,50){Value = obj.SchemaId},
                                new SqlParameter("@Sort", SqlDbType.Int){Value = obj.Sort},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                obj.Id = (int)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 根据Id删除报表模板与分类关系记录。
        /// </summary>
        /// <param name="id">报表模板与分类关系Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(int id)
        {
            var sqlStatement = "Delete From T_CategoryRelation Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = id},
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
        /// 删除报表模板与分类关系实体。
        /// </summary>
        /// <param name="obj">报表模板与分类关系实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(RelationInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 获取所有的报表模板与分类关系集合。
        /// </summary>
        /// <returns>报表模板与分类关系集合</returns>
        public override IList<RelationInfo> GetAll()
        {
            var sqlStatement = @"
Select  A.Id,A.CategoryId,A.CSchema,B.I_Schema_NM,B.I_Schema_TP,B.I_Cycle_Type,B.I_Schema_Url,A.Sort ,B.I_Schema_Des
From    T_CategoryRelation A, T_Schema_MS B 
Where   A.CSchema = B.I_Schema_Id";
            var objs = new List<RelationInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToRelationInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据分类Id获取报表模板与分类关系集合。
        /// </summary>
        /// <param name="categoryId">分类Id。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        public override IList<RelationInfo> GetByCategoryId(int categoryId)
        {
            var sqlStatement = @"
Select  A.Id,A.CategoryId,A.CSchema,B.I_Schema_NM,B.I_Schema_TP,B.I_Cycle_Type,B.I_Schema_Url,A.Sort,B.I_Schema_Des 
From    T_CategoryRelation A, T_Schema_MS B 
Where   A.CSchema = B.I_Schema_Id And 
        A.CategoryId = @CategoryId";
            var parms = new[]
                            {
                                new SqlParameter("@CategoryId", SqlDbType.Int){Value = categoryId},
                            };
            var objs = new List<RelationInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRelationInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据报表Id获取报表模板与分类关系的集合。
        /// </summary>
        /// <param name="schemaId">报表模板Id。</param>
        /// <returns>报表模板与分类关系集合。</returns>
        public override IList<RelationInfo> GetBySchemaId(string schemaId)
        {
            var sqlStatement = @"
Select  A.Id,A.CategoryId,A.CSchema,B.I_Schema_NM,B.I_Schema_TP,B.I_Cycle_Type,B.I_Schema_Url,A.Sort ,B.I_Schema_Des
From    T_CategoryRelation A, T_Schema_MS B 
Where   A.CSchema = B.I_Schema_Id And 
        A.CSchema = @SchemaId";
            var parms = new[]
                            {
                                new SqlParameter("@SchemaId", SqlDbType.VarChar,50){Value = schemaId},
                            };
            var objs = new List<RelationInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRelationInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取报表模板与分类关系。
        /// </summary>
        /// <param name="id">报表模板与分类关系Id。</param>
        /// <returns>报表模板与分类关系实体。</returns>
        public override RelationInfo GetById(int id)
        {
            var sqlStatement = @"
Select  A.Id,A.CategoryId,A.CSchema,B.I_Schema_NM,B.I_Schema_TP,B.I_Cycle_Type,B.I_Schema_Url,A.Sort ,B.I_Schema_Des
From    T_CategoryRelation A, T_Schema_MS B 
Where   A.CSchema = B.I_Schema_Id And 
        A.Id = @Id";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            RelationInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToRelationInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
