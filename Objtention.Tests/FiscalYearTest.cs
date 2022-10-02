using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Objtention.Tests
{
    [TestClass]
    public class FiscalYearTest
    {
        [TestMethod]
        public void FiscalYear_SameH1FYAndH2FY_ThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new FiscalYear(2000, 2000));
            Assert.ThrowsException<ArgumentException>(() => new FiscalYear(2001, 2003));
        }

        [TestMethod]
        public void FiscalYear_ParseFromValidString_True()
        {
            Assert.IsNotNull(FiscalYear.Parse("2000-2001"));
        }

        [TestMethod]
        public void FiscalYear_ParseFromInalidString_ThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => FiscalYear.Parse("2000-200"));
            Assert.ThrowsException<ArgumentException>(() => FiscalYear.Parse("2000-2004"));
            Assert.ThrowsException<ArgumentException>(() => FiscalYear.Parse("2002-2000"));
            Assert.ThrowsException<ArgumentException>(() => FiscalYear.Parse("2001- 2000"));
            Assert.ThrowsException<ArgumentException>(() => FiscalYear.Parse("2001-    2000"));

        }

        [TestMethod]
        public void FiscalYear_ParseFromInvalidFormat_ThrowsFormatException()
        {
            Assert.ThrowsException<FormatException>(() => FiscalYear.Parse("Invalid String Input"));
            Assert.ThrowsException<FormatException>(() => FiscalYear.Parse("1x99 -1111"));
        }

        [TestMethod]
        public void FiscalYear_TwoEqualFY_True()
        {
            FiscalYear f1 = new FiscalYear(2000, 2001);
            FiscalYear f2 = new FiscalYear(2000, 2001);
            Assert.IsTrue(f1.Equals(f2));
            Assert.IsTrue(f1 == f2);
        }

        [TestMethod]
        public void FiscalYear_TwoUnequalFY_False()
        {
            FiscalYear f1 = new FiscalYear(2000, 2001);
            FiscalYear f2 = new FiscalYear(2015, 2016);
            Assert.IsFalse(f1.Equals(f2));
            Assert.IsFalse(f1 == f2);
        }

        [TestMethod]
        public void FiscalYearAddYear_Adding2Years_NewFiscalYear()
        {
            FiscalYear expected = new FiscalYear(2005, 2006);
            FiscalYear actual = new FiscalYear(2003, 2004);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
