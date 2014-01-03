using System.Web.Services;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;


namespace Shmzh.SystemComponent.WebService
{
    /// <summary>
    /// 系统管理中OnlineStatus 的WebService接口.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "系统管理中OnlineStatus 的WebService接口.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class OnlineStatus : System.Web.Services.WebService,IOnlineStatus
    {
        #region Implementation of IOnlineStatus

        /// <summary>
        /// 添加用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "添加用户在线状态记录")]
        public bool Insert(OnlineStatusInfo onlineStatus)
        {
            return DataProvider.OnlineStatusProvider.Insert(onlineStatus);
        }

        /// <summary>
        /// 修改用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "修改用户在线状态记录")]
        public bool Update(OnlineStatusInfo onlineStatus)
        {
            return DataProvider.OnlineStatusProvider.Update(onlineStatus);
        }

        /// <summary>
        /// 删除用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        [WebMethod(Description = "删除用户在线状态记录")]
        public bool Delete(OnlineStatusInfo onlineStatus)
        {
            return DataProvider.OnlineStatusProvider.Delete(onlineStatus);
        }

        /// <summary>
        /// 根据用户名和IP地址来获取用户在线状态记录实体。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线记录实体。</returns>
        [WebMethod(Description = "根据用户名和IP地址来获取用户在线状态记录实体。")]
        public OnlineStatusInfo GetByUserNameAndIPAddress(string userName, string ipAddress)
        {
            return DataProvider.OnlineStatusProvider.GetByUserNameAndIPAddress(userName, ipAddress);
        }

        /// <summary>
        /// 根据用户名获取用户在线记录集合。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>用户在线记录集合。</returns>
        [WebMethod(Description = "根据用户名和IP地址来获取用户在线状态记录实体。")]
        public ListBase<OnlineStatusInfo> GetByUserName(string userName)
        {
            return DataProvider.OnlineStatusProvider.GetByUserName(userName);
        }

        /// <summary>
        /// 根据用户名获取用户在线记录集合。
        /// </summary>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线记录集合。</returns>a
        [WebMethod(Description = "根据用户名获取用户在线记录集合.")]
        public ListBase<OnlineStatusInfo> GetByIPAddress(string ipAddress)
        {
            return DataProvider.OnlineStatusProvider.GetByIPAddress(ipAddress);
        }

        /// <summary>
        /// 根据在线用户记录集。
        /// </summary>       
        /// <returns>IList</returns>
        [WebMethod(Description = "根据在线用户记录集.")]
        public ListBase<OnlineStatusInfo> GetOnlineUser()
        {
            return DataProvider.OnlineStatusProvider.GetOnlineUser();
        }

        #endregion
    }
}
