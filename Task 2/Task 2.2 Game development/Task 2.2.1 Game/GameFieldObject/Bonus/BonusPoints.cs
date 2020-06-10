using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Bonus
{
	public class BonusPoints : Bonus
	{
		public BonusPoints(Point position) : base(position)
		{
			BonusLifes = 0;
			BonusPoints = 100;
		}
	}
}
