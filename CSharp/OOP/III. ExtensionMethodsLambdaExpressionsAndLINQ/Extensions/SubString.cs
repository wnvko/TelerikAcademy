/*
 * Implement an extension method Substring(int index, int length) for the
 * class StringBuilder that returns new StringBuilder and has the same
 * functionality as Substring in the class String.
 */

namespace ExtensionsNamespace
{
    using System;
    using System.Text;

    public static class Extension
    {
        public static StringBuilder SubString(this StringBuilder input, int index, int lenght)
        {
            string tempContainer = input.ToString().Substring(index, lenght);

            StringBuilder result = new StringBuilder(tempContainer);
            return result;
        }
    }
}
