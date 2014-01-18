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
	///		UserSystem 的摘要说明。
	///     <remarks>
	///         提供操作用户数据的唯一的接口
	///     </remarks>
	///     <remarks>
	///         提供远程调用
	///     </remarks>
	/// </summary>
    public class SysSystem : MarshalByRefObject, ISbodSystem, ISTAGSystem, ISwitchSystem//, IDeptSystem, IUserSystem
	{
		private string _Message=string.Empty;

		public string Message
		{
			get{return _Message;}
		}

		#region ISbodSystem 成员
        /// <summary>
        /// 获取单据类型名称。
        /// </summary>
        /// <param name="DocCode">单据类型编号。</param>
        /// <returns>单据类型名称。</returns>
        public string GetDocName(short DocCode)
        {
            return new SBODs().GetDocNameByDocCode(DocCode);
        }
		/// <summary>
		/// 获取单据的审批级数。
		/// </summary>
		/// <param name="DocCode">int:	单据类型。</param>
		/// <returns>int:	级数。</returns>
		public int GetAuditLevel(short DocCode)
		{
            return new SBODs().GetAuditLevelByDocCode(DocCode);
		}
		/// <summary>
		/// 获取所有表单。
		/// </summary>
		/// <returns>SBODData:	表单类型数据实体。</returns>
		public SBODData GetAllBillOfDocs()
		{
			return new SBODs().GetAllBillOfDocs();
		}
		/// <summary>
		/// 增加用户对于某种单据的操作权限。
		/// </summary>
		/// <param name="userCode">string:	用户。</param>
		/// <param name="docCode">int:	单据类型。</param>
		/// <param name="deptList">string:	部门列表。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool AddUserDocDepts(string userCode,short roleCode, short docCode,string deptList)
		{
			return new SBODs().AddUserDocDepts(userCode,roleCode,docCode,deptList);
		}
		/// <summary>
		/// 根据用户名和单据类型得到部门字符串
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
        /// 根据用户登录名、单据类型、角色Id获取部门串。
        /// </summary>
        /// <param name="user">用户登录名</param>
        /// <param name="doc">单据类型</param>
        /// <param name="role">角色Id</param>
        /// <returns>部门串</returns>
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
		/// 获取某个用户对于某种单据的可操作部门。
		/// </summary>
		/// <param name="userCode">string:	用户。</param>
		/// <param name="docCode">int:	单据。</param>
		/// <returns>DeptData:	部门数据实体。</returns>
		public DeptData GetDeptByUserAndDoc(string userCode, short docCode)
		{
		    var oDeptData = new SBODs().GetDeptByUserAndDoc(userCode, docCode);
		    return oDeptData;
		}

	    /// <summary>
		/// 完整通用查询。
		/// </summary>
		/// <param name="sqlStatement">string:	通用查询中生成的SQL.</param>
		/// <param name="userCode">string:	当前用户。</param>
		/// <param name="docCode">int:	当前的单据。</param>
		/// <param name="deptCode">int:	当前的部门。</param>
		/// <returns>string:	SQL语句。</returns>
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

		#region ISTAGSystem 成员
		/// <summary>
		/// 获取数据采集系统的配置信息。
		/// </summary>
		/// <returns>STAGData:	数据采集系统的配置信息。</returns>
		public STAGData GetSTAGInfo()
		{
			STAGData oSTAGData;
			oSTAGData = new STAGs().GetSTAGInfo();
			return oSTAGData;
		}

		#endregion

		#region ISwitchSystem 成员
		/// <summary>
		/// 是否限制采购订单的数量。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		public bool IsOrdNumLimit()
		{
			return new Switchs().OrdNumEnable();
		}
		/// <summary>
		/// 是否限制采购收料单的物料项。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		public bool IsBorItemLimit()
		{
			return new Switchs().BorItemEnable();
		}
		/// <summary>
		/// 是否限制采购收料单的物料数量。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		public bool IsBorNumLimit()
		{
			return new Switchs().BorNumEnable();
		}

		#endregion
	}
}
