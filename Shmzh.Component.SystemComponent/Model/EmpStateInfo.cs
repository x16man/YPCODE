// <copyright file="GroupInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
    /// <summary>
    /// Ա��״̬��Ϣ
    /// </summary>
    [Serializable]
    public class EmpStateInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public EmpStateInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// Ա��״̬���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }

        /// <summary>
        /// Ա��״̬����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Description { get; set; }

        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        #endregion
    }
}
