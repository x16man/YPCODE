using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class RightCat : IRightCat
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169
        /// <summary>
        /// 添加权限分组记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_RIGHTCAT = "Insert Into mySystemRightCat (Code, Name, [Desc], ProductCode, IsValid) Values (@Code, @Name, @Desc, @ProductCode, @IsValid)";
        /// <summary>
        /// 修改权限分组记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_RIGHTCAT = "Update mySystemRightCat Set [Name] = @Name, [Desc] = @Desc, [ProductCode] = @ProductCode, IsValid = @IsValid Where Code = @Code";
        /// <summary>
        /// 删除权限分组记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_RIGHTCAT = "Delete From mySystemRightCat Where Code = @Code";
        /// <summary>
        /// 根据产品编号获取所有权限分组记录。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_PRODUCTCODE = "Select * From mySystemRightCat Where ProductCode = @ProductCode";
        /// <summary>
        /// 根据产品编号获取所有有效的权限分组记录。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE = "Select * From mySystemRightCat Where ProductCode = @ProductCode And IsValid = 'Y'";
        /// <summary>
        /// 根据权限分组编号获取权限分组记录。
        /// </summary>
        private const string SQL_SELECT_BY_CODE = "Select * From mySystemRightCat Where Code = @Code";
        /// <summary>
        /// 判断权限编号是否已经存在的SQL语句。
        /// </summary>
        private const string SQL_SELECT_COUNT_BY_CODE = "Select Count(*) From mySystemRightCat Where Code = @Code";
        /// <summary>
        /// 判断在同一产品下是否存在相同的名称权限分组记录。
        /// </summary>
        private const string SQL_SELECT_COUNT_BY_PRODUCTCODE_NAME = "Select Count(*) From mySystemRightCat Where ProductCode = @ProductCode And [Name] = @Name";
        /// <summary>
        /// 判断权限分类是否被使用。
        /// </summary>
        private const string SQL_SELECT_CHILDCOUNT_BY_CODE = @"Select Count(*) From mySystemRights Where RightCatCode=@Code";
        #endregion

        #region Private method
        /// <summary>
        /// 获取权限分组参数。
        /// </summary>
        /// <returns></returns>
        private static OleDbParameter[] GetRightCatParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_RIGHTCAT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@Code", OleDbType.VarChar,10),
                                new OleDbParameter("@Name", OleDbType.VarChar,20), 
                                new OleDbParameter("@Desc", OleDbType.VarChar,50), 
                                new OleDbParameter("@ProductCode", OleDbType.SmallInt),
                                new OleDbParameter("@IsValid", OleDbType.Char, 1), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_RIGHTCAT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成GroupInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>组实体。</returns>
        private RightCatInfo ConvertToRightCatInfo(IDataRecord dr)
        {
            var obj = new RightCatInfo
            {
                Code = dr.GetString(0),
                Name = dr.GetString(1),
                Desc = dr["Desc"] == DBNull.Value ? string.Empty : dr["Desc"].ToString(),
                ProductCode = dr.GetInt16(3),
                IsValid = dr.GetString(4)
            };
            return obj;
        }
        #endregion

        #region IRightCat 成员
        /// <summary>
        /// 添加权限分组。
        /// </summary>
        /// <param name="rightCatInfo">权限分组实体。</param>
        /// <returns>bool</returns>
        public bool Insert(RightCatInfo rightCatInfo)
        {
            var parms = GetRightCatParameters();
            parms[0].Value = rightCatInfo.Code;
            parms[1].Value = rightCatInfo.Name;
            parms[2].Value = string.IsNullOrEmpty(rightCatInfo.Desc) ? (object) DBNull.Value : rightCatInfo.Desc;
            parms[3].Value = rightCatInfo.ProductCode;
            parms[4].Value = rightCatInfo.IsValid;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_RIGHTCAT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 修改权限分组。
        /// </summary>
        /// <param name="rightCatInfo">权限分组实体。</param>
        /// <returns>bool</returns>
        public bool Update(RightCatInfo rightCatInfo)
        {
            var parms = new[]
                            {
                              
                                new OleDbParameter("@Name", OleDbType.VarChar,20), 
                                new OleDbParameter("@Desc", OleDbType.VarChar,50), 
                                new OleDbParameter("@ProductCode", OleDbType.SmallInt),
                                new OleDbParameter("@IsValid", OleDbType.Char, 1), 
                                new OleDbParameter("@Code", OleDbType.VarChar,10),
                            };
           
            parms[0].Value = rightCatInfo.Name;
            parms[1].Value = string.IsNullOrEmpty(rightCatInfo.Desc) ? (object)DBNull.Value : rightCatInfo.Desc;
            parms[2].Value = rightCatInfo.ProductCode;
            parms[3].Value = rightCatInfo.IsValid;
            parms[4].Value = rightCatInfo.Code;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE_RIGHTCAT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除权限分组。
        /// </summary>
        /// <param name="rightCatInfo">权限分组实体。</param>
        /// <returns>bool</returns>
        public bool Delete(RightCatInfo rightCatInfo)
        {
            var parms = new[] { new OleDbParameter("@Code", OleDbType.VarChar, 10) { Value = rightCatInfo.Code }, };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_RIGHTCAT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除权限分组。
        /// </summary>
        /// <param name="code">权限分组编号。</param>
        /// <returns>bool</returns>
        public bool Delete(string code)
        {
            var parms = new[] { new OleDbParameter("@Code", OleDbType.VarChar, 10) { Value = code }, };
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_RIGHTCAT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 判断权限分组编号是否已经存在。
        /// </summary>
        /// <param name="code">权限编号编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(string code)
        {
            var parms = new[] { new OleDbParameter("@Code", OleDbType.VarChar, 10) { Value = code }, };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_COUNT_BY_CODE, parms);
            return (int) obj == 0 ? false : true;
        }
        /// <summary>
        /// 判断权限分组名称是否已经存在。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="name">权限分组名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(short productCode, string name)
        {
            var parms = new[] { 
                new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } ,
                new OleDbParameter("@Name",OleDbType.VarChar,20){Value = name}
            };
    
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_COUNT_BY_PRODUCTCODE_NAME, parms);
            return (int)obj == 0 ? false : true;
        }
        /// <summary>
        /// 根据产品编号获取所有的权限分组。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限分组集合。</returns>
        public IList<RightCatInfo> GetAllByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } };
            var objs = new ListBase<RightCatInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_BY_PRODUCTCODE,
                                             parms);
            while(dr.Read())
            {
                objs.Add(ConvertToRightCatInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号获取所有有效的权限分组。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限分组集合。</returns>
        public IList<RightCatInfo> GetAllAvalibleByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } };
            var objs = new ListBase<RightCatInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRightCatInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据编号获取权限分组。
        /// </summary>
        /// <param name="code">权限分组编号。</param>
        /// <returns>权限分组实体。</returns>
        public RightCatInfo GetByCode(string code)
        {
            var parms = new[] { new OleDbParameter("@Code", OleDbType.VarChar, 10) { Value = code }, };
           
            RightCatInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_CODE,
                                             parms);
            while (dr.Read())
            {
                obj = ConvertToRightCatInfo(dr);
            }
            dr.Close();
            return obj;
        }

        #endregion

        #region IRightCat 成员


        public bool HasChildren(string code)
        {
            var parms = new[] {new OleDbParameter("@Code", OleDbType.VarChar, 10) {Value = code},};
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_CHILDCOUNT_BY_CODE,
                                              parms);
            return (int) obj == 0 ? false : true;
        }

        #endregion
    }
}
