using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Q2.Models;

namespace Exam.Q2.Repository
{
    public interface IRepositoryProvider 
    {
        IEnumerable<Employee> GetEmployees();
    }
}
