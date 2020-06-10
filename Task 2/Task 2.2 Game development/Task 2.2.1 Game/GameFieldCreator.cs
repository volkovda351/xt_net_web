using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game
{
	public static class GameFieldCreator
	{
		public static GameField Square(int scale)
		{
			int side = 10 * scale;

			List<GameFieldObject.Environment.Environment> staticObjects = new List<GameFieldObject.Environment.Environment>();

			for (int i = 0; i < side; i++)
			{
				for (int j = 0; j < side; j++)
				{
					if (i == 0 || j == 0 || i == side - 1 || j == side - 1)
					{
						staticObjects.Add(new GameFieldObject.Environment.Stone(new Point(i, j)));
					}
					else
					{
						staticObjects.Add(new GameFieldObject.Environment.Road(new Point(i, j)));
					}
				}
			}

			return new GameField(side, side, scale * scale, scale * scale, staticObjects);
		}
	}
}
