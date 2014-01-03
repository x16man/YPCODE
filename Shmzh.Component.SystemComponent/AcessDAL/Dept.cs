using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
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
      DeptCo = @DeptCo";
        private const string SQL_DISABLE_DEPT = "Update mySystemDept Set IsValid = 'N' Where DeptCode = @DeptCode And DeptCo = @DeptCo";
        private const string SQL_ENABLE_DEPT = "Update mySystemDept Set IsValid = 'Y' Where DeptCode = @DeptCode And DeptCo = @DeptCo";
        private const string SQL_DELETE_DEPT = "Delete From mySystemDept Where DeptCode = @DeptCode And DeptCo = @DeptCo";
        private const string SQL_SELECT_ALL_BY_COMPANY = "Select * From mySystemDept Where DeptCo = @DeptCo";
        private const string SQL_SELECT_ALLAVALIBLE_BY_COMPANY = "Select * From mySystemDept Where DeptCo = @DeptCo And IsValid = 'Y'";
        //private const string SQL_SELECT_TEST = "Select * From mySystemDept Where DeptCo='YPWATER' And IsValid='Y'";
        private const string SQL_SELECTCOUNT_BY_COMPANY_CODE = "Select Count(*) From mySystemDept Where DeptCo = @DeptCo And DeptCode = @DeptCode";
        private const string SQL_SELECTCOUNT_BY_COMPANY_NAME = "Select Count(*) From mySystemDept Where DeptCo = @DeptCo And DeptCnName = @DeptCnName";
        private const string SQL_SELECT_BY_COMPANY_CODE = "Select * From mySystemDept Where DeptCo = @DeptCo And DeptCode = @DeptCode";
        private const string SQL_SELECT_BY_DEPT_MANAGER = "SELECT * FROM mySystemDept WHERE DeptCo=@DeptCo AND IsValid='Y' And DeptMgr = @DeptMgr ";
        #endregion

        #region private method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static OleDbParameter[] GetDeptParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_DEPT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@DeptCode", OleDbType.VarChar,20),
                                new OleDbParameter("@DeptCo", OleDbType.VarChar,20), 
                                new OleDbParameter("@DeptCnName", OleDbType.VarChar,50), 
                                new OleDbParameter("@DeptEnName", OleDbType.VarChar, 50),
                                new OleDbParameter("@ParentDept", OleDbType.VarChar,20),
                                new OleDbParameter("@ParentDeptName",OleDbType.VarChar, 20),
                                new OleDbParameter("@DeptMgr",OleDbType.VarChar,20),
                                new OleDbParameter("@CreateDate",OleDbType.Date),
                                new OleDbParameter("@IsValid",OleDbType.Char,1),
                                new OleDbParameter("@DeptLevel",OleDbType.SmallInt),
                                new OleDbParameter("@Remark",OleDbType.VarChar,50),
                                new OleDbParameter("@Serial",OleDbType.SmallInt), 
                                new OleDbParameter("@TypeId",OleDbType.VarChar, 20),
                                new OleDbParameter("@TypeName", OleDbType.VarChar,50),
                                new OleDbParameter("@DeptMgrName", OleDbType.VarChar,50),
                                new OleDbParameter("@CostCenter",OleDbType.VarChar,50),
                                new OleDbParameter("@ShowInOtherSys",OleDbType.Integer),
                                
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_DEPT, parms);
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
            var parms = GetDeptParameters();
            parms[0].Value = deptInfo.DeptCode;
            parms[1].Value = deptInfo.DeptCo;
            parms[2].Value = deptInfo.DeptCnName;
            parms[3].Value = string.IsNullOrEmpty(deptInfo.DeptEnName) ? (object) DBNull.Value : deptInfo.DeptEnName;
            parms[4].Value = string.IsNullOrEmpty(deptInfo.ParentDept) ? (object) DBNull.Value : deptInfo.ParentDept;
            parms[5].Value = string.IsNullOrEmpty(deptInfo.ParentDeptName)
                                 ? (object) DBNull.Value
                                 : deptInfo.ParentDeptName;
            parms[6].Value = string.IsNullOrEmpty(deptInfo.DeptMgr) ? (object) DBNull.Value : deptInfo.DeptMgr;
            parms[7].Value = deptInfo.CreateDate;
            parms[8].Value = deptInfo.IsValid;
            parms[9].Value = deptInfo.DeptLevel;
            parms[10].Value = string.IsNullOrEmpty(deptInfo.Remark) ? (object) DBNull.Value : deptInfo.Remark;
            parms[11].Value = deptInfo.Serial;
            parms[12].Value = string.IsNullOrEmpty(deptInfo.TypeId) ? (object) DBNull.Value : deptInfo.TypeId;
            parms[13].Value = string.IsNullOrEmpty(deptInfo.TypeName) ? (object) DBNull.Value : deptInfo.TypeName;
            parms[14].Value = string.IsNullOrEmpty(deptInfo.DeptMgrName) ? (object) DBNull.Value : deptInfo.DeptMgrName;
            parms[15].Value = string.IsNullOrEmpty(deptInfo.CostCenter) ? (object) DBNull.Value : deptInfo.CostCenter;
            parms[16].Value = deptInfo.ShowInOtherSys;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_INSERT_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 添加部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(DeptInfo deptInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Update(DeptInfo deptInfo)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCnName",OleDbType.VarChar,50){Value = deptInfo.DeptCnName},
                                new OleDbParameter("@DeptEnName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(deptInfo.DeptEnName) ? (object)DBNull.Value : deptInfo.DeptEnName},
                                new OleDbParameter("@ParentDept",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(deptInfo.ParentDept) ? (object)DBNull.Value : deptInfo.ParentDept}, 
                                new OleDbParameter("@ParentDeptName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(deptInfo.ParentDeptName)? (object)DBNull.Value: deptInfo.ParentDeptName}, 
                                new OleDbParameter("@DeptMgr",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(deptInfo.DeptMgr) ? (object)DBNull.Value : deptInfo.DeptMgr}, 
                                new OleDbParameter("@CreateDate",OleDbType.Date){Value = deptInfo.CreateDate},
                                new OleDbParameter("@IsValid",OleDbType.Char,1){Value = deptInfo.IsValid},
                                new OleDbParameter("@DeptLevel",OleDbType.Integer){Value = deptInfo.DeptLevel},
                                new OleDbParameter("@Remark",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(deptInfo.Remark) ? (object) DBNull.Value : deptInfo.Remark}, 
                                new OleDbParameter("@Serial",OleDbType.Integer){Value = deptInfo.Serial},
                                new OleDbParameter("@TypeId",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(deptInfo.TypeId) ? (object)DBNull.Value : deptInfo.TypeId}, 
                                new OleDbParameter("@TypeName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(deptInfo.TypeName) ? (object)DBNull.Value : deptInfo.TypeName}, 
                                new OleDbParameter("@DeptMgrName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(deptInfo.DeptMgrName) ? (object)DBNull.Value : deptInfo.DeptMgrName}, 
                                new OleDbParameter("@CostCenter",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(deptInfo.CostCenter) ? (object)DBNull.Value : deptInfo.CostCenter},
                                new OleDbParameter("@ShowInOtherSys", OleDbType.Integer){Value = deptInfo.ShowInOtherSys}, 
                                new OleDbParameter("@DeptCode",OleDbType.VarChar,20){Value = deptInfo.DeptCode},
                                new OleDbParameter("@DeptCo", OleDbType.VarChar,20){Value = deptInfo.DeptCo}, 
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_UPDATE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool。</returns>
        public bool Update(DeptInfo deptInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <returns>bool</returns>
        public bool Delete(DeptInfo deptInfo)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptInfo.DeptCode},
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = deptInfo.DeptCo},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="deptInfo">部门实体。</param>
        /// <param name="trans">事务对虾昂。</param>
        /// <returns>bool。</returns>
        public bool Delete(DeptInfo deptInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string companyCode, string deptCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@DetpCode", OleDbType.VarChar, 20) {Value = deptCode},
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_DEPT, parms);
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
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode},
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DISABLE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 部门失效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Disable(string companyCode, string deptCode, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 部门有效。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool Enable(string companyCode, string deptCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode},
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_ENABLE_DEPT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 是否已经存在部门编号。
        /// </summary>
        /// <param name="companyCode">公司代码。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <returns>bool</returns>
        public bool IsExistDeptCode(string companyCode, string deptCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode},
                            };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData, SQL_SELECTCOUNT_BY_COMPANY_CODE, parms);
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
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptName", OleDbType.VarChar, 50) {Value = deptName},
                            };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData, SQL_SELECTCOUNT_BY_COMPANY_NAME, parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 获取所有部门。
        /// </summary>
        /// <returns>部门集合。</returns>
        public IList<DeptInfo> GetAllByCompanyCode(string companyCode)
        {
            var parms = new[] {new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},};
            var objs = new ListBase<DeptInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_BY_COMPANY,
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
            var parms = new[] {new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},};
            var objs = new ListBase<DeptInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALLAVALIBLE_BY_COMPANY,
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
        //    var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  SQL_SELECT_TEST);
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
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode},
                            };
            DeptInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_BY_COMPANY_CODE,
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
            throw new NotImplementedException();
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
            var parms = new[]
                            {
                                new OleDbParameter("@DeptCo", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptMgr", OleDbType.VarChar, 20) {Value = manager},
                            };
            var objs = new ListBase<DeptInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_BY_DEPT_MANAGER,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToDeptInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion

        #region IDept 成员

        /// <summary>
        /// 判断是否有子部门。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        public bool HasChildDept(string companyCode, string deptCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 判断是否有用户。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="deptCode">部门名称</param>
        /// <returns>bool</returns>
        public bool HasUser(string companyCode, string deptCode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
