using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_2._2._1_Game
{
	public class GameField
	{
		private int _height;
		private int _width;
		private List<GameFieldObject.Environment.Environment> _staticObjects;
		private List<GameFieldObject.Bonus.Bonus> _bonuses;
		private int _cntBonuses;
		private List<GameFieldObject.Unit.Enemy.Enemy> _enemies;
		private int _cntEnemies;
		private GameFieldObject.Unit.Hero _player;

		public GameField(int height, int width, int maxBonuses, int maxEnemies, List<GameFieldObject.Environment.Environment> staticObjects)
		{
			Height = height;
			Width = width;
			CntBonuses = maxBonuses;
			CntEnemies = maxEnemies;
			StaticObjects = staticObjects;

			Bonuses = new List<GameFieldObject.Bonus.Bonus>();
			FillBonuses();
			Thread.Sleep(15);
			Enemies = new List<GameFieldObject.Unit.Enemy.Enemy>();
			FillEnemies();

			CreateHero();
		}

		public int Height
		{
			get
			{
				return _height;
			}
			private set
			{
				if (value <= 0)
					throw new Exception("Высота карты должна быть положительной");
				else
					_height = value;
			}
		}
		public int Width
		{
			get
			{
				return _width;
			}
			private set
			{
				if (value <= 0)
					throw new Exception("Ширина должна быть положительной");
				else
					_width = value;
			}
		}
		public List<GameFieldObject.Environment.Environment> StaticObjects
		{
			get
			{
				return _staticObjects;
			}
			private set
			{
				_staticObjects = value;
			}
		}
		public List<GameFieldObject.Bonus.Bonus> Bonuses
		{
			get
			{
				return _bonuses;
			}
			set
			{
				_bonuses = value;
			}
		}
		public int CntBonuses
		{
			get
			{
				return _cntBonuses;
			}
			private set
			{
				if (value < 0)
					throw new Exception("Ограничение на количество бонусов не может быть отрицательным");
				else
					_cntBonuses = value;
			}
		}
		public List<GameFieldObject.Unit.Enemy.Enemy> Enemies
		{
			get
			{
				return _enemies;
			}
			set
			{
				_enemies = value;
			}
		}
		public int CntEnemies
		{
			get
			{
				return _cntEnemies;
			}
			private set
			{
				if (value < 0)
					throw new Exception("Ограничение на количество противников не может быть отрицательным");
				else
					_cntEnemies = value;
			}
		}
		public GameFieldObject.Unit.Hero Player
		{
			get
			{
				return _player;
			}
			set
			{
				_player = value;
			}
		}
		public char[] Print
		{
			get
			{
				char[] result = new char[Height * Width + Height];

				foreach (var item in StaticObjects)
					result[item.Position.Y * (Width + 1) + item.Position.X] = item.Name;

				foreach (var item in Bonuses)
					result[item.Position.Y * (Width + 1) + item.Position.X] = item.Name;

				foreach (var item in Enemies)
					result[item.Position.Y * (Width + 1) + item.Position.X] = item.Name;

				result[Player.Position.Y * (Width + 1) + Player.Position.X] = Player.Name;

				for (int i = 0; i < Height; i++)
					result[Width + i * (Width + 1)] = '\n';

				return result;
			}
		}

		public bool IsFreePosition(Point position, bool isBot)
		{
			if (isBot)
			{
				foreach (var item in Enemies)
					if (item.Position == position)
						return false;
			}

			foreach (var item in StaticObjects)
			{
				if (item.Position == position)
				{
					if (item.IsPassable)
						return true;
					else
						return false;
				}
			}

			throw new Exception("Такой позиции нет на карте");
		}

		public void NextTurn()
		{
			foreach (var item in Enemies)
			{
				Point position = item.ToMove();

				if (IsFreePosition(position, true))
					item.Position = position;
				else
					item.Position = item.Position;
			}

			while (true)
			{
				try
				{
					Point playerPosition = Player.ToMove();

					if (IsFreePosition(playerPosition, false))
						Player.Position = playerPosition;

					break;
				}
				catch
				{
					continue;
				}
			}

		}
		public void FillBonuses()
		{
			Random random = new Random();

			while (Bonuses.Count < CntBonuses)
			{
				Point position = new Point(random.Next(0, Width), random.Next(0, Height));

				if (IsFreePosition(position, false))
				{
					double chance = random.NextDouble();

					if (chance < 0.05)
						Bonuses.Add(new GameFieldObject.Bonus.SuperBonus(position));
					else if (chance < 0.25)
						Bonuses.Add(new GameFieldObject.Bonus.BonusLife(position));
					else
						Bonuses.Add(new GameFieldObject.Bonus.BonusPoints(position));
				}
			}
		}
		public void FillEnemies()
		{
			Random random = new Random();

			while (Enemies.Count < CntEnemies)
			{
				Point position = new Point(random.Next(0, Width), random.Next(0, Height));

				if (IsFreePosition(position, true))
				{
					double chance = random.NextDouble();

					if (chance < 0.5)
						Enemies.Add(new GameFieldObject.Unit.Enemy.Alcoholic(position));
					else
						Enemies.Add(new GameFieldObject.Unit.Enemy.Biker(position));
				}
			}
		}
		public void CreateHero()
		{
			Random random = new Random();

			while (true)
			{
				Point position = new Point(random.Next(0, Width), random.Next(0, Height));

				if (IsFreePosition(position, true))
				{
					Player = new GameFieldObject.Unit.Hero(position);
					return;
				}
			}
		}
	}
}
