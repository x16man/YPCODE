using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;
using Shmzh.Components.Util;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlSchemaProvider:SchemaProvider
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
        /// <summary>
        /// 是否使用GZip.
        /// </summary>
        public string UseGZip
        {
            get { return _useGzip; }
            set { this._useGzip = value; }
        }
        /// <summary>
        /// 是否启用压缩.
        /// </summary>
        public bool IsZipped
        {
            get { return this._useGzip.ToUpper() == "TRUE"; }
        }
        #endregion

        #region CTOR
        /// <summary>
		/// Creates a new <see cref="SqlCategoryProvider"/> instance.
		/// </summary>
		public SqlSchemaProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlCategoryProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlSchemaProvider(string connectionString, string providerInvariantName,string useGzip)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
            this._useGzip = useGzip;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到报表模板实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="isZipped">是否需要将</param>
        /// <returns>报表模板实体。</returns>
        private SchemaInfo ConvertToSchemaInfo(IDataRecord dr)
        {
            var obj = new SchemaInfo();
            obj.Id = dr.GetString(0);
            obj.Name = dr.GetString(1);
            obj.Type = dr.GetString(2);
            obj.IsZipped = this.IsZipped;
            obj.Xml = dr["Xml"] == DBNull.Value ? string.Empty : (this.IsZipped ? StringUtil.Zip(dr.GetString(3)):dr.GetString(3));
            obj.CycleType = dr["CycleType"] == DBNull.Value ? string.Empty : dr.GetString(4);
            obj.Url = dr["Url"] == DBNull.Value ? string.Empty : dr.GetString(5);
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr.GetString(6);

            return obj;
        }
        #endregion

        #region Implementation of ISchema

        /// <summary>
        /// 添加报表模板。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        public override bool Insert(SchemaInfo obj)
        {
            var sqlStatement =
                @"Insert Into T_Schema_MS (I_Schema_Id,I_Schema_NM,I_Schema_TP,I_Schema_Xml,I_Cycle_Type,I_Schema_Url,I_Schema_Des) 
                                Values (@Id,@Name,@Type,@Xml,@CycleType,@Url,@Remark)";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 20) {Value = obj.Id},
                                new SqlParameter("@Name", SqlDbType.NVarChar,100){Value = obj.Name},
                                new SqlParameter("@Type",SqlDbType.VarChar,10){Value = obj.Type},
                                new SqlParameter("@Xml", SqlDbType.Text){Value = obj.IsZipped?StringUtil.UnZip(obj.Xml):obj.Xml},
                                new SqlParameter("@CycleType",SqlDbType.VarChar,10){Value = obj.CycleType},
                                new SqlParameter("@Url", SqlDbType.VarChar,500){Value = obj.Url},
                                new SqlParameter("@Remark", SqlDbType.VarChar,5000){Value = obj.Remark},
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
        /// 更改报表模板。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        public override bool Update(SchemaInfo obj)
        {
            var sqlStatement =
                "Update T_Schcma_MS Set I_Schema_NM = @Name,I_Schema_TP = @Type,I_Schema_Xml=@Xml,@I_Cycle_Type=@CycleType,@I_Schema_Url = @Url,I_Schema_Des=@Remark Where I_Schema_Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 20) {Value = obj.Id},
                                new SqlParameter("@Name", SqlDbType.NVarChar,100){Value = obj.Name},
                                new SqlParameter("@Type",SqlDbType.VarChar,10){Value = obj.Type},
                                new SqlParameter("@Xml", SqlDbType.Text){Value=obj.IsZipped?StringUtil.UnZip(obj.Xml):obj.Xml},
                                new SqlParameter("@CycleType",SqlDbType.VarChar,10){Value = obj.CycleType},
                                new SqlParameter("@Url", SqlDbType.VarChar,500){Value = obj.Url},
                                new SqlParameter("@Remark", SqlDbType.VarChar,5000){Value = obj.Remark},
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
        /// 根据Id删除报表模板记录。
        /// </summary>
        /// <param name="id">报表模板Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(string id)
        {
            var sqlStatement = "Delete From T_Schema_MS Where I_Schema_Id = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 20) {Value = id},
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
        /// 删除报表模板实体。
        /// </summary>
        /// <param name="obj">报表模板实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(SchemaInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 获取所有的报表模板。
        /// </summary>
        /// <returns>报表模板集合</returns>
        /// <remarks>获取所有报表模板时,不包括模板的XML和备注信息,为了提高性能.</remarks>
        public override IList<SchemaInfo> GetAll()
        {
            var sqlStatement = "Select I_Schema_Id As Id,I_Schema_NM As Name,I_Schema_TP As Type,null as Xml,I_Cycle_Type As CycleType,I_Schema_Url As Url,null As Remark From T_Schema_MS";
            var objs = new List<SchemaInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToSchemaInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取报表模板对象,可以指定是否进行GZip压缩。
        /// </summary>
        /// <param name="id">报表模板Id.</param>
        /// <param name="isZipped">是否进行GZip压缩.</param>
        /// <returns>报表模板对象.</returns>
        public override SchemaInfo GetById(string id)
        {
            var sqlStatement = "Select I_Schema_Id As Id,I_Schema_NM As Name,I_Schema_TP As Type,I_Schema_Xml as Xml,I_Cycle_Type As CycleType,I_Schema_Url As Url,I_Schema_DES As Remark From T_Schema_MS Where I_Schema_Id = @Id";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.VarChar, 20) { Value = id } };
            SchemaInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToSchemaInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
