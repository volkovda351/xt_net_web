using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._7_Array_processing
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
            int[] mas = new int[N];

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
                mas[i] = rnd.Next() % 1000;

            Console.WriteLine("Unsorted array");
            printMas(mas);

            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                max = (max < mas[i]) ? mas[i] : max;
                min = (min > mas[i]) ? mas[i] : min;
            }

            Console.WriteLine("Max = " + max);
            Console.WriteLine("Min = " + min);

            for (int i = 0; i < N; i++)
                for (int j = 1; j < N - i; j++)
                    if (mas[j - 1] > mas[j])
                    {
                        int temp = mas[j - 1];
                        mas[j - 1] = mas[j];
                        mas[j] = temp;
                    }

            Console.WriteLine("Sorted array");
            printMas(mas);
        }
    }
}
