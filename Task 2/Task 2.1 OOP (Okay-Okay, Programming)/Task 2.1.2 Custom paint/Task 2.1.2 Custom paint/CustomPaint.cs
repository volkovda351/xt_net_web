using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_2._1._2_Custom_paint
{
	static class CustomPaint
	{
		private static Dictionary<string, List<Shape>> _users = new Dictionary<string, List<Shape>>();
		private static string _currentUserName = null;

		private static Dictionary<string, List<Shape>> Users
		{
			get
			{
				return _users;
			}
			set
			{
				Users = value;
			}
		}
		private static string CurrentUserName
		{
			get
			{
				return _currentUserName;
			}
			set
			{
				if (Regex.IsMatch(value, @"[\w]{3,15}"))
					_currentUserName = value;
				else
					throw new ArgumentException("Value of username is invalid");
			}
		}

		public static void MainMenu()
		{
			while (true)
			{
				try
				{
					_setupCurrentUserName();

					Console.WriteLine($"{CurrentUserName}, выберите действие");
					Console.WriteLine("1. Добавить фигуру");
					Console.WriteLine("2. Вывести фигуры");
					Console.WriteLine("3. Очистить холст");
					Console.WriteLine("4. Сменить пользователя");
					Console.WriteLine("5. Выход");

					int.TryParse(Console.ReadLine(), out int choice);

					switch (choice)
					{
						case 1:
							_addShape();
							break;
						case 2:
							_printShapes();
							break;
						case 3:
							_clearAll();
							break;
						case 4:
							_currentUserName = "";
							break;
						case 5:
							return;
						default:
							break;
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message);
				}
			}
		}

		private static void _setupCurrentUserName()
		{
			while (CurrentUserName == null)
			{
				try
				{
					Console.WriteLine("Введите имя пользователя");
					CurrentUserName = Console.ReadLine();

					if (!_users.ContainsKey(CurrentUserName))
						Users.Add(CurrentUserName, new List<Shape>());
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message);
				}
			}
		}
		private static void _addShape()
		{
			try
			{
				Console.WriteLine($"{CurrentUserName}, выберите фигуру");
				Console.WriteLine("1. Круг");
				Console.WriteLine("2. Кольцо");
				Console.WriteLine("3. Прямоугольник");
				Console.WriteLine("4. Квадрат");
				Console.WriteLine("5. Треугольник");
				Console.WriteLine("6. Прямая");

				int.TryParse(Console.ReadLine(), out int choice);

				switch (choice)
				{
					case 1:
						DiscCreator discCreator = new DiscCreator();
						Users[CurrentUserName] = Users[CurrentUserName].Append(discCreator.CreateShape()).ToList();
						break;
					case 2:
						RingCreator ringCreator = new RingCreator();
						Users[CurrentUserName] = Users[CurrentUserName].Append(ringCreator.CreateShape()).ToList();
						break;
					case 3:
						RectangleCreator rectangleCreator = new RectangleCreator();
						Users[CurrentUserName] = Users[CurrentUserName].Append(rectangleCreator.CreateShape()).ToList();
						break;
					case 4:
						SquareCreator squareCreator = new SquareCreator();
						Users[CurrentUserName] = Users[CurrentUserName].Append(squareCreator.CreateShape()).ToList();
						break;
					case 5:
						TriangleCreator triangleCreator = new TriangleCreator();
						Users[CurrentUserName] = Users[CurrentUserName].Append(triangleCreator.CreateShape()).ToList();
						break;
					case 6:
						LineCreator lineCreator = new LineCreator();
						Users[CurrentUserName] = Users[CurrentUserName].Append(lineCreator.CreateShape()).ToList();
						break;
					default:
						throw new Exception("Ничего не выбрано");
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
		private static void _printShapes()
		{
			try
			{
				if (Users[CurrentUserName].Count() == 0)
				{
					Console.WriteLine("Список фигур пуст");
				}
				else
				{
					Console.WriteLine("Список фигур:");

					foreach (var item in Users[CurrentUserName])
						Console.WriteLine(item.ToString());
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
		private static void _clearAll()
		{
			Users[CurrentUserName].Clear();
			Console.WriteLine("Холст очищен");
		}
	}
}