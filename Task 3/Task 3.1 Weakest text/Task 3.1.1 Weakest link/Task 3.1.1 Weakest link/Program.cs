using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._1_Weakest_link
{
	class Program
	{
		static void Main(string[] args)
		{
			WeakestLink game = WeakestLinkCreator.CreateWeakestLink();
			game.StartGame();
		}
	}
}
