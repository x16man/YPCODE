using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// SQLServer版本的模板对象的数据访问层。
    /// </summary>
    public class Template : IDAL.ITemplate
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169
        /// <summary>
        /// 获取所有模板记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_TEMPLATES = "Select * From mySystemTemplate";
        /// <summary>
        /// 根据产品编号获取模板记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_TEMPLATES_BY_PRODUCTCODE = "Select * From mySystemTemplate Where ProductCode = @ProductCode";
        /// <summary>
        /// 根据模板ID获取模板记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_TEMPLATE_BY_ID = "Select * From mySystemTemplate Where Id = @Id";
        /// <summary>
        /// 根据模板编号获取模板记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_TEMPLATE_BY_CODE = "Select * From mySystemTemplate Where Code = @Code";
        /// <summary>
        /// 添加模板记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_TEMPLATE = "Insert Into mySystemTemplate([ProductCode],[Code],[Name],[Content],[Remark]) Values (@ProductCode,@Code,@Name,@Content,@Remark) SET @Id = SCOPE_IDENTITY()";
        /// <summary>
        ///修改模板记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_TEMPLATE = "Update mySystemTemplate Set [ProductCode] = @ProductCode,[Code] = @Code, [Name] = @Name, [Content] = @Content, [Remark] = @Remark Where Id = @Id";
        /// <summary>
        /// 删除模板记录。
        /// </summary>
        private const string SQL_DELETE_TEMPLATE = "Delete From mySystemTemplate Where [Id] = @Id";

        private const string PARM_ID = "@Id";
        private const string PARM_PRODUCTCODE = "@ProductCode";
        private const string PARM_CODE = "@Code";
        private const string PARM_NAME = "@name";
        private const string PARM_CONTENT = "@Content";
        private const string PARM_REMARK = "@Remark";
        #endregion

        #region ITemplate 成员
        /// <summary>
        /// 添加模板记录。
        /// </summary>
        /// <param name="templateInfo">模板记录实体。</param>
        /// <returns>bool</returns>
        public bool Insert(TemplateInfo templateInfo)
        {
            var parms = GetTemplateParameters();
            parms[0].Value = 0;
            parms[1].Value = templateInfo.ProductCode;
            parms[2].Value = templateInfo.Code;
            parms[3].Value = templateInfo.Name;
            parms[4].Value = templateInfo.Content;
            parms[5].Value = templateInfo.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_TEMPLATE, parms);
                templateInfo.ID = (int)parms[0].Value;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 修改模板记录实体。
        /// </summary>
        /// <param name="templateInfo">模板记录实体。</param>
        /// <returns>bool</returns>
        public bool Update(TemplateInfo templateInfo)
        {
            var parms = GetTemplateParameters();
            parms[0].Value = templateInfo.ID;
            parms[1].Value = templateInfo.ProductCode;
            parms[2].Value = templateInfo.Code;
            parms[3].Value = templateInfo.Name;
            parms[4].Value = templateInfo.Content;
            parms[5].Value = templateInfo.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_TEMPLATE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 删除模板记录。
        /// </summary>
        /// <param name="templateInfo">模板记录实体。</param>
        /// <returns>bool</returns>
        public bool Delete(TemplateInfo templateInfo)
        {
            var parms = GetTemplateParameters();
            parms[0].Value = templateInfo.ID;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_TEMPLATE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据模板ID删除模板记录。
        /// </summary>
        /// <param name="id">模板id。</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var parms = GetTemplateParameters();
            parms[0].Value = id;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_TEMPLATE, parms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取所有的模板记录。
        /// </summary>
        /// <returns>模板记录集合。</returns>
        public IList<TemplateInfo> GetAll()
        {
            IList<TemplateInfo> objs = new ListBase<TemplateInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TEMPLATES);
            while (dr.Read())
            {
                var obj = ConvertToTemplateInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号获取模板记录集合。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>模板记录集合。</returns>
        public IList<TemplateInfo> GetByProductCode(short productCode)
        {
            IList<TemplateInfo> objs = new ListBase<TemplateInfo>();
            var parms = GetTemplateParameters();
            parms[1].Value = productCode;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TEMPLATES_BY_PRODUCTCODE, parms);
            while (dr.Read())
            {
                var obj = ConvertToTemplateInfo(dr);
                objs.Add(obj);
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据模板ID获取模板记录实体。
        /// </summary>
        /// <param name="id">模板ID。</param>
        /// <returns>模板记录实体。</returns>
        public TemplateInfo GetById(int id)
        {
            TemplateInfo obj = null;
            var parms = GetTemplateParameters();
            parms[0].Value = id;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TEMPLATE_BY_ID, parms);
            while (dr.Read())
            {
                obj = ConvertToTemplateInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        /// <summary>
        /// 根据模板编号获取模板记录实体。
        /// </summary>
        /// <param name="code">模板编号。</param>
        /// <returns>模板记录实体。</returns>
        public TemplateInfo GetByCode(string code)
        {
            TemplateInfo obj = null;
            var parms = GetTemplateParameters();
            parms[2].Value = code;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_TEMPLATE_BY_CODE, parms);
            while (dr.Read())
            {
                obj = ConvertToTemplateInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        /// <summary>
        /// 是否已经存在模板编号。
        /// </summary>
        /// <param name="code">模板编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(string code)
        {
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, string.Format("Select Count(*) From mySystemTemplate Where Code='{0}'", code));
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 获取Insert和Update命令的参数数组。
        /// </summary>
        /// <returns>Sql参数数组。</returns>
        private static SqlParameter[] GetTemplateParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_TEMPLATE);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter(PARM_ID, SqlDbType.Int){Direction = ParameterDirection.InputOutput},
                                new SqlParameter(PARM_PRODUCTCODE, SqlDbType.SmallInt), 
                                new SqlParameter(PARM_CODE, SqlDbType.NVarChar,10), 
                                new SqlParameter(PARM_NAME, SqlDbType.NVarChar, 20),
                                new SqlParameter(PARM_CONTENT, SqlDbType.Text),
                                new SqlParameter(PARM_REMARK,SqlDbType.NVarChar, 255), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_TEMPLATE, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将SqlDataReader转换为TemplateInfo实体。
        /// </summary>
        /// <param name="dr">DataReader</param>
        /// <returns>模板实体。</returns>
        private TemplateInfo ConvertToTemplateInfo(IDataRecord dr)
        {
            var obj = new TemplateInfo(dr.GetInt32(0), dr.GetInt16(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString());
            return obj;
        }

        #endregion
    }
}
