namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Shmzh.Components.SystemComponent.IDAL;
    /// <summary>
    /// 消息类型的SQLServer数据访问类。
    /// </summary>
    public class SD_MessageType : I_SD_MessageType
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT_SD_MESSAGETYPE = @"
DECLARE @SerialNumber int SELECT @SerialNumber = ISNULL(MAX([SerialNumber]),0) + 1 FROM [SD_MessageType]
Insert Into SD_MessageType ([Id],[Name],[IsLocked],[Remark],[SerialNumber]) Values (@Id, @Name, @IsLocked, @Remark, @SerialNumber)";
        private const string SQL_UPDATE_SD_MESSAGETYPE = "Update SD_MessageType Set [Name] = @Name, [IsLocked] = @IsLocked, [Remark] = @Remark Where [ID] = @Id";
        private const string SQL_DELETE_SD_MESSAGETYPE = @"UPDATE A SET [SerialNumber] = A.[SerialNumber] - 1 FROM [SD_MessageType] A
INNER JOIN [SD_MessageType] B ON A.[SerialNumber] > B.[SerialNumber] WHERE B.[ID] = @Id
Delete From SD_MessageType Where [ID] = @Id";
        private const string SQL_SELECT_ALL_SD_MESSAGETYPE = "Select * From SD_MessageType ORDER BY [SerialNumber]";
        private const string SQL_SELECT_BY_ID_SD_MESSAGETYPE = "Select * From SD_MessageType Where [Id] = @Id";

        private const string PARM_ID = "@Id";
        private const string PARM_NAME = "@Name";
        private const string PARM_ISLOCKED = "@IsLocked";
        private const string PARM_REMARK = "@Remark";
        #endregion


        #region I_SD_MessageType 成员
        /// <summary>
        /// 添加消息记录。
        /// </summary>
        /// <param name="messageTypeInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(SD_MessageTypeInfo messageTypeInfo)
        {
            var parms = GetMessageTypeParameters();
            parms[0].Value = messageTypeInfo.ID;
            parms[1].Value = messageTypeInfo.Name;
            parms[2].Value = messageTypeInfo.IsLocked;
            parms[3].Value = string.IsNullOrEmpty(messageTypeInfo.Remark) ? (object)DBNull.Value : messageTypeInfo.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_SD_MESSAGETYPE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 修改消息记录实体。
        /// </summary>
        /// <param name="messageTypeInfo">消息记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(SD_MessageTypeInfo messageTypeInfo)
        {
            var parms = GetMessageTypeParameters();
            parms[0].Value = messageTypeInfo.ID;
            parms[1].Value = messageTypeInfo.Name;
            parms[2].Value = messageTypeInfo.IsLocked;
            parms[3].Value = string.IsNullOrEmpty(messageTypeInfo.Remark) ? (object)DBNull.Value : messageTypeInfo.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_SD_MESSAGETYPE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 删除消息类型。
        /// </summary>
        /// <param name="messageTypeInfo">消息类型实体。</param>
        /// <returns>bool</returns>
        public bool Delete(SD_MessageTypeInfo messageTypeInfo)
        {
            var parms = GetMessageTypeParameters();
            parms[0].Value = messageTypeInfo.ID;
            
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_SD_MESSAGETYPE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取所有的消息类型。
        /// </summary>
        /// <returns>消息类型集合。</returns>
        public IList<SD_MessageTypeInfo> GetALL()
        {
            IList<SD_MessageTypeInfo> objs = new List<SD_MessageTypeInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL_SD_MESSAGETYPE);
            while (dr.Read())
            {
                var obj = ConvertToMessageTypeInfo(dr);
                
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据ID获取消息类型。
        /// </summary>
        /// <param name="id">消息类型ID。</param>
        /// <returns>消息类型实体。</returns>
        public SD_MessageTypeInfo GetById(string id)
        {
            var parms = GetMessageTypeParameters();
            parms[0].Value = id;

            SD_MessageTypeInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID_SD_MESSAGETYPE,parms);
            while (dr.Read())
            {
                obj = ConvertToMessageTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 消息类型排序号调整。
        /// </summary>
        /// <param name="id">消息类型Id。</param>
        /// <param name="opType">0:上移,1:下移。</param>
        /// <returns></returns>
        public Boolean Move(String id, Byte opType)
        {
            var parms = new[] { 
                new SqlParameter("@ID", SqlDbType.NChar, 3) { Value = id },
                new SqlParameter("@OpType", SqlDbType.TinyInt) { Value = opType }
            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "SD_MessageType_Move", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 验证消息类型是否允许删除。
        /// </summary>
        /// <param name="typeId">消息类型Id。</param>
        /// <returns>bool</returns>
        public Boolean IsAllowDelete(String typeId)
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@TypeId", SqlDbType.NChar, 3)
            };
            parms[0].Value = typeId;
            String strSQL = "SELECT TOP 1 * FROM SD_Message WHERE [TypeId] = @TypeId";
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, strSQL, parms))
                {
                    if (dr.Read())
                    {
                        return false;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }

        #endregion

        #region private method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static SqlParameter[] GetMessageTypeParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_SD_MESSAGETYPE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_ID, SqlDbType.NVarChar, 3),
                                new SqlParameter(PARM_NAME, SqlDbType.NVarChar,10), 
                                new SqlParameter(PARM_ISLOCKED, SqlDbType.Bit), 
                                new SqlParameter(PARM_REMARK, SqlDbType.NVarChar, 255)
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_SD_MESSAGETYPE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将SqlDataReader转换为消息类型实体。
        /// </summary>
        /// <param name="dr">SqlDataReader。</param>
        /// <returns>消息类型实体。</returns>
        private SD_MessageTypeInfo ConvertToMessageTypeInfo(IDataRecord dr)
        {
            var obj = new SD_MessageTypeInfo
            {
                ID = dr["ID"].ToString(),
                Name = dr["Name"].ToString(),
                IsLocked = Convert.ToBoolean(dr["IsLocked"]),
                SerialNumber = Convert.ToInt32(dr["SerialNumber"])
            };
            if (dr["Remark"] != DBNull.Value) obj.Remark = dr["Remark"].ToString();
            return obj;
        }

        #endregion
    }
}
