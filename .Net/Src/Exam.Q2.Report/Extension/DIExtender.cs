using System;
using System.Collections.Generic;
using System.Text;
using Exam.Q2.Report;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DIExtender
    {
        public static IServiceCollection AddFormatterServices(this IServiceCollection services)
        {

            services.AddTransient<IConsoleFormatter, ConsoleFormatter>();
            //services.AddTransient<IDBProvider, FileProvider>();
            services.AddTransient<IFormatterFactory, FormaterFactory>();
            return services;
        }
    }
}
