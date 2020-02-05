using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			return 2 * SideLength;
		}
	}
}
