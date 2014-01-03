// <copyright file="OnlineStatus.cs" company="Shmzh Technology">
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
    public class MenuInfo
    {
        #region Field

        #endregion

        #region Constructor
        ///<summary>
        /// 默认构造函数。
        ///</summary>
        public MenuInfo()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">用户名。</param>
        /// <param name="name">IP地址。</param>
        /// <param name="title">在线状态。</param>
        /// <param name="productId">心跳时间。</param>
        /// <param name="rightCode">权限编码。</param>
        /// <param name="parentId">上级菜单Id。</param>
        /// <param name="order">序号。</param>
        /// <param name="level">层次。</param>
        /// <param name="urlType">URL类型</param>
        /// <param name="url">URL地址。</param>
        /// <param name="imageUrl">图片地址。</param>
        /// <param name="cssClass">css样式。</param>
        /// <param name="isEnable">是否有效。</param>
        /// <param name="hasSubMenu">是否有子菜单。</param>
        /// <param name="type">菜单类型。</param>
        /// <param name="remark">备注。</param>
        /// <param name="checkCode">检查对象标识。</param>
        /// <param name="objType">检查对象类型。</param>
        public MenuInfo(int id, string name, string title, int productId,int rightCode, int parentId, 
            int order,int level,int urlType,string url, string imageUrl, 
            string cssClass, int isEnable, int hasSubMenu, int type, string remark, string checkCode, string objType)
            
        {
            this.ID = id;
            this.Name = name;
            this.Title = title;
            this.ProductID = productId;
            this.RightCode = rightCode;
            this.ParentID = parentId;
            this.Order = order;
            this.Level = level;
            this.URLType = urlType;
            this.URL = url;
            this.ImageURL = imageUrl;
            this.CSSClass = cssClass;
            this.IsEnable = isEnable;
            this.HasSubMenu = hasSubMenu;
            this.Type = type;
            this.Remark = remark;
            this.CheckCode = checkCode;
            this.ObjType = objType;
        }
        
        #endregion

        #region Property
        /// <summary>
        /// 菜单ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ID { get; set; }
        /// <summary>
        /// 菜单名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Title { get; set; }
        /// <summary>
        /// 所属产品ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProductID { get; set; }
        /// <summary>
        /// 权限编号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RightCode { get; set; }
        /// <summary>
        /// 上级菜单ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentID { get; set; }
        /// <summary>
        /// 顺序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Order { get; set; }
        /// <summary>
        /// 层次。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Level { get; set; }
        /// <summary>
        /// URL类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int URLType { get; set; }
        /// <summary>
        /// URL。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string URL { get; set; }
        /// <summary>
        /// 图片地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ImageURL { get; set; }
        /// <summary>
        /// CSS样式。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CSSClass { get; set; }
        /// <summary>
        /// 是否有效。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int IsEnable { get; set; }
        /// <summary>
        /// 是否有子菜单。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int HasSubMenu { get; set; }
        /// <summary>
        /// 菜单类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Type { get; set; }
        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// 检查对象标识。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }

        /// <summary>
        /// 标识对象类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ObjType { get; set; }


        #endregion
    }
}
