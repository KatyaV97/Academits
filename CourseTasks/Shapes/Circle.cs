using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class Circle : IShape, IComparable
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

		public int CompareTo(object obj)
		{
			Circle circle1 = obj as Circle;

			if (circle1 != null)
			{
				if (this.GetArea() < circle1.GetArea())
				{
					return -1;
				}
				else if (this.GetArea() > circle1.GetArea())
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			else
			{
				throw new Exception("Параметр не является треугольником.");
			}
		}
	}
}
