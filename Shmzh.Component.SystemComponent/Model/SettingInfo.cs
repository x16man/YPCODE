namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
	/// <summary>
	/// ϵͳ������Ϣ��
	/// </summary>
	public class SettingInfo
	{
		/// <summary>
		/// ���캯����
		/// </summary>
		public SettingInfo()
		{
        }

        #region Property
        /// <summary>
        /// ���ü����ơ�
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Key { get; set; }
        /// <summary>
        /// ���ü�ֵ��
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Value { get; set; }
        /// <summary>
        /// ����˵����
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// ���÷��ࡣ
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Category { get; set; }
        #endregion

	}
}
