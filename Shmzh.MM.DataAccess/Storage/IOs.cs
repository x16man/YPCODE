#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: IOs.cs
**		����: IOs
**		����: �շ���ϸ������ݷ��ʲ㡣
**
**              
**		����: �ź�
**		����: 2005-10-11
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ


namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;
    using System.Data.SqlClient;
    using System.Data.Common;
	/// <summary>
	/// IOs ��ժҪ˵����
	/// </summary>
	public class IOs
	{
		#region ��Ա����
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion

		#region ����
		//
		//TODO: �ڴ˴�������ԡ�
		//
		#endregion
		
		#region ˽�з���
		//
		//TODO: ����˴���˽�з�����
		//
		#endregion

		#region ��������
		/// <summary>
		/// ����ָ�����ϵ��շ���ϸ��¼��
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>IOData:	�շ���ϸ��ʵ�塣</returns>
		public IOData GetIOByItemCode(string ItemCode)
		{
			IOData oIOData = new IOData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			new SQLServer().ExecSPReturnDS("Sto_ItemIODetail",oHT,oIOData.Tables[IOData.IO_Table]);

			return oIOData;
		}
		public IOData GetIOByItemCodeAndDate(string ItemCode,DateTime StartDate, DateTime EndDate)
		{
			IOData   oIOData = new IOData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode",ItemCode);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			new SQLServer().ExecSPReturnDS("Sto_ItemIOGetDetailByDate",oHT,oIOData.Tables[IOData.IO_Table]);
			return oIOData;
		}
        public bool Insert(DbTransaction trans, int entryNo,short docCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo},
                                new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.StoredProcedure, "Sto_IOInsert", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
		#endregion

		#region ���캯��
		public IOs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
