using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3_Pizza_time
{
	public class User
	{
		private string _name;

		public User(string name)
		{
			Name = name;
		}

		public event Action<Pizzeria.Pizza> MakeOrder;

		public string Name
		{
			get
			{
				return _name;
			}
			private set
			{
				_name = value;
			}
		}

		public void Order(Pizzeria pizzeria, Pizzeria.Pizza pizza)
		{
			MakeOrder += pizzeria.NewOrder;
			pizzeria.GivePizza += GetPizza;

			MakeOrder?.Invoke(pizza);
		}

		public void GetPizza(Pizzeria.Pizza pizza)
		{
			Console.WriteLine($"{Name} has gave {pizza}");
		}

	}
}
