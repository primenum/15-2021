using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Exam.Q2.Report.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetHeader_out__NotEmptyString()
        {
            var uut = new Exam.Q2.Report.ConsoleFormatter();
            Assert.IsFalse(string.IsNullOrEmpty(uut.GetHeader()));
        }

        [Test]
        public void GetFooter_out__NotEmptyString()
        {
            var uut = new Exam.Q2.Report.ConsoleFormatter();
            Assert.IsFalse(string.IsNullOrEmpty(uut.GetFooter()));
        }



        [Test]
        public void GetBody_null_out__ThrowException()
        {
            var uut = new Exam.Q2.Report.ConsoleFormatter();
            Assert.Throws<ArgumentNullException>(() => uut.GetBody(null));
        }


        [Test]
        public void GetBody_Empty_out__EmptyString()
        {
            var uut = new Exam.Q2.Report.ConsoleFormatter();
            var actual = uut.GetBody(new List<Models.Employee>());
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }
    }
}