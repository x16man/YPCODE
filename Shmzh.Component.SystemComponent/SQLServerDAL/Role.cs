using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 角色的SQL Server数据访问对象。
    /// </summary>
    public class Role : IRole
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 添加角色记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_ROLE = "Select @RoleCode=IsNull(max(roleCode),0)+1 From mySystemRoles Insert Into mySystemRoles (RoleCode,RoleName,IsValid,Remark,ProductCode,SerialNo) Values (@RoleCode,@RoleName,@IsValid,@Remark,@ProductCode,@SerialNo)";
        /// <summary>
        /// 修改角色记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_ROLE = "Update mySystemRoles Set RoleCode = @RoleCode,RoleName = @RoleName, IsValid=@IsValid, Remark = @Remark,ProductCode = @ProductCode,SerialNo = @SerialNo Where RoleCode = @RoleCode";
        /// <summary>
        /// 删除角色记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_ROLE = @"
Delete From mySystemRoles Where RoleCode = @RoleCode
Delete From mySystemRoleRights Where RoleCode = @RoleCode
Delete From mySystemUserRoles Where RoleCode = @RoleCode
Delete From mySystemGroupRoles Where RoleCode = @RoleCode";
        /// <summary>
        /// 根据产品编号获取所有角色记录。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_PRODUCTCODE = "Select * From mySystemRoles Where ProductCode = @ProductCode Order By SerialNo";
        /// <summary>
        /// 根据产品编号获取所有有效的角色记录。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE = "Select * From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y' Order By SerialNo";
        /// <summary>
        /// 根据角色名称和产品编号获取角色记录。
        /// </summary>
        private const string SQL_SELECT_BY_NAME_PRODUCTCODE = "Select Count(*) From mySystemRoles Where RoleName = @RoleName And ProductCode = @ProductCode";
        /// <summary>
        /// 根据角色编号获取角色记录。
        /// </summary>
        private const string SQL_SELECT_BY_CODE = "Select * From mySystemRoles Where RoleCode = @RoleCode";
        
        /// <summary>
        /// 角色编号。
        /// </summary>
        private const string PARM_ROLECODE = "@RoleCode";
        /// <summary>
        /// 角色名称。
        /// </summary>
        private const string PARM_ROLENAME = "@RoleName";
        /// <summary>
        /// 是否有效。
        /// </summary>
        private const string PARM_ISVALID = "@IsValid";
        /// <summary>
        /// 角色描述。
        /// </summary>
        private const string PARM_REMARK = "@Remark";
        /// <summary>
        /// 产品编号。
        /// </summary>
        private const string PARM_PRODUCTCODE = "@ProductCode";
        /// <summary>
        /// 顺序编号。
        /// </summary>
        private const string PARM_SERIALNO = "@SerialNo";
            
        #endregion

        #region Private method
        /// <summary>
        /// 获取角色参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetRoleParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_ROLE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_ROLECODE, SqlDbType.SmallInt),
                                new SqlParameter(PARM_ROLENAME, SqlDbType.NVarChar,50), 
                                new SqlParameter(PARM_ISVALID,SqlDbType.NChar,1), 
                                new SqlParameter(PARM_REMARK, SqlDbType.NVarChar,50), 
                                new SqlParameter(PARM_PRODUCTCODE,SqlDbType.SmallInt), 
                                new SqlParameter(PARM_SERIALNO,SqlDbType.Int), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_ROLE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成RoleInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>角色实体。</returns>
        private RoleInfo ConvertToRoleInfo(IDataRecord dr)
        {
            var obj = new RoleInfo
                          {
                              RoleCode = dr.GetInt16(0),
                              RoleName = dr.GetString(1),
                              IsValid = dr.GetString(2),
                              Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                              ProductCode = dr.GetInt16(4),
                              SerialNo = dr["SerialNo"] == DBNull.Value?-1:int.Parse(dr["SerialNo"].ToString()),
            };
            return obj;
        }
        #endregion

        #region IRole 成员
        /// <summary>
        /// 添加角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(RoleInfo roleInfo)
        {
            var parms = GetRoleParameters();
            parms[0].Value = 0;
            parms[1].Value = roleInfo.RoleName;
            parms[2].Value = roleInfo.IsValid;
            parms[3].Value = roleInfo.Remark == string.Empty ? (object)DBNull.Value : roleInfo.Remark;
            parms[4].Value = roleInfo.ProductCode;
            parms[5].Value = roleInfo.SerialNo == -1 ? (object) DBNull.Value : roleInfo.SerialNo;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_ROLE, parms);
                roleInfo.RoleCode = short.Parse(parms[0].Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        public bool Update(RoleInfo roleInfo)
        {
            var parms = GetRoleParameters();
            parms[0].Value = roleInfo.RoleCode;
            parms[1].Value = roleInfo.RoleName;
            parms[2].Value = roleInfo.IsValid;
            parms[3].Value = roleInfo.Remark == string.Empty ? (object)DBNull.Value : roleInfo.Remark;
            parms[4].Value = roleInfo.ProductCode;
            parms[5].Value = roleInfo.SerialNo == -1 ? (object)DBNull.Value : roleInfo.SerialNo;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_ROLE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleInfo">角色实体。</param>
        /// <returns>bool</returns>
        /// <remarks>联动删除角色权限、用户角色、组角色。</remarks>
        public bool Delete(RoleInfo roleInfo)
        {
            var parms = GetRoleParameters();
            parms[0].Value = roleInfo.RoleCode;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_ROLE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        /// <remarks>联动删除角色权限、用户角色、组角色。</remarks>
        public bool Delete(short roleCode)
        {
            var parms = GetRoleParameters();
            parms[0].Value = roleCode;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_ROLE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 根据角色编号判断是否已经在数据库中存在。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(short roleCode)
        {
            try
            {
                var obj = this.GetByCode(roleCode);
                return obj == null ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return true;
            }
        }
        /// <summary>
        /// 根据产品编号和角色名称判断是否已经在数据库中存在。
        /// </summary>
        /// <param name="roleName">角色名称。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(string roleName, short productCode)
        {
            var parms = GetRoleParameters();
            parms[1].Value = roleName;
            parms[4].Value = productCode;

            try
            {
                var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_NAME_PRODUCTCODE, parms);
                return (int) obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return true;
            }
        }
        /// <summary>
        /// 根据产品编号获取所有的角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色集合。</returns>
        public IList<RoleInfo> GetAllByProductCode(short productCode)
        {
            IList<RoleInfo> objs = new ListBase<RoleInfo>();
            var parms = GetRoleParameters();
            parms[4].Value = productCode;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL_BY_PRODUCTCODE, parms);
            while (dr.Read())
            {
                var obj = ConvertToRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号获取所有的有效角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色集合。</returns>
        public IList<RoleInfo> GetAllAvalibleByProductCode(short productCode)
        {
            IList<RoleInfo> objs = new ListBase<RoleInfo>();
            var parms = GetRoleParameters();
            parms[4].Value = productCode;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE, parms);
            while (dr.Read())
            {
                var obj = ConvertToRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据角色编号获取角色实体。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>角色实体。</returns>
        public RoleInfo GetByCode(short roleCode)
        {
            var parms = new[] {new SqlParameter("@RoleCode", SqlDbType.SmallInt) {Value = roleCode}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text,SQL_SELECT_BY_CODE, parms);
            RoleInfo obj = null;
            while (dr.Read())
            {
                obj = ConvertToRoleInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
