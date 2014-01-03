using System;

namespace Shmzh.Components.SystemComponent
{
    public class ProviderCollection : System.Configuration.Provider.ProviderCollection
    {
        /// <summary>
        /// Gets the <see cref="T:NetTiersProvider"/> with the specified name.
        /// </summary>
        /// <value></value>
        public new Provider this[string name]
        {
            get { return (Provider)base[name]; }
        }

        /// <summary>
        /// Adds the specified provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public void Add(Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (!(provider is Shmzh.Components.SystemComponent.Provider))
            {
                throw new ArgumentException("Invalid provider type", "provider");
            }
            base.Add(provider);
        }
    }
}
