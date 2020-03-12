using System;

namespace Matrices
{
	class MatricesProgram
	{
		static void Main()
		{
			double[,] values = new double[4, 4];

			values[0, 0] = 2;
			values[0, 1] = 5;
			values[0, 2] = 4;
			values[0, 3] = 6;
			values[1, 0] = 1;
			values[1, 1] = 2;
			values[1, 2] = 8;
			values[1, 3] = 1;
			values[2, 0] = 3;
			values[2, 1] = 7;
			values[2, 2] = 5;
			values[2, 3] = 6;
			values[3, 0] = 5;
			values[3, 1] = 8;
			values[3, 2] = 11;
			values[3, 3] = 10;

			/*
			for (int i = 0; i < values.GetLength(0); i++)
			{
				for (int j = 0; j < values.GetLength(1); j++)
				{
					values[i, j] = ;
				}
			}
			*/

			Matrix matrix1 = new Matrix(values);
			Matrix matrix2 = new Matrix(matrix1);

			Console.WriteLine("Матрица №1: " + matrix1);
			Console.WriteLine("Результат транспонирования матрицы №1: " + matrix1.Transpose());

			Console.WriteLine("Матрица №2: " + matrix2);
			Console.WriteLine(Environment.NewLine);

			Vectors.Vector vector1 = new Vectors.Vector(3);

			matrix2.SetVector(1, vector1);

			Console.WriteLine("Матрица №1: " + matrix1);
			Console.WriteLine("Матрица №2: " + matrix2);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Определитель матрицы №2 = " + matrix1.GetDeterminant());
			Console.WriteLine(Environment.NewLine);

			Vectors.Vector vector2 = new Vectors.Vector(new double[] { 5, 2, 0, 9 });
			Vectors.Vector vector3 = new Vectors.Vector(new double[] { 7, 10, 12 });
			Vectors.Vector vector4 = new Vectors.Vector(new double[] { 2, 15, 22, 14 });
			Vectors.Vector vector5 = new Vectors.Vector(new double[] { 14, 2 });
			Vectors.Vector vector6 = new Vectors.Vector(new double[] { 18 });
			Vectors.Vector vector7 = new Vectors.Vector(new double[] { 45 });
			Vectors.Vector vector8 = new Vectors.Vector(new double[] { 3, 7 });
			//Vectors.Vector vector5 = new Vectors.Vector(new double[] { 11, 6, 9 });

			Vectors.Vector[] vectors1 = new Vectors.Vector[] { vector2, vector3, vector4 };
			Vectors.Vector[] vectors2 = new Vectors.Vector[] { vector5, vector6, vector7, vector8 };
			Vectors.Vector[] vectors3 = new Vectors.Vector[] { vector6, vector7 };

			Matrix matrix3 = new Matrix(vectors1);
			Matrix matrix4 = new Matrix(vectors2);
			Matrix matrix5 = new Matrix(vectors3);
			//Matrix matrix4 = matrix3.MultiplyByVector(vector5);

			Console.WriteLine("Результат умножения матрицы №5 на вектор №8 = " + matrix5.MultiplyByVector(vector8));
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Матрица №3: " + matrix3);
			Console.WriteLine("Результат умножения матрицы №4 на матрицу №3  = " + Matrix.Multiply(matrix3, matrix4));
			Console.WriteLine(Environment.NewLine);

			Console.ReadKey();
		}
	}
}
