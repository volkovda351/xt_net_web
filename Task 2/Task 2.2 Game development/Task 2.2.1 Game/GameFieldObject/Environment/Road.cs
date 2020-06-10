using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Environment
{
	public class Road : Environment
	{
		public Road(Point position) : base(position)
		{
			Name = ' ';
			IsPassable = true;
		}
	}
}
