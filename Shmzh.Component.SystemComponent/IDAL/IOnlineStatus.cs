using System.Collections.Generic;

namespace Shmzh.Components.SystemComponent.IDAL
{
    /// <summary>
    /// 用户在线状态数据访问接口。
    /// </summary>
    public interface IOnlineStatus
    {
        /// <summary>
        /// 添加用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        bool Insert(OnlineStatusInfo onlineStatus);
        /// <summary>
        /// 修改用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        bool Update(OnlineStatusInfo onlineStatus);
        /// <summary>
        /// 删除用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        bool Delete(OnlineStatusInfo onlineStatus);
        /// <summary>
        /// 根据用户名和IP地址来获取用户在线状态记录实体。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线记录实体。</returns>
        OnlineStatusInfo GetByUserNameAndIPAddress(string userName, string ipAddress);
        /// <summary>
        /// 根据用户名获取用户在线记录集合。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>用户在线记录集合。</returns>
        ListBase<OnlineStatusInfo> GetByUserName(string userName);
        /// <summary>
        /// 根据用户名获取用户在线记录集合。
        /// </summary>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线记录集合。</returns>
        ListBase<OnlineStatusInfo> GetByIPAddress(string ipAddress);
        /// <summary>
        /// 根据在线用户记录集。
        /// </summary>       
        /// <returns>IList</returns>
        ListBase<OnlineStatusInfo> GetOnlineUser();
    }
}
