using System;

namespace Shapes
{
	class ShapesProgram
	{
		public static IShape GetShapeWithFirstMaxArea(IShape[] shapes)
		{
			CompareShapesPerimeters compareShapes = new CompareShapesPerimeters();

			Array.Sort(shapes, 0, shapes.Length, compareShapes);
			Array.Reverse(shapes);

			return shapes[0];
		}

		public static IShape GetShapeWithSecondMaxPerimeter(IShape[] shapes)
		{
			CompareShapesAreas compareShapes = new CompareShapesAreas();

			Array.Sort(shapes, 0, shapes.Length, compareShapes);
			Array.Reverse(shapes);

			return shapes[1];
		}

		static void Main(string[] args)
		{
			double radius1 = 6;
			IShape circle1 = new Circle(radius1);

			double radius2 = 5;
			IShape circle2 = new Circle(radius2);

			double rectangle1SideLength1 = 1;
			double rectangle1SideLength2 = 2;
			IShape rectangle1 = new Rectangle(rectangle1SideLength1, rectangle1SideLength2);

			double rectangle2SideLength1 = 25;
			double rectangle2SideLength2 = 10;
			IShape rectangle2 = new Rectangle(rectangle2SideLength1, rectangle2SideLength2);

			double square1SideLength = 15;
			IShape square1 = new Square(square1SideLength);

			double triangle1X1 = 5;
			double triangle1Y1 = 6;
			double triangle1X2 = 5;
			double triangle1Y2 = 1;
			double triangle1X3 = 8;
			double triangle1Y3 = 1;
			IShape triangle1 = new Triangle(triangle1X1, triangle1Y1, triangle1X2, triangle1Y2, triangle1X3, triangle1Y3);

			IShape[] shapes = new IShape[] { circle1, circle2, rectangle1, rectangle2, square1, triangle1 };

			Console.WriteLine("Параметры фигуры с максимальной площадью:");
			Console.WriteLine(GetShapeWithFirstMaxArea(shapes));

			Console.WriteLine("Параметры фигуры со вторым максимальным периметром:");
			Console.WriteLine(GetShapeWithSecondMaxPerimeter(shapes));

			Console.ReadKey();
		}
	}
}
