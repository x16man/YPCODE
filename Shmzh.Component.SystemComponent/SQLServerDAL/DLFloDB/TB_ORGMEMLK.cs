using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 工作流中组织机构与人员的关系的SQL Serveer的数据访问对象。
    /// </summary>
    public class TB_ORGMEMLK :IDAL.ITB_ORGMEMLK
    {
        #region Field

        private const string FloDBName = "FloDBName";
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string SQL_INSERT = string.Format("Insert Into {0}.[dbo].[TB_ORGMEMLNK] (ORGID,USERID) Values (@OrgId,@UserId) Set @LnkId = SCOPE_IDENTITY()",ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_UPDATE = string.Format("Update {0}.[dbo].[TB_ORGMEMLNK] Set OrgId=@OrgId,UserId=@UserId Where LnkId = @LnkId",ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_DELETE = string.Format("Delete From {0}.[dbo].[TB_ORGMEMLNK] Where LnkId = @LnkId",ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_BY_LNKID = string.Format("Select * From {0}.[dbo].[TB_ORGMEMLNK] Where LnkId = @LnkId",ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_BY_ORGID_USERID = string.Format("Select * From {0}.[dbo].[TB_ORGMEMLNK] Where OrgId = @OrgId And UserId = @UserId",ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_BY_USERID = string.Format("Select * From {0}.[dbo].[TB_ORGMEMLNK] Where UserId = @UserId", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_ALL = string.Format("Select * From {0}.[dbo].[TB_ORGMEMLNK]", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_ALLAVALIBLE = string.Format("Select * From {0}.[dbo].[TB_ORGMEMLNK]", ConfigurationManager.AppSettings[FloDBName]);
        #endregion


        #region Implementation of ITB_ORGMEMLK


        /// <summary>
        /// 添加东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        public bool Insert(TB_ORGMEMLKInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@LnkId", SqlDbType.Int){Value = obj.LnkId},
                                new SqlParameter("@OrgId", SqlDbType.Int) {Value = obj.OrgId}, 
                                new SqlParameter("@UserId", SqlDbType.Int) {Value = obj.UserId}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT, parms);
                obj.LnkId = (int) parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message,ex);
                return false;
            }
        }

        /// <summary>
        /// 修改东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        public bool Update(TB_ORGMEMLKInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@LnkId", SqlDbType.Int){Value = obj.LnkId},
                                new SqlParameter("@OrgId", SqlDbType.Int) {Value = obj.OrgId}, 
                                new SqlParameter("@UserId", SqlDbType.Int) {Value = obj.UserId}
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
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        public bool Delete(TB_ORGMEMLKInfo obj, DbTransaction trans)
        {
            return Delete(obj.LnkId, trans);
        }

        /// <summary>
        /// 删除东兰工作流部门信息。
        /// </summary>
        /// <param name="lnkId">部门key。</param>
        /// <param name="trans">事务对象。</param>
        public bool Delete(int lnkId, DbTransaction trans)
        {
            var parms = new[] {new SqlParameter("@LnkId", SqlDbType.Int) {Value = lnkId}};
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction) trans, CommandType.Text, SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 获取所有记录。
        /// </summary>
        /// <returns></returns>
        public IList<TB_ORGMEMLKInfo> GetALL()
        {
            var objs = new ListBase<TB_ORGMEMLKInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(new TB_ORGMEMLKInfo {LnkId = dr.GetInt32(0), OrgId = dr.GetInt32(1), UserId = dr.GetInt32(2)});
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效记录。
        /// </summary>
        /// <returns></returns>
        public IList<TB_ORGMEMLKInfo> GetAllAvalible()
        {
            var objs = new ListBase<TB_ORGMEMLKInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(new TB_ORGMEMLKInfo { LnkId = dr.GetInt32(0), OrgId = dr.GetInt32(1), UserId = dr.GetInt32(2) });
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据名称获取组织机构。
        /// </summary>
        /// <param name="lnkId">名称。</param>
        /// <returns>组织机构。</returns>
        public TB_ORGMEMLKInfo GetByLnkId(int lnkId)
        {
            var parms = new[] {new SqlParameter("@LnkId", SqlDbType.Int) {Value = lnkId}};
            TB_ORGMEMLKInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_LNKID, parms);
            while (dr.Read())
            {
                obj = new TB_ORGMEMLKInfo {LnkId = dr.GetInt32(0), OrgId = dr.GetInt32(1), UserId = dr.GetInt32(2)};
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据组织机构Id和用户Id获取记录。
        /// </summary>
        /// <param name="orgId">组织机构Id。</param>
        /// <param name="userId">用户Id。</param>
        /// <returns>组织机构与用户关系实体。</returns>
        public TB_ORGMEMLKInfo GetByOrgIdAndUserId(int orgId, int userId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@OrgId", SqlDbType.Int) {Value = orgId}, 
                                new SqlParameter("@UserId", SqlDbType.Int) {Value = userId},
                            };
            TB_ORGMEMLKInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_ORGID_USERID, parms);
            while (dr.Read())
            {
                obj = new TB_ORGMEMLKInfo { LnkId = dr.GetInt32(0), OrgId = dr.GetInt32(1), UserId = dr.GetInt32(2) };
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据用户Id获取记录。
        /// </summary>
        /// <param name="userId">用户Id。</param>
        /// <returns>组织机构与用户关系实体。</returns>
        public TB_ORGMEMLKInfo GetByUserId(int userId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@UserId", SqlDbType.Int) {Value = userId},
                            };
            TB_ORGMEMLKInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_BY_USERID, parms);
            while (dr.Read())
            {
                obj = new TB_ORGMEMLKInfo { LnkId = dr.GetInt32(0), OrgId = dr.GetInt32(1), UserId = dr.GetInt32(2) };
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
