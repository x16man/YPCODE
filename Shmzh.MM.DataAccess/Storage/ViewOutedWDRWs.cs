using System;
using System.Text;
using System.Collections;
using System.Data;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess.Storage
{
    /// <summary>
    /// ViewOutedWDRWs 的摘要说明。
    /// </summary>
    public class ViewOutedWDRWs
    {
        public ViewOutedWDRWs()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 根据Sql获取数据集.
        /// </summary>
        /// <param name="Sql_Statement">SQL语句.</param>
        /// <returns>ViewOutedWDRWData</returns>
        public ViewOutedWDRWData GetEntryBySQL(string Sql_Statement)
        {
            ViewOutedWDRWData oViewOutedWDRWData = new ViewOutedWDRWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@Sql_Statement", Sql_Statement);
            oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oViewOutedWDRWData.Tables[ViewOutedWDRWData.ViewOutedWDRW_Table]);
            return oViewOutedWDRWData;
        }
        /// <summary>
        /// 更新WDOD的科目信息.
        /// </summary>
        /// <param name="obj">ViewOutedWDRWData</param>
        /// <returns>bool</returns>
        public bool UpdateWDODKM(ViewOutedWDRWData obj)
        {
            bool ret = true;
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", obj.Tables[0].Rows[0]["EntryNo"]);
            oHT.Add("@SerialNo", obj.Tables[0].Rows[0]["SerialNo"]);
            oHT.Add("@KM1", obj.Tables[0].Rows[0]["KM1"]);
            oHT.Add("@KM2", obj.Tables[0].Rows[0]["KM2"]);
            oHT.Add("@KM3", obj.Tables[0].Rows[0]["KM3"]);
            oHT.Add("@KM4", obj.Tables[0].Rows[0]["KM4"]);

            ret = oSQLServer.ExecSP("Sto_WDOD_UpdateKM", oHT);

            return ret;
        }
    }
}
