// <copyright file="SEModuleInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ��ѯģ����Ϣ��
    /// </summary>
    [Serializable]
    public class SEModuleInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public SEModuleInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ԭʼID��
        /// </summary>
        public string OldId { get; set; }
        /// <summary>
        /// ��ѯģ��Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Id { get; set; }

        /// <summary>
        /// ��Ʒ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }

        /// <summary>
        /// ��ѯģ�����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// ��ѯģ��SQL��ǰ׺��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string SQL { get; set; }
        /// <summary>
        /// ����Where�������ַ�����Where �� And �� Or��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Where { get; set; }
        /// <summary>
        /// ��ѯģ��ı�ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
