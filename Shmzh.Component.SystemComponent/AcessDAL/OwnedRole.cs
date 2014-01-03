using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// 角色与访问对象之间关系的SQLServer的数据访问对象。
    /// </summary>
    public class OwnedRole :IDAL.IOwnedRole
    {
        #region Field

        private const string SQL_SELECT_ALL_BY_PRODUCTCODE =
            @"
Select  Distinct RoleCode,CheckCode,Type From mySystemUserRoles a Where Exists (Select * From mySystemRoles b Where a.RoleCode = b.RoleCode And B.ProductCode = @ProductCode And B.IsValid = 'Y')
Union
Select  Distinct RoleCode,CheckCode,Type From mySystemGroupRoles a Where Exists (Select * From mySystemRoles b Where a.RoleCode = b.RoleCode And B.ProductCode = @ProductCode And B.IsValid = 'Y')";
        private const string SQL_SELECT_BY_USERNAME = @"
Select  Distinct RoleCode,CheckCode,Type
From    dbo.ViewUsersRoles a
Where   UserCode In (SELECT @UserName As UserName
                     UNION
                     Select Grantor AS UserName
                     From   dbo.fun_GetAllGrantorsByEmbracer(@UserName)
                     Where  EffectTime <= getDate()
                    ) And
        Exists (Select * 
                From    mySystemRoles b
                Where   a.RoleCode = b.RoleCode And
                        b.IsValid = 'Y')";
        #endregion

        #region IOwnedRole 成员

        /// <summary>
        /// 根据产品获取所有的角色与对象的关系的集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        public List<OwnedRoleInfo> GetAllByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.VarChar, 20) { Value = productCode } };
            var objs = new ListBase<OwnedRoleInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_BY_PRODUCTCODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOwnedRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据用户名获取用户所具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色和访问对象关系的集合。</returns>
        public List<OwnedRoleInfo> GetByUserName(string userName)
        {
            var parms = new[] {new OleDbParameter("@UserName", OleDbType.VarChar, 20) {Value = userName}};
            var objs = new ListBase<OwnedRoleInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_BY_USERNAME, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToOwnedRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据组编号获取具有的角色和访问对象的关系。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>角色和访问对象关系的集合</returns>
        public List<OwnedRoleInfo> GetByGroupCode(short groupCode)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region private method
        /// <summary>
        /// 将DataRow转换成OwnedRoleInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>角色与访问对象的关系实体。</returns>
        private OwnedRoleInfo ConvertToOwnedRoleInfo(IDataRecord dr)
        {
            var obj = new OwnedRoleInfo
            {
                RoleCode = dr.GetInt16(0),
                CheckCode = dr["CheckCode"] == DBNull.Value?string.Empty:dr["CheckCode"].ToString(),
                Type = dr["Type"] == DBNull.Value ? string.Empty : dr["Type"].ToString(),
            };
            return obj;
        }
        #endregion


        
    }
}
