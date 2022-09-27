using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @if
{
    internal class Program
    {
        static void Main(string[] args)
        {





            if (Asal(67+1))
            {
                Console.WriteLine("ASAL");
            }
            else
            {
                Console.WriteLine("ASAL DEĞİL");
            }

            Console.ReadLine();







        }


        private static bool Asal(int number) //71
        {
            bool result = true;

            for (int i = 2; i <= number-1; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    i = number-1;
                }
                else if (number == 2)
                {
                    result = true;
                } 
              
            }
            return result;
        }











    }
}

