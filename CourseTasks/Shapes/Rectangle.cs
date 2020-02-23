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
			return SideLength1;
		}

		public double GetHeight()
		{
			return SideLength2;
		}

		public double GetArea()
		{
			return SideLength1 * SideLength2;
		}

		public double GetPerimeter()
		{
			return 2 * (SideLength1 + SideLength2);
		}

		public override string ToString()
		{
			return "\nТип фигуры: Прямоугольник \nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПериметр: " + GetPerimeter() + "\nПлощадь: " + GetArea() + "\n";
		}

		public override int GetHashCode()
		{
			int prime = 37;
			int hash = 1;

			hash = prime * hash + SideLength1.GetHashCode();
			hash = prime * hash + SideLength2.GetHashCode();

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

			Rectangle newObj = (Rectangle)obj;

			return SideLength1 == newObj.SideLength1 && SideLength2 == newObj.SideLength2;
		}
	}
}
