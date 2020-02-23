using System;

namespace Shapes
{
	public class Square : IShape
	{
		public double SideLength { get; set; }

		public Square(double sideLength)
		{
			SideLength = sideLength;
		}

		public double GetWidth()
		{
			return SideLength;
		}

		public double GetHeight()
		{
			return SideLength;
		}

		public double GetArea()
		{
			return Math.Pow(SideLength, 2);
		}

		public double GetPerimeter()
		{
			return 4 * SideLength;
		}

		public override string ToString()
		{
			return "\nТип фигуры: Квадрат \nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПериметр: " + GetPerimeter() + "\nПлощадь: " + GetArea() + "\n";
		}

		public override int GetHashCode()
		{
			return SideLength.GetHashCode(); ;
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

			Square newObj = (Square)obj;

			return SideLength == newObj.SideLength;
		}
	}
}
