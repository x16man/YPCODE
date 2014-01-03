using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class GroupRole : IGroupRole
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169
        /// <summary>
        /// 添加组角色记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_GROUPROLE = "Insert Into mySystemGroupRoles (GroupCode,RoleCode,CheckCode,Type) Values (@GroupCode, @RoleCode, @CheckCode,@Type) ";

        private const string SQL_INSERT_GROUPSROLES = @"
Delete	From mySystemGroupRoles 
Where	GroupCode In (Select Convert(smallint,Item) From dbo.String2Table(@GroupCodeList)) And
		RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)
		
Insert	Into mySystemGroupRoles(GroupCode, RoleCode)
Select	Convert(smallint,G.Item) as GroupCode,Convert(smallint,R.Item) As RoleCode
From	dbo.String2Table(@GroupCodeList) G, dbo.String2Table(@RoleCodeList) R";

        private const string SQL_INSERT_GROUPSROLESBYCHECKCODE = @"
Delete  From mySystemGroupRoles
Where   GroupCode In (Select Convert(smallint,Item) From dbo.String2Table(@GroupCodeList)) And
        CheckCode = @CheckCode And
        Type = @Type

Insert  Into mySystemGroupRoles(GroupCode,RoleCode,CheckCode,Type)
Select  Convert(smallint,G.Item) as GroupCode,Convert(smallint,R.Item) As RoleCode,@CheckCode,@Type
From    dbo.String2Table(@GroupCodeList) G,dbo.String2Table(@RoleCodeList) R
";
        /// <summary>
        /// 删除组角色记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_GROUPROLE = "Delete From mySystemGroupRoles Where GroupCode = @GroupCode And RoleCode = @RoleCode And CheckCode = @CheckCode And Type = @Type";

        private const string SQL_DELETE_BY_GROUPCODES_PRODUCTCODE =@"
Delete  From mySystemGroupRoles 
Where   GroupCode In (Select Convert(smallint,Item) From dbo.String2Table(@GroupCodeList)) And
        RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)";
        
        private const string SQL_DELETE_BY_GROUPCODES_CHECKCODE_TYPE =@"
Delete  From mySystemGroupRoles 
Where   GroupCode In (Select Convert(smallint,Item) From dbo.String2Table(@GroupCodeList)) And 
        CheckCode = @CheckCode And 
        Type = @Type";
        /// <summary>
        /// 根据组编号和产品编号获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_GROUPCODE_PRODUCTCODE = @"
Select * From mySystemGroupRoles  
Where  GroupCode = @GroupCode And
       RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)";
        /// <summary>
        /// 根据组编号和知识库条目号和知识库条目类型来获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_GROUPCODE_CHECKCODE_TYPE = @"
Select * From mySystemGroupRoles 
Where  GroupCode = @GroupCode And
       CheckCode = @CheckCode And
       Type = @Type";
        /// <summary>
        /// 根据知识库条目号和知识库条目类型来获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_CHECKCODE_TYPE = @"
Select * From mySystemGroupRoles 
Where   CheckCode = @CheckCode And
        Type = @Type And 
        RoleCode In (Select RoleCode From mySystemRoles Where IsValid='Y')";
        /// <summary>
        /// 根据产品编号获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE = @"
Select * From mySystemGroupRoles 
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)";
        /// <summary>
        /// 根据角色编号获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_ROLECODE = @"
Select * From mySystemGroupRoles 
Where   RoleCode = @RoleCode
";
        /// <summary>
        /// 根据产品编号和组名(模糊)来获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE_NAME = @"
Select * From mySystemGroupRoles 
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        GroupCode In (Select GroupCode From mySystemGroups Where GroupName Like '%'+@Name+'%')
";
        /// <summary>
        /// 根据产品编号和组编号获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE_GROUPCODE = @"
Select * From mySystemGroupRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        GroupCode = @GroupCode
";
        /// <summary>
        /// 根据产品编号和组编号和检查对象获取组角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE_GROUPCODE_CHECKCODE_TYPE = @"
Select * From mySystemGroupRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        GroupCode = @GroupCode And
        CheckCode = @CheckCode And
        Type = @Type
";
        /// <summary>
        /// 清除知识库条目的访问控制。
        /// </summary>
        private const string SQL_CLEARACCESS = @"Delete From mySystemGroupRoles Where CheckCode=@CheckCode And Type=@Type";

        /// <summary>
        /// 复制组权限到目标组
        /// </summary>
        private const string SQL_COPYTOGROUPROLE_BY_SOURCEGROUPCODE_TARGETGROUPCODE_PRODUCTCODE = @"
Insert Into mySystemGroupRoles Select @TargetGroupCode As GroupCode,RoleCode,CheckCode,Type
From    mySystemGroupRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        GroupCode = @SourceGroupCode
";

        private const string SQL_SELECT_BY_GROUPCODE_TYPE = @"
Select * From mySystemGroupRoles
Where   GroupCode = @GroupCode And
        Type = @Type";
        #endregion

        #region Private method
        /// <summary>
        /// 获取用户角色参数。
        /// </summary>
        /// <returns>参数数组。</returns>
        private static SqlParameter[] GetGroupRoleParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_GROUPROLE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@GroupCode", SqlDbType.SmallInt),
                                new SqlParameter("@RoleCode", SqlDbType.SmallInt), 
                                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50), 
                                new SqlParameter("@Type", SqlDbType.NChar,1), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_GROUPROLE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private GroupRoleInfo ConvertToGroupRoleInfo(IDataRecord dr)
        {
            var obj = new GroupRoleInfo
              {
                  GroupCode = dr.GetInt16(0),
                  RoleCode = dr.GetInt16(1),
                  CheckCode = dr["CheckCode"] == DBNull.Value ? string.Empty : dr["CheckCode"].ToString(),
                  Type = dr["Type"] == DBNull.Value ? string.Empty : dr["Type"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IGroupRole 成员
        /// <summary>
        /// 添加组角色。
        /// </summary>
        /// <param name="groupRoleInfo">组角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(GroupRoleInfo groupRoleInfo)
        {
            var parms = GetGroupRoleParameters();
            parms[0].Value = groupRoleInfo.GroupCode;
            parms[1].Value = groupRoleInfo.RoleCode;
            parms[2].Value = groupRoleInfo.CheckCode;
            parms[3].Value = groupRoleInfo.Type;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_GROUPROLE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Insert(string groupCodes, string roleCodes, short productCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@GroupCodeList", SqlDbType.NVarChar,4000) {Value = groupCodes},
                                new SqlParameter("@RoleCodeList", SqlDbType.NVarChar, 4000) {Value = roleCodes},
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode}, 
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_GROUPSROLES, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Insert(string groupCodes, string roleCodes, string checkCode, string type)
        {
            var parms = new[]
                            {
                                new SqlParameter("@GroupCodeList", SqlDbType.NVarChar, 4000) {Value = groupCodes},
                                new SqlParameter("@RoleCodeList", SqlDbType.NVarChar, 4000) {Value = roleCodes},
                                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50){Value = checkCode},
                                new SqlParameter("@Type",SqlDbType.NChar,1){Value = type},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_GROUPSROLESBYCHECKCODE,
                                          parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        
        public bool Delete(GroupRoleInfo groupRoleInfo)
        {
            var parms = GetGroupRoleParameters();
            parms[0].Value = groupRoleInfo.GroupCode;
            parms[1].Value = groupRoleInfo.RoleCode;
            parms[2].Value = groupRoleInfo.CheckCode;
            parms[3].Value = groupRoleInfo.Type;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_GROUPROLE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(string groupCodes, short productCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@GroupCodeList", SqlDbType.NVarChar, 4000) {Value = groupCodes},
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt) {Value = productCode},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text,
                                          SQL_DELETE_BY_GROUPCODES_PRODUCTCODE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(string groupCodes, string checkCode, string type)
        {
            var parms = new[]
                            {
                                new SqlParameter("@GroupCodeList", SqlDbType.NVarChar, 4000) {Value = groupCodes},
                                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50) {Value = checkCode},
                                new SqlParameter("@Type",SqlDbType.NChar,1){Value = type}, 
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text,
                                          SQL_DELETE_BY_GROUPCODES_CHECKCODE_TYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool ClearAccess(string checkCode, string type)
        {
            var parms = new[]
                            {
                                new SqlParameter("@CheckCode", SqlDbType.NVarChar, 50) {Value = checkCode},
                                new SqlParameter("@Type", SqlDbType.NChar, 1) {Value = type}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_CLEARACCESS, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool CopyTo(string sourceGroupCode, string targetGroupCode, short productCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@SourceGroupCode",SqlDbType.VarChar,4000){Value = sourceGroupCode},
                                new SqlParameter("@TargetGroupCode",SqlDbType.VarChar,4000){Value = targetGroupCode},
                                new SqlParameter("@ProductCode", SqlDbType.VarChar,50){Value = productCode},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_COPYTOGROUPROLE_BY_SOURCEGROUPCODE_TARGETGROUPCODE_PRODUCTCODE,
                                          parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据组编号和产品编号获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByGroupCodeAndProductCode(short groupCode, short productCode)
        {
            var parms = new[] {
                new SqlParameter("@GroupCode",SqlDbType.SmallInt){Value = groupCode},
                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode},
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_GROUPCODE_PRODUCTCODE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据组编号和知识库条目号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">知识库条目号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByGroupCodeAndCheckCodeAndType(short groupCode, string checkCode, string type)
        {
            var parms = new[] {
                new SqlParameter("@GroupCode",SqlDbType.SmallInt){Value = groupCode},
                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50){Value = checkCode},
                new SqlParameter("@Type", SqlDbType.NChar,1){Value = type}, 
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_GROUPCODE_CHECKCODE_TYPE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据知识库条目号和知识库条目类型获取组角色。
        /// </summary>
        /// <param name="checkCode">知识库条目号。</param>
        /// <param name="type">知识库条目类型。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByCheckCodeAndType(string checkCode, string type)
        {
            var parms = new[] {
                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50){Value = checkCode},
                new SqlParameter("@Type", SqlDbType.NChar,1){Value = type}, 
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_CHECKCODE_TYPE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号获取组角色。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCode(short productCode)
        {
            var parms = new[] {
                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode},
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text,SQL_SELECT_BY_PRODUCTCODE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据角色编号获取组角色集合。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByRoleCode(short roleCode)
        {
            var parms = new[] {
                new SqlParameter("@RoleCode", SqlDbType.SmallInt){Value = roleCode},
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ROLECODE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号和组名来获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">组名称。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCodeAndName(short productCode, string name)
        {
            var parms = new[] {
                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode},
                new SqlParameter("@Name", SqlDbType.NVarChar,50){Value = name}, 
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_PRODUCTCODE_NAME, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号和组编号获取组角色集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCodeAndGroupCode(short productCode, short groupCode)
        {
            var parms = new[] {
                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode},
                new SqlParameter("@GroupCode", SqlDbType.SmallInt){Value = groupCode}, 
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_PRODUCTCODE_GROUPCODE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据产品编号和组编号和检查对象来获取组角色集合
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByProductCodeAndGroupCodeAndCheckCodeAndType(short productCode, short groupCode, string checkCode, string type)
        {
            var parms = new[] {
                new SqlParameter("@ProductCode", SqlDbType.SmallInt){Value = productCode},
                new SqlParameter("@GroupCode", SqlDbType.SmallInt){Value = groupCode}, 
                new SqlParameter("@CheckCode", SqlDbType.NVarChar,50){Value = checkCode},
                new SqlParameter("@Type", SqlDbType.Char,1){Value = type}, 
            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_PRODUCTCODE_GROUPCODE_CHECKCODE_TYPE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据用户组和访问对象类型获取组角色列表。
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <param name="type">访问对象类型</param>
        /// <returns>组角色集合。</returns>
        public IList<GroupRoleInfo> GetByGroupCodeAndType(short groupCode, string type)
        {
            var parms = new[]
                            {
                                new SqlParameter("@GroupCode", SqlDbType.SmallInt) {Value = groupCode},
                                new SqlParameter("@Type", SqlDbType.NChar, 1) {Value = type},
                            };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_GROUPCODE_TYPE, parms);
            IList<GroupRoleInfo> objs = new ListBase<GroupRoleInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToGroupRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion

    }
}
