namespace Carpets
{
    using System;

    class Carpets
    {
        static void Main()
        {
            int sizeOfCarpet = int.Parse(Console.ReadLine());
            sizeOfCarpet /= 2;

            //upper part
            for (int i = 0; i < sizeOfCarpet; i++)
            {
                string leftString = "";
                string rightString = "";
                leftString = leftString + (new string('.', (sizeOfCarpet - i - 1)));
                for (int j = 0; j <= i; j++)
                {
                    if (j % 2 == 0)
                    {
                        leftString = leftString + "/";
                    }
                    else
                    {
                        leftString = leftString + " ";
                    }
                }
                for (int j = i; j >= 0; j--)
                {
                    if (j % 2 == 0)
                    {
                        rightString = rightString + "\\";
                    }
                    else
                    {
                        rightString = rightString + " ";
                    }
                }
                rightString = rightString + (new string('.', (sizeOfCarpet - i - 1)));
                Console.WriteLine(leftString + rightString);
            }

            //lower part
            for (int i = sizeOfCarpet - 1; i >= 0; i--)
            {
                string leftString = "";
                string rightString = "";
                leftString = leftString + (new string('.', (sizeOfCarpet - i - 1)));
                for (int j = 0; j <= i; j++)
                {
                    if (j % 2 == 0)
                    {
                        leftString = leftString + "\\";
                    }
                    else
                    {
                        leftString = leftString + " ";
                    }
                }
                for (int j = i; j >= 0; j--)
                {
                    if (j % 2 == 0)
                    {
                        rightString = rightString + "/";
                    }
                    else
                    {
                        rightString = rightString + " ";
                    }
                }
                rightString = rightString + (new string('.', (sizeOfCarpet - i - 1)));
                Console.WriteLine(leftString + rightString);
            }
        }
    }
}