//-----------------------------------------------------------------------
// <copyright file="RightDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Security.Cryptography;
    using System.Web.Security;

	/// <summary>
	/// UserDA 的摘要说明。
	/// </summary>
	public class RightDA
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
		/// 构造函数
		/// </summary>
		public RightDA()
		{}
		/// <summary>
		/// 增加角色
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <param name="rightlist">权限编号串</param>
		/// <returns>bool</returns>
		public bool AddRoleRight(int roleCode,string rightlist)
		{
			SqlParameter[] arParms = new SqlParameter[2];
			
			// @ProductID Input Parameter 
			arParms[0] = new SqlParameter("@RoleCode",SqlDbType.SmallInt); 
			arParms[0].Value = roleCode;

			arParms[1] = new SqlParameter("@RightList", SqlDbType.NVarChar,4000 ); 
			arParms[1].Value = rightlist;
            
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_AddRoleRights", arParms);
        
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
			return false;
		}
		/// <summary>
		/// 根据产品编号获取所有的权限.
		/// </summary>
        /// <param name="productcode">产品编号</param>
		/// <returns>DataSet</returns>
        [Obsolete("此方法名不恰当已经作废",false)]
		public DataSet GetAllRights(int productcode)
		{
			string strSQL = "SELECT * FROM mySystemRights WHERE ProductCode=" + productcode;
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL);
		}
        /// <summary>
        /// 根据产品号获取所有权限项。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllByProductCode(int productCode)
        {
            string sqlStatement = string.Format("SELECT A.*,B.ProductName FROM mySystemRights A, mySystemProducts B where A.ProductCode = B.ProductCode And A.ProductCode={0}", productCode);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,sqlStatement);
        }
        /// <summary>
        /// 根据产品编号获取所有有效的权限项。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleByProductCode(int productCode)
        {
            string sqlStatement = string.Format("SELECT A.*,B.ProductName FROM mySystemRights A, mySystemProducts B where A.ProductCode = B.ProductCode And A.ProductCode={0} And A.IsValid='Y' ", productCode);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,sqlStatement);
        }
        /// <summary>
        /// 根据产品编号和权限分类获取所有的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="rightCat">权限分类。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllByRightCat(int productCode, string rightCat)
        {
            string sqlStatement = string.Format("Select A.*,B.ProductName From mySystemRights A,mySystemProducts B Where A.ProductCode = B.ProductCode And A.ProductCode = {0} And A.RightCatCode = '{1}'",productCode,rightCat);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据产品编号和权限分类获取所有有效的权限。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <param name="rightCat">权限分类。</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleByRightCat(int productCode, string rightCat)
        {
            string sqlStatement = string.Format("Select A.*,B.ProductName From mySystemRights A,mySystemProducts B Where A.ProductCode = B.ProductCode And A.ProductCode = {0} And A.RightCatCode = '{1}' And A.IsValid='Y'", productCode, rightCat);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// 根据产品编号获取所有的权限.
		/// </summary>
		/// <param name="productcode">产品编号</param>
		/// <param name="rightCatCode">权限分类编号。</param>
		/// <param name="bistrue">是否为除了权限分类以外的其他类型的,True是 false为否</param>
		/// <returns>DataSet</returns>
		[Obsolete("此方法名文不对题，已作废",false)]
        public DataSet GetCatRights(int productcode,string rightCatCode,bool bistrue)
		{
            string strSQL = string.Empty;

			if (!bistrue)
			{
				strSQL = string.Format("SELECT * FROM mySystemRights where ProductCode={0} AND RightCatCode ='{1}'",productcode,rightCatCode);
			}
			else
			{
				strSQL = "SELECT * FROM mySystemRights where ProductCode=" + productcode + " AND (RightcatCode is null or RightcatCode not in (SELECT Code FROM mySystemRightCat))";
			}
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL);
		}
		/// <summary>
		/// 根据角色编号获取权限.
		/// </summary>
		/// <param name="roleCode">角色编号</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllRightsByRole(int roleCode)
		{
			string strSQL = "SELECT * FROM mySystemRoleRights WHERE RoleCode=" + roleCode;
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL);
		}
	}
}
