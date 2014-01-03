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
    public class MenuInfo
    {
        #region Field

        #endregion

        #region Constructor
        ///<summary>
        /// Ĭ�Ϲ��캯����
        ///</summary>
        public MenuInfo()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="id">�û�����</param>
        /// <param name="name">IP��ַ��</param>
        /// <param name="title">����״̬��</param>
        /// <param name="productId">����ʱ�䡣</param>
        /// <param name="rightCode">Ȩ�ޱ��롣</param>
        /// <param name="parentId">�ϼ��˵�Id��</param>
        /// <param name="order">��š�</param>
        /// <param name="level">��Ρ�</param>
        /// <param name="urlType">URL����</param>
        /// <param name="url">URL��ַ��</param>
        /// <param name="imageUrl">ͼƬ��ַ��</param>
        /// <param name="cssClass">css��ʽ��</param>
        /// <param name="isEnable">�Ƿ���Ч��</param>
        /// <param name="hasSubMenu">�Ƿ����Ӳ˵���</param>
        /// <param name="type">�˵����͡�</param>
        /// <param name="remark">��ע��</param>
        /// <param name="checkCode">�������ʶ��</param>
        /// <param name="objType">���������͡�</param>
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
        /// �˵�ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ID { get; set; }
        /// <summary>
        /// �˵����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Title { get; set; }
        /// <summary>
        /// ������ƷID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProductID { get; set; }
        /// <summary>
        /// Ȩ�ޱ�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RightCode { get; set; }
        /// <summary>
        /// �ϼ��˵�ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParentID { get; set; }
        /// <summary>
        /// ˳��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Order { get; set; }
        /// <summary>
        /// ��Ρ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Level { get; set; }
        /// <summary>
        /// URL���͡�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int URLType { get; set; }
        /// <summary>
        /// URL��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string URL { get; set; }
        /// <summary>
        /// ͼƬ��ַ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ImageURL { get; set; }
        /// <summary>
        /// CSS��ʽ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CSSClass { get; set; }
        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int IsEnable { get; set; }
        /// <summary>
        /// �Ƿ����Ӳ˵���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int HasSubMenu { get; set; }
        /// <summary>
        /// �˵����͡�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Type { get; set; }
        /// <summary>
        /// ��ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// �������ʶ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CheckCode { get; set; }

        /// <summary>
        /// ��ʶ�������͡�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ObjType { get; set; }


        #endregion
    }
}
