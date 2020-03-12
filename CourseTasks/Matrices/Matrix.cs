using System;
using Vectors;

namespace Matrices
{
	class Matrix
	{
		private int VectorSize;

		private int VectorsCount;

		private double[,] Values;

		public Matrix(int vectorsCount, int vectorSize)
		{
			VectorsCount = vectorsCount;
			VectorSize = vectorSize;

			Values = new double[VectorsCount, VectorSize];
		}

		public Matrix(Matrix matrix)
		{
			VectorsCount = matrix.Values.GetLength(0);
			VectorSize = matrix.Values.GetLength(1);

			Values = new double[VectorsCount, VectorSize];

			Array.Copy(matrix.Values, Values, matrix.Values.Length);
		}

		public Matrix(double[,] matrixValues)
		{
			VectorsCount = matrixValues.GetLength(0);
			VectorSize = matrixValues.GetLength(1);

			Values = new double[VectorsCount, VectorSize];

			Array.Copy(matrixValues, Values, matrixValues.Length);
		}

		public Matrix(Vector[] vectors)
		{
			VectorsCount = vectors.Length;

			VectorSize = 0;

			for (int i = 0; i < vectors.Length; i++)
			{
				VectorSize = Math.Max(VectorSize, vectors[i].GetSize());
			}

			Values = new double[VectorsCount, VectorSize];

			for (int i = 0; i < VectorsCount; i++)
			{
				for (int j = 0; j < vectors[i].Values.Length; j++)
				{
					Values[i, j] = vectors[i].Values[j];
				}
			}
		}

		public int GetVectorSize()
		{
			return VectorSize;
		}

		public int GetVectorsCount()
		{
			return VectorsCount;
		}

		public void SetVector(int index, Vector vector)
		{
			for (int i = 0; i < vector.GetSize(); i++)
			{
				Values[index, i] = vector.Values[i];
			}
		}

		public Vector GetVectorRow(int index)
		{
			Vector vector = new Vector(VectorSize);

			for (int i = 0; i < VectorSize; i++)
			{
				vector.Values[i] = Values[index, i];
			}

			return vector;
		}

		public Vector GetVectorColumn(int index)
		{
			Vector vector = new Vector(VectorsCount);

			for (int i = 0; i < VectorsCount; i++)
			{
				vector.Values[i] = Values[i, index];
			}

			return vector;
		}

		public Matrix Transpose()
		{
			Matrix matrixTransposed = new Matrix(VectorSize, VectorsCount);

			for (int i = 0; i < VectorsCount; i++)
			{
				for (int j = 0; j < VectorSize; j++)
				{
					matrixTransposed.Values[j, i] = Values[i, j];
				}
			}

			return matrixTransposed;
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < VectorsCount; i++)
			{
				for (int j = 0; j < VectorSize; j++)
				{
					Values[i, j] *= scalar;
				}
			}
		}

		public double GetDeterminant()
		{
			if (VectorsCount != VectorSize)
			{
				throw new Exception("Матрица не квадратная");
			}

			if (VectorSize == 1)
			{
				return Values[0, 0];
			}

			if (VectorSize == 2)
			{
				return Values[0, 0] * Values[1, 1] - Values[0, 1] * Values[1, 0];
			}

			double[,] values = new double[VectorsCount, VectorSize];
			Array.Copy(Values, values, Values.Length);

			double determinant = 0;

			for (int i = 0; i < VectorSize; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * Values[0, i] * GetMinor(i, values);
			}

			return determinant;
		}

		private static double GetMinor(int index, double[,] values1)
		{
			int values1Length = values1.GetLength(0);

			double[,] values2 = new double[values1Length - 1, values1Length - 1];
			int values2Length = values2.GetLength(0);

			for (int i = 0; i < values2Length; i++)
			{
				int nextIndexFlag = 0;

				for (int j = 0; j < values2Length; j++)
				{
					if (j == index)
					{
						nextIndexFlag++;
					}

					values2[i, j] = values1[i + 1, j + nextIndexFlag];
				}
			}

			if (values2Length == 1)
			{
				return values2[0, 0];
			}

			if (values2Length == 2)
			{
				return values2[0, 0] * values2[1, 1] - values2[0, 1] * values2[1, 0];
			}

			double determinant = 0;

			for (int i = 0; i < values2Length; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * values2[0, i] * GetMinor(i, values2);
			}

			return determinant;
		}

		public override string ToString()
		{
			string printResult = "{";

			for (int i = 0; i < VectorsCount; i++)
			{
				printResult += "{";

				for (int j = 0; j < VectorSize; j++)
				{
					printResult += Values[i, j];

					if (j < VectorSize - 1)
					{
						printResult += ", ";
					}
				}

				if (i < VectorsCount - 1)
				{
					printResult += "}, ";
				}
			}

			printResult += "}}";

			return printResult;
		}

		public Matrix MultiplyByVector(Vector vector)
		{
			if (VectorSize > 1 || VectorsCount != vector.GetSize())
			{
				throw new Exception("Умножаемая матрица не соответсвтует требованиям.");
			}

			Matrix matrix = new Matrix(VectorsCount, VectorsCount);

			for (int i = 0; i < VectorsCount; i++)
			{
				for (int j = 0; j < VectorsCount; j++)
				{
					matrix.Values[i, j] = Values[i, 0] * vector.Values[j];
				}
			}

			return matrix;
		}

		public void Add(Matrix matrix)
		{
			if (VectorsCount != matrix.VectorsCount || VectorSize != matrix.VectorSize)
			{
				throw new Exception("Складываемые матрицы не соотвествуют требованиям.");
			}

			for (int i = 0; i < VectorsCount; i++)
			{
				for (int j = 0; j < VectorSize; j++)
				{
					Values[i, j] += matrix.Values[i, j];
				}
			}
		}

		public void Subtract(Matrix matrix)
		{
			if (VectorsCount != matrix.VectorsCount || VectorSize != matrix.VectorSize)
			{
				throw new Exception("Вычитаемые матрицы не соотвествуют требованиям.");
			}

			matrix.MultiplyByScalar(-1);

			Add(matrix);
		}

		public static Matrix Addition(Matrix matrix1, Matrix matrix2)
		{
			Matrix resultAddition = new Matrix(matrix1);

			resultAddition.Add(matrix2);

			return resultAddition;
		}

		public static Matrix Subtraction(Matrix matrix1, Matrix matrix2)
		{
			Matrix resultSubtraction = new Matrix(matrix1);

			resultSubtraction.Subtract(matrix2);

			return resultSubtraction;
		}

		public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.VectorSize != matrix2.VectorsCount)
			{
				throw new Exception("Перемножаемые матрицы не соотвествуют требованиям.");
			}

			int matrix1VectorsCount = matrix1.VectorsCount;
			int matrix1VectorSize = matrix1.VectorSize;
			int matrix2VectorSize = matrix2.VectorSize;

			Matrix resultMultiplying = new Matrix(matrix1VectorsCount, matrix2VectorSize);

			for (int i = 0; i < matrix1VectorsCount; i++)
			{
				for (int j = 0; j < matrix2VectorSize; j++)
				{
					double sum = 0;

					for (int k = 0; k < matrix1VectorSize; k++)
					{
						sum += matrix1.Values[i, k] * matrix2.Values[k, j];
					}

					resultMultiplying.Values[i, j] = sum;
				}
			}

			return resultMultiplying;
		}
	}
}
