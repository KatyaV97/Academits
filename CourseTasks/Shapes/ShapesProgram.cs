using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class ShapesProgram : IComparable
	{
		public double Area { get; set; }


		 public int CompareTo(IShape shape)
	{
			IShape shapeArea = shape as IShape;

			return this.Area.CompareTo(shapeArea);
		}

	
		static void Main(string[] args)
		{
			double radius1 = 10;
			Circle circle1 = new Circle(radius1);

			double radius2 = 12;
			Circle circle2 = new Circle(radius2);

			double rectangle1SideLength1 = 8;
			double rectangle1SideLength2 = 10;
			Rectangle rectangle1 = new Rectangle(rectangle1SideLength1, rectangle1SideLength2);

			double rectangle2SideLength1 = 8;
			double rectangle2SideLength2 = 10;
			Rectangle rectangle2 = new Rectangle(rectangle2SideLength1, rectangle2SideLength2);

			double square1SideLength = 15;
			Square square1 = new Square(square1SideLength);

			double triangle1X1 = 1;
			double triangle1Y1 = 0;
			double triangle1X2 = 5;
			double triangle1Y2 = 2;
			double triangle1X3 = 1.5;
			double triangle1Y3 = 7;
			Triangle triangle1 = new Triangle(triangle1X1, triangle1Y1, triangle1X2, triangle1Y2, triangle1X3, triangle1Y3);

			IShape[] shapes = new IShape[] { circle1, circle2, rectangle1, rectangle2, square1, triangle1 };

		}

		public IShape GetShapeWithMaxArea(IShape[] shapes) 
		{
			GetArea.shapes[0].CompareTo(shapes[1]);

			Array.Sort(shapes, new ShapesComparer())
		}
	}
}
