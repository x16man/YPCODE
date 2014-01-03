// <copyright file="GrantDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Shmzh.Components.SystemComponent
{
    using System.Data;
    using System.Data.SqlClient;

	/// <summary>
	/// GroupDA ��ժҪ˵����
	/// </summary>
	public class GrantDA
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// ���캯��
		/// </summary>
		public GrantDA()
		{
		}

		/// <summary>
		/// ���ݽ����˻�ȡ��Ȩʵ��.
		/// </summary>
		/// <param name="embracer">������</param>
		/// <returns>DataSet</returns>
		public DataSet GetGrantsByEmbracer(string embracer)
		{
			DataSet ds = null;
			try
			{
                var arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@Embracer", SqlDbType.NVarChar,20) {Value = embracer};
			    ds = SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetGrantor",arParms);
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
			}
			return ds;
		}
		
		/// <summary>
		/// ������Ȩ�˻�ȡ��Ȩ��Ϣʵ��.
		/// </summary>
		/// <param name="grantor">��Ȩ��</param>
		/// <returns>DataSet</returns>
        public DataSet GetGrantsByGrantor(string grantor)
        {
            DataSet ds = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@Grantor", SqlDbType.NVarChar,20); 
                arParms[0].Value = grantor;
                ds = SqlHelper.ExecuteDataset(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetEmbracers",arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return ds;
        }
		
		/// <summary>
		/// ����PKID��ȡGrant����.
		/// </summary>
		/// <param name="pkid">pkid</param>
		/// <returns>DataSet</returns>
        public DataSet GetGrantsByPKID(long pkid)
        {
            DataSet ds = null;

            try
            {
                var arParms = new SqlParameter[1];
			
                arParms[0] = new SqlParameter("@PKID", SqlDbType.BigInt) {Value = pkid};
                ds = SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.StoredProcedure,"mysys_GetGrantByPKID",arParms);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
		
            return ds;
        }
		/// <summary>
		/// ������Ȩ.
		/// </summary>
		/// <param name="grant">Grant����</param>
		/// <returns>bool</returns>
        public bool SaveGrants(Grant grant)
        {
            bool ret = true;

            try
            {
                SqlParameter[] arParms = new SqlParameter[9];
			
                arParms[0] = new SqlParameter("@PKID", SqlDbType.BigInt); 
                arParms[0].Value = grant.PKID;

                arParms[1] = new SqlParameter("@Grantor", SqlDbType.NVarChar,20); 
                arParms[1].Value = grant.Grantor;
                arParms[2] = new SqlParameter("@GrantorName", SqlDbType.NVarChar,20); 
                arParms[2].Value = grant.GrantorName;
                arParms[3] = new SqlParameter("@GrantorDept", SqlDbType.NVarChar,20); 
                arParms[3].Value = grant.GrantorDept;
                arParms[4] = new SqlParameter("@Embracer", SqlDbType.NVarChar,20); 
                arParms[4].Value = grant.Embracer;
                arParms[5] = new SqlParameter("@IsValid", SqlDbType.Bit); 
                arParms[5].Value = grant.IsValid;
                arParms[6] = new SqlParameter("@EffectTime", SqlDbType.SmallDateTime); 
                arParms[6].Value = grant.EffectTime;
                arParms[7] = new SqlParameter("@LoginIsValid", SqlDbType.Bit); 
                arParms[7].Value = grant.LoginIsValid;
                arParms[8] = new SqlParameter("@Reason", SqlDbType.NVarChar,255); 
                arParms[8].Value = grant.Reason;

                SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.StoredProcedure,"mysys_SaveGrant",arParms);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
		/// <summary>
		/// �趨��Ȩ�Ƿ���Ч
		/// </summary>
		/// <param name="pkid">pkid</param>
		/// <param name="isvalid">�Ƿ���Ч</param>
		/// <returns>bool</returns>
        public bool SetIsValid(long pkid,bool isvalid)
        {
            bool ret = true;

            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@PKID", SqlDbType.BigInt); 
                arParms[0].Value = pkid;
                arParms[1] = new SqlParameter("@IsValid", SqlDbType.Bit); 
                arParms[1].Value = isvalid;
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.StoredProcedure,"mysys_SetEffective",arParms);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
	}
}
