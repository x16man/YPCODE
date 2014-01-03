using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class SESchema :IDAL.ISESchema
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = @"
Insert Into SESchema ([ModuleId],[UserCode],[SchemaName],[WhereClause],[Remark],[IsDefault],[CreateTime] )
Values (@ModuleId,@UserCode,@SchemaName,@WhereClause,@Remark,@IsDefault,@CreateTime)
SET @Id = SCOPE_IDENTITY()";
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
        private static SqlParameter[] GetParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter("@ModuleId", SqlDbType.NVarChar,20),
                                new SqlParameter("@UserCode", SqlDbType.NVarChar,20),
                                new SqlParameter("@SchemaName", SqlDbType.NVarChar,20), 
                                new SqlParameter("@WhereClause", SqlDbType.NVarChar,2000),
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255), 
                                new SqlParameter("@IsDefault",SqlDbType.Bit),
                                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
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
            var parms = GetParameters();
            parms[0].Value = 0;
            parms[1].Value = obj.ModuleId;
            parms[2].Value = obj.UserCode;
            parms[3].Value = obj.SchemaName;
            parms[4].Value = obj.WhereClause;
            parms[5].Value = obj.Remark;
            parms[6].Value = obj.IsDefault;
            parms[7].Value = obj.CreateTime;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                obj.Id = (int)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Update(SESchemaInfo obj)
        {
            var parms = GetParameters();
            parms[0].Value = obj.Id;
            parms[1].Value = obj.ModuleId;
            parms[2].Value = obj.UserCode;
            parms[3].Value = obj.SchemaName;
            parms[4].Value = obj.WhereClause;
            parms[5].Value = obj.Remark;
            parms[6].Value = obj.IsDefault;
            parms[7].Value = obj.CreateTime;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE, parms);
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
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = obj.Id}};
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
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
            var parms = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = id } };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE, parms);
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
                                new SqlParameter("@ModuleId", SqlDbType.NVarChar, 20) {Value = moduleId},
                                new SqlParameter("@UserCode", SqlDbType.NVarChar, 20) {Value = userCode}
                            };
            var objs = new ListBase<SESchemaInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_MODULE_USER,
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
                                new SqlParameter("@ModuleId", SqlDbType.NVarChar, 20) {Value = moduleId},
                                new SqlParameter("@UserCode", SqlDbType.NVarChar, 20) {Value = userCode}
                            };
            SESchemaInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_DEFAULT_BY_MODULE_USER,
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
            var parms = new[] {new SqlParameter("@Id", SqlDbType.Int) {Value = id}};
            SESchemaInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID, parms);
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
                                new SqlParameter("@ModuleId", SqlDbType.NVarChar,20){Value = moduleId},
                                new SqlParameter("@UserCode", SqlDbType.NVarChar, 20){Value = userCode},
                                new SqlParameter("@SchemaName", SqlDbType.NVarChar,20){Value = schemaName},
                             };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text,
                                              SQL_SELECT_COUNT_BY_MODULE_USER, parms);
            return (int) obj == 0 ? false : true;
        }

        #endregion
    }
}
