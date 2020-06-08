using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._1_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;

            Console.WriteLine("Enter positive integer A");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter positive integer B");
            b = Convert.ToInt32(Console.ReadLine());

            if (a <= 0 || b <= 0)
                Console.WriteLine("Error!");
            else
                Console.WriteLine("Area of rectangle = " + (a * b));
        }
    }
}
