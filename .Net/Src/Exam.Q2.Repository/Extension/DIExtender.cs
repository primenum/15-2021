using System;
using System.Collections.Generic;
using System.Text;
using Exam.Q2.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DIExtender
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {

            services.AddTransient<IFileProvider, FileProvider>();
            //services.AddTransient<IDBProvider, FileProvider>();
            services.AddTransient<IProviderFactory, ProviderFactory>();
            return services;
        }
    }
}
