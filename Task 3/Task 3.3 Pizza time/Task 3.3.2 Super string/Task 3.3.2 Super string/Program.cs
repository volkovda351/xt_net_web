using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._2_Super_string
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = "Украина";
			Console.WriteLine(s.GetLanguage());

			string s1 = "Ukraine";
			Console.WriteLine(s1.GetLanguage());

			string s2 = "Україна";
			Console.WriteLine(s2.GetLanguage());

			string s3 = "2020";
			Console.WriteLine(s3.GetLanguage());
		}
	}
}
