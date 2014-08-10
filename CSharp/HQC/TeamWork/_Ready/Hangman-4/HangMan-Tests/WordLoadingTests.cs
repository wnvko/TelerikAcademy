namespace HangMan_Tests
{
    using System;
    using HangMan.WordLoading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WordLoadingTests
    {
        private static readonly string WORD = "word";

        [TestMethod]
        public void CheckLoadedWordsLengthWhenUsingListSource()
        {
            // create words loader
            WordsLoader loader = new WordsLoader();

            // create list words source
            ListSource listSource = new ListSource();

            int listLength = 4;

            listSource.Words = this.CreateWordsList(listLength);

            // set loader source
            loader.SetSource(listSource);

            // load the words using the WordsLoader
            string[] loadedWords = (string[])loader.LoadWords();

            // do test
            Assert.AreEqual(listLength, loadedWords.Length);
        }

        [TestMethod]
        public void CheckLoadedWordsWhenUsingListSource()
        {
            // create words loader
            WordsLoader loader = new WordsLoader();

            // create list words source
            ListSource listSource = new ListSource();

            int listLength = 4;

            listSource.Words = this.CreateWordsList(listLength);

            // set loader source
            loader.SetSource(listSource);

            // load the words using the WordsLoader
            string[] loadedWords = (string[])loader.LoadWords();

            // do test
            for (int i = 0; i < loadedWords.Length; i++)
            {
                Assert.AreEqual(loadedWords[i], WordLoadingTests.WORD);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "The words source must be set before any attempt to load words!")]
        public void CheckIfExceptionIsThrownWhenNoWordsSourceIsSpecified()
        {
            // create words loader
            WordsLoader loader = new WordsLoader();

            // skip SetSource...

            // load the words using the WordsLoader
            string[] loadedWords = (string[])loader.LoadWords();
        }

        private string[] CreateWordsList(int length)
        {
            string[] result = new string[length];

            for (int j = 0; j < length; j++)
            {
                result[j] = WordLoadingTests.WORD;
            }

            return result;
        }
    }
}
