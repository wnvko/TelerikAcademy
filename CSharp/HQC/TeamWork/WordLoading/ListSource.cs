namespace HangMan.WordLoading
{
    using System;
    using System.Collections.Generic;
    using HangMan.Interfaces;

    /// <summary>
    /// This is a implementation for a words source. The words collection will be loaded from a simple hardcoded collection of strings.
    /// </summary>
    public class ListSource : IWordsSource
    {
        private IList<string> words;

        public ListSource()
        {
            // declare words collection
            this.words = new string[] 
            {
                "computer", "programmer", "software", "debugger", "compiler",
                "developer", "algorithm", "array", "method", "variable"
            };
        }

        public IList<string> Words
        {
            set
            {
                this.words = value;                
            }
        }

        public IList<string> LoadWords()
        {
            return this.words;
        }
    }
}
