/*
 * Write a program that encodes and decodes a string using given encryption key (cipher).
 * The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter
 * of the string with the first of the key, the second – with the second, etc. When the last key
 * character is reached, the next is the first.
 */

using System;
using System.Collections.Generic;
using System.Text;

public class EncodeDecode
{
    public static void Main()
    {
        string textToEncrypt = TakeUserInput("Enter text to encrypt: ");
        string cipher = TakeUserInput("Enter cipher:");
        List<int> encryptedText = Encode(textToEncrypt, cipher);
        string decryptedText = Decode(encryptedText, cipher);
        Console.WriteLine("Encrypted text:");
        PrintListOfIntAsChars(encryptedText);
        Console.WriteLine("Decrypted text:");
        Console.WriteLine(decryptedText);
    }

    public static string TakeUserInput(string inputString)
    {
        Console.WriteLine(inputString);
        string input = Console.ReadLine();
        return input;
    }

    public static List<int> Encode(string inputText, string cipher)
    {
        List<int> encodedText = new List<int>();
        for (int index = 0; index < inputText.Length; index++)
        {
            int cipherIndex = index % cipher.Length;
            encodedText.Add((int)inputText[index] ^ (int)cipher[cipherIndex]);
        }

        return encodedText;
    }

    public static string Decode(List<int> inputText, string cipher)
    {
        StringBuilder decodedText = new StringBuilder();
        for (int index = 0; index < inputText.Count; index++)
        {
            int cipherIndex = index % cipher.Length;
            decodedText.Append((char)(inputText[index] ^ (int)cipher[cipherIndex]));
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
}
