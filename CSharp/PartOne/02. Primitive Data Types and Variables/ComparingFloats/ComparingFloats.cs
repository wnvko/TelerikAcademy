namespace ComparingFloats
{
    using System;

    public class ComparingFloats
    {
        public static void Main(string[] args)
        {
            float firstNumber = 5.3f;
            float secondNumber = 6.0f;
            float thitdNumber = 5.3000001f;
            bool result = firstNumber == secondNumber;
            Console.WriteLine("5.3 = 6 -> {0}", result);
            result = firstNumber == thitdNumber;
            Console.WriteLine("5.3 = 5.3000001 -> {0}", result);
        }
    }
}
