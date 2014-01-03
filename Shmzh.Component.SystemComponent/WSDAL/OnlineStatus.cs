using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Model;
using Shmzh.Components.Util;

namespace Shmzh.Components.SystemComponent.WSDAL
{
    class OnlineStatus:IOnlineStatus
    {
        #region Implementation of IOnlineStatus

        /// <summary>
        /// 添加用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(OnlineStatusInfo onlineStatus)
        {
            var obj = new OnlineStatusService.OnlineStatusInfo();
            CopyHelper.Copy(onlineStatus,obj);
            return new OnlineStatusService.OnlineStatus().Insert(obj);
        }

        /// <summary>
        /// 修改用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(OnlineStatusInfo onlineStatus)
        {
            var obj = new OnlineStatusService.OnlineStatusInfo();
            CopyHelper.Copy(onlineStatus, obj);
            return new OnlineStatusService.OnlineStatus().Update(obj);
        }

        /// <summary>
        /// 删除用户在线状态记录。
        /// </summary>
        /// <param name="onlineStatus">用户在线状态记录实体。</param>
        /// <returns>bool</returns>
        public bool Delete(OnlineStatusInfo onlineStatus)
        {
            var obj = new OnlineStatusService.OnlineStatusInfo();
            CopyHelper.Copy(onlineStatus, obj);
            return new OnlineStatusService.OnlineStatus().Delete(obj);
        }

        /// <summary>
        /// 根据用户名和IP地址来获取用户在线状态记录实体。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线记录实体。</returns>
        public OnlineStatusInfo GetByUserNameAndIPAddress(string userName, string ipAddress)
        {
            var obj = new OnlineStatusService.OnlineStatus().GetByUserNameAndIPAddress(userName, ipAddress);
            if(obj != null)
            {
                var obj1 = new OnlineStatusInfo();
                CopyHelper.Copy(obj,obj1);
                return obj1;
            }
            return null;
        }

        /// <summary>
        /// 根据用户名获取用户在线记录集合。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>用户在线记录集合。</returns>
        public ListBase<OnlineStatusInfo> GetByUserName(string userName)
        {
            var objs = new OnlineStatusService.OnlineStatus().GetByUserName(userName);
            var obj1s = new ListBase<OnlineStatusInfo>();
            foreach(var obj in objs)
            {
                var obj1 = new OnlineStatusInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据用户名获取用户在线记录集合。
        /// </summary>
        /// <param name="ipAddress">IP地址。</param>
        /// <returns>用户在线记录集合。</returns>
        public ListBase<OnlineStatusInfo> GetByIPAddress(string ipAddress)
        {
            var objs = new OnlineStatusService.OnlineStatus().GetByIPAddress(ipAddress);
            var obj1s = new ListBase<OnlineStatusInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new OnlineStatusInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        /// <summary>
        /// 根据在线用户记录集。
        /// </summary>       
        /// <returns>IList</returns>
        public ListBase<OnlineStatusInfo> GetOnlineUser()
        {
            var objs = new OnlineStatusService.OnlineStatus().GetOnlineUser();
            var obj1s = new ListBase<OnlineStatusInfo>();
            foreach (var obj in objs)
            {
                var obj1 = new OnlineStatusInfo();
                CopyHelper.Copy(obj, obj1);
                obj1s.Add(obj1);
            }
            return obj1s;
        }

        #endregion
    }
}
