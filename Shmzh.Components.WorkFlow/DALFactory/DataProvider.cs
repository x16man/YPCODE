using System;
using System.Configuration;

namespace Shmzh.Components.WorkFlow.DALFactory
{
    /// <summary>
    /// 依据配置文件以抽象工厂模式来创建数据访问层.
    /// </summary>
    public static class DataProvider
    {
        private static readonly string WorkFlowDAL = ConfigurationManager.AppSettings["WorkFlowDAL"];

        #region Property
        /// <summary>
        /// 待办事宜对象的数据访问对象.
        /// </summary>
        public static IDAL.ITask TaskProvider
        {
            get { return CreateTaskProvider(); }
        }
        
        #endregion

        #region Method
        /// <summary>
        /// 创建待办事宜对象的数据访问对象。
        /// </summary>
        /// <returns>待办事宜对象的数据访问对象。</returns>
        public static IDAL.ITask CreateTaskProvider()
        {
            var className = string.Format("{0}.Task", WorkFlowDAL);
            var classType = Type.GetType(className); 
            return (IDAL.ITask) Activator.CreateInstance(classType);
        }
        #endregion
    }
}
