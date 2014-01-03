using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 系统访问记录的SQL Server的数据访问层。
    /// </summary>
    public class History :IDAL.IHistory
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = "Insert Into mySystemHistory ([Operation],[Url],[UserName],[IpAddress],[OpTime]) Values (@Operation,@Url,@UserName,@IpAddress,@OpTime) Set @Id = SCOPE_IDENTITY()";
        private const string SQL_UPDATE = "Update mySystemHistory Set [Operation]  = @Operation,[Url]=@Url,[UserName]=@UserName,[IpAddress]=@IpAddress,[OpTime]=@OpTime Where Id = @Id";
        private const string SQL_DELETE = "Delete From mySystemHistory Where Id = @Id";

        private const string SQL_SELECT_ALL_BY_DATETIME =
            "Select * From mySystemHistory Where OpTime>=@BeginTime And OpTime<=@EndTime Order By OpTime Desc";

        private const string SQL_SELECT_BY_USERNAME_DATETIME = "Select * From mySystemHistory Where UserName = @UserName And OpTime>=@BeginTime And OpTime<=@EndTime Order By OpTime Desc";
        #endregion


        #region IHistory 成员

        /// <summary>
        /// 添加系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        public bool Insert(HistoryInfo historyInfo)
        {
            var parms = new[] {
                new SqlParameter("@Id",SqlDbType.BigInt){Value =  0,Direction = ParameterDirection.InputOutput},
                new SqlParameter("@Operation", SqlDbType.NVarChar, 20) {Value = historyInfo.Operation},
                new SqlParameter("@Url",SqlDbType.NVarChar,100){Value = historyInfo.Url},
                new SqlParameter("@UserName", SqlDbType.NVarChar,20){Value = historyInfo.UserName},
                new SqlParameter("@IpAddress", SqlDbType.NVarChar,50){Value = historyInfo.IpAddress},
                new SqlParameter("@OpTime", SqlDbType.DateTime){Value = historyInfo.OpTime},
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                historyInfo.Id = long.Parse(parms[0].Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        public bool Update(HistoryInfo historyInfo)
        {
            var parms = new[] {
                new SqlParameter("@Id",SqlDbType.BigInt){Value =  historyInfo.Id},
                new SqlParameter("@Operation", SqlDbType.NVarChar, 20) {Value = historyInfo.Operation},
                new SqlParameter("@Url",SqlDbType.NVarChar,100){Value = historyInfo.Url},
                new SqlParameter("@UserName", SqlDbType.NVarChar,20){Value = historyInfo.UserName},
                new SqlParameter("@IpAddress", SqlDbType.NVarChar,50){Value = historyInfo.IpAddress},
                new SqlParameter("@OpTime", SqlDbType.DateTime){Value = historyInfo.OpTime},
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除系统访问记录。
        /// </summary>
        /// <param name="historyInfo">系统访问记录。</param>
        /// <returns>bool</returns>
        public bool Delete(HistoryInfo historyInfo)
        {
            return Delete(historyInfo.Id);
        }

        /// <summary>
        /// 删除系统访问记录。
        /// </summary>
        /// <param name="id">系统访问记录Id。</param>
        /// <returns>bool</returns>
        public bool Delete(long id)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.BigInt) {Value = id}};
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        #endregion

        #region Priviat Method
        /// <summary>
        /// 将DataRow转换成HistoryInfoInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>访问记录实体。</returns>
        private HistoryInfo ConvertToHistoryInfo(IDataRecord dr)
        {
            var obj = new HistoryInfo
            {
                Id = dr.GetInt64(0),
                Operation = dr.GetString(1),
                Url = dr["Url"] == DBNull.Value ? string.Empty : dr["Url"].ToString(),
                UserName = dr.GetString(3),
                IpAddress = dr.GetString(4),
                OpTime = dr.GetDateTime(5),
            };
            return obj;
        }
        #endregion

        #region IHistory 成员

        /// <summary>
        /// 根据时间段获取所有用户的登录退出记录。
        /// </summary>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        public List<HistoryInfo> GetAllByDateTime(DateTime beginTime, DateTime endTime)
        {
            var parms = new[]
                            {
                                new SqlParameter("@BeginTime", SqlDbType.DateTime) {Value = beginTime},
                                new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime}
                            };
            var objs = new List<HistoryInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL_BY_DATETIME, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToHistoryInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据时间段获取指定用户的登录退出记录
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="beginTime">开始时间。</param>
        /// <param name="endTime">结束时间。</param>
        /// <returns>登录退出记录集合。</returns>
        public List<HistoryInfo> GetByUserAndDateTime(string userName, DateTime beginTime, DateTime endTime)
        {
            var parms = new[]
                            {
                                new SqlParameter("@UserName",SqlDbType.NVarChar,20){Value = userName}, 
                                new SqlParameter("@BeginTime", SqlDbType.DateTime) {Value = beginTime},
                                new SqlParameter("@EndTime", SqlDbType.DateTime) {Value = endTime}
                            };
            var objs = new List<HistoryInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_USERNAME_DATETIME, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToHistoryInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion
    }
}
