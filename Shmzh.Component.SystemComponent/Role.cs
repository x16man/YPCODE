//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Collections;
    using System.Data;

	/// <summary>
	/// ��ɫӵ�е�Ȩ����Ϣ
	/// </summary>
    //[Serializable]
    //public class RoleRightInfo
    //{
    //    /// <summary>
    //    /// ��ɫ���
    //    /// </summary>
    //    public int RoleCode
    //    {
    //        get{return this.roleCode;}
    //        set{this.roleCode = value;}
    //    }
    //    private int roleCode;

    //    /// <summary>
    //    /// Ȩ�ޱ��
    //    /// </summary>
    //    public int RightCode
    //    {
    //        get{return this.rightCode;}
    //        set{this.rightCode = value;}
    //    }
    //    private int rightCode;
    //    /// <summary>
    //    /// ���캯��
    //    /// </summary>
    //    public RoleRightInfo()
    //    {}
    //}
	
	/// <summary>
	/// RoleInfo ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class Role : Messages
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public Role()
		{
		}
		/// <summary>
		/// ���ӽ�ɫ
		/// </summary>
		/// <param name="user">�û���</param>
		/// <param name="thisRoleInfoList">��ɫ��Ŵ�</param>
		/// <returns>bool</returns>
		public bool AddRole(string user,string thisRoleInfoList)
		{
			return (new RoleDA()).AddRole(user,thisRoleInfoList);
		}
		/// <summary>
		/// ���ӽ�ɫ
		/// </summary>
		/// <param name="roleCode">��ɫ���</param>
		/// <param name="roleName">��ɫ����</param>
		/// <param name="isValid">�Ƿ���Ч</param>
		/// <param name="remark">��ע</param>
		/// <param name="productCode">������Ʒ</param>
		/// <returns>�Ƿ����ӳɹ�</returns>
		public bool AddRole(int roleCode,string roleName,string isValid,string remark,int productCode)
		{
			var ret = true;

			var objRole = new RoleDA();

			if (!objRole.IsExistRole(roleCode,productCode))
			{
				if (!objRole.AddRole(roleCode,roleName,isValid,remark,productCode))
				{
					this.Message = "Please look log";
					ret = false;
				}
			}
			else
			{
				this.Message = "��ɫ�����Ѿ����ڣ������±���";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���ӽ�ɫ
		/// </summary>
		/// <param name="roleName">��ɫ����</param>
		/// <param name="isValid">�Ƿ���Ч</param>
		/// <param name="remark">��ɫ����</param>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>bool</returns>
		public bool AddRole(string roleName,bool isValid,string remark,int productCode)
		{
			bool ret = true;
			RoleDA objRole = new RoleDA();
			if (!objRole.AddRole(roleName,isValid,remark,productCode))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ���Ľ�ɫ
		/// </summary>
		/// <param name="roleCode">��ɫ���</param>
		/// <param name="roleName">��ɫ����</param>
		/// <param name="isValid">�Ƿ���Ч</param>
		/// <param name="remark">��ע</param>
		/// <param name="productCode">������Ʒ</param>
		/// <returns>�Ƿ����ӳɹ�</returns>
		public bool UpdateRole(int roleCode,string roleName,string isValid,string remark,int productCode)
		{
			RoleDA objRole = new RoleDA();
			bool ret = true;

			if (!objRole.UpdateRole(roleCode,roleName,isValid,remark,productCode))
			{
					this.Message = "Please look log";
					ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ɾ����ɫ
		/// </summary>
		/// <param name="roleCode">��ɫ��š�</param>
		/// <param name="productCode">������Ʒ</param>
		/// <returns>bool</returns>
		public bool DeleteRole(int roleCode,int productCode)
		{
			var objRole = new RoleDA();
			var ret = true;

			if (!objRole.DeleteRole(roleCode,productCode))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �õ����еĽ�ɫ
		/// </summary>
		/// <returns>ArrayList</returns>
		public ArrayList GetAllRoles()
		{
			ArrayList role = new ArrayList();
			DataSet ds = new RoleDA().GetAllRoles();
			if (ds != null)
			{
				for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
				{
					RoleInfo objRoleInfo = new RoleInfo();

					objRoleInfo.RoleCode = int.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString());
					objRoleInfo.RoleName = ds.Tables[0].Rows[i]["RoleName"].ToString();

					role.Add(objRoleInfo);
				}
			}
			return role;
		}
		/// <summary>
		/// ��ȡ��Ʒ�����н�ɫ.
		/// </summary>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>ArrayList</returns>
		public ArrayList GetAllRoles(int productCode)
		{
			ArrayList role = new ArrayList();
			DataSet ds = new RoleDA().GetAllRoles(productCode);
			if (ds != null)
			{
				for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
				{
					RoleInfo objRoleInfo = new RoleInfo();

					objRoleInfo.RoleCode = int.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString());
					objRoleInfo.RoleName = ds.Tables[0].Rows[i]["RoleName"].ToString();
					role.Add(objRoleInfo);
				}
			}
			return role;
		}
        public ArrayList GetAllAvalible(int productCode)
        {
            ArrayList roles = new ArrayList();
            DataSet ds = new RoleDA().GetAllAvalibleRoles(productCode);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RoleInfo objRoleInfo = new RoleInfo();

                    objRoleInfo.RoleCode = int.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString());
                    objRoleInfo.RoleName = ds.Tables[0].Rows[i]["RoleName"].ToString();
                    roles.Add(objRoleInfo);
                }
            }
            return roles;
        }
		/// <summary>
		/// ���ݽ�ɫ��źͲ�Ʒ��Ż�ȡ��ɫ��Ϣ
		/// </summary>
		/// <param name="roleCode">��ɫ���</param>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>DataSet</returns>
		public DataSet GetRoleByRoleCode(int roleCode,int productCode)
		{
			return new RoleDA().GetRoleByRoleCode(roleCode,productCode);
		}
		/// <summary>
		/// �õ���ɫ��Ȩ��
		/// </summary>
		/// <returns>ArrayList</returns>
		public ArrayList GetRoleRights()
		{
			ArrayList roleright = new ArrayList();
			DataSet ds = new RoleDA().GetAllRoleRights();
			if (ds != null)
			{
				for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
				{
					var objRoleRightInfo = new RoleRightInfo
					                           {
					                               RightCode = short.Parse(ds.Tables[0].Rows[i]["RightCode"].ToString()),
					                               RoleCode = short.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString())
					                           };

				    roleright.Add(objRoleRightInfo);
				}
			}
			return roleright;
		}
		/// <summary>
		/// ���ӽ�ɫȨ��
		/// </summary>
		/// <param name="roleRightInfo">��ɫȨ��ʵ��</param>
		/// <returns>bool</returns>
		public bool AddRoleRight(RoleRightInfo roleRightInfo)
		{
			return true;
		}
		/// <summary>
		/// �༭��ɫȨ��
		/// </summary>
		/// <param name="roleRightInfo">��ɫȨ�޼�¼ʵ�塣</param>
		/// <returns>bool</returns>
		public bool UpdateRoleRight(RoleRightInfo roleRightInfo)
		{
			return true;
		}
		/// <summary>
		/// ɾ����ɫȨ��
		/// </summary>
		/// <param name="roleRightInfo">��ɫȨ�޼�¼ʵ�塣ʱ</param>
		/// <returns>bool</returns>
		public bool DeleteRoleRight(RoleRightInfo roleRightInfo)
		{
			return true;
		}
		/// <summary>
		/// �õ��û����еĽ�ɫ
		/// </summary>
		/// <param name="thisUserCode">�û���¼����</param>
		/// <returns>ArrayList</returns>
		public ArrayList GetUserRoles(string thisUserCode)
		{
			ArrayList roleinfo = new ArrayList();

			DataSet ds = new UserDA().GetUserRoles(thisUserCode);

			if (ds != null)
			{
				for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
				{
					RoleInfo objRoleInfo = new RoleInfo();

					objRoleInfo.RoleCode = int.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString());
					objRoleInfo.RoleName = ds.Tables[0].Rows[i]["RoleName"].ToString();
					objRoleInfo.ProductCode = int.Parse(ds.Tables[0].Rows[i]["ProductCode"].ToString());
					//objRoleInfo.CheckCode = ds.Tables[0].Rows[i]["CheckCode"].ToString();
					//objRoleInfo.Type = ds.Tables[0].Rows[i]["Type"].ToString();
					roleinfo.Add(objRoleInfo);
				}
			}
			return roleinfo;
		}
		/// <summary>
		/// �����û����Ͳ�Ʒ��Ż�ȡ�û�Ȩ���б�.
		/// </summary>
		/// <param name="userCode">�û���</param>
		/// <param name="productCode">��Ʒ��</param>
		/// <returns>ArrayList</returns>
		public ArrayList GetUserRoles(string userCode, int productCode)
		{
			ArrayList list = new ArrayList();
			DataSet userRoles = new UserDA().GetUserRoles(userCode, productCode);
			if (userRoles != null)
			{
				for (int i = 0; i < userRoles.Tables[0].Rows.Count; i++)
				{
					RoleInfo info = new RoleInfo();
					info.RoleCode = int.Parse(userRoles.Tables[0].Rows[i]["RoleCode"].ToString());
					info.RoleName = userRoles.Tables[0].Rows[i]["RoleName"].ToString();
					info.ProductCode = int.Parse(userRoles.Tables[0].Rows[i]["ProductCode"].ToString());
					//info.CheckCode = userRoles.Tables[0].Rows[i]["CheckCode"].ToString();
					//info.Type = userRoles.Tables[0].Rows[i]["Type"].ToString();
					list.Add(info);
				}
			}
			return list;
		}
		/// <summary>
		/// �����û�����checkcode��type��ȡ��ɫ.
		/// </summary>
		/// <param name="thisUserCode">�û���</param>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">����</param>
		/// <returns>ArrayList</returns>
		public ArrayList GetUserRoles(string thisUserCode,string checkCode,string type)
		{
			ArrayList roleinfo = new ArrayList();

			DataSet ds = new UserDA().GetUserRoles(thisUserCode,checkCode,type);

			if (ds != null)
			{
				for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
				{
					RoleInfo objRoleInfo = new RoleInfo();

					objRoleInfo.RoleCode = int.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString());
					objRoleInfo.RoleName = ds.Tables[0].Rows[i]["RoleName"].ToString();
					objRoleInfo.ProductCode = int.Parse(ds.Tables[0].Rows[i]["ProductCode"].ToString());
					//objRoleInfo.CheckCode = ds.Tables[0].Rows[i]["CheckCode"].ToString();
					//objRoleInfo.Type = ds.Tables[0].Rows[i]["Type"].ToString();
					roleinfo.Add(objRoleInfo);
				}
			}
			return roleinfo;
		}
		/// <summary>
		/// ��ȡ�û����н�ɫ.
		/// </summary>
		/// <param name="thisUserCode">�û���</param>
		/// <returns>ArrayList</returns>
		public ArrayList GetAllUserRoles(string thisUserCode)
		{
			ArrayList roleinfo = new ArrayList();

			DataSet ds = new UserDA().GetAllUserRoles(thisUserCode);

			if (ds != null)
			{
				for (int i = 0;i < ds.Tables[0].Rows.Count;i++)
				{
					RoleInfo objRoleInfo = new RoleInfo();

					objRoleInfo.RoleCode = int.Parse(ds.Tables[0].Rows[i]["RoleCode"].ToString());
					objRoleInfo.RoleName = ds.Tables[0].Rows[i]["RoleName"].ToString();
					objRoleInfo.ProductCode = int.Parse(ds.Tables[0].Rows[i]["ProductCode"].ToString());
					//objRoleInfo.CheckCode = ds.Tables[0].Rows[i]["CheckCode"].ToString();
					//objRoleInfo.Type = ds.Tables[0].Rows[i]["Type"].ToString();
					roleinfo.Add(objRoleInfo);
				}
			}
			return roleinfo;
		}
		/// <summary>
		/// �����û������Ƚ�ɫ���봮�Լ���Ʒ���������û���ɫ.
		/// </summary>
		/// <param name="userCodeList">�û����봮.</param>
		/// <param name="roleCodeList">��ɫ���봮.</param>
		/// <param name="productCode">��Ʒ����.</param>
		/// <returns>bool</returns>
		public bool AddUserRole(string userCodeList, string roleCodeList, int productCode)
		{
			bool flag = true;
			RoleDA eda = new RoleDA();
			if (!eda.AddUserRole(userCodeList, roleCodeList, productCode))
			{
				Message = "Please look log";
				flag = false;
			}
			return flag;
		}
		/// <summary>
		/// �����û���ɫ��
		/// </summary>
		/// <param name="userCodeList">�û�ID����</param>
		/// <param name="roleCodeList">��ɫ��Ŵ���</param>
		/// <param name="checkCode">���»�Ŀ¼ID��</param>
		/// <param name="type">���»�Ŀ¼��</param>
		/// <returns>bool</returns>
		public bool AddUserRole(string userCodeList,string roleCodeList,string checkCode,string type)
		{
			bool ret = true;
			RoleDA obj = new RoleDA();
			if (!obj.AddUserRole(userCodeList,roleCodeList,checkCode,type))
			{
				this.Message = "Please look log";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// �õ��û���ɫ�б�
		/// </summary>
		/// <param name="checkCode">���»�Ŀ¼ID</param>
		/// <param name="type">���»�Ŀ¼</param>
		/// <returns>DataSet</returns>
        /// <remarks>֪ʶ��ʹ�á�</remarks>
		public DataSet GetUsersRoles(string checkCode,string type)
		{
			return new RoleDA().GetUsersRoles(checkCode,type);
		}
        /// <summary>
        /// �õ��û���ɫ�б�
        /// </summary>
        /// <param name="checkCode">���»�Ŀ¼ID��</param>
        /// <param name="type">���»�Ŀ¼��</param>
        /// <returns>DataTable</returns>
        public DataTable GetUsersRoleList(string checkCode, string type)
        {
            RoleDA obj = new RoleDA();
            DataSet ds = obj.GetUsersRoles(checkCode, type);
            DataTable dtUser = obj.GetUsersRoleList(checkCode, type);
            DataTable retDt = new DataTable();
            DataColumn dc = new DataColumn("UserCode");
            retDt.Columns.Add(dc);
            DataColumn dc1 = new DataColumn("EmpName");
            retDt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("RoleCodeList");
            retDt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("RoleNameList");
            retDt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn("CheckCode");
            retDt.Columns.Add(dc4);
            DataColumn dc5 = new DataColumn("Type");
            retDt.Columns.Add(dc5);
            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                var strRoleCodeList = string.Empty;
                var strRoleNameList = string.Empty;
                var empName = string.Empty;

                for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (dtUser.Rows[i]["UserCode"].ToString() != ds.Tables[0].Rows[j]["UserCode"].ToString()) continue;
                    empName = ds.Tables[0].Rows[j]["EmpName"].ToString();

                    if (strRoleCodeList != string.Empty)
                    {
                        strRoleCodeList = strRoleCodeList + "," + ds.Tables[0].Rows[j]["RoleCode"];
                        strRoleNameList = strRoleNameList + "," + ds.Tables[0].Rows[j]["RoleName"];
                    }
                    else
                    {
                        strRoleCodeList = strRoleCodeList + ds.Tables[0].Rows[j]["RoleCode"];
                        strRoleNameList = strRoleNameList + ds.Tables[0].Rows[j]["RoleName"];
                    }
                }	//End for j
                var dr = retDt.NewRow();

                dr["UserCode"] = dtUser.Rows[i]["UserCode"].ToString();
                dr["EmpName"] = empName;
                dr["RoleCodeList"] = strRoleCodeList;
                dr["RoleNameList"] = strRoleNameList;
                dr["CheckCode"] = checkCode;
                dr["Type"] = type;
                retDt.Rows.Add(dr);
            }
            return retDt;
        }
		/// <summary>
		/// ���ݲ�Ʒ�����ȡ�û���ɫ�б�.һ���û�һ����¼����ɫ���ַ���ƴ�ӡ�
		/// </summary>
		/// <param name="productCode">��Ʒ����</param>
		/// <returns>DataTable</returns>
		public DataTable GetUsersRoleListByProduct(int productCode)
		{
			RoleDA myDA = new RoleDA();
            DataSet usersRoles = myDA.GetUsersRolesByProduct(productCode);
            DataTable usersList = myDA.GetLoginNameByProduct(productCode);//��ȡ��Ʒ�������û���
            //���������ݼ��ϳ�һ���û���Ӧһ���ɫ�����ݱ�
            return this.MakeUsersRolesTable(usersList, usersRoles);
		}
        /// <summary>
        /// ���ݲ�Ʒ��źͽ�ɫ��Ż�ȡ�û���ɫ�б�һ���û�һ����¼����ɫ���ַ���ƴ�ӡ�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="roleCode">��ɫ��š�</param>
        /// <returns>DataTable</returns>
        public DataTable GetUsersRolesListByProductAndRole(int productCode, string roleCode)
        {
            RoleDA myDA = new RoleDA();
            DataSet usersRoles = myDA.GetUsersRolesByProduct(productCode);
            DataTable usersList = myDA.GetLoginNameByProductAndRole(productCode, roleCode);
            
            //���������ݼ��ϳ�һ���û���Ӧһ���ɫ�����ݱ�
            return this.MakeUsersRolesTable(usersList, usersRoles);
        }
        /// <summary>
        /// ���ݲ�Ʒ��ź��û�����������ȡ�û���ɫ�б�һ���û�һ����¼����ɫ���ַ���ƴ�ӡ�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="name">�û�����������</param>
        /// <returns>DataTable</returns>
        public DataTable GetUsersRolesListByProductAndName(int productCode, string name)
        {
            RoleDA myDA = new RoleDA();
            DataSet usersRoles = myDA.GetUsersRolesByProductAndName(productCode, name);
            DataTable usersList = myDA.GetLoginNameByProductAndName(productCode, name);
            
            //���������ݼ��ϳ�һ���û���Ӧһ���ɫ�����ݱ�
            return this.MakeUsersRolesTable(usersList, usersRoles);
        }
        /// <summary>
        /// �����û����б���û���ɫ���ݱ���һ��һ���û���Ӧһ����ɫ�б�ļ�¼��
        /// </summary>
        /// <param name="usersList">�û����б�һ�����ݱ�ֻ��UserCodeһ���ֶΡ�</param>
        /// <param name="usersRoles">�û���ɫ���ݼ���һ���û���ֻ��Ӧһ����ɫ�������б�</param>
        /// <returns>һ���û�����Ӧһ���ɫ�ļ�¼��</returns>
        private DataTable MakeUsersRolesTable(DataTable usersList, DataSet usersRoles)
        {
            #region ����һ��DataTable
            DataTable table2 = new DataTable();
            DataColumn column = new DataColumn("UserCode");
            table2.Columns.Add(column);
            DataColumn column2 = new DataColumn("EmpName");
            table2.Columns.Add(column2);
            DataColumn column3 = new DataColumn("RoleCodeList");
            table2.Columns.Add(column3);
            DataColumn column4 = new DataColumn("RoleNameList");
            table2.Columns.Add(column4);
            DataColumn column5 = new DataColumn("CheckCode");
            table2.Columns.Add(column5);
            DataColumn column6 = new DataColumn("Type");
            table2.Columns.Add(column6);
            #endregion

            string roleCodeString, roleNameString, empName;
            foreach (DataRow userRow in usersList.Rows)
            {
                roleCodeString = roleNameString = empName = string.Empty;
                foreach (DataRow userRoleRow in usersRoles.Tables[0].Rows)
                {
                    if (userRow["UserCode"].ToString() == userRoleRow["UserCode"].ToString())
                    {
                        empName = userRoleRow["EmpName"].ToString();
                        roleCodeString += string.Format(roleCodeString.Length > 0 ? ",{0}" : "{0}", userRoleRow["RoleCode"].ToString());
                        roleNameString += string.Format(roleNameString.Length > 0 ? ",{0}" : "{0}", userRoleRow["RoleName"].ToString());
                    }
                }
                DataRow row = table2.NewRow();
                row["UserCode"] = userRow["UserCode"].ToString();
                row["EmpName"] = empName;
                row["RoleCodeList"] = roleCodeString;
                row["RoleNameList"] = roleNameString;
                table2.Rows.Add(row);
            }
            return table2;
        }
	}
}
