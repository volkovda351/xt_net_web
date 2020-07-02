using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3_Pizza_time
{
	public class Pizzeria
	{
		public Pizzeria() { }

		public Action<Pizza> GivePizza;

		public void NewOrder(Pizza pizza)
		{
			Console.WriteLine("Accept the order!");
			GivePizza?.Invoke(pizza);

		}
		public enum Pizza
		{
			None,
			FourSeasons,
			Hawaiian,
			Capricccioso,
			Calzone,
			Neapolitan,
			Sicilian,
			Margarita
		}
	}
}
