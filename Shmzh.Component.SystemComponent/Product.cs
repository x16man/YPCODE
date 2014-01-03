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
	/// ϵͳ��Ʒ��Ϣ�����ݷ�����.
	/// </summary>
	[Serializable]
	public class Product
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region ���캯��
        /// <summary>
		/// ���캯��
		/// </summary>
		public Product()
		{
		}
		#endregion

		#region ����
        /// <summary>
        /// ��ȡ���е�ϵͳ��Ʒ���󼯺ϡ�
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
		/// ��ȡ������Ч��ϵͳ��Ʒ���󼯺�.
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
		/// ���ݲ�Ʒ��ŷ��ز�Ʒʵ��.
		/// </summary>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>ProductInfo</returns>
		/// <remarks>���û�ж�Ӧ��Ʒ�򷵻�null.</remarks>
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
        /// �жϲ�Ʒ����Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <returns>bool</returns>
        public bool IsExist(int productCode)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemProducts Where ProductCode={0}", productCode);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        /// <summary>
        /// �жϲ�Ʒ�����Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="productName">��Ʒ���ơ�</param>
        /// <returns>bool</returns>
        public bool IsExist(string productName)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemProducts Where ProductName='{0}'",productName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
        /// <summary>
        /// �жϲ�Ʒ�����Ƿ��Ѿ����ڡ�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="productName">��Ʒ���ơ�</param>
        /// <returns>bool</returns>
        public bool IsExist(int productCode, string productName)
        {
            var sqlStatement = string.Format("Select Count(*) From mySystemProducts Where ProductName='{1}' And ProductCode<>{0}", productCode,productName);
            var oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
        }
		/// <summary>
		/// ����һ��Ʒ
		/// </summary>
		/// <param name="thisProductInfo">��Ʒ��Ϣʵ��.</param>
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
		/// ���Ĳ�Ʒ��Ϣ.
		/// </summary>
		/// <param name="thisProductInfo">��Ʒ��Ϣʵ��.</param>
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
		/// ɾ����Ʒ��Ϣʵ��.
		/// </summary>
		/// <param name="thisProductInfo">��Ʒ��Ϣʵ��.</param>
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
		/// ɾ����Ʒ��Ϣʵ��.
		/// </summary>
		/// <param name="productCode">��Ʒ���</param>
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
