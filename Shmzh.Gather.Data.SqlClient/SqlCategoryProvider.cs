using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlCategoryProvider:CategoryProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string _connectionString;
        string _providerInvariantName;
        string _useGzip;
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
		public SqlCategoryProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlCategoryProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlCategoryProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到报表分类实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>报表分类实体。</returns>
        private static CategoryInfo ConvertToCategoryInfo(IDataRecord dr)
        {
            var obj = new CategoryInfo();
            obj.Id = dr.GetInt32(0);
            obj.Name = dr.GetString(1);
            obj.ParentId = dr.GetInt32(2);
            obj.Sort = dr["Sort"] == DBNull.Value ? int.MaxValue : dr.GetInt32(3);

            return obj;
        }

        /// <summary>
        /// 由给定的报表分类集合中找出指定分类的所有子分类.
        /// </summary>
        /// <param name="objs">给定的报表分类集合.</param>
        /// <param name="targetObjs">存放子分类的集合.</param>
        /// <param name="parentId">上级分类Id.</param>
        private static void GetByParentId(List<CategoryInfo> objs, List<CategoryInfo> targetObjs, int parentId)
        {
            var children = objs.FindAll(x => x.ParentId == parentId);
            foreach (var obj in children)
            {
                GetByParentId(objs, targetObjs, obj.Id);
            }
        }
        #endregion

        #region Implementation of ICategory

        /// <summary>
        /// 添加报表分类。
        /// </summary>
        /// <param name="obj">报表分类实体。</param>
        /// <returns>bool</returns>
        public override int Insert(CategoryInfo obj)
        {
            var sqlStatement = @"Insert Into T_Category ( CategoryName,ParentId,Sort) Values (@Name,@ParentId,@Sort) Set @Id = SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.VarChar, 50) {Value = obj.Name},
                                new SqlParameter("@ParentId", SqlDbType.Int) {Value = obj.ParentId},
                                new SqlParameter("@Sort", SqlDbType.Int) {Value = obj.Sort == int.MaxValue ? DBNull.Value : (object) obj.Sort},
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
        /// 更改报表分类。
        /// </summary>
        /// <param name="obj">报表分类实体。</param>
        /// <returns>bool</returns>
        public override bool Update(CategoryInfo obj)
        {
            var sqlStatement = @"Update T_Category Set CategoryName = @Name,ParentId = @ParentId,Sort=@Sort Where Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = obj.Id},
                                new SqlParameter("@Name", SqlDbType.VarChar, 50) {Value = obj.Name},
                                new SqlParameter("@ParentId", SqlDbType.Int) {Value = obj.ParentId},
                                new SqlParameter("@Sort", SqlDbType.Int) {Value = obj.Sort == int.MaxValue ? DBNull.Value : (object) obj.Sort},
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
        /// 根据Id删除报表分类记录。
        /// </summary>
        /// <param name="id">报表分类Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(int id)
        {
            var sqlStatement = "Delete From T_Category Where Id = @Id";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
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
        /// 删除报表实体。
        /// </summary>
        /// <param name="obj">报表实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(CategoryInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 获取所有的报表分类。
        /// </summary>
        /// <returns>报表分类集合</returns>
        public override IList<CategoryInfo> GetAll()
        {
            var sqlStatement = "Select Id,CategoryName As [Name],ParentId,Sort From T_Category";
            var objs = new List<CategoryInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToCategoryInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据父Id获取报表分类集合.
        /// </summary>
        /// <param name="parentId">父Id.</param>
        /// <returns>报表分类集合.</returns>
        public override IList<CategoryInfo> GetByParentId(int parentId)
        {
            var sqlStatement = "Select Id,CategoryName As [Name],ParentId,Sort From T_Category Where ParentId=@ParentId";
            var parms = new[] {new SqlParameter("@ParentId", SqlDbType.Int) {Value = parentId}};
            var objs = new List<CategoryInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToCategoryInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据父Id获取所有下辖的报表分类集合(向下递归).
        /// </summary>
        /// <param name="parentId">父Id.</param>
        /// <returns>报表分类集合.</returns>
        public override IList<CategoryInfo> RecursiveGetByParentId(int parentId)
        {
            var srcObjs = GetAll() as List<CategoryInfo>;
            var tgtObjs = new List<CategoryInfo>();
            GetByParentId(srcObjs, tgtObjs, parentId);
            return tgtObjs;
        }

        /// <summary>
        /// 根据Id获取报表分类。
        /// </summary>
        /// <param name="id">报表分类Id。</param>
        /// <returns>报表分类</returns>
        public override CategoryInfo GetById(int id)
        {
            var sqlStatement = "Select Id,CategoryName As [Name],ParentId,Sort From T_Category Where Id = @Id";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            CategoryInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToCategoryInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据分类名称获取报表分类。
        /// </summary>
        /// <param name="name">分类名称。</param>
        /// <returns>报表分类</returns>
        /// <remarks>由于分类名称不是唯一的，所以会取第一个符合的分类记录来进行检索。</remarks>
        public override CategoryInfo GetByName(string name)
        {
            var sqlStatement = "Select top 1 Id,CategoryName As [Name],ParentId,Sort From T_Category Where UPPER(CategoryName) = UPPER(@Name)";
            var parms = new[] { new SqlParameter("@Name", SqlDbType.VarChar,50) { Value = name } };
            CategoryInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToCategoryInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

    }
}
