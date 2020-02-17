using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class ShapesProgram
	{
		static void Main(string[] args)
		{
			double radius1 = 10;
			IShape circle1 = new Circle(radius1);

			double radius2 = 12;
			IShape circle2 = new Circle(radius2);

			double rectangle1SideLength1 = 8;
			double rectangle1SideLength2 = 10;
			IShape rectangle1 = new Rectangle(rectangle1SideLength1, rectangle1SideLength2);

			double rectangle2SideLength1 = 8;
			double rectangle2SideLength2 = 10;
			IShape rectangle2 = new Rectangle(rectangle2SideLength1, rectangle2SideLength2);

			double square1SideLength = 15;
			IShape square1 = new Square(square1SideLength);

			double triangle1X1 = 1;
			double triangle1Y1 = 0;
			double triangle1X2 = 5;
			double triangle1Y2 = 2;
			double triangle1X3 = 1.5;
			double triangle1Y3 = 7;
			IShape triangle1 = new Triangle(triangle1X1, triangle1Y1, triangle1X2, triangle1Y2, triangle1X3, triangle1Y3);

			IShape[] shapes = new IShape[] { circle1, circle2, rectangle1, rectangle2, square1, triangle1 };

			Array.Sort(shapes);
			//IShape shapeWithMaxArea = GetShapeWithMaxArea(shapes);
			//Console.WriteLine("Фигура с наибольшей площадью:");
			//Console.WriteLine(shapes[0].GetArea);

		}

		public IShape GetShapeWithMaxArea(IShape[] shapes)
		{
			Array.Sort(shapes);

			return shapes[0];
		}
	}
}
