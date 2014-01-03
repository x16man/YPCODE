// <copyright file="MapInfo.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Windows.Forms;

namespace DDE2OPC.Model
{
    using System;
    using System.ComponentModel;
    using NDde;
    [Serializable] 
    public class MapInfo
    {
        #region Property
        /// <summary>
        /// 映射ID。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public int Id { get; set; }
        /// <summary>
        /// DDE Topic
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DDETopic { get; set; }

        /// <summary>
        /// DDE Item
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string DDEItem { get; set; }

        /// <summary>
        /// OPC Address
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string OPCAddress { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }

        /// <summary>
        /// DDE Client 对象。
        /// </summary>
        public NDde.Client.DdeClient Client { get; set; }

        /// <summary>
        /// 当前值。
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// ListView Item.
        /// </summary>
        public ListViewItem LVItem { get; set; }
        #endregion

        /// <summary>
		/// 构造函数
		/// </summary>
		public MapInfo()
		{
		}
    }
}
