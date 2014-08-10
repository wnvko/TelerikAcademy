namespace HangMan.GameStorage.ResultsStorage
{
    using System;
    using System.Collections.Generic;
    using HangMan.Interfaces;

    public abstract class Storage
    {
        public abstract void AddRecord(IRecord record);

        public abstract IEnumerable<IRecord> GetAll();
    }
}