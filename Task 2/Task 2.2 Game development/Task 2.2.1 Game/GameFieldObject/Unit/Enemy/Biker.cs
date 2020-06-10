using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject.Unit.Enemy
{
	public class Biker : Enemy
	{
		private Point _lastPosition;

		public Biker(Point position) : base(position)
		{
			Hit = 2;
			Name = 'B';
			LastPosition = position;
		}

		public override Point Position
		{
			get
			{
				return base.Position;
			}
			set
			{
				LastPosition = Position;
				base.Position = value;
			}
		}
		private Point LastPosition
		{
			get
			{
				return _lastPosition;
			}
			set
			{
				_lastPosition = value;
			}
		}

		public override Point ToMove()
		{
			if (LastPosition.X < Position.X)
				return Position.RightPoint;

			if (LastPosition.X > Position.X)
				return Position.LeftPoint;

			if (LastPosition.Y < Position.Y)
				return Position.LowerPoint;

			if (LastPosition.Y > Position.Y)
				return Position.UpperPoint;

			Random random = new Random();
			int choose = random.Next(0, 4);

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
				default:
					throw new Exception("Сторона движения не определена");
			}
		}
	}
}
