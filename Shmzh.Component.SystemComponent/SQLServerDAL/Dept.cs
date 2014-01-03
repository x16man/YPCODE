using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 组织机构的SQL Server的数据访问层。
    /// </summary>
    public class Dept :IDAL.IDept
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string SQL_INSERT_DEPT = @"
Insert Into mySystemDept (DeptCode,DeptCo,DeptCnName,DeptEnName,ParentDept,ParentDeptName,DeptMgr,CreateDate,IsValid,DeptLevel,Remark,Serial,TypeId,TypeName,DeptMgrName,CostCenter,ShowInOtherSys) 
Values (@DeptCode,@DeptCo,@DeptCnName,@DeptEnName,@ParentDept,@ParentDeptName,@DeptMgr,@CreateDate,@IsValid,@DeptLevel,@Remark,@Serial,@TypeId,@TypeName,@DeptMgrName,@CostCenter,@ShowInOtherSys)";
        private const string SQL_UPDATE_DEPT = @"
Update mySystemDept Set DeptCnName = @DeptCnName
,   DeptEnName = @DeptEnName
,   ParentDept = @ParentDept
,   ParentDeptName = @ParentDeptName
,   DeptMgr = @DeptMgr
,   CreateDate = @CreateDate
,   IsValid = @IsValid
,   DeptLevel = @DeptLevel
,   Remark = @Remark
,   Serial = @Serial
,   TypeId = @TypeId
,   TypeName = @TypeName
,   DeptMgrName = @DeptMgrName
,   CostCenter = @CostCenter
,   ShowInOtherSys = @ShowInOtherSys
Where DeptCode = @DeptCode And
      DeptCo = @DeptCo

Update mySystemUserInfo Set DeptCnName=@DeptCnName Where EmpDept = @DeptCode
";
        private const string SQL_DISABLE_DEPT = "Update mySystemDept Set IsValid = 'N' Where DeptCode = @DeptCode And DeptCo = @DeptCo";
        private const string SQL_ENABLE_DEPT = "Update mySystemDept Set IsValid = 'Y' Where DeptCode = @DeptCode And DeptCo = @DeptCo";
        private const string SQL_DELETE_DEPT = "Delete From mySystemDept Where DeptCode = @DeptCode And DeptCo = @DeptCo";
        private const string SQL_SELECT_ALL_BY_COMPANY = "Select * From mySystemDept Where DeptCo = @DeptCo";
        private const string SQL_SELECT_ALLAVALIBLE_BY_COMPANY = "Select * From mySystemDept Where DeptCo = @DeptCo And IsValid = 'Y'";
        private const string SQL_SELECTCOUNT_BY_COMPANY_CODE = "Select Count(*) From mySystemDept Where DeptCo = @DeptCo And DeptCode = @DeptCode";
        private const string SQL_SELECTCOUNT_BY_COMPANY_NAME = "Select Count(*) From mySystemDept Where DeptCo = @DeptCo And DeptCnName = @DeptCnName";
        private const string SQL_SELECT_BY_COMPANY_CODE = "Select * From mySystemDept Where DeptCo = @DeptCo And DeptCode = @DeptCode";
        private const string SQL_SELECT_BY_DEPT_MANAGER = "SELECT * FROM mySystemDept WHERE DeptCo=@DeptCo AND IsValid='Y' And DeptMgr = @DeptMgr ";
        private const string SQL_SELECTPARENTDETP_BY_CODE = "select * from mySystemDept where deptCode = (select ParentDept from mySystemDept where DeptCode=@DeptCode)";
        private const string SQL_HAS_CHILDDEPT = "Select count(*) From mySystemDept Where ParentDept = @DeptCode And DeptCo = @DeptCo";

        private const string SQL_HAS_USER =
            "Select count(*) From mySystemUserInfo Where EmpCo = @EmpCo And EmpDept = @EmpDept";
        #endregion

        #region private method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static SqlParameter[] GetDeptParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_DEPT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@DeptCode", SqlDbType.NVarChar,20),
                                new SqlParameter("@DeptCo", SqlDbType.NVarChar,20), 
                                new SqlParameter("@DeptCnName", SqlDbType.NVarChar,50), 
                                new SqlParameter("@DeptEnName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ParentDept", SqlDbType.NVarChar,20),
                                new SqlParameter("@ParentDeptName",SqlDbType.NVarChar, 20),
                                new SqlParameter("@DeptMgr",SqlDbType.NVarChar,20),
                                new SqlParameter("@CreateDate",SqlDbType.SmallDateTime),
                                new SqlParameter("@IsValid",SqlDbType.NChar,1),
                                new SqlParameter("@DeptLevel",SqlDbType.SmallInt),
                                new SqlParameter("@Remark",SqlDbType.NVarChar,50),
                                new SqlParameter("@Serial",SqlDbType.SmallInt), 
                                new SqlParameter("@TypeId",SqlDbType.NVarChar, 20),
                                new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
                                new SqlParameter("@DeptMgrName", SqlDbType.NVarChar,50),
                                new SqlParameter("@CostCenter",SqlDbType.NVarChar,50),
                                new SqlParameter("@ShowInOtherSys",SqlDbType.Int),
                                
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_DEPT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将SqlDataReader转换为DeptInfo实体。
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <returns>组织机构实体。</returns>
        private static DeptInfo ConvertToDeptInfo(IDataRecord dr)
        {
            var obj = new DeptInfo
            {
                DeptCode = dr.GetString(0),
                DeptCo = dr.GetString(1),
                DeptCnName = dr.GetString(2),
                DeptEnName = dr["DeptEnName"] == DBNull.Value ? string.Empty : dr["DeptEnName"].ToString(),
                ParentDept = dr["ParentDept"] == DBNull.Value ? string.Empty : dr["ParentDept"].ToString(),
                ParentDeptName = dr["ParentDeptName"] == DBNull.Value ? string.Empty : dr["ParentDeptName"].ToString(),
                DeptMgr = dr["DeptMgr"] == DBNull.Value ? string.Empty : dr["DeptMgr"].ToString(),
                CreateDate = dr.GetDateTime(7),
                IsValid = dr.GetString(8),
                DeptLevel = dr["DeptLevel"] == DBNull.Value ? (short)0 : short.Parse(dr["DeptLevel"].ToString()),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                Serial = dr["Serial"] == DBNull.Value ? (short)0 : short.Parse(dr["Serial"].ToString()),
                TypeId = dr["TypeId"] == DBNull.Value ? string.Empty : dr["TypeId"].ToString(),
                TypeName = dr["TypeName"] == DBNull.Value ? string.Empty : dr["TypeName"].ToString(),
                DeptMgrName = dr["DeptMgrName"] == DBNull.Value ? string.Empty : dr["DeptMgrName"].ToString(),
                CostCenter = dr["CostCenter"] == DBNull.Value ? string.Empty : dr["CostCenter"].ToString(),
                ShowInOtherSys = dr["ShowInOtherSys"] == DBNull.Value ? 1 : int.Parse(dr["ShowInOtherSys"].ToString()),
                
            };
            return obj;
        }
        #endregion

        #region IDept 成员

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Insert(DeptInfo deptInfo)
        {
            return Insert(deptInfo, null);
        }

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(DeptInfo deptInfo,DbTransaction trans)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptInfo.DeptCode;
            parms[1].Value = deptInfo.DeptCo;
            parms[2].Value = deptInfo.DeptCnName;
            parms[3].Value = string.IsNullOrEmpty(deptInfo.DeptEnName) ? (object)DBNull.Value : deptInfo.DeptEnName;
            parms[4].Value = string.IsNullOrEmpty(deptInfo.ParentDept) ? (object)DBNull.Value : deptInfo.ParentDept;
            parms[5].Value = string.IsNullOrEmpty(deptInfo.ParentDeptName)
                                 ? (object)DBNull.Value
                                 : deptInfo.ParentDeptName;
            parms[6].Value = string.IsNullOrEmpty(deptInfo.DeptMgr) ? (object)DBNull.Value : deptInfo.DeptMgr;
            parms[7].Value = deptInfo.CreateDate;
            parms[8].Value = deptInfo.IsValid;
            parms[9].Value = deptInfo.DeptLevel;
            parms[10].Value = string.IsNullOrEmpty(deptInfo.Remark) ? (object)DBNull.Value : deptInfo.Remark;
            parms[11].Value = deptInfo.Serial;
            parms[12].Value = string.IsNullOrEmpty(deptInfo.TypeId) ? (object)DBNull.Value : deptInfo.TypeId;
            parms[13].Value = string.IsNullOrEmpty(deptInfo.TypeName) ? (object)DBNull.Value : deptInfo.TypeName;
            parms[14].Value = string.IsNullOrEmpty(deptInfo.DeptMgrName) ? (object)DBNull.Value : deptInfo.DeptMgrName;
            parms[15].Value = string.IsNullOrEmpty(deptInfo.CostCenter) ? (object)DBNull.Value : deptInfo.CostCenter;
            parms[16].Value = deptInfo.ShowInOtherSys;
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_DEPT, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT_DEPT, parms);
                return true;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Update(DeptInfo deptInfo)
        {
            return Update(deptInfo, null);
        }

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool。</returns>
        public bool Update(DeptInfo deptInfo,DbTransaction trans)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptInfo.DeptCode;
            parms[1].Value = deptInfo.DeptCo;
            parms[2].Value = deptInfo.DeptCnName;
            parms[3].Value = string.IsNullOrEmpty(deptInfo.DeptEnName) ? (object)DBNull.Value : deptInfo.DeptEnName;
            parms[4].Value = string.IsNullOrEmpty(deptInfo.ParentDept) ? (object)DBNull.Value : deptInfo.ParentDept;
            parms[5].Value = string.IsNullOrEmpty(deptInfo.ParentDeptName)
                                 ? (object)DBNull.Value
                                 : deptInfo.ParentDeptName;
            parms[6].Value = string.IsNullOrEmpty(deptInfo.DeptMgr) ? (object)DBNull.Value : deptInfo.DeptMgr;
            parms[7].Value = deptInfo.CreateDate;
            parms[8].Value = deptInfo.IsValid;
            parms[9].Value = deptInfo.DeptLevel;
            parms[10].Value = string.IsNullOrEmpty(deptInfo.Remark) ? (object)DBNull.Value : deptInfo.Remark;
            parms[11].Value = deptInfo.Serial;
            parms[12].Value = string.IsNullOrEmpty(deptInfo.TypeId) ? (object)DBNull.Value : deptInfo.TypeId;
            parms[13].Value = string.IsNullOrEmpty(deptInfo.TypeName) ? (object)DBNull.Value : deptInfo.TypeName;
            parms[14].Value = string.IsNullOrEmpty(deptInfo.DeptMgrName) ? (object)DBNull.Value : deptInfo.DeptMgrName;
            parms[15].Value = string.IsNullOrEmpty(deptInfo.CostCenter) ? (object)DBNull.Value : deptInfo.CostCenter;
            parms[16].Value = deptInfo.ShowInOtherSys;
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_DEPT, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_UPDATE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Delete(DeptInfo deptInfo)
        {
            return Delete(deptInfo, null);
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对虾昂。</param>
        /// <returns>bool。</returns>
        public bool Delete(DeptInfo deptInfo,DbTransaction trans)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptInfo.DeptCode;
            parms[1].Value = deptInfo.DeptCo;

            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_DEPT, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DELETE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
            
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string companyCode, string deptCode)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptCode;
            parms[1].Value = companyCode;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool Disable(string companyCode, string deptCode)
        {
            return Disable(companyCode, deptCode, null);
        }

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Disable(string companyCode, string deptCode,DbTransaction trans)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptCode;
            parms[1].Value = companyCode;
            parms[8].Value = "N";
            try
            {
                if(trans == null )
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DISABLE_DEPT, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DISABLE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 部门有效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool Enable(string companyCode, string deptCode)
        {
            return Enable(companyCode, deptCode, null);
        }

        /// <summary>
        /// 部门起效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门代码。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Enable(string companyCode, string deptCode, DbTransaction trans)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptCode;
            parms[1].Value = companyCode;
            parms[8].Value = "Y";

            try
            {
                if(trans == null )
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, ConnectionString.PubData, CommandType.Text, SQL_ENABLE_DEPT, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, ConnectionString.PubData, CommandType.Text, SQL_ENABLE_DEPT, parms);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 是否已经存在部门编号。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool IsExistDeptCode(string companyCode, string deptCode)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptCode;
            parms[1].Value = companyCode;

            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text,
                                              SQL_SELECTCOUNT_BY_COMPANY_CODE, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 是否已经存在部门名称
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptName">部门名称。</param>
        /// <returns>bool</returns>
        public bool IsExistDeptName(string companyCode, string deptName)
        {
            var parms = GetDeptParameters();
            parms[1].Value = companyCode;
            parms[2].Value = deptName;
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text,
                                              SQL_SELECTCOUNT_BY_COMPANY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        public bool HasChildDept(string companyCode, string deptCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@DeptCo", SqlDbType.NVarChar, 20) {Value = companyCode},
                                new SqlParameter("@DeptCode", SqlDbType.NVarChar, 20) {Value = deptCode}
                            };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_HAS_CHILDDEPT, parms);

            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        public bool HasUser(string companyCode, string deptCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EmpCo", SqlDbType.NVarChar, 20) {Value = companyCode},
                                new SqlParameter("@EmpDept", SqlDbType.NVarChar, 20) {Value = deptCode}
                            };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_HAS_USER, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 获取所有部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        public IList<DeptInfo> GetAllByCompanyCode(string companyCode)
        {
            var parms = GetDeptParameters();
            parms[1].Value = companyCode;
            var objs = new ListBase<DeptInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL_BY_COMPANY,
                                             parms);
            while(dr.Read())
            {
                objs.Add(ConvertToDeptInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        public IList<DeptInfo> GetAllAvalibleCompanyCode(string companyCode)
        {
            var parms = GetDeptParameters();
            parms[1].Value = companyCode;
            var objs = new ListBase<DeptInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE_BY_COMPANY,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToDeptInfo(dr));
            }
            dr.Close();
            return objs;
        }
        
        //public IList<DeptInfo> GetAllTestCompanyCode()
        //{
        //    var objs = new ListBase<DeptInfo>();
        //    var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TEST);
        //    while (dr.Read())
        //    {
        //        objs.Add(ConvertToDeptInfo(dr));
        //    }
        //    dr.Close();
        //    return objs;
        //}

        /// <summary>
        /// 根据部门编号获取部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        public DeptInfo GetByCompanyCodeAndDeptCode(string companyCode, string deptCode)
        {
            var parms = GetDeptParameters();
            parms[0].Value = deptCode;
            parms[1].Value = companyCode;

            DeptInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_COMPANY_CODE,
                                             parms);
            while(dr.Read())
            {
                obj = ConvertToDeptInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据部门编号获取上级部门。
        /// </summary>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>部门实体。</returns>
        public DeptInfo GetParentDeptByCode(string deptCode)
        {
            var parms = new[] { new SqlParameter("@DeptCode", SqlDbType.NVarChar, 50) { Value = deptCode } };

            DeptInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECTPARENTDETP_BY_CODE,
                                             parms);
            while(dr.Read())
            {
                obj = ConvertToDeptInfo(dr);
                break;
            }
            dr.Close();
            return obj;
            
        }

        #endregion

        #region IDept 成员

        /// <summary>
        /// 根据公司编号和部门主管获取部门列表。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="manager">部门主管。</param>
        /// <returns>部门列表。</returns>
        public IList<DeptInfo> GetByCompanyAndManager(string companyCode, string manager)
        {
            var parms = GetDeptParameters();
            
            parms[1].Value = companyCode;
            parms[6].Value = manager;

            var objs = new ListBase<DeptInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_DEPT_MANAGER,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToDeptInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion
    }
}
