using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Shmzh.Components.SystemComponent
{
    public abstract class ProviderBase:System.Configuration.Provider.ProviderBase
    {
        #region Field
        private static object syncObject = new object();
        private int defaultCommandTimeout = 30;
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the default timeout for every command
        /// </summary>
        /// <value>integer value in seconds.</value>
        public virtual int DefaultCommandTimeout
        {
            get { return this.defaultCommandTimeout;} 
            set { this.defaultCommandTimeout = value;}
        }

        ///<summary>
        /// Indicates if the current <see cref="Provider"/> implementation is supporting Transactions.
        ///</summary>
        public abstract bool IsTransactionSupported { get; }
        #endregion

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);


            lock (syncObject)
            {
                if (config["defaultCommandTimeout"] != null)
                {
                    int.TryParse(config["defaultCommandTimeout"], out this.defaultCommandTimeout);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
        /// </summary>
        /// <returns></returns>
        public virtual TransactionManager CreateTransaction() { throw new NotSupportedException(); }

    }
}
