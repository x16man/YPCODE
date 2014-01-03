using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// 员工状态的SQLServer的数据访问层。
    /// </summary>
    public class EmpState :IEmpState
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT_EMPSTATE =
            "Insert Into mySystemEmpState (Code,Description,IsValid) Value (@Code,@Description,@IsValid)";

        private const string SQL_UPDATE_EMPSTATE =
            "Update mySystemEmpState Set Description = @Description,IsValid = @IsValid Where Code = @Code";

        private const string SQL_DELETE_EMPSTATE = "Delete From mySystemEmpState Where Code = @Code";
        private const string SQL_SELECT_ALL = "Select * From mySystemEmpState";
        private const string SQL_SELECT_ALLAVALIBLE = "Select * From mySystemEmpState Where IsValid = 'Y'";
        private const string SQL_SELECT_COUNT_BY_CODE = "Select Count(*) From mySystemEmpState Where Code = @Code";

        private const string SQL_SELECT_COUNT_BY_DESCRIPTION =
            "Select Count(*) From mySystemEmpState Where Description = @Description";

        private const string SQL_SELECT_BY_CODE = "Select * From mySystemEmpState Where Code = @Code";
        #endregion

        #region private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetEmpStateParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_EMPSTATE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@Code", OleDbType.Char,1),
                                new OleDbParameter("@Description", OleDbType.VarChar,20), 
                                new OleDbParameter("@IsValid", OleDbType.Char,10),
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_EMPSTATE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private EmpStateInfo ConvertToEmpStateInfo(IDataRecord dr)
        {
            var obj = new EmpStateInfo()
            {
                Code = dr.GetString(0),
                Description = dr.GetString(1),
                IsValid = dr.GetString(2),
            };
            return obj;
        }
        #endregion

        #region IEmpState 成员

        /// <summary>
        /// 添加员工状态。
        /// </summary>
        /// <param name="empStateInfo">员工状态实体。</param>
        /// <returns>bool</returns>
        public bool Insert(EmpStateInfo empStateInfo)
        {
            var parms = GetEmpStateParameters();
            parms[0].Value = empStateInfo.Code;
            parms[1].Value = empStateInfo.Description;
            parms[2].Value = empStateInfo.IsValid;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_INSERT_EMPSTATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改员工状态。
        /// </summary>
        /// <param name="empStateInfo">员工状态实体。</param>
        /// <returns>bool</returns>
        public bool Update(EmpStateInfo empStateInfo)
        {
            var parms = GetEmpStateParameters();
            parms[0].Value = empStateInfo.Code;
            parms[1].Value = empStateInfo.Description;
            parms[2].Value = empStateInfo.IsValid;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_UPDATE_EMPSTATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除员工状态。
        /// </summary>
        /// <param name="empStateInfo">员工状态实体。</param>
        /// <returns>bool</returns>
        public bool Delete(EmpStateInfo empStateInfo)
        {
            var parms = GetEmpStateParameters();
            parms[0].Value = empStateInfo.Code;
            parms[1].Value = empStateInfo.Description;
            parms[2].Value = empStateInfo.IsValid;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_EMPSTATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除员工状态。
        /// </summary>
        /// <param name="code">员工状态代码。</param>
        /// <returns>bool</returns>
        public bool Delete(string code)
        {
            var parms = GetEmpStateParameters();
            parms[0].Value = code;
            
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_EMPSTATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 是否已经存在员工状态编号。
        /// </summary>
        /// <param name="code">员工状态代码。</param>
        /// <returns>bool</returns>
        public bool IsExistCode(string code)
        {
            var parms = GetEmpStateParameters();
            parms[0].Value = code;
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData, SQL_SELECT_COUNT_BY_CODE,
                                              parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 是否已经存在员工状态名称
        /// </summary>
        /// <param name="description">员工状态名称。</param>
        /// <returns>bool</returns>
        public bool IsExistDescription(string description)
        {
            var parms = GetEmpStateParameters();
            parms[1].Value = description;
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData, SQL_SELECT_COUNT_BY_DESCRIPTION,
                                              parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 获取所有员工状态。
        /// </summary>
        /// <returns>ArrayList。</returns>
        public IList<EmpStateInfo> GetAll()
        {
            var objs = new ListBase<EmpStateInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToEmpStateInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的员工状态。
        /// </summary>
        /// <returns>员工状态集合。</returns>
        public IList<EmpStateInfo> GetAllAvalible()
        {
            var objs = new ListBase<EmpStateInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(ConvertToEmpStateInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据员工状态编号获取员工状态。
        /// </summary>
        /// <param name="code">员工状态代码。</param>
        /// <returns>员工状态实体。</returns>
        public EmpStateInfo GetByCode(string code)
        {
            var parms = GetEmpStateParameters();
            parms[0].Value = code;
            EmpStateInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_BY_CODE, parms);
            while (dr.Read())
            {
                obj = ConvertToEmpStateInfo(dr);
                break;
            }
            dr.Close();
            return obj;
            
        }

        #endregion
    }
}
