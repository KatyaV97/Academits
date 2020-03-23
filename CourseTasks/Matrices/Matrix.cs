using System;
using Vectors;
using System.Text;

namespace Matrices
{
	class Matrix
	{
		private Vector[] rowsVectors;

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

			rowsVectors = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				rowsVectors[i] = new Vector(columnsCount);
			}
		}

		public Matrix(Matrix matrix)
		{
			int vectorsCount = matrix.rowsVectors.Length;
			rowsVectors = new Vector[vectorsCount];

			Array.Copy(matrix.rowsVectors, rowsVectors, vectorsCount);
		}

		public Matrix(double[,] matrixValues)
		{
			int rowsCount = matrixValues.GetLength(0);
			int columnsCount = matrixValues.GetLength(1);

			if (rowsCount <= 0)
			{
				throw new ArgumentException("Массив должен быть заполнен.", nameof(rowsCount) + " = " + rowsCount);
			}

			rowsVectors = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				double[] vectorValues = new double[columnsCount];

				for (int j = 0; j < columnsCount; j++)
				{
					vectorValues[j] = matrixValues[i, j];
				}

				rowsVectors[i] = new Vector(vectorValues);
			}
		}

		public Matrix(Vector[] vectors)
		{
			int vectorsCount = vectors.Length;

			if (vectorsCount <= 0)
			{
				throw new ArgumentException("Количество векторов должен быть > 0", nameof(vectorsCount) + " = " + vectorsCount);
			}

			int vectorMaxLength = 0;

			for (int i = 0; i < vectorsCount; i++)
			{
				vectorMaxLength = Math.Max(vectorMaxLength, vectors[i].GetSize());
			}

			rowsVectors = new Vector[vectorsCount];

			for (int i = 0; i < vectorsCount; i++)
			{
				int currentVectorLength = vectors[i].GetSize();

				if (currentVectorLength == vectorMaxLength)
				{
					rowsVectors[i] = vectors[i];
				}
				else
				{
					rowsVectors[i] = new Vector(vectorMaxLength);

					for (int j = 0; j < currentVectorLength; j++)
					{
						rowsVectors[i].SetComponent(j, vectors[i].GetComponent(j));
					}
				}
			}
		}

		public int GetRowsCount()
		{
			return rowsVectors.GetLength(0);
		}

		public int GetColumnsCount()
		{
			return rowsVectors.GetLength(1);
		}

		public void SetRow(int index, Vector vector)
		{
			int rowsCount = rowsVectors.Length;
			int columnsCount = rowsVectors[0].GetSize();
			int vectorLength = vector.GetSize();

			if (index < 0 || index >= rowsCount)
			{
				throw new ArgumentException("Индекс строки не входит в диапазон матрицы = [0, " + rowsCount + "]",
					nameof(index) + " = " + index);
			}

			if (vectorLength != columnsCount)
			{
				throw new ArgumentException("Вектор должен быть равен длине векторов матрицы = " + columnsCount,
					nameof(vectorLength) + " = " + vectorLength);
			}

			rowsVectors[index] = vector;
		}

		public Vector GetRow(int index)
		{
			int rowsCount = rowsVectors.Length;

			if (index < 0 || index >= rowsCount)
			{
				throw new ArgumentException("Индекс строки не входит в диапазон матрицы = [0, " + rowsCount + "]",
					nameof(index) + " = " + index);
			}

			return rowsVectors[index];
		}

		public Vector GetColumn(int index)
		{
			int columnsCount = rowsVectors[0].GetSize();

			if (index >= columnsCount)
			{
				throw new ArgumentException("Индекс столбца не входит в диапазон матрицы = [0, " + columnsCount + "]",
					nameof(index) + " = " + index);
			}

			int rowsCount = rowsVectors.Length;

			double[] vectorValues = new double[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				vectorValues[i] = rowsVectors[i].GetComponent(index);
			}

			Vector vector = new Vector(vectorValues);

			return vector;
		}

		public Matrix Transpose()
		{
			int rowsCount = rowsVectors.Length;
			int columnsCount = rowsVectors[0].GetSize();

			Matrix matrixTransposed = new Matrix(columnsCount, rowsCount);

			for (int i = 0; i < columnsCount; i++)
			{
				Vector vector = new Vector(rowsCount);

				for (int j = 0; j < rowsCount; j++)
				{
					vector.SetComponent(j, rowsVectors[j].GetComponent(i));
				}

				matrixTransposed.rowsVectors[i] = vector;
			}

			return matrixTransposed;
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < rowsVectors.Length; i++)
			{
				rowsVectors[i].MultiplyByScalar(scalar);
			}
		}

		public double GetDeterminant()
		{
			int rowsCount = rowsVectors.Length;
			int columnsCount = rowsVectors[0].GetSize();

			if (rowsCount != columnsCount)
			{
				throw new IndexOutOfRangeException("Матрица не квадратная. Количесвто строк = " + rowsCount +
					" должно быть равно количеству столбцов = " + columnsCount);
			}

			if (rowsCount == 1)
			{
				return rowsVectors[0].GetComponent(0);
			}

			if (rowsCount == 2)
			{
				return rowsVectors[0].GetComponent(0) * rowsVectors[1].GetComponent(1) -
					rowsVectors[0].GetComponent(1) * rowsVectors[1].GetComponent(0);
			}

			double[,] matrixValues = new double[rowsCount, columnsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				for (int j = 0; j < columnsCount; j++)
				{
					matrixValues[i, j] = rowsVectors[i].GetComponent(j);
				}
			}

			double determinant = 0;

			for (int i = 0; i < columnsCount; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * rowsVectors[0].GetComponent(i) * GetMinor(i, matrixValues);
			}

			return determinant;
		}

		private static double GetMinor(int index, double[,] matrixValues)
		{
			int rowsCount = matrixValues.GetLength(0);

			double[,] matrixValuesForGetMinor = new double[rowsCount - 1, rowsCount - 1];
			int values2Length = matrixValuesForGetMinor.GetLength(0);

			for (int i = 0; i < values2Length; i++)
			{
				int nextIndexFlag = 0;

				for (int j = 0; j < values2Length; j++)
				{
					if (j == index)
					{
						nextIndexFlag++;
					}

					matrixValuesForGetMinor[i, j] = matrixValues[i + 1, j + nextIndexFlag];
				}
			}

			if (values2Length == 1)
			{
				return matrixValuesForGetMinor[0, 0];
			}

			if (values2Length == 2)
			{
				return matrixValuesForGetMinor[0, 0] * matrixValuesForGetMinor[1, 1] - matrixValuesForGetMinor[0, 1] * matrixValuesForGetMinor[1, 0];
			}

			double determinant = 0;

			for (int i = 0; i < values2Length; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * matrixValuesForGetMinor[0, i] * GetMinor(i, matrixValuesForGetMinor);
			}

			return determinant;
		}

		public override string ToString()
		{
			StringBuilder printResult = new StringBuilder();
			int rowsCount = rowsVectors.Length;

			printResult.Append("{");

			for (int i = 0; i < rowsCount - 1; i++)
			{
				printResult.Append(rowsVectors[i] + ", ");
			}

			printResult.Append(rowsVectors[rowsCount - 1] + "}");

			return printResult.ToString();
		}

		public Matrix MultiplyByVector(Vector vector)
		{
			int rowsCount = rowsVectors.Length;
			int columnsCount = rowsVectors[0].GetSize();
			int vectorLength = vector.GetSize();

			if (columnsCount > 1 || rowsCount != vectorLength)
			{
				throw new Exception("Умножаемая матрица не соответсвтует требованиям. Количество столбцов = " +
					columnsCount + " должно быть > 1 и количесвто строк = " + rowsCount + " должно быть равно длине ветора = "
					+ vectorLength);
			}

			Matrix matrix = new Matrix(rowsCount, rowsCount);

			for (int i = 0; i < rowsCount; i++)
			{
				Vector multiplyingVector = new Vector(vector);
				multiplyingVector.MultiplyByScalar(rowsVectors[i].GetComponent(0));

				matrix.rowsVectors[i] = multiplyingVector;
			}

			return matrix;
		}

		public void Add(Matrix matrix)
		{
			int currenMatrixRowsCount = rowsVectors.Length;
			int additionMatrixRowsCount = matrix.rowsVectors.Length;
			int currenMatrixColumnsCount = rowsVectors[0].GetSize();
			int additionMatrixColumnsCount = matrix.rowsVectors[0].GetSize();

			if (currenMatrixRowsCount != additionMatrixRowsCount)
			{
				throw new Exception("Количество строк текущей матрицы = " + currenMatrixRowsCount +
					" должно быть равно количеству строк складываемой матрицы = " + additionMatrixRowsCount);
			}

			if (currenMatrixColumnsCount != additionMatrixColumnsCount)
			{
				throw new Exception("Количество столбцов текущей матрицы = " + currenMatrixColumnsCount +
					" должно быть равно количеству стобцов складываемой матрицы = " + additionMatrixColumnsCount);
			}

			for (int i = 0; i < currenMatrixRowsCount; i++)
			{
				rowsVectors[i].Add(matrix.rowsVectors[i]);
			}
		}

		public void Subtract(Matrix matrix)
		{
			int currenMatrixRowsCount = rowsVectors.Length;
			int substractionMatrixRowsCount = matrix.rowsVectors.Length;
			int currenMatrixColumnsCount = rowsVectors[0].GetSize();
			int substractionMatrixColumnsCount = matrix.rowsVectors[0].GetSize();

			if (currenMatrixRowsCount != substractionMatrixRowsCount)
			{
				throw new IndexOutOfRangeException("Количество строк текущей матрицы = " + currenMatrixRowsCount +
					" должно быть равно количеству строк вычитаемой матрицы = " + substractionMatrixRowsCount);
			}

			if (currenMatrixColumnsCount != substractionMatrixColumnsCount)
			{
				throw new IndexOutOfRangeException("Количество столбцов текущей матрицы = " + currenMatrixColumnsCount +
					" должно быть равно количеству стобцов вычитаемой матрицы = " + substractionMatrixColumnsCount);
			}

			for (int i = 0; i < currenMatrixRowsCount; i++)
			{
				rowsVectors[i].Subtract(matrix.rowsVectors[i]);
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
			int matrix1RowsCount = matrix1.rowsVectors.Length;
			int matrix2ColumnsCount = matrix2.rowsVectors[0].GetSize();

			if (matrix1.rowsVectors[0].GetSize() != matrix2.rowsVectors.Length)
			{
				throw new IndexOutOfRangeException("Количество строк матрицы №1 = " + matrix1RowsCount +
					"должно быть равно = количеству столбцов матрицы №2 = " + matrix2ColumnsCount);
			}

			Matrix resultMultiplying = new Matrix(matrix1RowsCount, matrix2ColumnsCount);

			for (int i = 0; i < matrix1RowsCount; i++)
			{
				for (int j = 0; j < matrix2ColumnsCount; j++)
				{
					double vectorComponent = Vector.GetScalarMultiplication(matrix1.rowsVectors[i], matrix2.GetColumn(j));

					resultMultiplying.rowsVectors[i].SetComponent(j, vectorComponent);
				}
			}

			return resultMultiplying;
		}
	}
}
