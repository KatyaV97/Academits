using System;

namespace Matrices
{
	class MatricesProgram
	{
		static void Main()
		{
			var matrix1 = new Matrix(3, 3);

			var matrix2 = new Matrix(matrix1);

			var values1 = new double[,] { { 1, 2, 3, 4 }, { 4, 5, 6, 7 } };

			var matrix3 = new Matrix(values1);

			var vectors1 = new Vectors.Vector[] { new Vectors.Vector(new double[] { 8, 9 }), new Vectors.Vector(new double[] { 5, 9 }), new Vectors.Vector(new double[] {6,8 }), new Vectors.Vector(new double[] { 11,12 }) };
			var vectors2 = new Vectors.Vector[] { new Vectors.Vector(new double[] { 8 }), new Vectors.Vector(new double[] { 5 }), new Vectors.Vector(new double[] { 9 }) };

			var matrix4 = new Matrix(vectors1);
			var matrix5 = new Matrix(vectors2);

			Console.WriteLine("Матрица №1: " + matrix1);
			Console.WriteLine("Матрица №2: " + matrix2);
			Console.WriteLine("Матрица №3: " + matrix3);
			Console.WriteLine("Матрица №4: " + matrix4);
			Console.WriteLine("Матрица №5: " + matrix5);
			Console.WriteLine(Environment.NewLine);

			matrix4.Transpose();

			Console.WriteLine("Результат транспонирования матрицы №4: " + matrix4);
			Console.WriteLine(Environment.NewLine);

			var vector1 = new Vectors.Vector(new double[] { 3, 8,9,10});

			Console.WriteLine("Результат умножения матрицы №4 на вектор №1 = " + matrix4.MultiplyByVector(vector1));
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Результат сложения матрицы №3 с матрицей №4 статическим методом = " + Matrix.Addition(matrix3, matrix4));

			Console.WriteLine("Результат вычитания матрицы №4 из матрицы №3 статическим методом = " + Matrix.Subtraction(matrix3, matrix4));

			matrix3.Add(matrix4);

			Console.WriteLine("Результат сложения матрицы №3 с матрицей №4 нестатическим методом = " + matrix3);

			matrix3.Subtract(matrix4);

			Console.WriteLine("Результат вычитания матрицы №4 из матрицы №3 нестатическим методом = " + matrix3);
			Console.WriteLine(Environment.NewLine);

			var vector2 = new Vectors.Vector(new double[] { 5, 2, 0, 7 });
			var vector3 = new Vectors.Vector(new double[] { 7, 10, 12, 1 });
			var vector4 = new Vectors.Vector(new double[] { 2, 15, 22, 14 });
			var vector5 = new Vectors.Vector(new double[] { 14, 2 });
			var vector6 = new Vectors.Vector(new double[] { 18, 1 });
			var vector7 = new Vectors.Vector(new double[] { 45, 3 });
			var vector8 = new Vectors.Vector(new double[] { 3, 7 });
			var vector9 = new Vectors.Vector(new double[] { 7, 8, 5, 6 });

			var vectors3 = new Vectors.Vector[] { vector2, vector3, vector4 };
			var vectors4 = new Vectors.Vector[] { vector5, vector6, vector7, vector8 };
			var vectors5 = new Vectors.Vector[] { vector2, vector3, vector4, vector9 };

			var matrix6 = new Matrix(vectors3);
			var matrix7 = new Matrix(vectors4);
			var matrix8 = new Matrix(vectors5);
			var matrix9 = new Matrix(matrix8);

			Console.WriteLine("Матрица №3: " + matrix3);
			Console.WriteLine("Результат умножения матрицы №6 на матрицу №7  = " + Matrix.Multiply(matrix6, matrix7));
			Console.WriteLine(Environment.NewLine);

			var vector10 = new Vectors.Vector(new double[] { 3, 8, 5 });
			matrix1.SetRow(2, vector10);

			Console.WriteLine("Матрица №1 после установки вектора №10 на 3 позицию: " + matrix1);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Определитель матрицы №8 = " + matrix8.GetDeterminant());
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Строчный вектор матрицы №3 = " + matrix3.GetRow(1));
			Console.WriteLine("Вектор по столбцу матрицы №3 = " + matrix3.GetColumn(1));
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Матрица №8: " + matrix8);
			Console.WriteLine("Матрица №9: " + matrix9);
			Console.WriteLine(Environment.NewLine);

			vector2.SetComponent(1, 25);
			matrix8.SetRow(3, vector2);

			Console.WriteLine("Матрица №8  после установки вектора №2 на 3 строку: " + matrix8);
			Console.WriteLine("Матрица №9: " + matrix9);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Количество столбцов матрицы №9: " + matrix9.GetColumnsCount());

			Console.ReadKey();
		}
	}
}
