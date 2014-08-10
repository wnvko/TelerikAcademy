namespace HangMan.WordLoading
{
    using System;
    using System.Collections.Generic;
    using HangMan.Interfaces;

    /// <summary>
    /// The WordsLoader is used for abstracting the words loading process. It is used to implement the Bridge pattern.
    /// </summary>
    public class WordsLoader
    {
        protected IWordsSource source;

        public void SetSource(IWordsSource source)
        {
            this.source = source;
        }

        public virtual IList<string> LoadWords()
        {
            if (this.source == null)
            {
                throw new NullReferenceException("The words source must be set before any attempt to load words!");       
            }

            return this.source.LoadWords();
        }
    }
}
