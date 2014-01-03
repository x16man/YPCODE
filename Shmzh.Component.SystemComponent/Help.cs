// <copyright file="Help.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System.Data;
	/// <summary>
	/// Help ��ժҪ˵����
	/// </summary>
	public class MzhHelp : Messages
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public MzhHelp()
		{
		}

		/// <summary>
		/// ��ȡ����
		/// </summary>
		/// <param name="code">������š�</param>
		/// <returns>DataSet</returns>
		public DataSet GetHelpInfoByCode(string code)
		{
			return new HelpDA().GetHelpInfoByCode(code);
  		 }
		/// <summary>
		/// ���Ӱ���
		/// </summary>
		/// <param name="code">�������</param>
		/// <param name="title">����</param>
		/// <param name="content">����</param>
		/// <param name="parentcode">�ϼ����</param>
		/// <param name="serial">���</param>
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
		/// ���İ���
		/// </summary>
		/// <param name="code">�������</param>
		/// <param name="title">����</param>
		/// <param name="content">����</param>
		/// <param name="parentcode">�ϼ����</param>
		/// <param name="serial">���</param>
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
		/// ɾ������
		/// </summary>
		/// <param name="code">�������</param>
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
		/// �����ϼ���Ż�ȡ���еİ�����Ϣ.
		/// </summary>
		/// <param name="parentCode">�ϼ��������</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllHelpsByParentCode(string parentCode)
		{
			return new HelpDA().GetAllHelpsByParentCode(parentCode);
		}
	}
}
