using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Unit.Enemy
{
	public class Alcoholic : Enemy
	{
		public Alcoholic(Point position) : base(position)
		{
			Hit = 1;
			Name = 'A';
		}

		public override Point ToMove()
		{
			Random random = new Random();
			int choose = random.Next(0, 5);

			switch (choose)
			{
				case 0:
					return Position.UpperPoint;
				case 1:
					return Position.RightPoint;
				case 2:
					return Position.LowerPoint;
				case 3:
					return Position.LeftPoint;
				case 4:
					return Position;
				default:
					throw new Exception("Сторона движения не определена");
			}
		}
	}
}
