using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._1_Weakest_link
{
	public class WeakestLink
	{
		private int _n;
		private int _m;
		private LinkedList<Human> _humans;

		public WeakestLink(int n, int m)
		{
			N = n;
			M = m;

			Humans = new LinkedList<Human>();
			for (int i = 0; i < N; i++)
				Humans.AddLast(new Human());
		}

		public void StartGame()
		{
			var node = Humans.First;

			for (int i = 1; Humans.Count >= M; i++)
			{
				var oldNode = node;

				if (oldNode.Next == null)
					node = Humans.First;
				else
					node = oldNode.Next;

				if (i % M == 0)
				{
					Humans.Remove(oldNode);
					Console.WriteLine($"Раунд {i / M}. Вычеркнут человек. Людей осталось: {Humans.Count}");
				}
			}
		}
		public int N
		{
			get
			{
				return _n;
			}
			private set
			{
				if (value > 1)
					_n = value;
				else
					throw new ArgumentOutOfRangeException("N должно быть больше 1");
			}
		}
		public int M
		{
			get
			{
				return _m;
			}
			private set
			{
				if (value > 1)
					_m = value;
				else
					throw new ArgumentOutOfRangeException("M должно быть больше 1");
			}
		}
		public LinkedList<Human> Humans
		{
			get
			{
				return _humans;
			}
			private set
			{
				_humans = value;
			}
		}
	}
}
