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
	/// 角色拥有的权限信息
	/// </summary>
    //[Serializable]
    //public class RoleRightInfo
    //{
    //    /// <summary>
    //    /// 角色编号
    //    /// </summary>
    //    public int RoleCode
    //    {
    //        get{return this.roleCode;}
    //        set{this.roleCode = value;}
    //    }
    //    private int roleCode;

    //    /// <summary>
    //    /// 权限编号
    //    /// </summary>
    //    public int RightCode
    //    {
    //        get{return this.rightCode;}
    //        set{this.rightCode = value;}
    //    }
    //    private int rightCode;
    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    public RoleRightInfo()
    //    {}
    //}
	
	/// <summary>
	/// RoleInfo 的摘要说明。
	/// </summary>
	[Serializable]
	public class Role : Messages
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Role()
		{
		}
		/// <summary>
		/// 增加角色
		/// </summary>
		/// <param name="user">用户名</param>
		/// <param name="thisRoleInfoList">角色编号串</param>
		/// <returns>bool</returns>
		public bool AddRole(string user,string thisRoleInfoList)
		{
			return (new RoleDA()).AddRole(user,thisRoleInfoList);
		}
		/// <summary>
		/// 增加角色
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="roleName">角色名称</param>
		/// <param name="isValid">是否有效</param>
		/// <param name="remark">备注</param>
		/// <param name="productCode">所属产品</param>
		/// <returns>是否增加成功</returns>
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
				this.Message = "角色编码已经存在，请重新编码";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 增加角色
		/// </summary>
		/// <param name="roleName">角色名称</param>
		/// <param name="isValid">是否有效</param>
		/// <param name="remark">角色描述</param>
		/// <param name="productCode">产品编号</param>
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
		/// 更改角色
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="roleName">角色名称</param>
		/// <param name="isValid">是否有效</param>
		/// <param name="remark">备注</param>
		/// <param name="productCode">所属产品</param>
		/// <returns>是否增加成功</returns>
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
		/// 删除角色
		/// </summary>
		/// <param name="roleCode">角色编号。</param>
		/// <param name="productCode">所属产品</param>
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
		/// 得到所有的角色
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
		/// 获取产品的所有角色.
		/// </summary>
		/// <param name="productCode">产品编号</param>
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
		/// 根据角色编号和产品编号获取角色信息
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="productCode">产品编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetRoleByRoleCode(int roleCode,int productCode)
		{
			return new RoleDA().GetRoleByRoleCode(roleCode,productCode);
		}
		/// <summary>
		/// 得到角色的权限
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
		/// 增加角色权限
		/// </summary>
		/// <param name="roleRightInfo">角色权限实体</param>
		/// <returns>bool</returns>
		public bool AddRoleRight(RoleRightInfo roleRightInfo)
		{
			return true;
		}
		/// <summary>
		/// 编辑角色权限
		/// </summary>
		/// <param name="roleRightInfo">角色权限记录实体。</param>
		/// <returns>bool</returns>
		public bool UpdateRoleRight(RoleRightInfo roleRightInfo)
		{
			return true;
		}
		/// <summary>
		/// 删除角色权限
		/// </summary>
		/// <param name="roleRightInfo">角色权限记录实体。时</param>
		/// <returns>bool</returns>
		public bool DeleteRoleRight(RoleRightInfo roleRightInfo)
		{
			return true;
		}
		/// <summary>
		/// 得到用户所有的角色
		/// </summary>
		/// <param name="thisUserCode">用户登录名。</param>
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
		/// 根据用户名和产品编号获取用户权限列表.
		/// </summary>
		/// <param name="userCode">用户名</param>
		/// <param name="productCode">产品码</param>
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
		/// 根据用户名和checkcode和type获取角色.
		/// </summary>
		/// <param name="thisUserCode">用户名</param>
		/// <param name="checkCode">checkCode</param>
		/// <param name="type">类型</param>
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
		/// 获取用户所有角色.
		/// </summary>
		/// <param name="thisUserCode">用户名</param>
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
		/// 根据用户名串喝角色代码串以及产品代码增加用户角色.
		/// </summary>
		/// <param name="userCodeList">用户代码串.</param>
		/// <param name="roleCodeList">角色代码串.</param>
		/// <param name="productCode">产品代码.</param>
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
		/// 增加用户角色。
		/// </summary>
		/// <param name="userCodeList">用户ID串。</param>
		/// <param name="roleCodeList">角色编号串。</param>
		/// <param name="checkCode">文章或目录ID。</param>
		/// <param name="type">文章或目录。</param>
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
		/// 得到用户角色列表
		/// </summary>
		/// <param name="checkCode">文章或目录ID</param>
		/// <param name="type">文章或目录</param>
		/// <returns>DataSet</returns>
        /// <remarks>知识库使用。</remarks>
		public DataSet GetUsersRoles(string checkCode,string type)
		{
			return new RoleDA().GetUsersRoles(checkCode,type);
		}
        /// <summary>
        /// 得到用户角色列表
        /// </summary>
        /// <param name="checkCode">文章或目录ID。</param>
        /// <param name="type">文章或目录。</param>
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
		/// 根据产品代码获取用户角色列表.一个用户一条记录，角色以字符串拼接。
		/// </summary>
		/// <param name="productCode">产品代码</param>
		/// <returns>DataTable</returns>
		public DataTable GetUsersRoleListByProduct(int productCode)
		{
			RoleDA myDA = new RoleDA();
            DataSet usersRoles = myDA.GetUsersRolesByProduct(productCode);
            DataTable usersList = myDA.GetLoginNameByProduct(productCode);//获取产品的所有用户。
            //将两个数据集合成一个用户对应一组角色的数据表。
            return this.MakeUsersRolesTable(usersList, usersRoles);
		}
        /// <summary>
        /// 根据产品编号和角色编号获取用户角色列表。一个用户一条记录，角色以字符串拼接。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>DataTable</returns>
        public DataTable GetUsersRolesListByProductAndRole(int productCode, string roleCode)
        {
            RoleDA myDA = new RoleDA();
            DataSet usersRoles = myDA.GetUsersRolesByProduct(productCode);
            DataTable usersList = myDA.GetLoginNameByProductAndRole(productCode, roleCode);
            
            //将两个数据集合成一个用户对应一组角色的数据表。
            return this.MakeUsersRolesTable(usersList, usersRoles);
        }
        /// <summary>
        /// 根据产品编号和用户名或姓名获取用户角色列表。一个用户一条记录，角色以字符串拼接。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">用户名或姓名。</param>
        /// <returns>DataTable</returns>
        public DataTable GetUsersRolesListByProductAndName(int productCode, string name)
        {
            RoleDA myDA = new RoleDA();
            DataSet usersRoles = myDA.GetUsersRolesByProductAndName(productCode, name);
            DataTable usersList = myDA.GetLoginNameByProductAndName(productCode, name);
            
            //将两个数据集合成一个用户对应一组角色的数据表。
            return this.MakeUsersRolesTable(usersList, usersRoles);
        }
        /// <summary>
        /// 根据用户名列表和用户角色数据表构造一个一个用户对应一个角色列表的记录表。
        /// </summary>
        /// <param name="usersList">用户名列表，一个数据表，只有UserCode一个字段。</param>
        /// <param name="usersRoles">用户角色数据集。一个用户名只对应一个角色的数据列表。</param>
        /// <returns>一个用户名对应一组角色的记录表。</returns>
        private DataTable MakeUsersRolesTable(DataTable usersList, DataSet usersRoles)
        {
            #region 定制一个DataTable
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
