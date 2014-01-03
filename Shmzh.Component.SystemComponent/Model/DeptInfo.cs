// <copyright file="GroupInfo.cs" company="Shmzh Technology">
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
    public class DeptInfo
    {
        #region Constructor
        /// <summary>
        /// ���캯��
        /// </summary>
        public DeptInfo()
        { }
        #endregion

        #region Property
        /// <summary>
        /// ���ű��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCode { get; set; }

        /// <summary>
        /// ����������˾���롣
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCo { get; set; }

        /// <summary>
        /// �����������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptCnName { get; set; }
        /// <summary>
        /// ����Ӣ�����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptEnName { get; set; }
        /// <summary>
        /// �ϼ����ű�š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentDept { get; set; }
        /// <summary>
        /// �ϼ��������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ParentDeptName { get; set; }
        /// <summary>
        /// ���������û�����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptMgr { get; set; }
        /// <summary>
        /// �����������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DeptMgrName { get; set; }
        /// <summary>
        /// ���ż���
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short DeptLevel { get; set; }
        /// <summary>
        /// ��š�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public short Serial { get; set; }
        /// <summary>
        /// ����ID��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeId { get; set; }
        /// <summary>
        /// �������ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string TypeName { get; set; }
        /// <summary>
        /// �ɱ����ġ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CostCenter { get; set; }
        /// <summary>
        /// �������ڡ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// �Ƿ���Ч��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string IsValid { get; set; }
        /// <summary>
        /// �Ƿ�������ϵͳ����ʾ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int ShowInOtherSys { get; set; }
        /// <summary>
        /// ��ע��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
