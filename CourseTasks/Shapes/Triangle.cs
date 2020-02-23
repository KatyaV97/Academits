﻿using System;

namespace Shapes
{
	class Triangle : IShape
	{
		public double X1 { get; set; }

		public double Y1 { get; set; }

		public double X2 { get; set; }

		public double Y2 { get; set; }

		public double X3 { get; set; }

		public double Y3 { get; set; }

		public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
		{
			X1 = x1;
			Y1 = y1;

			X2 = x2;
			Y2 = y2;

			X3 = x3;
			Y3 = y3;
		}

		public double GetWidth()
		{
			double max = Math.Max(Math.Max(X1, X2), X3);
			double min = Math.Min(Math.Min(X1, X2), X3);

			return max - min;
		}

		public double GetHeight()
		{
			double max = Math.Max(Math.Max(Y1, Y2), Y3);
			double min = Math.Min(Math.Min(Y1, Y2), Y3);

			return max - min;
		}

		public double GetArea()
		{
			return 0.5 * Math.Abs((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3));
		}

		public double GetPerimeter()
		{
			return GetSideLength(X1, X2, Y1, Y2) + GetSideLength(X2, X3, Y2, Y3) + GetSideLength(X1, X3, Y1, Y3);
		}

		private double GetSideLength(double x1, double x2, double y1, double y2)
		{
			return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
		}

		public override string ToString()
		{
			return "\nТип фигуры: Треугольник \nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПериметр: " + GetPerimeter() + "\nПлощадь: " + GetArea() + "\n";
		}

		public override int GetHashCode()
		{
			int prime = 37;
			int hash = 1;

			hash = prime * hash + X1.GetHashCode();
			hash = prime * hash + X2.GetHashCode();
			hash = prime * hash + X3.GetHashCode();
			hash = prime * hash + Y1.GetHashCode();
			hash = prime * hash + Y2.GetHashCode();
			hash = prime * hash + Y3.GetHashCode();

			return hash;
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

			Triangle newObj = (Triangle)obj;

			return X1 == newObj.X1 && X2 == newObj.X2 && X3 == newObj.X3 && Y1 == newObj.Y1 && Y2 == newObj.Y2 && Y3 == newObj.Y3;
		}
	}
}
