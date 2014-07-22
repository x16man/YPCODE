// <copyright file="OnlineStatusDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{    
    [Serializable]
    /// <summary>
    /// 在线状态类。
    /// </summary>
    public class OnlineStatus : MarshalByRefObject, IOnlineStatus
    {
        private static Shmzh.Components.SystemComponent.IDAL.IOnlineStatus dal;
        static OnlineStatus()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.OnlineStatusProvider;
        }
        #region ITemplate 成员
        /// <summary>
        /// 增加。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态实体。</param>
        /// <returns>bool</returns>
        public bool Insert(OnlineStatusInfo onlineStatus)
        {
            return dal.Insert(onlineStatus);
        }

        /// <summary>
        /// 修改。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态实体。</param>
        /// <returns>bool</returns>
        public bool Update(OnlineStatusInfo onlineStatus)
        {
            return dal.Update(onlineStatus);
        }
        
        /// <summary>
        /// 删除。
        /// </summary>
        /// <param name="onlineStatus"></param>
        /// <returns></returns>
        public bool Delete(OnlineStatusInfo onlineStatus)
        {
            return dal.Delete(onlineStatus);
        }

        /// <summary>
        /// 根据用户名和IP地址获取用户在线状态记录。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线状态实体。</returns>
        public OnlineStatusInfo GetByUserNameAndIPAddress(string userName, string ipAddress)
        {
            return dal.GetByUserNameAndIPAddress(userName, ipAddress);
        }
       
        /// <summary>
        /// 根据用户名获取用户在线状态记录集。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>IList</returns>
        public ListBase<OnlineStatusInfo> GetByUserName(string userName)
        {
            return dal.GetByUserName(userName);
        }

        /// <summary>
        /// 根据IP地址获取用户在线状态记录集。
        /// </summary>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>IList。</returns>
        public ListBase<OnlineStatusInfo> GetByIPAddress(string ipAddress)
        {
            return dal.GetByIPAddress(ipAddress);
        }
        
        /// <summary>
        /// 根据在线用户记录集。
        /// </summary>       
        /// <returns>IList</returns>
        public ListBase<OnlineStatusInfo> GetOnlineUser()
        {
            return dal.GetOnlineUser();
        }         
        #endregion

    }
}
