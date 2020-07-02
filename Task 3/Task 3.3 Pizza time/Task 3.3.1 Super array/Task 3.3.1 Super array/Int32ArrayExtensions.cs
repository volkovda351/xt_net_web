using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task_3._3._1_Super_array
{
	static public class Int32ArrayExtensions
	{
		public static double[] ModifyArrayElements(this double[] mass, Func<double, double> modification)
		{
			if (mass == null || mass.Length == 0)
				throw new ArgumentException("'mass' argument cannot be null or empty");

			double[] result = new double[mass.Length];

			for (int i = 0; i < mass.Length; i++)
				result[i] = modification(mass[i]);

			return result;
		}
		public static double SumOfElements(this double[] mass)
		{
			if (mass == null)
				throw new ArgumentException("'mass' argument cannot be null or empty");

			double result = 0;

			foreach (var item in mass)
				result += item;

			return result;
		}
		public static double AverageValueOfElements(this double[] mass)
		{
			if (mass == null || mass.Length == 0)
				throw new ArgumentException("'mass' argument cannot be null or empty");

			double result = mass.SumOfElements() / mass.Length;

			return result;
		}
		public static double MostPopularValueOfElements(this double[] mass)
		{
			if (mass == null || mass.Length == 0)
				throw new ArgumentException("'mass' argument cannot be null or empty");

			List<double> temp = new List<double>(mass);
			temp.Sort();

			int currentCount = 0;
			double currentValue = temp[0];
			int maxCount = 0;
			double resultValue = temp[0];

			foreach (var item in temp)
			{
				if (Abs(item - currentValue) < 0.00001)
				{
					currentCount++;
				}
				else
				{
					currentCount = 1;
					currentValue = item;
				}

				if (currentCount > maxCount)
				{
					maxCount = currentCount;
					resultValue = currentValue;
				}
			}

			return resultValue;
		}
	}
}
