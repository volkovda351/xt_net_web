using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using MyStringLib;

namespace Task_2._1._2_Custom_paint
{
	public abstract class Shape
	{
		protected const double E = 1e-6;

		public abstract string Name { get; }
		public abstract string Description { get; }
		
		public override string ToString()
		{
			return $"{Name} {Description}";
		}
	}
	public class Point : Shape
	{
		private double _x;
		private double _y;

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public override string Name
		{
			get
			{
				return "Точка";
			}
		}
		public override string Description
		{
			get
			{
				return $"({X},{Y})";
			}
		}
		public double X
		{
			get
			{
				return _x;
			}
			protected set
			{
				_x = value;
			}
		}
		public double Y
		{
			get
			{
				return _y;
			}
			protected set
			{
				_y = value;
			}
		}

		public override string ToString()
		{
			return Description;
		}
	}
	public class Line : Shape
	{
		private double _a;
		private double _b;
		private double _c;

		public Line(Point a, Point b)
		{
			A = a.Y - b.Y;
			B = b.X - a.X;
			C = (a.X * b.Y - b.X * a.Y);

			_checkСoefficients(A, B);
		}
		public Line(double a, double b, double c)
		{
			A = a;
			B = b;
			C = c;

			_checkСoefficients(A, B);
		}

		public override string Name
		{
			get
			{
				return "Прямая";
			}
		}
		public override string Description
		{
			get
			{
				return $"{A}X + {B}Y + {C} = 0";
			}
		}
		public double A
		{
			get
			{
				return _a;
			}
			private set
			{
				_a = value;
			}
		}
		public double B
		{
			get
			{
				return _b;
			}
			private set
			{
				_b = value;
			}
		}
		public double C
		{
			get
			{
				return _c;
			}
			private set
			{
				_c = value;
			}
		}

		private static void _checkСoefficients(double a, double b)
		{
			if (Abs(a) < E && Abs(b) < E)
				throw new Exception("Хотя бы один из коэффициентов a и b должен быть отличен от нуля");
		}
	}
	public abstract class RoundShape : Shape 
	{
		public abstract Point Center { get; protected set; }
		public abstract double Radius { get; protected set; }
		public abstract double Area { get; }
		public abstract double Perimeter { get; }

		protected static void _checkRadius(double r)
		{
			if (r <= 0)
				throw new Exception("Радиус должен иметь положительное значение");
		}
	}
	public class Disc : RoundShape
	{
		private Point _center;
		private double _radius;

		public Disc(Point center, double radius)
		{
			Center = center;
			Radius = radius;
		}

		public override string Name
		{
			get
			{
				return "Круг";
			}
		}
		public override string Description
		{
			get
			{
				return $"с центром {Center}, радиусом {Radius}, площадью {Area} и периметром {Perimeter}";
			}
		}
		public override Point Center
		{
			get
			{
				return _center;
			}
			protected set
			{
				_center = value;
			}
		}
		public override double Radius
		{
			get
			{
				return _radius;
			}
			protected set
			{
				_radius = value;
				_checkRadius(_radius);
			}
		}
		public override double Area
		{
			get
			{
				return PI * Pow(Radius, 2);
			}
		}
		public override double Perimeter
		{
			get
			{
				return 2 * PI * Radius;
			}
		}
	}
	public class Ring : RoundShape
	{
		private Point _center;
		private double _outerRadius;
		private double _innerRadius;

		public Ring(Point center, double innerRadius, double radius)
		{
			Center = center;
			Radius = radius;
			InnerRadius = innerRadius;
		}

		public override string Name
		{
			get
			{
				return "Кольцо";
			}
		}
		public override string Description
		{
			get
			{
				return $"с центром {Center}, радиусами {InnerRadius} и {Radius}, площадью {Area} и периметром {Perimeter}";
			}
		}
		public override Point Center
		{
			get
			{
				return _center;
			}
			protected set
			{
				_center = value;
			}
		}
		public override double Radius
		{
			get
			{
				return _outerRadius;
			}
			protected set
			{
				_outerRadius = value;
				_checkRadius(_outerRadius);
				_checkRadiuses(_innerRadius, _outerRadius);
			}
		}
		public double InnerRadius
		{
			get
			{
				return _innerRadius;
			}
			private set
			{
				_innerRadius = value;
				_checkRadius(_innerRadius);
				_checkRadiuses(_innerRadius, _outerRadius);
			}
		}
		public override double Area
		{
			get
			{
				return PI * (Pow(Radius, 2) - Pow(InnerRadius, 2));
			}
		}
		public override double Perimeter
		{
			get
			{
				return 2 * PI * (InnerRadius + Radius);
			}
		}

		protected void _checkRadiuses(double innerRadius, double outerRadius)
		{
			if (innerRadius >= outerRadius)
				throw new Exception("Внутренний радиус должен быть меньше внешнего");
		}
	}
	public abstract class Polygon : Shape
	{
		private Point[] _vertexes;
		public Polygon(Point[] vertexes)
		{
			Vertexes = vertexes;
		}

		public override string Description
		{
			get
			{
				MyString myStr = new MyString();

				for (int i = 0; i < Vertexes.Length; i++)
					myStr.Append($"{Vertexes[i].Description} ");

				myStr += $"периметром {Perimeter} и площадью {Area}";

				return myStr.ToString();
			}
		}
		public Point[] Vertexes
		{
			get
			{
				return _vertexes;
			}
			private set
			{
				_vertexes = value;
			}
		}
		public double Area
		{
			get
			{
				int n = Vertexes.Length;

				double result = 0;
				
				for (int i = 0; i < n; i++)
				{
					result += Vertexes[i].X * Vertexes[(n + i + 1) % n].Y;
					result -= Vertexes[i].X * Vertexes[(n + i - 1) % n].Y;
				}

				result = Abs(result) / 2;

				return result;
			}
		}
		public double Perimeter
		{
			get
			{
				int n = Vertexes.Length;

				double result = 0;

				Vector[] vectorsOfSides = new Vector[n];
				for (int i = 0; i < n; i++)
					vectorsOfSides[i] = new Vector(Vertexes[(n + i - 1) % n], Vertexes[i]);

				for (int i = 0; i < n; i++)
					result += vectorsOfSides[i].Length;

				return result;
			}
		}
		
		protected bool isRegularity(Point[] vertexes)

		{
			int n = vertexes.Length;

			Vector[] vectorsOfSides = new Vector[n];
			for (int i = 0; i < n; i++)
				vectorsOfSides[i] = new Vector(vertexes[(n + i - 1) % n], vertexes[i]);

			for (int i = 1; i < n; i++)
				if (vectorsOfSides[0].Length != vectorsOfSides[i].Length)
					return false;

			return true;
		}

		protected class Vector
		{
			private double _x;
			private double _y;

			public Vector(Point p1, Point p2)
			{
				X = p2.X - p1.X;
				Y = p2.Y - p1.Y;
			}

			public double X
			{
				get
				{
					return _x;
				}
				set
				{
					_x = value;
				}
			}
			public double Y
			{
				get
				{
					return _y;
				}
				set
				{
					_y = value;
				}
			}
			public double Length
			{
				get
				{
					return Sqrt(Pow(X, 2) + Pow(Y, 2));
				}
			}

			public static double PseudoScalarMultiplication(Vector v1, Vector v2)
			{
				return v1.X * v2.Y - v2.X * v1.Y;
			}
			public static double ScalarMultiplication(Vector v1, Vector v2)
			{
				return v1.X * v2.X + v1.Y * v2.Y;
			}
			public static double CosOfTheAngle(Vector v1, Vector v2)
			{
				return ScalarMultiplication(v1, v2) / (v1.Length * v2.Length);
			}
		}
	}
	public abstract class ConvexPolygon : Polygon
	{
		public ConvexPolygon(Point[] vertexes) : base(vertexes)
		{
			if (!isConvexity(vertexes))
				throw new Exception("Не является выпуклым");
		}

		protected bool isConvexity(Point[] vertexes)
		{
			int n = vertexes.Length;

			Vector[] vectorsOfSides = new Vector[n];
			for (int i = 0; i < n; i++)
				vectorsOfSides[i] = new Vector(vertexes[(n + i - 1) % n], vertexes[i]);

			double[] orientationOfAngle = new double[vertexes.Length];

			for (int i = 0; i < n; i++)
				orientationOfAngle[i] = Vector.PseudoScalarMultiplication(vectorsOfSides[(n + i - 1) % n], vectorsOfSides[i]);

			for (int i = 1; i < n; i++)
				if (orientationOfAngle[0] < 0 != orientationOfAngle[i] < 0)
					return false;

			return true;
		}
	}
	public class Rectangle : ConvexPolygon
	{
		public Rectangle(Point[] vertexes) : base(vertexes)
		{
			if (!isRectangular(vertexes))
				throw new Exception("Не все углы прямые");
		}

		public override string Name
		{
			get
			{
				return "Прямоугольник";
			}
		}

		protected bool isRectangular(Point[] vertexes)
		{
			int n = vertexes.Length;

			Vector[] vectorsOfSides = new Vector[n];
			for (int i = 0; i < n; i++)
				vectorsOfSides[i] = new Vector(vertexes[(n + i - 1) % n], vertexes[i]);

			double[] cosArr = new double[vertexes.Length];

			for (int i = 0; i < n; i++)
				cosArr[i] = Vector.CosOfTheAngle(vectorsOfSides[(n + i - 1) % n], vectorsOfSides[i]);

			for (int i = 0; i < n; i++)
				if (Abs(cosArr[0]) > E)
					return false;

			return true;
		}
	}
	public class Square : Rectangle
	{
		public Square(Point[] vertexes) : base(vertexes)
		{
			if (!isRegularity(vertexes))
				throw new Exception("Не все стороны равны");
		}

		public override string Name
		{
			get
			{
				return "Квадрат";
			}
		}
	}
	public class Triangle : ConvexPolygon
	{
		public Triangle(Point[] vertexes) : base(vertexes) { }

		public override string Name
		{
			get
			{
				return "Треугольник";
			}
		}
	}
}