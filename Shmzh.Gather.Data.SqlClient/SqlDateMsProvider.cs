using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlDateMsProvider:DateMsProvider
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
		/// Creates a new <see cref="SqlDateMsProvider"/> instance.
		/// </summary>
		public SqlDateMsProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlDateMsProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlDateMsProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到时间特征实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>时间特征实体。</returns>
        private static DateMsInfo ConvertToDateMsInfo(IDataRecord dr)
        {
            var obj = new DateMsInfo();
            obj.Id = dr["I_Date_Key"].ToString();
            obj.Name = dr["I_Name"].ToString();
            obj.BaseKey = dr["I_Base_Key"].ToString();
            obj.SerialNo = short.Parse(dr["I_ORDER"].ToString());
            obj.Count = short.Parse(dr["I_Count"].ToString());
            obj.StartIndex = short.Parse(dr["I_Start"].ToString());
            obj.EndIndex = short.Parse(dr["I_End"].ToString());

            return obj;
        }

        #endregion

        #region Overrides of DateMsProvider

        /// <summary>
        /// 添加时间特征。
        /// </summary>
        /// <param name="obj">时间特征实体。</param>
        /// <returns>bool</returns>
        public override bool Insert(DateMsInfo obj)
        {
            var sqlStatement = "Insert Into T_Date_MS(I_Date_Key,I_ORDER,I_Name,I_Base_Key,I_Count,I_Start,I_End) Values (@Id,@SerialNo,@Name,@BaseKey,@Count,@StartIndex,@EndIndex)";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 10) {Value = obj.Id},
                                new SqlParameter("@Name", SqlDbType.VarChar,50){Value = obj.Name},
                                new SqlParameter("@BaseKey",SqlDbType.VarChar,10){Value = obj.BaseKey},
                                new SqlParameter("@SerialNo",SqlDbType.SmallInt){Value = obj.SerialNo},
                                new SqlParameter("@Count", SqlDbType.SmallInt){Value = obj.Count},
                                new SqlParameter("@StartIndex",SqlDbType.SmallInt){Value = obj.StartIndex},
                                new SqlParameter("@EndIndex",SqlDbType.SmallInt){Value = obj.EndIndex},
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
        /// 更改时间特征。
        /// </summary>
        /// <param name="obj">时间特征实体。</param>
        /// <returns>bool</returns>
        public override bool Update(DateMsInfo obj)
        {
            var sqlStatement = "Update T_Date_Ms Set I_Name = @Name,I_Base_Key = @BaseKey,I_Order=@SerialNo,I_Count=@Count,I_Start=@StartIndex,I_End = @EndIndex Where I_Date_Key = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 10) {Value = obj.Id},
                                new SqlParameter("@Name", SqlDbType.VarChar,50){Value = obj.Name},
                                new SqlParameter("@BaseKey",SqlDbType.VarChar,10){Value = obj.BaseKey},
                                new SqlParameter("@SerialNo",SqlDbType.SmallInt){Value = obj.SerialNo},
                                new SqlParameter("@Count", SqlDbType.SmallInt){Value = obj.Count},
                                new SqlParameter("@StartIndex",SqlDbType.SmallInt){Value = obj.StartIndex},
                                new SqlParameter("@EndIndex",SqlDbType.SmallInt){Value = obj.EndIndex},
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
        /// 根据Id删除时间特征。
        /// </summary>
        /// <param name="id">时间特征Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(string id)
        {
            var sqlStatement = "Delete From T_Date_MS Where I_Date_Key = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 10) {Value = id},
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
        /// 删除时间特征。
        /// </summary>
        /// <param name="obj">时间特征。</param>
        /// <returns>bool</returns>
        public override bool Delete(DateMsInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 获取所有的时间特征。
        /// </summary>
        /// <returns>时间特征集合</returns>
        public override List<DateMsInfo> GetAll()
        {
            var sqlStatement = "Select * From T_Date_MS";
            var objs = new List<DateMsInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement);
            while(dr.Read())
            {
                objs.Add(ConvertToDateMsInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取时间特征。
        /// </summary>
        /// <param name="id">时间特征Id。</param>
        /// <returns>时间特征</returns>
        public override DateMsInfo GetById(string id)
        {
            var sqlStatement = "Select * From T_Date_MS Where I_Date_Key = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.VarChar, 10) {Value = id},
                            };
            DateMsInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToDateMsInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
