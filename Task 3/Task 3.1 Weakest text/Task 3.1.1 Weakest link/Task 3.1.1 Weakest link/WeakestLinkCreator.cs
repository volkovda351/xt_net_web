using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._1_Weakest_link
{
	public static class WeakestLinkCreator
	{
		public static WeakestLink CreateWeakestLink()
		{
			while (true)
			{
				try
				{
					int N = 0;
					bool successInputN = false;

					while (!successInputN)
					{
						Console.WriteLine("Введите N");
						successInputN = int.TryParse(Console.ReadLine(), out N);
					}

					int M = 0;
					bool successInputM = false;

					while (!successInputM)
					{
						Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
						successInputM = int.TryParse(Console.ReadLine(), out M);
					}

					return new WeakestLink(N, M);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Попробуйте снова");
				}
			}
		}
	}
}
