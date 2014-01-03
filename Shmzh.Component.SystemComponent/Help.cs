// <copyright file="Help.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System.Data;
	/// <summary>
	/// Help 的摘要说明。
	/// </summary>
	public class MzhHelp : Messages
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public MzhHelp()
		{
		}

		/// <summary>
		/// 获取帮助
		/// </summary>
		/// <param name="code">帮助编号。</param>
		/// <returns>DataSet</returns>
		public DataSet GetHelpInfoByCode(string code)
		{
			return new HelpDA().GetHelpInfoByCode(code);
  		 }
		/// <summary>
		/// 增加帮助
		/// </summary>
		/// <param name="code">帮助编号</param>
		/// <param name="title">标题</param>
		/// <param name="content">内容</param>
		/// <param name="parentcode">上级编号</param>
		/// <param name="serial">序号</param>
		/// <returns>bool</returns>
		public bool AddHelpInfo(string code,string title,string content,string parentcode,int serial)
		{
			var ret = true;
		    var obj = new HelpInfo {Code = code, Title = title, Content = content, ParentCode = parentcode, Serial = serial};
		    var objDA = new HelpDA();
			if (!objDA.AddHelpInfo(obj))
			{
				this.Message = objDA.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 更改帮助
		/// </summary>
		/// <param name="code">帮助编号</param>
		/// <param name="title">标题</param>
		/// <param name="content">内容</param>
		/// <param name="parentcode">上级编号</param>
		/// <param name="serial">序号</param>
		/// <returns>bool</returns>
		public bool UpdateHelpInfo(string code,string title,string content,string parentcode,int serial)
		{
			var ret = true;
			var obj = new HelpInfo {Code = code, Title = title, Content = content, ParentCode = parentcode, Serial = serial};
		    var objDA = new HelpDA();
			if (!objDA.UpdateHelpInfo(obj))
			{
				this.Message = objDA.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 删除帮助
		/// </summary>
		/// <param name="code">帮助编号</param>
		/// <returns>bool</returns>
		public bool DeleteHelpInfo(string code)
		{
			var ret = true;
			if (!new HelpDA().DeleteHelpInfo(code))
			{
				this.Message = "Please look log!";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据上级编号获取所有的帮助信息.
		/// </summary>
		/// <param name="parentCode">上级帮助编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllHelpsByParentCode(string parentCode)
		{
			return new HelpDA().GetAllHelpsByParentCode(parentCode);
		}
	}
}
