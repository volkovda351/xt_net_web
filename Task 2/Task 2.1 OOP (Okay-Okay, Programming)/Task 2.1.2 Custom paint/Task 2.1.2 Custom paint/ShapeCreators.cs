using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_paint
{
	public abstract class ShapeCreator
	{
		public abstract Shape CreateShape();
	}
	public class PointCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Точка задается координатами X и Y");

				double x = 0;
				bool isSuccessX = false;
				while (!isSuccessX)
				{
					Console.WriteLine("Введите X");
					isSuccessX = double.TryParse(Console.ReadLine(), out x);
				}

				double y = 0;
				bool isSuccessY = false;
				while (!isSuccessY)
				{
					Console.WriteLine("Введите Y");
					isSuccessY = double.TryParse(Console.ReadLine(), out y);
				}

				return new Point(x, y);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Точка не создана");
			}
		}
	}
	public class LineCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Выберите способ задания прямой");
				Console.WriteLine("1. Пара точек");
				Console.WriteLine("2. Уравнение прямой");

				int.TryParse(Console.ReadLine(), out int choice);

				switch (choice)
				{
					case 1:
						PointCreator pointCreator = new PointCreator();

						Console.WriteLine("Точка (x1, y1)");
						Point p1 = (Point)pointCreator.CreateShape();

						Console.WriteLine("Точка (x2, y2)");
						Point p2 = (Point)pointCreator.CreateShape();

						return new Line(p1, p2);
					case 2:
						Console.WriteLine("Уравнение прямой имеет вид aX + bY + c = 0");

						double a = 0;
						bool isSuccessA = false;
						while (!isSuccessA)
						{
							Console.WriteLine("Введите a");
							isSuccessA = double.TryParse(Console.ReadLine(), out a);
						}

						double b = 0;
						bool isSuccessB = false;
						while (!isSuccessB)
						{
							Console.WriteLine("Введите b");
							isSuccessB = double.TryParse(Console.ReadLine(), out b);
						}

						double c = 0;
						bool isSuccessC = false;
						while (!isSuccessC)
						{
							Console.WriteLine("Введите c");
							isSuccessC = double.TryParse(Console.ReadLine(), out c);
						}

						return new Line(a, b, c);
					default:
						throw new Exception("Ничего не выбрано");
				}
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Прямая не создана");
			}
		}
	}
	public class DiscCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Круг задается точкой центра (X, Y) и радиусом R");

				PointCreator pointCreator = new PointCreator();
				Point p = (Point)pointCreator.CreateShape();

				double r = 0;
				bool isSuccessR = false;
				while (!isSuccessR)
				{
					Console.WriteLine("Введите R");
					isSuccessR = double.TryParse(Console.ReadLine(), out r);
				}

				return new Disc(p, r);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Круг не создан");
			}
		}
	}
	public class RingCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Кольцо задается точкой центра (X, Y), внешним радиусом R и внутренним радиусом r");

				PointCreator pointCreator = new PointCreator();
				Point p = (Point)pointCreator.CreateShape();

				double outerRadius = 0;
				bool isSuccessOuterRadius = false;
				while (!isSuccessOuterRadius)
				{
					Console.WriteLine("Введите R");
					isSuccessOuterRadius = double.TryParse(Console.ReadLine(), out outerRadius);
				}

				double innerRadius = 0;
				bool isSuccessInnerRadius = false;
				while (!isSuccessInnerRadius)
				{
					Console.WriteLine("Введите r");
					isSuccessInnerRadius = double.TryParse(Console.ReadLine(), out innerRadius);
				}

				return new Ring(p, innerRadius, outerRadius);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Кольцо не создано");
			}
		}
	}
	public class RectangleCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Прямоугольник задается четырьмя точками");

				PointCreator pointCreator = new PointCreator();
				Point[] vertexes = new Point[4];

				for (int i = 0; i < 4; i++)
					vertexes[i] = (Point)pointCreator.CreateShape();

				return new Rectangle(vertexes);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Прямоугольник не создан");
			}
		}
	}
	public class SquareCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Квадрат задается четырьмя точками");

				PointCreator pointCreator = new PointCreator();
				Point[] vertexes = new Point[4];

				for (int i = 0; i < 4; i++)
					vertexes[i] = (Point)pointCreator.CreateShape();

				return new Square(vertexes);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Квадрат не создан");
			}
		}
	}
	public class TriangleCreator : ShapeCreator
	{
		public override Shape CreateShape()
		{
			try
			{
				Console.WriteLine("Треугольник задается тремя точками");

				PointCreator pointCreator = new PointCreator();
				Point[] vertexes = new Point[3];

				for (int i = 0; i < 3; i++)
					vertexes[i] = (Point)pointCreator.CreateShape();

				return new Triangle(vertexes);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message + Environment.NewLine + "Треугольник не создан");
			}
		}
	}
}
