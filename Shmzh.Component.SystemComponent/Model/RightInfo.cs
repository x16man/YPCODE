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
    /// Ȩ�޴�����Ϣ����.
    /// </summary>
    /// <remarks>��Ӧ�����ݿ�PubData����mySystemRights��ļ�¼.</remarks>
    [Serializable]
    public class RightInfo
    {
        #region ��Ա����

#pragma warning disable 169
        //private bool checkright;
#pragma warning restore 169
        #endregion

        #region ����
        /// <summary>
        /// ԭʼȨ�ޱ�š�
        /// </summary>
        public short OldRightCode { get; set; }
        /// <summary>
        /// Ȩ�ޱ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short RightCode { get; set; }

        /// <summary>
        /// Ȩ����������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RightName { get; set; }

        /// <summary>
        /// �Ƿ���Ч
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }

        /// <summary>
        /// Ȩ������
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// ������Ʒ����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short ProductCode { get; set; }

        /// <summary>
        /// Ȩ�޷���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RightCatCode { get; set; }

        #endregion

        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public RightInfo()
        {
            this.IsValid = "Y";
        }
        #endregion
    }
}