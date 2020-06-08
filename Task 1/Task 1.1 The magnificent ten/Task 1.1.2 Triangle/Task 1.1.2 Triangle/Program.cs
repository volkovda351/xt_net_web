using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._2_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter positive integer N");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write('*');

                Console.WriteLine();
            }
        }
    }
}
