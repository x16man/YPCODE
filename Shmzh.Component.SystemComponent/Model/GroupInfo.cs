// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 组信息
    /// </summary>
    [Serializable]
    public class GroupInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public GroupInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 组编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short GroupCode { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string GroupName { get; set; }

        /// <summary>
        /// 组描述
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short SerialNo { get; set; }
        /// <summary>
        /// 组分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short GroupCatId { get; set; }
        #endregion
    }
}
