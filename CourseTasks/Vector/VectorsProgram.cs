using System;

namespace Vectors
{
	class VectorsProgram
	{
		static void Main(string[] args)
		{
			Vector vector1 = new Vector(new double[] { 10, 20 });
			Vector vector2 = new Vector(new double[] { 15, 5, 6, 18, -5 });

			Vector vectorsResultAddition = Vector.Addition(vector1, vector2);
			Console.WriteLine("Результат сложения векторов статическим методом: " + vectorsResultAddition);

			vector1.Add(vector2);
			Console.WriteLine("Результат сложения векторов нестатическим методом: " + vector1);

			Console.WriteLine(Environment.NewLine);

			Vector vectorsResultSubtraction = Vector.Subtraction(vector1, vector2);
			Console.WriteLine("Результат вычитания векторов статическим методом: " + vectorsResultSubtraction);

			vector1.Subtract(vector2);
			Console.WriteLine("Результат вычитания векторов статическим методом: " + vector1);

			Console.WriteLine(Environment.NewLine);

			vector1.MultiplyByScalar(12);
			Console.WriteLine("Результат усножения вектора №1 на скаляр: " + vector1);

			vector1.Reverse();
			Console.WriteLine("Разворот вектора №1: " + vector1);

			double vector1Length = vector1.GetLength();

			Console.WriteLine("Длина вектора №1: " + vector1Length);
			Console.WriteLine(Environment.NewLine);

			Vector vector3 = new Vector(5);
			Vector vector4 = new Vector(6, new double[] { 3, 4, 9, 6, 7 });
			Vector vector5 = new Vector(vector4);

			Console.WriteLine("Вектор №3: " + vector3);
			Console.WriteLine("Вектор №4: " + vector4);
			Console.WriteLine("Вектор №5: " + vector5);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Первый элемент вектора №5 = " + vector5.GetComponent(5));

			if (vector4.Equals(vector5))
			{
				Console.WriteLine("Вектор №4 равен вектору №5");
			}
			else
			{
				Console.WriteLine("Вектор №4 не равен вектору №5");
			}

			Console.WriteLine(Environment.NewLine);

			vector5.SetComponent(0, 10);

			Console.WriteLine("Вектор №3: " + vector3);
			Console.WriteLine("Вектор №4: " + vector4);
			Console.WriteLine("Вектор №5: " + vector5);
			Console.WriteLine(Environment.NewLine);

			if (vector4.Equals(vector5))
			{
				Console.WriteLine("Вектор №4 равен вектору №5");
			}
			else
			{
				Console.WriteLine("Вектор №4 не равен вектору №5");
			}

			Console.ReadKey();
		}
	}
}
