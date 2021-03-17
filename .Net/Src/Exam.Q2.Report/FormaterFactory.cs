using System;

namespace Exam.Q2.Report
{
    internal class FormaterFactory : IFormatterFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FormaterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public IFormatter GetFormatter<TFormatter>() where TFormatter : IFormatter
        {
            var formatter = _serviceProvider.GetService(typeof(TFormatter));
            if (formatter == null)
                throw new InvalidOperationException("Missing formatter");

            return (TFormatter)formatter;
        }
    }
}
