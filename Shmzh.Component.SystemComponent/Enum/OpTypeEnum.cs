using System;

namespace Shmzh.Components.SystemComponent.Enum
{
    ///<summary>
    /// 操作日志类型枚举。
    ///</summary>
    [Serializable]
    public sealed class OpTypeEnum
    {
        /// <summary>
        /// 用户操作。
        /// </summary>
        public const string UserOperation = "User";
        /// <summary>
        /// 角色权限操作。
        /// </summary>
        public const string RoleRightOperation = "RoleRight";
        /// <summary>
        /// 用户角色操作。
        /// </summary>
        public const string UserRoleOperation = "UserRole";

    }
}

