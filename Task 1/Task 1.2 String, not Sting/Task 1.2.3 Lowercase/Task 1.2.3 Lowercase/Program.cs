using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._3_Lowercase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string s = Console.ReadLine();

            int cnt = 0;

            bool isSameWord = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (isSameWord)
                {
                    if (char.IsLetter(s[i]))
                        continue;
                    else
                        isSameWord = false;
                }
                else
                {
                    if (char.IsLetter(s[i]))
                    {
                        if (char.IsLower(s[i]))
                            cnt++;

                        isSameWord = true;
                    }
                }
            }

            Console.WriteLine(cnt);
        }
    }
}
