namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using HangMan.GameStorage.ResultsStorage;
    using HangMan.Interfaces;

    public class FileStorage : Storage
    {
        private string fileName = @"..\..\results.txt";

        public FileStorage(int maxRecordNumber)
        {
            this.MaxRecordNumber = maxRecordNumber;
        }

        public FileStorage(int maxRecordNumber, string fileNameIn)
        {
            this.MaxRecordNumber = maxRecordNumber;
            this.fileName = fileNameIn;
        }

        public int MaxRecordNumber { get; set; }

        public override void AddRecord(IRecord record)
        {
            // Add new record in the storage
            string recordToWrite = record.BuildRecord();
            this.VerifyRecord(recordToWrite);
            StreamWriter streamWriter = new StreamWriter(this.fileName, true);
            streamWriter.WriteLine(recordToWrite);
            streamWriter.Close();

            // Get records list sorted after the new one is added
            IEnumerable<IRecord> newFileList = this.GetAll();

            // Remove elements that exceed MaxRecordNumber 
            StreamWriter writer = new StreamWriter(this.fileName, false);
            using (writer)
            {
                int count = this.MaxRecordNumber;
                foreach (var item in newFileList)
                {
                    writer.WriteLine(item.BuildRecord());
                    count--;
                    if (count == 0)
                    {
                        break;
                    }
                }
            }
        }

        public override IEnumerable<IRecord> GetAll()
        {
            StreamReader reader = new StreamReader(this.fileName);
            List<PlayerRecord> resultList = new List<PlayerRecord>();
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] lineParsed = line.Split(':');
                    PlayerRecord currentPlayer = new PlayerRecord(lineParsed[0], lineParsed[1]);
                    resultList.Add(currentPlayer);
                    line = reader.ReadLine();
                }
            }

            resultList = resultList.OrderBy(x => int.Parse(x.Mistakes)).ToList();
            return resultList;
        }

        private void VerifyRecord(string recordToWrite)
        {
            string[] recordParsed = recordToWrite.Split(':');
            int mistakes;
            bool verification = int.TryParse(recordParsed[1], out mistakes);

            if (!verification)
            {
                throw new ArgumentException("Field mistakes of a player must be a number!");
            }
        }
    }
}
