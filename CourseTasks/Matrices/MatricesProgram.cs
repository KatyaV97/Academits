using System;

namespace Matrices
{
	class MatricesProgram
	{
		static void Main()
		{
			double[,] values = new double[2, 3];

			for (int i = 0; i < values.GetLength(0); i++)
			{
				for (int j = 0; j < values.GetLength(1); j++)
				{
					values[i, j] = i + j;
				}
			}

			Matrix matrix1 = new Matrix(values);

			Console.WriteLine("Матрица №1: " + matrix1);		

			Console.WriteLine("Результат транспонирования матрицы №1: " + matrix1.Transpose());

			Console.ReadKey();
		}
	}
}
