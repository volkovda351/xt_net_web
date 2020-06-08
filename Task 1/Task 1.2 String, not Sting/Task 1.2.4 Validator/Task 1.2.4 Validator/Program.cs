using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2._4_Validator
{
    class Program
    {
        const string separators = ".?!";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            StringBuilder s = new StringBuilder(Console.ReadLine());

            bool isSameSentence = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (isSameSentence)
                {
                    if (separators.Contains(s[i]))
                        isSameSentence = false;
                }
                else
                {
                    if (char.IsLetter(s[i]))
                    {
                        if (char.IsLower(s[i]))
                            s[i] = char.ToUpper(s[i]);
                            
                        isSameSentence = true;
                    }
                }
            }

            Console.WriteLine(s);
        }
    }
}
