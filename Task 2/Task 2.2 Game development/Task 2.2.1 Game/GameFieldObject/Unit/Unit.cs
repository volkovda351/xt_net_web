using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Unit
{
	public abstract class Unit : GameFieldObject
	{
		public Unit(Point position) : base(position)
		{
			IsPassable = false;
		}

		public abstract Point ToMove();
	}
}
