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
    /// User�û���ժҪ˵����
    /// </summary>
    [Serializable]
    public class Group
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ����Ȩ�ޱ���ж��û��Ƿ�ӵ��Ȩ�޵�SQl��䡣
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
        /// ����Ȩ�ޱ�ź�֪ʶ����ĿID���������ж��û��Ƿ��֪ʶ����Ŀӵ��Ȩ�޵�SQL��䡣
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
        /// �ж�֪ʶ����Ŀ�Ƿ��ǲ��ܹ��Ƶ�SQL��䡣
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
        /// ��ʵ�塣
        /// </summary>
        public GroupInfo thisGroupInfo { get; set; }

        /// <summary>
        /// ��ӵ�еĽ�ɫ��Ϣ.
        /// </summary>
        public ListBase<OwnedRoleInfo> OwenedRoles { get; set; }
        private ListBase<OwnedRoleInfo> ASL { get; set; }

        /// <summary>
        /// ��ɫȨ��.
        /// </summary>
        private ListBase<RoleRightInfo> RoleRights { get; set; }

        #endregion

        #region constranctor
        /// <summary>
        /// �û�ʵ��
        /// </summary>
        /// <param name="obj">��ʵ�塣</param>
        public Group(GroupInfo obj)
        {
            this.thisGroupInfo = obj;
            var productCode = short.Parse(System.Configuration.ConfigurationManager.AppSettings["ProductId"].ToString());
            this.ASL = DataProvider.OwnedRoleProvider.GetAllByProductCode(productCode) as ListBase<OwnedRoleInfo>;
            this.OwenedRoles = DataProvider.OwnedRoleProvider.GetByGroupCode(thisGroupInfo.GroupCode) as ListBase<OwnedRoleInfo>;
            this.RoleRights = DataProvider.RoleRightProvider.GetAllAvalible() as ListBase<RoleRightInfo>;
        }

        /// <summary>
        /// �����û��������û�ʵ��.
        /// </summary>
        /// <param name="groupCode">����.</param>
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
        /// �Ƿ���Ȩ��
        /// </summary>
        /// <param name="rightCode">Ȩ�ޱ��</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode)
        {
            var roles = this.OwenedRoles;
            var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//��ָ��Ȩ������صĽ�ɫ.
            //���������������Ľ�ɫ���ص�,���ʾ��Ȩ��.
            foreach (var obj in roleRights)
            {
                if (roles.Exists(o => o.RoleCode == obj.RoleCode))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// �Ƿ�ӵ��Ȩ�ޣ�����֪ʶ������ʹ�á�
        /// </summary>
        /// <param name="rightCode">Ȩ�ޱ��</param>
        /// <param name="docCode">�ĵ����</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string docCode)
        {
            //return DataProvider.UserProvider.HasRight(rightCode, this.LoginName, docCode);
            return HasRight(rightCode, docCode, "A");
        }

        /// <summary>
        /// �Ƿ�ӵ��Ȩ��(����֪ʶ����)
        /// </summary>
        /// <param name="rightCode">Ȩ�޴���</param>
        /// <param name="checkCode">�ڵ��</param>
        /// <param name="type">���ͣ�Ŀ¼�����£�</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string checkCode, string type)
        {
            var roles = this.OwenedRoles.FindAll(o => o.CheckCode == checkCode && o.Type == type);//��ָ�����ʶ�����صĸ��û��Ľ�ɫ.
            var roleRights = this.RoleRights.FindAll(o => o.RightCode == (short)rightCode);//��ָ��Ȩ������صĽ�ɫ.
            //���������������Ľ�ɫ���ص�,���ʾ��Ȩ��.
            foreach (var obj in roleRights)
            {
                if (roles.Exists(o => o.RoleCode == obj.RoleCode))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// �ж�֪ʶ����Ŀ�Ƿ��ǲ��ܹ��Ƶġ�
        /// </summary>
        /// <param name="checkCode">���»�Ŀ¼��ID��</param>
        /// <param name="type">����(���»�Ŀ¼);</param>
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
