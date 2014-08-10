namespace HangMan.WordLoading
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using HangMan.Interfaces;
    
    /// <summary>
    /// This is a implementation for a words source. The words collection will be loaded from a file.
    /// </summary>
    public class FileSource : IWordsSource
    {
        private string filename;

        public FileSource(string filename)
        {
            // declare file source refferance
            this.filename = filename;
        }

        public IList<string> LoadWords()
        {
            throw new NotImplementedException();
        }
    }
}
