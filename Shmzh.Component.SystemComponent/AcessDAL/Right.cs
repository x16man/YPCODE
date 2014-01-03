using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.AccessDAL
{
    class Right : IRight
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169
        /// <summary>
        /// 添加权限记录的SQL语句。
        /// </summary>
        private const string SQL_INSERT_RIGHT = @"Insert Into mySystemRights (RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode) Values (@RightCode, @RightName, @IsValid, @Remark, @ProductCode,@RightCatCode)";
        /// <summary>
        /// 修改权限记录的SQL语句。
        /// </summary>
        private const string SQL_UPDATE_RIGHT = @"
Update  mySystemRights
Set     RightCode = @RightCode
,       RightName = @RightName
,       IsValid = @IsValid
,       Remark = @Remark
,       ProductCode = @ProductCode
,       RightCatCode = @RightCatCode 
Where   RightCode = @OldRightCode";
        /// <summary>
        /// 删除权限记录的SQL语句。
        /// </summary>
        private const string SQL_DELETE_RIGHTS = @"Delete From mySystemRoleRights Where RightCode = @RightCode";
        private const string SQL_DELETE_RIGHT = @"Delete From mySystemRights Where RightCode = @RightCode";

        /// <summary>
        /// 根据产品编号获取所有权限记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_PRODUCTCODE = @"
Select  RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode 
From    mySystemRights 
Where   ProductCode = @ProductCode";
        /// <summary>
        /// 根据产品编号获取所有有效的权限记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE = @"
Select  RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode 
From    mySystemRights 
Where   ProductCode = @ProductCode And 
        IsValid = 'Y'";
        /// <summary>
        /// 根据权限分类编号获取所有的权限记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_ALL_BY_RIGHTCATCODE = @"
Select  RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode 
From    mySystemRights 
Where   RightCatCode = @RightCatCode ";
        /// <summary>
        /// 根据权限分类编号获取所有有效的权限记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_ALLAVALIBLE_BY_RIGHTCATCODE = @"
Select  RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode 
From    mySystemRights 
Where   RightCatCode = @RightCatCode And 
        IsValid = 'Y'";

        private const string SQL_SELECT_ALL_OTHER_BY_PRODUCTCODE =@"
Select  RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode 
From    mySystemRights 
Where   ProductCode = @ProductCode And 
        (RightCatCode Is Null OR RightCatCode = '')";
        private const string SQL_SELECT_ALLAVALIBLE_OTHER_BY_PRODUCTCODE = @"
Select  RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode 
From    mySystemRights 
Where   ProductCode = @ProductCode And 
        IsValid = 'Y' And
        (RightCatCode Is Null OR RightCatCode = '')";
        /// <summary>
        /// 根据权限编号获取权限记录的SQL语句。
        /// </summary>
        private const string SQL_SELECT_BY_RIGHTCODE = "Select RightCode, RightName, IsValid, Remark, ProductCode, RightCatCode From mySystemRights Where RightCode = @RightCode";
        /// <summary>
        /// 判断权限编号是否已经存在的SQL语句。
        /// </summary>
        private const string SQL_SELECT_COUNT_BY_CODE = "Select Count(*) From mySystemRights Where RightCode = @RightCode";

        private const string SQL_ISUSING_BY_CODE = @"
Select sum(aa) From (Select Count(*) as aa From mySystemMenu Where fRightCode = @RightCode
Union
Select Count(*) as aa From mySystemRoleRights Where RightCode = @RightCode1) as a"; 
        #endregion

        #region Private method
        /// <summary>
        /// 获取权限参数。
        /// </summary>
        /// <returns>权限参数。</returns>
        private static OleDbParameter[] GetRightParameters()
        {
            var parms = AccessHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_RIGHT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new OleDbParameter("@RightCode", OleDbType.SmallInt),
                                new OleDbParameter("@RightName", OleDbType.VarChar,50), 
                                new OleDbParameter("@IsValid", OleDbType.VarChar,1), 
                                new OleDbParameter("@Remark", OleDbType.VarChar,50), 
                                new OleDbParameter("@ProductCode", OleDbType.SmallInt),
                                new OleDbParameter("@RightCatCode", OleDbType.VarChar, 10), 
                                new OleDbParameter("@OldRightCode", OleDbType.SmallInt), 
                            };

                AccessHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_RIGHT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成RightInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>权限实体。</returns>
        private RightInfo ConvertToRightInfo(IDataRecord dr)
        {
            var obj = new RightInfo
                          {
                              RightCode = dr.GetInt16(0),
                              RightName = dr.GetString(1),
                              IsValid = dr.GetString(2),
                              Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                              ProductCode = dr.GetInt16(4),
                              RightCatCode = dr["RightCatCode"] == DBNull.Value ? string.Empty : dr["RightCatCode"].ToString(),
            };
            return obj;
        }
        #endregion

        #region IRight 成员
        /// <summary>
        /// 添加权限。
        /// </summary>
        /// <param name="rightInfo">权限实体。</param>
        /// <returns>bool</returns>
        public bool Insert(RightInfo rightInfo)
        {
            var parms = GetRightParameters();
            parms[0].Value = rightInfo.RightCode;
            parms[1].Value = rightInfo.RightName;
            parms[2].Value = rightInfo.IsValid;
            parms[3].Value = string.IsNullOrEmpty(rightInfo.Remark) ? (object) DBNull.Value : rightInfo.Remark;
            parms[4].Value = rightInfo.ProductCode;
            parms[5].Value = string.IsNullOrEmpty(rightInfo.RightCatCode) ?(object)DBNull.Value : rightInfo.RightCatCode;

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_INSERT_RIGHT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 修改权限。
        /// </summary>
        /// <param name="rightInfo">权限实体。</param>
        /// <returns>bool</returns>
        public bool Update(RightInfo rightInfo)
        {
            var parms = GetRightParameters();
            parms[0].Value = rightInfo.RightCode;
            parms[1].Value = rightInfo.RightName;
            parms[2].Value = rightInfo.IsValid;
            parms[3].Value = string.IsNullOrEmpty(rightInfo.Remark) ? (object)DBNull.Value : rightInfo.Remark;
            parms[4].Value = rightInfo.ProductCode;
            parms[5].Value = string.IsNullOrEmpty(rightInfo.RightCatCode) ? (object)DBNull.Value : rightInfo.RightCatCode;
            parms[6].Value = rightInfo.OldRightCode;
            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_UPDATE_RIGHT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除权限。
        /// </summary>
        /// <param name="rightInfo">权限实体。</param>
        /// <returns>bool</returns>
        public bool Delete(RightInfo rightInfo)
        {
            var parms = new[] { new OleDbParameter("@RightCode", OleDbType.VarChar, 10) { Value = rightInfo.RightCode }, };
           

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData,   SQL_DELETE_RIGHT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short rightCode)
        {
            var parms = new[] { new OleDbParameter("@RightCode", OleDbType.SmallInt) { Value = rightCode }, };
           

            try
            {
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_RIGHTS, parms);
                AccessHelper.ExecuteNonQuery(ConnectionString.PubData, SQL_DELETE_RIGHT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 判断权限编号是否存在。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(short rightCode)
        {
            var parms = new[] { new OleDbParameter("@RightCode", OleDbType.VarChar, 10) { Value = rightCode }, };
           

            try
            {
                var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_SELECT_COUNT_BY_CODE, parms);
                return (int) obj == 0 ? false : true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 根据产品编号获取所有权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        public IList<RightInfo> GetAllByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } };
            //var objs = new List<RightInfo>();
            var objs = new ListBase<RightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_BY_PRODUCTCODE,
                                             parms);
            while(dr.Read())
            {
                objs.Add(ConvertToRightInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号获取所有有效的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        public IList<RightInfo> GetAllAvalibleByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } };
            //var objs = new List<RightInfo>();
            var objs = new ListBase<RightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE_BY_PRODUCTCODE,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRightInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据权限分类获取权限。
        /// </summary>
        /// <param name="rightCatCode">权限分类编号。</param>
        /// <returns>权限集合。</returns>
        public IList<RightInfo> GetAllByRightCatCode(string rightCatCode)
        {
            var parms = new[] { new OleDbParameter("@RightCatCode", OleDbType.VarChar, 10) { Value = rightCatCode } };
            var objs = new ListBase<RightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_BY_RIGHTCATCODE,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRightInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据权限分类获取所有有效的权限集合。
        /// </summary>
        /// <param name="rightCatCode">权限分类编号。</param>
        /// <returns>权限集合。</returns>
        public IList<RightInfo> GetAllAvalibleByRightCatCode(string rightCatCode)
        {
            var parms = new[] { new OleDbParameter("@RightCatCode", OleDbType.VarChar, 10) { Value = rightCatCode } };
            var objs = new ListBase<RightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE_BY_RIGHTCATCODE,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRightInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据产品编号获取所有没有设置权限分类的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        public IList<RightInfo> GetAllOtherByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } };
            var objs = new ListBase<RightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALL_OTHER_BY_PRODUCTCODE,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRightInfo(dr));
            }
            dr.Close();
            return objs;
        }      
        /// <summary>
        /// 根据产品编号获取所有有效的没有设置权限分类的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>权限集合。</returns>
        public IList<RightInfo> GetAllAvalibleOtherByProductCode(short productCode)
        {
            var parms = new[] { new OleDbParameter("@ProductCode", OleDbType.SmallInt) { Value = productCode } };
            var objs = new ListBase<RightInfo>();
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_ALLAVALIBLE_OTHER_BY_PRODUCTCODE,
                                             parms);
            while (dr.Read())
            {
                objs.Add(ConvertToRightInfo(dr));
            }
            dr.Close();
            return objs;
        }
        /// <summary>
        /// 根据权限编号获取权限。
        /// </summary>
        /// <param name="rightCode">权限编号。</param>
        /// <returns>权限实体。</returns>
        public RightInfo GetByCode(short rightCode)
        {
            var parms = new[] { new OleDbParameter("@RightCode", OleDbType.SmallInt) { Value = rightCode } };
            
            RightInfo obj = null;
            var dr = AccessHelper.ExecuteReader(ConnectionString.PubData,   SQL_SELECT_BY_RIGHTCODE,
                                             parms);
            while (dr.Read())
            {
                obj = ConvertToRightInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

        #region IRight 成员


        public bool IsUsing(short rightCode)
        {
            var parms = new[] { 
                new OleDbParameter("@RightCode", OleDbType.SmallInt) { Value = rightCode } ,
                new OleDbParameter("@RightCode1", OleDbType.SmallInt) { Value = rightCode } 
            
            };
            var obj = AccessHelper.ExecuteScalar(ConnectionString.PubData,   SQL_ISUSING_BY_CODE, parms);
            
            return int.Parse(obj.ToString()) == 0 ? false : true;
        }

        #endregion
    }
}
