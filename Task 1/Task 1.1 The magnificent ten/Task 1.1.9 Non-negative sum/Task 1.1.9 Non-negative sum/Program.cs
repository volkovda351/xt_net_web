using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._9_Non_negative_sum
{
    class Program
    {
        const int N = 25;

        static void printMas(int[] mas)
        {
            for (int i = 0; i < N; i++)
                Console.Write(mas[i] + " ");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[] mas = new int[N];

            for (int i = 0; i < N; i++)
                mas[i] = rnd.Next(-1000, 1000);

            Console.WriteLine("Array");
            printMas(mas);

            int sum = 0;

            for (int i = 0; i < N; i++)
                if (mas[i] > 0)
                    sum += mas[i];

            Console.WriteLine("Sum = " + sum);
        }
    }
}
