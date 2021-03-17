using System.Collections.Generic;

namespace Exam.Q2.Report
{
    public interface IFormatter
    {
        string GetHeader();
        string GetBody(IEnumerable<Models.Employee> employees);
        string GetFooter();


        /// <summary>
        /// this method will be used for reports that can create a file
        /// for example PDF
        /// for formatters such Console, this interface should not be implemented
        /// </summary>
        /// <param name="employees"></param>
        /// <returns>the report content as byte[]</returns>
        byte[] Persist(IEnumerable<Models.Employee> employees);

    }
}