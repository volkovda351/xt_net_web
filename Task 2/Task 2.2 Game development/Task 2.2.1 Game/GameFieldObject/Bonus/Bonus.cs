using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Bonus
{
	public abstract class Bonus : GameFieldObject
	{
		private int _bonusLifes;
		private int _bonusPoints;

		public Bonus(Point position) : base(position)
		{
			IsPassable = true;
			Name = '*';
		}

		public int BonusLifes
		{
			get
			{
				return _bonusLifes;
			}
			set
			{
				_bonusLifes = value;
			}
		}
		public int BonusPoints
		{
			get
			{
				return _bonusPoints;
			}
			set
			{
				_bonusPoints = value;
			}
		}
	}
}
