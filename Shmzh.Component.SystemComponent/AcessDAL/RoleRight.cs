using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class RoleRight : IRoleRight
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 添加组记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_ROLERIGHT = "Insert Into mySystemRoleRights ([RoleCode],[RightCode]) Values (@RoleCode, @RightCode) ";

        //private const string SQL_INSERT_ROLERIGHTS = @"Insert Into mySystemRoleRights (RoleCode, RightCode)";
        //Select @RoleCode,Convert(smallint,Item) as RightCode  From dbo.String2Table(@RightCodes)
        //";
        /// <summary>
        /// 删除组记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_ROLERIGHT = "Delete From mySystemRoleRights Where RoleCode = @RoleCode And RightCode = @RightCode";

        private const string SQL_DELETE_BY_ROLECODE = "Delete From mySystemRoleRights Where RoleCode = @RoleCode";

        private const string SQL_SELECT_ALL = "Select * From mySystemRoleRights";

        private const string SQL_SELECT_ALLAVALIBLE =@"
Select * From mySystemRoleRights a
Where Exists (Select * From mySystemRoles b Where a.RoleCode = b.RoleCode And b.IsValid='Y') And
      Exists (Select * From mySystemRights c Where A.RightCode = C.RightCode And c.IsValid = 'Y')";
        /// <summary>
        /// 获取所有有效的用户角色记录。
        /// </summary>
        private const string SQL_SELECT_BY_ROLECODE = "Select * From mySystemRoleRights Where RoleCode = @RoleCode";
        /// <summary>
        /// 根据权限编号获取角色权限的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_RIGHTCODE = "Select * From mySystemRoleRights Where RightCode = @RightCode";
       
        /// <summary>
        /// 用户名参数。
        /// </summary>
        private const string PARM_ROLECODE = "@RoleCode";
        /// <summary>
        /// 角色编号参数。
        /// </summary>
        private const string PARM_RIGHTCODE = "@RightCode";
        
        #endregion

        #region Private method
        /// <summary>
        /// 获取用户角色参数。
        /// </summary>
        /// <returns>参数数组。</returns>
        private static OleDbParameter[] GetRoleRightParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_ROLERIGHT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter(PARM_ROLECODE, OleDbType.SmallInt), 
                                new OleDbParameter(PARM_RIGHTCODE, OleDbType.SmallInt), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_ROLERIGHT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成RoleRightInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>用户权限实体。</returns>
        private RoleRightInfo ConvertToRoleRightInfo(IDataRecord dr)
        {
            var obj = new RoleRightInfo
            {
                RoleCode = dr.GetInt16(0),
                RightCode = dr.GetInt16(1),
            };
            return obj;
        }
        #endregion

        #region IRoleRight 成员
        /// <summary>
        /// 添加用户角色。
        /// </summary>
        /// <param name="roleRightInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(RoleRightInfo roleRightInfo)
        {
            var parms = GetRoleRightParameters();
            parms[0].Value = roleRightInfo.RoleCode;
            parms[1].Value = roleRightInfo.RightCode;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_ROLERIGHT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 批量添加角色权限。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <param name="rightCodes">权限编码拼接字符串。</param>
        /// <returns>bool</returns>
        public bool Insert(short roleCode, string rightCodes)
        {
            //var parms = new[] {
            //    new OleDbParameter("@RoleCode",OleDbType.SmallInt){Value = roleCode},
            //    new OleDbParameter("@RightCodes", OleDbType.VarChar,4000){Value = rightCodes},
           // };
            try
            {
                string[] strRightCodes = rightCodes.Split(',');

                for (int i = 0; i < strRightCodes.Length; i++)
                {
                    var parms = new[] {
                        new OleDbParameter("@RoleCode",OleDbType.SmallInt){Value = roleCode},
                         new OleDbParameter("@RightCodes", OleDbType.VarChar,4000){Value = strRightCodes[i]},
                         };
                    AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_INSERT_ROLERIGHT, parms);
                }

               // AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_ROLERIGHTS, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除角色权限实体。
        /// </summary>
        /// <param name="roleRightInfo">角色权限实体。</param>
        /// <returns>bool</returns>
        public bool Delete(RoleRightInfo roleRightInfo)
        {
            var parms = GetRoleRightParameters();
            parms[0].Value = roleRightInfo.RoleCode;
            parms[1].Value = roleRightInfo.RightCode;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_ROLERIGHT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 根据角色编号删除角色权限关系。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short roleCode)
        {
            var parms = GetRoleRightParameters();
            parms[0].Value = roleCode;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_BY_ROLECODE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 根据角色编号获取角色权限。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetByRoleCode(short roleCode)
        {
            var parms = GetRoleRightParameters();
            parms[0].Value = roleCode;
            IList<RoleRightInfo> objs = new ListBase<RoleRightInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_ROLECODE,parms);
            while (dr.Read())
            {
                var obj = ConvertToRoleRightInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据权限编号获取角色权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetByRightCode(short rightCode)
        {
            var parms = GetRoleRightParameters();
            parms[1].Value = rightCode;
            IList<RoleRightInfo> objs = new ListBase<RoleRightInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_RIGHTCODE, parms);
            while (dr.Read())
            {
                var obj = ConvertToRoleRightInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据用户名获取角色权限集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="userName">用户名。</param>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetByProductCodeAndUserName(short productCode, string userName)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IRoleRight 成员

        /// <summary>
        /// 获取所有的角色权限关系。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        public IList<RoleRightInfo> GetAll()
        {
            var objs = new ListBase<RoleRightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToRoleRightInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 获取所有有效的角色权限关系。
        /// </summary>
        /// <returns>角色权限集合。</returns>
        public ListBase<RoleRightInfo> GetAllAvalible()
        {
            var objs = new ListBase<RoleRightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(ConvertToRoleRightInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion
    }
}
