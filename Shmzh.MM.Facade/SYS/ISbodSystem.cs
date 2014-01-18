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
	/// ISbodSystem ��ժҪ˵����
	/// </summary>
	public interface ISbodSystem
	{
	    string GetDocName(short DocCode);
		/// <summary>
		/// ��ȡĳ�ֵ��ݵ�����������
		/// </summary>
		/// <param name="DocCode">int:	�������͡�</param>
		/// <returns>int:	����������</returns>
		int GetAuditLevel(short DocCode);
		/// <summary>
		/// �����û�����ĳ�ֵ��ݵĲ������š�
		/// </summary>
		/// <param name="user">string:	�û���</param>
		/// <param name="roleCode">��ɫId��</param>
		/// <param name="doc">short:	�������͡�</param>
		/// <param name="deptList">string:	�����б�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddUserDocDepts(string user,short roleCode, short doc,string deptList);
		/// <summary>
		/// �����û�����ĳ�ֵ��ݵ����пɲ������š�
		/// </summary>
		/// <param name="user">string:	�û���</param>
		/// <param name="doc">int:	�������͡�</param>
		/// <returns>string:	�����ַ�����</returns>
		string GetAllDeptsByUserAndDoc(string user,short doc);
		/// <summary>
		/// �����û�����ĳ�ֵ��ݵĿɲ������š�
		/// </summary>
		/// <param name="User">string:	��ǰ�û���</param>
		/// <param name="doc">int:	��ǰ���ݡ�</param>
		/// <returns>DeptData:	��������ʵ�塣</returns>
		DeptData GetDeptByUserAndDoc(string User, short doc);
		/// <summary>
		/// ����ͨ�ò�ѯSQL��
		/// </summary>
		/// <param name="sqlStatement">string:	ͨ�ò�ѯ���ɵ�SQL��</param>
		/// <param name="userCode">string:	��ǰ�û���</param>
		/// <param name="docCode">int:	�������͡�</param>
		/// <param name="deptCode">string:	��ǰ����</param>
		/// <returns>string:	�������SQL��䡣</returns>
		string CompleteSQL(string sqlStatement, string userCode, short docCode, string deptCode);
	}

}
