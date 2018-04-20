using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Umrbrwn.Objtention.Tests
{
    [TestClass]
    public class ObjUtilsTest
    {
        [TestMethod]
        public void ToTitleCase_RandomString_TitleCase()
        {
            string expected = "This Is A Test String 123 #Test";
            string actual = "this Is A test STRING 123 #teSt".ToTitleCase();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualIgnoreCase_DistinctStrings_False()
        {
            Assert.IsFalse("umrbrwn".EqualsIgnoreCase("this is sample one"));
        }

        [TestMethod]
        public void EqualIgnoreCase_UnequalStrings_True()
        {
            Assert.IsTrue("umrbrwn".EqualsIgnoreCase("UMRBrwn"));
        }

        [TestMethod]
        public void EqualIgnoreCase_EqualStrings_True()
        {
            Assert.IsTrue("umrbrwn".EqualsIgnoreCase("umrbrwn"));
        }

        [TestMethod]
        public void ToInt_NullRef_Ret0()
        {
            int expected = 0;
            object obj = null;
            int actual = obj.ToInt();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToInt_StringfiedInt_ConvertedInt()
        {
            int expected = 2001;
            string obj = "2001";
            int actual = obj.ToInt();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToType_NullObjToDouble_DefaultOfDoubleType()
        {
            double expected = default(double);
            string obj = null;
            double actual = obj.ToType<double>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrecised_ConstantDecimalPrecision_PrecisedDecimal()
        {
            decimal expected = 2000.00m;
            decimal actual = (1999.99999m).ToPrecised();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrecised_ProvidedDecimalPrecision_PrecisedDecimal()
        {
            decimal expected = 149.359m;
            decimal actual = (149.35890m).ToPrecised(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrecised_ConstantDoublePrecision_PrecisedDouble()
        {
            double expected = 149.36d;
            double actual = (149.35890d).ToPrecised();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrecised_ConstantDoublePrecisionFromNAN_Ret0()
        {
            double expected = 0;
            double actual = (double.NaN).ToPrecised();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrecised_ConstantDobulePrecisionFromPositiveInfinity_Ret0()
        {
            double expected = 0;
            double actual = (double.PositiveInfinity).ToPrecised();
            Assert.AreEqual(expected, actual);
        }
    }
}
