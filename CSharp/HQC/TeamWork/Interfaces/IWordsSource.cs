namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// This is the interface that should be implemented by all word collection sources. 
    /// </summary>
    public interface IWordsSource
    {
        IList<string> LoadWords();
    }
}
