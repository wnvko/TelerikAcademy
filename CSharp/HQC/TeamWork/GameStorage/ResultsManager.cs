namespace HangMan
{
    using System.Collections.Generic;
    using HangMan.GameStorage.ResultsStorage;
    using HangMan.Interfaces;

    public abstract class ResultsManager
    {
        protected readonly Storage Storage;

        protected ResultsManager(Storage storage)
        {
            this.Storage = storage;
        }

        public abstract void AddResult(IRecord result);

        public abstract IEnumerable<IRecord> GetAll();
    }
}
