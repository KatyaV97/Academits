using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class Rectangle : IShape
	{
		public double SideLength1 { get; set; }

		public double SideLength2 { get; set; }

		public Rectangle(double sideLength1, double sideLength2)
		{
			SideLength1 = sideLength1;
			SideLength2 = sideLength2;
		}

		public double GetWidth()
		{
			return (SideLength1 < SideLength2)? SideLength1: SideLength1;
		}

		public double GetHeight()
		{
			return (SideLength1 > SideLength2) ? SideLength1 : SideLength1;
		}

		public double GetArea()
		{
			return SideLength1 * SideLength2;
		}

		public double GetPerimeter()
		{
			return 2 * (SideLength1 + SideLength2);
		}
	}
}
