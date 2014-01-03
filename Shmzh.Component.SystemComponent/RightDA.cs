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
	/// UserDA ��ժҪ˵����
	/// </summary>
	public class RightDA
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
		/// ���캯��
		/// </summary>
		public RightDA()
		{}
		/// <summary>
		/// ���ӽ�ɫ
		/// </summary>
		/// <param name="roleCode">��ɫ���</param>
		/// <param name="rightlist">Ȩ�ޱ�Ŵ�</param>
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
		/// ���ݲ�Ʒ��Ż�ȡ���е�Ȩ��.
		/// </summary>
        /// <param name="productcode">��Ʒ���</param>
		/// <returns>DataSet</returns>
        [Obsolete("�˷�������ǡ���Ѿ�����",false)]
		public DataSet GetAllRights(int productcode)
		{
			string strSQL = "SELECT * FROM mySystemRights WHERE ProductCode=" + productcode;
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL);
		}
        /// <summary>
        /// ���ݲ�Ʒ�Ż�ȡ����Ȩ���
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllByProductCode(int productCode)
        {
            string sqlStatement = string.Format("SELECT A.*,B.ProductName FROM mySystemRights A, mySystemProducts B where A.ProductCode = B.ProductCode And A.ProductCode={0}", productCode);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,sqlStatement);
        }
        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ������Ч��Ȩ���
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleByProductCode(int productCode)
        {
            string sqlStatement = string.Format("SELECT A.*,B.ProductName FROM mySystemRights A, mySystemProducts B where A.ProductCode = B.ProductCode And A.ProductCode={0} And A.IsValid='Y' ", productCode);
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,sqlStatement);
        }
        /// <summary>
        /// ���ݲ�Ʒ��ź�Ȩ�޷����ȡ���е�Ȩ�ޡ�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="rightCat">Ȩ�޷��ࡣ</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllByRightCat(int productCode, string rightCat)
        {
            string sqlStatement = string.Format("Select A.*,B.ProductName From mySystemRights A,mySystemProducts B Where A.ProductCode = B.ProductCode And A.ProductCode = {0} And A.RightCatCode = '{1}'",productCode,rightCat);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
        /// <summary>
        /// ���ݲ�Ʒ��ź�Ȩ�޷����ȡ������Ч��Ȩ�ޡ�
        /// </summary>
        /// <param name="productCode">��Ʒ��š�</param>
        /// <param name="rightCat">Ȩ�޷��ࡣ</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllAvalibleByRightCat(int productCode, string rightCat)
        {
            string sqlStatement = string.Format("Select A.*,B.ProductName From mySystemRights A,mySystemProducts B Where A.ProductCode = B.ProductCode And A.ProductCode = {0} And A.RightCatCode = '{1}' And A.IsValid='Y'", productCode, rightCat);
            return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text, sqlStatement);
        }
		/// <summary>
		/// ���ݲ�Ʒ��Ż�ȡ���е�Ȩ��.
		/// </summary>
		/// <param name="productcode">��Ʒ���</param>
		/// <param name="rightCatCode">Ȩ�޷����š�</param>
		/// <param name="bistrue">�Ƿ�Ϊ����Ȩ�޷���������������͵�,True�� falseΪ��</param>
		/// <returns>DataSet</returns>
		[Obsolete("�˷������Ĳ����⣬������",false)]
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
		/// ���ݽ�ɫ��Ż�ȡȨ��.
		/// </summary>
		/// <param name="roleCode">��ɫ���</param>
		/// <returns>DataSet</returns>
		public DataSet GetAllRightsByRole(int roleCode)
		{
			string strSQL = "SELECT * FROM mySystemRoleRights WHERE RoleCode=" + roleCode;
			return SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.Text,strSQL);
		}
	}
}
