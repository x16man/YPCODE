//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	///		UserSystem ��ժҪ˵����
	///     <remarks>
	///         �ṩ�����û����ݵ�Ψһ�Ľӿ�
	///     </remarks>
	///     <remarks>
	///         �ṩԶ�̵���
	///     </remarks>
	/// </summary>
    public class SysSystem : MarshalByRefObject, ISbodSystem, ISTAGSystem, ISwitchSystem//, IDeptSystem, IUserSystem
	{
		private string _Message=string.Empty;

		public string Message
		{
			get{return _Message;}
		}

		#region ISbodSystem ��Ա
        /// <summary>
        /// ��ȡ�����������ơ�
        /// </summary>
        /// <param name="DocCode">�������ͱ�š�</param>
        /// <returns>�����������ơ�</returns>
        public string GetDocName(short DocCode)
        {
            return new SBODs().GetDocNameByDocCode(DocCode);
        }
		/// <summary>
		/// ��ȡ���ݵ�����������
		/// </summary>
		/// <param name="DocCode">int:	�������͡�</param>
		/// <returns>int:	������</returns>
		public int GetAuditLevel(short DocCode)
		{
            return new SBODs().GetAuditLevelByDocCode(DocCode);
		}
		/// <summary>
		/// ��ȡ���б���
		/// </summary>
		/// <returns>SBODData:	����������ʵ�塣</returns>
		public SBODData GetAllBillOfDocs()
		{
			return new SBODs().GetAllBillOfDocs();
		}
		/// <summary>
		/// �����û�����ĳ�ֵ��ݵĲ���Ȩ�ޡ�
		/// </summary>
		/// <param name="userCode">string:	�û���</param>
		/// <param name="docCode">int:	�������͡�</param>
		/// <param name="deptList">string:	�����б�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool AddUserDocDepts(string userCode,short roleCode, short docCode,string deptList)
		{
			return new SBODs().AddUserDocDepts(userCode,roleCode,docCode,deptList);
		}
		/// <summary>
		/// �����û����͵������͵õ������ַ���
		/// </summary>
		/// <param name="user"></param>
		/// <param name="doc"></param>
		/// <returns></returns>
		public string GetAllDeptsByUserAndDoc(string user,short doc)
		{
			System.Data.DataTable dt=new SBODs().GetAllDeptsByUserAndDoc(user,doc);
			
			string deptlist="";

			if (dt!=null)
			{
				for(int i=0;i<dt.Rows.Count;i++)
				{
					if(deptlist!="")
					{
						deptlist=deptlist+",'" + dt.Rows[i]["DeptCode"] + "'";
					}
					else
					{
						deptlist=deptlist+"'" + dt.Rows[i]["DeptCode"] + "'";
					}
				}
			}
			return deptlist;
		}
        /// <summary>
        /// �����û���¼�����������͡���ɫId��ȡ���Ŵ���
        /// </summary>
        /// <param name="user">�û���¼��</param>
        /// <param name="doc">��������</param>
        /// <param name="role">��ɫId</param>
        /// <returns>���Ŵ�</returns>
        public string GetAllDeptsByUserAndDocAndRole(string user,short doc,short role)
        {
            System.Data.DataTable dt = new SBODs().GetAllDeptsByUserAndDocAndRole(user, doc, role);

            string deptlist = "";

            if (dt != null)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    deptlist = deptlist != ""
                                   ? deptlist + ",'" + dt.Rows[i]["DeptCode"] + "'"
                                   : deptlist + "'" + dt.Rows[i]["DeptCode"] + "'";
                }
            }
            return deptlist;
        }
		/// <summary>
		/// ��ȡĳ���û�����ĳ�ֵ��ݵĿɲ������š�
		/// </summary>
		/// <param name="userCode">string:	�û���</param>
		/// <param name="docCode">int:	���ݡ�</param>
		/// <returns>DeptData:	��������ʵ�塣</returns>
		public DeptData GetDeptByUserAndDoc(string userCode, short docCode)
		{
		    var oDeptData = new SBODs().GetDeptByUserAndDoc(userCode, docCode);
		    return oDeptData;
		}

	    /// <summary>
		/// ����ͨ�ò�ѯ��
		/// </summary>
		/// <param name="sqlStatement">string:	ͨ�ò�ѯ�����ɵ�SQL.</param>
		/// <param name="userCode">string:	��ǰ�û���</param>
		/// <param name="docCode">int:	��ǰ�ĵ��ݡ�</param>
		/// <param name="deptCode">int:	��ǰ�Ĳ��š�</param>
		/// <returns>string:	SQL��䡣</returns>
		public string CompleteSQL(string sqlStatement, string userCode, short docCode, string deptCode)
		{
	        var attachStatement = this.GetAllDeptsByUserAndDoc(userCode, docCode);
			if (string.IsNullOrEmpty(attachStatement))
			{
				attachStatement = "'"+deptCode+"'";
			}
			if (sqlStatement.IndexOf("where") > 0 || sqlStatement.IndexOf("Where") > 0 )
			{
				switch (docCode)
				{
					case DocType.ROS:
						sqlStatement += " And ReqDept In (" + attachStatement + ")";
						break;
					case DocType.MRP:
						sqlStatement  += " And ReqDept In (" + attachStatement + ")";
						break;
					case DocType.PP:
						sqlStatement += "  And ReqDept In ("+attachStatement+")";
						break;
					case DocType.PO:
                        sqlStatement += " And ReqDept In (" + attachStatement + ")";
						break;
					case DocType.BOR:
                        sqlStatement += " And AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.DRW:
                        sqlStatement += " And AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.RTS:
                        sqlStatement += " And AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.RTV:
                        sqlStatement += " And AuthorDept In (" + attachStatement + ")";
						break;
				}
			}
			else
			{
				switch (docCode)
				{
					case DocType.ROS:
                        sqlStatement += " where ReqDept In (" + attachStatement + ")";
						break;
					case DocType.MRP:
                        sqlStatement += " where ReqDept In (" + attachStatement + ")";
						break;
					case DocType.PP:
                        sqlStatement += " where ReqDept In (" + attachStatement + ")";
						break;
					case DocType.PO:
                        sqlStatement += " where AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.BOR:
                        sqlStatement += " where AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.DRW:
                        sqlStatement += " where AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.RTS:
                        sqlStatement += " where AuthorDept In (" + attachStatement + ")";
						break;
					case DocType.RTV:
                        sqlStatement += " where AuthorDept In (" + attachStatement + ")";
						break;
				}
			}
            return sqlStatement;
		}
		#endregion

		#region ISTAGSystem ��Ա
		/// <summary>
		/// ��ȡ���ݲɼ�ϵͳ��������Ϣ��
		/// </summary>
		/// <returns>STAGData:	���ݲɼ�ϵͳ��������Ϣ��</returns>
		public STAGData GetSTAGInfo()
		{
			STAGData oSTAGData;
			oSTAGData = new STAGs().GetSTAGInfo();
			return oSTAGData;
		}

		#endregion

		#region ISwitchSystem ��Ա
		/// <summary>
		/// �Ƿ����Ʋɹ�������������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		public bool IsOrdNumLimit()
		{
			return new Switchs().OrdNumEnable();
		}
		/// <summary>
		/// �Ƿ����Ʋɹ����ϵ��������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		public bool IsBorItemLimit()
		{
			return new Switchs().BorItemEnable();
		}
		/// <summary>
		/// �Ƿ����Ʋɹ����ϵ�������������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		public bool IsBorNumLimit()
		{
			return new Switchs().BorNumEnable();
		}

		#endregion
	}
}
