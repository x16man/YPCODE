using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlTagSqlMapProvider:TagSqlMapProvider
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
		/// Creates a new <see cref="SqlTagSqlMapProvider"/> instance.
		/// </summary>
		public SqlTagSqlMapProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlTagSqlMapProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlTagSqlMapProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到本地指标与第三方采集系统的指标对应关系。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>本地指标与第三方采集系统的指标对应关系。</returns>
        private static TagSqlMapInfo ConvertToTagSqlMapInfo(IDataRecord dr)
        {
            var obj = new TagSqlMapInfo();
            obj.TagId = dr["I_Tag_Id"].ToString();
            obj.TagName = dr["I_Tag_Name"].ToString();
            obj.Unit = dr["I_Unit"].ToString();
            obj.DigNum = dr["I_Dig_Num"] == DBNull.Value ? (short)0 : short.Parse(dr["I_Dig_Num"].ToString());
            obj.TagType = dr["I_Tag_Type"].ToString();
            obj.TagUnitName = dr["I_Tag_UnitName"] == DBNull.Value ? string.Empty : dr["I_Tag_UnitName"].ToString();
            obj.TagSqlName = dr["I_Tag_SqlName"]==DBNull.Value?string.Empty:dr["I_Tag_SqlName"].ToString();
            obj.TagSqlType = dr["I_Tag_SqlType"]==DBNull.Value?string.Empty:dr["I_Tag_SqlType"].ToString();
            obj.TagLocation = dr["I_Tag_Location"]==DBNull.Value?string.Empty:dr["I_Tag_Location"].ToString();
            obj.Enabled = (bool)dr["I_Enabled"];

            return obj;
        }

        #endregion

        #region Implementation of ITagSqlMap

        /// <summary>
        /// 添加本地指标与第三方采集系统的指标对应关系。
        /// </summary>
        /// <param name="obj">本地指标与第三方采集系统的指标对应关系。</param>
        /// <returns>bool</returns>
        public override bool Insert(TagSqlMapInfo obj)
        {
            var sqlStatement = @"Insert Into T_Tag_SqlMap ( I_Tag_Id,I_Tag_UnitName,I_Tag_SqlName,I_Tag_SqlType,I_Tag_Location,I_Enabled) Values (@TagId,@TagUnitName,@TagSqlName,@TagSqlType,@Location,@Enabled)";
            var parms = new[]
                            {
                                new SqlParameter("@TagId", SqlDbType.VarChar,8) {Value = obj.TagId},
                                new SqlParameter("@TagUnitName",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.TagUnitName)?DBNull.Value:(object)obj.TagUnitName}, 
                                new SqlParameter("@TagSqlName", SqlDbType.NVarChar, 50) {Value = string.IsNullOrEmpty(obj.TagSqlName)?DBNull.Value:(object)obj.TagSqlName},
                                new SqlParameter("@TagSqlType", SqlDbType.Char,1) {Value = string.IsNullOrEmpty(obj.TagSqlType)?DBNull.Value:(object)obj.TagSqlType},
                                new SqlParameter("@Enabled", SqlDbType.Bit) {Value = obj.Enabled},
                                new SqlParameter("@Location",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.TagLocation)?DBNull.Value:(object)obj.TagLocation},
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
        /// 更改本地指标与第三方采集系统的指标对应关系。
        /// </summary>
        /// <param name="obj">本地指标与第三方采集系统的指标对应关系。</param>
        /// <returns>bool</returns>
        public override bool Update(TagSqlMapInfo obj)
        {
            var sqlStatement = @"Update T_Tag_SqlMap Set I_Tag_UnitName = @TagUnitName,I_Tag_SqlName = @TagSqlName,I_Tag_SqlType=@TagSqlType,I_Tag_Location=@Location,I_Enabled=@Enabled Where I_Tag_Id = @TagId";
            var parms = new[]
                            {
                                new SqlParameter("@TagId", SqlDbType.VarChar,8) {Value = obj.TagId},
                                new SqlParameter("@TagUnitName",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.TagUnitName)?DBNull.Value:(object)obj.TagUnitName}, 
                                new SqlParameter("@TagSqlName", SqlDbType.NVarChar, 50) {Value = string.IsNullOrEmpty(obj.TagSqlName)?DBNull.Value:(object)obj.TagSqlName},
                                new SqlParameter("@TagSqlType", SqlDbType.Char,1) {Value = string.IsNullOrEmpty(obj.TagSqlType)?DBNull.Value:(object)obj.TagSqlType},
                                new SqlParameter("@Enabled", SqlDbType.Bit) {Value = obj.Enabled},
                                new SqlParameter("@Location",SqlDbType.NVarChar,50){Value = string.IsNullOrEmpty(obj.TagLocation)?DBNull.Value:(object)obj.TagLocation},
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
        /// 根据指标Id删除本地指标与第三方采集系统的指标对应关系。
        /// </summary>
        /// <param name="id">指标Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(string tagId)
        {
            var sqlStatement = "Delete From T_Tag_SqlMap Where I_Tag_Id = @TagId";
            var parms = new[] { new SqlParameter("@TagId", SqlDbType.VarChar,8) { Value = tagId } };
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
        /// 删除本地指标与第三方采集系统的指标对应关系记录。
        /// </summary>
        /// <param name="obj">本地指标与第三方采集系统的指标对应关系记录。</param>
        /// <returns>bool</returns>
        public override bool Delete(TagSqlMapInfo obj)
        {
            return this.Delete(obj.TagId);
        }

        /// <summary>
        /// 获取所有的本地指标与第三方采集系统的指标对应关系记录。
        /// </summary>
        /// <returns>本地指标与第三方采集系统的指标对应关系集合。</returns>
        public override List<TagSqlMapInfo> GetAll()
        {
            var sqlStatement = "Select A.I_Tag_Id,A.I_Tag_Name,A.I_Tag_Type,A.I_Unit,A.I_Dig_Num,B.I_Tag_UnitName,B.I_Tag_SqlName,B.I_Tag_SqlType,B.I_Tag_Location,B.I_Enabled From T_Tag_Ms A,T_Tag_SqlMap B Where A.I_Tag_Id = B.I_Tag_Id";
            var objs = new List<TagSqlMapInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToTagSqlMapInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public override List<TagSqlMapInfo> GetByContent(string content)
        {
            var sqlStatement = @"
Select  A.I_Tag_Id,A.I_Tag_Name,A.I_Tag_Type,A.I_Unit,A.I_Dig_Num,B.I_Tag_UnitName,B.I_Tag_UnitName,B.I_Tag_SqlName,B.I_Tag_SqlType,B.I_Tag_Location,B.I_Enabled 
From    T_Tag_Ms A,T_Tag_SqlMap B 
Where   A.I_Tag_Id = B.I_Tag_Id And
        (A.I_Tag_Name Like '%{0}%' Or  A.I_Tag_Id Like '%{0}%' OR B.I_Tag_UnitName Like '%{0}%' OR B.I_Tag_SqlName Like '%{0}%' OR B.I_Tag_Location Like '%{0}%')";
            sqlStatement = string.Format(sqlStatement,content);

            var objs = new List<TagSqlMapInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToTagSqlMapInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取本地指标与第三方采集系统的指标对应关系.
        /// </summary>
        /// <param name="id">报表分类Id。</param>
        /// <returns>报表分类</returns>
        public override TagSqlMapInfo GetByTagId(string tagId)
        {
            var sqlStatement = "Select A.I_Tag_Id,A.I_Tag_Name,A.I_Tag_Type,A.I_Unit,A.I_Dig_Num,B.I_Tag_UnitName,B.I_Tag_SqlName,B.I_Tag_SqlType,B.I_Tag_Location,B.I_Enabled From T_Tag_Ms A,T_Tag_SqlMap B Where A.I_Tag_Id = B.I_Tag_Id And A.I_Tag_Id = @TagId";
            var parms = new[] { new SqlParameter("@TagId", SqlDbType.VarChar,8) { Value = tagId } };
            TagSqlMapInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToTagSqlMapInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

    }
}
