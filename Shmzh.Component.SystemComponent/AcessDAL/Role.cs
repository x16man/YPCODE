using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
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
        private const string SQL_INSERT_ROLE = "Insert Into mySystemRoles (RoleCode,RoleName,IsValid,Remark,ProductCode,SerialNo) Values (@RoleCode,@RoleName,@IsValid,@Remark,@ProductCode,@SerialNo)";
        /// <summary>
        /// 修改角色记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_ROLE = "Update mySystemRoles Set RoleCode = @RoleCode,RoleName = @RoleName, IsValid=@IsValid, Remark = @Remark,ProductCode = @ProductCode,SerialNo = @SerialNo Where RoleCode = @RoleCode1";
        /// <summary>
        /// 删除角色记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_ROLES = @"Delete From mySystemRoles Where RoleCode = @RoleCode";
        private const string SQL_DELETE_ROLESRights = @"Delete From mySystemRoleRights Where RoleCode = @RoleCode";
         private const string SQL_DELETE_UserRoles = @"Delete From mySystemUserRoles Where RoleCode = @RoleCode";
         private const string SQL_DELETE_GroupRoles = @"Delete From mySystemGroupRoles Where RoleCode = @RoleCode";

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
        
        private const string PARM_SERIALNO = "@SerialNo";
        #endregion

        #region Private method
        /// <summary>
        /// 获取角色参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetRoleParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_ROLE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter(PARM_ROLECODE, OleDbType.SmallInt),
                                new OleDbParameter(PARM_ROLENAME, OleDbType.VarChar,50), 
                                new OleDbParameter(PARM_ISVALID,OleDbType.Char,1), 
                                new OleDbParameter(PARM_REMARK, OleDbType.VarChar,50), 
                                new OleDbParameter(PARM_PRODUCTCODE,OleDbType.SmallInt), 
                                new OleDbParameter(PARM_SERIALNO,OleDbType.Integer), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_ROLE, parms);
            }
            return parms;
        }

        private static OleDbParameter[] GetRoleUpdateParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_ROLE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter(PARM_ROLECODE, OleDbType.SmallInt),
                                new OleDbParameter(PARM_ROLENAME, OleDbType.VarChar,50), 
                                new OleDbParameter(PARM_ISVALID,OleDbType.Char,1), 
                                new OleDbParameter(PARM_REMARK, OleDbType.VarChar,50), 
                                new OleDbParameter(PARM_PRODUCTCODE,OleDbType.SmallInt), 
                                new OleDbParameter(PARM_SERIALNO, OleDbType.Integer), 
                                new OleDbParameter("RoleCode1", OleDbType.SmallInt),
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_ROLE, parms);
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
                              SerialNo = dr["SerialNo"] == DBNull.Value ? -1 : int.Parse(dr["SerialNo"].ToString()),
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
            parms[0].Value = GetMax();
            parms[1].Value = roleInfo.RoleName;
            parms[2].Value = roleInfo.IsValid;
            parms[3].Value = roleInfo.Remark == string.Empty ? (object)DBNull.Value : roleInfo.Remark;
            parms[4].Value = roleInfo.ProductCode;
            parms[5].Value = roleInfo.SerialNo;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_ROLE, parms);
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
            var parms = new[]
                            {
                                new OleDbParameter(PARM_ROLECODE, OleDbType.SmallInt),
                                new OleDbParameter(PARM_ROLENAME, OleDbType.VarChar,50), 
                                new OleDbParameter(PARM_ISVALID,OleDbType.Char,1), 
                                new OleDbParameter(PARM_REMARK, OleDbType.VarChar,50), 
                                new OleDbParameter(PARM_PRODUCTCODE,OleDbType.SmallInt), 
                                new OleDbParameter(PARM_SERIALNO, OleDbType.Integer),
                                new OleDbParameter("RoleCode1", OleDbType.SmallInt),
                                
                            };

            parms[0].Value = roleInfo.RoleCode;
            parms[1].Value = roleInfo.RoleName;
            parms[2].Value = roleInfo.IsValid;
            parms[3].Value = roleInfo.Remark == string.Empty ? (object)DBNull.Value : roleInfo.Remark;
            parms[4].Value = roleInfo.ProductCode;
            parms[5].Value = roleInfo.SerialNo == -1 ? (object)DBNull.Value : roleInfo.SerialNo;
            parms[6].Value = roleInfo.RoleCode;
            
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE_ROLE, parms);
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
            //var parms = GetRoleParameters();
            //parms[0].Value = roleInfo.RoleCode;

            var parms = new[] { new OleDbParameter("@RoleCode", OleDbType.SmallInt) { Value = roleInfo.RoleCode } };

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_ROLES, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_ROLESRights, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_UserRoles, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_GroupRoles, parms);
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
            var parms = new[] { new OleDbParameter("@RoleCode", OleDbType.SmallInt) { Value = roleCode } };


            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_ROLES, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_ROLESRights, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_UserRoles, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_GroupRoles, parms);
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
            //var parms = GetRoleParameters();
            //parms[1].Value = roleName;
            //parms[4].Value = productCode;

            var parms = new[] { 
                new OleDbParameter("@RoleName", OleDbType.SmallInt) { Value = roleName },
                new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode },
            
            };

            try
            {
                var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_BY_NAME_PRODUCTCODE, parms);
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
            var parms = new[] { 
                new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode },
            
            };
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_BY_PRODUCTCODE, parms);
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
            var parms = new[] { 
                new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode },
            
            };
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE, parms);
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
            var parms = new[] {new OleDbParameter("@RoleCode", OleDbType.SmallInt) {Value = roleCode}};
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  SQL_SELECT_BY_CODE, parms);
            RoleInfo obj = null;
            while (dr.Read())
            {
                obj = ConvertToRoleInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        private short GetMax()
        {
            var oRet = AccessHelper.ExecuteScalar(ConnectionString.PubData, "Select max(roleCode)+1 From mySystemRoles");
            return short.Parse(oRet.ToString());
        }

        #endregion
    }
}
