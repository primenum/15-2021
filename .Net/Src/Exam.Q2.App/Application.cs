using System;
using System.Collections.Generic;
using System.Text;
using Exam.Q2.Report;
using Exam.Q2.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Exam.Q2.App
{
    class Application : IApplication
    {
        private readonly ILogger<Application> _logger;
        private readonly IConfiguration _configuration;
        private readonly IProviderFactory _providerFactory;
        private readonly IFormatterFactory _formatterFactory;
        private readonly string _repositoryProvider;

        public Application(ILogger<Application> logger, IConfiguration configuration,
            Repository.IProviderFactory providerFactory,
            Report.IFormatterFactory formatterFactory)
        {
            _logger = logger;
            _providerFactory = providerFactory;
            _formatterFactory = formatterFactory;

            _repositoryProvider = configuration.GetValue<string>("DataSourceProvider");
            

        }
        public void Run()
        {
            _logger.LogInformation("Application enter running state");
            var repositoryProvider = GetRepositoryProvider();
            var employees = repositoryProvider.GetEmployees();
            var consoleFormatter = _formatterFactory.GetFormatter<Report.IConsoleFormatter>();
            Console.WriteLine(consoleFormatter.GetHeader());
            Console.WriteLine(consoleFormatter.GetBody(employees));
            Console.WriteLine(consoleFormatter.GetFooter());
            
            _logger.LogInformation("Application complete");

        }


        private Repository.IRepositoryProvider GetRepositoryProvider()
        {
            _logger.LogInformation("Looking for repository provider");
            if (_repositoryProvider == typeof(IFileProvider).Name)
            {
                _logger.LogInformation("Repository provider, file");
                return _providerFactory.GetProvider<IFileProvider>();
            }
            if (_repositoryProvider == typeof(IDBProvider).Name)
            {
                _logger.LogInformation("Repository provider, DB");
                return _providerFactory.GetProvider<IDBProvider>();
            }

            _logger.LogError("Repository provider not found");
            throw new ArgumentException($"Repository: {_repositoryProvider} not found, Please check your spelling or set available provider");
        }
    }
}
