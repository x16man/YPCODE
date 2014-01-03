namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.ComponentModel;
	/// <summary>
	/// 系统配置信息表。
	/// </summary>
	public class SettingInfo
	{
		/// <summary>
		/// 构造函数。
		/// </summary>
		public SettingInfo()
		{
        }

        #region Property
        /// <summary>
        /// 配置键名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Key { get; set; }
        /// <summary>
        /// 配置键值。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Value { get; set; }
        /// <summary>
        /// 配置说明。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        /// <summary>
        /// 配置分类。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Category { get; set; }
        #endregion

	}
}
