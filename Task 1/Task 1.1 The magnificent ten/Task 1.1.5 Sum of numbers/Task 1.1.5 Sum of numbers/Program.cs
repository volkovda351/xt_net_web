﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._5_Sum_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            for (int i = 0; i < 1000; i++)
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;

            Console.WriteLine("Sum = " + sum);
        }
    }
}
