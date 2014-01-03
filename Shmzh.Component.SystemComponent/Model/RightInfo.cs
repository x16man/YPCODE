//-----------------------------------------------------------------------
// <copyright file="RightInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 权限代码信息对象.
    /// </summary>
    /// <remarks>对应于数据库PubData库中mySystemRights表的记录.</remarks>
    [Serializable]
    public class RightInfo
    {
        #region 成员变量

#pragma warning disable 169
        //private bool checkright;
#pragma warning restore 169
        #endregion

        #region 属性
        /// <summary>
        /// 原始权限编号。
        /// </summary>
        public short OldRightCode { get; set; }
        /// <summary>
        /// 权限编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RightCode { get; set; }

        /// <summary>
        /// 权限名称名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RightName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 所属产品代码
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }

        /// <summary>
        /// 权限分类
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RightCatCode { get; set; }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public RightInfo()
        {
            this.IsValid = "Y";
        }
        #endregion
    }
}