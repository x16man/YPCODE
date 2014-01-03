//-----------------------------------------------------------------------
// <copyright file="SystemDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

	/// <summary>
	/// ProductDA ��ժҪ˵����
	/// </summary>
	public class SystemDA
	{
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
		/// <summary>
		/// ���캯��
		/// </summary>
		public SystemDA(){}
		/// <summary>
		/// ��ȡϵͳ��Ϣ.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetSystemInfo()
		{
			DataSet ds = null;
			try
			{
				ds = SqlHelper.ExecuteDataset(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_GetProductInfo");
			}
			catch (Exception ex)
			{
                Logger.Error(ex.Message);
            }
			return ds;
		}
	}
}
