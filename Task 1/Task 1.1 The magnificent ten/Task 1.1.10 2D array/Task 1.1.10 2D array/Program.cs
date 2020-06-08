using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._10_2D_array
{
    class Program
    {
        const int N = 5;

        static void printMas(int[,] mas)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(mas[i, j] + " ");

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[,] mas = new int[N, N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    mas[i, j] = rnd.Next(1000);

            Console.WriteLine("Array");
            printMas(mas);

            int sum = 0;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if ((i + j) % 2 == 0)
                        sum += mas[i, j];

            Console.WriteLine("Sum = " + sum);
        }
    }
}
