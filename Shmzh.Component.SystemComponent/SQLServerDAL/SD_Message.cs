using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.IDAL;
namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 消息的SQLServer数据访问对象。
    /// </summary>
    public class SD_Message : I_SD_Message
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169

        private const string SQL_INSERT_SD_MESSAGE = "Insert Into SD_Message ( TypeId, Name, [Desc], PRI, URL,Status, Refer, ReferUserName, Handler, HandlerUserName, CreateTime, TipTime, ViewTime) Values ( @TypeId, @Name, @Desc, @PRI, @URL, @Status, @Refer, @ReferUserName, @Handler, @HandlerUserName, @CreateTime, @TipTime, @ViewTime) SET @Id = SCOPE_IDENTITY()";
        private const string SQL_UPDATE_SD_MESSAGE = "Update SD_Message Set TypeId = @TypeId, Name = @Name, [Desc] = @Desc, PRI = @PRI, URL = @URL , Status = @Status, Refer = @Refer, ReferUserName = @ReferUserName, Handler = @Handler, HandlerUserName = @HandlerUserName, CreateTime = @CreateTime, TipTime = @TipTime, ViewTime = @ViewTime Where Id = @Id";
        private const string SQL_DELETE_SD_MESSAAGE = "Delete From SD_Message Where Id = @Id";
        private const string SQL_SELECT_ALL_SD_MESSAGES = "Select * From SD_Message";
        private const string SQL_SELECT_BY_HANDLER_SD_MESSAGES = "Select * From SD_Message Where HandlerUserName = @HandlerUserName";
        private const string SQL_SELECT_BY_HANDLER_STATUS_SD_MESSAGES = "Select * From SD_Message Where HandlerUserName = @HandlerUserName And Status = @Status";
        private const string SQL_SELECT_BY_HANDLER_TYPE_SD_MESSAGES = "Select * From SD_Message Where HandlerUserName = @HandlerUserName And TypeId = @TypeId";
        private const string SQL_SELECT_BY_HANDLER_STATUS_TYPE_SD_MESSAGES = "Select * From SD_Message Where HandlerUserName = @HandlerUserName And Status = @Status And TypeId = @TypeId";
        private const string SQL_SELECT_BY_WHERECLAUSE_SD_MESSAGAE = "Select * From SD_Message {0}";
        private const string SQL_SELECT_BY_ID_SD_MESSAGE = "Select * From SD_Message Where Id = @Id";
        private const string SQL_SELECT_BY_Refer_CreateTime_SD_MESSAGE = "Select * From SD_Message Where [ReferUserName] = @ReferUserName AND [CreateTime] = @CreateTime";
        private const string SQL_SELECT_GetCurrentTimeFromDB = "SELECT GETDATE() AS [CurrentTime]";
        private const string SQL_UPDATE_SetStatusToReceived_SD_MESSAGE = "UPDATE SD_Message SET [Status] = 1, [TipTime] = getdate() WHERE [Status] = 0 AND [TipTime] IS NULL AND [HandlerUserName] = @HandlerUserName";
        private const string SQL_UPDATE_SetStatusToRead_SD_MESSAGE = "UPDATE SD_Message SET [Status] = 2, [ViewTime] = getdate() WHERE [Status] <> 2 AND [ID] = @ID";

        private const string PARM_ID = "@Id";
        private const string PARM_TYPEID = "@TypeId";
        private const string PARM_NAME = "@Name";
        private const string PARM_DESC = "@Desc";
        private const string PARM_PRI = "@PRI";
        private const string PARM_URL = "@URL";
        private const string PARM_STATUS = "@Status";
        private const string PARM_REFER = "@Refer";
        private const string PARM_REFERUSERNAME = "@ReferUserName";
        private const string PARM_HANDLER = "@Handler";
        private const string PARM_HANDLERUSERNAME = "@HandlerUserName";
        private const string PARM_CREATETIME = "@CreateTime";
        private const string PARM_TIPTIME = "@TipTime";
        private const string PARM_VIEWTIME = "@ViewTime";
        #endregion

        #region I_SD_Message 成员
        /// <summary>
        /// 添加消息记录。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SD_MessageInfo messageInfo)
        {
            var parms = GetMessageParameters();
            parms[0].Value = 0;
            parms[1].Value = messageInfo.TypeId;
            parms[2].Value = messageInfo.Name;
            parms[3].Value = messageInfo.Desc;
            parms[4].Value = messageInfo.PRI;
            parms[5].Value = messageInfo.URL;
            parms[6].Value = messageInfo.Status;
            parms[7].Value = messageInfo.Refer;
            parms[8].Value = messageInfo.ReferUserName;
            parms[9].Value = messageInfo.Handler;
            parms[10].Value = messageInfo.HandlerUserName;
            parms[11].Value = messageInfo.CreateTime;
            parms[12].Value = (messageInfo.TipTime == DateTime.MinValue) ? (object)DBNull.Value : messageInfo.TipTime;
            parms[13].Value = messageInfo.ViewTime == DateTime.MinValue ? (object)DBNull.Value : messageInfo.ViewTime;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_SD_MESSAGE, parms);
                messageInfo.ID = (long)parms[0].Value;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// 修改消息记录。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(SD_MessageInfo messageInfo)
        {
            var parms = GetMessageParameters();
            parms[0].Value = 0;
            parms[1].Value = messageInfo.TypeId;
            parms[2].Value = messageInfo.Name;
            parms[3].Value = messageInfo.Desc;
            parms[4].Value = messageInfo.PRI;
            parms[5].Value = messageInfo.URL;
            parms[6].Value = messageInfo.Status;
            parms[7].Value = messageInfo.Refer;
            parms[8].Value = messageInfo.ReferUserName;
            parms[9].Value = messageInfo.Handler;
            parms[10].Value = messageInfo.HandlerUserName;
            parms[11].Value = messageInfo.CreateTime;
            parms[12].Value = (messageInfo.TipTime == DateTime.MinValue) ? (object)DBNull.Value : messageInfo.TipTime;
            parms[13].Value = messageInfo.ViewTime == DateTime.MinValue ? (object)DBNull.Value : messageInfo.ViewTime;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_SD_MESSAGE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// 删除消息记录实体。
        /// </summary>
        /// <param name="messageInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SD_MessageInfo messageInfo)
        {
            var parms = GetMessageParameters();
            parms[0].Value = messageInfo.ID;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_SD_MESSAAGE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取所有消息记录集合。
        /// </summary>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetALL()
        {
            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL_SD_MESSAGES);
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据处理人用户名获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandler(string handlerUserName)
        {
            var parms = GetMessageParameters();
            parms[10].Value = handlerUserName;

            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_HANDLER_SD_MESSAGES, parms);
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据处理人用户名和消息记录状态获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="status">消息记录状态。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandlerAndStatus(string handlerUserName, short status)
        {
            var parms = GetMessageParameters();
            parms[10].Value = handlerUserName;
            parms[6].Value = status;

            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_HANDLER_STATUS_SD_MESSAGES, parms);
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据处理人用户名和消息类型获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="typeId">消息类型Id。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandlerAndType(string handlerUserName, string typeId)
        {
            var parms = GetMessageParameters();
            parms[10].Value = handlerUserName;
            parms[1].Value = typeId;

            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_HANDLER_TYPE_SD_MESSAGES, parms);
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据处理人和消息状态和消息类型获取消息记录集合。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <param name="status">消息状态。</param>
        /// <param name="typeId">消息类型。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByHandlerAndStatusAndType(string handlerUserName, short status, string typeId)
        {
            var parms = GetMessageParameters();
            parms[10].Value = handlerUserName;
            parms[6].Value = status;
            parms[1].Value = typeId;

            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_HANDLER_STATUS_TYPE_SD_MESSAGES, parms);
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据发送人用户名和发送时间获取消息记录集合。
        /// </summary>
        /// <param name="referUserName">发送人用户名。</param>
        /// <param name="createTime">发送时间。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByReferAndCreateTime(string referUserName, DateTime createTime)
        {
            var parms = GetMessageParameters();
            parms[8].Value = referUserName;
            parms[11].Value = createTime;

            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_Refer_CreateTime_SD_MESSAGE, parms);
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据WhereClause语句来获取消息记录的集合。
        /// </summary>
        /// <param name="whereClause">SQL的Where条件语句。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetByWhereClause(string whereClause)
        {
            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, string.Format(SQL_SELECT_BY_WHERECLAUSE_SD_MESSAGAE, whereClause));
            while (dr.Read())
            {
                var obj = ConvertToMessageInfo(dr);

                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据WhereClause语句来获取发送消息记录的集合。
        /// </summary>
        /// <param name="whereClause">SQL的Where条件语句。</param>
        /// <returns>消息记录集合。</returns>
        public IList<SD_MessageInfo> GetSendMsgByWhereClause(string whereClause)
        {
            SD_MessageInfo msgInfo;            
            IList<SD_MessageInfo> objs = new List<SD_MessageInfo>();
            var strSQL = "Select * From V_SD_Message_Send {0}";

            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, String.Format(strSQL, whereClause));
            while (dr.Read())
            {
                var i = 0;
                msgInfo = new SD_MessageInfo {TypeId = dr.GetString(i++), Name = dr.GetString(i++)};
                if (dr[i] != DBNull.Value) msgInfo.Desc = dr.GetString(i);
                i++;
                msgInfo.PRI = dr.GetInt16(i++);
                if (dr[i] != DBNull.Value) msgInfo.URL = dr.GetString(i);
                i++;
                msgInfo.Refer = dr.GetString(i++);
                msgInfo.ReferUserName = dr.GetString(i++);
                msgInfo.CreateTime = dr.GetDateTime(i++);
                msgInfo.Handler = dr.GetString(i++);
                msgInfo.HandlerUserName = dr.GetString(i++);
                msgInfo.HandlerCount = dr.GetInt32(i);

                objs.Add(msgInfo);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据处理人获取未读的分组统计的消息个数。
        /// </summary>
        /// <param name="handlerUserName">处理人用户名。</param>
        /// <returns>消息类型记录集合。</returns>
        public IList<SD_MessageTypeInfo> GetNoReadMsgGroupsByHandler(String handlerUserName)
        {
            IList<SD_MessageTypeInfo> objs = new List<SD_MessageTypeInfo>();
            
            var strSQL = @"SELECT [TypeId], B.[Name] AS [TypeName], COUNT(1) AS [MsgCount] FROM [SD_Message] A 
                    INNER JOIN [SD_MessageType] B ON A.[TypeId] = B.[ID]
                    WHERE [Status] <> 2 AND [HandlerUserName] = @HandlerUserName
                    GROUP BY A.[TypeId], B.[Name]";
            var parms = new[] {
                new SqlParameter(PARM_HANDLERUSERNAME, SqlDbType.NVarChar, 20)
            };
            parms[0].Value = handlerUserName;

            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, strSQL, parms);
            while (dr.Read())
            {
                var i = 0;
                var msgTypeInfo = new SD_MessageTypeInfo
                                  {
                                      ID = dr.GetString(i++),
                                      Name = dr.GetString(i++),
                                      MsgCount = dr.GetInt32(i)
                                  };
                objs.Add(msgTypeInfo);
            }
            dr.Close();
            return objs;
        }               

        /// <summary>
        /// 据接收人获取最后收取和读取消息的时间。
        /// </summary>
        /// <param name="handlerUserName">接收人用户名</param>
        /// <param name="strIPAddress">IP地址。</param>
        /// <returns></returns>
        public SDTransferInfo GetLastMsgInfoByHandler(String handlerUserName, String strIPAddress)
        {
            var parms = new[] {
                new SqlParameter("@UserName", SqlDbType.NVarChar, 20),
                new SqlParameter("@IPAddress", SqlDbType.NVarChar, 20)
            };
            parms[0].Value = handlerUserName;
            parms[1].Value = strIPAddress;

            SDTransferInfo obj = null;

            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.StoredProcedure, "SD_GetLastMsgInfoByHandler", parms);
            if (dr.Read())
            {
                obj = new SDTransferInfo();
                if (dr[0] != DBNull.Value) obj.CreateTime = dr.GetDateTime(0);
                if (dr[1] != DBNull.Value) obj.ViewTime = dr.GetDateTime(1);
                obj.OnlineStatus = dr.GetString(2);
                obj.OnlineCount = dr.GetInt32(3);
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 据接收人用户名将消息状态设置为已接收（已提示）。
        /// </summary>
        /// <param name="handlerUserName">接收人用户名</param>
        /// <returns></returns>
        public Boolean SetStatusToReceivedByHandler(String handlerUserName)
        {            
            var parms = new[] {
                new SqlParameter(PARM_HANDLERUSERNAME, SqlDbType.NVarChar, 20)
            };
            parms[0].Value = handlerUserName;            
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_SetStatusToReceived_SD_MESSAGE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 据接消息ID将消息状态设置为已读。
        /// </summary>
        /// <param name="id">消息ID。</param>
        /// <returns></returns>
        public Boolean SetStatusToReadById(long id)
        {            
            var parms = new[] {
                new SqlParameter(PARM_ID, SqlDbType.BigInt)
            };
            parms[0].Value = id;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_SetStatusToRead_SD_MESSAGE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据ID获取消息记录。
        /// </summary>
        /// <param name="id">消息记录ID。</param>
        /// <returns>消息记录实体。</returns>
        public SD_MessageInfo GetById(long id)
        {
            var parms = GetMessageParameters();
            parms[0].Value = id;

            SD_MessageInfo obj = null;

            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID_SD_MESSAGE, parms);
            while(dr.Read())
            {
                obj = ConvertToMessageInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 从数据库中获取当前时间。
        /// </summary>
        /// <returns>当前时间。</returns>
        public DateTime GetCurrentTimeFromDB()
        {
            object oCurrentTime = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_GetCurrentTimeFromDB);
            return Convert.ToDateTime(oCurrentTime);
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static SqlParameter[] GetMessageParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_SD_MESSAGE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_ID, SqlDbType.BigInt){Direction = ParameterDirection.InputOutput},
                                new SqlParameter(PARM_TYPEID, SqlDbType.NChar,3), 
                                new SqlParameter(PARM_NAME, SqlDbType.NVarChar,50), 
                                new SqlParameter(PARM_DESC, SqlDbType.NVarChar, 255),
                                new SqlParameter(PARM_PRI, SqlDbType.SmallInt),
                                new SqlParameter(PARM_URL, SqlDbType.NVarChar, 255),
                                new SqlParameter(PARM_STATUS, SqlDbType.SmallInt), 
                                new SqlParameter(PARM_REFER, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_REFERUSERNAME, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_HANDLER, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_HANDLERUSERNAME, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_CREATETIME, SqlDbType.DateTime),
                                new SqlParameter(PARM_TIPTIME, SqlDbType.DateTime),
                                new SqlParameter(PARM_VIEWTIME, SqlDbType.DateTime) 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_SD_MESSAGE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataReader数据填充到MessageInfo对象。
        /// </summary>
        /// <param name="dr">SqlDataReader。</param>
        /// <returns>消息实体。</returns>
        private static SD_MessageInfo ConvertToMessageInfo(IDataRecord dr)
        {
            var obj = new SD_MessageInfo
            {
                ID = dr.GetInt64(0),
                TypeId = dr.GetString(1),
                Name = dr.GetString(2),
                PRI = dr.GetInt16(4),
                Status = dr.GetInt16(6),
                Refer = dr.GetString(7),
                ReferUserName = dr.GetString(8),
                Handler = dr.GetString(9),
                HandlerUserName = dr.GetString(10),
                CreateTime = dr.GetDateTime(11)
            };
            if (dr[3] != DBNull.Value) obj.Desc = dr.GetString(3);
            if (dr[5] != DBNull.Value) obj.URL = dr.GetString(5);
            if (dr[12] != DBNull.Value) obj.TipTime = dr.GetDateTime(12);
            if (dr[13] != DBNull.Value) obj.ViewTime = dr.GetDateTime(13);
            return obj;
        }

        #endregion
    }
}
