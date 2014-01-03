using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlAnalogProvider:AnalogProvider
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
		/// Creates a new <see cref="SqlAnalogProvider"/> instance.
		/// </summary>
		public SqlAnalogProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlAnalogProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlAnalogProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到AnalogInfo。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>AnalogInfo</returns>
        private static AnalogInfo ConvertToAnalogInfo(IDataRecord dr)
        {
            var obj = new AnalogInfo();
            obj.TagId = dr.GetString(0);
            obj.UnitName = dr.GetString(1);
            obj.ValueName = dr.GetString(2);
            obj.Time = dr.GetDateTime(3);
            //obj.Value = dr.GetFloat(4);
            obj.Value = float.Parse(dr["值"].ToString());

            return obj;
        }
        #endregion

        #region Overrides of AnalogProvider

        /// <summary>
        /// 根据指定的时间来获取模拟量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>数字量指标数据。</returns>
        public override List<AnalogInfo> GetByTime(DateTime time)
        {
            var dateString = time.ToString("yyyyMMdd");
            var sqlStatement = @"
Select  B.I_Tag_Id
,       A.[单元名称]
,       A.[数据名称]
,       A.[时间]
,       A.[值]
From    LINK_3rd.[int].dbo.Analog{0} As A,T_Tag_Gather B
Where   A.[单元名称] = B.I_DESIGN_CD And
        A.[数据名称] = B.I_ADDRESS And
        A.[时间] = @Time And
        B.[I_ACTION] = 4 ";
            sqlStatement = string.Format(sqlStatement, dateString);

            var parms = new[] {new SqlParameter("@Time", SqlDbType.DateTime) {Value = time}};
            var objs = new List<AnalogInfo>();
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToAnalogInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指定的时间来同步模拟量指标数据。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>bool</returns>
        public override bool SyncByTime(DateTime time)
        {
            var dateString = time.ToString("yyyyMMdd");
            var sqlStatement = @"
Delete From T_Tag_Hour Where I_Cycle_ID = dbo.DateTime2HourCycleId(@Time) And I_Tag_Id IN (Select I_Tag_ID From T_Tag_Gather Where I_Action=4) 

Insert  Into T_Tag_Hour (I_Tag_id,I_Cycle_Id,I_Value_Org,I_Value_Man)
Select  B.I_Tag_Id
,       dbo.DateTime2HourCycleId(A.[时间])
,       B.I_PARA_A*A.[值]+B.I_PARA_B,B.I_PARA_A*A.[值]+B.I_PARA_B
From    LINK_3rd.[int].dbo.Analog{0} As A,T_Tag_Gather B
Where   A.[单元名称] = B.I_DESIGN_CD And
        A.[数据名称] = B.I_ADDRESS And
        A.[时间] = @Time And
        B.[I_ACTION] = 4";
            sqlStatement = string.Format(sqlStatement, dateString);
            var parms = new[] { new SqlParameter("@Time", SqlDbType.DateTime) { Value = time } };
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

        #endregion
    }
}
