using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisDictionary
{
    public sealed class ClientForRedis
    {
        private const string LogIn = "127.0.0.1:6379";
        private string myDictionary = "MyDictionary";
        private RedisClient myRedisClient;

        private static ClientForRedis instance;

        private ClientForRedis()
        {
            this.myRedisClient = new RedisClient(LogIn);
        }

        public static ClientForRedis Instance()
        {
            if (instance == null)
            {
                instance = new ClientForRedis();
            }

            return instance;
        }

        public void AddWord(string word, string meaning)
        {
            this.myRedisClient.HSet(myDictionary, GetBytes(word), GetBytes(meaning));
        }

        public string FindWord(string word)
        {
            string result = string.Empty;

            byte[] resultByte = this.myRedisClient.HGet(myDictionary, GetBytes(word));
            if (resultByte != null)
            {
                result = GetString(resultByte);
            }


            return result;
        }

        public SortedDictionary<string, string> ListAllWords()
        {
            SortedDictionary<string, string> allWords = new SortedDictionary<string, string>();

            byte[][] allWordsBytes = this.myRedisClient.HGetAll(myDictionary);

            for (int i = 0; i < allWordsBytes.Length; i++)
            {
                string word = GetString(allWordsBytes[i]);
                string meaning = GetString(allWordsBytes[++i]);

                allWords[word] = meaning;
            }

            return allWords;
        }

        // Thanks Stackoverflow for next two methods 
        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
