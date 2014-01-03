using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Shmzh.Components.SystemComponent.SQLServerDAL
{
    /// <summary>
    /// 工作流中组织机构与人员的关系的SQL Serveer的数据访问对象。
    /// </summary>
    public class TB_SYN :IDAL.ITB_SYN
    {
        #region Field

        private const string FloDBName = "FloDBName";
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string SQL_UPDATE = string.Format("Update {0}.[dbo].[TB_SYN] Set TBSYN_Value=getDate() Where TBSYN_CD = @CD",ConfigurationManager.AppSettings[FloDBName]);
        #endregion

        #region Implementation of ITB_SYN
        /// <summary>
        /// 修改东兰工作流部门信息。
        /// </summary>
        /// <param name="obj">配置信息实体。</param>
        /// <param name="trans">事务对象。</param>
        public bool Update(string CD, DbTransaction trans)
        {
            var parms = new[]
                            {
                                new SqlParameter("@CD", SqlDbType.Char,2){Value = CD},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery((SqlTransaction)trans, CommandType.Text, SQL_UPDATE, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        #endregion
    }
}
