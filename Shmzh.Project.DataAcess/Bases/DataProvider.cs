using System;

namespace Shmzh.Project.Data.Bases
{
    /// <summary>
    /// 项目数据库依据配置文件以抽象工厂模式来创建数据访问层.
    /// </summary>
    public  abstract partial class DataProvider : Shmzh.Components.SystemComponent.Provider
    {
        #region Table Provider
        /// <summary>
        /// Current ProjectIncomeProvider instance.
        /// </summary>
        public virtual ProjectIncomeProvider ProjectIncomeProvider { get { throw new NotImplementedException(); } }
        /// <summary>
        /// Current ProjectYearIncomeProvider instance.
        /// </summary>
        public virtual ProjectYearIncomeProvider ProjectYearIncomeProvider { get { throw new NotImplementedException(); } }
        
        /// <summary>
        /// Current ProjectExtProvider instance.
        /// </summary>
        public virtual ProjectExtProvider ProjectExtProvider{get {throw new NotImplementedException();}}
        /// <summary>
        /// Current TempTaskProvider instance.
        /// </summary>
        public virtual TempTaskProvider TempTaskProvider { get{throw new NotImplementedException();} }

        #endregion

        #region View Provider
        /// <summary>
        /// Current ViewProjectIncomeProvider instance.
        /// </summary>
        public virtual ViewProjectIncomeProvider ViewProjectIncomeProvider{get {throw new NotImplementedException();} }
        /// <summary>
        /// Current ViewProjectYearIncomeProvider instance.
        /// </summary>
        public virtual ViewProjectYearIncomeProvider ViewProjectYearIncomeProvider { get { throw new NotImplementedException(); } }
        #endregion
    }
}
