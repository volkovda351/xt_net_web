﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Bonus
{
	public class BonusLife : Bonus
	{
		public BonusLife(Point position) : base(position)
		{
			BonusLifes = 1;
			BonusPoints = 0;
		}
	}
}
