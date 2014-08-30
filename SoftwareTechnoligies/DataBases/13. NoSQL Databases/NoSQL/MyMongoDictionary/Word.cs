using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDictionary
{
    public class Word
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string TheWord { get; set; }

        public string Meaning { get; set; }

        [BsonConstructor]
        public Word(string theWord, string meaning)
        {
            this.TheWord = theWord;
            this.Meaning = meaning;
        }

        public override string ToString()
        {
            return string.Format("{0}:\t{1}", this.TheWord, this.Meaning);
        }
    }
}
