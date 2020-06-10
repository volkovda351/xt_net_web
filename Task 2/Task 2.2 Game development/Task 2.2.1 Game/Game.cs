using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1_Game
{
	public class Game
	{
		private GameField _field;

		public Game()
		{
			Field = GameFieldCreator.Square(2);
			_run();
		}
		public GameField Field
		{
			get
			{
				return _field;
			}
			set
			{
				_field = value;
			}
		}

		private void _run()
		{
			Console.WriteLine("S - непроходимые скалы" + Environment.NewLine +
							"T - непроходимые деревья" + Environment.NewLine +
							"A - алкаши (сила удара 1)" + Environment.NewLine +
							"B - велосипедисты (сила удара 2)" + Environment.NewLine +
							"Пережитое столкновение с врагом добавит бонусных очков" + Environment.NewLine +
							"* - бонусы" + Environment.NewLine +
							"P - ваш герой" + Environment.NewLine +
							"Ход осуществляется вводом направления движения" + Environment.NewLine +
							"[W] - вверх, [A] - влево, [S] - вниз, [D] - вправо");
			Console.ReadLine();
			Console.Clear();

			while (true)
			{
				_toPrint(0, 0, $"Жизни: {Field.Player.Lifes}");
				_toPrint(0, 1, $"Очки: {Field.Player.Points}");
				_toPrint(0, 2, Field.Print);
				Field.NextTurn();

				_addBonuses();
				_hitHero();

				if (Field.Player.Lifes <= 0 || Field.Bonuses.Count == 0)
				{
					Console.Clear();
					Console.WriteLine($"Игра закончена, ваш результат {Field.Player.Points}");
					return;
				}
			}
		}

		private void _toPrint(int x, int y, char[] charArr)
		{
			Console.SetCursorPosition(x, y);

			for (int i = 0; i < charArr.Length; i++)
			{
				if (charArr[i] == '\n')
				{
					y++;
					Console.SetCursorPosition(x, y);
				}
				else
				{
					Console.Write(charArr[i]);
				}
			}
		}
		private void _toPrint(int x, int y, string s)
		{
			_toPrint(x, y, s.ToCharArray());
		}
		private void _addBonuses()
		{
			foreach (var item in Field.Bonuses)
			{
				if (item.Position == Field.Player.Position)
				{
					Field.Player.AddBonus(item.BonusLifes, item.BonusPoints);

					Random random = new Random();
					Field.Bonuses.Remove(item);
					Field.FillBonuses();
					return;
				}
			}
		}
		private void _hitHero()
		{
			foreach (var item in Field.Enemies)
			{
				if (item.Position == Field.Player.Position)
				{
					Field.Player.Lifes -= item.Hit;

					if (Field.Player.Lifes > 0)
						Field.Player.AddBonus(0, 100);

					Field.Enemies.Remove(item);
					Field.FillEnemies();
					return;
				}
			}
		}
	}
}
