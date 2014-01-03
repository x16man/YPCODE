using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Reflection;
using System.Security.Cryptography;
using log4net;
using Shmzh.Components.SystemComponent.IDAL;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    /// <summary>
    /// 用户对象的SQLServer数据库的数据访问对象。
    /// </summary>
    public class User : IUser
    {
        #region Field

#pragma warning disable 169
        private const string PARM_APPANDCODE = "@AppandCode";
        private const string PARM_BIRTHDAY = "@Birthday";
        private const string PARM_CREATEDATE = "@CreateDate";
        private const string PARM_DEPTCNNAME = "@DeptCnName";
        private const string PARM_DUTYCNNAME = "@DutyCnName";
        private const string PARM_DUTYCODE = "@DutyCode";
        private const string PARM_DUTYENNAME = "@DutyEnName";
        private const string PARM_EMAIL = "@Email";
        private const string PARM_EMPCNNAME = "@EmpCnName";
        private const string PARM_EMPCO = "@EmpCo";
        private const string PARM_EMPCODE = "@EmpCode";
        private const string PARM_EMPDEPT = "@EmpDept";
        private const string PARM_EMPSTATE = "@EmpState";
        private const string PARM_GENDER = "@Gender";
        private const string PARM_IDCARD = "@IDCard";
        private const string PARM_INDATE = "@InDate";
        private const string PARM_ISEMP = "@IsEmp";
        private const string PARM_ISLEAVE = "@IsLeave";
        private const string PARM_ISUSER = "@IsUser";
        private const string PARM_LEAVEDATE = "@LeaveDate";
        private const string PARM_LOGINNAME = "@LoginName";
        private const string PARM_MOBILE = "@Mobile";
        private const string PARM_OFFICECALL = "@OfficeCall";
        private const string PARM_OFFICEFAX = "@OfficeFax";
        private const string PARM_OFFICESUBCALL = "@OfficeSubCall";
        private const string PARM_PASSWORD1 = "@Password1";
        private const string PARM_PASSWORD2 = "@Password2";
        private const string PARM_PKID = "@PKId";
        private const string PARM_USERSTATE = "@UserState";

        /// <summary>
        /// 添加用户记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_USER =
            "Insert Into mySystemUserInfo (EmpCode,EmpCo,EmpDept,DeptCnName,EmpCnName,Gender, Birthday, LoginName,Password1,Password2,AppandCode,EmpState,DutyCode,DutyCnName,DutyEnName,IDCard,OfficeCall,OfficeSubCall,Mobile,OfficeFax,Email,IsUser,UserState,IsEmp,CreateDate,InDate,IsLeave,LeaveDate,UICulture) Values (@EmpCode,@EmpCo,@EmpDept,@DeptCnName,@EmpCnName,@Gender,@Birthday,@LoginName,@Password1,@Password2,@AppandCode,@EmpState,@DutyCode,@DutyCnName,@DutyEnName,@IDCard,@OfficeCall,@OfficeSubCall,@Mobile,@OfficeFax,@Email,@IsUser,@UserState,@IsEmp,@CreateDate,@InDate,@IsLeave,@LeaveDate,@UICulture)";
        /// <summary>
        ///修改用户记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_USER =@"
Update mySystemUserInfo Set 
    EmpCode = @EmpCode
,   EmpCo = @EmpCo
,   EmpDept = @EmpDept
,   DeptCnName = @DeptCnName
,   EmpCnName = @EmpCnName
,   Gender = @Gender
,   BirthDay = @BirthDay
,   LoginName = @LoginName
,   Password1= @Password1
,   Password2=@Password2
,   AppandCode = @AppandCode
,   EmpState = @EmpState
,   DutyCode = @DutyCode
,   DutyCnName = @DutyCnName
,   DutyEnName = @DutyEnName
,   IDCard = @IDCard
,   OfficeCall = @OfficeCall
,   OfficeSubCall = @OfficeSubCall
,   Mobile = @Mobile
,   OfficeFax = @OfficeFax
,   Email = @Email
,   IsUser = @IsUser
,   UserState=@UserState
,   IsEmp = @IsEmp
,   CreateDate = @CreateDate
,   InDate = @InDate
,   IsLeave=@IsLeave
,   LeaveDate=@LeaveDate 
,   UICulture=@UICulture
Where PKID = @PKId";
        /// <summary>
        /// 根据公司编号获取所有用户或员工。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_COMPANY =
            "Select * From mySystemUserInfo Where EmpCo = @CompanyCode";
        /// <summary>
        /// 根据公司编号获取所有的用户。
        /// </summary>
        private const string SQL_SELECT_ALL_USER_BY_COMPANY =
            "SELECT * FROM mySystemUserInfo WHERE EmpCo=@CompanyCode AND IsUser='Y' AND UserState = 'A'";
        /// <summary>
        /// 根据公司编号获取所有的员工。
        /// </summary>
        private const string SQL_SELECT_ALL_EMP_BY_COMPANY =
            "Select * From mySystemUserInfo Where EmpCo = @CompanyCode And IsEmp = 'Y'";
        /// <summary>
        /// 根据公司编号获取所有的内部用户。
        /// </summary>
        private const string SQL_SELECT_INNERUSER_BY_COMPANY = "Select * From mySystemUserInfo Where IsEmp='Y' And IsUser='Y' And EmpCo = @CompanyCode";
        /// <summary>
        /// 根据公司编号和部门编号获取所有的员工(包括子部门）。
        /// </summary>
        private const string SQL_SELECT_ALL_EMP_BY_COMPANY_DEPT_WITHCHILD =@"
SELECT    A.* 
FROM      mySystemUserinfo as A,fun_GetAllSubDeptsByParentDept(@DeptCode,@CompanyCode) AS B 
Where     A.EmpDept=B.DeptCode And 
          A.EmpCo=B.DeptCo And
            A.IsEmp='Y'
UNION
SELECT    A.* 
FROM      mySystemUserinfo as A 
WHERE     A.EmpCo=@CompanyCode And 
        A.EmpDept=@DeptCode And
        A.IsEmp='Y'";
        /// <summary>
        /// 根据公司编号和部门编号获取所有的员工。
        /// </summary>
        private const string SQL_SELECT_ALL_EMP_BY_COMPANY_DEPT =
            "Select * From mySystemUserInfo Where IsEmp='Y' And EmpCo = @CompanyCode And EmpDept=@DeptCode";
        
        /// <summary>
        /// 根据公司编号和部门编号获取所有的用户（包括子部门。）
        /// </summary>
        private const string SQL_SELECT_ALL_USER_BY_COMPANY_DEPT_WITHCHILID = @"
SELECT    A.* 
FROM      mySystemUserinfo as A,fun_GetAllSubDeptsByParentDept(@DeptCode,@CompanyCode) AS B 
Where     A.EmpDept=B.DeptCode And 
        A.EmpCo=B.DeptCo And
        A.IsUser = 'Y'
UNION
SELECT    A.* 
FROM      mySystemUserinfo as A 
WHERE     A.EmpCo=@CompanyCode And 
        A.EmpDept=@DeptCode And
        A.IsUser = 'Y'";
        /// <summary>
        /// 根据公司编号和部门编号获取所有的用户。
        /// </summary>
        private const string SQL_SELECT_ALL_USER_BY_COMPANY_DEPT =
            "Select * From mySystemUserInfo Where IsUser = 'Y' And EmpCo = @CompanyCode And EmpDept=@DeptCode";
        /// <summary>
        /// 根据公司编号和部门编号获取所有的员工和用户（包括子部门）。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_COMPANY_DEPT_WITHCHILD =
            @"
SELECT    A.* 
FROM      mySystemUserinfo as A,fun_GetAllSubDeptsByParentDept(@DeptCode,@CompanyCode) AS B 
Where     A.EmpDept=B.DeptCode And 
        A.EmpCo=B.DeptCo 
UNION
SELECT    A.* 
FROM      mySystemUserinfo as A 
WHERE     A.EmpCo=@CompanyCode And 
        A.EmpDept=@DeptCode ";
        /// <summary>
        /// 根据公司编号和部门编号获取所有的用户和员工。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_COMPANY_DEPT = 
            "Select * From mySystemUserInfo Where EmpCo = @CompanyCode And EmpDept = @DeptCode";
        /// <summary>
        /// 根据组编号获取所有的用户。
        /// </summary>
        private const string SQL_SELECT_ALL_USER_BY_GROUPCODE =@"
Select * From mySystemUserInfo 
Where   LoginName In (Select UserCode From mySystemGroupUsers Where GroupCode = @GroupCode)";

        /// <summary>
        /// 根据ID获取用户的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_ID = "Select * From mySystemUserInfo Where PKID = @PKID";

        /// <summary>
        /// 根据工号获取用户的SQL语句。
        /// </summary>
        private const string SQL_SELECT_USER_BY_EMPCODE = "Select * From mySystemUserInfo Where EmpCode = @EmpCode";
        /// <summary>
        /// 根据公司编号和工号获取用户的SQL语句。
        /// </summary>
        private const string SQL_SELECT_USER_BY_COMPANYCODE_EMPCODE =
            "Select * From mySystemUserInfo Where EmpCo = @CompanyCode And EmpCode = @EmpCode";
        /// <summary>
        /// 根据公司编号和用户名获取用户的SQL语句。
        /// </summary>
        private const string SQL_SELECT_USER_BY_COMPANYCODE_LOGINNAME = 
            "Select * From mySystemUserInfo Where EmpCo = @CompanyCode And LoginName = @LoginName";
        /// <summary>
        /// 根据登录名获取用户的SQL语句。
        /// </summary>
        private const string SQL_SELECT_USER_BY_LOGINNAME =
            "Select * From mySystemUserInfo Where LoginName = @LoginName";

        private const string SQL_SELECT_USER_BY_MOBILE =
            "Select * From mySystemUserInfo Where Mobile = @Mobile";
        /// <summary>
        /// 根据产品编号获取用户的SQL语句。
        /// </summary>
        private const string SQL_SELECT_USER_BY_PRODUCTCODE =
            @"
Select * from mySystemUserInfo 
Where LoginName in (Select distinct usercode From mySystemUserRoles 
                    Where RoleCode in (Select RoleCode From mySystemRoles 
                                       Where  ProductCode = @ProductCode And 
                                              IsValid = 'Y'))";

        private const string SQL_SELECT_USER_BY_ROLECODE = @"
Select * From mySystemUserInfo
Where   LoginName In (Select UserCode From mySystemUserRoles Where RoleCode = @RoleCode)";

        private const string SQL_SELECT_ALL_BY_COMPANY_QUERYCONTENT = @"
Select  * From mySystemUserInfo 
Where   EmpCo = @CompanyCode And 
        (EmpCode like '%+@Name+%' Or EmpCnName Like '%'+@Name+'%' Or LoginName Like '%'+@Name+'%')";
        private const string SQL_SELECT_ALLUSER_BY_COMPANY_QUERYCONTENT = @"
Select  * From mySystemUserInfo 
Where   EmpCo = @CompanyCode And 
        IsUser = 'Y' And
        (EmpCode like '%'+@Name+'%' Or EmpCnName Like '%'+@Name+'%' Or LoginName Like '%'+@Name+'%')";
        private const string SQL_SELECT_ALLEMP_BY_COMPANY_QUERYCONTENT = @"
Select  * From mySystemUserInfo 
Where   EmpCo = @CompanyCode And 
        IsEmp = 'Y' And
        (EmpCode like '%'+@Name+'%' Or EmpCnName Like '%'+@Name+'%' Or LoginName Like '%'+@Name+'%')";
        private const string SQL_SELECT_ALLAVALIBLE_BY_COMPANY_RIGHTCODE = @"
Select * From mySystemUserInfo
Where   EmpCo = @CompanyCode And
        IsUser = 'Y' And
        UserState = 'A' And
        LoginName In (Select Distinct UserCode From mySystemUserRoles 
                      Where RoleCode In (Select A.RoleCode From mySystemRoleRights A,mySystemRoles B
                                         Where  A.RightCode = @RightCode And 
                                                A.RoleCode = B.RoleCode And
                                                B.IsValid = 'Y')
                      Union
                      Select Distinct UserCode From mySystemGroupUsers 
                      Where  GroupCode In (Select GroupCode From mySystemGroupRoles A,mySystemRoles B
                                           Where A.RoleCode = B.RoleCode And
                                                 B.RoleCode In (Select R.RoleCode From mySystemRoleRights RR,mySystemRoles R
                                                                Where RR.RightCode = @RightCode And
                                                                      RR.RoleCode = R.RoleCode And
                                                                      R.IsValid = 'Y')))
";

        /// <summary>
        /// 根据权限编号判断用户是否拥有权限的SQl语句。
        /// </summary>
        private const string SQL_HASRIGHT_BY_RIGHTCODE = @"
SELECT  COUNT(*)
FROM    dbo.mySystemRoleRights
WHERE   RightCode = @RightCode AND
        RoleCode IN ( SELECT    DISTINCT RoleCode
                      FROM      dbo.ViewUsersRoles a
                      WHERE     UserCode = @UserName AND
                                EXISTS ( SELECT *
                                         FROM   mysystemroles b
                                         WHERE  a.RoleCode = b.RoleCode AND
                                                b.IsValid = 'Y' ) )";
        /// <summary>
        /// 根据权限编号和知识库项目ID和类型来判断用户是否对知识库项目拥有权限的SQL语句。
        /// </summary>
        private const string SQL_HASRIGHT_BY_RIGHTCODE_CHECKCODE_TYPE = @"
SELECT  COUNT(*)
FROM    dbo.mySystemRoleRights
WHERE   RightCode = @RightCode AND
        RoleCode IN ( SELECT    DISTINCT RoleCode
                      FROM      dbo.ViewUsersRoles a
                      WHERE     CheckCode = @CheckCode And
                                Type = @Type And
                                UserCode = @UserName AND
                                EXISTS ( SELECT *
                                         FROM   mysystemroles b
                                         WHERE  a.RoleCode = b.RoleCode AND
                                                b.IsValid = 'Y' ) )";
        private static readonly ILog Logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion

        #region Tree

        private List<DeptInfo> deptTree = new List<DeptInfo>();
        #endregion

        #region Private Method

        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static OleDbParameter[] GetUserParameters()
        {
            OleDbParameter[] parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData,
                                                                                 SQL_INSERT_USER);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter(PARM_EMPCODE, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_EMPCO, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_EMPDEPT, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_DEPTCNNAME, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_EMPCNNAME, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_GENDER, OleDbType.Char, 1),
                                new OleDbParameter(PARM_BIRTHDAY, OleDbType.Date),
                                new OleDbParameter(PARM_LOGINNAME, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_PASSWORD1, OleDbType.VarChar, 255),
                                new OleDbParameter(PARM_PASSWORD2, OleDbType.VarChar, 255),
                                new OleDbParameter(PARM_APPANDCODE, OleDbType.VarChar, 255),
                                new OleDbParameter(PARM_EMPSTATE, OleDbType.Char, 1),
                                new OleDbParameter(PARM_DUTYCODE, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_DUTYCNNAME, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_DUTYENNAME, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_IDCARD, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_OFFICECALL, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_OFFICESUBCALL, OleDbType.VarChar, 20),
                                new OleDbParameter(PARM_MOBILE, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_OFFICEFAX, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_EMAIL, OleDbType.VarChar, 50),
                                new OleDbParameter(PARM_ISUSER, OleDbType.Char, 1),
                                new OleDbParameter(PARM_USERSTATE, OleDbType.Char, 1),
                                new OleDbParameter(PARM_ISEMP, OleDbType.Char, 1),
                                new OleDbParameter(PARM_CREATEDATE, OleDbType.Date),
                                new OleDbParameter(PARM_INDATE, OleDbType.Date),
                                new OleDbParameter(PARM_ISLEAVE, OleDbType.Char, 1),
                                new OleDbParameter(PARM_LEAVEDATE, OleDbType.Date),
                                new OleDbParameter(PARM_PKID, OleDbType.Integer) {Direction = ParameterDirection.InputOutput},

                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_USER, parms);
            }
            return parms;
        }

        /// <summary>
        /// 将SqlDataReader转换为TemplateInfo实体。
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <returns>模板实体。</returns>
        private UserInfo ConvertToUserInfo(IDataRecord dr)
        {
            var obj = new UserInfo
                          {
                              PKID = dr.GetInt32(0),
                              EmpCode = dr["EmpCode"] == DBNull.Value ? string.Empty : dr["EmpCode"].ToString(),
                              EmpCo = dr["EmpCo"] == DBNull.Value ? string.Empty : dr["EmpCo"].ToString(),
                              DeptCode = dr["EmpDept"] == DBNull.Value ? string.Empty : dr["EmpDept"].ToString(),
                              DeptName = dr["DeptCnName"] == DBNull.Value ? string.Empty : dr["DeptCnName"].ToString(),
                              EmpName = dr["EmpCnName"] == DBNull.Value ? string.Empty : dr["EmpCnName"].ToString(),
                              EmpEnName = dr["EmpEnName"] == DBNull.Value ? string.Empty : dr["EmpEnName"].ToString(),
                              Gender = dr["Gender"].ToString(),
                              BirthDay =
                                  dr["BirthDay"] == DBNull.Value
                                      ? DateTime.MinValue
                                      : DateTime.Parse(dr["BirthDay"].ToString()),
                              LoginName = dr["LoginName"] == DBNull.Value ? string.Empty : dr["LoginName"].ToString(),
                              Password1 = dr["Password1"] == DBNull.Value ? string.Empty : dr["Password1"].ToString(),
                              Password2 = dr["Password2"] == DBNull.Value ? string.Empty : dr["Password2"].ToString(),
                              AppandCode = dr["AppandCode"] == DBNull.Value ? string.Empty : dr["AppandCode"].ToString(),
                              EmpState = dr["EmpState"] == DBNull.Value ? string.Empty : dr["EmpState"].ToString(),
                              DutyCode = dr["DutyCode"] == DBNull.Value ? string.Empty : dr["DutyCode"].ToString(),
                              DutyName = dr["DutyCnName"] == DBNull.Value ? string.Empty : dr["DutyCnName"].ToString(),
                              DutyEnName = dr["DutyEnName"] == DBNull.Value ? string.Empty : dr["DutyEnName"].ToString(),
                              IDCard = dr["IDCard"] == DBNull.Value ? string.Empty : dr["IDCard"].ToString(),
                              OfficeCall = dr["OfficeCall"] == DBNull.Value ? string.Empty : dr["OfficeCall"].ToString(),
                              OfficeSubCall =
                                  dr["OfficeSubCall"] == DBNull.Value ? string.Empty : dr["OfficeSubCall"].ToString(),
                              Mobile = dr["Mobile"] == DBNull.Value ? string.Empty : dr["Mobile"].ToString(),
                              OfficeFax = dr["OfficeFax"] == DBNull.Value ? string.Empty : dr["Mobile"].ToString(),
                              EMail = dr["EMail"] == DBNull.Value ? string.Empty : dr["Email"].ToString(),
                              IsUser = dr["IsUser"].ToString(),
                              UserState = dr["UserState"].ToString(),
                              IsEmp = dr["IsEmp"] == DBNull.Value ? string.Empty : dr["IsEmp"].ToString(),
                              CreateDate =
                                  dr["CreateDate"] == DBNull.Value
                                      ? DateTime.MinValue
                                      : DateTime.Parse(dr["CreateDate"].ToString()),
                              InDate =
                                  dr["InDate"] == DBNull.Value
                                      ? DateTime.MinValue
                                      : DateTime.Parse(dr["InDate"].ToString()),
                              IsLeave = dr["IsLeave"] == DBNull.Value ? string.Empty : dr["IsLeave"].ToString(),
                              LeaveDate =
                                  dr["LeaveDate"] == DBNull.Value
                                      ? DateTime.MinValue
                                      : DateTime.Parse(dr["LeaveDate"].ToString()),
                          };
            return obj;
        }

        private void CreateTree(List<DeptInfo> objs,string deptCode)
        {
            var childDepts = objs.FindAll(z => z.ParentDept == deptCode);
            if(childDepts.Count > 0)
            {
                foreach (var dept in childDepts)
                {
                    this.deptTree.Add(dept);
                    CreateTree(objs, dept.DeptCode);
                }
            }
        }
        
        #endregion

        #region IUser 成员

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户实体对象。</param>
        /// <returns>bool</returns>
        public bool Insert(UserInfo userInfo)
        {
            var parms = new[]
                             {
                                new OleDbParameter("@EmpCode",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.EmpCode) ? (object) DBNull.Value : userInfo.EmpCode},
                                new OleDbParameter("@EmpCo", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.EmpCo) ? (object) DBNull.Value : userInfo.EmpCo},
                                new OleDbParameter("@EmpDept", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.DeptCode) ? (object) DBNull.Value : userInfo.DeptCode},
                                new OleDbParameter("@DeptCnName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.DeptName) ? (object) DBNull.Value : userInfo.DeptName},
                                new OleDbParameter("@EmpCnName", OleDbType.VarWChar,20){Value = string.IsNullOrEmpty(userInfo.EmpName) ? (object) DBNull.Value : userInfo.EmpName},
                                new OleDbParameter("@Gender", OleDbType.Char,1){Value = userInfo.Gender},
                                new OleDbParameter("@Birthday", OleDbType.Date){Value = userInfo.BirthDay == DateTime.MinValue ? (object) DBNull.Value : userInfo.BirthDay},
                                new OleDbParameter("@LoginName",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.LoginName) ? (object) DBNull.Value : userInfo.LoginName},
                                new OleDbParameter("@Password1",OleDbType.VarChar,255){Value = string.IsNullOrEmpty(userInfo.Password1) ? (object) DBNull.Value : userInfo.Password1},
                                new OleDbParameter("@Password2", OleDbType.VarChar,255){Value = string.IsNullOrEmpty(userInfo.Password2) ? (object) DBNull.Value : userInfo.Password2},
                                new OleDbParameter("@AppandCode", OleDbType.VarChar,255){Value = string.IsNullOrEmpty(userInfo.AppandCode) ? (object) DBNull.Value : userInfo.AppandCode},
                                new OleDbParameter("@EmpState", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.EmpState) ? (object) DBNull.Value : userInfo.EmpState},
                                new OleDbParameter("@DutyCode", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.DutyCode) ? (object) DBNull.Value : userInfo.DutyCode},
                                new OleDbParameter("@DutyCnName", OleDbType.VarWChar,20){Value = string.IsNullOrEmpty(userInfo.DutyName) ? (object) DBNull.Value : userInfo.DutyName},
                                new OleDbParameter("@DutyEnName", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.DutyEnName) ? (object) DBNull.Value : userInfo.DutyEnName},
                                new OleDbParameter("@IDCard", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.IDCard) ? (object) DBNull.Value : userInfo.IDCard},
                                new OleDbParameter("@OfficeCall", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.OfficeCall) ? (object) DBNull.Value : userInfo.OfficeCall},
                                new OleDbParameter("@OfficeSubCall", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.OfficeSubCall)? (object) DBNull.Value: userInfo.OfficeSubCall},
                                new OleDbParameter("@Mobile", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.Mobile) ? (object) DBNull.Value : userInfo.Mobile},
                                new OleDbParameter("@OfficeFax", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.OfficeFax) ? (object) DBNull.Value : userInfo.OfficeFax},
                                new OleDbParameter("@Email", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.EMail) ? (object) DBNull.Value : userInfo.EMail},
                                new OleDbParameter("@IsUser", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.IsUser) ? (object) DBNull.Value : userInfo.IsUser},
                                new OleDbParameter("@UserState", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.UserState) ? (object) DBNull.Value : userInfo.UserState},
                                new OleDbParameter("@IsEmp", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.IsEmp) ? (object) DBNull.Value : userInfo.IsEmp},
                                new OleDbParameter("@CreateDate", OleDbType.Date){Value = userInfo.CreateDate == DateTime.MinValue ? (object) DBNull.Value : userInfo.CreateDate},
                                new OleDbParameter("@InDate", OleDbType.Date){Value = userInfo.InDate == DateTime.MinValue ? (object) DBNull.Value : userInfo.InDate},
                                new OleDbParameter("@IsLeave", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.IsLeave) ? (object) DBNull.Value : userInfo.IsLeave},
                                new OleDbParameter("@LeaveDate", OleDbType.Date){Value = userInfo.LeaveDate == DateTime.MinValue ? (object) DBNull.Value : userInfo.LeaveDate},
                                //new OleDbParameter("@PKId", OleDbType.Integer){Direction = ParameterDirection.InputOutput,Value = 0},
        };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_USER, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更改用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        public bool Update(UserInfo userInfo)
        {
            var parms = new[]
                             {
                                new OleDbParameter("@EmpCode",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.EmpCode) ? (object) DBNull.Value : userInfo.EmpCode},
                                new OleDbParameter("@EmpCo", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.EmpCo) ? (object) DBNull.Value : userInfo.EmpCo},
                                new OleDbParameter("@EmpDept", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.DeptCode) ? (object) DBNull.Value : userInfo.DeptCode},
                                new OleDbParameter("@DeptCnName",OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.DeptName) ? (object) DBNull.Value : userInfo.DeptName},
                                new OleDbParameter("@EmpCnName", OleDbType.VarWChar,20){Value = string.IsNullOrEmpty(userInfo.EmpName) ? (object) DBNull.Value : userInfo.EmpName},
                                new OleDbParameter("@Gender", OleDbType.Char,1){Value = userInfo.Gender},
                                new OleDbParameter("@Birthday", OleDbType.Date){Value = userInfo.BirthDay == DateTime.MinValue ? (object) DBNull.Value : userInfo.BirthDay},
                                new OleDbParameter("@LoginName",OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.LoginName) ? (object) DBNull.Value : userInfo.LoginName},
                                new OleDbParameter("@Password1",OleDbType.VarChar,255){Value = string.IsNullOrEmpty(userInfo.Password1) ? (object) DBNull.Value : userInfo.Password1},
                                new OleDbParameter("@Password2", OleDbType.VarChar,255){Value = string.IsNullOrEmpty(userInfo.Password2) ? (object) DBNull.Value : userInfo.Password2},
                                new OleDbParameter("@AppandCode", OleDbType.VarChar,255){Value = string.IsNullOrEmpty(userInfo.AppandCode) ? (object) DBNull.Value : userInfo.AppandCode},
                                new OleDbParameter("@EmpState", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.EmpState) ? (object) DBNull.Value : userInfo.EmpState},
                                new OleDbParameter("@DutyCode", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.DutyCode) ? (object) DBNull.Value : userInfo.DutyCode},
                                new OleDbParameter("@DutyCnName", OleDbType.VarWChar,20){Value = string.IsNullOrEmpty(userInfo.DutyName) ? (object) DBNull.Value : userInfo.DutyName},
                                new OleDbParameter("@DutyEnName", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.DutyEnName) ? (object) DBNull.Value : userInfo.DutyEnName},
                                new OleDbParameter("@IDCard", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.IDCard) ? (object) DBNull.Value : userInfo.IDCard},
                                new OleDbParameter("@OfficeCall", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.OfficeCall) ? (object) DBNull.Value : userInfo.OfficeCall},
                                new OleDbParameter("@OfficeSubCall", OleDbType.VarChar,20){Value = string.IsNullOrEmpty(userInfo.OfficeSubCall)? (object) DBNull.Value: userInfo.OfficeSubCall},
                                new OleDbParameter("@Mobile", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.Mobile) ? (object) DBNull.Value : userInfo.Mobile},
                                new OleDbParameter("@OfficeFax", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.OfficeFax) ? (object) DBNull.Value : userInfo.OfficeFax},
                                new OleDbParameter("@Email", OleDbType.VarChar,50){Value = string.IsNullOrEmpty(userInfo.EMail) ? (object) DBNull.Value : userInfo.EMail},
                                new OleDbParameter("@IsUser", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.IsUser) ? (object) DBNull.Value : userInfo.IsUser},
                                new OleDbParameter("@UserState", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.UserState) ? (object) DBNull.Value : userInfo.UserState},
                                new OleDbParameter("@IsEmp", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.IsEmp) ? (object) DBNull.Value : userInfo.IsEmp},
                                new OleDbParameter("@CreateDate", OleDbType.Date){Value = userInfo.CreateDate == DateTime.MinValue ? (object) DBNull.Value : userInfo.CreateDate},
                                new OleDbParameter("@InDate", OleDbType.Date){Value = userInfo.InDate == DateTime.MinValue ? (object) DBNull.Value : userInfo.InDate},
                                new OleDbParameter("@IsLeave", OleDbType.Char,1){Value = string.IsNullOrEmpty(userInfo.IsLeave) ? (object) DBNull.Value : userInfo.IsLeave},
                                new OleDbParameter("@LeaveDate", OleDbType.Date){Value = userInfo.LeaveDate == DateTime.MinValue ? (object) DBNull.Value : userInfo.LeaveDate},
                                new OleDbParameter("@PKId", OleDbType.Integer){Value = userInfo.PKID},
        };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE_USER, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <returns>bool</returns>
        public bool Delete(UserInfo userInfo)
        {
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,
                                             "Delete From mySystemGroupUsers Where UserCode = @UserCode",
                                             new[]
                                                 {
                                                     new OleDbParameter("@UserCode", OleDbType.VarChar, 20)
                                                         {Value = userInfo.LoginName},
                                                 });
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, "Delete Delete From mySystemUserRoles Where UserCode = @UserCode ", new[]
                                                 {
                                                     new OleDbParameter("@UserCode", OleDbType.VarChar, 20)
                                                         {Value = userInfo.LoginName},
                                                 });
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, "Delete From mySystemUserInfo Where pkid=@PKID",
                                             new[]
                                                 {
                                                     new OleDbParameter("@PKID", OleDbType.Integer) {Value = userInfo.PKID}
                                                 });
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除用户实体。
        /// </summary>
        /// <param name="id">用户id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var userInfo = DataProvider.UserProvider.GetById(id);
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,
                                             "Delete From mySystemGroupUsers Where UserCode = @UserCode",
                                             new[]
                                                 {
                                                     new OleDbParameter("@UserCode", OleDbType.VarChar, 20)
                                                         {Value = userInfo.LoginName},
                                                 });
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, "Delete Delete From mySystemUserRoles Where UserCode = @UserCode ", new[]
                                                 {
                                                     new OleDbParameter("@UserCode", OleDbType.VarChar, 20)
                                                         {Value = userInfo.LoginName},
                                                 });
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, "Delete From mySystemUserInfo Where pkid=@PKID",
                                             new[]
                                                 {
                                                     new OleDbParameter("@PKID", OleDbType.Integer) {Value = userInfo.PKID}
                                                 });
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据ID获取用户对象。
        /// </summary>
        /// <param name="id">用户ID。</param>
        /// <returns>用户对象。</returns>
        public UserInfo GetById(int id)
        {
            UserInfo userInfo = null;
            var parms = new[] {new OleDbParameter("@PKID", OleDbType.Integer) {Value = id},};

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_ID,
                                                       parms);
            while (dr.Read())
            {
                userInfo = ConvertToUserInfo(dr);
                break;
            }
            dr.Close();
            return userInfo;
        }

        /// <summary>
        /// 根据产品号获取用户集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByProductCode(short productCode)
        {
            var parms = new[] {new OleDbParameter("@ProductCode", OleDbType.SmallInt) {Value = productCode}};
            IList<UserInfo> objs = new ListBase<UserInfo>();
            OleDbDataReader dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_USER_BY_PRODUCTCODE,
                                                       parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据组编号获取用户。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByGroupCode(short groupCode)
        {
            var parms = new[] { new OleDbParameter("@GroupCode", OleDbType.SmallInt) { Value = groupCode } };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_ALL_USER_BY_GROUPCODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号获取所有员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllByCompany(string companyCode)
        {
            var parms = new[] { new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) { Value = companyCode } };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_BY_COMPANY,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompany(string companyCode)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据公司编号获取所有用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllUserByCompany(string companyCode)
        {
            var parms = new[] {new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode}};
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_ALL_USER_BY_COMPANY, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据角色编号获取用户。
        /// </summary>
        /// <param name="roleCode">角色编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetByRoleCode(short roleCode)
        {
            var parms = new[] {new OleDbParameter("@RoleCode", OleDbType.SmallInt) {Value = roleCode}};
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_USER_BY_ROLECODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号获取内部用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetInnerUserByCompany(string companyCode)
        {
            var parms = new[] { new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) { Value = companyCode } };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_INNERUSER_BY_COMPANY, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号获取所有员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllEmployeeByCompany(string companyCode)
        {
            var parms = new[] { new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) { Value = companyCode } };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_ALL_EMP_BY_COMPANY, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号和部门编号获取所有的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode}
                            };
            var objs = new ListBase<UserInfo>();
            OleDbDataReader dr;
            if (!withChildDept)
            {
                dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_BY_COMPANY_DEPT, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToUserInfo(dr));
                }
                dr.Close();

            }
            else
            {
                var depts = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(companyCode) as List<DeptInfo>;
                this.deptTree.Clear();
                if (depts != null)
                {
                    var dept = depts.Find(z => z.DeptCode == deptCode);
                    if (dept != null)
                    {
                        this.deptTree.Add(dept);
                        this.CreateTree(depts, dept.DeptCode);
                    }
                    foreach (var obj in deptTree)
                    {
                        dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_BY_COMPANY_DEPT,
                                                        new[]
                                                            {
                                                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20)
                                                                    {Value = companyCode},
                                                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20)
                                                                    {Value = obj.DeptCode},
                                                            });
                        while (dr.Read())
                        {
                            objs.Add(ConvertToUserInfo(dr));
                        }
                        dr.Close();
                    }
                }
            }
            return objs;
        }

        /// <summary>
        /// 根据公司编号和部门编号获取所有有效的员工和用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            throw new System.NotImplementedException();
        }

        public IList<UserInfo> GetAllAvalibleByCompanyAndDeptIds(string companyCode, string deptIds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据公司编号和部门编号获取员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门的员工。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllEmployeeByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode}
                            };
            var objs = new ListBase<UserInfo>();
            OleDbDataReader dr;
            if(!withChildDept)
            {
                dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_EMP_BY_COMPANY_DEPT, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToUserInfo(dr));
                }
                dr.Close();
                
            }
            else
            {
                var depts = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(companyCode) as List<DeptInfo>;
                this.deptTree.Clear();
                if (depts != null)
                {
                    var dept = depts.Find(z => z.DeptCode == deptCode);
                    if(dept != null)
                    {
                        this.deptTree.Add(dept);
                        this.CreateTree(depts, dept.DeptCode);
                    }
                    foreach(var obj in deptTree)
                    {
                        dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_EMP_BY_COMPANY_DEPT,
                                                        new[]
                                                            {
                                                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20)
                                                                    {Value = companyCode},
                                                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20)
                                                                    {Value = obj.DeptCode},
                                                            });
                        while (dr.Read())
                        {
                            objs.Add(ConvertToUserInfo(dr));
                        }
                        dr.Close();
                    }
                }
            }
            return objs;
        }

        /// <summary>
        /// 根据公司编号和部门编号获取用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="deptCode">部门编号。</param>
        /// <param name="withChildDept">是否包括子部门的用户。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllUserByCompanyAndDept(string companyCode, string deptCode, bool withChildDept)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20) {Value = deptCode}
                            };
            var objs = new ListBase<UserInfo>();
            OleDbDataReader dr;
            if(!withChildDept)
            {
                dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_USER_BY_COMPANY_DEPT, parms);
                while (dr.Read())
                {
                    objs.Add(ConvertToUserInfo(dr));
                }
                dr.Close();
                
            }
            else
            {
                var depts = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(companyCode) as List<DeptInfo>;
                this.deptTree.Clear();
                if (depts != null)
                {
                    var dept = depts.Find(z => z.DeptCode == deptCode);
                    if(dept != null)
                    {
                        this.deptTree.Add(dept);
                        this.CreateTree(depts, dept.DeptCode);
                    }
                    foreach(var obj in deptTree)
                    {
                        dr = AccessHelper.ExecuteReader(ConnectionString.PubData, SQL_SELECT_ALL_USER_BY_COMPANY_DEPT,
                                                        new[]
                                                            {
                                                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20)
                                                                    {Value = companyCode},
                                                                new OleDbParameter("@DeptCode", OleDbType.VarChar, 20)
                                                                    {Value = obj.DeptCode},
                                                            });
                        while (dr.Read())
                        {
                            objs.Add(ConvertToUserInfo(dr));
                        }
                        dr.Close();
                    }
                }
            }
            return objs;

            
            
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找人员。
        /// </summary>
        /// <param name="companyCode">公司编号</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合.</returns>
        public IList<UserInfo> SearchAll(string companyCode, string name)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@Name", OleDbType.VarChar, 20) {Value = name}
                            };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                             SQL_SELECT_ALL_BY_COMPANY_QUERYCONTENT, parms);
            while(dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找非禁用人员。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名.</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchAllAvalible(string companyCode, string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据公司编号和输入的名称（用户名、姓名）模糊查找员工。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchEmp(string companyCode, string name)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@Name", OleDbType.VarChar, 20) {Value = name}
                            };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                             SQL_SELECT_ALLEMP_BY_COMPANY_QUERYCONTENT, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号和名称（用户名、姓名）模糊查找用户。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="name">用户名、姓名。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> SearchUser(string companyCode, string name)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@Name", OleDbType.VarChar, 20) {Value = name}
                            };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                             SQL_SELECT_ALLUSER_BY_COMPANY_QUERYCONTENT, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据公司编号和登录名获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户。</returns>
        public UserInfo GetByCompanyAndLoginName(string companyCode, string loginName)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@LoginName", OleDbType.VarChar, 20) {Value = loginName}
                            };
            UserInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_USER_BY_COMPANYCODE_LOGINNAME,
                                             parms);
            while (dr.Read())
            {
                obj = ConvertToUserInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据公司编号和工号获取用户信息。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByCompanyAndEmpCode(string companyCode, string empCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@EmpCode", OleDbType.VarChar, 20) {Value = empCode}
                            };
            UserInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_USER_BY_COMPANYCODE_EMPCODE,
                                             parms);
            while(dr.Read())
            {
                obj = ConvertToUserInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        /// <summary>
        /// 根据登录名获取用户信息。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByLoginName(string loginName)
        {
            UserInfo userInfo = null;
            OleDbParameter[] parms = new[]
                                         {new OleDbParameter("@LoginName", OleDbType.VarChar, 20) {Value = loginName},};
            

            OleDbDataReader dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_USER_BY_LOGINNAME,
                                                       parms);
            while (dr.Read())
            {
                userInfo = ConvertToUserInfo(dr);
                break;
            }
            dr.Close();
            return userInfo;
        }

        /// <summary>
        /// 根据工号获取用户信息。
        /// </summary>
        /// <param name="empCode">工号。</param>
        /// <returns>用户实体。</returns>
        public UserInfo GetByEmpCode(string empCode)
        {
            UserInfo userInfo = null;
            var parms = GetUserParameters();
            parms[1].Value = empCode;

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                                       SQL_SELECT_USER_BY_EMPCODE,
                                                       parms);
            while (dr.Read())
            {
                userInfo = ConvertToUserInfo(dr);
                break;
            }
            dr.Close();
            return userInfo;
        }

        /// <summary>
        /// 根据手机号码获取用户。
        /// </summary>
        /// <param name="mobile">手机号码。</param>
        /// <returns>用户。</returns>
        public UserInfo GetByMobile(string mobile)
        {
            UserInfo obj = null;
            var parms = new[] {new OleDbParameter(PARM_MOBILE, OleDbType.VarChar, 50) {Value = mobile}};
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_USER_BY_MOBILE,
                                             parms);
            while (dr.Read())
            {
                obj = ConvertToUserInfo(dr);
                break;
            }
            return obj;
        }

        /// <summary>
        /// 设置口令。
        /// </summary>
        /// <param name="loginName">登录名。</param>
        /// <param name="pwd">原始口令。</param>
        /// <returns>bool</returns>
        public bool SetPassword(string loginName, string pwd)
        {
            var obj = this.GetByLoginName(loginName);
            return SystemComponent.User.ResetPassword(obj);
        }

        #endregion

        #region IUser 成员

        /// <summary>
        /// 根据公司编号或权限编码获取该公司下具有该权限的用户集合。
        /// </summary>
        /// <param name="companyCode">公司编号。</param>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetAllAvalibleByCompanyAndRightCode(string companyCode, short rightCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CompanyCode", OleDbType.VarChar, 20) {Value = companyCode},
                                new OleDbParameter("@RightCode", OleDbType.SmallInt) {Value = rightCode},
                            };
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                             SQL_SELECT_ALLAVALIBLE_BY_COMPANY_RIGHTCODE, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion

        /// <summary>
        /// 根据SQL语句来获取用户集合。
        /// </summary>
        /// <param name="sqlStatement">SQL语句。</param>
        /// <returns>用户集合。</returns>
        public IList<UserInfo> GetBySQL(string sqlStatement)
        {
            var objs = new ListBase<UserInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToUserInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #region IUser 成员

        /// <summary>
        /// 添加用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Insert(UserInfo userInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更改用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Update(UserInfo userInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="userInfo">用户对象。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(UserInfo userInfo, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户实体。
        /// </summary>
        /// <param name="id">用户Id。</param>
        /// <param name="trans">事务对象。</param>
        /// <returns>bool</returns>
        public bool Delete(int id, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取指定部门的部门主管工号。
        /// </summary>
        /// <param name="strDeptCode">部门编号。</param>
        /// <returns>部门主管工号。</returns>
        public string GetDeptMgr(string strDeptCode)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUser 成员

        /// <summary>
        /// 根据登录名来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string loginName)
        {
            if (loginName.ToLower() == "administrator")
                return true;

            //var parms = Get_HasRight_By_RightCode_Parameters();
            var parms = new[]
                            {
                                new OleDbParameter("@RightCode", OleDbType.Integer) {Value = rightCode},
                                new OleDbParameter("@UserName", OleDbType.VarChar, 20) {Value = loginName},
                            };

            try
            {
                var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData, SQL_HASRIGHT_BY_RIGHTCODE, parms);
                return (int)obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据登录名和文章编号来判断是否拥有指定的权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <param name="loginName">登录名。</param>
        /// <param name="docCode">文章编号。</param>
        /// <returns>bool</returns>
        public bool HasRight(int rightCode, string loginName, string docCode)
        {
            throw new NotImplementedException();
        }

       

        #endregion

        #region IUser 成员

        /// <summary>
        /// 创建Salt值。
        /// </summary>
        /// <returns></returns>
        public string CreateSalt()
        {
            // Generate a cryptographic random number using the cryptographic
            // service provider
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[128];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        #endregion
    }
}