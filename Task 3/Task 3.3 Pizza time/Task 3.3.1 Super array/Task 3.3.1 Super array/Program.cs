using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._1_Super_array
{
	class Program
	{
		static void Main(string[] args)
		{
			double[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 3 };

			mass = mass.ModifyArrayElements(a => a * a);
			
			foreach (var item in mass)
				Console.WriteLine(item);

			Console.WriteLine(mass.SumOfElements());
			Console.WriteLine(mass.AverageValueOfElements());
			Console.WriteLine(mass.MostPopularValueOfElements());
		}
	}
}
