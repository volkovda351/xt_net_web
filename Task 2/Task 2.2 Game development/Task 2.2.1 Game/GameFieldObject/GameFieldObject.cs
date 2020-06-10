using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game.GameFieldObject
{
	public abstract class GameFieldObject
	{
		private Point _position;
		private char _name;
		private bool _isPassable;

		public GameFieldObject(Point position)
		{
			Position = position;
		}

		public virtual Point Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}
		public char Name
		{
			get
			{
				return _name;
			}
			protected set
			{
				_name = value;
			}
		}
		public bool IsPassable
		{
			get
			{
				return _isPassable;
			}
			protected set
			{
				_isPassable = value;
			}
		}
	}
}
