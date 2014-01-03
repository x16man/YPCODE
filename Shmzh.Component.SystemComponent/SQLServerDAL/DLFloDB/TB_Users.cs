using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 东兰数据库用户的数据访问类。
    /// </summary>
    public class TB_Users : IDAL.ITB_Users
    {
        #region 字段

        private const string FloDBName = "FloDBName";
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string SQL_INSERT = string.Format(@"
INSERT INTO  {0}.dbo.[TB_USERS] (HRID
,   UserName
,   Domain
,   PWD
,   UserDspName
,   EMAIL
,   Tel
,   Dept
,   JobTitle
,   SpHRID
,   JoinDate
,   CostCenter
,   LocationCode
,   Enable
,   IsOut
,   AgentUserID
,   Language
,   MbTel
,   CanAssignOut
,   IsLeave
,   LeaveDate
,   UserCatID
)
VALUES (@HRID
,   @UserName
,   @Domain
,   @PWD
,   @UserDspName
,   @EMail
,   @Tel
,   @Dept
,   @JobTitle
,   @SpHRID
,   @JoinDate
,   @CostCenter
,   @LocationCode
,   @Enable
,   @IsOut
,   @AgentUserId
,   @Language
,   @MbTel
,   @CanAssignOut
,   @IsLeave
,   @LeaveDate
,   @UserCatId
)
Set @UserId = SCOPE_IDENTITY()
",ConfigurationManager.AppSettings[FloDBName]);
        
        private static readonly string SQL_UPDATE = string.Format(@"
UPDATE  {0}.dbo.[TB_USERS]
SET     [HrId] = @HrId
,       [UserName] = @UserName
,       [Domain] = @Domain
,       [PWD] = @PWD
,       [UserDspName] =@UserDspName
,       [EMAIL] = @EMail
,       [Tel] = @Tel
,       [Dept] = @Dept 
,       [JobTitle] = @JobTitle
,       [SpHrId] =@SpHrId 
,       [JoinDate] = @JoinDate
,       [CostCenter] = @CostCenter
,       [LocationCode] = @LocationCode
,       [Enable] = @Enable
,       [IsOut] = @IsOut
,       [AgentUserId] = @AgentUserId
,       [Language] = @Language
,       [MbTel] = @MbTel
,       [CanAssignOut] = @CanAssignOut
,       [IsLeave] = @IsLeave
,       [LeaveDate] = @LeaveDate
,       [UserCatId] = @UserCatId
WHERE   [UserId] =@UserId
",ConfigurationManager.AppSettings[FloDBName]);
        
        private static readonly string SQL_SELECT_BY_USERNAME = string.Format("SELECT * FROM {0}.[dbo].[TB_USERS] WHERE [UserName] = @UserName",ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_BY_HRID = string.Format("SELECT * FROM {0}.[dbo].[TB_USERS] WHERE [HRID] = @HRID", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_SELECT_BY_USERID = string.Format("Select * From {0}.[dbo].[TB_USERS] Where [UserId]=@UserId", ConfigurationManager.AppSettings[FloDBName]);
        private static readonly string SQL_DELETE = string.Format(@"
DELETE {0}.dbo.[TB_USERS] WHERE userid = @userid",ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_BY_ORGID = string.Format(@"Select * From {0}.[dbo].[TB_USERS] Where [UserId] In (Select UserId From {0}.[dbo].[TB_ORGMEMLNK] Where ORGID=@OrgId)",
                                                                  ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_ALL = string.Format(@"Select * From {0}.[dbo].[TB_USERS]", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_ALLAVALIBLE = string.Format(@"Select * From {0}.[dbo].[TB_USERS] Where Enable  = 1", ConfigurationManager.AppSettings[FloDBName]);

        private static readonly string SQL_SELECT_ALLBUDGETMANAGER =
            string.Format(
                @"Select A.* From {0}.[dbo].[TB_USERS] A,{0}.[dbo].[ViewBudgetManager] B Where A.UserId = B.UserId",
                ConfigurationManager.AppSettings[FloDBName]);

        #endregion

        #region 私有方法
        private static TB_UsersInfo ConvertToTblUserInfo(IDataRecord dr)
        {
            var obj = new TB_UsersInfo
            {
                UserId = dr.GetInt32(0),
                HRID = dr.GetString(1),
                UserName = dr.GetString(2),
                Domain = dr.GetString(3),
                PWD = dr.GetString(4),
                UserDspName = dr.GetString(5),
                EMail = dr.GetString(6),
                Tel = dr.GetString(7),
                Dept = dr.GetString(8),
                JobTitle = dr.GetString(9),
                SpHRID = dr.GetString(10),
                JoinDate = dr.GetDateTime(11),
                CostCenter = dr.GetString(12),
                LocationCode = dr.GetString(13),
                Enalbe = dr.GetBoolean(14),
                IsOut = dr.GetBoolean(15),
                AgentUserId = dr.GetInt32(16),
                Language = dr.GetString(17),
                MbTel = dr.GetString(18),
                CanAssignOut = dr.GetBoolean(19),
                IsLeave = dr.GetBoolean(20),
                LeaveDate = dr.GetDateTime(21),
                UserCatId = dr.GetInt32(22),
            };

            return obj;
        }
        #endregion 

        #region 接口方法
        /// <summary>
        /// 添加东兰工作流人员信息。
        /// </summary>
        /// <param name="obj">用户。</param>
        /// <param name="trans">事务对象。</param>
        public bool Insert(TB_UsersInfo obj ,DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@UserId", SqlDbType.Int){Value = 0, Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@HrId", SqlDbType.NVarChar, 50) {Value = obj.HRID},
                                new SqlParameter("@UserName", SqlDbType.NVarChar,50){Value = obj.UserName},
                                new SqlParameter("@Domain", SqlDbType.NVarChar,50){Value = obj.Domain},
                                new SqlParameter("@PWD",SqlDbType.NVarChar,32){Value = obj.PWD},
                                new SqlParameter("@UserDspName",SqlDbType.NVarChar,200){Value = obj.UserDspName},
                                new SqlParameter("@EMail",SqlDbType.NVarChar,50){Value = obj.EMail??string.Empty}, 
                                new SqlParameter("@Tel",SqlDbType.NVarChar,50){Value = obj.Tel??string.Empty},
                                new SqlParameter("@Dept", SqlDbType.NVarChar,50){Value = obj.Dept??string.Empty},
                                new SqlParameter("@JobTitle",SqlDbType.NVarChar,50){Value = obj.JobTitle??string.Empty},
                                new SqlParameter("@SpHrId", SqlDbType.NVarChar,50){Value = obj.SpHRID},
                                new SqlParameter("@JoinDate", SqlDbType.DateTime){Value = obj.JoinDate},
                                new SqlParameter("@CostCenter", SqlDbType.NVarChar,50){Value = obj.CostCenter??string.Empty},
                                new SqlParameter("@LocationCode", SqlDbType.NVarChar,50){Value = obj.LocationCode},
                                new SqlParameter("@Enable", SqlDbType.Bit){Value = obj.Enalbe},
                                new SqlParameter("@IsOut",SqlDbType.Bit){Value = obj.IsOut},
                                new SqlParameter("@AgentUserId",SqlDbType.Int){Value = obj.AgentUserId},
                                new SqlParameter("@Language",SqlDbType.NVarChar,50){Value = obj.Language},
                                new SqlParameter("@MbTel",SqlDbType.NVarChar,50){Value = obj.MbTel},
                                new SqlParameter("@CanAssignOut",SqlDbType.Bit){Value = obj.CanAssignOut},
                                new SqlParameter("@IsLeave",SqlDbType.Bit){Value = obj.IsLeave},
                                new SqlParameter("@LeaveDate",SqlDbType.DateTime){Value = obj.LeaveDate},
                                new SqlParameter("@UserCatId", SqlDbType.Int){Value = obj.UserCatId}, 
                            };

            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT, parms);
                obj.UserId = (int)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 修改东兰工作流人员信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans"></param>
        public bool Update(TB_UsersInfo obj, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@UserId", SqlDbType.Int){Value = obj.UserId},
                                new SqlParameter("@HrId", SqlDbType.NVarChar, 50) {Value = obj.HRID},
                                new SqlParameter("@UserName", SqlDbType.NVarChar,50){Value = obj.UserName},
                                new SqlParameter("@Domain", SqlDbType.NVarChar,50){Value = obj.Domain},
                                new SqlParameter("@PWD",SqlDbType.NVarChar,32){Value = obj.PWD},
                                new SqlParameter("@UserDspName",SqlDbType.NVarChar,200){Value = obj.UserDspName},
                                new SqlParameter("@EMail",SqlDbType.NVarChar,50){Value = obj.EMail??string.Empty}, 
                                new SqlParameter("@Tel",SqlDbType.NVarChar,50){Value = obj.Tel??string.Empty},
                                new SqlParameter("@Dept", SqlDbType.NVarChar,50){Value = obj.Dept??string.Empty},
                                new SqlParameter("@JobTitle",SqlDbType.NVarChar,50){Value = obj.JobTitle??string.Empty},
                                new SqlParameter("@SpHrId", SqlDbType.NVarChar,50){Value = obj.SpHRID??string.Empty},
                                new SqlParameter("@JoinDate", SqlDbType.DateTime){Value = obj.JoinDate},
                                new SqlParameter("@CostCenter", SqlDbType.NVarChar,50){Value = obj.CostCenter??string.Empty},
                                new SqlParameter("@LocationCode", SqlDbType.NVarChar,50){Value = obj.LocationCode},
                                new SqlParameter("@Enable", SqlDbType.Bit){Value = obj.Enalbe},
                                new SqlParameter("@IsOut",SqlDbType.Bit){Value = obj.IsOut},
                                new SqlParameter("@AgentUserId",SqlDbType.Int){Value = obj.AgentUserId},
                                new SqlParameter("@Language",SqlDbType.NVarChar,50){Value = obj.Language},
                                new SqlParameter("@MbTel",SqlDbType.NVarChar,50){Value = obj.MbTel??string.Empty},
                                new SqlParameter("@CanAssignOut",SqlDbType.Bit){Value = obj.CanAssignOut},
                                new SqlParameter("@IsLeave",SqlDbType.Bit){Value = obj.IsLeave},
                                new SqlParameter("@LeaveDate",SqlDbType.DateTime){Value = obj.LeaveDate},
                                new SqlParameter("@UserCatId", SqlDbType.Int){Value = obj.UserCatId}, 
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message,ex);
                return false;
            }
        }

        /// <summary>
        /// 删除东兰工作流人员信息。
        /// </summary>
        /// <param name="tbluserInfo">配置信息实体。</param>
        /// <param name="trans"></param>
        public bool Delete(TB_UsersInfo tbluserInfo, DbTransaction trans)
        {
            return Delete(tbluserInfo.UserId, trans);
        }

        /// <summary>
        /// 删除东兰工作流人员信息。
        /// </summary>
        /// <param name="key">人员信息编号。</param>
        /// <param name="trans"></param>
        public bool Delete(int key, DbTransaction trans)
        {
            var parms = new[] { new SqlParameter("@userid", SqlDbType.Int) { Value = key } };
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
        /// 根据用户名获取人员信息。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>用户实体。</returns>
        public TB_UsersInfo GetByUserName(string userName)
        {
            var parms = new[] {new SqlParameter("@UserName", SqlDbType.NVarChar, 50) {Value = userName}};
            TB_UsersInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_USERNAME, parms);
            while (dr.Read())
            {
                obj = ConvertToTblUserInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        public TB_UsersInfo GetByHrId(string hrid)
        {
            var parms = new[] { new SqlParameter("@HRID", SqlDbType.NVarChar, 50) { Value = hrid } };
            TB_UsersInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_HRID, parms);
            while (dr.Read())
            {
                obj = ConvertToTblUserInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据用户Id获取用户实体。
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>用户实体</returns>
        public TB_UsersInfo GetByUserId(int userId)
        {
            var parms = new[] { new SqlParameter("@UserId", SqlDbType.Int) { Value = userId } };
            TB_UsersInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_USERID, parms);
            while (dr.Read())
            {
                obj = ConvertToTblUserInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据组织机构Id获取用户列表。
        /// </summary>
        /// <param name="orgId">组织机构Id。</param>
        /// <returns>用户列表。</returns>
        public IList<TB_UsersInfo> GetByOrgId(int orgId)
        {
            var parms = new[] {new SqlParameter("@OrgId", SqlDbType.Int) {Value = orgId}};
            var objs = new List<TB_UsersInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ORGID, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToTblUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有的用户列表。
        /// </summary>
        /// <returns>所有的用户列表。</returns>
        public IList<TB_UsersInfo> GetAll()
        {
            var objs = new ListBase<TB_UsersInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToTblUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的用户列表。
        /// </summary>
        /// <returns>所有有效的用户列表。</returns>
        public IList<TB_UsersInfo> GetAllAvalible()
        {
            var objs = new ListBase<TB_UsersInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(ConvertToTblUserInfo(dr));
            }
            dr.Close();
            return objs;
        }
        public List<TB_UsersInfo> GetAllBudgetManager()
        {
            var objs = new ListBase<TB_UsersInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLBUDGETMANAGER);
            while (dr.Read())
            {
                objs.Add(ConvertToTblUserInfo(dr));
            }
            dr.Close();
            return objs;
        } 
        #endregion

    }
}
