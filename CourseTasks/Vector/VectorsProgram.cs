using System;

namespace Vectors
{
	class VectorsProgram
	{
		static void Main(string[] args)
		{
			Vectors vector1 = new Vectors(new double[] { 10, 20, 30 });
			Vectors vector2 = new Vectors(new double[] { 15, 5 });

			Vectors vectorsResultAddition = Vectors.AdditionVectors(vector1, vector2);
			Console.WriteLine("Результат сложения векторов статическим методом: " + vectorsResultAddition);

			vector1.AddVector(vector2);
			Console.WriteLine("Результат сложения векторов нестатическим методом: " + vector1);

			Console.WriteLine(Environment.NewLine);

			Vectors vectorsResultSubtraction = Vectors.SubtractionVectors(vector1, vector2);
			Console.WriteLine("Результат вычитания векторов статическим методом: " + vectorsResultSubtraction);

			vector1.SubtractVector(vector2);
			Console.WriteLine("Результат вычитания векторов статическим методом: " + vector1);

			Console.WriteLine(Environment.NewLine);

			vector1.MultiplyVectorByScalar(12);
			Console.WriteLine("Результат усножения вектора №1 на скаляр: " + vector1);

			vector1.ReverseVector();
			Console.WriteLine("Разворот вектора №1: " + vector1);

			double vector1Length = vector1.GetLength();

			Console.WriteLine("Длина вектора №1: " + vector1Length);
			Console.WriteLine(Environment.NewLine);

			Vectors vector3 = new Vectors(5);
			Vectors vector4 = new Vectors(6, new double[] { 3, 4, 9, 6, 7 });
			Vectors vector5 = new Vectors(vector4);

			Console.WriteLine("Вектор №3: " + vector3);
			Console.WriteLine("Вектор №4: " + vector4);
			Console.WriteLine("Вектор №5: " + vector5);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Первый элемент вектора №5 = " + vector5.GetComponent(0));

			if (vector4.Equals(vector5))
			{
				Console.WriteLine("Вектор №4 равен вектору №5");
			}
			else
			{
				Console.WriteLine("Вектор №4 не равен вектору №5");
			}

			Console.WriteLine(Environment.NewLine);

			vector5.SetComponent(10, 0);

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
