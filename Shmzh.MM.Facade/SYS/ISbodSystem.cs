#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved


namespace Shmzh.MM.Facade
{
    using Common;

    /// <summary>
	/// ISbodSystem 的摘要说明。
	/// </summary>
	public interface ISbodSystem
	{
	    string GetDocName(short DocCode);
		/// <summary>
		/// 获取某种单据的审批级数。
		/// </summary>
		/// <param name="DocCode">int:	单据类型。</param>
		/// <returns>int:	审批级数。</returns>
		int GetAuditLevel(short DocCode);
		/// <summary>
		/// 增加用户对于某种单据的操作部门。
		/// </summary>
		/// <param name="user">string:	用户。</param>
		/// <param name="roleCode">角色Id。</param>
		/// <param name="doc">short:	单据类型。</param>
		/// <param name="deptList">string:	部门列表。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddUserDocDepts(string user,short roleCode, short doc,string deptList);
		/// <summary>
		/// 返回用户对于某种单据的所有可操作部门。
		/// </summary>
		/// <param name="user">string:	用户。</param>
		/// <param name="doc">int:	单据类型。</param>
		/// <returns>string:	部门字符串。</returns>
		string GetAllDeptsByUserAndDoc(string user,short doc);
		/// <summary>
		/// 返回用户对于某种单据的可操作部门。
		/// </summary>
		/// <param name="User">string:	当前用户。</param>
		/// <param name="doc">int:	当前单据。</param>
		/// <returns>DeptData:	部门数据实体。</returns>
		DeptData GetDeptByUserAndDoc(string User, short doc);
		/// <summary>
		/// 完整通用查询SQL。
		/// </summary>
		/// <param name="sqlStatement">string:	通用查询生成的SQL。</param>
		/// <param name="userCode">string:	当前用户。</param>
		/// <param name="docCode">int:	单据类型。</param>
		/// <param name="deptCode">string:	当前部门</param>
		/// <returns>string:	完整后的SQL语句。</returns>
		string CompleteSQL(string sqlStatement, string userCode, short docCode, string deptCode);
	}

}
