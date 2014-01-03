using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class SESchema :IDAL.ISESchema
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = @"
Insert Into SESchema ([ModuleId],[UserCode],[SchemaName],[WhereClause],[Remark],[IsDefault],[CreateTime] )
Values (@ModuleId,@UserCode,@SchemaName,@WhereClause,@Remark,@IsDefault,@CreateTime)";
        private const string SQL_UPDATE = @"
Update SESchema 
Set [ModuleId] = @ModuleId
,   [UserCode] = @UserCode
,   [SchemaName] = @SchemaName
,   [WhereClause] = @WhereClause
,   [Remark] = @Remark
,   [IsDefault] = @IsDefault
,   [CreateTime] = @CreateTime
Where   [Id] = @Id
";
        private const string SQL_DELETE = @"Delete From SESchema Where [Id] = @Id";
        private const string SQL_SELECT_BY_MODULE_USER = "Select * From SESchema Where [ModuleId] = @ModuleId And [UserCode] = @UserCode";
        private const string SQL_SELECT_DEFAULT_BY_MODULE_USER = "Select * From SESchema Where [ModuleId] = @ModuleId And [UserCode] = @UserCode And [IsDefault]=1";
        private const string SQL_SELECT_BY_ID = "Select * From SESchema Where Id = @Id";

        private const string SQL_SELECT_COUNT_BY_MODULE_USER =
            "Select Count(*) From SESchema Where ModuleId = @ModuleId And UserCode = @UserCode And SchemaName = @SchemaName";
        #endregion

        #region private method
        /// <summary>
        /// 获取查询引擎的数据类型的参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_UPDATE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar,20),
                                new OleDbParameter("@UserCode", OleDbType.VarChar,20),
                                new OleDbParameter("@SchemaName", OleDbType.VarChar,20), 
                                new OleDbParameter("@WhereClause", OleDbType.VarChar,2000),
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                                new OleDbParameter("@IsDefault",OleDbType.Boolean),
                                new OleDbParameter("@CreateTime", OleDbType.Date),
                                new OleDbParameter("@Id", OleDbType.Integer),
                                
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }

        private static OleDbParameter[] GetInsertParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar,20),
                                new OleDbParameter("@UserCode", OleDbType.VarChar,20),
                                new OleDbParameter("@SchemaName", OleDbType.VarChar,20), 
                                new OleDbParameter("@WhereClause", OleDbType.VarChar,2000),
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                                new OleDbParameter("@IsDefault",OleDbType.Boolean),
                                new OleDbParameter("@CreateTime", OleDbType.Date),
                                
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成SESchemaInfo.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>查询方案实体。</returns>
        private SESchemaInfo ConvertToSESchemaInfo(IDataRecord dr)
        {
            var obj = new SESchemaInfo
            {
                Id = dr.GetInt32(0),
                ModuleId = dr.GetString(1),
                UserCode = dr.GetString(2),
                SchemaName = dr.GetString(3),
                WhereClause = dr.GetString(4),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                IsDefault = dr.GetBoolean(6),
                CreateTime = dr.GetDateTime(7),
            };
            return obj;
        }
        #endregion

        #region ISESchema 成员

        public bool Insert(SESchemaInfo obj)
        {
            var parms = GetInsertParameters();
            parms[0].Value = obj.ModuleId;
            parms[1].Value = obj.UserCode;
            parms[2].Value = obj.SchemaName;
            parms[3].Value = obj.WhereClause;
            parms[4].Value = obj.Remark;
            parms[5].Value = obj.IsDefault;
            parms[6].Value = obj.CreateTime;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT, parms);
                obj.Id = GetMax();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        private short GetMax()
        {
            var oRet = AccessHelper.ExecuteScalar(ConnectionString.PubData, "Select max(Id) From [SeSchema] ");
            return short.Parse(oRet.ToString());
        }

        public bool Update(SESchemaInfo obj)
        {
            var parms = GetParameters();
           
            parms[0].Value = obj.ModuleId;
            parms[1].Value = obj.UserCode;
            parms[2].Value = obj.SchemaName;
            parms[3].Value = obj.WhereClause;
            parms[4].Value = obj.Remark;
            parms[5].Value = obj.IsDefault;
            parms[6].Value = obj.CreateTime;
            parms[7].Value = obj.Id;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(SESchemaInfo obj)
        {
            var parms = new[] {new OleDbParameter("@Id", OleDbType.Integer) {Value = obj.Id}};
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            var parms = new[] { new OleDbParameter("@Id", OleDbType.Integer) { Value = id } };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public IList<SESchemaInfo> GetByModuleAndUser(string moduleId, string userCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar, 20) {Value = moduleId},
                                new OleDbParameter("@UserCode", OleDbType.VarChar, 20) {Value = userCode}
                            };
            var objs = new ListBase<SESchemaInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_MODULE_USER,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSESchemaInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public SESchemaInfo GetDefaultByModuleAndUser(string moduleId, string userCode)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar, 20) {Value = moduleId},
                                new OleDbParameter("@UserCode", OleDbType.VarChar, 20) {Value = userCode}
                            };
            SESchemaInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_DEFAULT_BY_MODULE_USER,
                                             parms);
            while (dr.Read())
            {
                obj = ConvertToSESchemaInfo(dr);
            }
            dr.Close();
            return obj;
        }

        public SESchemaInfo GetById(int id)
        {
            var parms = new[] {new OleDbParameter("@Id", OleDbType.Integer) {Value = id}};
            SESchemaInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_ID, parms);
            while (dr.Read())
            {
                obj = ConvertToSESchemaInfo(dr);
            }
            dr.Close();
            return obj;
        }

        public bool IsExist(string moduleId, string userCode, string schemaName)
        {
            var parms = new[]
                            {
                                new OleDbParameter("@ModuleId", OleDbType.VarChar,20){Value = moduleId},
                                new OleDbParameter("@UserCode", OleDbType.VarChar, 20){Value = userCode},
                                new OleDbParameter("@SchemaName", OleDbType.VarChar,20){Value = schemaName},
                             };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,  
                                              SQL_SELECT_COUNT_BY_MODULE_USER, parms);
            return (int) obj == 0 ? false : true;
        }

        #endregion
    }
}
