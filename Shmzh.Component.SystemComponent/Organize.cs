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
	/// Organize ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class Organize : Messages
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public Organize()
		{
		}
		
		#region "��˾"
		/// <summary>
		/// �õ����еĹ�˾
		/// </summary>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetCompany()
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetCompanyInfo(ds);
			return ds;
		}
		/// <summary>
		/// ��ȡ��Ч�Ĺ�˾
		/// </summary>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetActiveCompanies()
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetActiveCompanies(ds);
			return ds;
		}

		/// <summary>
		/// ���ݹ�˾��Ż�ȡ��˾��Ϣ��
		/// </summary>
		/// <param name="strCompanyCode">��˾��š�</param>
		/// <returns>��˾��Ϣ��</returns>
		public EntryCompanyInfo GetCompanyByCode(string strCompanyCode)
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetCompanyByCode(ds,strCompanyCode);
			return ds;
		}

		/// <summary>
		/// ��ȡ��ǰ��Ч����ȱʡ�Ĺ�˾
		/// </summary>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetDefaultCompany()
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetDefaultCompany(ds);
			return ds;
		}

		/// <summary>
		/// ��ȡ�����ӹ�˾.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���.</param>
		/// <returns>EntryCompanyInfo</returns>
		public EntryCompanyInfo GetSubCompany(string thisCompanyCode)
		{
			var ds = new EntryCompanyInfo();
			new OrganizeDA().GetSubCompany(ds,thisCompanyCode);
			return ds;
		}

		/// <summary>
		/// ���ӹ�˾.
		/// </summary>
		/// <param name="thisEntryCompanyInfo">��˾����ʵ��.</param>
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
					this.Message = "��˾����Ѿ�����,�����±��!";
					ret = false;
				}
			}
			else
			{
				this.Message = "��˾����Ϊ��!";
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
		/// ���Ĺ�˾.
		/// </summary>
		/// <param name="thisEntryCompanyInfo">��˾����ʵ��.</param>
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
					this.Message = "Ĭ�Ϲ�˾�޷��޸�Ĭ��״̬!";
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
				this.Message = "��˾����Ϊ��!";
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// ɾ����˾
		/// </summary>
		/// <param name="thisCompanyCode">��˾���.</param>
		/// <returns>bool</returns>
		public bool DeleteCompany(string thisCompanyCode)
		{
			bool ret;
			var obj = new OrganizeDA();

			if (obj.IsExistDefaultCoCode(thisCompanyCode))
			{
				this.Message = "Ĭ��ֵ�޷�ɾ��!";
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
		/// ���ݹ�˾��Ž���˾��Ϊ���.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <returns>bool</returns>
		public bool SetActiveCompany(string thisCompanyCode)
		{
			return false;
		}

		/// <summary>
		/// ���ݹ�˾��Ž���˾��ΪĬ�ϵ�.
		/// </summary>
		/// <param name="companyCode">��˾���</param>
		/// <returns>bool</returns>
		public bool SetDefaultCompany(string companyCode)
		{
			return false;
		}
		#endregion

		#region "����"
		/// <summary>
		/// �õ���ǰ��˾�Ĳ���
		/// </summary>
		/// <param name="thisCompanyCode">��˾����</param>
		/// <returns>����ʵ��</returns>
        [Obsolete("�˷��������ϣ�������GetAllDeptsByCompany��string companyCode����",true)]
		public EntryDept GetDeptsByCompany(string thisCompanyCode)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptsByCompany(ds,thisCompanyCode);
			return ds;
		}
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ���в����б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>EntryDeptʵ�塣</returns>
        public EntryDept GetAllDeptsByCompany(string companyCode)
        {
            var depts = new EntryDept();
            new OrganizeDA().GetAllDeptsByCompany(depts, companyCode);
            return depts;
        }
		/// <summary>
		/// �õ���ǰ��˾�Ĳ���
		/// </summary>
		/// <param name="companyCode">��˾���롣</param>
		/// <param name="isValid">�Ƿ���Ч��</param>
		/// <returns>����ʵ��</returns>
		[Obsolete("�˷��������ϣ�������GetAllByCompany(string companyCode)",false)]
        public EntryDept GetDeptsByCompany(string companyCode, string isValid)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptsByCompany(ds, companyCode, isValid);
			return ds;
		}
        /// <summary>
        /// ���ݹ�˾��Ż�ȡ������Ч�Ĳ����б�
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <returns>EntryDeptʵ�塣</returns>
        public EntryDept GetAllAvalibleDeptsByCompany(string companyCode)
        {
            var depts = new EntryDept();
            new OrganizeDA().GetAllAvalibleDeptsByCompany(depts, companyCode);
            return depts;
        }
		/// <summary>
		/// �õ���ǰ��˾���ŵ��Ӳ���.
		/// </summary>
		/// <param name="thisCompanyCode">��˾����</param>
		/// <param name="thisDeptCode">���Ŵ���</param>
		/// <returns>����ʵ��</returns>
		public EntryDept GetSubDeptsByParent(string thisCompanyCode, string thisDeptCode)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetSubDeptsByParent(ds,thisCompanyCode,thisDeptCode);
			return ds;
		}
		/// <summary>
		/// ���ݹ�˾��źͲ��ű��,��ȡ����ʵ��.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisDeptCode">���ű��</param>
		/// <returns>����ʵ��</returns>
		public EntryDept GetDeptByDeptCode(string thisCompanyCode, string thisDeptCode)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptByDeptCode(ds,thisCompanyCode,thisDeptCode);
			return ds;
		}
		/// <summary>
		/// ���ݹ�˾��ź��û�����ȡ����Ͻ�Ĳ���.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisUserName">���������û���</param>
		/// <returns>EntryDept</returns>
		public EntryDept GetDeptByManager(string thisCompanyCode, string thisUserName)
		{
			var ds = new EntryDept();
			new OrganizeDA().GetDeptsByManager(ds, thisCompanyCode, thisUserName);
			return ds;
		}
		/// <summary>
		/// �Ƿ�����֯������ʹ����
		/// </summary>
		/// <param name="strTypeid">��֯����ID</param>
		/// <returns>True Ϊ��ʹ��  falseΪ��ʹ��</returns>
		public bool IsHaveUseType(string strTypeid)
		{
			return new OrganizeDA().IsHaveTypeUsing(strTypeid);
		}
		/// <summary>
		/// ���Ӳ���
		/// </summary>
		/// <param name="thisEntryDept">����ʵ��</param>
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
					this.Message = "���Ŵ����Ѿ�����,�����±��!";
					ret = false;
				}
			}
			else
			{
				this.Message = "���Ŷ���Ϊ��!";
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
		/// ���Ĳ���
		/// </summary>
		/// <param name="thisEntryDept">����ʵ��</param>
		/// <returns>bool</returns>
		public bool UpdateDept(EntryDept thisEntryDept)
		{
			var ret = true;
			var obj = new OrganizeDA();

			if (thisEntryDept == null)
			{
				this.Message = "���Ŷ���Ϊ��!";
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
		/// �ƶ����ŵ�Ŀ�겿����.
		/// </summary>
		/// <param name="deptCode">���ű��</param>
		/// <param name="deptCo">��˾���</param>
		/// <param name="targetParentDeptCode">Ŀ�길����.</param>
		/// <returns>bool</returns>
		public bool MoveDept(string deptCode,string deptCo,string targetParentDeptCode)
		{
		    var obj = new OrganizeDA();
		    var ret = obj.MoveDept(deptCode,deptCo,targetParentDeptCode);
		    this.Message = obj.Message;
		    return ret;
		}
		/// <summary>
		/// ɾ������.
		/// </summary>
		/// <param name="thisDeptCode">���ű��</param>
		/// <param name="deptCo">��˾���.</param>
		/// <returns>bool</returns>
		public bool DeleteDept(string thisDeptCode,string deptCo)
		{
			return new OrganizeDA().DeleteDept(thisDeptCode,deptCo);
		}
		/// <summary>
		/// �ж��Ƿ���ͬһ����˾���Ѿ����ڲ���������.
		/// </summary>
		/// <param name="deptCo">��˾���</param>
		/// <param name="thisDeptName">��������</param>
		/// <returns>bool</returns>
		public bool HasExistDeptName(string deptCo,string thisDeptName)
		{
			return new OrganizeDA().IsExistDeptName(deptCo,thisDeptName);
		}
		/// <summary>
		/// ������֯����
		/// </summary>
		/// <param name="code">����</param>
		/// <param name="level">����</param>
		/// <param name="cnname">��������</param>
		/// <param name="enname">Ӣ������</param>
		/// <param name="isvalid">�Ƿ���Ч</param>
		/// <returns>�Ƿ����ӳɹ�</returns> 
		public bool SaveOrgType(string code,int level,string cnname,string enname,string isvalid)
		{
			return new OrganizeDA().UpdateOrgType(code,level,cnname,enname,isvalid);
		}
		/// <summary>
		/// ɾ����֯����
		/// </summary>
		/// <param name="code">����</param>
		/// <returns>�Ƿ�ɾ���ɹ�</returns> 
		public bool DeleteOrgType(string code)
		{
			return new OrganizeDA().DeleteOrgType(code);
		}
		/// <summary>
		/// ������֯����
		/// </summary>
		/// <param name="code">����</param>
		/// <param name="level">����</param>
		/// <param name="cnname">��������</param>
		/// <param name="enname">Ӣ������</param>
		/// <param name="isvalid">�Ƿ���Ч</param>
		/// <returns>�Ƿ����ӳɹ�</returns> 
		public bool AddOrgType(string code,int level,string cnname,string enname,string isvalid)
		{
			return new OrganizeDA().AddOrgType(code,level,cnname,enname,isvalid);
		}
		/// <summary>
		/// ��ȡ��֯����
		/// </summary>
        /// <param name="isValid">�Ƿ���Ч��</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgType(string isValid)
		{
			return new OrganizeDA().GetOrgType(isValid);
		}
		/// <summary>
		/// �Ƿ����ͬ������֯���ʹ���
		/// </summary>
		/// <param name="orgTypeCode">����</param>
		/// <returns>true or false</returns>
		public bool IsExistOrgTypeCode(string orgTypeCode)
		{
			return new OrganizeDA().IsExist(orgTypeCode);
		}
		/// <summary>
		/// �Ƿ����ͬ������֯��������
		/// </summary>
		/// <param name="orgTypeName">����</param>
		/// <returns>true or false</returns>
		public bool IsExistOrgTypeName(string orgTypeName)
		{
			return new OrganizeDA().IsExist(orgTypeName);
		}
		#endregion

		#region "ְλ"
		/// <summary>
		/// ���ݹ�˾��ȡ���е�ְλ.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <returns>EntryDuty</returns>
		public EntryDuty GetDutiesByCompany(string thisCompanyCode)
		{
			var ds = new EntryDuty();
			new OrganizeDA().FillDutiesByCompany(ds,thisCompanyCode);
			return ds;
		}
		/// <summary>
		/// ����ְλ��Ż�ȡְλʵ��.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���.</param>
		/// <param name="thisDutyCode">ְλ���.</param>
		/// <returns>EntryDuty</returns>
		public EntryDuty GetDutyByDutyCode(string thisCompanyCode, string thisDutyCode)
		{
			var ds = new EntryDuty();
			new OrganizeDA().GetDutyByDutyCode(ds,thisCompanyCode,thisDutyCode);
			return ds;
		}
		/// <summary>
		/// ����ְλ
		/// </summary>
		/// <param name="thisEntryDuty">ְλ����ʵ��</param>
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
					this.Message = "ְλ�����Ѿ�����,�����±��!";
					ret = false;
				}
			}
			else
			{
				this.Message = "����Ϊ��!";
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
		/// ����ְλ
		/// </summary>
		/// <param name="thisEntryDuty">ְλ����ʵ��.</param>
		/// <returns>bool</returns>
		public bool UpdateDuty(EntryDuty thisEntryDuty)
		{
			var ret = true;
			var obj = new OrganizeDA();

			if (thisEntryDuty == null)
			{
				this.Message = "ְλ����Ϊ��!";
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
		/// �ƶ�ְλ
		/// </summary>
		/// <param name="dutyCode">ְλ���</param>
		/// <param name="dutyCo">��˾���</param>
		/// <param name="targetParentDutyCode">Ŀ��ְλ���.</param>
		/// <returns>bool</returns>
		public bool MoveDuty(string dutyCode,string dutyCo,string targetParentDutyCode)
		{
			var obj = new OrganizeDA();
			var ret = obj.MoveDuty(dutyCode,dutyCo,targetParentDutyCode);
			this.Message = obj.Message;

			return ret;
		}
		/// <summary>
		/// ���ݹ�˾ְλ��ȡ����Ա�������������ַ���.
		/// </summary>
		/// <param name="dutyCode">ְλ���</param>
		/// <param name="dutyCo">��˾���</param>
		/// <param name="empCnNames">Ա�������������ַ���</param>
        /// <returns>����Ա�������������ַ�����</returns>
		public string GetDutyUsers(string dutyCode,string dutyCo,out string empCnNames)
		{
			var ret = string.Empty;
			empCnNames = string.Empty;
			var obj = new OrganizeDA();
			if (dutyCode == string.Empty || dutyCo == string.Empty)
			{
				this.Message = "δְ֪λ��";
				return ret;
			}
		    ret = obj.GetDutyUsers(dutyCode,dutyCo,out empCnNames);			
		    this.Message = obj.Message;
		    return ret;
		}
		/// <summary>
		/// ɾ��ְλ
		/// </summary>
		/// <param name="companyCode">��˾���</param>
		/// <param name="dutyCode">ְλ���</param>
		/// <returns>bool</returns>
		public bool DeleteDuty(string companyCode, string dutyCode)
		{
			var ret = true;
			var obj = new OrganizeDA();
			if (obj.IsUsingDutyCode(dutyCode))
			{
				this.Message = "ְλ�����Ѿ�ʹ��,����ɾ��!";
				ret = false;
			}
			if (ret)
			{
				obj.DeleteDuty(companyCode,dutyCode);
			}
			return ret;
		}
		/// <summary>
		/// �ж�ְλ�����Ƿ��ظ�
		/// </summary>
		/// <param name="dutyName">ְλ����</param>
		/// <param name="dutyCo">��˾����</param>
		/// <returns>false or true</returns>
		public bool IsExistDutyName(string dutyName,string dutyCo)
		{
			return new OrganizeDA().IsExistDutyName(dutyName,dutyCo);
		}
		#endregion

		#region "��Ա"
		/// <summary>
		/// ��ȡ����Ա��.
		/// </summary>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployee()
		{
			var ds = new EntryUser();
			new OrganizeDA().FillAllEmployee(ds);
			return ds;
		}
		/// <summary>
		/// ����״̬��ȡ����Ա��.
		/// </summary>
		/// <param name="thisState">״̬</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByState(string thisState)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillAllEmployeeByState(ds,thisState);
			return ds;
		}
		/// <summary>
		/// ���ݹ�˾��ȡ����Ա��
		/// </summary>
		/// <param name="companyCode">��˾���</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByCompany(string companyCode)
		{
			var ds = new EntryUser();
            new OrganizeDA().FillAllEmployeeByCompany(ds, companyCode);
			return ds;
		}
		/// <summary>
		/// ���ݹ�˾��ź�Ա�����Ż�ȡԱ����Ϣ.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisEmpCode">Ա������</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetEmployeeByCompanyAndEmpCode(string thisCompanyCode,string thisEmpCode)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillEmployeeByCompanyAndEmpCode(ds,thisCompanyCode,thisEmpCode);
			return ds;
		}
        /// <summary>
        /// ���ݹ�˾��ź͵�¼����ȡ�û�ʵ�塣
        /// </summary>
        /// <param name="companyCode">��˾��š�</param>
        /// <param name="loginName">��¼����</param>
        /// <returns>EntryUser��</returns>
        public EntryUser GetEmployeeByCompanyAndLoginName(string companyCode, string loginName)
        {
            var ds = new EntryUser();
            new OrganizeDA().FillemployeeByCompanyAndLoginName(ds, companyCode, loginName);
            return ds;
        }
		/// <summary>
		/// ����PKID��ȡԱ����Ϣ.
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
		/// ���ݹ�˾��ź�״̬��ȡԱ����Ϣ.
		/// </summary>
		/// <param name="thisCompanyCode">��˾���</param>
		/// <param name="thisState">Ա��״̬�����û�״̬</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByCompanyAndState(string thisCompanyCode, string thisState)
		{
			var ds = new EntryUser();
			new OrganizeDA().GetAllEmployeeByCompanyAndState(ds,thisCompanyCode,thisState);
			return ds;
		}
		/// <summary>
		/// ���ݹ�˾��źͲ��ű�ź�״̬��ȡԱ����Ϣ.
		/// </summary>
		/// <param name="companyCode">��˾���</param>
		/// <param name="deptCode">���ű��</param>
		/// <param name="state">Ա��״̬�����û�״̬</param>
		/// <returns>EntryUser</returns>
		public EntryUser GetAllEmployeeByCompanyAndDeptAndState(string companyCode,string deptCode,string state)
		{
			var ds = new EntryUser();
			new OrganizeDA().FillAllEmployeeByCompanyAndDeptAndState(ds, companyCode,deptCode,state);
			return ds;
		}
		/// <summary>
		/// ����Ա��
		/// </summary>
		/// <param name="thisEntryUser">Ա������</param>
		/// <returns>bool</returns>
		public bool AddEmployee(EntryUser thisEntryUser)
		{
			var ret = true;
			OrganizeDA da = null;

			if (thisEntryUser != null && thisEntryUser.Tables.Count > 0 && thisEntryUser.Tables[0].Rows.Count > 0)
			{
                da = new OrganizeDA();
                var oRow = thisEntryUser.Tables[EntryUser.MYSYSTEMUSERINFO_TABLE].Rows[0];
				
                //�Ƿ�����ҵ���û�
				if (oRow[EntryUser.ISEMP_FIELD].ToString() == "Y")
				{
					//�������빤��,����Ψһ.
                    if (da.IsExistEmpCode(oRow[EntryUser.EMPCODE_FIELD].ToString()))
					{
						this.Message = "Ա�������Ѿ�����,�����±��!";
						ret = false;
					}
				}
				
                //�Ƿ������û���Ϣ.
				var strUserName = oRow[EntryUser.LOGINNAME_FIELD].ToString().Trim();
				if (!string.IsNullOrEmpty(strUserName))
				{
                    //�ж��û����Ƿ��Ѿ����ڡ�
					if (new Users().IsExistUser(strUserName))
					{
						this.Message = "�û����ظ�,�����±��!";
						ret = false;
					}
				}
			}
			else
			{
				this.Message = "����Ϊ��!";
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
		/// �޸�Ա����Ϣ��
		/// </summary>
		/// <param name="user">Ա������</param>
		/// <returns>bool</returns>
		public bool UpdateEmployee(EntryUser user)
		{
            var orgDA = new OrganizeDA();
            var userDA = new Users();
            
            if (user != null && user.Tables.Count > 0 && user.Tables[0].Rows.Count > 0)
            {
                var oRow = user.Tables[EntryUser.MYSYSTEMUSERINFO_TABLE].Rows[0];
                var pkid = int.Parse(oRow[EntryUser.PKID_FIELD].ToString());
                
                //�жϹ����Ƿ��ظ���
                var empCode = oRow[EntryUser.EMPCODE_FIELD].ToString();
                if (orgDA.IsExistEmpCode(empCode, pkid))
                {
                    this.Message = "Ա�������ظ���������ָ����";
                    return false;
                }
                
                //�ж��û����Ƿ��ظ���
                var loginName = oRow[EntryUser.LOGINNAME_FIELD].ToString().Trim();
                if (string.IsNullOrEmpty(loginName))
                {
                    if (userDA.IsExistUser(loginName, pkid))
                    {
                        this.Message = "�û����ظ�,�����±�ţ�";
                        return false;
                    }
                }
                if (oRow["IsEmp"].ToString() == "Y")
                {
                    //������ڲ�Ա���Ļ���һ��Ҫ���벿����Ϣ��
                    if (oRow["EmpDept"] == DBNull.Value || oRow["EmpDept"].ToString().Trim() == string.Empty || oRow["EmpDept"].ToString() == "-100")
                    {
                        this.Message = "��ָ���������ţ�";
                        return false; 
                    }
                }
            }
            else
            {
                this.Message = "�û�����Ϊ�գ�";
                return false;
            }
            
            //����Ա����Ϣ�ĸ��¡�
            if (!orgDA.UpdateEmployee(user))
            {
                this.Message = orgDA.Message;
                return false;
            }
			return true;
		}
		/// <summary>
		/// ɾ��Ա��
		/// </summary>
		/// <param name="pkid">PKID</param>
		/// <returns>bool</returns>
		public bool DeleteEmployee(int pkid)
		{
			return new OrganizeDA().DeleteEmployee(pkid);
		}

		/// <summary>
		/// �ı�Ա��״̬.
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <param name="newState">��״̬</param>
		/// <returns>bool</returns>
		public bool ChangeEmployeeState(int thisPKID, string newState)
		{
			return false;
		}

		/// <summary>
		/// ��Ա����Ϊ�û�.
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <returns>bool</returns>
		public bool EnableEmployeeIsUser(int thisPKID)
		{
			return new OrganizeDA().EnableEmployeeIsUser(thisPKID);
		}
		/// <summary>
		/// Ա����Ϊ�û�
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <param name="userCode">�û����</param>
		/// <param name="password">����</param>
		/// <param name="state">״̬</param>
		/// <returns>�Ƿ�ɹ�</returns>
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
				this.Message = "�û������Ѿ����ڣ������±���";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// ʹԱ�������û�.
		/// </summary>
		/// <param name="thisPKID">PKID</param>
		/// <returns>bool</returns>
		public bool DisableEmployeeIsUser(int thisPKID)
		{
			return new OrganizeDA().DisableEmployeeIsUser(thisPKID);
		}
		/// <summary>
		/// �ƶ�Ա�����ڵĲ���
		/// </summary>
		/// <param name="employeeCodes">Ա�������ַ���.</param>
		/// <param name="employeeCompanyCode">��˾���</param>
		/// <param name="targetDeptCode">Ŀ�겿�ű��.</param>
		/// <returns>bool</returns>
		public bool MoveEmployees(string employeeCodes,string employeeCompanyCode,string targetDeptCode)
		{
			var obj = new OrganizeDA();
			var ret = obj.MoveEmployees(employeeCodes,employeeCompanyCode,targetDeptCode);
			this.Message = obj.Message;
			return ret;
		}
		#endregion
	
		#region "��֯��Ա"
		/// <summary>
		/// ������֯�û��б�
		/// </summary>
		/// <param name="companyCode">��˾</param>
		/// <param name="orgCode">��֯</param>
		/// <param name="userList">�û��б�</param>
		/// <returns>bool</returns>
        public bool SaveOrgUser(string companyCode, string orgCode, string userList)
		{
			return new OrganizeDA().UpdateOrgUser(companyCode,orgCode,userList);
		}

		/// <summary>
		/// �õ���֯�û�
		/// </summary>
		/// <param name="companyCode">��˾����</param>
		/// <param name="orgCode">��֯����</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgUsers(string companyCode,string orgCode)
		{
			return new OrganizeDA().GetOrgUsers(companyCode,orgCode);
		}
		#endregion

		#region "��֯��ְλ����Ա"

		/// <summary>
		/// ������֯��ְλ����Ա����
		/// </summary>
		/// <param name="orgCo">��֯��˾</param>
		/// <param name="orgCode">��֯����</param>
		/// <param name="dutyList">ְλ�����б�</param>
		/// <param name="userList">�û����б�</param>
		/// <returns>bool</returns>
		public bool SaveOrgDutysUsers(string orgCo,string orgCode,string dutyList,string userList)
		{
			return new OrganizeDA().UpdateOrgDutysUsers(orgCo,orgCode,dutyList,userList);
		}	

		/// <summary>
		/// �õ���֯�û�ְλ
		/// </summary>
		/// <param name="companyCode">��˾����</param>
		/// <param name="orgCode">��֯����</param>
		/// <returns>DataSet</returns>
		public DataSet GetOrgUsersDutys(string companyCode,string orgCode)
		{
			return new OrganizeDA().GetOrgUsersDutys(companyCode,orgCode);
		}
		
		#endregion
	}
}
