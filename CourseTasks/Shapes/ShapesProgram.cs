using System;
using Shapes.ShapesTypes;
using Shapes.Comparers;

namespace Shapes
{
	class ShapesProgram
	{
		public static IShape GetShapeWithFirstMaxArea(IShape[] shapes)
		{
			AreasComparer shapesComparer = new AreasComparer();

			Array.Sort(shapes, shapesComparer);

			return shapes[shapes.Length - 1];
		}

		public static IShape GetShapeWithSecondMaxPerimeter(IShape[] shapes)
		{
			PerimetersComparer shapesComparer = new PerimetersComparer();

			Array.Sort(shapes, shapesComparer);

			return shapes[shapes.Length - 2];
		}

		static void Main(string[] args)
		{
			double radius1 = 22;
			IShape circle1 = new Circle(radius1);

			double radius2 = 18;
			IShape circle2 = new Circle(radius2);

			double rectangle1Width = 1;
			double rectangle1Height = 2;
			IShape rectangle1 = new Rectangle(rectangle1Width, rectangle1Height);

			double rectangle2Width = 25;
			double rectangle2Height = 35;
			IShape rectangle2 = new Rectangle(rectangle2Width, rectangle2Height);

			double square1SideLength = 15;
			IShape square1 = new Square(square1SideLength);

			double triangle1X1 = 5;
			double triangle1Y1 = 6;
			double triangle1X2 = 5;
			double triangle1Y2 = 1;
			double triangle1X3 = 8;
			double triangle1Y3 = 1;
			IShape triangle1 = new Triangle(triangle1X1, triangle1Y1, triangle1X2, triangle1Y2, triangle1X3, triangle1Y3);

			IShape[] shapes = { circle1, circle2, rectangle1, rectangle2, square1, triangle1 };

			Console.WriteLine("Параметры фигуры с максимальной площадью:");
			Console.WriteLine(GetShapeWithFirstMaxArea(shapes));

			Console.WriteLine("Параметры фигуры со вторым максимальным периметром:");
			Console.WriteLine(GetShapeWithSecondMaxPerimeter(shapes));

			Console.ReadKey();
		}
	}
}
