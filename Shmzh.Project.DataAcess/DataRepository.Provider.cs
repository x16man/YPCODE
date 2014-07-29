using Shmzh.Project.Data.Bases;

namespace Shmzh.Project.Data
{
    public sealed partial class DataRepository
    {
        #region Table Provider
        /// <summary>
        /// 获取<see cref="ProjectIncomeProvider"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了CRUD方法.
        /// </summary>
        public static ProjectIncomeProvider ProjectIncomeProvider
        {
            get
            {
                LoadProviders();
                return _provider.ProjectIncomeProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="ProjectYearIncomeProvider"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了CRUD方法.
        /// </summary>
        public static ProjectYearIncomeProvider ProjectYearIncomeProvider
        {
            get
            {
                LoadProviders();
                return _provider.ProjectYearIncomeProvider;
            }
        }
        
        /// <summary>
        /// 获取<see cref="ProjectExtProvider"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了CRUD方法.
        /// </summary>
        public static ProjectExtProvider ProjectExtProvider
        {
            get
            {
                LoadProviders();
                return _provider.ProjectExtProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="TempTaskProvider"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了CRUD方法.
        /// </summary>
        public static TempTaskProvider TempTaskProvider
        {
            get
            {
                LoadProviders();
                return _provider.TempTaskProvider;
            }
        }
        #endregion

        #region View Provider
        public static ViewProjectIncomeProvider ViewProjectIncomeProvider
        {
            get
            {
                LoadProviders();
                return _provider.ViewProjectIncomeProvider;
            }
        }
        public static ViewProjectYearIncomeProvider ViewProjectYearIncomeProvider
        {
            get
            {
                LoadProviders();
                return _provider.ViewProjectYearIncomeProvider;
            }
        }
        #endregion
    }
}
