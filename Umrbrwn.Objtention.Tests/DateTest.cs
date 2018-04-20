using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Umrbrwn.Objtention.Tests
{
    [TestClass]
    public class DateTest
    {
        [TestMethod]
        public void FYMonth_OutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FYMonth(15));
        }

        [TestMethod]
        public void FYMonth_NovemberMonthNumber_RetStringNov()
        {
            Assert.IsTrue(new FYMonth(11).ToString().Equals("NOV"));
        }

        [TestMethod]
        public void ToQuarter_QuarterTests()
        {
            Assert.IsTrue(new DateTime(2000, 1, 1).ToQuarter() == 1);
            Assert.IsTrue(new DateTime(2000, 2, 1).ToQuarter() == 1);
            Assert.IsTrue(new DateTime(2000, 3, 1).ToQuarter() == 1);
            Assert.IsTrue(new DateTime(2000, 4, 1).ToQuarter() == 2);
            Assert.IsTrue(new DateTime(2000, 5, 1).ToQuarter() == 2);
            Assert.IsTrue(new DateTime(2000, 6, 1).ToQuarter() == 2);
            Assert.IsTrue(new DateTime(2000, 7, 1).ToQuarter() == 3);
            Assert.IsTrue(new DateTime(2000, 8, 1).ToQuarter() == 3);
            Assert.IsTrue(new DateTime(2000, 9, 1).ToQuarter() == 3);
            Assert.IsTrue(new DateTime(2000, 10, 1).ToQuarter() == 4);
            Assert.IsTrue(new DateTime(2000, 11, 1).ToQuarter() == 4);
            Assert.IsTrue(new DateTime(2000, 12, 1).ToQuarter() == 4);
        }

        [TestMethod]
        public void ToH1FY_MonthBeforeH2End_H1FY()
        {
            DateTime expected = new DateTime(2000, FiscalYear.H1StartMonth, 1);
            DateTime actual = new DateTime(2001, FiscalYear.H2EndMonth - 1, 10).ToH1FY();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToH1FY_MonthAfterH2End_H1FY()
        {
            DateTime expected = new DateTime(2001, FiscalYear.H1StartMonth, 1);
            DateTime actual = new DateTime(2001, FiscalYear.H2EndMonth + 1, 10).ToH1FY();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToH2FY_MonthBeforeH1Start_H2FY()
        {
            var dim = DateTime.DaysInMonth(2001, FiscalYear.H2EndMonth);
            DateTime expected = new DateTime(2001, FiscalYear.H2EndMonth, dim);
            DateTime actual = new DateTime(2001, FiscalYear.H1StartMonth - 1, 10).ToH2FY();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToH2FY_MonthAfterH1Start_H2FY()
        {
            var dim = DateTime.DaysInMonth(2001, FiscalYear.H2EndMonth);
            DateTime expected = new DateTime(2001, FiscalYear.H2EndMonth, dim);
            DateTime actual = new DateTime(2000, FiscalYear.H1StartMonth + 1, 10).ToH2FY();
            Assert.AreEqual(expected, actual);
        }
    }
}
