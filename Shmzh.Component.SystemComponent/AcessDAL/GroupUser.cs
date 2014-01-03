using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class GroupUser : IDAL.IGroupUser
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT_GROUPUSER= "Insert Into mySystemGroupUsers (GroupCode,UserCode) Values (@GroupCode,@UserCode)";

        private const string SQL_DELETE_GROUPUSER =
            "Delete From mySystemGroupUsers Where GroupCode = @GroupCode And UserCode = @UserCode";

        private const string SQL_SELECT_BY_GROUPCODE = "Select * From mySystemGroupUsers Where GroupCode = @GroupCode";
        #endregion

        #region private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_GROUPUSER);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@GroupCode", OleDbType.SmallInt),
                                new OleDbParameter("@UserCode", OleDbType.VarChar,20), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_GROUPUSER, parms);
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

        public bool Insert(GroupUserInfo groupUserInfo)
        {
            var parms = GetParameters();
            parms[0].Value = groupUserInfo.GroupCode;
            parms[1].Value = groupUserInfo.UserCode;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_INSERT_GROUPUSER, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 添加组用户。
        /// </summary>
        /// <param name="obj">组用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupUserInfo obj, DbTransaction trans)
        {
            throw new System.NotImplementedException();
        }

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
                    AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_INSERT_GROUPUSER, parms);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public bool Delete(GroupUserInfo groupUserInfo)
        {
            var parms = GetParameters();
            parms[0].Value = groupUserInfo.GroupCode;
            parms[1].Value = groupUserInfo.UserCode;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_DELETE_GROUPUSER, parms);
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///  根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <returns>bool</returns>
        public bool Delete(string userCode)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据指定的用户名来删除组和用户的关系记录。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(string userCode, DbTransaction trans)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的组用户集合.
        /// </summary>
        /// <returns>组用户集合.</returns>
        public IList<GroupUserInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<GroupUserInfo> GetByGroupCode(short groupCode)
        {
            var parms = GetParameters();
            parms[0].Value = groupCode;
            var objs = new ListBase<GroupUserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,SQL_SELECT_BY_GROUPCODE,parms);
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
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
