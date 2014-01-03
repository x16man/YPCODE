// <copyright file="OnlineStatus.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ����Ϣ
    /// </summary>
    [Serializable]
    public class OnlineStatusInfo
    {
        #region Constructor
        ///<summary>
        /// Ĭ�Ϲ��캯����
        ///</summary>
        public OnlineStatusInfo()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="userName">�û�����</param>
        /// <param name="ipAddress">IP��ַ��</param>
        /// <param name="status">����״̬��</param>
        /// <param name="beatTime">����ʱ�䡣</param>
        public OnlineStatusInfo(string userName, string ipAddress, string status, DateTime beatTime)
        {
            this.UserName = userName;
            this.IPAddress = ipAddress;
            this.Status = status;
            this.BeatTime = beatTime;
        }
        
        #endregion

        #region Property
        /// <summary>
        /// �û�����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string UserName { get; set; }

        /// <summary>
        /// IP��ַ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IPAddress { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Status { get; set; }

        /// <summary>
        /// ����ʱ�䡣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime BeatTime { get; set; }
        #endregion
    }
}
