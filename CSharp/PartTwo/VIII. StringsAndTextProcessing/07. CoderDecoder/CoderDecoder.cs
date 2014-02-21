/*
 * Write a program that encodes and decodes a string using given
 * encryption key (cipher). The key consists of a sequence of
 * characters. The encoding/decoding is done by performing XOR
 * (exclusive or) operation over the first letter of the string
 * with the first of the key, the second – with the second, etc.
 * When the last key character is reached, the next is the first.
 */

namespace CoderDecoder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CoderDecoder
    {
        public static string TakeUserInput(string inputString)
        {
            Console.WriteLine(inputString);
            string userExpression = Console.ReadLine();
            return userExpression;
        }

        public static List<int> EncodingTextWithCipher(string inputText, string cipher)
        {
            List<int> encodedText = new List<int>();
            for (int counter = 0; counter < inputText.Length; counter++)
            {
                for (int cipherChar = 0; cipherChar < cipher.Length; cipherChar++)
                {
                    int textCurrentChar = (counter * cipher.Length) + cipherChar;
                    if (textCurrentChar < inputText.Length)
                    {
                        encodedText.Add((int)inputText[textCurrentChar] ^ (int)cipher[cipherChar]);
                    }
                    else
                    {
                        return encodedText;
                    }
                }
            }

            return encodedText;
        }

        public static string DecodingTextWithCipher(List<int> inputText, string cipher)
        {
            StringBuilder decodedText = new StringBuilder();
            for (int counter = 0; counter < inputText.Count; counter++)
            {
                for (int cipherChar = 0; cipherChar < cipher.Length; cipherChar++)
                {
                    int textCurrentChar = (counter * cipher.Length) + cipherChar;
                    if (textCurrentChar < inputText.Count)
                    {
                        decodedText.Append((char)(inputText[textCurrentChar] ^ (int)cipher[cipherChar]));
                    }
                    else
                    {
                        return decodedText.ToString();
                    }
                }
            }

            return decodedText.ToString();
        }

        public static void PrintListOfIntAsChars(List<int> inputList)
        {
            Console.WriteLine();
            for (int count = 0; count < inputList.Count; count++)
            {
                Console.Write((char)inputList[count]);
            }

            Console.WriteLine();
        }

        public static void Main()
        {
            string textToEncrypt = TakeUserInput("Enter text to encrypt: ");
            string cipher = TakeUserInput("Enter cipher:");
            List<int> encryptedText = EncodingTextWithCipher(textToEncrypt, cipher);
            string decryptedText = DecodingTextWithCipher(encryptedText, cipher);
            Console.WriteLine("Encrypted text:");
            PrintListOfIntAsChars(encryptedText);
            Console.WriteLine("Decrypted text:");
            Console.WriteLine(decryptedText);
        }
    }
}