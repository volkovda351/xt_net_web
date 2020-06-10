using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Unit.Enemy
{
	public abstract class Enemy : Unit
	{
		private int _hit;

		public Enemy(Point position) : base(position) { }

		public int Hit
		{
			get
			{
				return _hit;
			}
			set
			{
				if (value <= 0)
					throw new Exception("Сила удара должна быть положительной");
				else
					_hit = value;
			}
		}
	}
}
