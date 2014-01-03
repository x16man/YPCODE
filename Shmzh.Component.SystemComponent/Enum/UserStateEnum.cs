using System;

namespace Shmzh.Components.SystemComponent.Enum
{
    ///<summary>
    /// 用户状态枚举类。
    ///</summary>
    [Serializable]
    public sealed class UserStateEnum
    {
        /// <summary>
        /// 激活的
        /// </summary>
        public const string ACTIVED = "A";
        /// <summary>
        /// 不激活的
        /// </summary>
        public const string UNACTIVED = "U";
    }
}
