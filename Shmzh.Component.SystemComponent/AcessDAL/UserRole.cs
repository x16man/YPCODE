using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class UserRole : IUserRole
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 添加组记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_USERROLE = @"
Insert Into mySystemUserRoles (UserCode,RoleCode,CheckCode,Type) 
Values (@UserName, @RoleCode, @CheckCode,@Type) ";


        private  const string SQL_INSERT_USERSROLES_Delete_Content = @"Delete  From mySystemUserRoles "+
            " Where     RoleCode In"+
        "(Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)";

        //private  const string SQL_INSERT_USERSROLES_Delete = @"Delete  From mySystemUserRoles "+
        //    " Where   UserCode In (@UsercodeList) AND RoleCode In"+
        //"(Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)";

        private const string SQL_INSERT_USERSROLES_Insert = @"Insert  Into mySystemUserRoles(UserCode,RoleCode)" +
        " values(@UserCode,@RoleCode)";
                
//        private const string SQL_INSERT_USERSROLES = @"
//Delete  From mySystemUserRoles 
//Where   UserCode In (Select Convert(nvarchar(20),Item) From dbo.String2Table(@UserNameList)) And
//        RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)
//
//Insert  Into mySystemUserRoles(UserCode,RoleCode)
//Select  Convert(nvarchar(20),U.Item) as UserCode,Convert(smallint,R.Item) as RoleCode
//From    dbo.String2Table(@UserNameList) U,dbo.string2Table(@RoleCodeList) R
//";

        private const string SQL_INSERT_USERSROLES_BY_CHECKCODE = @"
Delete  From mySystemUserRoles
Where   UserCode In (Select Convert(nvarchar(20),Item) From dbo.String2Table(@UserCodeList)) And
        CheckCode = @CheckCode And
        Type = @Type
Insert  Into mySystemUserRoles (UserCode, RoleCode, CheckCode, Type)
Select  Convert(nvarchar(20),U.Item) as UserCode,Convert(smallint,R.Item) as RoleCode,@CheckCode,@Type
From    dbo.String2Table(@UserCodeList) U,dbo.String2Table(@RoleCodeList) R
";
        /// <summary>
        /// 删除组记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_USERROLE = @"
Delete  From mySystemUserRoles 
Where   UserCode = @UserName And 
        RoleCode = @RoleCode And 
        CheckCode = @CheckCode And 
        Type = @Type";
        /// <summary>
        /// 根据产品删除某一个用户的角色关联。
        /// </summary>
        private const string SQL_DELETE_BY_USERCODELIST_PRODUCTCODE = @"
Delete From mySystemUserRoles 
Where   UserCode In (Select Convert(nvarchar(20),Item) From dbo.String2Table(@UserCodeList)) And
        RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode)";
        /// <summary>
        /// 根据知识库条目删除某一个用户的角色关联。
        /// </summary>
        private const string SQL_DELETE_BY_USERCODELIST_CHECKCODE_TYPE = @"
Delete  From mySystemUserRoles
Where   UserCode In (Select Convert(nvarchar(20),Item) From dbo.String2Table(@UserCodeList)) And
        CheckCode = @CheckCode And
        Type = @Type";
        /// <summary>
        /// 获取所有有效的用户角色记录。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_USERNAME = @"
Select  UserCode, RoleCode,CheckCode,Type 
From    mySystemUserRoles 
Where   UserCode = @UserName And 
        Exists (Select * From mySystemRoles 
                Where   mySystemRoles.RoleCode = mySystemUserRoles.RoleCode And 
                        mySystemRoles.IsValid ='Y')
Union
Sellect UserCode,RoleCode,CheckCode,Type 
From    (Select GU.UserCode,GR.RoleCode,GR.CheckCode,GR.Type 
         From   mySystemGroupUsers GU,mySystemGroupRoles GR 
         Where  GU.GroupCode = GR.GroupCode And 
                GU.UserCode = @UserName) AS A
Where Exists (  Select * From mySystemRoles B 
                Where   A.RoleCode = B.RoleCode And 
                        B.IsValid = 'Y')
";
        /// <summary>
        /// 根据产品编号来获取用户角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE = @"
Select  UserCode,RoleCode,CheckCode,Type
From    mySystemUserRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y')
";
        /// <summary>
        /// 根据角色编号来获取用户角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_ROLECODE = @"
Select  UserCode,RoleCode,CheckCode,Type
From    mySystemUserRoles
Where   RoleCode = @RoleCode";
        /// <summary>
        /// 根据产品编号和用户名、姓名来获取用户角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE_NAME = @"
Select  UserCode,RoleCode,CheckCode,Type
From    mySystemUserRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        UserCode In (Select LoginName From mySystemUserInfo Where LoginName Like '%'+@Name+'%' OR EmpCnName Like '%'+@Name+'%')
";
        /// <summary>
        /// 根据产品编号和用户名获取用户角色的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_PRODUCTCODE_USERNAME = @"
Select  UserCode,RoleCode,CheckCode,Type
From    mySystemUserRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        UserCode = @UserName
";

        private const string SQL_SELECT_BY_CHECKCODE_TYPE =@"
Select UserCode,RoleCode,CheckCode,Type 
From    mySystemUserRoles
Where   CheckCode = @CheckCode And
        Type = @Type And
        RoleCode In (Select RoleCode From mySystemRoles Where ProductCode=1 And IsValid='Y')";

        private const string SQL_SELECT_BY_CHECKCODE_TYPE_USERNAME = @"
Select  UserCode,RoleCode,CheckCode,Type
From    mySystemUserRoles 
Where   UserCode = @UserName And
        CheckCode = @CheckCode And
        Type = @Type";

        private const string SQL_CLEARACCESS =
            "Delete From mySystemUserRoles Where CheckCode = @CheckCode And Type = @Type";

        private const string SQL_COPYTOUSERROLE_BY_SOURCEUSERNAME_TARGETUSERNAME_PRODUCTCODE = @"
Insert Into mySystemUserRoles Select @TargetUserName As UserCode,RoleCode,CheckCode,Type
From    mySystemUserRoles
Where   RoleCode In (Select RoleCode From mySystemRoles Where ProductCode = @ProductCode And IsValid = 'Y') And
        UserCode = @SourceUserName
";

        #endregion

        #region Private method
        /// <summary>
        /// 获取用户角色参数。
        /// </summary>
        /// <returns>参数数组。</returns>
        private static OleDbParameter[] GetUserRoleParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_USERROLE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@UserName", OleDbType.VarChar,20),
                                new OleDbParameter("@RoleCode", OleDbType.SmallInt), 
                                new OleDbParameter("@CheckCode", OleDbType.VarChar,50), 
                                new OleDbParameter("@Type", OleDbType.Char,1), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_USERROLE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private UserRoleInfo ConvertToUserRoleInfo(IDataRecord dr)
        {
            var obj = new UserRoleInfo
            {
                UserName = dr.GetString(0),
                RoleCode = dr.GetInt16(1),
                CheckCode = dr.GetString(2),
                Type = dr.GetString(3),
            };
            return obj;
        }
        #endregion

        #region IUserRole 成员
        /// <summary>
        /// 添加用户角色。
        /// </summary>
        /// <param name="userRoleInfo">用户角色实体。</param>
        /// <returns>bool</returns>
        public bool Insert(UserRoleInfo userRoleInfo)
        {
            var parms = GetUserRoleParameters();
            parms[0].Value = userRoleInfo.UserName;
            parms[1].Value = userRoleInfo.RoleCode;
            parms[2].Value = userRoleInfo.CheckCode;
            parms[3].Value = userRoleInfo.Type;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_USERROLE, parms);
                return true;
            }
            catch (Exception ex )
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Insert(string userNameList, string roleCodeList, short productCode)
        {
            //var parms = new[]
            //                {
            //                    new OleDbParameter("@UserNameList",OleDbType.VarChar,4000){Value = userNameList},
            //                    new OleDbParameter("@RoleCodeList", OleDbType.VarChar,4000){Value = roleCodeList},
            //                    new OleDbParameter("@ProductCode", OleDbType.SmallInt){Value = productCode}, 
            //                };
            try
            {
                //var parms = new[]
                //{
                //    new OleDbParameter("@UserNameList",OleDbType.VarChar,4000),
                //    new OleDbParameter("@ProductCode", OleDbType.SmallInt),
                //};
                //parms[0].Value = userNameList;
                //parms[1].Value = productCode;
                //AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_INSERT_USERSROLES_Delete, parms);

                if (!DeleteUserRoles(userNameList, productCode))
                    return false;

                string[] username = userNameList.Split(',');

                for(int i = 0 ;i< username.Length ;i++)
                {
                    string [] roleCode = roleCodeList.Split(',');

                    for(int j=0;j<roleCode.Length;j++)
                    {
                        var parms1 = new []
                        {
                            new OleDbParameter("@UserName", OleDbType.VarChar,20),
                            new OleDbParameter("@RoleCode", OleDbType.SmallInt), 
                        };
                        parms1[0].Value = username[i];
                        parms1[1].Value = roleCode[j];
                        AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_USERSROLES_Insert, parms1);
                    }
                    
                }
               
               // AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_USERSROLES, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }


        private bool DeleteUserRoles(string userNameList, short productCode)
        {
            try
            {
                string[] username = userNameList.Split(',');

                int itemp = 1 + username.Length;
                int i = 0;

                string strDelete = SQL_INSERT_USERSROLES_Delete_Content;

                string strtemp = "";

                if (username.Length > 0)
                {
                    strDelete += " AND ( ";
                    for (i = 0; i < username.Length; i++)
                    {
                        strtemp += "Or UserCode = @UserCode" + i.ToString() + " ";
                    }

                    strtemp = strtemp.Substring(2);
                    strDelete += strtemp;
                    strDelete += ")";
                }

                OleDbParameter[] parms = new OleDbParameter[itemp];

                parms[0] = new OleDbParameter();
                parms[0].ParameterName = "@ProductCode";
                parms[0].OleDbType = OleDbType.SmallInt;
                parms[0].Value = productCode;

                for (i = 0; i < username.Length; i++)
                {
                    parms[i + 1] = new OleDbParameter();
                    parms[i + 1].ParameterName = "@UserCode"+i.ToString();
                    parms[i + 1].OleDbType = OleDbType.VarChar;
                    parms[i + 1].Value = username[i];
                }

                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, strDelete, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Insert(string userNameList, string roleCodeList, string checkCode, string type)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@UserCodeList",OleDbType.VarChar,4000){Value = userNameList},
                                new OleDbParameter("@RoleCodeList",OleDbType.VarChar,4000){Value = roleCodeList},
                                new OleDbParameter("@CheckCode", OleDbType.VarChar,50){Value = checkCode},
                                new OleDbParameter("@Type",OleDbType.Char,1){Value = type},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_USERSROLES_BY_CHECKCODE,
                                          parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        
        public bool Delete(UserRoleInfo userRoleInfo)
        {
            var parms = GetUserRoleParameters();
            parms[0].Value = userRoleInfo.UserName;
            parms[1].Value = userRoleInfo.RoleCode;
            parms[2].Value = userRoleInfo.CheckCode;
            parms[3].Value = userRoleInfo.Type;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_USERROLE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(string userNameList, short productCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@UserCodeList", OleDbType.VarChar, 4000) {Value = userNameList},
                                new OleDbParameter("@ProductCode", OleDbType.SmallInt) {Value = productCode},
                            };
            try
            {
                if (DeleteUserRoles(userNameList, productCode))
                    return true;
                else
                    return false;
               // parms[0].Value = userNameList;
                //parms[1].Value = productCode;
               // AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_INSERT_USERSROLES_Delete, parms);
                //AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  
                //                          SQL_DELETE_BY_USERCODELIST_PRODUCTCODE, parms);
               // return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(string userNameList, string checkCode, string type)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@UserCodeList", OleDbType.VarChar, 4000) {Value = userNameList},
                                new OleDbParameter("@CheckCode", OleDbType.VarChar, 50) {Value = checkCode},
                                new OleDbParameter("@Type", OleDbType.Char,1){Value = type},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,  
                                          SQL_DELETE_BY_USERCODELIST_CHECKCODE_TYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool ClearAccess(string checkCode, string type)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CheckCode", OleDbType.VarChar, 50) {Value = checkCode},
                                new OleDbParameter("@Type", OleDbType.Char, 1) {Value = type}
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_CLEARACCESS, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool CopyTo(string sourceUserName, string targetUserName, short productCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@SourceUserName",OleDbType.VarChar,4000){Value = sourceUserName},
                                new OleDbParameter("@TargetUserName",OleDbType.VarChar,4000){Value = targetUserName},
                                new OleDbParameter("@ProductCode", OleDbType.VarChar,50){Value = productCode},
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_COPYTOUSERROLE_BY_SOURCEUSERNAME_TARGETUSERNAME_PRODUCTCODE,
                                          parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public IList<UserRoleInfo> GetByUserName(string userName)
        {
            var parms = GetUserRoleParameters();
            parms[0].Value = userName;
            IList<UserRoleInfo> objs = new List<UserRoleInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  SQL_SELECT_ALLAVALIBLE_BY_USERNAME, parms);
            while (dr.Read())
            {
                var obj = ConvertToUserRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        
        public IList<UserRoleInfo> GetByProductCode(short productCode)
        {
            var parms = new[] {new OleDbParameter("@ProductCode", OleDbType.SmallInt) {Value = productCode}};
            
            IList<UserRoleInfo> objs = new List<UserRoleInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  SQL_SELECT_BY_PRODUCTCODE, parms);
            while (dr.Read())
            {
                var obj = ConvertToUserRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        
        public IList<UserRoleInfo> GetByRoleCode(short roleCode)
        {
            var parms = new[] { new OleDbParameter("@roleCode", OleDbType.SmallInt) { Value = roleCode } };

            IList<UserRoleInfo> objs = new List<UserRoleInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_ROLECODE, parms);
            while (dr.Read())
            {
                var obj = ConvertToUserRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        
        public IList<UserRoleInfo> GetByProductCodeAndName(short productCode, string name)
        {
            var parms = new[]{
                                new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode },
                                new OleDbParameter("@Name",OleDbType.VarChar,50){Value = name}, 
                            };

            IList<UserRoleInfo> objs = new List<UserRoleInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_PRODUCTCODE_NAME, parms);
            while (dr.Read())
            {
                var obj = ConvertToUserRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        
        public IList<UserRoleInfo> GetByProductCodeAndUserName(short productCode, string userName)
        {
            var parms = new[]{
                                new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode },
                                new OleDbParameter("@UserName",OleDbType.VarChar,20){Value = userName}, 
                            };

            IList<UserRoleInfo> objs = new List<UserRoleInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_PRODUCTCODE_USERNAME, parms);
            while (dr.Read())
            {
                var obj = ConvertToUserRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据产品编号和用户名获取用户角色集合。
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <param name="userName">用户名。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        /// <returns>用户角色集合。</returns>
        public IList<UserRoleInfo> GetByProductCodeAndUserNameAndCheckCodeAndType(short productCode, string userName, string checkCode, string type)
        {
            throw new System.NotImplementedException();
        }

        public IList<UserRoleInfo> GetByCheckCodeAndType(string checkCode, string type)
        {
            var parms = GetUserRoleParameters();
            parms[2].Value = checkCode;
            parms[3].Value = type;
            IList<UserRoleInfo> objs = new List<UserRoleInfo>();

            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_CHECKCODE_TYPE, parms);
            while (dr.Read())
            {
                var obj = ConvertToUserRoleInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }

        public IList<UserRoleInfo> GetByCheckCodeAndTypeAndUserName(string checkCode, string type,string userName)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@CheckCode", OleDbType.VarChar, 50) {Value = checkCode},
                                new OleDbParameter("@Type", OleDbType.Char, 1) {Value = type},
                                new OleDbParameter("@UserName", OleDbType.VarChar,20){Value = userName},
                            };
            var objs = new ListBase<UserRoleInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,  
                                             SQL_SELECT_BY_CHECKCODE_TYPE_USERNAME, parms);
            while(dr.Read())
            {
                objs.Add(ConvertToUserRoleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public DataSet GetNoAccessObj(int rightCode, int productcode)
        {
            try
            {
                var strSQL = "select distinct A.CheckCode,A.Type from V_RoleCheckCodeType A where not exists(select CheckCode,Type from (select A.CheckCode,A.Type from V_RoleCheckCodeType A,mySystemRoleRights B Where A.RoleCode=B.RoleCode And B.RightCode=" + rightCode + ") as B where A.checkcode = B.checkcode and  A.Type = B.Type)";
                return AccessHelper.ExecuteDataset(ConnectionString.PubData,   strSQL);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        #endregion

        #region IUserRole 成员
        #endregion
    }
}
