using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// 公司信息的SQL Server 的数据访问对象。
    /// </summary>
    public class Company : ICompany
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT_COMPANY = @"
Insert Into mySystemCompanyInfo ([CoCode],[CoCnName],[CoEnName],[CoShortName],[ParentCo],[ParentCoName],[ArtificialPerson],[Mgr],[BussinessLicense],BussinessRange,CoArea,CoAddress,IsValid,Remark,IsDefault)
Values (@CoCode,@CoCnName,@CoEnName,@CoShortName,@ParentCo,@ParentCoName,@ArtificialPerson,@Mgr,@BussinessLicense,@BussinessRange,@CoArea,@CoAddress,@IsValid,@Remark,@IsDefault)";
        private const string SQL_UPDATE_COMPANY = @"
Update mySystemCompanyInfo Set CoCnName = @CoCnName
,   CoEnName = @CoEnName
,   CoShortName = @CoShortName
,   ParentCo = @ParentCo
,   ParentCoName = @ParentCoName
,   ArtificialPerson = @ArtificialPerson
,   Mgr = @Mgr
,   BussinessLicense = @BussinessLicense
,   BussinessRange = @BussinessRange
,   CoArea = @CoArea
,   CoAddress = @CoAddress
,   IsValid = @IsValid
,   Remark = @Remark
,   IsDefault = @IsDefault
Where   CoCode = @CoCode";
        private const string SQL_DELETE_COMPANY = "Delete From mySystemCompanyInfo Where CoCode = @CoCode";
        private const string SQL_SELECT_ALL = "Select * From mySystemCompanyInfo";
        private const string SQL_SELECT_ALLAVALIBLE = "Select * From mySystemCompanyInfo Where IsValid = 'Y'";
        private const string SQL_SELECT_DEFAULT = "Select * From mySystemCompanyInfo Where IsDefault = 'Y'";
        private const string SQL_SELECT_BY_CODE = "Select * From mySystemCompanyInfo Where CoCode = @CoCode";
        private const string SQL_SELECT_COUNT_BY_CODE = "Select Count(*) From mySystemCompanyInfo Where CoCode = @CoCode";
        private const string SQL_SELECT_COUNT_BY_NAME = "Select Count(*) From mySystemCompanyInfo Where CoCnName = @CoCnName";

        #endregion

        #region ICompany 成员

        /// <summary>
        /// 添加公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Insert(CompanyInfo companyInfo)
        {
            var parms = GetCompanyParameters();
            parms[0].Value = companyInfo.CoCode;
            parms[1].Value = companyInfo.CoName;
            parms[2].Value = string.IsNullOrEmpty(companyInfo.CoEnName) ? (object) DBNull.Value : companyInfo.CoEnName;
            parms[3].Value = string.IsNullOrEmpty(companyInfo.CoShortName)
                                 ? (object) DBNull.Value
                                 : companyInfo.CoShortName;
            parms[4].Value = string.IsNullOrEmpty(companyInfo.ParentCo) ? (object) DBNull.Value : companyInfo.ParentCo;
            parms[5].Value = string.IsNullOrEmpty(companyInfo.ParentCoName)
                                 ? (object) DBNull.Value
                                 : companyInfo.ParentCoName;
            parms[6].Value = string.IsNullOrEmpty(companyInfo.ArtificialPerson)
                                 ? (object) DBNull.Value
                                 : companyInfo.ArtificialPerson;
            parms[7].Value = string.IsNullOrEmpty(companyInfo.Mgr) ? (object) DBNull.Value : companyInfo.Mgr;
            parms[8].Value = string.IsNullOrEmpty(companyInfo.BussinessLicense)
                                 ? (object) DBNull.Value
                                 : companyInfo.BussinessLicense;
            parms[9].Value = string.IsNullOrEmpty(companyInfo.BussinessRange)
                                 ? (object) DBNull.Value
                                 : companyInfo.BussinessRange;
            parms[10].Value = string.IsNullOrEmpty(companyInfo.CoArea) ? (object) DBNull.Value : companyInfo.CoArea;
            parms[11].Value = string.IsNullOrEmpty(companyInfo.CoAddress)
                                  ? (object) DBNull.Value
                                  : companyInfo.CoAddress;
            parms[12].Value = companyInfo.IsValid;
            parms[13].Value = companyInfo.Remark;
            parms[14].Value = companyInfo.IsDefault;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_INSERT_COMPANY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 修改公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Update(CompanyInfo companyInfo)
        {
            //var parms = GetCompanyParameters();
            //parms[0].Value = companyInfo.CoCode;
            //parms[1].Value = companyInfo.CoName;
            //parms[2].Value = string.IsNullOrEmpty(companyInfo.CoEnName) ? (object)DBNull.Value : companyInfo.CoEnName;
            //parms[3].Value = string.IsNullOrEmpty(companyInfo.CoShortName)
            //                     ? (object)DBNull.Value
            //                     : companyInfo.CoShortName;
            //parms[4].Value = string.IsNullOrEmpty(companyInfo.ParentCo) ? (object)DBNull.Value : companyInfo.ParentCo;
            //parms[5].Value = string.IsNullOrEmpty(companyInfo.ParentCoName)? (object)DBNull.Value: companyInfo.ParentCoName;
            //parms[6].Value = string.IsNullOrEmpty(companyInfo.ArtificialPerson)? (object)DBNull.Value: companyInfo.ArtificialPerson;
            //parms[7].Value = string.IsNullOrEmpty(companyInfo.Mgr) ? (object)DBNull.Value : companyInfo.Mgr;
            //parms[8].Value = string.IsNullOrEmpty(companyInfo.BussinessLicense)? (object)DBNull.Value: companyInfo.BussinessLicense;
            //parms[9].Value = string.IsNullOrEmpty(companyInfo.BussinessRange)? (object)DBNull.Value: companyInfo.BussinessRange;
            //parms[10].Value = string.IsNullOrEmpty(companyInfo.CoArea) ? (object)DBNull.Value : companyInfo.CoArea;
            //parms[11].Value = string.IsNullOrEmpty(companyInfo.CoAddress)? (object)DBNull.Value: companyInfo.CoAddress;
            //parms[12].Value = companyInfo.IsValid;
            //parms[13].Value = companyInfo.Remark;
            //parms[14].Value = companyInfo.IsDefault;

            var parms = new[]
                             {
                                 new OleDbParameter("@CoCnName",OleDbType.VarChar,50){Value = companyInfo.CoName},
                                 new OleDbParameter("@CoEnName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.CoEnName) ? (object)DBNull.Value : companyInfo.CoEnName},
                                 new OleDbParameter("@CoShortName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.CoShortName)? (object)DBNull.Value: companyInfo.CoShortName},
                                 new OleDbParameter("@ParentCo",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.ParentCo) ? (object)DBNull.Value : companyInfo.ParentCo},
                                 new OleDbParameter("@ParentCoName", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.ParentCoName)? (object)DBNull.Value: companyInfo.ParentCoName},
                                 new OleDbParameter("@ArtificialPerson", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.ArtificialPerson)? (object)DBNull.Value: companyInfo.ArtificialPerson},
                                 new OleDbParameter("@Mgr", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.Mgr) ? (object)DBNull.Value : companyInfo.Mgr},
                                 new OleDbParameter("@BussinessLicense", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.BussinessLicense)? (object)DBNull.Value: companyInfo.BussinessLicense},
                                 new OleDbParameter("@BussinessRange",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.BussinessRange)? (object)DBNull.Value: companyInfo.BussinessRange},
                                 new OleDbParameter("@CoArea",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.CoArea) ? (object)DBNull.Value : companyInfo.CoArea},
                                 new OleDbParameter("@CoAddress",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.CoAddress)? (object)DBNull.Value: companyInfo.CoAddress},
                                 new OleDbParameter("@IsValid",OleDbType.Char, 1){Value = companyInfo.IsValid},
                                 new OleDbParameter("@Remark",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(companyInfo.Remark)?(object)DBNull.Value:companyInfo.Remark},
                                 new OleDbParameter("@IsDefault",OleDbType.Char,1){Value = companyInfo.IsDefault},
                                 new OleDbParameter("@CoCode", OleDbType.VarChar,20){Value = companyInfo.CoCode},
        };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_UPDATE_COMPANY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="companyInfo">公司实体。</param>
        /// <returns>bool</returns>
        public bool Delete(CompanyInfo companyInfo)
        {
            var parms = GetCompanyParameters();
            parms[0].Value = companyInfo.CoCode;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_COMPANY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除公司。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string coCode)
        {
            var parms = GetCompanyParameters();
            parms[0].Value = coCode;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_COMPANY, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 判断公司编号是否已经存在。
        /// </summary>
        /// <param name="coCode">公司编号。</param>
        /// <returns>bool</returns>
        public bool IsExistCode(string coCode)
        {
            var parms = GetCompanyParameters();
            parms[0].Value = coCode;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_SELECT_COUNT_BY_CODE, parms);
                return true;
            }
            catch (Exception ex)
            { 
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 是否已经存在组名称。
        /// </summary>
        /// <param name="coCnName">公司名称。</param>
        /// <returns>bool</returns>
        public bool IsExistName(string coCnName)
        {
            var parms = GetCompanyParameters();
            parms[1].Value = coCnName;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_SELECT_COUNT_BY_NAME, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取所有公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        public ListBase<CompanyInfo> GetAll()
        {
            //var objs = new List<CompanyInfo>();
            var objs = new ListBase<CompanyInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL);
            while(dr.Read())
            {
                objs.Add(ConvertToCompanyInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的公司。
        /// </summary>
        /// <returns>公司集合。</returns>
        public ListBase<CompanyInfo> GetAllAvalible()
        {
            //var objs = new List<CompanyInfo>();
            var objs = new ListBase<CompanyInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(ConvertToCompanyInfo(dr));
            }
            dr.Close();
            return objs;    
        }

        /// <summary>
        /// 根据公司编号获取公司。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>公司实体。</returns>
        public CompanyInfo GetByCode(string companyCode)
        {
            var parms = GetCompanyParameters();
            parms[0].Value = companyCode;

            CompanyInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_BY_CODE, parms);
            while(dr.Read())
            {
                obj = ConvertToCompanyInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 获取默认的公司。
        /// </summary>
        /// <returns>公司信息。</returns>
        public CompanyInfo GetDefault()
        {
            CompanyInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_DEFAULT);
            while (dr.Read())
            {
                obj = ConvertToCompanyInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

        #region private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetCompanyParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_COMPANY);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@CoCode", OleDbType.VarChar,20),
                                new OleDbParameter("@CoCnName", OleDbType.VarChar,50), 
                                new OleDbParameter("@CoEnName", OleDbType.VarChar,50), 
                                new OleDbParameter("@CoShortName", OleDbType.VarChar,50),
                                new OleDbParameter("@ParentCo", OleDbType.VarChar,20),
                                new OleDbParameter("@ParentCoName", OleDbType.VarChar, 50),
                                new OleDbParameter("@ArtificialPerson", OleDbType.VarChar, 50),
                                new OleDbParameter("@Mgr", OleDbType.VarChar, 50),
                                new OleDbParameter("@BussinessLicense",OleDbType.VarChar, 50),
                                new OleDbParameter("@BussinessRange", OleDbType.VarChar, 50),
                                new OleDbParameter("@CoArea", OleDbType.VarChar,50),
                                new OleDbParameter("@CoAddress",OleDbType.VarChar,50), 
                                new OleDbParameter("@IsValid", OleDbType.Char,1),
                                new OleDbParameter("@Remark",OleDbType.VarChar,50),
                                new OleDbParameter("@IsDefault", OleDbType.Char,1), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_COMPANY, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private CompanyInfo ConvertToCompanyInfo(IDataRecord dr)
        {
            var obj = new CompanyInfo()
              {
                  CoCode = dr.GetString(0),
                  CoName = dr.GetString(1),
                  CoEnName = dr["CoEnName"] == DBNull.Value ? string.Empty : dr["CoEnName"].ToString(),
                  CoShortName = dr["CoShortName"] == DBNull.Value?string.Empty: dr["CoShortName"].ToString(),
                  ParentCo = dr["ParentCo"] == DBNull.Value?string.Empty:dr["ParentCo"].ToString(),
                  ParentCoName = dr["ParentCoName"] == DBNull.Value?string.Empty:dr["ParentCoName"].ToString(),
                  ArtificialPerson = dr["ArtificialPerson"] == DBNull.Value?string.Empty:dr["ArtificialPerson"].ToString(),
                  Mgr = dr["Mgr"] == DBNull.Value?string.Empty:dr["Mgr"].ToString(),
                  BussinessLicense = dr["BussinessLicense"] == DBNull.Value?string.Empty:dr["BussinessLicense"].ToString(),
                  BussinessRange = dr["BussinessRange"] == DBNull.Value? string.Empty:dr["BussinessRange"].ToString(),
                  CoArea = dr["CoArea"] == DBNull.Value?string.Empty:dr["CoArea"].ToString(),
                  CoAddress = dr["CoAddress"] == DBNull.Value?string.Empty:dr["CoAddress"].ToString(),
                  IsValid = dr["IsValid"].ToString(),
                  IsDefault = dr["IsDefault"].ToString(),
                  Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion
    }
}
