using System;

class RowOfNumbers
{
    static void Main()
    {
        /*
         * Write a program that prints the first 10 members
         * of the sequence: 2, -3, 4, -5, 6, -7, ...
         */
        
        
        //this is the new version
        int signChanger = 1;
        for (int i = 2; i < 12; i++)
        {
            Console.WriteLine(i*signChanger);
            signChanger*=-1;
        }


        /*
        This was old version with slow Math.Pow function
         
         
        for (int i = 2; i < 12; i++)
        {
            Console.WriteLine(i*Math.Pow(-1,i));
        }
        */

    }
}