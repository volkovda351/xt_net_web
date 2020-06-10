using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStringLib;

namespace Task_2._1._1_Custom_string
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myStr1 = new MyString("Better safe than sorry.");
            Console.WriteLine(myStr1);

            MyString myStr2 = new MyString("Live and learn.");
            Console.WriteLine(myStr2);

            Console.WriteLine(myStr1 + myStr2);

            MyString myStr3 = new MyString("Press F\n");
            Console.WriteLine(myStr3 * 10);

            MyString myStr4 = new MyString("We are ");
            myStr4.Append("the champions");
            Console.WriteLine(myStr4);

            MyString myStr5 = new MyString("Goodday");
            myStr5.Insert(' ', 4);
            Console.WriteLine(myStr5);

            MyString myStr6 = new MyString("hay ");
            myStr6.Repeat(100000);
            myStr6.Insert("needle ", 32768);
            Console.WriteLine(myStr6.Find("n"));

            myStr6.Remove("hay ");
            Console.WriteLine(myStr6);

            MyString myStr7 = new MyString("abcd");
            myStr7.Reverse();
            Console.WriteLine(myStr7);

            MyString myStr8 = new MyString("0123456789");
            myStr8.RandomShuffle();
            Console.WriteLine(myStr8);

            MyString myStr9 = new MyString("Python!");
            Console.WriteLine(myStr9[-1]);
        }
    }
}
