using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	public class Square : IShape, IComparable
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
			return 2 * SideLength;
		}

		public int CompareTo(object obj)
		{
			Square square1 = obj as Square;

			if (square1 != null)
			{
				if (this.GetArea() < square1.GetArea())
				{
					return -1;
				}
				else if (this.GetArea() > square1.GetArea())
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
				throw new Exception("Параметр не является квадратом.");
			}
		}
	}
}
