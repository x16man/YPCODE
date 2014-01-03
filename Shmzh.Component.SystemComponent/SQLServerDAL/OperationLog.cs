using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 公司信息的SQL Server 的数据访问对象。
    /// </summary>
    public class OperationLog : IOperationLog
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = @"
Insert Into mySystemOperationLog (UserName,OpTime,ProductCode,OpType,OpDesc)
Values (@UserName,@OpTime,@ProductCode,@OpType,@OpDesc) 
SET @Id = SCOPE_IDENTITY()";
        private const string SQL_SELECT_BY_TIME_OPTYPE = "Select * From mySystemOperationLog Where OpTime >=@BeginTime And OpTime <=@EndTime And OpType= @OpType";
        private const string SQL_SELECT_BY_TIME_OPTYPE_OPDESC = "Select * From mySystemOperationLog Where OpTime >=@BeginTime And OpTime <=@EndTime And OpType= @OpType And OpDesc Like @OpDesc";
        
        private const string SQL_SELECT_BY_TIME_OPTYPE_PRODUCTCODE = "Select * From mySystemOperationLog Where OpTime >=@BeginTime And OpTime <=@EndTime And OpType= @OpType And ProductCode = @ProductCode";
        private const string SQL_SELECT_BY_TIME_OPTYPE_PRODUCTCODE_OPDESC = "Select * From mySystemOperationLog Where OpTime >=@BeginTime And OpTime <=@EndTime And OpType= @OpType And ProductCode = @ProductCode And OpDesc Like @OpDesc";
        private const string SQL_SELECT_TOP100_BY_OPTYPE = "Select Top 100 * From mySystemOperationLog Where OpType= @OpType Order by Id desc";
        private const string SQL_SELECT_TOP100_BY_OPTYPE_PRODUCTCODE = "Select Top 100 * From mySystemOperationLog Where OpType= @OpType And ProductCode = @ProductCode Order by Id desc";
        #endregion

        #region private method
        /// <summary>
        /// 将DataRow转换成OperationLogInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>操作记录实体。</returns>
        private OperationLogInfo ConvertToOperationLogInfo(IDataRecord dr)
        {
            var obj = new OperationLogInfo()
              {
                  Id = dr.GetInt64(0),
                  UserName = dr.GetString(1),
                  OpTime = dr.GetDateTime(2),
                  ProductCode = dr.GetInt16(3),
                  OpType = dr.GetString(4),
                  OpDesc = dr.GetString(5),
            };
            return obj;
        }
        #endregion

        #region Implementation of IOperationLog

        /// <summary>
        /// 添加操作日志。
        /// </summary>
        /// <param name="obj">操作日志实体。</param>
        /// <returns>bool</returns>
        public bool Insert(OperationLogInfo obj)
        {
            return Insert(obj, null);
        }

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="obj">操作日志实体.</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(OperationLogInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.BigInt) {Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@UserName", SqlDbType.NVarChar, 50) {Value = obj.UserName},
                                new SqlParameter("@OpTime", SqlDbType.DateTime) {Value = obj.OpTime},
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = obj.ProductCode},
                                new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = obj.OpType},
                                new SqlParameter("@OpDesc", SqlDbType.NText) {Value = obj.OpDesc},
                            };
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT, parms);
                obj.Id = (long)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据指定的时间范围和操作类型来获取操作日志列表。
        /// </summary>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <param name="opType">操作类型。</param>
        /// <returns>操作日志列表。</returns>
        public IList<OperationLogInfo> GetByTimeAndOpType(DateTime beginTime, DateTime endTime, string opType)
        {
            var parms = new[]
                            {
                                new SqlParameter("@BeginTime", SqlDbType.DateTime) {Value = beginTime},
                                new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime},
                                new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = opType},
                            };
            var objs = new ListBase<OperationLogInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_TIME_OPTYPE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOperationLogInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指定的时间范围和操作类型、产品编号来获取操作日志列表
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="opType">操作类型</param>
        /// <param name="productCode">产品编号</param>
        /// <returns>操作日志列表</returns>
        public IList<OperationLogInfo> GetByTimeAndOpTypeAndProductCode(DateTime beginTime, DateTime endTime, string opType, short productCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@BeginTime", SqlDbType.DateTime) {Value = beginTime},
                                new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime},
                                new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = opType},
                                new SqlParameter("@ProductCode",SqlDbType.SmallInt){Value = productCode}, 
                            };
            var objs = new ListBase<OperationLogInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_TIME_OPTYPE_PRODUCTCODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOperationLogInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指定的操作类型获取最新的100条操作记录。
        /// </summary>
        /// <param name="opType">操作类型。</param>
        /// <returns>操作日志列表。</returns>
        public IList<OperationLogInfo> GetTop100(string opType)
        {
            var parms = new[] {new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = opType}};
            var objs = new ListBase<OperationLogInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TOP100_BY_OPTYPE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOperationLogInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指定的操作类型获取最新的100条操作记录。
        /// </summary>
        /// <param name="opType">操作类型</param>
        /// <param name="productCode">产品编号</param>
        /// <returns>操作日志列表</returns>
        public IList<OperationLogInfo> GetTop100(string opType, short productCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = opType},
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt) {Value = productCode},
                            };
            var objs = new ListBase<OperationLogInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TOP100_BY_OPTYPE_PRODUCTCODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOperationLogInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指定的开始时间、结束时间、操作类型、操作描述等条件进行查询。
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="opType">操作类型</param>
        /// <param name="likeOpDesc">操作描述。</param>
        /// <returns>操作日志列表</returns>
        public IList<OperationLogInfo> GetByTimeAndOpTypeAndOpDesc(DateTime beginTime, DateTime endTime, string opType, string likeOpDesc)
        {
            var parms = new[]
                            {
                                new SqlParameter("@BeginTime", SqlDbType.DateTime) {Value = beginTime},
                                new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime},
                                new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = opType},
                                new SqlParameter("@OpDesc", SqlDbType.NText){Value = string.Format("%{0}%",StringUtil.DeleteKeyWord(likeOpDesc))}, 
                            };
            var objs = new ListBase<OperationLogInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_TIME_OPTYPE_OPDESC, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOperationLogInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据指定的开始时间、结束时间、操作类型、产品编号、操作描述等条件进行查询。
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="opType">操作类型</param>
        /// <param name="productCode">产品编号</param>
        /// <param name="likeOpDesc">操作描述。</param>
        /// <returns>操作日志列表</returns>
        public IList<OperationLogInfo> GetByTimeAndOpTypeAndProductCodeAndOpDesc(DateTime beginTime, DateTime endTime, string opType, short productCode, string likeOpDesc)
        {
            var parms = new[]
                            {
                                new SqlParameter("@BeginTime", SqlDbType.DateTime) {Value = beginTime},
                                new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime},
                                new SqlParameter("@OpType", SqlDbType.NVarChar, 50) {Value = opType},
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode}, 
                                new SqlParameter("@OpDesc", SqlDbType.NText){Value = string.Format("%{0}%",StringUtil.DeleteKeyWord(likeOpDesc))}, 
                            };
            var objs = new ListBase<OperationLogInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_TIME_OPTYPE_PRODUCTCODE_OPDESC, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOperationLogInfo(dr));
            }
            dr.Close();
            return objs;
        }
        #endregion
    }
}
