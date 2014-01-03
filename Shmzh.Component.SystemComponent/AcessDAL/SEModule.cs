using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Shmzh.Components.SystemComponent.AccessDAL
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
        private static OleDbParameter[] GetSEModuleParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.VarChar,10),
                                new OleDbParameter("@ProductCode",OleDbType.SmallInt), 
                                new OleDbParameter("@Name", OleDbType.VarChar,20), 
                                new OleDbParameter("@Sql", OleDbType.VarChar,3700),
                                new OleDbParameter("@Where", OleDbType.VarChar,20),
                                new OleDbParameter("@Remark", OleDbType.VarChar,255), 
                                new OleDbParameter("@OldId",OleDbType.VarChar,10), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT, parms);
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
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT, parms);
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
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE, parms);
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
            var parms = new[] {new OleDbParameter("@Id", OleDbType.VarChar, 10) {Value = moduleInfo.Id}};
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

        public bool Delete(string id)
        {
            var parms = new[] { new OleDbParameter("@Id", OleDbType.VarChar, 10) { Value = id } };
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

        public bool IsExist(string id)
        {
            var parms = new[] { new OleDbParameter("@Id", OleDbType.VarChar, 10) { Value = id } };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_COUNT_BY_ID, parms);
            return (int) obj == 0 ? false : true;
        }

        public IList<SEModuleInfo> GetAll()
        {
            var objs = new ListBase<SEModuleInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL);
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
            var parms = new[] {new OleDbParameter("@ProductCode", OleDbType.SmallInt) {Value = productCode}};
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_PRODUCT, parms);
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
            var parms = new[] { new OleDbParameter("@Id", OleDbType.VarChar, 10) { Value = id } };
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_ID,parms);
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
