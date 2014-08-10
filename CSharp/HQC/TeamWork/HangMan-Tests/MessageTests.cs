namespace HangMan_Tests
{
    using System;
    using HangMan.Messages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void CheckIfGetMessageIsReturningCorrectValue()
        {
            var message = Message.GetMessage("greeting");
            Assert.AreEqual("Welcome to Hangman", message, "Generated message is different");
        }
    }
}
