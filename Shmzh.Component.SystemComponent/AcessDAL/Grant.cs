using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// 授权管理。
    /// </summary>
    public class Grant : IGrant
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 添加组记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_GRANT = @"
Insert Into mySystemGrant (Grantor, GrantorName,GrantorDept,Embracer,EmbracerName,EmbracerDept,IsLeaf,CreateTime,InvalidTime,IsValid,EffectTime,LoginIsValid,Reason) 
Values (@Grantor,@GrantorName,@GrantorDept,@Embracer,@EmbracerName,@EmbracerDept,@IsLeaf,@CreateTime,@InvalidTime,@IsValid,@EffectTime,@LoginIsValid,@Reason) 
Set @Id = SCOPE_IDENTITY()";
        /// <summary>
        /// 修改组记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_GRANT = @"
Update mySystemGrant Set Grantor = @Grantor
,   GrantorName = @GrantorName
,   GrantorDept = @GrantorDept
,   Embracer = @Embracer
,   EmbracerName = @EmbracerName
,   EmbracerDept = @EmbracerDept
,   IsLeaf = @IsLeaf
,   CreateTime = @CreateTime
,   InvalidTime = @InvalidTime
,   IsValid = @IsValid
,   EffectTime = @EffectTime
,   LoginIsValid = @LoginIsValid
,   Reason = @Reason
Where PKID = @Id";
        /// <summary>
        /// 删除组记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_GRANT = @"Delete From mySystemGrant Where PKID = @Id";
        /// <summary>
        /// 获取所有组记录。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_GRANTOR = @"
SELECT PKID,Grantor,GrantorName,GrantorDept,Embracer,EmbracerName,EmbracerDept,IsLeaf,CreateTime,InvalidTime,IsValid,EffectTime,LoginIsValid,Reason  
From mySystemGrant 
Where Grantor = @Grantor And 
IsValid = 1";
        /// <summary>
        /// 根据组名称获取组记录。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_EMBRACER = @"
SELECT PKID,Grantor,GrantorName,GrantorDept,Embracer,EmbracerName,EmbracerDept,IsLeaf,CreateTime,InvalidTime,IsValid,EffectTime,LoginIsValid,Reason  
FROM mySystemGrant 
WHERE Embracer = @Embracer And 
IsValid = 1 
UNION
SELECT PKID,Grantor,GrantorName,GrantorDept,Embracer,EmbracerName,EmbracerDept,IsLeaf,CreateTime,InvalidTime,IsValid,EffectTime,LoginIsValid,Reason 
FROM dbo.fun_GetAllGrantorsByEmbracer('guzhenguo')
WHERE EffectTime<=getDate()";
        /// <summary>
        /// 根据组编号获取组记录。
        /// </summary>
        private const string SQL_SELECT_BY_ID = @"
SELECT PKID,Grantor,GrantorName,GrantorDept,Embracer,EmbracerName,EmbracerDept,IsLeaf,CreateTime,InvalidTime,IsValid,EffectTime,LoginIsValid,Reason 
From mySystemGrant 
Where PKID = @Id";
        
        #endregion

        #region Private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetGrantParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_GRANT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.BigInt){Direction = ParameterDirection.InputOutput},
                                new OleDbParameter("@Grantor", OleDbType.VarChar,20), 
                                new OleDbParameter("@GrantorName", OleDbType.VarChar,20),
                                new OleDbParameter("@GrantorDept", OleDbType.VarChar,20),
                                new OleDbParameter("@Embracer", OleDbType.VarChar,20),
                                new OleDbParameter("@EmbracerName", OleDbType.VarChar, 20),
                                new OleDbParameter("@EmbracerDept", OleDbType.VarChar,20),
                                new OleDbParameter("@IsLeaf", OleDbType.Boolean),
                                new OleDbParameter("@CreateTime", OleDbType.Date),
                                new OleDbParameter("@InvalidTime", OleDbType.Date),
                                new OleDbParameter("@IsValid", OleDbType.Boolean),
                                new OleDbParameter("@EffectTime",OleDbType.Date),
                                new OleDbParameter("@LoginIsValid", OleDbType.Boolean),
                                new OleDbParameter("@Reason", OleDbType.VarChar, 255), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_GRANT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GrantInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>授权记录实体。</returns>
        private GrantInfo ConvertToGrantInfo(IDataRecord dr)
        {
            var obj = new GrantInfo
                          {
                              ID = dr.GetInt64(0),
                              Grantor = dr.GetString(1),
                              GrantorName = dr["GrantorName"] == DBNull.Value ? string.Empty : dr["GrantorName"].ToString(),
                              GrantorDept = dr["GrantorDept"] == DBNull.Value ? string.Empty : dr["GrantorDept"].ToString(),
                              Embracer = dr.GetString(4),
                              EmbracerName = dr["EmbracerName"] == DBNull.Value ? string.Empty : dr["EmbracerName"].ToString(),
                              EmbracerDept = dr["EmbracerDept"] == DBNull.Value ? string.Empty : dr["EmbracerDept"].ToString(),
                              IsLeaf = dr.GetBoolean(7),
                              CreateTime = dr.GetDateTime(8),
                              InvalidTime = dr["InvalidTime"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["InvalidTime"].ToString()),
                              IsValid = dr.GetBoolean(10),
                              EffectTime = dr.GetDateTime(11),
                              LoginIsValid = dr.GetBoolean(12),
                              Reason = dr["Reason"] == DBNull.Value ? string.Empty : dr["Reason"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IGrant 成员
        /// <summary>
        /// 添加授权记录。
        /// </summary>
        /// <param name="grantInfo">授权记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GrantInfo grantInfo)
        {
            var parms = GetGrantParameters();
            parms[0].Value = 0;
            parms[1].Value = grantInfo.Grantor;
            parms[2].Value = string.IsNullOrEmpty(grantInfo.GrantorName)?(object)DBNull.Value:grantInfo.GrantorName;
            parms[3].Value = string.IsNullOrEmpty(grantInfo.GrantorDept) ? (object)DBNull.Value : grantInfo.GrantorDept;
            parms[4].Value = grantInfo.Embracer;
            parms[5].Value = string.IsNullOrEmpty(grantInfo.EmbracerName) ? (object)DBNull.Value : grantInfo.EmbracerName;
            parms[6].Value = string.IsNullOrEmpty(grantInfo.EmbracerDept) ? (object)DBNull.Value : grantInfo.EmbracerDept;
            parms[7].Value = grantInfo.IsLeaf;
            parms[8].Value = grantInfo.CreateTime;
            parms[9].Value = grantInfo.InvalidTime == DateTime.MinValue ? (object) DBNull.Value : grantInfo.InvalidTime;
            parms[10].Value = grantInfo.IsValid;
            parms[11].Value = grantInfo.EffectTime;
            parms[12].Value = grantInfo.LoginIsValid;
            parms[13].Value = string.IsNullOrEmpty(grantInfo.Reason) ? (object) DBNull.Value : grantInfo.Reason;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_INSERT_GRANT, parms);
                grantInfo.ID = (long)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 修改授权记录实体。
        /// </summary>
        /// <param name="grantInfo">授权记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(GrantInfo grantInfo)
        {
            var parms = GetGrantParameters();
            parms[0].Value = grantInfo.ID;
            parms[1].Value = grantInfo.Grantor;
            parms[2].Value = string.IsNullOrEmpty(grantInfo.GrantorName) ? (object)DBNull.Value : grantInfo.GrantorName;
            parms[3].Value = string.IsNullOrEmpty(grantInfo.GrantorDept) ? (object)DBNull.Value : grantInfo.GrantorDept;
            parms[4].Value = grantInfo.Embracer;
            parms[5].Value = string.IsNullOrEmpty(grantInfo.EmbracerName) ? (object)DBNull.Value : grantInfo.EmbracerName;
            parms[6].Value = string.IsNullOrEmpty(grantInfo.EmbracerDept) ? (object)DBNull.Value : grantInfo.EmbracerDept;
            parms[7].Value = grantInfo.IsLeaf;
            parms[8].Value = grantInfo.CreateTime;
            parms[9].Value = grantInfo.InvalidTime == DateTime.MinValue ? (object)DBNull.Value : grantInfo.InvalidTime;
            parms[10].Value = grantInfo.IsValid;
            parms[11].Value = grantInfo.EffectTime;
            parms[12].Value = grantInfo.LoginIsValid;
            parms[13].Value = string.IsNullOrEmpty(grantInfo.Reason) ? (object)DBNull.Value : grantInfo.Reason;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_UPDATE_GRANT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除授权记录实体。
        /// </summary>
        /// <param name="grantInfo">授权记录实体。</param>
        /// <returns>bool</returns>
        public bool Delete(GrantInfo grantInfo)
        {
            var parms = GetGrantParameters();
            parms[0].Value = grantInfo.ID;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_DELETE_GRANT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除授权记录实体。
        /// </summary>
        /// <param name="id">授权记录id。</param>
        /// <returns>bool</returns>
        public bool Delete(long id)
        {
            var parms = GetGrantParameters();
            parms[0].Value = id;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  SQL_DELETE_GRANT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 根据授权人获取当前有效的授权记录。
        /// </summary>
        /// <param name="grantor">授权人用户名。</param>
        /// <returns>授权记录集合。</returns>
        public IList<GrantInfo> GetAllAvalibleByGrantor(string grantor)
        {
            var parms = GetGrantParameters();
            parms[1].Value = grantor;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, 
                                             SQL_SELECT_ALLAVALIBLE_BY_GRANTOR, parms);
            IList<GrantInfo> objs = new ListBase<GrantInfo>();
            while(dr.Read())
            {
                objs.Add(ConvertToGrantInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据被授权人获取当前的有效的授权记录。
        /// </summary>
        /// <param name="embracer">被授权人用户名。</param>
        /// <returns>授权记录集合。</returns>
        public IList<GrantInfo> GetAllAvalibleByEmbracer(string embracer)
        {
            var parms = GetGrantParameters();
            parms[4].Value = embracer;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, 
                                             SQL_SELECT_ALLAVALIBLE_BY_EMBRACER, parms);
            IList<GrantInfo> objs = new ListBase<GrantInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGrantInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据Id获取授权记录实体。
        /// </summary>
        /// <param name="id">授权记录Id。</param>
        /// <returns>授权记录实体。</returns>
        public GrantInfo GetById(long id)
        {
            var parms = GetGrantParameters();
            parms[0].Value = id;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, 
                                             SQL_SELECT_BY_ID, parms);
            GrantInfo obj = null;
            while (dr.Read())
            {
                obj = ConvertToGrantInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
