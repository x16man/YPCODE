using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using DDE2OPC.IDAL;

namespace DDE2OPC.DALFactory
{
    public class DataProvider
    {
        private static readonly string MapDAL = ConfigurationManager.AppSettings["MapDAL"];
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Property
        /// <summary>
        /// Map的数据访问接口。
        /// </summary>
        public static IMap MapProvider
        {
            get { return CreateMapProvider(); }
        }
        #endregion 

        #region Method
        /// <summary>
        /// 创建Map的数据访问接口。
        /// </summary>
        /// <returns>Map的数据访问接口。</returns>
        private static IMap CreateMapProvider()
        {
            var className = string.Format("{0}.Map", MapDAL);
            var classType = Type.GetType(className);
            try
            {
                var obj = (IDAL.IMap)Activator.CreateInstance(classType);
                return obj;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return null;
            }
        }
        #endregion
    }
}
