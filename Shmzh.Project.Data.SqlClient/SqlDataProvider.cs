using Shmzh.Project.Data.Bases;

namespace Shmzh.Project.Data.SqlClient
{
    /// <summary>
    /// SQL Server数据库的Provider。
    /// </summary>
    public sealed partial class SqlDataProvider
    {
        #region Field

        private volatile SqlProjectIncomeProvider _innerSqlProjectIncomeProvider;
        private volatile SqlProjectYearIncomeProvider _innerSqlProjectYearIncomeProvider;
        private volatile SqlProjectExtProvider _innerSqlProjectExtProvider;
        private volatile SqlTempTaskProvider _innerSqlTempTaskProvider;

        private volatile SqlViewProjectIncomeProvider _innerSqlViewProjectIncomeProvider;
        private volatile SqlViewProjectYearIncomeProvider _innerSqlViewProjectYearIncomeProvider;
        #endregion

        #region Table Provider
        ///<summary>
        /// 项目财务到帐信息Provider。
        ///</summary>
        public override ProjectIncomeProvider ProjectIncomeProvider
        {
            get
            {
                if (_innerSqlProjectIncomeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (_innerSqlProjectIncomeProvider == null)
                        {
                            this._innerSqlProjectIncomeProvider = new SqlProjectIncomeProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return _innerSqlProjectIncomeProvider;
            }
        }
        ///<summary>
        /// 项目财务年度到帐信息Provider。
        ///</summary>
        public override ProjectYearIncomeProvider ProjectYearIncomeProvider
        {
            get
            {
                if (_innerSqlProjectYearIncomeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (_innerSqlProjectYearIncomeProvider == null)
                        {
                            this._innerSqlProjectYearIncomeProvider = new SqlProjectYearIncomeProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return _innerSqlProjectYearIncomeProvider;
            }
        }
        /// <summary>
        /// 项目扩展属性的Provider。
        /// </summary>
        public override ProjectExtProvider ProjectExtProvider
        {
            get
            {
                if (_innerSqlProjectExtProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (_innerSqlProjectExtProvider == null)
                        {
                            this._innerSqlProjectExtProvider = new SqlProjectExtProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return _innerSqlProjectExtProvider;
            }
        }
        /// <summary>
        /// 任务的Provider。
        /// </summary>
        public override TempTaskProvider TempTaskProvider
        {
            get
            {
                if (_innerSqlTempTaskProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (_innerSqlTempTaskProvider == null)
                        {
                            this._innerSqlTempTaskProvider = new SqlTempTaskProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return _innerSqlTempTaskProvider;
            }
        }

        #endregion

        #region View Provider
        public override ViewProjectIncomeProvider ViewProjectIncomeProvider
        {
            get
            {
                if (_innerSqlViewProjectIncomeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (_innerSqlViewProjectIncomeProvider == null)
                        {
                            this._innerSqlViewProjectIncomeProvider = new SqlViewProjectIncomeProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return _innerSqlViewProjectIncomeProvider;
            }
        }
        public override ViewProjectYearIncomeProvider ViewProjectYearIncomeProvider
        {
            get
            {
                if (_innerSqlViewProjectYearIncomeProvider == null)
                {
                    lock (syncRoot)
                    {
                        if (_innerSqlViewProjectYearIncomeProvider == null)
                        {
                            this._innerSqlViewProjectYearIncomeProvider = new SqlViewProjectYearIncomeProvider(_connectionString, _providerInvariantName);
                        }
                    }
                }
                return _innerSqlViewProjectYearIncomeProvider;
            }
        }
        #endregion
    }
}
