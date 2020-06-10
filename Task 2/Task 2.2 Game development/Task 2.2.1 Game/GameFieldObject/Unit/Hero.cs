using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Unit
{
	public class Hero : Unit
	{
		private int _lifes;
		private int _points;

		public Hero(Point position) : base(position)
		{
			Lifes = 1;
			Points = 0;
			Name = 'P';
		}

		public int Lifes
		{
			get
			{
				return _lifes;
			}
			set
			{
				_lifes = value;
			}
		}
		public int Points
		{
			get
			{
				return _points;
			}
			set
			{
				_points = value;
			}
		}

		public void AddBonus(int lifes, int points)
		{
			Lifes += lifes;
			Points += points;
		}
		public override Point ToMove()
		{
			char.TryParse(Console.ReadLine(), out char choose);

			switch (choose)
			{
				case 'w':
				case 'W':
					return Position.UpperPoint;
				case 'a':
				case 'A':
					return Position.LeftPoint;
				case 's':
				case 'S':
					return Position.LowerPoint;
				case 'd':
				case 'D':
					return Position.RightPoint;
				default:
					throw new Exception("Введено некорректное направление движения");
			}
		}
	}
}
