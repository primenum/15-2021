using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Q2.Models;
using Newtonsoft.Json;

namespace Exam.Q2.Repository
{
    internal class FileProvider : IFileProvider
    {
        const string REPOSITORY_SOURCE = @"Data\EmployeesCollection.json";
        public IEnumerable<Employee> GetEmployees()
        {
            string content = ReadRepositoryData();
            if (string.IsNullOrEmpty(content))
                return default(IEnumerable<Employee>);

            var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);
            return result;

        }

        private string ReadRepositoryData()
        {
            string content = System.IO.File.ReadAllText(REPOSITORY_SOURCE);
            return content;
        }
    }
}
