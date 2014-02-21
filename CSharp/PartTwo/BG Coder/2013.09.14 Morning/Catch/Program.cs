using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catch
{

    class Program
    {
        static void Main(string[] args)
        {
            string test = string.Empty;
            test = Console.ReadLine();
            throw new System.ArgumentException(test);
        }
    }
}