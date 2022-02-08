using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LongestSubsequenceTest
{
    [TestMethod]
    public void TestTrivialList()
    {
        List<int> result = new List<int>() { 2, 2, 2 };
        List<int> test = new List<int>();

        test = LongestSubsequence.LongestSubsequenceOfEqualNumbers(new List<int>() { 1, 1, 2, 2, 2, 5, 4, 3, 1, 1, 5, 3, 0 });
        Assert.AreEqual(result.Count, test.Count);

        for (int i = 0; i < result.Count; i++)
        {
            Assert.AreEqual(result[i], test[i]);
        }
    }

    [TestMethod]
    public void TestEmptyList()
    {
        List<int> result = new List<int>();
        List<int> test = new List<int>();

        Assert.AreEqual(result.Count, test.Count);

        for (int i = 0; i < result.Count; i++)
        {
            Assert.AreEqual(result[i], test[i]);
        }
    }
}
