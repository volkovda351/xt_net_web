using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._6_Font_adjustment
{
    class Program
    {
        [Flags]
        enum font
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        static void Main(string[] args)
        {
            font state = 0;
            
            while (true)
            {
                Console.WriteLine($"Параметры надписи: {state}");
                Console.WriteLine("Введите:");
                Console.WriteLine("\t1: bold");
                Console.WriteLine("\t2: italic");
                Console.WriteLine("\t3: underline");

                int n = Convert.ToInt32(Console.ReadLine());
                n = 1 << (n - 1); // convert 1 to 1, 2 to 2, 3 to 4, 4 to 8, 5 to 16 etc
                state ^= (font)n;
            }
        }
    }
}
