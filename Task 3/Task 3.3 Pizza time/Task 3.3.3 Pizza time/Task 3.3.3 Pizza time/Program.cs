using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3_Pizza_time
{
	class Program
	{
		static void Main(string[] args)
		{
			Pizzeria donna = new Pizzeria();
			User user = new User("Andrey");
			User user1 = new User("Kate");

			user.Order(donna, Pizzeria.Pizza.Hawaiian);
			user1.Order(donna, Pizzeria.Pizza.Neapolitan);
		}
	}
}
