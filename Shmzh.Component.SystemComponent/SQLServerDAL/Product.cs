using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Caching;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    ///<summary>
    /// 产品的SQL Server数据访问层。
    ///</summary>
    public class Product : IProduct
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        private const string SQL_INSERT_PRODUCT =
            "Insert Into mySystemProducts (ProductCode, ProductName, IsValid, Remark) Values (@ProductCode, @ProductName, @IsValid, @Remark)";

        private const string SQL_UPDATE_PRODUCT =
            "Update mySystemProducts Set ProductName = @ProductName,IsValid = @IsValid, Remark = @Remark Where ProductCode = @ProductCode";

        private const string SQL_DELETE_PRODUCT = "Delete From mySystemProducts Where ProductCode = @ProductCode";

        private const string SQL_SELECT_COUNT_BY_PRODUCTNAME =
            "Select Count(*) From mySystemProducts Where ProductName = @ProductName";

        private const string SQL_SELECT_COUNT_BY_PRODUCTCODE =
            "Select count(*) from mySystemProducts Where ProductCode = @ProductCode";

        private const string SQL_SELECT_ALL = "Select * From mySystemProducts";
        private const string SQL_SELECT_ALLAVALIBLE = "Select * from mySystemProducts Where IsValid = 'Y'";
        private const string SQL_SELECT_BY_CODE = "Select * from mySystemProducts Where ProductCode = @ProductCode";
        private const string SQL_REGISTER = "Update mySystemProducts Set License = @License Where ProductCode = @ProductCode";
        #endregion

        #region IProduct 成员

        /// <summary>
        /// 添加产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        public bool Insert(ProductInfo productInfo)
        {
            var parms = GetProductParameters();
            parms[0].Value = productInfo.ProductCode;
            parms[1].Value = productInfo.ProductName;
            parms[2].Value = productInfo.IsValid;
            parms[3].Value = string.IsNullOrEmpty(productInfo.Remark) ? (object) DBNull.Value : productInfo.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_INSERT_PRODUCT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        public bool Update(ProductInfo productInfo)
        {
            var parms = GetProductParameters();
            parms[0].Value = productInfo.ProductCode;
            parms[1].Value = productInfo.ProductName;
            parms[2].Value = productInfo.IsValid;
            parms[3].Value = string.IsNullOrEmpty(productInfo.Remark) ? (object)DBNull.Value : productInfo.Remark;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_UPDATE_PRODUCT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        public bool Delete(ProductInfo productInfo)
        {
            var parms = GetProductParameters();
            parms[0].Value = productInfo.ProductCode;
            
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_PRODUCT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除产品。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool Delete(short productCode)
        {
            var parms = GetProductParameters();
            parms[0].Value = productCode;

            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_DELETE_PRODUCT, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 注册产品。
        /// </summary>
        /// <param name="productInfo">产品实体。</param>
        /// <returns>bool</returns>
        public bool Register(ProductInfo productInfo)
        {
            var parms = new[]
                            {
                                new SqlParameter("@License", SqlDbType.NVarChar, 4000) {Value = productInfo.License},
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt) {Value = productInfo.ProductCode}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.Text, SQL_REGISTER, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 判断产品编号是否已经存在。
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public bool IsExist(short productCode)
        {
            var parms = GetProductParameters();
            parms[0].Value = productCode;

            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text,
                                              SQL_SELECT_COUNT_BY_PRODUCTCODE, parms);
            return (int) obj == 0 ? false : true;
        }

        /// <summary>
        /// 是否已经存在产品名称。
        /// </summary>
        /// <param name="productName">产品名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string productName)
        {
            var parms = GetProductParameters();
            parms[1].Value = productName;

            var obj = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text,
                                              SQL_SELECT_COUNT_BY_PRODUCTNAME, parms);
            return (int)obj == 0 ? false : true;
        }

        /// <summary>
        /// 获取所有产品。
        /// </summary>
        /// <returns>ArrayList。</returns>
        public IList<ProductInfo> GetAll()
        {
            //var objs = GetCachedProductList();
            //if(objs == null)
            //{
                var objs = new ListBase<ProductInfo>();
                var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALL);
                while(dr.Read())
                {
                    objs.Add(ConvertToProductInfo(dr));
                }
                dr.Close();
                //CacheProductsList(objs);
                
            //}
            return objs;
        }

        /// <summary>
        /// 获取所有有效的产品。
        /// </summary>
        /// <returns></returns>
        public IList<ProductInfo> GetAllAvalible()
        {

            var objs = new ListBase<ProductInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_ALLAVALIBLE);
            while (dr.Read())
            {
                objs.Add(ConvertToProductInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据产品编号获取产品。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>ArrayList</returns>
        public ProductInfo GetByCode(short productCode)
        {
            var parms = GetProductParameters();
            parms[0].Value = productCode;
            ProductInfo obj = null;
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, SQL_SELECT_BY_CODE, parms);
            while(dr.Read())
            {
                obj = ConvertToProductInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion

        #region private method
        /// <summary>
        /// 获取产品参数。
        /// </summary>
        /// <returns>产品参数数组。</returns>
        private static SqlParameter[] GetProductParameters()
        {
            var parms = SqlHelperParameterCache.GetCachedParameterSet(ConnectionString.PubData, SQL_INSERT_PRODUCT);
            if (parms == null)
            {
                parms = new[]
                            {
                                new SqlParameter("@ProductCode", SqlDbType.SmallInt),
                                new SqlParameter("@ProductName", SqlDbType.NVarChar,50), 
                                new SqlParameter("@IsValid", SqlDbType.NVarChar,1),
                                new SqlParameter("@Remark", SqlDbType.NVarChar,50), 
                                new SqlParameter("@License", SqlDbType.NVarChar,4000), 
                            };

                SqlHelperParameterCache.CacheParameterSet(ConnectionString.PubData, SQL_INSERT_PRODUCT, parms);
            }
            return parms;
        }
        /// <summary>
        /// 将DataRow转换成ProductInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>产品实体。</returns>
        private static ProductInfo ConvertToProductInfo(IDataRecord dr)
        {
            var obj = new ProductInfo()
            {
                ProductCode = dr.GetInt16(0),
                ProductName = dr.GetString(1),
                IsValid = dr.GetString(2),
                Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString(),
                License = dr["License"] == DBNull.Value?string.Empty:dr["License"].ToString(),
            };
            return obj;
        }
        //private static void CacheProductsList(List<ProductInfo> products)
        //{

        //    var sqlDependency = new SqlCacheDependency("PubData", "mySystemProducts");
            
        //    HttpContext.Current.Cache.Insert("ProductsList", products, sqlDependency, DateTime.Now.AddDays(1), Cache.NoSlidingExpiration);
        //}

        //private static List<ProductInfo> GetCachedProductList()
        //{
        //    return HttpContext.Current.Cache["ProductsList"] as List<ProductInfo>;
        //}
        #endregion

    }
}
