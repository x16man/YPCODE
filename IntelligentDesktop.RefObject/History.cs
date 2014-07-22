using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    [Serializable]
    /// <summary>
    /// 系统访问记录的SQL Server的数据访问层。
    /// </summary>
    public class History : MarshalByRefObject, IHistory
    {
        private static Shmzh.Components.SystemComponent.IDAL.IHistory dal;
        static History()
        {
            dal = Shmzh.Components.SystemComponent.DALFactory.DataProvider.HistoryProvider;
        }

        #region IHistory 成员

        public bool Insert(HistoryInfo historyInfo)
        {
            return dal.Insert(historyInfo);
        }

        public bool Update(HistoryInfo historyInfo)
        {
            return dal.Update(historyInfo);
        }

        public bool Delete(HistoryInfo historyInfo)
        {
            return dal.Delete(historyInfo);
        }

        public bool Delete(long id)
        {
            return dal.Delete(id);
        }

        public List<HistoryInfo> GetAllByDateTime(DateTime beginTime, DateTime endTime)
        {
            return dal.GetAllByDateTime(beginTime, endTime);
        }

        public List<HistoryInfo> GetByUserAndDateTime(string userName, DateTime beginTime, DateTime endTime)
        {
            return dal.GetByUserAndDateTime(userName, beginTime, endTime);
        }
       
        #endregion
    }
}
