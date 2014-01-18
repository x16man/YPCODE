using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Shmzh.MM.Common;
using Shmzh.Components.SystemComponent;

namespace Shmzh.MM.DataAccess.Common
{
    public class ESTUs
    {
        #region Property
        
        #endregion
        
        #region private method
        /// <summary>
        /// 将DataReader转换为状态实体。
        /// </summary>
        /// <param name="dr">DataReader对象。</param>
        /// <returns>状态实体。</returns>
        private ESTUInfo ConvertToESTUInfo(IDataRecord dr)
        {
            var obj = new ESTUInfo {Code = dr["Code"].ToString(), Description = dr["Description"].ToString(), Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString()};
            return obj;
        }
        /// <summary>
        /// 根据SQL来获取状态集合。
        /// </summary>
        /// <param name="sqlStatement">SQL语句。</param>
        /// <returns>状态集合。</returns>
        private List<ESTUInfo> GetBySQL(string sqlStatement)
        {
            var objs = new List<ESTUInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToESTUInfo(dr));
            }
            dr.Close();
            return objs;
        }
        #endregion

        #region Method
        public List<ESTUInfo> GetAll()
        {
            const string sqlStatement = "Select * From ESTU";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取采购申请单的状态集合。
        /// </summary>
        /// <returns>状态集合。</returns>
        public List<ESTUInfo> GetDistinctFromPros()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From PROS) Order By Code";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取月度计划需求单的状态集合。
        /// </summary>
        /// <returns>状态集合。</returns>
        public List<ESTUInfo> GetDistinctFromPmrp()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From PMRP)";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取采购计划的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromPpln()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From PPLN)";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取采购订单的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromPord()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From Pord) Order By Code";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取采购收料单的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromPbor()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From Pbor) Order By Code";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取采购退货单的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromPrtv()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From Prtv)";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取采购撤销单的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromPcor()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From Pcor)";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取领料单的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromWdrw()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From Wdrw)";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取委外加工申请单的的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromWtow()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From WTOW)";
            return this.GetBySQL(sqlStatement);
        }
        /// <summary>
        /// 获取委外加工收料单的状态集合。
        /// </summary>
        /// <returns>状态集合</returns>
        public List<ESTUInfo> GetDistinctFromWinw()
        {
            const string sqlStatement = "Select * From ESTU Where Code In (Select Distinct EntryState From WINW)";
            return this.GetBySQL(sqlStatement);
        }
        #endregion
    }
}
