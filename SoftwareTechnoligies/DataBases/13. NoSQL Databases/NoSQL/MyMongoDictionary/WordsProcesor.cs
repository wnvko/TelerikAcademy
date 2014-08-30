using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

namespace MyMongoDictionary
{
    public class WordsProcesor
    {
        private const string ConnectionSring = "mongodb://localhost/";
        private const string DataBaseName = "MyDictionaryDb";
        private const string CollectionName = "MyDictionaryCollection";

        private MongoClient myMongoClient;
        private MongoServer myMongoServer;
        private MongoDatabase myDictionary;
        private MongoCollection myWords;

        internal void Start()
        {
            myMongoClient = new MongoClient(ConnectionSring);
            myMongoServer = myMongoClient.GetServer();
            myDictionary = myMongoServer.GetDatabase(DataBaseName);
            myWords = myDictionary.GetCollection(CollectionName);

            bool working = true;

            while (working)
            {
                Console.Write("Please choose a command Add, Search, List or End: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Add":
                        {
                            Console.Write("\n Enter new word: ");
                            string word = Console.ReadLine();

                            Console.Write("\n Enter the meaning of {0}: ", word);
                            string meaning = Console.ReadLine();

                            Add(word, meaning);
                            break;
                        }
                    case "Search":
                        {
                            Console.Write("\n Enter a word to look for: ");
                            string word = Console.ReadLine();

                            FindAndPrintWord(word);
                            break;
                        }
                    case "List":
                        {
                            ListAllWords();
                            break;
                        }
                    case "End":
                        {
                            Console.WriteLine("Good buy!");
                            working = false;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void Add(string word, string meaning)
        {
            Word currentWord = new Word(word, meaning);
            myWords.Insert(currentWord);
        }

        private void FindAndPrintWord(string word)
        {
            IMongoQuery queryMeanings = Query.EQ("TheWord", word);
            var meanings = myWords.FindAs<Word>(queryMeanings);

            if (meanings.Count() > 0)
            {
                foreach (var meaning in meanings)
                {
                    Console.WriteLine(meaning);
                }
            }
            else
            {
                Console.WriteLine("The word {0} is not found!", word);
            }
        }

        private void ListAllWords()
        {
            var meanings = myWords.FindAllAs<Word>();

            if (meanings.Count() > 0)
            {
                foreach (var meaning in meanings)
                {
                    Console.WriteLine(meaning);
                }
            }
            else
            {
                Console.WriteLine("The dictionary is empty! Use Add to add some words.");
            }
        }

    }
}