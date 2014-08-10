namespace HangMan_Tests
{
    using System;
    using System.Collections.Generic;
    using HangMan;
    using HangMan.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void TestMaxNumberOfRecords()
        {
            FileStorage storage = new FileStorage(3);
            ScoreBoard scoreBoard = new ScoreBoard(storage);
            PlayerRecord record1 = new PlayerRecord("Player1", "5");
            scoreBoard.AddResult(record1);
            PlayerRecord record2 = new PlayerRecord("Player2", "3");
            scoreBoard.AddResult(record2);
            PlayerRecord record3 = new PlayerRecord("Player3", "4");
            scoreBoard.AddResult(record3);
            PlayerRecord record4 = new PlayerRecord("Player4", "6");
            scoreBoard.AddResult(record4);
            IEnumerable<IRecord> result = scoreBoard.GetAll();
            int numberOfRecords = 0;
            foreach (var item in result)
            {
                numberOfRecords++;
            }

            Assert.AreEqual(numberOfRecords, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddRecordInWrongFormat()
        {
            FileStorage storage = new FileStorage(3);
            ScoreBoard scoreBoard = new ScoreBoard(storage);
            PlayerRecord record = new PlayerRecord("Player1", "5mistakes");
            scoreBoard.AddResult(record);
        }
    }
}
