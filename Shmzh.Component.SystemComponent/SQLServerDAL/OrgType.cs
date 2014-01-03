using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
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
        private const string SQL_INSERT_ORGTYPE = "Insert Into mySystemOrgType (Code,Level,CnName,EnName,IsValid) Values (@Code,@Level,@CnName,@EnName,@IsValid)";
        /// <summary>
        /// 修改组织机构类型的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_ORGTYPE = "Update mySystemOrgType Set Level = @Level, CnName = @CnName, EnName = @EnName, IsValid = @IsValid Where Code = @Code";
        /// <summary>
        /// 删除组织机构类型的SQL语句。
        /// </summary>
        private const string SQL_DELETE_ORGTYPE = "Delete From mySystemOrgType Where Code = @Code";
        /// <summary>
        /// 获取所有组织机构类型。
        /// </summary>
        private const string SQL_SELECT_ALL = "Select * From mySystemOrgType";
        /// <summary>
        /// 获取所有有效的组织机构类型。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE = "Select * From mySystemOrgType Where IsValid = 'Y'";
        /// <summary>
        /// 通过对组织机构类型编号进行查询，判断编号有没有已经存在的SQL语句。
        /// </summary>
        private const string SQL_SELECTCOUNT_BY_CODE = "Select Count(*) From mySystemOrgType Where Code = @Code";
        /// <summary>
        /// 通过对组织机构类型名称进行查询，判断名称有没有已经存在的SQL语句。
        /// </summary>
        private const string SQL_SELECTCOUNT_BY_NAME = "Select Count(*) From mySystemOrgType Where CnName = @CnName";
        /// <summary>
        /// 根据组编号获取组织机构记录。
        /// </summary>
        private const string SQL_SELECT_BY_CODE = "Select * From mySystemOrgType Where Code = @Code";
        /// <summary>
        /// 判断组织机构类型有没有被使用的SQL语句。
        /// </summary>
        private const string SQL_SELECTORGCOUNT_BY_CODE = "Select Count(*) From mySystemDept Where TypeId = @Code";
        #endregion

        #region Private method
        /// <summary>
        /// 获取组参数。
        /// </summary>
        /// <returns></returns>
        private static SqlParameter[] GetOrgTypeParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_ORGTYPE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@Code", SqlDbType.NVarChar, 20),
                                new SqlParameter("@Level", SqlDbType.SmallInt), 
                                new SqlParameter("@CnName", SqlDbType.NVarChar, 50), 
                                new SqlParameter("@EnName", SqlDbType.NVarChar, 50), 
                                new SqlParameter("@IsValid", SqlDbType.NChar, 1), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_ORGTYPE, parms);
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
            return Insert(orgTypeInfo, null);
        }

        public bool Update(OrgTypeInfo orgTypeInfo)
        {
            return Update(orgTypeInfo, null);    
        }

        public bool Delete(OrgTypeInfo orgTypeInfo)
        {
            return Delete(orgTypeInfo.Code);
        }

        public bool Delete(string code)
        {
            return Delete(code, null);
        }

        public bool IsExistCode(string code)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = code;
            try
            {
                var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECTCOUNT_BY_CODE, parms);
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
                var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECTCOUNT_BY_NAME, parms);
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
                var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, SQL_SELECTORGCOUNT_BY_CODE, parms);
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
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
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
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE);
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
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_CODE, parms);
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
        public bool Insert(OrgTypeInfo orgTypeInfo, DbTransaction trans)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = orgTypeInfo.Code;
            parms[1].Value = orgTypeInfo.Level;
            parms[2].Value = orgTypeInfo.CnName;
            parms[3].Value = string.IsNullOrEmpty(orgTypeInfo.EnName) ? (object)DBNull.Value : orgTypeInfo.EnName;
            parms[4].Value = orgTypeInfo.IsValid;
            try
            {
                if (trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_ORGTYPE, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_INSERT_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Update(OrgTypeInfo orgTypeInfo, DbTransaction trans)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = orgTypeInfo.Code;
            parms[1].Value = orgTypeInfo.Level;
            parms[2].Value = orgTypeInfo.CnName;
            parms[3].Value = string.IsNullOrEmpty(orgTypeInfo.EnName) ? (object)DBNull.Value : orgTypeInfo.EnName;
            parms[4].Value = orgTypeInfo.IsValid;
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_ORGTYPE, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_UPDATE_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(OrgTypeInfo orgTypeInfo, DbTransaction trans)
        {
            return Delete(orgTypeInfo.Code, trans);
        }

        public bool Delete(string code, DbTransaction trans)
        {
            var parms = GetOrgTypeParameters();
            parms[0].Value = code;
            try
            {
                if(trans == null)
                    SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_ORGTYPE, parms);
                else
                    SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_DELETE_ORGTYPE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
