using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Q2.Repository
{
    internal class ProviderFactory : IProviderFactory
    {
        private IServiceProvider _serviceProvider;

        public ProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRepositoryProvider GetProvider<TProvider>() where TProvider : IRepositoryProvider
        {
            var provider = _serviceProvider.GetService(typeof( TProvider));
            if (provider == null)
                throw new InvalidOperationException("Missing provider");

            return (TProvider)provider;
        }
    }
}
