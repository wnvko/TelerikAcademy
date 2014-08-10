namespace HangMan_Tests
{
    using System;
    using HangMan;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerRecordTest
    {
        private PlayerRecord testRecod = new PlayerRecord("John", "2");

        [TestMethod]
        public void PlayerRecordBuildRecordTest()
        {
            string buildRecord = "John:2";

            Assert.AreEqual(buildRecord, this.testRecod.BuildRecord());
        }

        [TestMethod]
        public void PlayerRecordToStringTest()
        {
            string buildRecord = "John - 2 mistakes";

            Assert.AreEqual(buildRecord, this.testRecod.ToString());
        }
    }
}
