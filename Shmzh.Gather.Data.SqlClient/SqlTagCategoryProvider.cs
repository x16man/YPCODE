using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlTagCategoryProvider : TagCategoryProvider
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
        public SqlTagCategoryProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="SqlCategoryProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public SqlTagCategoryProvider(string connectionString, string providerInvariantName)
        {
            this._connectionString = connectionString;
            this._providerInvariantName = providerInvariantName;
        }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到指标分类实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>指标分类实体。</returns>
        private static TagCategoryInfo ConvertToTagCategoryInfo(IDataRecord dr)
        {
            var obj = new TagCategoryInfo();
            obj.Id = dr.GetInt32(0);
            obj.Name = dr.GetString(1);
            obj.ParentId = dr.GetInt32(2);
            obj.SerialNo = dr.GetInt32(3);

            return obj;
        }
        #endregion

        #region Overrides of TagCategoryProvider

        /// <summary>
        /// 添加指标分类。
        /// </summary>
        /// <param name="obj">指标分类实体。</param>
        /// <returns>指标分类Id。</returns>
        public override int Insert(TagCategoryInfo obj)
        {
            var sqlStatement = "Insert Into T_Tag_Category (CategoryName,ParentId,SerialNumber) Values (@Name,@ParentId,@SerialNo) Set @Id = SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@Name", SqlDbType.NVarChar, 50) {Value = obj.Name},
                                new SqlParameter("@ParentId", SqlDbType.Int){Value = obj.ParentId},
                                new SqlParameter("@SerialNo", SqlDbType.Int){Value = obj.SerialNo},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                obj.Id = int.Parse(parms[0].ToString());
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                obj.Id = 0;
            }
            return obj.Id;
        }

        /// <summary>
        /// 更改指标分类。
        /// </summary>
        /// <param name="obj">指标分类实体。</param>
        /// <returns>bool</returns>
        public override bool Update(TagCategoryInfo obj)
        {
            var sqlStatement = "Update T_Tag_Category Set CategoryName = @Name,ParentId = @ParentId,SerialNumber=@SerialNo Where CategoryId = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int) {Value = obj.Id},
                                new SqlParameter("@Name", SqlDbType.NVarChar, 50) {Value = obj.Name},
                                new SqlParameter("@ParentId", SqlDbType.Int){Value = obj.ParentId},
                                new SqlParameter("@SerialNo", SqlDbType.Int){Value = obj.SerialNo},
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
        /// 删除指标分类。
        /// </summary>
        /// <param name="obj">指标分类实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(TagCategoryInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除指标分类。
        /// </summary>
        /// <param name="id">指标分类Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(int id)
        {
            var sqlStatement = "Delete From T_Tag_Category Where CategoryId = @Id";
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
        /// 获取所有的指标分类。
        /// </summary>
        /// <returns>指标分类的集合。</returns>
        public override List<TagCategoryInfo> GetAll()
        {
            var sqlStatement = "Select CategoryId,CategoryName,ParentId,SerialNumber From T_Tag_Category";
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            var objs = new List<TagCategoryInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToTagCategoryInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据上级分类Id获取指标分类。
        /// </summary>
        /// <param name="parentId">上级分类Id。</param>
        /// <returns>指标分类的集合。</returns>
        public override List<TagCategoryInfo> GetByParentId(int parentId)
        {
            var sqlStatement = "Select CategoryId,CategoryName,ParentId,SerialNumber From T_Tag_Category Where ParentId = @ParentId";
            var parms = new[] { new SqlParameter("@ParentId", SqlDbType.Int) { Value = parentId } };
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            var objs = new List<TagCategoryInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToTagCategoryInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指标分类Id获取指标分类。
        /// </summary>
        /// <param name="id">指标分类Id。</param>
        /// <returns>指标分类实体。</returns>
        public override TagCategoryInfo GetById(int id)
        {
            var sqlStatement = "Select CategoryId,CategoryName,ParentId,SerialNumber From T_Tag_Category Where CategoryId = @Id";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            TagCategoryInfo obj = null;
            while (dr.Read())
            {
                obj = ConvertToTagCategoryInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}