// <copyright file="OnlineStatusDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Shmzh.Components.SystemComponent.IDAL;
    /// <summary>
    /// 
    /// </summary>
    public class OnlineStatus :IOnlineStatus
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string PARM_USERNAME = "@UserName";
        private const string PARM_IPADDRESS = "@IPAddress";
        private const string PARM_STATUS = "@Status";
        private const string PARM_BEATTIME = "@BeatTime";

        private const string SQL_INSERT  = "Insert Into SD_OnlineStatus(UserName,IPAddress,Status,BeatTime) Values (@UserName,@IPAddress,@Status,@BeatTime)";

        private const string SQL_UPDATE = "Update SD_OnlineStatus Set Status = @Status,BeatTime = @BeatTime Where UserName = @UserName And IPAddress = @IPAddress";
        
        private const string SQL_DELETE = "Delete From SD_OnlineStatus Where UserName = @UserName And IPAddress = @IPAddress";

        private const string SQL_SELECT = "Select * From SD_OnlineStatus Where UserName = @UserName And IPAddress = @IPAddress";

        private const string SQL_SELECTBYUSERNAME = "Select * From SD_OnlineStatus Where UserName = @UserName";

        private const string SQL_SELECTBYIPADDRESS = "Select * From SD_OnlineStatus Where IPAddress = @IPAddress";

        private const string SQL_SELECTONLINE = "SELECT * FROM [SD_OnlineStatus] WHERE [Status] = 'Y'";
        #endregion


        #region ITemplate 成员
        /// <summary>
        /// 增加。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态实体。</param>
        /// <returns>bool</returns>
        public bool Insert(OnlineStatusInfo onlineStatus)
        {
            var parms = GetOnlineStatusParameters();
            parms[0].Value = onlineStatus.UserName;
            parms[1].Value = onlineStatus.IPAddress;
            parms[2].Value = onlineStatus.Status;
            parms[3].Value = onlineStatus.BeatTime;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 修改。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态实体。</param>
        /// <returns>bool</returns>
        public bool Update(OnlineStatusInfo onlineStatus)
        {
            var parms = GetOnlineStatusParameters();
            parms[0].Value = onlineStatus.UserName;
            parms[1].Value = onlineStatus.IPAddress;
            parms[2].Value = onlineStatus.Status;
            parms[3].Value = onlineStatus.BeatTime;

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
        /// 删除。
        /// </summary>
        /// <param name="onlineStatus"></param>
        /// <returns></returns>
        public bool Delete(OnlineStatusInfo onlineStatus)
        {
            var parms = GetOnlineStatusParameters();
            parms[0].Value = onlineStatus.UserName;
            parms[1].Value = onlineStatus.IPAddress;

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
        /// <summary>
        /// 根据用户名和IP地址获取用户在线状态记录。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线状态实体。</returns>
        public OnlineStatusInfo GetByUserNameAndIPAddress(string userName, string ipAddress)
        {
            var parms = GetOnlineStatusParameters();
            parms[0].Value = userName;
            parms[1].Value = ipAddress;
            OnlineStatusInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT, parms);
            while (dr.Read())
            {
                obj = ConvertToOnlinStatusInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        /// <summary>
        /// 根据用户名获取用户在线状态记录集。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>IList</returns>
        public ListBase<OnlineStatusInfo> GetByUserName(string userName)
        {
            var parms = GetOnlineStatusParameters();
            parms[0].Value = userName;

            var objs = new ListBase<OnlineStatusInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECTBYUSERNAME, parms);
            while (dr.Read())
            {
                var obj = ConvertToOnlinStatusInfo(dr);
                objs.Add( obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据IP地址获取用户在线状态记录集。
        /// </summary>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>IList。</returns>
        public ListBase<OnlineStatusInfo> GetByIPAddress(string ipAddress)
        {
            var parms = GetOnlineStatusParameters();
            parms[1].Value = ipAddress;
            
            var objs = new ListBase<OnlineStatusInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECTBYIPADDRESS, parms);
            while (dr.Read())
            {
                var obj = ConvertToOnlinStatusInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据在线用户记录集。
        /// </summary>       
        /// <returns>IList</returns>
        public ListBase<OnlineStatusInfo> GetOnlineUser()
        {          
            var objs = new ListBase<OnlineStatusInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECTONLINE);
            while (dr.Read())
            {
                var obj = ConvertToOnlinStatusInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static SqlParameter[] GetOnlineStatusParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_USERNAME, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_IPADDRESS, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_STATUS, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_BEATTIME, SqlDbType.DateTime)
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }

        private OnlineStatusInfo ConvertToOnlinStatusInfo(IDataRecord dr)
        {
            var obj = new OnlineStatusInfo(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetDateTime(3));
            return obj;
        }

        #endregion
    }
}
