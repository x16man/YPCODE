using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class GroupUser : IDAL.IGroupUser
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT_GROUPUSER= "Insert Into mySystemGroupUsers (GroupCode,UserCode) Values (@GroupCode,@UserCode)";

        private const string SQL_DELETE_GROUPUSER =
            "Delete From mySystemGroupUsers Where GroupCode = @GroupCode And UserCode = @UserCode";

        private const string SQL_DELETE_BY_USERCODE = "Delete From mySystemGroupUsers Where UserCode = @UserCode";
        private const string SQL_SELECT_ALL = "Select * From mySystemGroupUsers";
        private const string SQL_SELECT_BY_GROUPCODE = "Select * From mySystemGroupUsers Where GroupCode = @GroupCode";
        private const string SQL_SELECT_BY_USERCODE = "Select * From mySystemGroupUsers Where UserCode = @UserCode";
        #endregion

        #region private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_GROUPUSER);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@GroupCode", SqlDbType.SmallInt),
                                new SqlParameter("@UserCode", SqlDbType.NVarChar,20), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_GROUPUSER, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupUserInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组用户实体。</returns>
        private GroupUserInfo ConvertToGroupUserInfo(IDataRecord dr)
        {
            var obj = new GroupUserInfo
            {
                GroupCode = dr.GetInt16(0),
                UserCode = dr.GetString(1),
            };
            return obj;
        }
        #endregion

        #region IGroupUser 成员

        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupUserInfo groupUserInfo)
        {
            return Insert(groupUserInfo, null);
        }

        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="obj">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupUserInfo obj, DbTransaction trans)
        {
            var parms = GetParameters();
            parms[0].Value = obj.GroupCode;
            parms[1].Value = obj.UserCode;
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_GROUPUSER, parms);
                else
                {
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT_GROUPUSER, parms);
                }
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
            var aUserName = userNames.Split(',');
            foreach(var userName in aUserName)
            {
                var parms = GetParameters();
                parms[0].Value = groupCode;
                parms[1].Value = userName;
                try
                {
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_GROUPUSER, parms);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupUserInfo groupUserInfo)
        {
            var parms = GetParameters();
            parms[0].Value = groupUserInfo.GroupCode;
            parms[1].Value = groupUserInfo.UserCode;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_GROUPUSER, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除组用户。
        /// </summary>
        /// <param name="groupUserInfo">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(GroupUserInfo groupUserInfo, DbTransaction trans)
        {
            var parms = GetParameters();
            parms[0].Value = groupUserInfo.GroupCode;
            parms[1].Value = groupUserInfo.UserCode;

            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_GROUPUSER, parms);
                else
                {
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DELETE_GROUPUSER, parms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        ///  根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>bool</returns>
        public bool Delete(string userCode)
        {
            return Delete(userCode, null);
        }

        /// <summary>
        /// 根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(string userCode, DbTransaction trans)
        {
            var parms = new[] { new SqlParameter("@UserCode", SqlDbType.NVarChar, 20) { Value = userCode } };

            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_BY_USERCODE, parms);
                else
                {
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DELETE_BY_USERCODE, parms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取所有的组用户集合.
        /// </summary>
        /// <returns>组用户集合.</returns>
        public IList<GroupUserInfo> GetAll()
        {
            var objs = new ListBase<GroupUserInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToGroupUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据组编号来获取组用户集合。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组用户集合。</returns>
        public IList<GroupUserInfo> GetByGroupCode(short groupCode)
        {
            var parms = GetParameters();
            parms[0].Value = groupCode;
            var objs = new ListBase<GroupUserInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData,CommandType.Text,SQL_SELECT_BY_GROUPCODE,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToGroupUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据用户名获取组用户集合。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>组用户集合。</returns>
        public IList<GroupUserInfo> GetByUserCode(string userCode)
        {
            var parms = new[] {new SqlParameter("@UserCode", SqlDbType.NVarChar, 20) {Value = userCode}};
            
            var objs = new ListBase<GroupUserInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_USERCODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToGroupUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion
    }
}
