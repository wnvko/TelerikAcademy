namespace MyRedisDictionary
{
    using System;
    using System.Collections.Generic;

    using ServiceStack.Redis;

    public sealed class ClientForRedis
    {
        private const string LogIn = "127.0.0.1:6379";

        private static ClientForRedis instance;
        
        private string dictionary = "MyDictionary";
        private RedisClient redisClient;

        private ClientForRedis()
        {
            this.redisClient = new RedisClient(LogIn);
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
            this.redisClient.HSet(
                this.dictionary, 
                this.ConvertStringToBytes(word),
                this.ConvertStringToBytes(meaning));
        }

        public string FindWord(string word)
        {
            string result = string.Empty;

            byte[] resultByte = this.redisClient.HGet(this.dictionary, this.ConvertStringToBytes(word));
            if (resultByte != null)
            {
                result = this.ConvertBytesToString(resultByte);
            }

            return result;
        }

        public SortedDictionary<string, string> ListAllWords()
        {
            SortedDictionary<string, string> allWords = new SortedDictionary<string, string>();

            byte[][] allWordsBytes = this.redisClient.HGetAll(this.dictionary);

            for (int i = 0; i < allWordsBytes.Length; i++)
            {
                string word = this.ConvertBytesToString(allWordsBytes[i]);
                string meaning = this.ConvertBytesToString(allWordsBytes[++i]);

                allWords[word] = meaning;
            }

            return allWords;
        }

        // Thanks Stack overflow for next two methods 
        private byte[] ConvertStringToBytes(string text)
        {
            byte[] bytes = new byte[text.Length * sizeof(char)];
            Buffer.BlockCopy(text.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private string ConvertBytesToString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
