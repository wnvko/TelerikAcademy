namespace HangMan_Tests
{
    using System;
    using HangMan;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTest
    {
        private Player playerWithOneMistake = new Player("John", 1);
        private Player onotherPlayerWithOneMistake = new Player("Ringo", 1);
        private Player emptyPlayer = new Player();
        
        [TestMethod]
        public void PlayerAreEqualSamePlayers()
        {
            bool areEqual = this.playerWithOneMistake.CompareTo(this.onotherPlayerWithOneMistake) == 0;
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PlayerCheckDefaultFieldValues()
        {
            bool areEqual = this.emptyPlayer.Name == string.Empty &&
                            this.emptyPlayer.Mistakes == 999;

            Assert.IsTrue(areEqual);
        }
    }
}
