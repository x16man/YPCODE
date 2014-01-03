//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Collections;
    using System.Data;

	/// <summary>
	/// 系统产品信息的数据访问类.
	/// </summary>
	[Serializable]
	public class Product
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region 构造函数
        /// <summary>
		/// 构造函数
		/// </summary>
		public Product()
		{
		}
		#endregion

		#region 方法
        /// <summary>
        /// 获取所有的系统产品对象集合。
        /// </summary>
        /// <returns>ArrayList</returns>
        public ArrayList GetAll()
        {
            var productinfoList = new ArrayList();
            var sqlStatement = "Select ProductCode,ProductName,IsValid,Remark From mySystemProducts";
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                productinfoList.Add(new ProductInfo(dr.GetInt16(0), dr.GetString(1),dr.GetString(2),dr["Remark"].ToString()));
            }
            dr.Close();
            return productinfoList;
        }
		/// <summary>
		/// 获取所有有效的系统产品对象集合.
		/// </summary>
		/// <returns>ArrayList</returns>
		public ArrayList GetAllValid()
		{
			var productinfoList = new ArrayList();
            var sqlStatement = "Select ProductCode,ProductName,IsValid,Remark From mySystemProducts Where IsValid = 'Y'";
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                productinfoList.Add(new ProductInfo(dr.GetInt16(0), dr.GetString(1), dr.GetString(2), dr["Remark"].ToString()));
            }
            dr.Close();
			return productinfoList;
		}
		/// <summary>
		/// 根据产品编号返回产品实体.
		/// </summary>
		/// <param name="productCode">产品编号</param>
		/// <returns>ProductInfo</returns>
		/// <remarks>如果没有对应产品则返回null.</remarks>
		public ProductInfo GetByCode(int productCode)
		{
			ProductInfo obj = null;
			var sqlStatement = string.Format("Select ProductCode,ProductName,IsValid,Remark From mySystemProducts Where ProductCode = {0}",productCode);
			var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text ,sqlStatement);
			if (dr.Read())
			{
                obj = new ProductInfo(dr.GetInt16(0), dr.GetString(1), dr.GetString(2), dr["Remark"].ToString());
			}
			dr.Close();
			return obj;
		}
        /// <summary>
        /// 判断产品编号是否已经存在。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>bool</returns>
        public bool IsExist(int productCode)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemProducts Where ProductCode={0}", productCode);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        /// <summary>
        /// 判断产品名称是否已经存在。
        /// </summary>
        /// <param name="productName">产品名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(string productName)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemProducts Where ProductName='{0}'",productName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        /// <summary>
        /// 判断产品名称是否已经存在。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="productName">产品名称。</param>
        /// <returns>bool</returns>
        public bool IsExist(int productCode, string productName)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemProducts Where ProductName='{1}' And ProductCode<>{0}", productCode,productName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
		/// <summary>
		/// 增加一产品
		/// </summary>
		/// <param name="thisProductInfo">产品信息实体.</param>
		/// <returns>bool</returns>
		public bool Add(ProductInfo thisProductInfo)
		{
			var retValue = true;
			var sqlStatement = string.Format("Insert Into mySystemProducts Values ({0},'{1}','{2}','{3}')",
											thisProductInfo.ProductCode,
											thisProductInfo.ProductName,
											thisProductInfo.IsValid,
											thisProductInfo.Remark);
			try
			{
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text, sqlStatement);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 更改产品信息.
		/// </summary>
		/// <param name="thisProductInfo">产品信息实体.</param>
		/// <returns>bool</returns>
		public bool Update(ProductInfo thisProductInfo)
		{
			var retValue = true;
			var sqlStatement = string.Format("Update mySystemProducts Set ProductName='{1}',IsValid='{2}',Remark='{3}' Where ProductCode={0}",
										thisProductInfo.ProductCode,
										thisProductInfo.ProductName,
										thisProductInfo.IsValid,
										thisProductInfo.Remark);
			try
			{
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text, sqlStatement);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 删除产品信息实体.
		/// </summary>
		/// <param name="thisProductInfo">产品信息实体.</param>
		/// <returns>bool</returns>
		public bool Delete(ProductInfo thisProductInfo)
		{
			var retValue = true;
			var sqlStatement = string.Format("Delete From  mySystemProducts Where ProductCode={0}",thisProductInfo.ProductCode);
			try
			{
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text, sqlStatement);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 删除产品信息实体.
		/// </summary>
		/// <param name="productCode">产品编号</param>
		/// <returns>bool</returns>
		public bool Delete(int productCode)
		{
			var retValue = true;
			var sqlStatement = string.Format("Delete From  mySystemProducts Where ProductCode={0}",productCode);
				
			try
			{
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text, sqlStatement);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
				retValue = false;
			}
			return retValue;
		}
		#endregion
	}
}
