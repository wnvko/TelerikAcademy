using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SameItemInArray;

namespace SameItemInArrayTest
{
    [TestClass]
    public class SameItemInArrayTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int [] testArray1 = {1,1,1,1,1,1,1,1,1,1};
            int testNumber = 1;
            int res = SameItemInArray.SameItemInArray.CountRepetitions(testNumber, testArray1);
            Assert.AreEqual(10, res);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int[] testArray2 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int testNumber = 2;
            int res = SameItemInArray.SameItemInArray.CountRepetitions(testNumber, testArray2);
            Assert.AreEqual(0, res);
        }
    }
}
