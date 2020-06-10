using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game
{
	public class Point
	{
		private int _x;
		private int _y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X
		{
			get
			{
				return _x;
			}
			set
			{
				if (value < 0)
					throw new Exception("Абсцисса не может быть отрицательной");
				else
					_x = value;
			}
		}
		public int Y
		{
			get
			{
				return _y;
			}
			set
			{
				if (value < 0)
					throw new Exception("Ордината не может быть отрицательной");
				else
					_y = value;
			}
		}

		public Point UpperPoint
		{
			get
			{
				return new Point(X, Y - 1);
			}
		}
		public Point RightPoint
		{
			get
			{
				return new Point(X + 1, Y);
			}
		}
		public Point LowerPoint
		{
			get
			{
				return new Point(X, Y + 1);
			}
		}
		public Point LeftPoint
		{
			get
			{
				return new Point(X - 1, Y);
			}
		}

		public static bool operator ==(Point p1, Point p2)
		{
			return p1.X == p2.X && p1.Y == p2.Y;
		}
		public static bool operator !=(Point p1, Point p2)
		{
			return !(p1 == p2);
		}
	}
}
