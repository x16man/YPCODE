//-----------------------------------------------------------------------
// <copyright file="Group.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Web.Security;
using System.Configuration;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.OleDb;

    using Shmzh.Components.SystemComponent.DALFactory;

    /// <summary>
    /// User用户的摘要说明。
    /// </summary>
    [Serializable]
    public class Group
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 根据权限编号判断用户是否拥有权限的SQl语句。
        /// </summary>
        private const string SQL_HASRIGHT_BY_RIGHTCODE = @"
SELECT  COUNT(*)
FROM    dbo.mySystemRoleRights
WHERE   RightCode = @RightCode AND
        RoleCode IN ( SELECT    DISTINCT RoleCode
                      FROM      dbo.mySystemGroupRoles a
                      WHERE     GroupCode = @GroupCode And
                                EXISTS ( SELECT *
                                         FROM   mysystemroles b
                                         WHERE  a.RoleCode = b.RoleCode AND
                                                b.IsValid = 'Y' ) )";
        /// <summary>
        /// 根据权限编号和知识库项目ID和类型来判断用户是否对知识库项目拥有权限的SQL语句。
        /// </summary>
        private const string SQL_HASRIGHT_BY_RIGHTCODE_CHECKCODE_TYPE = @"
SELECT  COUNT(*)
FROM    dbo.mySystemRoleRights
WHERE   RightCode = @RightCode AND
        RoleCode IN ( SELECT    DISTINCT RoleCode
                      FROM      dbo.mySystemGroupRoles a
                      WHERE     CheckCode = @CheckCode And
                                Type = @Type And
                                GroupCode = @GroupCode And 
                                EXISTS ( SELECT *
                                         FROM   mysystemroles b
                                         WHERE  a.RoleCode = b.RoleCode AND
                                                b.IsValid = 'Y' ) )";
        /// <summary>
        /// 判断知识库条目是否是不受管制的SQL语句。
        /// </summary>
        private const string SQL_ISUNMANAGED_BY_CHECKCODE_TYPE = @"
SELECT  COUNT(*)
FROM    dbo.ViewUsersRoles a
WHERE   CheckCode = @CheckCode AND
        [Type] = @Type AND
        EXISTS ( SELECT *
                 FROM   dbo.mySystemRoles b
                 WHERE  a.RoleCode = b.RoleCode AND
                        b.IsValid = 'Y' )
";
        #endregion

        #region property

        /// <summary>
        /// 组实体。
        /// </summary>
        public GroupInfo thisGroupInfo { get; set; }

        /// <summary>
        /// 组拥有的角色信息.
        /// </summary>
        public ListBase<OwnedRoleInfo> OwenedRoles { get; set; }
        private ListBase<OwnedRoleInfo> ASL { get; set; }

        /// <summary>
        /// 角色权限.
        /// </summary>
        private ListBase<RoleRightInfo> RoleRights { get; set; }

        #endregion

        #region constranctor
        /// <summary>
        /// 用户实例
        /// </summary>
        /// <param name="obj">组实体。</param>
        public Group(GroupInfo obj)
        {
            this.thisGroupInfo = obj;
            var productCode = short.Parse(System.Configuration.ConfigurationManager.AppSettings["ProductId"].ToString());
            this.ASL = DataProvider.OwnedRoleProvider.GetAllByProductCode(productCode) as ListBase<OwnedRoleInfo>;
            this.OwenedRoles = DataProvider.OwnedRoleProvider.GetByGroupCode(thisGroupInfo.GroupCode) as ListBase<OwnedRoleInfo>;
            this.RoleRights = DataProvider.RoleRightProvider.GetAllAvalible() as ListBase<RoleRightInfo>;
        }

        /// <summary>
        /// 根据用户名构造用户实例.
        /// </summary>
        /// <param name="groupCode">组编号.</param>
        public Group(short groupCode)
        {
            this.thisGroupInfo = DataProvider.GroupProvider.GetByCode(groupCode);
            
            var productCode = short.Parse(System.Configuration.ConfigurationManager.AppSettings["ProductId"].ToString());
            this.ASL = DataProvider.OwnedRoleProvider.GetAllByProductCode(productCode) as ListBase<OwnedRoleInfo>;
            this.OwenedRoles = DataProvider.OwnedRoleProvider.GetByGroupCode(thisGroupInfo.GroupCode) as ListBase<OwnedRoleInfo>;
            this.RoleRights = DataProvider.RoleRightProvider.GetAllAvalible() as ListBase<RoleRightInfo>;
        }
        
        #endregion

        #region public methods
        /// <summary>
        /// 是否有权限
        /// </summary>
        /// <param name="rightCode">权限编号</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode)
        {
            var roles = this.OwenedRoles;
            var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//和指定权限码相关的角色.
            //如果以上两个对象的角色有重叠,则表示有权限.
            foreach (var obj in roleRights)
            {
                if (roles.Exists(o => o.RoleCode == obj.RoleCode))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 是否拥有权限，仅限知识库文章使用。
        /// </summary>
        /// <param name="rightCode">权限编号</param>
        /// <param name="docCode">文档编号</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string docCode)
        {
            //return DataProvider.UserProvider.HasRight(rightCode, this.LoginName, docCode);
            return HasRight(rightCode, docCode, "A");
        }

        /// <summary>
        /// 是否拥有权限(适用知识管理)
        /// </summary>
        /// <param name="rightCode">权限代码</param>
        /// <param name="checkCode">节点号</param>
        /// <param name="type">类型（目录、文章）</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string checkCode, string type)
        {
            var roles = this.OwenedRoles.FindAll(o => o.CheckCode == checkCode && o.Type == type);//和指定访问对象相关的该用户的角色.
            var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//和指定权限码相关的角色.
            //如果以上两个对象的角色有重叠,则表示有权限.
            foreach (var obj in roleRights)
            {
                if (roles.Exists(o => o.RoleCode == obj.RoleCode))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 判断知识库项目是否是不受管制的。
        /// </summary>
        /// <param name="checkCode">文章或目录的ID。</param>
        /// <param name="type">类型(文章或目录);</param>
        /// <returns>bool</returns>
        public bool IsUnManaged(string checkCode, string type)
        {
            return this.ASL == null || !this.ASL.Exists(o => o.CheckCode == checkCode && o.Type == type);
        }

        
        #endregion

        #region private functions

        #endregion
    }
}
