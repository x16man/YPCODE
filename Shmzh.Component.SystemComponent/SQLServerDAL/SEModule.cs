using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    class SEModule :IDAL.ISEModule
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_INSERT = @"Insert Into SEModule ([ID],[ProductCode],[Name],[SQL],[Where],[Remark]) Values (@Id,@ProductCode,@Name,@Sql,@Where,@Remark)";
        private const string SQL_UPDATE = @"Update SEModule Set [ID]=@Id,[ProductCode]=@ProductCode,[Name] = @Name,[SQL] = @Sql,[Where]=@Where,[Remark] = @Remark Where [ID]=@OldId";
        private const string SQL_DELETE = @"Delete From SEModule Where ID = @Id";
        private const string SQL_SELECT_ALL = @"Select * From SEModule";
        private const string SQL_SELECT_BY_PRODUCT = @"Select * From SEModule Where ProductCode = @ProductCode";
        private const string SQL_SELECT_BY_ID = @"Select * From SEModule Where ID = @Id";
        private const string SQL_SELECT_COUNT_BY_ID = @"Select Count(*) From SEModule Where Id = @Id";
        #endregion

        #region private method
        /// <summary>
        /// 获取查询模块参数。
        /// </summary>
        /// <returns>查询模块参数。</returns>
        private static SqlParameter[] GetSEModuleParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Id", SqlDbType.NVarChar,10),
                                new SqlParameter("@ProductCode",SqlDbType.SmallInt), 
                                new SqlParameter("@Name", SqlDbType.NVarChar,20), 
                                new SqlParameter("@Sql", SqlDbType.NVarChar,3700),
                                new SqlParameter("@Where", SqlDbType.NVarChar,20),
                                new SqlParameter("@Remark", SqlDbType.NVarChar,255), 
                                new SqlParameter("@OldId",SqlDbType.NVarChar,10), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成SEModuleInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>查询模块实体。</returns>
        private SEModuleInfo ConvertToSEModuleInfo(IDataRecord dr)
        {
            var obj = new SEModuleInfo
            {
                Id = dr.GetString(0),
                ProductCode = dr.GetInt16(1),
                Name = dr.GetString(2),
                SQL = dr.GetString(3),
                Where = dr.GetString(4),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
            };
            return obj;
        }
        #endregion

        #region ISEModule 成员

        public bool Insert(SEModuleInfo moduleInfo)
        {
            var parms = GetSEModuleParameters();
            parms[0].Value = moduleInfo.Id;
            parms[1].Value = moduleInfo.ProductCode;
            parms[2].Value = moduleInfo.Name;
            parms[3].Value = moduleInfo.SQL;
            parms[4].Value = moduleInfo.Where;
            parms[5].Value = string.IsNullOrEmpty(moduleInfo.Remark) ? (object)DBNull.Value : moduleInfo.Remark;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Update(SEModuleInfo moduleInfo)
        {
            var parms = GetSEModuleParameters();
            parms[0].Value = moduleInfo.Id;
            parms[1].Value = moduleInfo.ProductCode;
            parms[2].Value = moduleInfo.Name;
            parms[3].Value = moduleInfo.SQL;
            parms[4].Value = moduleInfo.Where;
            parms[5].Value = string.IsNullOrEmpty(moduleInfo.Remark) ? (object)DBNull.Value : moduleInfo.Remark;
            parms[6].Value = moduleInfo.OldId;
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

        public bool Delete(SEModuleInfo moduleInfo)
        {
            var parms = new[] {new SqlParameter("@Id", SqlDbType.NVarChar, 10) {Value = moduleInfo.Id}};
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

        public bool Delete(string id)
        {
            var parms = new[] { new SqlParameter("@Id", SqlDbType.NVarChar, 10) { Value = id } };
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

        public bool IsExist(string id)
        {
            var parms = new[] { new SqlParameter("@Id", SqlDbType.NVarChar, 10) { Value = id } };
            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        public IList<SEModuleInfo> GetAll()
        {
            var objs = new ListBase<SEModuleInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
            while (dr.Read())
            {
                objs.Add(ConvertToSEModuleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public IList<SEModuleInfo> GetByProduct(short productCode)
        {
            var objs = new ListBase<SEModuleInfo>();
            var parms = new[] {new SqlParameter("@ProductCode", SqlDbType.SmallInt) {Value = productCode}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_PRODUCT, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToSEModuleInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public SEModuleInfo GetById(string id)
        {
            SEModuleInfo obj = null;
            var parms = new[] { new SqlParameter("@Id", SqlDbType.NVarChar, 10) { Value = id } };
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_ID,parms);
            while (dr.Read())
            {
                obj = ConvertToSEModuleInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
