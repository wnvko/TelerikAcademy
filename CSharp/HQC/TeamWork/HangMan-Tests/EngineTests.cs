namespace HangMan_Tests
{
    using System.Collections.Generic;
    using HangMan.EngineAndRenderer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void CheckWord()
        {
            Engine game = Engine.Instance;
            game.CurrentWord = "testWord";
            Assert.AreEqual("testWord", game.CurrentWord, "The newly created word and expected word aren't the same");
        }

        [TestMethod]
        public void CheckIfGetGameStateIsReturningValidData()
        {
            Engine game = Engine.Instance;
            game.CurrentWord = "testWord";
            var dataFromEngine = game.GetGameState();
            Assert.AreEqual("testWord", dataFromEngine["word"], "Invalid game state data returned");
        }

        [TestMethod]
        public void CheckIfGeneratedPlaceholderIsOk()
        {
            Engine game = Engine.Instance;
            game.CurrentWord = "testWord";
            game.PlayerWord = game.GenerateWordPlaceholder(game.CurrentWord);
            var assertedValue = "The secret word is:_ _ _ _ _ _ _ _";
            var actualMessage = game.PrintWord().Trim();
            Assert.AreEqual(assertedValue, actualMessage, "Placeholder generator isn't working corectly");
        }

        [TestMethod]
        public void CheckIfGuessIsFindingOneLetter()
        {
            Engine game = Engine.Instance;
            game.CurrentWord = "testWord";
            var guessedLetters = game.Guess('o');
            Assert.AreEqual(1, guessedLetters, "Expected one guessed letter, but recieved another value");
        }

        [TestMethod]
        public void CheckIfGuessIsFindingMultipleLetters()
        {
            Engine game = Engine.Instance;
            game.CurrentWord = "testWord";
            var guessedLetters = game.Guess('t');
            Assert.AreEqual(2, guessedLetters, "Expected two guessed letters, but recieved another value");
        }

        [TestMethod]
        public void CheckIfThereIsOnlyOneInstanceOfTheGame()
        {
            Engine game1 = Engine.Instance;
            Engine game2 = Engine.Instance;
            Assert.AreEqual(game1, game2, "There must be only 1 instance of the game");
        }

        [TestMethod]
        public void TestIfGreetingMessageIsCorrectlyGenerated()
        {
            Engine game = Engine.Instance;
            var greeting = game.GenerateGreetingMessage();
            Assert.AreEqual("Welcome to Hangman", greeting, "Error in generating the greeting message");
        }
    }
}