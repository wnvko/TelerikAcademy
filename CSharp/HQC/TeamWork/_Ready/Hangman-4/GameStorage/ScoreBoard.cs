namespace HangMan
{
    using System.Collections.Generic;
    using HangMan.GameStorage.ResultsStorage;
    using HangMan.Interfaces;

    public class ScoreBoard : ResultsManager
    {
        public ScoreBoard(Storage storage)
            : base(storage)
        {
        }

        public override void AddResult(IRecord record)
        {
            Storage.AddRecord(record);
        }

        public override IEnumerable<IRecord> GetAll()
        {
            IEnumerable<IRecord> resultsList;
            return resultsList = Storage.GetAll();
        }
    }
}
