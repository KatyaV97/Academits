using System;

namespace Shapes
{
	class Circle : IShape
	{
		public double Radius { get; set; }

		public Circle(double radius)
		{
			Radius = radius;
		}

		public double GetWidth()
		{
			return Radius;
		}

		public double GetHeight()
		{
			return Radius;
		}

		public double GetArea()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}

		public double GetPerimeter()
		{
			return 2 * Math.PI * Radius;
		}

		public override string ToString()
		{
			return "\nТип фигуры: Окружность \nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПериметр: " + GetPerimeter() + "\nПлощадь: " + GetArea() + "\n";
		}

		public override int GetHashCode()
		{
			return Radius.GetHashCode(); ;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, this))
			{
				return true;
			}

			if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
			{
				return false;
			}

			Circle newObj = (Circle)obj;

			return Radius == newObj.Radius;
		}
	}
}
