using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.Model;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 用户分类的SQL Server 的数据访问对象。
    /// </summary>
    public class TB_UserCat:IDAL.ITB_UserCat
    {
        #region Field

        private const string FloDBName = "FloDBName";
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string SQL_INSERT =string.Format("Insert Into {0}.[dbo].[TB_UserCat] (UserCatType,UserCatName,UserCatEnable) Values (@UserCatType,@UserCatName,@UserCatEnable) Set @UserCatId=SCOPE_IDENTITY()",ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_UPDATE =string.Format("Update {0}.TB_UserCat Set UserCatType=@UserCatType,UserCatName=@UserCatName,UserCatEnable=@UserCatEnable Where UserCatId = @UserCatId", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_DELETE = string.Format("Delete From {0}.[dbo].[TB_UserCat] Where UserCatId = @UserCatId", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_BY_CATNAME = string.Format("Select * From {0}.[dbo].[TB_UserCat] Where UserCatName = @UserCatName", ConfigurationManager.AppSettings[FloDBName]);
        #endregion

        #region Implementation of ITB_UserCat

        /// <summary>
        /// 添加用户分类。
        /// </summary>
        /// <param name="obj">用户实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(TB_UserCatInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@UserCatId", SqlDbType.Int)
                                    {Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@UserCatType", SqlDbType.Char, 2) {Value = obj.UserCatType},
                                new SqlParameter("@UserCatName", SqlDbType.NVarChar,50){Value = obj.UserCatName},
                                new SqlParameter("@UserCatEnable", SqlDbType.Bit){Value = obj.UserCatEnable},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT, parms);
                obj.UserCatId = (int)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
            
        }

        /// <summary>
        /// 修改用户分类。
        /// </summary>
        /// <param name="obj">用户实体。</param>
        /// <param name="trans">事务对象</param>
        /// <returns>bool</returns>
        public bool Update(TB_UserCatInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@UserCatId", SqlDbType.Int){Value = obj.UserCatId},
                                new SqlParameter("@UserCatType", SqlDbType.Char, 2) {Value = obj.UserCatType},
                                new SqlParameter("@UserCatName", SqlDbType.NVarChar,50){Value = obj.UserCatName},
                                new SqlParameter("@UserCatEnable", SqlDbType.Bit){Value = obj.UserCatEnable},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 删除用户分类实体。
        /// </summary>
        /// <param name="obj">用户分类实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(TB_UserCatInfo obj, DbTransaction trans)
        {
            return Delete(obj.UserCatId, trans);
        }

        /// <summary>
        /// 删除用户分类实体。
        /// </summary>
        /// <param name="id">用户分类Id。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(int id, DbTransaction trans)
        {
            var parms = new[] {new SqlParameter("@UserCatId", SqlDbType.Int) {Value = id}};
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 根据用户分类名称获取用户分类信息。
        /// </summary>
        /// <param name="userCatName">用户分类名称。</param>
        /// <returns>用户分类实体。</returns>
        public TB_UserCatInfo GetByUserCatName(string userCatName)
        {
            var parms = new[] {new SqlParameter("@UserCatName", SqlDbType.NVarChar, 50) {Value = userCatName}};
            TB_UserCatInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_CATNAME, parms);
            while (dr.Read())
            {
                obj = new TB_UserCatInfo
                          {
                              UserCatId = dr.GetInt32(0),
                              UserCatName = dr.GetString(2),
                              UserCatEnable = dr.GetBoolean(3)
                          };
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
