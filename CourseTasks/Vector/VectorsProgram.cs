﻿using System;

namespace Vectors
{
	class VectorsProgram
	{
		static void Main(string[] args)
		{
			Vectors vector1 = new Vectors(new double[] { 10, 20, 30 });
			Vectors vector2 = new Vectors(new double[] { 15, 5 });
			Vectors additionalVectors = Vectors.AddVectors(vector1, vector2);

			Console.WriteLine("Результат сложения векторов статическим методом: " + additionalVectors);

			vector1.AdditionVectors(vector2);

			Console.WriteLine("Результат сложения векторов нестатическим методом: " + vector1);

			Vectors subtractionalVectors = Vectors.SubtractVectors(vector1, vector2);

			Console.WriteLine("Результат вычитания векторов статическим методом: " + subtractionalVectors);

			vector1.SubtractionVectors(vector2);

			Console.WriteLine("Результат вычитания векторов статическим методом: " + vector1);

			vector1.MultiplyVectorByScalar(12);

			Console.WriteLine("Результат усножения вектора на скаляр: " + vector1);

			vector1.ReverseVector();

			Console.WriteLine("Разворот вектора: " + vector1);

			double vector1Length = vector1.GetLength();

			Console.WriteLine("Длина вектора: " + vector1Length);

			Vectors vector3 = new Vectors(6);
			Vectors vector4 = new Vectors(6, new double[] { 3, 4, 9, 6, 7, 2 });
			Vectors vector5 = new Vectors(vector4);

			Console.WriteLine("Вектор №3: " + vector3);
			Console.WriteLine("Вектор №4: " + vector4);
			Console.WriteLine("Вектор №5: " + vector5);

			Console.ReadKey();
		}
	}
}
