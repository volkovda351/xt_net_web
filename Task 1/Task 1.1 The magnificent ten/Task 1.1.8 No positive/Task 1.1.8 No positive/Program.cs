using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._8_No_positive
{
    class Program
    {
        const int N = 3;

        static void printMasInLine(int[,,] mas)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        Console.Write(mas[i, j, k] + " ");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[,,] mas = new int[N, N, N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        mas[i, j, k] = rnd.Next(-1000, 1000);

            Console.WriteLine("Before");
            printMasInLine(mas);

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        if (mas[i, j, k] > 0)
                            mas[i, j, k] = 0;

            Console.WriteLine("After");
            printMasInLine(mas);
        }
    }
}
