using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._1_Averages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string s = Console.ReadLine();

            int cntChar = 0;
            int cntWord = 0;
            bool isSameWord = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    cntChar++;

                    if (!isSameWord)
                    {
                        cntWord++;
                        isSameWord = true;
                    }
                }
                else
                {
                    isSameWord = false;
                }
            }

            Console.WriteLine((double)cntChar / cntWord); // double output
        }
    }
}
