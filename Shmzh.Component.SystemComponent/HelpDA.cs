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
    /// HelpDA 的摘要说明。
    /// </summary>
    public class HelpDA : Messages
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public HelpDA()
        {
        }
        /// <summary>
        /// 增加帮助信息.
        /// </summary>
        /// <param name="helpInfo">帮助信息实体.</param>
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
                this.Message = "添加帮助信息失败！";
                ret = false;
            }
            return ret;
        }	

        /// <summary>
        /// 修改帮助信息.
        /// </summary>
        /// <param name="helpInfo">帮助信息实体.</param>
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
                this.Message = "更新帮助信息失败！";
                ret = false;
            }
            return ret;
        }	

        /// <summary>
        /// 根据编号获取帮助信息.
        /// </summary>
        /// <param name="code">帮助编号</param>
        /// <returns>DataSet</returns>
        public DataSet GetHelpInfoByCode(string code)
        {
            code = code.Replace("'","\"");
            var strSQL = "Select * from mySystemHelp where Code='" + code + "' order by Serial";
            return SqlHelper.ExecuteDataset( ConnectionString.PubData ,CommandType.Text,strSQL);
        }
        /// <summary>
        /// 根据父编号获取所有子节点帮助.
        /// </summary>
        /// <param name="parentCode">父编号</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllHelpsByParentCode(string parentCode)
        {
            parentCode = parentCode.Replace("'","\"");
            var strSQL = "Select * from mySystemHelp where ParentCode='" + parentCode + "'  order by Serial";
            return SqlHelper.ExecuteDataset(ConnectionString.PubData,CommandType.Text,strSQL);
        }
        /// <summary>
        /// 根据帮助编号删除帮助信息
        /// </summary>
        /// <param name="code">帮助编号</param>
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
