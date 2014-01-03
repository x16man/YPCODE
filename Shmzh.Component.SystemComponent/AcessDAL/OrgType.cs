using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class OrgType : IOrgType
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 添加组织机构类型的SQL语句。
        /// </summary>
        private const string SQL_INSERT_ORGTYPE = "Insert Into mySystemOrgType ([Code],[Level],[CnName],[EnName],[IsValid]) Values (@Code,@Level,@CnName,@EnName,@IsValid)";
        /// <summary>
        /// 修改组织机构类型的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_ORGTYPE = "Update mySystemOrgType Set [Level] = @Level, [CnName] = @CnName, [EnName] = @EnName, [IsValid] = @IsValid Where [Code] = @Code";
        /// <summary>
        /// 删除组织机构类型的SQL语句。
        /// </summary>
        private const string SQL_DELETE_ORGTYPE = "Delete From mySystemOrgType Where [Code] = @Code";
        /// <summary>
        /// 获取所有组织机构类型。
        /// </summary>
        private const string SQL_SELECT_ALL = "Select * From mySystemOrgType";
        /// <summary>
        /// 获取所有有效的组织机构类型。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE = "Select * From mySystemOrgType Where [IsValid] = 'Y'";
        /// <summary>
        /// 通过对组织机构类型编号进行查询，判断编号有没有已经存在的SQL语句。
        /// </summary>
        private const string SQL_SELECTCOUNT_BY_CODE = "Select Count(*) From mySystemOrgType Where [Code] = @Code";
        /// <summary>
        /// 通过对组织机构类型名称进行查询，判断名称有没有已经存在的SQL语句。
        /// </summary>
        private const string SQL_SELECTCOUNT_BY_NAME = "Select Count(*) From mySystemOrgType Where [CnName] = @CnName";
        /// <summary>
        /// 根据组编号获取组织机构记录。
        /// </summary>
        private const string SQL_SELECT_BY_CODE = "Select * From mySystemOrgType Where [Code] = @Code";
        /// <summary>
        /// 判断组织机构类型有没有被使用的SQL语句。
        /// </summary>
        private const string SQL_SELECTORGCOUNT_BY_CODE = "Select Count(*) From mySystemDept Where [TypeId] = @Code";
        #endregion

        #region Private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetOrgTypeParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_ORGTYPE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@Code", OleDbType.VarChar, 20),
                                new OleDbParameter("@Level", OleDbType.Integer), 
                                new OleDbParameter("@CnName", OleDbType.VarChar, 50), 
                                new OleDbParameter("@EnName", OleDbType.VarChar, 50), 
                                new OleDbParameter("@IsValid", OleDbType.Char, 1), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_ORGTYPE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成OrgTypeInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组织机构类型实体。</returns>
        private OrgTypeInfo ConvertToOrgTypeInfo(IDataRecord dr)
        {
            var obj = new OrgTypeInfo
            {
                Code = dr.GetString(0),
                Level = dr.GetInt16(1),
                CnName = dr.GetString(2),
                EnName = dr["EnName"] == DBNull.Value ? string.Empty : dr["EnName"].ToString(),
                IsValid = dr.GetString(4),
            };
            return obj;
        }
        #endregion

        #region IOrgType 成员

        public bool Insert(OrgTypeInfo orgTypeInfo)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = orgTypeInfo.Code;
            parms[1].Value = orgTypeInfo.Level;
            parms[2].Value = orgTypeInfo.CnName;
            parms[3].Value = string.IsNullOrEmpty(orgTypeInfo.EnName)?(object)DBNull.Value:orgTypeInfo.EnName;
            parms[4].Value = orgTypeInfo.IsValid;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Update(OrgTypeInfo orgTypeInfo)
        {
            var parms = new[]
                            {
                               
                                new OleDbParameter("@Level", OleDbType.Integer), 
                                new OleDbParameter("@CnName", OleDbType.VarChar, 50), 
                                new OleDbParameter("@EnName", OleDbType.VarChar, 50), 
                                new OleDbParameter("@IsValid", OleDbType.Char, 1), 
                                new OleDbParameter("@Code", OleDbType.VarChar, 20),
                            };
          
            parms[0].Value = orgTypeInfo.Level;
            parms[1].Value = orgTypeInfo.CnName;
            parms[2].Value = string.IsNullOrEmpty(orgTypeInfo.EnName) ? (object)DBNull.Value : orgTypeInfo.EnName;
            parms[3].Value = orgTypeInfo.IsValid;
            parms[4].Value = orgTypeInfo.Code;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(OrgTypeInfo orgTypeInfo)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = orgTypeInfo.Code;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(string code)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = code;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool IsExistCode(string code)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = code;
            try
            {
                var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECTCOUNT_BY_CODE, parms);
                return (int) obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool IsExistName(string name)
        {
            var parms = GetOrgTypeParameters();
            parms[2].Value = name;
            try
            {
                var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECTCOUNT_BY_NAME, parms);
                return (int)obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool IsUsed(string code)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = code;
            try
            {
                var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECTORGCOUNT_BY_CODE, parms);
                return (int)obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public IList<OrgTypeInfo> GetAll()
        {
            IList<OrgTypeInfo> objs = new ListBase<OrgTypeInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL);
            while(dr.Read())
            {
                objs.Add(ConvertToOrgTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public IList<OrgTypeInfo> GetAllAvalible()
        {
            IList<OrgTypeInfo> objs = new ListBase<OrgTypeInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(ConvertToOrgTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public OrgTypeInfo GetByCode(string code)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = code;
            OrgTypeInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_CODE, parms);
            while(dr.Read())
            {
                obj = ConvertToOrgTypeInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        

        #endregion

        #region IOrgType 成员


        public bool Insert(OrgTypeInfo orgTypeInfo, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrgTypeInfo orgTypeInfo, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrgTypeInfo orgTypeInfo, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string code, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
