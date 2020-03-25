using System;
using Vectors;
using System.Text;

namespace Matrices
{
	class Matrix
	{
		private Vector[] valuesVectorsRows;

		public Matrix(int rowsCount, int columnsCount)
		{
			if (rowsCount <= 0)
			{
				throw new ArgumentException("Количество строк = " + rowsCount + " должно быть > 0", nameof(rowsCount));
			}

			if (columnsCount <= 0)
			{
				throw new ArgumentException("Количество столбцов  = " + columnsCount + "должно быть > 0", nameof(columnsCount));
			}

			valuesVectorsRows = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				valuesVectorsRows[i] = new Vector(columnsCount);
			}
		}

		public Matrix(Matrix matrix)
		{
			int vectorsCount = matrix.valuesVectorsRows.Length;
			valuesVectorsRows = new Vector[vectorsCount];

			Array.Copy(matrix.valuesVectorsRows, valuesVectorsRows, vectorsCount);
		}

		public Matrix(double[,] matrixValues)
		{
			int rowsCount = matrixValues.GetLength(0);
			int columnsCount = matrixValues.GetLength(1);

			if (rowsCount <= 0)
			{
				throw new RankException("Массив должен быть заполнен.");
			}

			valuesVectorsRows = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				double[] vectorValues = new double[columnsCount];

				for (int j = 0; j < columnsCount; j++)
				{
					vectorValues[j] = matrixValues[i, j];
				}

				valuesVectorsRows[i] = new Vector(vectorValues);
			}
		}

		public Matrix(Vector[] vectors)
		{
			int vectorsCount = vectors.Length;

			if (vectorsCount <= 0)
			{
				throw new ArgumentException("Количество векторов = " + vectorsCount + " должно быть > 0", nameof(vectorsCount));
			}

			int vectorMaxLength = 0;

			for (int i = 0; i < vectorsCount; i++)
			{
				vectorMaxLength = Math.Max(vectorMaxLength, vectors[i].GetSize());
			}

			valuesVectorsRows = new Vector[vectorsCount];

			for (int i = 0; i < vectorsCount; i++)
			{
				int currentVectorLength = vectors[i].GetSize();

				if (currentVectorLength == vectorMaxLength)
				{
					valuesVectorsRows[i] = vectors[i];
				}
				else
				{
					valuesVectorsRows[i] = new Vector(vectorMaxLength);

					for (int j = 0; j < currentVectorLength; j++)
					{
						valuesVectorsRows[i].SetComponent(j, vectors[i].GetComponent(j));
					}
				}
			}
		}

		public int GetRowsCount()
		{
			return valuesVectorsRows.GetLength(0);
		}

		public int GetColumnsCount()
		{
			return valuesVectorsRows.GetLength(1);
		}

		public void SetRow(int index, Vector vector)
		{
			int rowsCount = valuesVectorsRows.Length;
			int columnsCount = valuesVectorsRows[0].GetSize();
			int vectorLength = vector.GetSize();

			if (index < 0 || index >= rowsCount)
			{
				throw new IndexOutOfRangeException("Индекс строки не входит в диапазон матрицы = [0, " + rowsCount + "]. Индекс = " + index);
			}

			if (vectorLength != columnsCount)
			{
				throw new ArgumentException("Длина вектора = " + vectorLength + " должна быть равна длине векторов матрицы = " + columnsCount,
					nameof(vectorLength));
			}

			valuesVectorsRows[index] = vector;
		}

		public Vector GetRow(int index)
		{
			int rowsCount = valuesVectorsRows.Length;

			if (index < 0 || index >= rowsCount)
			{
				throw new IndexOutOfRangeException("Индекс строки не входит в диапазон матрицы = [0, " + rowsCount + "]. Индекс = " + index);
			}

			return valuesVectorsRows[index];
		}

		public Vector GetColumn(int index)
		{
			int columnsCount = valuesVectorsRows[0].GetSize();

			if (index >= columnsCount)
			{
				throw new IndexOutOfRangeException("Индекс столбца не входит в диапазон матрицы = [0, " + columnsCount + "]. Индекс = " + index);
			}

			int rowsCount = valuesVectorsRows.Length;

			double[] vectorValues = new double[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				vectorValues[i] = valuesVectorsRows[i].GetComponent(index);
			}

			Vector vector = new Vector(vectorValues);

			return vector;
		}

		public Matrix Transpose()
		{
			int rowsCount = valuesVectorsRows.Length;
			int columnsCount = valuesVectorsRows[0].GetSize();

			Matrix matrixTransposed = new Matrix(columnsCount, rowsCount);

			for (int i = 0; i < columnsCount; i++)
			{
				Vector vector = new Vector(rowsCount);

				for (int j = 0; j < rowsCount; j++)
				{
					vector.SetComponent(j, valuesVectorsRows[j].GetComponent(i));
				}

				matrixTransposed.valuesVectorsRows[i] = vector;
			}

			return matrixTransposed;
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < valuesVectorsRows.Length; i++)
			{
				valuesVectorsRows[i].MultiplyByScalar(scalar);
			}
		}

		public double GetDeterminant()
		{
			int rowsCount = valuesVectorsRows.Length;
			int columnsCount = valuesVectorsRows[0].GetSize();

			if (rowsCount != columnsCount)
			{
				throw new RankException("Матрица не квадратная. Количество строк = " + rowsCount +
					" должно быть равно количеству столбцов = " + columnsCount);
			}

			if (rowsCount == 1)
			{
				return valuesVectorsRows[0].GetComponent(0);
			}

			if (rowsCount == 2)
			{
				return valuesVectorsRows[0].GetComponent(0) * valuesVectorsRows[1].GetComponent(1) -
					valuesVectorsRows[0].GetComponent(1) * valuesVectorsRows[1].GetComponent(0);
			}

			double[,] matrixValues = new double[rowsCount, columnsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				for (int j = 0; j < columnsCount; j++)
				{
					matrixValues[i, j] = valuesVectorsRows[i].GetComponent(j);
				}
			}

			double determinant = 0;

			for (int i = 0; i < columnsCount; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * valuesVectorsRows[0].GetComponent(i) * GetMinor(i, matrixValues);
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
			int rowsCount = valuesVectorsRows.Length;

			printResult.Append("{");

			for (int i = 0; i < rowsCount - 1; i++)
			{
				printResult.Append(valuesVectorsRows[i] + ", ");
			}

			printResult.Append(valuesVectorsRows[rowsCount - 1] + "}");

			return printResult.ToString();
		}

		public Vector MultiplyByVector(Vector vector)
		{
			int rowsCount = valuesVectorsRows.Length;
			int vectorLength = vector.GetSize();

			if (rowsCount != vectorLength)
			{
				throw new ArgumentException("Умножаемая матрица не соответсвтует требованиям. Количество строк = " + rowsCount + " должно быть равно длине ветора = "
					+ vectorLength, nameof(vectorLength));
			}

			Vector vectorResulting = new Vector(rowsCount);

			for (int i = 0; i < rowsCount; i++)
			{
				vectorResulting.SetComponent(i, valuesVectorsRows[i].GetComponent(0) * vector.GetComponent(i));
			}

			return vectorResulting;
		}

		public void Add(Matrix matrix)
		{
			int currenMatrixRowsCount = valuesVectorsRows.Length;
			int additionMatrixRowsCount = matrix.valuesVectorsRows.Length;
			int currenMatrixColumnsCount = valuesVectorsRows[0].GetSize();
			int additionMatrixColumnsCount = matrix.valuesVectorsRows[0].GetSize();

			if (currenMatrixRowsCount != additionMatrixRowsCount)
			{
				throw new IndexOutOfRangeException("Количество строк текущей матрицы = " + currenMatrixRowsCount +
					" должно быть равно количеству строк складываемой матрицы = " + additionMatrixRowsCount);
			}

			if (currenMatrixColumnsCount != additionMatrixColumnsCount)
			{
				throw new IndexOutOfRangeException("Количество столбцов текущей матрицы = " + currenMatrixColumnsCount +
					" должно быть равно количеству столбцов складываемой матрицы = " + additionMatrixColumnsCount);
			}

			for (int i = 0; i < currenMatrixRowsCount; i++)
			{
				valuesVectorsRows[i].Add(matrix.valuesVectorsRows[i]);
			}
		}

		public void Subtract(Matrix matrix)
		{
			int currenMatrixRowsCount = valuesVectorsRows.Length;
			int substractionMatrixRowsCount = matrix.valuesVectorsRows.Length;
			int currenMatrixColumnsCount = valuesVectorsRows[0].GetSize();
			int substractionMatrixColumnsCount = matrix.valuesVectorsRows[0].GetSize();

			if (currenMatrixRowsCount != substractionMatrixRowsCount)
			{
				throw new IndexOutOfRangeException("Количество строк текущей матрицы = " + currenMatrixRowsCount +
					" должно быть равно количеству строк вычитаемой матрицы = " + substractionMatrixRowsCount);
			}

			if (currenMatrixColumnsCount != substractionMatrixColumnsCount)
			{
				throw new IndexOutOfRangeException("Количество столбцов текущей матрицы = " + currenMatrixColumnsCount +
					" должно быть равно количеству столбцов вычитаемой матрицы = " + substractionMatrixColumnsCount);
			}

			for (int i = 0; i < currenMatrixRowsCount; i++)
			{
				valuesVectorsRows[i].Subtract(matrix.valuesVectorsRows[i]);
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
			int matrix1RowsCount = matrix1.valuesVectorsRows.Length;
			int matrix2ColumnsCount = matrix2.valuesVectorsRows[0].GetSize();

			if (matrix1.valuesVectorsRows[0].GetSize() != matrix2.valuesVectorsRows.Length)
			{
				throw new IndexOutOfRangeException("Количество строк матрицы №1 = " + matrix1RowsCount +
					"должно быть равно количеству столбцов матрицы №2 = " + matrix2ColumnsCount);
			}

			Matrix resultMultiplying = new Matrix(matrix1RowsCount, matrix2ColumnsCount);

			for (int i = 0; i < matrix1RowsCount; i++)
			{
				for (int j = 0; j < matrix2ColumnsCount; j++)
				{
					double vectorComponent = Vector.GetScalarMultiplication(matrix1.valuesVectorsRows[i], matrix2.GetColumn(j));

					resultMultiplying.valuesVectorsRows[i].SetComponent(j, vectorComponent);
				}
			}

			return resultMultiplying;
		}
	}
}
