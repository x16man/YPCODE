using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.Util;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Enum;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data.SqlClient
{
    class SqlOperationProvider:OperationProvider
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
            get { return this._useGzip; }
            set { this._useGzip = value; }
        }
        #endregion

        /// <summary>
        /// 是否需要压缩.
        /// </summary>
        private bool IsZipped
        {
            get { return this._useGzip.ToUpper() == "TRUE"; }
        }
        #region CTOR
        /// <summary>
		/// Creates a new <see cref="SqlCategoryProvider"/> instance.
		/// </summary>
		public SqlOperationProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="SqlCategoryProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	    public SqlOperationProvider(string connectionString, string providerInvariantName,string useGzip)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
            this._useGzip = useGzip;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到报表操作记录实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>报表操作记录实体。</returns>
        private OperationInfo ConvertToOperationInfo(IDataRecord dr)
        {
            var obj = new OperationInfo();
            obj.Id = dr.GetDecimal(0);
            obj.OperateTime = dr["Operate_Time"] == DBNull.Value ? DateTime.MinValue : dr.GetDateTime(1);
            obj.OperatorCode = dr["Operator_Code"] == DBNull.Value ? string.Empty : dr.GetString(2);
            obj.OperatorName = dr["Operator_Name"] == DBNull.Value ? string.Empty : dr.GetString(3);
            obj.OperatorIp = dr["Operator_Ip"] == DBNull.Value ? string.Empty : dr.GetString(4);
            obj.ReportCode = dr["Report_Code"] == DBNull.Value ? string.Empty : dr.GetString(5);
            obj.OperateType = dr["Operate_Type"] == DBNull.Value ? OperateType.UnDefined : (OperateType)dr.GetInt16(6);
            obj.CycleId = dr["I_Cycle_Id"] == DBNull.Value ? 0 : dr.GetInt32(7);
            obj.ModifyInfo = dr["Modify_Info"] == DBNull.Value ? string.Empty : dr.GetString(8);
            obj.OldXml = dr["Old_Xml"] == DBNull.Value ? string.Empty : (this.IsZipped? StringUtil.Zip(dr.GetString(9)):dr.GetString(9));
            obj.IsZipped = this.IsZipped;
            return obj;
        }
        #endregion

        #region Implementation of IOperation

        /// <summary>
        /// 添加报表操作信息。
        /// </summary>
        /// <param name="obj">报表操作信息。</param>
        /// <returns>bool</returns>
        public override bool Insert(OperationInfo obj)
        {
            var sqlStatement =
                @"Insert Into T_Operate_Info (Operate_Time,Operator_Code,Operator_Name,Operator_Ip,Report_Code,Operate_Type,I_Cycle_Id,Modify_Info,Old_Xml
                                Value (@OperateTime,@OperatorCode,@OperatorName,@OperatorIp,@ReportCode,@OperateType,@CycleId,@ModifyInfo,@OldXml)
                    Set @Id = SCOPE_IDENTITY()";
            var parms = new[]
                            {
                                new SqlParameter("@Id",SqlDbType.Decimal){Value = 0,Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@OperateTime",SqlDbType.DateTime){Value = obj.OperateTime==DateTime.MinValue?DBNull.Value:(object)obj.OperateTime},
                                new SqlParameter("@OperatorCode",SqlDbType.NVarChar,20){Value = obj.OperatorCode==string.Empty?DBNull.Value:(object)obj.OperatorCode},
                                new SqlParameter("@OperatorName", SqlDbType.NVarChar,50){Value = obj.OperatorName==string.Empty?DBNull.Value:(object)obj.OperatorName},
                                new SqlParameter("@OperatorIp",SqlDbType.NVarChar,20){Value =obj.OperatorIp==string.Empty?DBNull.Value :(object)obj.OperatorIp},
                                new SqlParameter("@ReportCode",SqlDbType.NVarChar,20){Value = obj.ReportCode==string.Empty?DBNull.Value:(object)obj.ReportCode},
                                new SqlParameter("@OperateType", SqlDbType.SmallInt){Value = obj.OperateType==OperateType.UnDefined?DBNull.Value:(object)obj.OperateType},
                                new SqlParameter("@CycleId", SqlDbType.Int){Value = obj.CycleId==0?DBNull.Value:(object)obj.CycleId},
                                new SqlParameter("@ModifyInfo", SqlDbType.Text){Value = obj.ModifyInfo==string.Empty?DBNull.Value:(object)obj.ModifyInfo},
                                new SqlParameter("@OldXml", SqlDbType.Text){Value = obj.OldXml == string.Empty?DBNull.Value:(object)(obj.IsZipped?StringUtil.UnZip(obj.OldXml):obj.OldXml)},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                obj.Id = (decimal)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 更改报表操作信息。
        /// </summary>
        /// <param name="obj">报表操作信息。</param>
        /// <returns>bool</returns>
        public override bool Update(CategoryInfo obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id删除报表操作记录。
        /// </summary>
        /// <param name="id">报表操作记录Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(decimal id)
        {
            var sqlStatement = "Delete From T_Operate_Info Where PKID = @Id";
            var parms = new[]
                            {
                                new SqlParameter("@Id",SqlDbType.Decimal){Value = id},
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
        /// 删除报表操作记录。
        /// </summary>
        /// <param name="obj">报表操作实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(OperationInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 根据报表编号和时间点获取所有的报表操作记录。
        /// </summary>
        /// <param name="reportCode">报表编号。</param>
        /// <param name="cycleId">时间点。</param>
        /// <returns>报表操作记录。</returns>
        public override IList<OperationInfo> GetByReportCodeAndCycleId(string reportCode, int cycleId)
        {
            var sqlStatement = "Select PKID,Operate_Time,Operator_Code,Operator_Name,Operator_Ip,Report_Code,Operate_Type,I_Cycle_Id,Modify_Info as Modify_Info,null as Old_Xml From T_Operate_Info Where Report_Code = @ReportCode And I_Cycle_Id = @CycleId";
            var parms = new[] {
                new SqlParameter("@ReportCode", SqlDbType.NVarChar, 20) {Value = reportCode},
                new SqlParameter("@CycleId",SqlDbType.Int){Value = cycleId},
            };
            var objs = new List<OperationInfo>();
            try
            {
                var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToOperationInfo(dr));
                }
                dr.Close();
                return objs;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return objs;
            }

        }

        /// <summary>
        /// 根据Id获取报表分类。
        /// </summary>
        /// <param name="id">报表分类Id。</param>
        /// <returns>报表操作记录.</returns>
        public override OperationInfo GetById(decimal id)
        {
            var sqlStatement = "Select * From T_Operate_Info Where PKID = @Id";
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Decimal) { Value = id } };
            OperationInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToOperationInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据报表编号和时间点获取最近一次的报表操作记录
        /// </summary>
        /// <param name="reportCode">报表编号</param>
        /// <param name="cycleId">时间点</param>
        /// <returns>报表操作记录</returns>
        public override OperationInfo GetLatestByReportCodeAndCycleId(string reportCode, int cycleId)
        {
            var sqlStatement = "Select Top 1 PKID,Operate_Time,Operator_Code,Operator_Name,Operator_Ip,Report_Code,Operate_Type,I_Cycle_Id,null as Modify_Info,null as Old_Xml From T_Operate_Info Where Report_Code = @ReportCode And I_Cycle_Id = @CycleId Order By Operate_Time Desc";
            var parms = new[]
                            {
                                new SqlParameter("@ReportCode", SqlDbType.NVarChar,20) { Value = reportCode },
                                new SqlParameter("@CycleId", SqlDbType.Int){Value = cycleId}, 
                            };
            OperationInfo obj = null;
            var dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToOperationInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
