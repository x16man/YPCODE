//-----------------------------------------------------------------------
// <copyright file="Messages.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
	/// <summary>
	/// Messages 的摘要说明。
	/// </summary>
	[Serializable]
	public class Messages
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Messages()
		{
		}

		/// <summary>
		/// 消息
		/// </summary>
		public string Message
		{
			get{return this.message;}
			set{this.message = value;}
		}
        private string message = string.Empty;
	}
} 
