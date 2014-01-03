// <copyright file="RoleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 部门信息实体。
    /// </summary>
    [Serializable]
    public class RoleInfo
    {
        #region CTOR
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 角色编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RoleName { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        /// <summary>
        /// 角色描述。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProductCode { get; set; }
        /// <summary>
        /// 顺序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int SerialNo { get; set; }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}{1}- RoleCode: {2}{1}- RoleName: {3}{1}- ProductCode: {4}{1}",
                                 this.GetType(),
                                 System.Environment.NewLine,
                                 this.RoleCode,
                                 this.RoleName,
                                 this.ProductCode);
        }
    }
}
