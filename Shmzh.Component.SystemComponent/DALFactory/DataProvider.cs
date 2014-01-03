using System;
using System.Configuration;

namespace Shmzh.Components.SystemComponent.DALFactory
{
    /// <summary>
    /// 依据配置文件以抽象工厂模式来创建数据访问层.
    /// </summary>
    public static class DataProvider
    {
        private static readonly string systemDAL = ConfigurationManager.AppSettings["SystemDAL"];

        #region Property
        /// <summary>
        /// 模板对象的数据访问对象.
        /// </summary>
        public static IDAL.ITemplate TemplateProvider
        {
#pragma warning disable 618,612
            get { return CreateTemplateProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 智能桌面系统在线状态的数据访问对象。
        /// </summary>
        public static IDAL.IOnlineStatus OnlineStatusProvider
        {
#pragma warning disable 618,612
            get { return CreateOnlineStatusProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 消息对象的数据访问对象。
        /// </summary>
        public static IDAL.I_SD_Message SD_MessageProvider
        {
#pragma warning disable 618,612
            get { return CreateSD_MessageProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 消息类型对象的数据访问对象。
        /// </summary>
        public static IDAL.I_SD_MessageType SD_MessageTypeProvider
        {
#pragma warning disable 618,612
            get { return CreateSD_MessageTypeProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 菜单对象的数据访问对象。
        /// </summary>
        public static IDAL.IMenu MenuProvider
        {
#pragma warning disable 618,612
            get { return CreateMenuProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 菜单类型的数据访问对象。
        /// </summary>
        public static IDAL.IMenuType MenuTypeProvider
        {
#pragma warning disable 618,612
            get { return CreateMenuTypeProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 用户人员的数据访问对象。
        /// </summary>
        public static IDAL.IUser UserProvider
        {
#pragma warning disable 618,612
            get { return CreateUserProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 组分类的数据访问对象。
        /// </summary>
        public static IDAL.IGroupCat GroupCatProvider
        {
#pragma warning disable 618,612
            get { return CreateGroupCatProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 组的数据访问对象。
        /// </summary>
        public static IDAL.IGroup GroupProvider
        {
#pragma warning disable 618,612
            get { return CreateGroupProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 角色的数据访问对象。
        /// </summary>
        public static IDAL.IRole RoleProvider
        {
#pragma warning disable 618,612
            get { return CreateRoleProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 用户角色的数据访问对象。
        /// </summary>
        public static IDAL.IUserRole UserRoleProvider
        {
#pragma warning disable 618,612
            get { return CreateUserRoleProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 角色权限的数据访问对象。
        /// </summary>
        public static IDAL.IRoleRight RoleRightProvider
        {
#pragma warning disable 618,612
            get { return CreateRoleRightProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 授权的数据访问对象。
        /// </summary>
        public static IDAL.IGrant GrantProvider
        {
#pragma warning disable 618,612
            get { return CreateGrantProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 组角色的数据访问对象。
        /// </summary>
        public static IDAL.IGroupRole GroupRoleProvider
        {
#pragma warning disable 618,612
            get { return CreateGroupRoleProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 组用户的数据访问对象。
        /// </summary>
        public static IDAL.IGroupUser GroupUserProvider
        {
#pragma warning disable 618,612
            get { return CreateGroupUserProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 权限分类的数据访问对象。
        /// </summary>
        public static IDAL.IRightCat RightCatProvider
        {
#pragma warning disable 618,612
            get { return CreateRightCatProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 权限的数据访问对象。
        /// </summary>
        public static IDAL.IRight RightProvider
        {
#pragma warning disable 618,612
            get { return CreateRightProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 公司的数据访问对象。
        /// </summary>
        public static IDAL.ICompany CompanyProvider
        {
#pragma warning disable 618,612
            get { return CreateCompanyProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 职务的数据访问对象。
        /// </summary>
        public static IDAL.IDuty DutyProvider
        {
#pragma warning disable 618,612
            get { return CreateDutyProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 部门的数据访问对象。
        /// </summary>
        public static IDAL.IDept DeptProvider
        {
#pragma warning disable 618,612
            get { return CreateDeptProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 组织机构类型的数据访问对象。
        /// </summary>
        public static IDAL.IOrgType OrgTypeProvider
        {
#pragma warning disable 618,612
            get { return CreateOrgTypeProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 员工状态的数据访问对象。
        /// </summary>
        public static IDAL.IEmpState EmpStateProvider
        {
#pragma warning disable 618,612
            get { return CreateEmpStateProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 产品的数据访问对象。
        /// </summary>
        public static IDAL.IProduct ProductProvider
        {
#pragma warning disable 618,612
            get { return CreateProductProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 角色与访问对象的关系的数据访问对象。
        /// </summary>
        public static IDAL.IOwnedRole OwnedRoleProvider
        {
#pragma warning disable 618,612
            get { return CreateOwnedRoleProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 查询模块的数据访问对象。
        /// </summary>
        public static IDAL.ISEModule SEModuleProvider
        {
#pragma warning disable 618,612
            get { return CreateSEModuleProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 查询引擎控件的数据访问对象。
        /// </summary>
        public static IDAL.ISEControl SEControlProvider
        {
#pragma warning disable 618,612
            get { return CreateSEControlProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 查询引擎的控件类型的数据访问对象。
        /// </summary>
        public static IDAL.ISEControlType SEControlTypeProvider
        {
#pragma warning disable 618,612
            get { return CreateSEControlTypeProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 查询引擎的数据类型的数据访问对象。
        /// </summary>
        public static IDAL.ISEDataType SEDataTypeProvider
        {
#pragma warning disable 618,612
            get { return CreateSEDataTypeProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 查询方案的数据访问对象。
        /// </summary>
        public static IDAL.ISESchema SESchemaProvider
        {
#pragma warning disable 618,612
            get { return CreateSESchemaProvider(); }
#pragma warning restore 618,612
        }

        /// <summary>
        /// 开关量的数据访问对象。
        /// </summary>
        public static IDAL.ISetting SettingProvider
        {
#pragma warning disable 618,612
            get { return CreateSettingInfoProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 工作流用户详细信息的数据访问接口.
        /// </summary>
        public static IDAL.IUserDetail UserDetailProvider
        {
            get
            {
                return CreateUserDetailProvider();
            }
        }
        /// <summary>
        /// 工作流用户数据访问对象。
        /// </summary>
        public static IDAL.ITB_Users TB_UsersProvider
        {
#pragma warning disable 618,612
            get { return CreateTB_UsersInfoProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 工作流组织机构数据访问对象。
        /// </summary>
        public static IDAL.ITB_ORGTREE TB_OrgTreeProvider
        {
#pragma warning disable 618,612
            get { return CreateTB_OrgTreeProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 工作流组织机构与人员的关联关系的数据访问对象。
        /// </summary>
        public static IDAL.ITB_ORGMEMLK TB_OrgMemLkProvider
        {
#pragma warning disable 618,612
            get { return CreateTB_ORGMEMLKProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 工作流组织机构类型的数据访问对象。
        /// </summary>
        public static IDAL.ITB_SYSORGTP TB_SYSORGTPProvider
        {
#pragma warning disable 618,612
            get { return CreateTB_SYSORTTPProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 工作流用户分类数据访问对象。
        /// </summary>
        public static IDAL.ITB_UserCat TB_UserCatProvider
        {
#pragma warning disable 618,612
            get { return CreateTB_UserCatProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 工作流系统同步标志。
        /// </summary>
        public static IDAL.ITB_SYN TB_SYNProvider
        {
            get { return CreateTB_SYNProvider(); }
        }
        /// <summary>
        /// 工作流领导类型。
        /// </summary>
        public static IDAL.ITB_SYSLDTP TB_SYSLDTPProvider
        {
            get { return CreateTB_SYSLDTPProvider(); }
        }
        /// <summary>
        /// 工作流部门领导。
        /// </summary>
        public static IDAL.ITB_ORGLDLNK TB_ORGLDLNKProvider
        {
            get { return CreateTB_ORGLDLNKProvider(); }
        }
        /// <summary>
        /// 系统访问记录的数据访问对象。
        /// </summary>
        public static IDAL.IHistory HistoryProvider
        {
#pragma warning disable 618,612
            get { return CreateHistoryProvider(); }
#pragma warning restore 618,612
        }
        /// <summary>
        /// 操作日志的数据访问对象。
        /// </summary>
        public static IDAL.IOperationLog OperationLogProvider
        {
#pragma warning disable 618,612
            get { return CreateOperationLogProvider(); }
#pragma warning restore 618,612
        }
        #endregion

        #region Method
        /// <summary>
        /// 创建模板对象的数据访问对象。
        /// </summary>
        /// <returns>模板对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)] 
        public static IDAL.ITemplate CreateTemplateProvider()
        {
            var className = string.Format("{0}.Template",systemDAL);
            var classType = Type.GetType(className); 
            return (IDAL.ITemplate) Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建在线状态的数据访问对象。
        /// </summary>
        /// <returns>在线状态的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IOnlineStatus CreateOnlineStatusProvider()
        {
            var className = string.Format("{0}.OnlineStatus", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IOnlineStatus)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建消息对象的数据访问对象。
        /// </summary>
        /// <returns>消息对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.I_SD_Message CreateSD_MessageProvider()
        {
            var className = string.Format("{0}.SD_Message", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.I_SD_Message)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建消息类型对象的数据访问对象。
        /// </summary>
        /// <returns>消息类型对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.I_SD_MessageType CreateSD_MessageTypeProvider()
        {
            var className = string.Format("{0}.SD_MessageType", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.I_SD_MessageType)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建菜单对象的数据访问对象。
        /// </summary>
        /// <returns>菜单对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IMenu CreateMenuProvider()
        {
            var className = string.Format("{0}.Menu", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IMenu)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建用户对象的数据访问对象。
        /// </summary>
        /// <returns>用户对象的数据访问对象</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IUser CreateUserProvider()
        {
            var className = string.Format("{0}.User", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IUser)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建组分类的数据访问对象。
        /// </summary>
        /// <returns>组分类的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IGroupCat CreateGroupCatProvider()
        {
            var className = string.Format("{0}.GroupCat", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IGroupCat)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建组信息对象的数据访问对象。
        /// </summary>
        /// <returns>组信息对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IGroup CreateGroupProvider()
        {
            var className = string.Format("{0}.Group", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IGroup) Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建角色信息对象的数据访问对象。
        /// </summary>
        /// <returns>角色信息对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IRole CreateRoleProvider()
        {
            var className = string.Format("{0}.Role", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IRole)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建用户角色信息对象的数据访问对象。
        /// </summary>
        /// <returns>用户角色信息对象的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IUserRole CreateUserRoleProvider()
        {
            var className = string.Format("{0}.UserRole", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IUserRole)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建角色权限的数据访问对象。
        /// </summary>
        /// <returns>角色权限的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IRoleRight CreateRoleRightProvider()
        {
            var className = string.Format("{0}.RoleRight", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IRoleRight)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建授权信息的数据访问对象。
        /// </summary>
        /// <returns>授权信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IGrant CreateGrantProvider()
        {
            var className = string.Format("{0}.Grant", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IGrant)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建组角色信息的数据访问对象。
        /// </summary>
        /// <returns>组角色信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IGroupRole CreateGroupRoleProvider()
        {
            var className = string.Format("{0}.GroupRole", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IGroupRole)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建组用户信息的数据访问对象。
        /// </summary>
        /// <returns>组用户信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IGroupUser CreateGroupUserProvider()
        {
            var className = string.Format("{0}.GroupUser", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IGroupUser)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建权限分组的数据访问对象。
        /// </summary>
        /// <returns>权限分组的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IRightCat CreateRightCatProvider()
        {
            var className = string.Format("{0}.RightCat", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IRightCat)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建权限的数据访问对象。
        /// </summary>
        /// <returns>权限的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IRight CreateRightProvider()
        {
            var className = string.Format("{0}.Right", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IRight)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建公司信息的数据访问对象。
        /// </summary>
        /// <returns>公司信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ICompany CreateCompanyProvider()
        {
            var className = string.Format("{0}.Company", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ICompany)Activator.CreateInstance(classType);    
        }

        /// <summary>
        /// 创建职务信息的数据访问对象。
        /// </summary>
        /// <returns>职务信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IDuty CreateDutyProvider()
        {
            var className = string.Format("{0}.Duty", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IDuty) Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建部门信息的数据访问对象。
        /// </summary>
        /// <returns>部门信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IDept CreateDeptProvider()
        {
            var className = string.Format("{0}.Dept", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IDept)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建部门信息的数据访问对象。
        /// </summary>
        /// <returns>部门信息的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IOrgType CreateOrgTypeProvider()
        {
            var className = string.Format("{0}.OrgType", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IOrgType)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建员工状态的数据访问对象。
        /// </summary>
        /// <returns>员工状态的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IEmpState CreateEmpStateProvider()
        {
            var className = string.Format("{0}.EmpState", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IEmpState)Activator.CreateInstance(classType);
        }

        ///<summary>
        /// 创建产品的数据访问对象。
        ///</summary>
        ///<returns>产品的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IProduct CreateProductProvider()
        {
            var className = string.Format("{0}.Product", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IProduct)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建菜单类型的数据访问对象。
        /// </summary>
        /// <returns>菜单类型的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IMenuType CreateMenuTypeProvider()
        {
            var className = string.Format("{0}.MenuType", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IMenuType)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建角色与访问对象的关系的数据访问对象。
        /// </summary>
        /// <returns></returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.IOwnedRole CreateOwnedRoleProvider()
        {
            var className = string.Format("{0}.OwnedRole", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IOwnedRole)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建查询模块的数据访问对象。
        /// </summary>
        /// <returns>查询模块的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ISEModule CreateSEModuleProvider()
        {
            var className = string.Format("{0}.SEModule", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ISEModule)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建查询引擎控件的数据访问对象。
        /// </summary>
        /// <returns>查询引擎控件的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ISEControl CreateSEControlProvider()
        {
            var className = string.Format("{0}.SEControl", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ISEControl)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建查询引擎的控件类型的数据访问对象。
        /// </summary>
        /// <returns>查询引擎的控件类型的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ISEControlType CreateSEControlTypeProvider()
        {
            var className = string.Format("{0}.SEControlType", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ISEControlType)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建查询引擎的数据类型的数据访问对象。
        /// </summary>
        /// <returns>查询引擎的数据类型的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ISEDataType CreateSEDataTypeProvider()
        {
            var className = string.Format("{0}.SEDataType", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ISEDataType)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建查询方案的数据访问对象。
        /// </summary>
        /// <returns>查询方案的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ISESchema CreateSESchemaProvider()
        {
            var className = string.Format("{0}.SESchema", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ISESchema)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 开关量的数据访问对象。
        /// </summary>
        /// <returns>开关量的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ISetting CreateSettingInfoProvider()
        {
            var className = string.Format("{0}.Setting", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ISetting)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建工作流用户详细信息的数据访问对象.
        /// </summary>
        /// <returns>工作流用户详细信息的数据访问对象.</returns>
        public static IDAL.IUserDetail CreateUserDetailProvider()
        {
            var className = string.Format("{0}.UserDetail", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IUserDetail)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 创建工作流用户的数据访问对象。
        /// </summary>
        /// <returns>工作流用户的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ITB_Users CreateTB_UsersInfoProvider()
        {
            var className = string.Format("{0}.TB_Users", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_Users)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建工作流组织机构的数据访问对象。
        /// </summary>
        /// <returns>工作流组织机构的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ITB_ORGTREE CreateTB_OrgTreeProvider()
        {
            var className = string.Format("{0}.TB_ORGTREE", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_ORGTREE)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建工作流组织机构类型的数据访问对象。
        /// </summary>
        /// <returns>工作流组织机构类型的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ITB_SYSORGTP CreateTB_SYSORTTPProvider()
        {
            var className = string.Format("{0}.TB_SYSORGTP", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_SYSORGTP)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 创建工作流组织机构与人员关联的数据访问对象。
        /// </summary>
        /// <returns>工作流组织机构与人员关联的数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ITB_ORGMEMLK CreateTB_ORGMEMLKProvider()
        {
            var className = string.Format("{0}.TB_ORGMEMLK", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_ORGMEMLK)Activator.CreateInstance(classType);
        }
        
        /// <summary>
        /// 创建用户分类数据访问对象。
        /// </summary>
        /// <returns>用户分类数据访问对象。</returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        public static IDAL.ITB_UserCat CreateTB_UserCatProvider()
        {
            var className = string.Format("{0}.TB_UserCat", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_UserCat)Activator.CreateInstance(classType);
        }

        /// <summary>
        /// 东兰同步标志表
        /// </summary>
        /// <returns></returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。",false)]
        public static IDAL.ITB_SYN CreateTB_SYNProvider()
        {
            var className = string.Format("{0}.TB_SYN", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_SYN)Activator.CreateInstance(classType);
        }
        private static IDAL.ITB_SYSLDTP CreateTB_SYSLDTPProvider()
        {
            var className = string.Format("{0}.TB_SYSLDTP", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_SYSLDTP)Activator.CreateInstance(classType);
        }
        private static IDAL.ITB_ORGLDLNK CreateTB_ORGLDLNKProvider()
        {
            var className = string.Format("{0}.TB_ORGLDLNK", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.ITB_ORGLDLNK)Activator.CreateInstance(classType);
        }
        /// <summary>
        /// 系统访问记录的数据访问对象。
        /// </summary>
        /// <returns></returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        private static IDAL.IHistory CreateHistoryProvider()
        {
            var className = string.Format("{0}.History", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IHistory)Activator.CreateInstance(classType);    
        }
        /// <summary>
        /// 创建操作日志的数据访问对象。
        /// </summary>
        /// <returns></returns>
        [Obsolete("该方法已经过期,请勿再使用!请使用属性对象。", false)]
        private static IDAL.IOperationLog CreateOperationLogProvider()
        {
            var className = string.Format("{0}.OperationLog", systemDAL);
            var classType = Type.GetType(className);
            return (IDAL.IOperationLog)Activator.CreateInstance(classType);    
        }
        #endregion
    }
}
