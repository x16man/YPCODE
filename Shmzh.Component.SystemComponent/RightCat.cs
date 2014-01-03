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
	/// RightCat ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class RightCat
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
		/// ���캯����
		/// </summary>
		public RightCat()
		{
		}
		/// <summary>
		/// ����ָ���Ĳ�Ʒ��ŷ���Ȩ�޷�����Ϣ
		/// </summary>
		/// <param name="productCode">��Ʒ���</param>
		/// <returns>DataSet</returns>
		/// <remarks>���ָ���Ĳ�Ʒ���Ϊ0���ʾ����������Ч��Ȩ����Ϣ.</remarks>
		[Obsolete("�˷������Ĳ����⣬������",true)]
        public DataSet GetRightByCode(int productCode)
		{
			string sqlStatement;
			if (productCode == 0)//��������ϵͳ��Ʒ
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
        /// ���ݲ�Ʒ��Ż�ȡ���е�Ȩ�޷��ࡣ
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <returns>DataSet��[Code,Name,Desc,ProductCode,IsValid,ProductName]</returns>
        public DataSet GetAllByProductCode(int productCode)
        {
            string sqlStatement = string.Format(@"  Select  a.[Code], a.[Name], a.[Desc], a.[ProductCode], a.[IsValid],b.[ProductName]  
                                                    From    mySystemRightCat as a,mySystemProducts as b 
                                                    Where   a.ProductCode=b.ProductCode AND  
                                                            a.ProductCode ={0}", productCode);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ������Ч��Ȩ�޷��ࡣ
        /// </summary>
        /// <param name="productCode">��Ʒ���</param>
        /// <returns>DataSet��[Code,Name,Desc,ProductCode,IsValid,ProductName]</returns>
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
		/// ����ָ���Ĳ�Ʒ��ŷ���Ȩ�޷�����Ϣ
		/// </summary>
		/// <param name="productCode">��Ʒ���</param>
		/// <param name="bisall">�Ƿ�ȫ����</param>
		/// <returns>DataSet</returns>
		/// <remarks>���ָ���Ĳ�Ʒ���Ϊ0���ʾ����������Ч��Ȩ����Ϣ.</remarks>
        [Obsolete("�˷������Ĳ����⣬������", true)]
        public DataSet GetRightByCode(int productCode,bool bisall)
		{
			string sqlStatement;
			if (productCode == 0)//��������ϵͳ��Ʒ
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
		/// ���ݱ�Ż�ȡȨ�޷��ࡣ
		/// </summary>
        /// <param name="code">Ȩ�޷����š�</param>
		/// <returns>DataSet</returns>
        public DataSet GetByCode(string code)
		{
			string sqlStatement = string.Format("SELECT * FROM mySystemRightCat where Code='{0}'", code);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
		}
		/// <summary>
		/// ���Ȩ�޷��ࡣ
		/// </summary>
		/// <param name="code">��š�</param>
		/// <param name="name">���ơ�</param>
		/// <param name="desc">������</param>
		/// <param name="productCode">��Ʒ��š�</param>
		/// <param name="isValid">�Ƿ���Ч��[Y:N]</param>
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
		/// ����Ȩ�޷��ࡣ
		/// </summary>
		/// <param name="code">��š�</param>
		/// <param name="name">���ơ�</param>
		/// <param name="desc">������</param>
		/// <param name="productCode">��Ʒ��š�</param>
		/// <param name="isValid">�Ƿ���Ч��</param>
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
		/// �ж�Ȩ�޷������Ƿ���Ȩ���
		/// </summary>
        /// <param name="code">Ȩ�޷����š�</param>
		/// <returns>bool</returns>
		public bool HasChildren(string code)
		{
			string sqlStatement = string.Format("SELECT Count(*) From mySystemRights Where RightCatCode='{0}'",code);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// �ж�Ȩ�޷�����Ƿ��Ѿ����ڡ�
		/// </summary>
        /// <param name="code">��š�</param>
		/// <returns>bool</returns>
		public bool IsExistCode(string code)
		{
			string sqlStatement = string.Format("SELECT Count(*) FROM  mySystemRightCat WHERE Code='{0}'",code);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// �ж�Ȩ�޷��������Ƿ��Ѿ����ڡ�
		/// </summary>
        /// <param name="name">���ơ�</param>
        /// <param name="productCode">��Ʒ���ơ�</param>
		/// <returns>bool</returns>
        /// <remarks>���ʱ��ʹ�á�</remarks>
		public bool IsExistName(string name,string productCode)
		{
			string sqlStatement = string.Format("SELECT Count(*) FROM  mySystemRightCat WHERE Name='{0}' AND Productcode={1}",name,productCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// �ж�Ȩ�޷��������Ƿ��Ѿ����ڡ�
		/// </summary>
		/// <param name="code">��š�</param>
		/// <param name="name">���ơ�</param>
		/// <param name="productCode">��Ʒ��š�</param>
		/// <returns>bool</returns>
        /// <remarks>����ʱ��ʹ�á�</remarks>
		public bool IsExistName(string code, string name, string productCode)
		{
			string sqlStatement = string.Format("SELECT Count(*�� From  mySystemRightCat Where Name='{1}' AND Productcode={2} AND Code <>'{0}'",code, name, productCode);
            object oRet = SqlHelper.ExecuteScalar(ConnectionString.PubData, CommandType.Text, sqlStatement);
            return int.Parse(oRet.ToString()) == 0 ? false : true;
		}
		/// <summary>
		/// ɾ��Ȩ�޷��ࡣ
		/// </summary>
        /// <param name="code">��š�</param>
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
