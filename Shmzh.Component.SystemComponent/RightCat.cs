//-----------------------------------------------------------------------
// <copyright file="RightCat.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

	/// <summary>
	/// RightCat 的摘要说明。
	/// </summary>
	[Serializable]
	public class RightCat
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
		/// 构造函数。
		/// </summary>
		public RightCat()
		{
		}
		/// <summary>
		/// 根据指定的产品编号返回权限分类信息
		/// </summary>
		/// <param name="productCode">产品编号</param>
		/// <returns>DataSet</returns>
		/// <remarks>如果指定的产品编号为0则表示返回所有有效的权限信息.</remarks>
		[Obsolete("此方法名文不对题，已作废",true)]
        public DataSet GetRightByCode(int productCode)
		{
			string sqlStatement;
			if (productCode == 0)//返回所有系统产品
			{
				sqlStatement = "Select a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName] From mySystemRightCat as a,mySystemProducts as b Where  a.ProductCode<>1 and a.ProductCode=b.ProductCode";
			}
			else
			{
				sqlStatement = string.Format(" Select a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName]  From mySystemRightCat as a,mySystemProducts as b Where  a.ProductCode<>1 and a.ProductCode=b.ProductCode and  a.ProductCode ={0}",productCode);
			}
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,sqlStatement);
		}
        /// <summary>
        /// 根据产品编号获取所有的权限分类。
        /// </summary>
        /// <param name="productCode">产品编号。</param>
        /// <returns>DataSet：[Code,Name,Desc,ProductCode,IsValid,ProductName]</returns>
        public DataSet GetAllByProductCode(int productCode)
        {
            string sqlStatement = string.Format(@"  Select  a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName]  
                                                    From    mySystemRightCat as a,mySystemProducts as b 
                                                    Where   a.ProductCode=b.ProductCode AND  
                                                            a.ProductCode ={0}", productCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// 根据产品编号获取所有有效的权限分类。
        /// </summary>
        /// <param name="productCode">产品编号</param>
        /// <returns>DataSet：[Code,Name,Desc,ProductCode,IsValid,ProductName]</returns>
        public DataSet GetAllAvalibleByProductCode(int productCode)
        {
            string sqlStatement = string.Format(@"  Select  a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName]  
                                                    From    mySystemRightCat as a,mySystemProducts as b 
                                                    Where   a.ProductCode=b.ProductCode AND  
                                                            a.ProductCode ={0} AND
                                                            a.[IsValid]='Y'", productCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// 根据指定的产品编号返回权限分类信息
		/// </summary>
		/// <param name="productCode">产品编号</param>
		/// <param name="bisall">是否全部。</param>
		/// <returns>DataSet</returns>
		/// <remarks>如果指定的产品编号为0则表示返回所有有效的权限信息.</remarks>
        [Obsolete("此方法名文不对题，已作废", true)]
        public DataSet GetRightByCode(int productCode,bool bisall)
		{
			string sqlStatement;
			if (productCode == 0)//返回所有系统产品
			{
				sqlStatement = string.Format(@" Select  a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName] 
                                                From    mySystemRightCat as a,mySystemProducts as b 
                                                Where  a.ProductCode=b.ProductCode");
			}
			else
			{
				sqlStatement = string.Format(@" Select  a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName]  
                                                From    mySystemRightCat as a,mySystemProducts as b 
                                                Where   a.ProductCode = b.ProductCode and  
                                                        a.ProductCode = {0}",productCode);
			}

			if (!bisall)
			{
				sqlStatement += " AND a.isValid='Y'";
			}
			return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,sqlStatement);
		}
		/// <summary>
		/// 根据编号获取权限分类。
		/// </summary>
        /// <param name="code">权限分类编号。</param>
		/// <returns>DataSet</returns>
        public DataSet GetByCode(string code)
		{
			string sqlStatement = string.Format("SELECT * FROM mySystemRightCat where Code='{0}'", code);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
		/// <summary>
		/// 添加权限分类。
		/// </summary>
		/// <param name="code">编号。</param>
		/// <param name="name">名称。</param>
		/// <param name="desc">描述。</param>
		/// <param name="productCode">产品编号。</param>
		/// <param name="isValid">是否有效。[Y:N]</param>
		/// <returns>bool</returns>
		public bool Add(string code,string name,string desc,int productCode,string isValid)
		{
			SqlParameter[] arParms = new SqlParameter[5];
			arParms[0] = new SqlParameter("@CatCode",SqlDbType.NVarChar,10); 
			arParms[0].Value = code;
			arParms[1] = new SqlParameter("@CatName", SqlDbType.NVarChar,20 ); 
			arParms[1].Value = name;
			arParms[2] = new SqlParameter("@CatDesc", SqlDbType.NVarChar,50 ); 
			arParms[2].Value = desc;
			arParms[3] = new SqlParameter("@ProductCode", SqlDbType.Int ); 
			arParms[3].Value = productCode;
			arParms[4] = new SqlParameter("@IsValid", SqlDbType.VarChar,1 ); 
			arParms[4].Value = isValid;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_AddRightCat", arParms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
		}
		/// <summary>
		/// 更新权限分类。
		/// </summary>
		/// <param name="code">编号。</param>
		/// <param name="name">名称。</param>
		/// <param name="desc">描述。</param>
		/// <param name="productCode">产品编号。</param>
		/// <param name="isValid">是否有效。</param>
		/// <returns>bool</returns>
		public bool Update(string code,string name,string desc,int productCode,string isValid)
		{
			SqlParameter[] arParms = new SqlParameter[5];
			arParms[0] = new SqlParameter("@CatCode",SqlDbType.NVarChar,10); 
			arParms[0].Value = code;
			arParms[1] = new SqlParameter("@CatName", SqlDbType.NVarChar,20 ); 
			arParms[1].Value = name;
			arParms[2] = new SqlParameter("@CatDesc", SqlDbType.NVarChar,50 ); 
			arParms[2].Value = desc;
			arParms[3] = new SqlParameter("@ProductCode", SqlDbType.Int ); 
			arParms[3].Value = productCode;
			arParms[4] = new SqlParameter("@IsValid", SqlDbType.VarChar,1 ); 
			arParms[4].Value = isValid;
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_UpdateRightCat", arParms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
		}
		/// <summary>
		/// 判断权限分类下是否有权限项。
		/// </summary>
        /// <param name="code">权限分类编号。</param>
		/// <returns>bool</returns>
		public bool HasChildren(string code)
		{
			string sqlStatement = string.Format("SELECT Count(*) From mySystemRights Where RightCatCode='{0}'",code);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 判断权限分类号是否已经存在。
		/// </summary>
        /// <param name="code">编号。</param>
		/// <returns>bool</returns>
		public bool IsExistCode(string code)
		{
			string sqlStatement = string.Format("SELECT Count(*) FROM  mySystemRightCat WHERE Code='{0}'",code);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 判断权限分类名称是否已经存在。
		/// </summary>
        /// <param name="name">名称。</param>
        /// <param name="productCode">产品名称。</param>
		/// <returns>bool</returns>
        /// <remarks>添加时候使用。</remarks>
		public bool IsExistName(string name,string productCode)
		{
			string sqlStatement = string.Format("SELECT Count(*) FROM  mySystemRightCat WHERE Name='{0}' AND Productcode={1}",name,productCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 判断权限分类名称是否已经存在。
		/// </summary>
		/// <param name="code">编号。</param>
		/// <param name="name">名称。</param>
		/// <param name="productCode">产品编号。</param>
		/// <returns>bool</returns>
        /// <remarks>更新时候使用。</remarks>
		public bool IsExistName(string code, string name, string productCode)
		{
			string sqlStatement = string.Format("SELECT Count(*） From  mySystemRightCat Where Name='{1}' AND Productcode={2} AND Code <>'{0}'",code, name, productCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// 删除权限分类。
		/// </summary>
        /// <param name="code">编号。</param>
		/// <returns>bool</returns>
		public bool Delete(string code)
		{
			string sqlStatement = string.Format("Delete From  mySystemRightCat Where [Code]='{0}'",code);
			try
			{
				SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text, sqlStatement);
                return true;
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
                return false;
			}
		}
	}
}
