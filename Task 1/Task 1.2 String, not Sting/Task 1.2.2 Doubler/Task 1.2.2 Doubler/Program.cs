using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._2_Doubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string s1");
            string s1 = Console.ReadLine();

            Console.WriteLine("Enter a string s2");
            string s2 = Console.ReadLine();

            for (int i = 0; i < s1.Length; i++)
                if (s2.Contains(s1.Substring(i, 1)))
                    Console.Write("{0}{0}", s1[i]);
                else
                    Console.Write(s1[i]);

            Console.WriteLine();
        }
    }
}
