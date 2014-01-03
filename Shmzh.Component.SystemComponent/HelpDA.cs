// <copyright file="HelpDA.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    /// <summary>
    /// HelpDA ��ժҪ˵����
    /// </summary>
    public class HelpDA : Messages
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
        /// ���캯��
        /// </summary>
        public HelpDA()
        {
        }
        /// <summary>
        /// ���Ӱ�����Ϣ.
        /// </summary>
        /// <param name="helpInfo">������Ϣʵ��.</param>
        /// <returns>bool</returns>
        public bool AddHelpInfo(HelpInfo helpInfo)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@Code", SqlDbType.NVarChar,20 ) {Value = helpInfo.Code};
                arParms[1] = new SqlParameter("@Title", SqlDbType.NVarChar,50 ) {Value = helpInfo.Title};
                arParms[2] = new SqlParameter("@Content", SqlDbType.Text ) {Value = helpInfo.Content};
                arParms[3] = new SqlParameter("@ParentCode", SqlDbType.NVarChar,20 ) {Value = helpInfo.ParentCode};
                arParms[4] = new SqlParameter("@Serial", SqlDbType.SmallInt) {Value = helpInfo.Serial};
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_AddHelpInfo",arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                this.Message = "��Ӱ�����Ϣʧ�ܣ�";
                ret = false;
            }
            return ret;
        }	

        /// <summary>
        /// �޸İ�����Ϣ.
        /// </summary>
        /// <param name="helpInfo">������Ϣʵ��.</param>
        /// <returns>bool</returns>
        public bool UpdateHelpInfo(HelpInfo helpInfo)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[5];
                arParms[0] = new SqlParameter("@Code", SqlDbType.NVarChar,20 ) {Value = helpInfo.Code};
                arParms[1] = new SqlParameter("@Title", SqlDbType.NVarChar,50 ) {Value = helpInfo.Title};
                arParms[2] = new SqlParameter("@Content", SqlDbType.Text ) {Value = helpInfo.Content};
                arParms[3] = new SqlParameter("@ParentCode", SqlDbType.NVarChar,20 ) {Value = helpInfo.ParentCode};
                arParms[4] = new SqlParameter("@Serial", SqlDbType.SmallInt) {Value = helpInfo.Serial};
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_UpdateHelpInfo",arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                this.Message = "���°�����Ϣʧ�ܣ�";
                ret = false;
            }
            return ret;
        }	

        /// <summary>
        /// ���ݱ�Ż�ȡ������Ϣ.
        /// </summary>
        /// <param name="code">�������</param>
        /// <returns>DataSet</returns>
        public DataSet GetHelpInfoByCode(string code)
        {
            code = code.Replace("'","\"");
            var strSQL = "Select * from mySystemHelp where Code='" + code + "' order by Serial";
            return SqlHelper.ExecuteDataset( ConnectionString.PubData ,CommandType.Text,strSQL);
        }
        /// <summary>
        /// ���ݸ���Ż�ȡ�����ӽڵ����.
        /// </summary>
        /// <param name="parentCode">�����</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllHelpsByParentCode(string parentCode)
        {
            parentCode = parentCode.Replace("'","\"");
            var strSQL = "Select * from mySystemHelp where ParentCode='" + parentCode + "'  order by Serial";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,strSQL);
        }
        /// <summary>
        /// ���ݰ������ɾ��������Ϣ
        /// </summary>
        /// <param name="code">�������</param>
        /// <returns>bool</returns>
        public bool DeleteHelpInfo(string code)
        {
            var ret = true;
            try
            {
                code = code.Replace("'","\"");
                var strSQL = "Delete from mySystemHelp where Code='" + code + "'";
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData,CommandType.Text,strSQL);
            }
            catch (Exception ex)
            {
                ret = false;
                this.Message = ex.Message;
            }

            return ret;
        }
    }
}
