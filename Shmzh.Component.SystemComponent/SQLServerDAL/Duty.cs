using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 职位的SQLServer的数据访问对象。
    /// </summary>
    public class Duty :IDuty
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT_DUTY =
            "Insert Into mySystemDuty (DutyCo,DutyCode,ParentDutyCode,DutyCnName,DutyEnName,IsValid,DutyLevel,Remark) Values (@DutyCo,@DutyCode,@ParentDutyCode,@DutyCnName,@DutyEnName,@IsValid,@DutyLevel,@Remark)";

        private const string SQL_UPDATE_DUTY =
            "Update mySystemDuty Set ParentDutyCode = @ParentDutyCode, DutyCnName=@DutyCnName,  DutyEnName=@DutyEnName, IsValid = @IsValid, DutyLevel = @DutyLevel, Remark = @Remark Where DutyCo = @DutyCo And DutyCode = @DutyCode";

        private const string SQL_DELETE_DUTY =
            "Delete From mySystemDuty Where DutyCo = @DutyCo And DutyCode = @DutyCode";

        private const string SQL_SELECT_COUNT_BY_DUTYCODE =
            "Select Count(*) From mySystemDuty Where DutyCo = @DutyCo And DutyCode = @DutyCode";

        private const string SQL_SELECT_COUNT_BY_DUTYNAME =
            "Select Count(*) From mySystemDuty Where DutyCo = @DutyCo And DutyCnName = @DutyCnName";

        private const string SQL_SELECT_ALL_BY_COMPANY =
            "Select * From mySystemDuty Where DutyCo = @DutyCo";

        private const string SQL_SELECT_ALLAVALIBLE_BY_COMPANY =
            "Select * From mySystemDuty Where DutyCo = @DutyCo And IsValid = 'Y'";

        private const string SQL_SELECT_BY_COMPANY_DUTYCODE =
            "Select * From mySystemDuty Where DutyCo = @DutyCo And DutyCode = @DutyCode";
        #endregion

        #region private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetDutyParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_DUTY);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@DutyCo", SqlDbType.NVarChar,20),
                                new SqlParameter("@DutyCode", SqlDbType.NVarChar,20), 
                                new SqlParameter("@ParentDutyCode", SqlDbType.NVarChar,20),
                                new SqlParameter("@DutyCnName", SqlDbType.NVarChar,50),
                                new SqlParameter("@DutyEnName", SqlDbType.NVarChar,50),
                                new SqlParameter("@IsValid", SqlDbType.NChar,1), 
                                new SqlParameter("@DutyLevel", SqlDbType.SmallInt),
                                new SqlParameter("@Remark", SqlDbType.NVarChar,50), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_DUTY, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成DutyInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体。</returns>
        private DutyInfo ConvertToDutyInfo(IDataRecord dr)
        {
            var obj = new DutyInfo
            {
                DutyCo = dr.GetString(0),
                DutyCode = dr.GetString(1),
                ParentDutyCode = dr["ParentDutyCode"]==DBNull.Value?string.Empty:dr["ParentDutyCode"].ToString(),
                DutyCnName = dr.GetString(3),
                DutyEnName = dr["DutyEnName"] == DBNull.Value?string.Empty:dr["DutyEnName"].ToString(),
                IsValid = dr.GetString(5),
                DutyLevel = dr["DutyLevel"]==DBNull.Value? (short)0:short.Parse(dr["DutyLevel"].ToString()),
                Remark = dr["Remark"] == DBNull.Value?string.Empty:dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IDuty 成员

        /// <summary>
        /// 添加职务。
        /// </summary>
        /// <param name="dutyInfo">职务实体。</param>
        /// <returns>bool</returns>
        public bool Insert(DutyInfo dutyInfo)
        {
            var parms = GetDutyParameters();
            parms[0].Value = dutyInfo.DutyCo;
            parms[1].Value = dutyInfo.DutyCode;
            parms[2].Value = dutyInfo.ParentDutyCode;
            parms[3].Value = dutyInfo.DutyCnName;
            parms[4].Value = dutyInfo.DutyEnName;
            parms[5].Value = dutyInfo.IsValid;
            parms[6].Value = dutyInfo.DutyLevel;
            parms[7].Value = dutyInfo.Remark;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_DUTY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改职务。
        /// </summary>
        /// <param name="dutyInfo">职务实体。</param>
        /// <returns>bool</returns>
        public bool Update(DutyInfo dutyInfo)
        {
            var parms = GetDutyParameters();
            parms[0].Value = dutyInfo.DutyCo;
            parms[1].Value = dutyInfo.DutyCode;
            parms[2].Value = dutyInfo.ParentDutyCode;
            parms[3].Value = dutyInfo.DutyCnName;
            parms[4].Value = dutyInfo.DutyEnName;
            parms[5].Value = dutyInfo.IsValid;
            parms[6].Value = dutyInfo.DutyLevel;
            parms[7].Value = dutyInfo.Remark;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_DUTY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除职务。
        /// </summary>
        /// <param name="dutyInfo">职务实体。</param>
        /// <returns>bool</returns>
        public bool Delete(DutyInfo dutyInfo)
        {
            var parms = GetDutyParameters();
            parms[0].Value = dutyInfo.DutyCo;
            parms[1].Value = dutyInfo.DutyCode;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_DUTY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除职务。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="dutyCode">职务编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string companyCode, string dutyCode)
        {
            var parms = GetDutyParameters();
            parms[0].Value = companyCode;
            parms[1].Value = dutyCode;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_DUTY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 是否已经存在职务编号。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="dutyCode">职务编号。</param>
        /// <returns>bool</returns>
        public bool IsExistDutyCode(string companyCode, string dutyCode)
        {
            var parms = GetDutyParameters();
            parms[0].Value = companyCode;
            parms[1].Value = dutyCode;
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_DUTYCODE,
                                              parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 是否已经存在职务名称
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="dutyName">职务名称。</param>
        /// <returns>bool</returns>
        public bool IsExistDutyName(string companyCode, string dutyName)
        {
            var parms = GetDutyParameters();
            parms[0].Value = companyCode;
            parms[1].Value = dutyName;
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_DUTYNAME,
                                              parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 获取所有职务。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>ArrayList。</returns>
        public IList<DutyInfo> GetAllByCompanyCode(string companyCode)
        {
            var parms = GetDutyParameters();
            parms[0].Value = companyCode;
            var objs = new ListBase<DutyInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL_BY_COMPANY,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToDutyInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的职务。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>职务集合。</returns>
        public IList<DutyInfo> GetAllAvalibleByCompanyCode(string companyCode)
        {
            var parms = GetDutyParameters();
            parms[0].Value = companyCode;
            var objs = new ListBase<DutyInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE_BY_COMPANY,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToDutyInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据职务编号获取职务。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="dutyCode">职务编号。</param>
        /// <returns>职务实体。</returns>
        public DutyInfo GetByCompanyCodeAndDutyCode(string companyCode, string dutyCode)
        {
            var parms = GetDutyParameters();
            parms[0].Value = companyCode;
            parms[1].Value = dutyCode;
            DutyInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_COMPANY_DUTYCODE,
                                             parms);
            while (dr.Read())
            {
                obj = ConvertToDutyInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
