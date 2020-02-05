using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			double max;
			double min;

			if (X1 > X2 && X1 > X3)
			{
				max = X1;

				if (X2 < X3)
				{
					min = X2;
				}
				else
				{
					min = X3;
				}
			}
			else if (X2 > X3)
			{
				max = X2;

				if (X1 < X3)
				{
					min = X1;
				}
				else
				{
					min = X3;
				}
			}
			else
			{
				max = X3;

				if (X1 < X2)
				{
					min = X1;
				}
				else
				{
					min = X2;
				}
			}

			return max - min;
		}

		public double GetHeight()
		{
			double max;
			double min;

			if (Y1 > Y2 && Y1 > Y3)
			{
				max = Y1;

				if (Y2 < Y3)
				{
					min = Y2;
				}
				else
				{
					min = Y3;
				}
			}
			else if (Y2 > Y3)
			{
				max = Y2;

				if (Y1 < Y3)
				{
					min = Y1;
				}
				else
				{
					min = Y3;
				}
			}
			else
			{
				max = Y3;

				if (Y1 < Y2)
				{
					min = Y1;
				}
				else
				{
					min = Y2;
				}
			}

			return max - min;
		}

		public double GetArea()
		{
			return 0.5 * Math.Abs((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3));
		}

		public double GetPerimeter()
		{
			double sideLength1 = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
			double sideLength2 = Math.Sqrt(Math.Pow((X3 - X2), 2) + Math.Pow((Y3 - Y2), 2));
			double sideLength3 = Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));

			return sideLength1 + sideLength2 + sideLength3;
		}
	}
}
