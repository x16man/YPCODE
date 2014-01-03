// <copyright file="RoleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ������Ϣʵ�塣
    /// </summary>
    [Serializable]
    public class RoleInfo
    {
        #region CTOR
        /// <summary>
        /// ���캯��
        /// </summary>
        public RoleInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ��ɫ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int RoleCode { get; set; }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RoleName { get; set; }
        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        /// <summary>
        /// ��ɫ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ProductCode { get; set; }
        /// <summary>
        /// ˳��š�
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
