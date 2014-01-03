// <copyright file="SEControlParamInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// ��ѯģ��ؼ�������Ϣ��
    /// </summary>
    [Serializable]
    public class SEControlParamInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public SEControlParamInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ��ѯģ��ؼ�����Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }

        /// <summary>
        /// ��ѯģ��ؼ�Id��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ControlId { get; set; }

        
        /// <summary>
        /// ��ѯģ��ؼ��������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParamName { get; set; }

        /// <summary>
        /// �������͡�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ParamType { get; set; }
        /// <summary>
        /// ����ֵ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParamValue { get; set; }
        /// <summary>
        /// ������š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public byte ParamIndex { get; set; }
        #endregion
    }
}
