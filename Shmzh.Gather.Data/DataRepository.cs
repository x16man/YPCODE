using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web;
using System.Web.Configuration;
using Shmzh.Components.SystemComponent;
using Shmzh.Gather.Data.Bases;
using Shmzh.Gather.Data.Model;

namespace Shmzh.Gather.Data
{
    public sealed class DataRepository
    {
        #region Field
        private static object SyncRoot = new object();
        private static DataProvider _provider = null;
        private static Shmzh.Components.SystemComponent.ProviderCollection _providers = null;
        private static volatile Configuration _config = null;
        private static volatile Section _section = null;

        #endregion

        #region CTOR
        private DataRepository()
        {
        }
        #endregion

        #region LoadProvider
        /// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(Shmzh.Components.SystemComponent.Provider provider)
        {
            LoadProvider(provider, false);
        }

        /// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
        public static void LoadProvider(Shmzh.Components.SystemComponent.Provider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
            {
                lock (SyncRoot)
                {
                    if (_providers == null)
                        _providers = new Shmzh.Components.SystemComponent.ProviderCollection();
                }
            }

            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if (_provider == null || setAsDefault)
                        _provider = provider as DataProvider;
                }
            }
        }

        ///<summary>
        /// Configuration based provider loading, will load the providers on first call.
        ///</summary>
        private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new Shmzh.Components.SystemComponent.ProviderCollection();
                        var thisSection = Section();
                        ProvidersHelper.InstantiateProviders(thisSection.Providers, _providers, typeof(Shmzh.Components.SystemComponent.Provider));
                        _provider = _providers[thisSection.DefaultProvider] as DataProvider;

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }
        #endregion

        #region Configuration
        /// <summary>
        /// Gets a reference to the configured NetTiersServiceSection object.
        /// </summary>
        public static Shmzh.Components.SystemComponent.Section Section()
        {
            if (_section == null)
            {
                // otherwise look for section based on the assembly name
                _section = WebConfigurationManager.GetSection("Shmzh.Gather.Data") as Section;
            }

            #region Design-Time Support

            if (_section == null)
            {
                // lastly, try to find the specific NetTiersServiceSection for this assembly
                foreach (ConfigurationSection temp in Configuration.Sections)
                {
                    if (temp is Section)
                    {
                        _section = temp as Section;
                        break;
                    }
                }
            }

            #endregion Design-Time Support

            if (_section == null)
            {
                throw new ProviderException("Unable to load NetTiersServiceSection");
            }

            return _section;

        }

        /// <summary>
        /// Gets a reference to the application configuration object.
        /// </summary>
        public static Configuration Configuration
        {
            get
            {
                if (_config == null)
                {
                    // load specific config file
                    if (HttpContext.Current != null)
                    {
                        _config = WebConfigurationManager.OpenWebConfiguration("~");
                    }
                    else
                    {
                        _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    }
                }

                return _config;
            }
        }
        #endregion

        #region Connections

        /// <summary>
        /// Gets a reference to the ConnectionStringSettings collection.
        /// </summary>
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                // use default ConnectionStrings if _section has already been discovered
                if (_config == null && _section != null)
                {
                    return WebConfigurationManager.ConnectionStrings;
                }

                return Configuration.ConnectionStrings.ConnectionStrings;
            }
        }

        // dictionary of connection providers
        private static Dictionary<String, ConnectionProvider> _connections;

        /// <summary>
        /// Gets the dictionary of connection providers.
        /// </summary>
        public static Dictionary<String, ConnectionProvider> Connections
        {
            get
            {
                if (_connections == null)
                {
                    lock (SyncRoot)
                    {
                        if (_connections == null)
                        {
                            _connections = new Dictionary<String, ConnectionProvider>();

                            // add a connection provider for each configured connection string
                            foreach (ConnectionStringSettings conn in ConnectionStrings)
                            {
                                _connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
                            }
                        }
                    }
                }

                return _connections;
            }
        }

        /// <summary>
        /// Adds the specified connection string to the map of connection strings.
        /// </summary>
        /// <param name="connectionStringName">The connection string name.</param>
        /// <param name="connectionString">The provider specific connection information.</param>
        public static void AddConnection(String connectionStringName, String connectionString)
        {
            lock (SyncRoot)
            {
                Connections.Remove(connectionStringName);
                ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
                Connections.Add(connectionStringName, connection);
            }
        }

        /// <summary>
        /// Provides ability to switch connection string at runtime.
        /// </summary>
        public sealed class ConnectionProvider
        {
            private Shmzh.Components.SystemComponent.Provider _provider;
            private Shmzh.Components.SystemComponent.ProviderCollection _providers;
            private String _connectionStringName;
            private String _connectionString;


            /// <summary>
            /// Initializes a new instance of the ConnectionProvider class.
            /// </summary>
            /// <param name="connectionStringName">The connection string name.</param>
            /// <param name="connectionString">The provider specific connection information.</param>
            public ConnectionProvider(String connectionStringName, String connectionString)
            {
                _connectionString = connectionString;
                _connectionStringName = connectionStringName;
            }

            /// <summary>
            /// Gets the provider.
            /// </summary>
            public Shmzh.Components.SystemComponent.Provider Provider
            {
                get { LoadProviders(); return _provider; }
            }

            /// <summary>
            /// Gets the provider collection.
            /// </summary>
            public Shmzh.Components.SystemComponent.ProviderCollection Providers
            {
                get { LoadProviders(); return _providers; }
            }

            /// <summary>
            /// Instantiates the configured providers based on the supplied connection string.
            /// </summary>
            private void LoadProviders()
            {
                DataRepository.LoadProviders();

                // Avoid claiming lock if providers are already loaded
                if (_providers == null)
                {
                    lock (SyncRoot)
                    {
                        // Do this again to make sure _provider is still null
                        if (_providers == null)
                        {
                            var thisSection = Section();
                            // apply connection information to each provider
                            for (int i = 0; i < thisSection.Providers.Count; i++)
                            {
                                thisSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
                                // remove previous connection string, if any
                                thisSection.Providers[i].Parameters.Remove("connectionString");

                                if (!String.IsNullOrEmpty(_connectionString))
                                {
                                    thisSection.Providers[i].Parameters["connectionString"] = _connectionString;
                                }
                            }

                            // Load registered providers and point _provider to the default provider
                            _providers = new Shmzh.Components.SystemComponent.ProviderCollection();

                            ProvidersHelper.InstantiateProviders(thisSection.Providers, _providers, typeof(Shmzh.Components.SystemComponent.Provider));
                            _provider = _providers[thisSection.DefaultProvider];
                        }
                    }
                }
            }
        }

        #endregion Connections

        #region Static properties
        ///<summary>
        /// 获取<see cref="CategoryInfo"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了CRUD方法.
        ///</summary>
        public static CategoryProvider CategoryProvider
        {
            get
            {
                LoadProviders();
                return _provider.CategoryProvider;
            }
        }
        ///<summary>
        /// 获取 <see cref="SchemaInfo"/> 业务实体的数据访问逻辑组件的当前实例．
        /// 它提供了CRUD方法.
        ///</summary>
        public static SchemaProvider SchemaProvider
        {
            get
            {
                LoadProviders();
                return _provider.SchemaProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="SchemaDataInfo"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了获取、保存、确认、取消确认方法。
        /// </summary>
        public static SchemaDataProvider SchemaDataProvider
        {
            get
            {
                LoadProviders();
                return _provider.SchemaDataProvider;
            }
        }
        
        ///<summary>
        /// 获取<see cref="OperationInfo"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了CRUD方法.
        ///</summary>
        public static OperationProvider OperationProvider
        {
            get
            {
                LoadProviders();
                return _provider.OperationProvider;
            }
        }
        ///<summary>
        /// 获取<see cref="RelationInfo"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供CRUD方法.
        ///</summary>
        public static RelationProvider RelationProvider
        {
            get
            {
                LoadProviders();
                return _provider.RelationProvider;
            }
        }
        ///<summary>
        /// 获取<see cref="TagInfo"/>业务实体的数据访问逻辑组件的当前实例.
        /// 它提供了GetAll(),GetById(),GetByAction()等获取方法.
        ///</summary>
        public static TagProvider TagProvider
        {
            get
            {
                LoadProviders();
                return _provider.TagProvider;
            }
        }

        /// <summary>
        /// 获取<see cref="TagCategoryInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了Insert，Update，Delete，GetAll，GetByParentId，GetById等方法。
        /// </summary>
        public static TagCategoryProvider TagCategoryProvider
        {
            get
            {
                LoadProviders();
                return _provider.TagCategoryProvider;
            }
        }

        /// <summary>
        /// 获取<see cref="TagCategoryDetailInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了Insert，Delete，GetAll，GetByCategoryId等方法。
        /// </summary>
        public static TagCategoryDetailProvider TagCategoryDetailProvider
        {
            get
            {
                LoadProviders();
                return _provider.TagCategoryDetailProvider;
            }
        }

        /// <summary>
        /// 获取<see cref="DateMsInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了CRUD等方法。
        /// </summary>
        public static DateMsProvider DateMsProvider
        {
            get
            {
                LoadProviders();
                return _provider.DateMsProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="TagSqlMapInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了CRUD等方法。
        /// </summary>
        public static TagSqlMapProvider TagSqlMapProvider
        {
            get 
            {
                LoadProviders();
                return _provider.TagSqlMapProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="AnalogInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了Get,Sync等方法。
        /// </summary>
        public static AnalogProvider AnalogProvider
        {
            get
            {
                LoadProviders();
                return _provider.AnalogProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="DigitalInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了Get,Sync等方法。
        /// </summary>
        public static DigitalProvider DigitalProvider
        {
            get
            {
                LoadProviders();
                return _provider.DigitalProvider;
            }
        }
        /// <summary>
        /// 获取<see cref="EnergyInfo"/>业务实体的数据访问逻辑组件的当前实例。
        /// 它提供了Get,Sync等方法。
        /// </summary>
        public static EnergyProvider EnergyProvider
        {
            get
            {
                LoadProviders();
                return _provider.EnergyProvider;
            }
        }
        #endregion
    }
}
