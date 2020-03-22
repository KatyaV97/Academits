using System;
using Vectors;
using System.Text;

namespace Matrices
{
	class Matrix
	{
		private Vector[] vectors;

		public Matrix(int rowsCount, int columnsCount)
		{
			if (rowsCount <= 0)
			{
				throw new ArgumentException("Количество строк должно быть > 0", nameof(rowsCount) + " = " + rowsCount);
			}

			if (columnsCount <= 0)
			{
				throw new ArgumentException("Количество столбцов должено быть > 0", nameof(columnsCount) + " = " + columnsCount);
			}

			vectors = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				vectors[i] = new Vector(columnsCount);
			}
		}

		public Matrix(Matrix matrix)
		{
			int vectorsCount = matrix.vectors.Length;
			vectors = new Vector[vectorsCount];

			Array.Copy(matrix.vectors, vectors, vectorsCount);
		}

		public Matrix(double[,] matrixValues)
		{
			int rowsCount = matrixValues.GetLength(0);
			int columnsCount = matrixValues.GetLength(1);

			if (rowsCount <= 0)
			{
				throw new ArgumentException("Массив должен быть заполнен");
			}

			vectors = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				double[] vectorValues = new double[columnsCount];

				for (int j = 0; j < columnsCount; j++)
				{
					vectorValues[j] = matrixValues[i, j];
				}

				vectors[i] = new Vector(vectorValues);
			}
		}

		public Matrix(Vector[] vectors)
		{
			this.vectors = vectors;
		}

		public int GetRowsCount()
		{
			return vectors.GetLength(0);
		}

		public int GetColumnsCount()
		{
			return vectors.GetLength(1);
		}

		public void SetRow(int index, Vector vector)
		{
			int rowsCount = vectors.Length;
			int columnsCount = vectors[0].GetSize();

			if (index > rowsCount)
			{
				throw new ArgumentException("Индекс находится вне границ матрицы.", nameof(index) + " = " + index);
			}

			int vectorLength = vector.GetSize();

			if (vectorLength > columnsCount)
			{
				throw new ArgumentException("Вектор не должен быть длиннее количества столбцов матрицы",
					nameof(vectorLength) + " = " + vectorLength);
			}

			vectors[index] = vector;
		}

		public Vector GetRow(int index)
		{
			if (index >= vectors.GetLength(0))
			{
				throw new ArgumentException("Индекс должен быть меньше количества строк матрицы.",
					nameof(index) + " = " + index);
			}

			return vectors[index];
		}

		public Vector GetColumn(int index)
		{
			if (index >= vectors[0].GetSize())
			{
				throw new ArgumentException("Индекс должен быть меньше количества столбцов матрицы.",
					nameof(index) + " = " + index);
			}

			int rowsCount = vectors.Length;

			double[] vectorValues = new double[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				vectorValues[i] = vectors[i].GetComponent(index);
			}

			Vector vector = new Vector(vectorValues);

			return vector;
		}

		public Matrix Transpose()
		{
			int rowsCount = vectors.Length;
			int columnsCount = vectors[0].GetSize();

			Matrix matrixTransposed = new Matrix(columnsCount, rowsCount);

			for (int i = 0; i < columnsCount; i++)
			{
				Vector vector = new Vector(rowsCount);

				for (int j = 0; j < rowsCount; j++)
				{
					vector.SetComponent(j, vectors[j].GetComponent(i));
				}

				matrixTransposed.vectors[i] = vector;
			}

			return matrixTransposed;
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < vectors.Length; i++)
			{
				vectors[i].MultiplyByScalar(scalar);
			}
		}
		/*
		public double GetDeterminant()
		{
			int rowsCount = vectors.Length;
			int columnsCount = vectors[0].GetSize();
			if (rowsCount != columnsCount)
			{
				throw new Exception("Матрица не квадратная");
			}

			if (rowsCount == 1)
			{
				return vectors[0].GetComponent(0);
			}

			if (rowsCount == 2)
			{
				return vectors[0].GetComponent(0) * vectors[1].GetComponent(1) -
					vectors[0].GetComponent(1) * vectors[1].GetComponent(0);
			}

			double[,] values = new double[rowsCount, columnsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				Array.Copy(vectors[i], values[i], columnsCount);
			}


			double determinant = 0;

			for (int i = 0; i < VectorSize; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * this.vectors[0, i] * GetMinor(i, values);
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
		*/
		public override string ToString()
		{
			StringBuilder printResult = new StringBuilder();
			int rowsCount = vectors.Length;

			printResult.Append("{");

			for (int i = 0; i < rowsCount - 1; i++)
			{
				printResult.Append(vectors[i] + ", ");
			}

			printResult.Append(vectors[rowsCount - 1] + "}");

			return printResult.ToString();
		}

		public Matrix MultiplyByVector(Vector vector)
		{
			int rowsCount = vectors.Length;
			int columnsCount = vectors[0].GetSize();

			if (columnsCount > 1 || rowsCount != vector.GetSize())
			{
				throw new Exception("Умножаемая матрица не соответсвтует требованиям.");
			}

			Matrix matrix = new Matrix(rowsCount, rowsCount);

			for (int i = 0; i < rowsCount; i++)
			{
				Vector multiplyingVector = new Vector(vector);
				multiplyingVector.MultiplyByScalar(vectors[i].GetComponent(0));

				matrix.vectors[i] = multiplyingVector;
			}

			return matrix;
		}

		public void Add(Matrix matrix)
		{
			int rowsCount = vectors.Length;

			if (rowsCount != matrix.vectors.Length || vectors[0].GetSize() != matrix.vectors[0].GetSize())
			{
				throw new Exception("Складываемые матрицы не соотвествуют требованиям.");
			}

			for (int i = 0; i < rowsCount; i++)
			{
				vectors[i].Add(matrix.vectors[i]);
			}
		}

		public void Subtract(Matrix matrix)
		{
			int rowsCount = vectors.Length;

			if (rowsCount != matrix.vectors.Length || vectors[0].GetSize() != matrix.vectors[0].GetSize())
			{
				throw new Exception("Вычитаемые матрицы не соотвествуют требованиям.");
			}

			for (int i = 0; i < rowsCount; i++)
			{
				vectors[i].Subtract(matrix.vectors[i]);
			}
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
			int matrix1RowsCount = matrix1.vectors.Length;
			int matrix1ColumnsCount = matrix1.vectors[0].GetSize();
			int matrix2RowsCount = matrix2.vectors.Length;
			int matrix2ColumnsCount = matrix2.vectors[0].GetSize();

			if (matrix1ColumnsCount != matrix2RowsCount)
			{
				throw new Exception("Перемножаемые матрицы не соотвествуют требованиям.");
			}

			Matrix resultMultiplying = new Matrix(matrix1RowsCount, matrix2ColumnsCount);

			for (int i = 0; i < matrix1RowsCount; i++)
			{
				for (int j = 0; j < matrix2ColumnsCount; j++)
				{
					double vectorComponent = Vector.GetScalarMultiplication(matrix1.vectors[i], matrix2.GetColumn(j));

					resultMultiplying.vectors[i].SetComponent(j, vectorComponent);
				}
			}

			return resultMultiplying;
		}

	}
}
