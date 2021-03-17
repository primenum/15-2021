using System;
using System.Collections.Generic;
using System.Text;
using Exam.Q2.Models;
using System.Linq;

namespace Exam.Q2.Report
{
    internal class ConsoleFormatter : IConsoleFormatter
    {
        public ConsoleFormatter()
        {
                
        }
        public string GetBody(IEnumerable<Employee> employees)
        {
            if (employees == null)
                throw new ArgumentNullException(nameof(employees));

            if (employees.Count() <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder(200);
            sb.AppendLine();
            sb.AppendLine("Section: Employee details");
            sb.AppendLine("---------------------------------------------------------------------");
            sb.AppendLine($"ID\tFirst Name\tLast Name\tSalary");
            sb.AppendLine();
            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.ID}\t{empl.FirstName}\t\t{empl.LastName}\t\t{empl.Salary}");
            }

            sb.AppendLine("---------------------------------------------------------------------");
            var avgSalary = employees.Average(empl => empl.Salary);
            sb.AppendLine($"Average salary {avgSalary}");
            sb.AppendLine("---------------------------------------------------------------------");

            return sb.ToString();
        }

        public string GetFooter()
        {
            return $"Generated - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} ";
        }

        public string GetHeader()
        {
            return $"Employees report";
        }

        byte[] IFormatter.Persist(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        
    }
}
