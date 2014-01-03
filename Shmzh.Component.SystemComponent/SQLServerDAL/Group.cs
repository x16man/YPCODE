using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 组的SQLServer数据访问对象。
    /// </summary>
    class Group : IGroup
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 添加组记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_GROUP = "Insert Into mySystemGroups (GroupName,Remark,SerialNo,GroupCatId) Values (@GroupName,@Remark,@SerialNo,@GroupCatId) Set @GroupCode = SCOPE_IDENTITY()";
        /// <summary>
        /// 修改组记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_GROUP = "Update mySystemGroups Set GroupName = @GroupName, Remark = @Remark ,SerialNo = @SerialNo, GroupCatId = @GroupCatId Where GroupCode = @GroupCode";
        /// <summary>
        /// 删除组记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_GROUP = @"Delete From mySystemGroups Where GroupCode = @GroupCode
Delete From mySystemGroupRoles Where GroupCode = @GroupCode
Delete From mySystemGroupUsers Where GroupCode = @GroupCode";
        /// <summary>
        /// 获取所有组记录。
        /// </summary>
        private const string SQL_SELECT_ALL = "Select * From mySystemGroups";
        /// <summary>
        /// 根据组名称获取组记录。
        /// </summary>
        private const string SQL_SELECT_BY_NAME = "Select Count(*) From mySystemGroups Where GroupName = @GroupName";
        /// <summary>
        /// 根据组编号获取组记录。
        /// </summary>
        private const string SQL_SELECT_BY_CODE = "Select * From mySystemGroups Where GroupCode = @GroupCode";
        /// <summary>
        /// 组编号。
        /// </summary>
        private const string PARM_GROUPCODE = "@GroupCode";
        /// <summary>
        /// 组名称。
        /// </summary>
        private const string PARM_GROUPNAME = "@GroupName";
        /// <summary>
        /// 组描述。
        /// </summary>
        private const string PARM_REMARK = "@Remark";
        /// <summary>
        /// 序号。
        /// </summary>
        private const string PARM_SERIALNO = "@SerialNo";

        private const string PARM_GROUPCATID = "@GroupCatId";
        
        #endregion

        #region IGroup 成员
        /// <summary>
        /// 添加组。
        /// </summary>
        /// <param name="groupInfo">组信息实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupInfo groupInfo)
        {
            var parms = GetGroupParameters();
            parms[0].Value = 0;
            parms[1].Value = groupInfo.GroupName;
            parms[2].Value = string.IsNullOrEmpty(groupInfo.Remark) ? (object)DBNull.Value : groupInfo.Remark;
            parms[3].Value = groupInfo.SerialNo;
            parms[4].Value = groupInfo.GroupCatId;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_GROUP, parms);
                groupInfo.GroupCode = short.Parse(parms[0].Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 批量添加组用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="userNames">用户名拼接字符串。</param>
        /// <returns>bool</returns>
        public bool Insert(short groupCode, string userNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改组。
        /// </summary>
        /// <param name="groupInfo">组信息实体。</param>
        /// <returns>bool</returns>
        public bool Update(GroupInfo groupInfo)
        {
            var parms = GetGroupParameters();
            parms[0].Value = groupInfo.GroupCode;
            parms[1].Value = groupInfo.GroupName;
            parms[2].Value = string.IsNullOrEmpty(groupInfo.Remark) ? (object)DBNull.Value : groupInfo.Remark;
            parms[3].Value = groupInfo.SerialNo;
            parms[4].Value = groupInfo.GroupCatId;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_GROUP, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupInfo">组信息实体。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupInfo groupInfo)
        {
            var parms = GetGroupParameters();
            parms[0].Value = groupInfo.GroupCode;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_GROUP, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除组。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short groupCode)
        {
            var parms = GetGroupParameters();
            parms[0].Value = groupCode;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_GROUP, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 判断组名称是否已经存在。
        /// </summary>
        /// <param name="groupName">组名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string groupName)
        {
            var parms = GetGroupParameters();
            parms[1].Value = groupName;
            try
            {
                var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_NAME, parms);
                return (int) obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return true;
            }
        }
        /// <summary>
        /// 获取所有组记录。
        /// </summary>
        /// <returns>组记录集合。</returns>
        public IList<GroupInfo> GetAll()
        {
            IList<GroupInfo> objs = new ListBase<GroupInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                var obj = ConvertToGroupInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据组编好获取组信息实体。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组信息实体。</returns>
        public GroupInfo GetByCode(short groupCode)
        {
            var parms = GetGroupParameters();
            parms[0].Value = groupCode;
            
            GroupInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_CODE, parms);
            while(dr.Read())
            {
                obj = ConvertToGroupInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

       #endregion

        #region Private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetGroupParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_GROUP);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_GROUPCODE, SqlDbType.SmallInt){Direction = ParameterDirection.InputOutput},
                                new SqlParameter(PARM_GROUPNAME, SqlDbType.NVarChar,50), 
                                new SqlParameter(PARM_REMARK, SqlDbType.NVarChar,50), 
                                new SqlParameter(PARM_SERIALNO, SqlDbType.SmallInt), 
                                new SqlParameter(PARM_GROUPCATID, SqlDbType.SmallInt), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_GROUP, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private static GroupInfo ConvertToGroupInfo(IDataRecord dr)
        {
            var obj = new GroupInfo
            {
                GroupCode = dr.GetInt16(0),
                GroupName = dr.GetString(1),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                SerialNo = dr["SerialNo"] ==DBNull.Value?(short)0:short.Parse(dr["SerialNo"].ToString()),
                GroupCatId = dr.GetInt16(4),
            };
            return obj;
        }
        #endregion
    }
}
