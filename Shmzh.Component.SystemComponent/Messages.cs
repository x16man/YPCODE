//-----------------------------------------------------------------------
// <copyright file="Messages.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
	/// <summary>
	/// Messages ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class Messages
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public Messages()
		{
		}

		/// <summary>
		/// ��Ϣ
		/// </summary>
		public string Message
		{
			get{return this.message;}
			set{this.message = value;}
		}
        private string message = string.Empty;
	}
} 
