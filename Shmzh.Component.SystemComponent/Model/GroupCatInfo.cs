// <copyright file="GroupCatInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 组分类信息
    /// </summary>
    [Serializable]
    public class GroupCatInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public GroupCatInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 组分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Id { get; set; }

        /// <summary>
        /// 组分类名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 组分类描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short SerialNo { get; set; }


        #endregion
    }
}
