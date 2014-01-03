//-----------------------------------------------------------------------
// <copyright file="Organize.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

	/// <summary>
	/// Organize 的摘要说明。
	/// </summary>
	[Serializable]
	public class Organize : Messages
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Organize()
		{
		}
		
		#region "公司"
		/// <summary>
		/// 得到所有的公司
		/// </summary>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetCompany()
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetCompanyInfo(ds);
			return ds;
		}
		/// <summary>
		/// 获取有效的公司
		/// </summary>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetActiveCompanies()
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetActiveCompanies(ds);
			return ds;
		}

		/// <summary>
		/// 根据公司编号获取公司信息。
		/// </summary>
		/// <param name="strCompanyCode">公司编号。</param>
		/// <returns>公司信息。</returns>
		public EntryCompanyInfo GetCompanyByCode(string strCompanyCode)
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetCompanyByCode(ds,strCompanyCode);
			return ds;
		}

		/// <summary>
		/// 获取当前有效并且缺省的公司
		/// </summary>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetDefaultCompany()
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetDefaultCompany(ds);
			return ds;
		}

		/// <summary>
		/// 获取所有子公司.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号.</param>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetSubCompany(string thisCompanyCode)
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetSubCompany(ds,thisCompanyCode);
			return ds;
		}

		/// <summary>
		/// 增加公司.
		/// </summary>
		/// <param name="thisEntryCompanyInfo">公司数据实体.</param>
		/// <returns>bool</returns>
		public bool AddCompany(EntryCompanyInfo thisEntryCompanyInfo)
		{
			var ret = true;
			OrganizeDA obj = null;

			if (thisEntryCompanyInfo != null)
			{
				obj = new OrganizeDA();
				if (obj.IsExistCoCode(thisEntryCompanyInfo.Tables[0].Rows[0][EntryCompanyInfo.COCODE_FIELD].ToString()))
				{
					this.Message = "公司编号已经存在,请重新编号!";
					ret = false;
				}
			}
			else
			{
				this.Message = "公司对象为空!";
				ret = false;
			}

			if (ret)
			{
				ret = obj.AddCompany(thisEntryCompanyInfo);
				this.Message = obj.Message;
			}

			return ret;
		}

		/// <summary>
		/// 更改公司.
		/// </summary>
		/// <param name="thisEntryCompanyInfo">公司数据实体.</param>
		/// <returns>bool</returns>
		public bool UpdateCompany(EntryCompanyInfo thisEntryCompanyInfo)
		{
			bool ret;
			OrganizeDA obj;
			if (thisEntryCompanyInfo != null)
			{
				obj = new OrganizeDA();
				if (thisEntryCompanyInfo.Tables[0].Rows[0][EntryCompanyInfo.ISDEFAULT_FIELD].ToString() == "N" &&
					obj.IsExistDefaultCoCode(thisEntryCompanyInfo.Tables[0].Rows[0][EntryCompanyInfo.COCODE_FIELD].ToString()))
				{
					this.Message = "默认公司无法修改默认状态!";
					ret = false;
				}
				else
				{
					ret = obj.UpdateCompany(thisEntryCompanyInfo);
					this.Message = obj.Message;
				}
			}
			else
			{
				this.Message = "公司对象为空!";
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 删除公司
		/// </summary>
		/// <param name="thisCompanyCode">公司编号.</param>
		/// <returns>bool</returns>
		public bool DeleteCompany(string thisCompanyCode)
		{
			bool ret;
			var obj = new OrganizeDA();

			if (obj.IsExistDefaultCoCode(thisCompanyCode))
			{
				this.Message = "默认值无法删除!";
				ret = false;
			}
			else
			{
				ret = obj.DeleteCompany(thisCompanyCode);
				this.Message = obj.Message;
			}

			return ret;
		}

		/// <summary>
		/// 根据公司编号将公司设为活动的.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <returns>bool</returns>
		public bool SetActiveCompany(string thisCompanyCode)
		{
			return false;
		}

		/// <summary>
		/// 根据公司编号将公司设为默认的.
		/// </summary>
		/// <param name="companyCode">公司编号</param>
		/// <returns>bool</returns>
		public bool SetDefaultCompany(string companyCode)
		{
			return false;
		}
		#endregion

		#region "部门"
		/// <summary>
		/// 得到当前公司的部门
		/// </summary>
		/// <param name="thisCompanyCode">公司代码</param>
		/// <returns>部门实体</returns>
        [Obsolete("此方法已作废！代替以GetAllDeptsByCompany（string companyCode）。",true)]
		public EntryDept GetDeptsByCompany(string thisCompanyCode)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptsByCompany(ds,thisCompanyCode);
			return ds;
		}
        /// <summary>
        /// 根据公司编号获取所有部门列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>EntryDept实体。</returns>
        public EntryDept GetAllDeptsByCompany(string companyCode)
        {
            var depts = new EntryDept();
            new OrganizeDA().GetAllDeptsByCompany(depts, companyCode);
            return depts;
        }
		/// <summary>
		/// 得到当前公司的部门
		/// </summary>
		/// <param name="companyCode">公司代码。</param>
		/// <param name="isValid">是否有效。</param>
		/// <returns>部门实体</returns>
		[Obsolete("此方法以作废！代替以GetAllByCompany(string companyCode)",false)]
        public EntryDept GetDeptsByCompany(string companyCode, string isValid)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptsByCompany(ds, companyCode, isValid);
			return ds;
		}
        /// <summary>
        /// 根据公司编号获取所有有效的部门列表。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>EntryDept实体。</returns>
        public EntryDept GetAllAvalibleDeptsByCompany(string companyCode)
        {
            var depts = new EntryDept();
            new OrganizeDA().GetAllAvalibleDeptsByCompany(depts, companyCode);
            return depts;
        }
		/// <summary>
		/// 得到当前公司部门的子部门.
		/// </summary>
		/// <param name="thisCompanyCode">公司编码</param>
		/// <param name="thisDeptCode">部门代码</param>
		/// <returns>部门实体</returns>
		public EntryDept GetSubDeptsByParent(string thisCompanyCode, string thisDeptCode)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetSubDeptsByParent(ds,thisCompanyCode,thisDeptCode);
			return ds;
		}
		/// <summary>
		/// 根据公司编号和部门编号,获取部门实体.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisDeptCode">部门编号</param>
		/// <returns>部门实体</returns>
		public EntryDept GetDeptByDeptCode(string thisCompanyCode, string thisDeptCode)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptByDeptCode(ds,thisCompanyCode,thisDeptCode);
			return ds;
		}
		/// <summary>
		/// 根据公司编号和用户名获取所管辖的部门.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisUserName">部门主管用户名</param>
		/// <returns>EntryDept</returns>
		public EntryDept GetDeptByManager(string thisCompanyCode, string thisUserName)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptsByManager(ds, thisCompanyCode, thisUserName);
			return ds;
		}
		/// <summary>
		/// 是否有组织类型在使用中
		/// </summary>
		/// <param name="strTypeid">组织类型ID</param>
		/// <returns>True 为有使用  false为无使用</returns>
		public bool IsHaveUseType(string strTypeid)
		{
			return new OrganizeDA().IsHaveTypeUsing(strTypeid);
		}
		/// <summary>
		/// 增加部门
		/// </summary>
		/// <param name="thisEntryDept">部门实体</param>
		/// <returns>bool</returns>
		public bool AddDept(EntryDept thisEntryDept)
		{
			var ret = true;
			OrganizeDA obj = null;

			if (thisEntryDept != null)
			{
				obj = new OrganizeDA();
				if (obj.IsExistDeptCode(thisEntryDept.Tables[EntryDept.MYSYSTEMDEPT_TABLE].Rows[0][EntryDept.DEPTCODE_FIELD].ToString(),thisEntryDept.Tables[EntryDept.MYSYSTEMDEPT_TABLE].Rows[0][EntryDept.DEPTCO_FIELD].ToString()))
				{
					this.Message = "部门代码已经存在,请重新编号!";
					ret = false;
				}
			}
			else
			{
				this.Message = "部门对象为空!";
				ret = false;
			}

			if (ret)
			{
				ret = obj.AddDept(thisEntryDept);
				this.Message = obj.Message;
			}

			return ret;
		}
		/// <summary>
		/// 更改部门
		/// </summary>
		/// <param name="thisEntryDept">部门实体</param>
		/// <returns>bool</returns>
		public bool UpdateDept(EntryDept thisEntryDept)
		{
			var ret = true;
			var obj = new OrganizeDA();

			if (thisEntryDept == null)
			{
				this.Message = "部门对象为空!";
				ret = false;
			}
	
			if (ret)
			{
				ret = obj.UpdateDept(thisEntryDept);
				this.Message = obj.Message;
			}

			return ret;
		}
		/// <summary>
		/// 移动部门到目标部门下.
		/// </summary>
		/// <param name="deptCode">部门编号</param>
		/// <param name="deptCo">公司编号</param>
		/// <param name="targetParentDeptCode">目标父部门.</param>
		/// <returns>bool</returns>
		public bool MoveDept(string deptCode,string deptCo,string targetParentDeptCode)
		{
		    var obj = new OrganizeDA();
		    var ret = obj.MoveDept(deptCode,deptCo,targetParentDeptCode);
		    this.Message = obj.Message;
		    return ret;
		}
		/// <summary>
		/// 删除部门.
		/// </summary>
		/// <param name="thisDeptCode">部门编号</param>
		/// <param name="deptCo">公司编号.</param>
		/// <returns>bool</returns>
		public bool DeleteDept(string thisDeptCode,string deptCo)
		{
			return new OrganizeDA().DeleteDept(thisDeptCode,deptCo);
		}
		/// <summary>
		/// 判断是否在同一个公司下已经存在部门名称了.
		/// </summary>
		/// <param name="deptCo">公司编号</param>
		/// <param name="thisDeptName">部门名称</param>
		/// <returns>bool</returns>
		public bool HasExistDeptName(string deptCo,string thisDeptName)
		{
			return new OrganizeDA().IsExistDeptName(deptCo,thisDeptName);
		}
		/// <summary>
		/// 增加组织类型
		/// </summary>
		/// <param name="code">编码</param>
		/// <param name="level">级别</param>
		/// <param name="cnname">中文描述</param>
		/// <param name="enname">英文描述</param>
		/// <param name="isvalid">是否有效</param>
		/// <returns>是否增加成功</returns> 
		public bool SaveOrgType(string code,int level,string cnname,string enname,string isvalid)
		{
			return new OrganizeDA().UpdateOrgType(code,level,cnname,enname,isvalid);
		}
		/// <summary>
		/// 删除组织类型
		/// </summary>
		/// <param name="code">编码</param>
		/// <returns>是否删除成功</returns> 
		public bool DeleteOrgType(string code)
		{
			return new OrganizeDA().DeleteOrgType(code);
		}
		/// <summary>
		/// 增加组织类型
		/// </summary>
		/// <param name="code">编码</param>
		/// <param name="level">级别</param>
		/// <param name="cnname">中文描述</param>
		/// <param name="enname">英文描述</param>
		/// <param name="isvalid">是否有效</param>
		/// <returns>是否增加成功</returns> 
		public bool AddOrgType(string code,int level,string cnname,string enname,string isvalid)
		{
			return new OrganizeDA().AddOrgType(code,level,cnname,enname,isvalid);
		}
		/// <summary>
		/// 获取组织类型
		/// </summary>
        /// <param name="isValid">是否有效。</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgType(string isValid)
		{
			return new OrganizeDA().GetOrgType(isValid);
		}
		/// <summary>
		/// 是否存在同名的组织类型代码
		/// </summary>
		/// <param name="orgTypeCode">编码</param>
		/// <returns>true or false</returns>
		public bool IsExistOrgTypeCode(string orgTypeCode)
		{
			return new OrganizeDA().IsExist(orgTypeCode);
		}
		/// <summary>
		/// 是否存在同名的组织类型名称
		/// </summary>
		/// <param name="orgTypeName">编码</param>
		/// <returns>true or false</returns>
		public bool IsExistOrgTypeName(string orgTypeName)
		{
			return new OrganizeDA().IsExist(orgTypeName);
		}
		#endregion

		#region "职位"
		/// <summary>
		/// 根据公司获取所有的职位.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <returns>EntryDuty</returns>
		public EntryDuty GetDutiesByCompany(string thisCompanyCode)
		{
			var ds = new EntryDuty();
			new OrganizeDA().FillDutiesByCompany(ds,thisCompanyCode);
			return ds;
		}
		/// <summary>
		/// 根据职位编号获取职位实体.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号.</param>
		/// <param name="thisDutyCode">职位编号.</param>
		/// <returns>EntryDuty</returns>
		public EntryDuty GetDutyByDutyCode(string thisCompanyCode, string thisDutyCode)
		{
			var ds = new EntryDuty();
			new OrganizeDA().GetDutyByDutyCode(ds,thisCompanyCode,thisDutyCode);
			return ds;
		}
		/// <summary>
		/// 增加职位
		/// </summary>
		/// <param name="thisEntryDuty">职位数据实体</param>
		/// <returns>bool</returns>
		public bool AddDuty(EntryDuty thisEntryDuty)
		{
			bool ret = true;
			OrganizeDA obj = null;

			if (thisEntryDuty != null)
			{
				obj = new OrganizeDA();
				if (obj.IsExistDutyCode(thisEntryDuty.Tables[EntryDuty.MYSYSTEMDUTY_TABLE].Rows[0][EntryDuty.DUTYCODE_FIELD].ToString(),thisEntryDuty.Tables[EntryDuty.MYSYSTEMDUTY_TABLE].Rows[0][EntryDuty.DUTYCO_FIELD].ToString()))
				{
					this.Message = "职位代码已经存在,请重新编号!";
					ret = false;
				}
			}
			else
			{
				this.Message = "对象为空!";
				ret = false;
			}
			if (ret)
			{
				ret = obj.AddDuty(thisEntryDuty);
				this.Message = obj.Message;
			}
			return ret;
		}
		/// <summary>
		/// 更新职位
		/// </summary>
		/// <param name="thisEntryDuty">职位数据实体.</param>
		/// <returns>bool</returns>
		public bool UpdateDuty(EntryDuty thisEntryDuty)
		{
			var ret = true;
			var obj = new OrganizeDA();

			if (thisEntryDuty == null)
			{
				this.Message = "职位对象为空!";
				ret = false;
			}
	
			if (ret)
			{
				ret = obj.UpdateDuty(thisEntryDuty);
				this.Message = obj.Message;
			}
			return ret;
		}
		/// <summary>
		/// 移动职位
		/// </summary>
		/// <param name="dutyCode">职位编号</param>
		/// <param name="dutyCo">公司编号</param>
		/// <param name="targetParentDutyCode">目标职位编号.</param>
		/// <returns>bool</returns>
		public bool MoveDuty(string dutyCode,string dutyCo,string targetParentDutyCode)
		{
			var obj = new OrganizeDA();
			var ret = obj.MoveDuty(dutyCode,dutyCo,targetParentDutyCode);
			this.Message = obj.Message;

			return ret;
		}
		/// <summary>
		/// 根据公司职位获取所有员工的姓名连接字符串.
		/// </summary>
		/// <param name="dutyCode">职位编号</param>
		/// <param name="dutyCo">公司编号</param>
		/// <param name="empCnNames">员工姓名的连接字符串</param>
        /// <returns>所有员工的姓名连接字符串。</returns>
		public string GetDutyUsers(string dutyCode,string dutyCo,out string empCnNames)
		{
			var ret = string.Empty;
			empCnNames = string.Empty;
			var obj = new OrganizeDA();
			if (dutyCode == string.Empty || dutyCo == string.Empty)
			{
				this.Message = "未知职位！";
				return ret;
			}
		    ret = obj.GetDutyUsers(dutyCode,dutyCo,out empCnNames);			
		    this.Message = obj.Message;
		    return ret;
		}
		/// <summary>
		/// 删除职位
		/// </summary>
		/// <param name="companyCode">公司编号</param>
		/// <param name="dutyCode">职位编号</param>
		/// <returns>bool</returns>
		public bool DeleteDuty(string companyCode, string dutyCode)
		{
			var ret = true;
			var obj = new OrganizeDA();
			if (obj.IsUsingDutyCode(dutyCode))
			{
				this.Message = "职位代码已经使用,不能删除!";
				ret = false;
			}
			if (ret)
			{
				obj.DeleteDuty(companyCode,dutyCode);
			}
			return ret;
		}
		/// <summary>
		/// 判断职位名称是否重复
		/// </summary>
		/// <param name="dutyName">职位名称</param>
		/// <param name="dutyCo">公司代码</param>
		/// <returns>false or true</returns>
		public bool IsExistDutyName(string dutyName,string dutyCo)
		{
			return new OrganizeDA().IsExistDutyName(dutyName,dutyCo);
		}
		#endregion

		#region "人员"
		/// <summary>
		/// 获取所有员工.
		/// </summary>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployee()
		{
			var ds = new EntryUser();
			new OrganizeDA().FillAllEmployee(ds);
			return ds;
		}
		/// <summary>
		/// 根据状态获取所有员工.
		/// </summary>
		/// <param name="thisState">状态</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByState(string thisState)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillAllEmployeeByState(ds,thisState);
			return ds;
		}
		/// <summary>
		/// 根据公司获取所有员工
		/// </summary>
		/// <param name="companyCode">公司编号</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByCompany(string companyCode)
		{
			var ds = new EntryUser();
            new OrganizeDA().FillAllEmployeeByCompany(ds, companyCode);
			return ds;
		}
		/// <summary>
		/// 根据公司编号和员工工号获取员工信息.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisEmpCode">员工工号</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetEmployeeByCompanyAndEmpCode(string thisCompanyCode,string thisEmpCode)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillEmployeeByCompanyAndEmpCode(ds,thisCompanyCode,thisEmpCode);
			return ds;
		}
        /// <summary>
        /// 根据公司编号和登录名获取用户实体。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>EntryUser。</returns>
        public EntryUser GetEmployeeByCompanyAndLoginName(string companyCode, string loginName)
        {
            var ds = new EntryUser();
            new OrganizeDA().FillemployeeByCompanyAndLoginName(ds, companyCode, loginName);
            return ds;
        }
		/// <summary>
		/// 根据PKID获取员工信息.
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetEmployeeByPKID(int pkid)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillEmployeeByPKID(ds,pkid);
			return ds;
		}
		/// <summary>
		/// 根据公司编号和状态获取员工信息.
		/// </summary>
		/// <param name="thisCompanyCode">公司编号</param>
		/// <param name="thisState">员工状态或者用户状态</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByCompanyAndState(string thisCompanyCode, string thisState)
		{
			var ds = new EntryUser();
			new OrganizeDA().GetAllEmployeeByCompanyAndState(ds,thisCompanyCode,thisState);
			return ds;
		}
		/// <summary>
		/// 根据公司编号和部门编号和状态获取员工信息.
		/// </summary>
		/// <param name="companyCode">公司编号</param>
		/// <param name="deptCode">部门编号</param>
		/// <param name="state">员工状态或者用户状态</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByCompanyAndDeptAndState(string companyCode,string deptCode,string state)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillAllEmployeeByCompanyAndDeptAndState(ds, companyCode,deptCode,state);
			return ds;
		}
		/// <summary>
		/// 增加员工
		/// </summary>
		/// <param name="thisEntryUser">员工对象</param>
		/// <returns>bool</returns>
		public bool AddEmployee(EntryUser thisEntryUser)
		{
			var ret = true;
			OrganizeDA da = null;

			if (thisEntryUser != null && thisEntryUser.Tables.Count > 0 && thisEntryUser.Tables[0].Rows.Count > 0)
			{
                da = new OrganizeDA();
                var oRow = thisEntryUser.Tables[EntryUser.MYSYSTEMUSERINFO_TABLE].Rows[0];
				
                //是否是企业内用户
				if (oRow[EntryUser.ISEMP_FIELD].ToString() == "Y")
				{
					//必须输入工号,并且唯一.
                    if (da.IsExistEmpCode(oRow[EntryUser.EMPCODE_FIELD].ToString()))
					{
						this.Message = "员工工号已经存在,请重新编号!";
						ret = false;
					}
				}
				
                //是否增加用户信息.
				var strUserName = oRow[EntryUser.LOGINNAME_FIELD].ToString().Trim();
				if (!string.IsNullOrEmpty(strUserName))
				{
                    //判断用户名是否已经存在。
					if (new Users().IsExistUser(strUserName))
					{
						this.Message = "用户名重复,请重新编号!";
						ret = false;
					}
				}
			}
			else
			{
				this.Message = "对象为空!";
				ret = false;
			}
			if (ret)
			{
				ret = da.AddEmployee(thisEntryUser);
				this.Message = da.Message;
			}
			return ret;
		}
		/// <summary>
		/// 修改员工信息。
		/// </summary>
		/// <param name="user">员工对象</param>
		/// <returns>bool</returns>
		public bool UpdateEmployee(EntryUser user)
		{
            var orgDA = new OrganizeDA();
            var userDA = new Users();
            
            if (user != null && user.Tables.Count > 0 && user.Tables[0].Rows.Count > 0)
            {
                var oRow = user.Tables[EntryUser.MYSYSTEMUSERINFO_TABLE].Rows[0];
                var pkid = int.Parse(oRow[EntryUser.PKID_FIELD].ToString());
                
                //判断工号是否重复。
                var empCode = oRow[EntryUser.EMPCODE_FIELD].ToString();
                if (orgDA.IsExistEmpCode(empCode, pkid))
                {
                    this.Message = "员工工号重复，请重新指定！";
                    return false;
                }
                
                //判断用户名是否重复。
                var loginName = oRow[EntryUser.LOGINNAME_FIELD].ToString().Trim();
                if (string.IsNullOrEmpty(loginName))
                {
                    if (userDA.IsExistUser(loginName, pkid))
                    {
                        this.Message = "用户名重复,请重新编号！";
                        return false;
                    }
                }
                if (oRow["IsEmp"].ToString() == "Y")
                {
                    //如果是内部员工的话，一定要输入部门信息。
                    if (oRow["EmpDept"] == DBNull.Value || oRow["EmpDept"].ToString().Trim() == string.Empty || oRow["EmpDept"].ToString() == "-100")
                    {
                        this.Message = "请指定所属部门！";
                        return false; 
                    }
                }
            }
            else
            {
                this.Message = "用户对象为空！";
                return false;
            }
            
            //进行员工信息的更新。
            if (!orgDA.UpdateEmployee(user))
            {
                this.Message = orgDA.Message;
                return false;
            }
			return true;
		}
		/// <summary>
		/// 删除员工
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		public bool DeleteEmployee(int pkid)
		{
			return new OrganizeDA().DeleteEmployee(pkid);
		}

		/// <summary>
		/// 改变员工状态.
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <param name="newState">新状态</param>
		/// <returns>bool</returns>
		public bool ChangeEmployeeState(int thisPKID, string newState)
		{
			return false;
		}

		/// <summary>
		/// 是员工成为用户.
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <returns>bool</returns>
		public bool EnableEmployeeIsUser(int thisPKID)
		{
			return new OrganizeDA().EnableEmployeeIsUser(thisPKID);
		}
		/// <summary>
		/// 员工成为用户
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <param name="userCode">用户编号</param>
		/// <param name="password">密码</param>
		/// <param name="state">状态</param>
		/// <returns>是否成功</returns>
		public bool EnableEmployeeIsUser(int thisPKID,string userCode,string password,string state)
		{
			var objU = new Users();
			var sail = objU.CreateSalt();
			password = objU.CreatePasswordHash(password,sail);

			var objOrganize = new OrganizeDA();
			var ret = true;

			if (!objU.IsExistUser(userCode))
			{
				if (!objOrganize.EnableEmployeeIsUser(thisPKID,userCode,password,sail,state))
				{
					this.Message = "Please look log";
					ret = false;
				}
			}
			else
			{
				this.Message = "用户编码已经存在，请重新编码";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 使员工不是用户.
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <returns>bool</returns>
		public bool DisableEmployeeIsUser(int thisPKID)
		{
			return new OrganizeDA().DisableEmployeeIsUser(thisPKID);
		}
		/// <summary>
		/// 移动员工所在的部门
		/// </summary>
		/// <param name="employeeCodes">员工工号字符串.</param>
		/// <param name="employeeCompanyCode">公司编号</param>
		/// <param name="targetDeptCode">目标部门编号.</param>
		/// <returns>bool</returns>
		public bool MoveEmployees(string employeeCodes,string employeeCompanyCode,string targetDeptCode)
		{
			var obj = new OrganizeDA();
			var ret = obj.MoveEmployees(employeeCodes,employeeCompanyCode,targetDeptCode);
			this.Message = obj.Message;
			return ret;
		}
		#endregion
	
		#region "组织人员"
		/// <summary>
		/// 更新组织用户列表
		/// </summary>
		/// <param name="companyCode">公司</param>
		/// <param name="orgCode">组织</param>
		/// <param name="userList">用户列表</param>
		/// <returns>bool</returns>
        public bool SaveOrgUser(string companyCode, string orgCode, string userList)
		{
			return new OrganizeDA().UpdateOrgUser(companyCode,orgCode,userList);
		}

		/// <summary>
		/// 得到组织用户
		/// </summary>
		/// <param name="companyCode">公司代码</param>
		/// <param name="orgCode">组织代码</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgUsers(string companyCode,string orgCode)
		{
			return new OrganizeDA().GetOrgUsers(companyCode,orgCode);
		}
		#endregion

		#region "组织、职位、人员"

		/// <summary>
		/// 更新组织、职位、人员关联
		/// </summary>
		/// <param name="orgCo">组织公司</param>
		/// <param name="orgCode">组织代码</param>
		/// <param name="dutyList">职位代码列表</param>
		/// <param name="userList">用户名列表</param>
		/// <returns>bool</returns>
		public bool SaveOrgDutysUsers(string orgCo,string orgCode,string dutyList,string userList)
		{
			return new OrganizeDA().UpdateOrgDutysUsers(orgCo,orgCode,dutyList,userList);
		}	

		/// <summary>
		/// 得到组织用户职位
		/// </summary>
		/// <param name="companyCode">公司代码</param>
		/// <param name="orgCode">组织代码</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgUsersDutys(string companyCode,string orgCode)
		{
			return new OrganizeDA().GetOrgUsersDutys(companyCode,orgCode);
		}
		
		#endregion
	}
}
