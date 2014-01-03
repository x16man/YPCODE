// <copyright file="GroupInfo.cs" company="Shmzh Technology">
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
    public class DeptInfo
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public DeptInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// 部门编号
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCode { get; set; }

        /// <summary>
        /// 部门所属公司代码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCo { get; set; }

        /// <summary>
        /// 部门中文名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCnName { get; set; }
        /// <summary>
        /// 部门英文名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptEnName { get; set; }
        /// <summary>
        /// 上级部门编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentDept { get; set; }
        /// <summary>
        /// 上级部门名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentDeptName { get; set; }
        /// <summary>
        /// 部门主管用户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptMgr { get; set; }
        /// <summary>
        /// 部门主管名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptMgrName { get; set; }
        /// <summary>
        /// 部门级别。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DeptLevel { get; set; }
        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Serial { get; set; }
        /// <summary>
        /// 类型ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeId { get; set; }
        /// <summary>
        /// 类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeName { get; set; }
        /// <summary>
        /// 成本中心。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CostCenter { get; set; }
        /// <summary>
        /// 创建日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        /// <summary>
        /// 是否在其他系统中显示。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ShowInOtherSys { get; set; }
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
