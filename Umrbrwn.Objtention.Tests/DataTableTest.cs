using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace Umrbrwn.Objtention.Tests
{
    [TestClass]
    public class DataTableTest
    {
        DataTable sample;

        public DataTableTest()
        {
            sample = new DataSource().GetStudents();
        }

        [TestMethod]
        public void DataTableToType()
        {
            Student s = null;
            s = sample.DataTableToType<Student>();

            Assert.IsNotNull(s);
            Assert.IsFalse(default(int) == s.Id);
            Assert.IsNotNull(s.Name);
            Assert.IsFalse(default(double) == s.CGPA);
            Assert.IsTrue(default(decimal?) == s.Loans);
            Assert.IsTrue(default(DateTime?) == s.ModifiedOn);
        }

        [TestMethod]
        public void DataTableToList()
        {
            var s = sample.DataTableToList<Student>();

            Assert.IsNotNull(s);
            Assert.IsTrue(s.Count > 1);
            Assert.IsFalse(default(int) == s.FirstOrDefault().Id);
            Assert.IsNotNull(s.FirstOrDefault().Name);
            Assert.IsFalse(default(double) == s.FirstOrDefault().CGPA);
            Assert.IsTrue(default(decimal?) == s.FirstOrDefault().Loans);
            Assert.IsTrue(default(DateTime?) == s.FirstOrDefault().ModifiedOn);
        }
    }
}
