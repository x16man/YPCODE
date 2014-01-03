// <copyright file="OwnedRoleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// 角色与访问对象的关系实体。
    /// </summary>
    /// <remarks>主要为知识库所用，知识库条目和角色之间的关系。</remarks>
    [Serializable]
    public class OwnedRoleInfo
    {
        #region CTOR
        /// <summary>
        /// 构造函数。
        /// </summary>
        public OwnedRoleInfo()
        {
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <param name="checkCode">知识库条目ID。</param>
        /// <param name="type">知识库条目类型。</param>
        public OwnedRoleInfo(short roleCode, string checkCode, string type)
        {
            this.RoleCode = roleCode;
            this.CheckCode = checkCode;
            this.Type = type;
        }
        #endregion

        #region Property
        /// <summary>
        /// 角色编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RoleCode { get; set; }
        /// <summary>
        /// 知识库条目ID(非KM系统无意义)。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }
        /// <summary>
        /// 知识库条目类型(非KM系统无意义)
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Type { get; set; }
        #endregion
    }
}
