using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Environment
{
	public class Stone : Environment
	{
		public Stone(Point position) : base(position)
		{
			Name = 'S';
			IsPassable = false;
		}
	}
}
