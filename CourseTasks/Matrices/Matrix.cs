using System;
using System.Text;
using Vectors;

namespace Matrices
{
	class Matrix
	{
		private Vector[] rows;

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

			rows = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				rows[i] = new Vector(columnsCount);
			}
		}

		public Matrix(Matrix matrix)
		{
			int vectorsCount = matrix.rows.Length;
			rows = new Vector[vectorsCount];

			for (int i = 0; i < vectorsCount; i++)
			{
				rows[i] = new Vector(matrix.rows[i]);
			}
		}

		public Matrix(double[,] matrixValues)
		{
			int rowsCount = matrixValues.GetLength(0);
			int columnsCount = matrixValues.GetLength(1);

			if (rowsCount == 0)
			{
				throw new RankException("Количество строк массива должно быть > 0.");
			}

			if (columnsCount == 0)
			{
				throw new RankException("Количество столбцов массива должно быть > 0.");
			}

			rows = new Vector[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				double[] vectorValues = new double[columnsCount];

				for (int j = 0; j < columnsCount; j++)
				{
					vectorValues[j] = matrixValues[i, j];
				}

				rows[i] = new Vector(vectorValues);
			}
		}

		public Matrix(Vector[] vectors)
		{
			if (vectors.Length == 0)
			{
				throw new ArgumentException("Количество векторов = " + vectors.Length + " должно быть > 0", nameof(vectors.Length));
			}

			int vectorMaxLength = 0;

			for (int i = 0; i < vectors.Length; i++)
			{
				vectorMaxLength = Math.Max(vectorMaxLength, vectors[i].GetSize());
			}

			rows = new Vector[vectors.Length];

			for (int i = 0; i < vectors.Length; i++)
			{
				int currentVectorLength = vectors[i].GetSize();

				if (currentVectorLength == vectorMaxLength)
				{
					rows[i] = new Vector(vectors[i]);
				}
				else
				{
					rows[i] = new Vector(vectorMaxLength);

					for (int j = 0; j < currentVectorLength; j++)
					{
						rows[i].SetComponent(j, vectors[i].GetComponent(j));
					}
				}
			}
		}

		public int GetRowsCount()
		{
			return rows.Length;
		}

		public int GetColumnsCount()
		{
			return rows[0].GetSize();
		}

		public void SetRow(int index, Vector vector)
		{
			int rowsCount = GetRowsCount();
			int columnsCount = GetColumnsCount();
			int vectorLength = vector.GetSize();

			if (index < 0 || index >= rowsCount)
			{
				throw new IndexOutOfRangeException("Индекс строки не входит в диапазон матрицы = [0, " + (rowsCount - 1) +
					"]. Индекс = " + index);
			}

			if (vectorLength != columnsCount)
			{
				throw new ArgumentException("Длина вектора = " + vectorLength + " должна быть равна длине векторов матрицы = " +
					columnsCount, nameof(vectorLength));
			}

			rows[index] = new Vector(vector);
		}

		public Vector GetRow(int index)
		{
			int rowsCount = GetRowsCount();

			if (index < 0 || index >= rowsCount)
			{
				throw new IndexOutOfRangeException("Индекс строки не входит в диапазон матрицы = [0, " + (rowsCount - 1) +
					"]. Индекс = " + index);
			}

			return new Vector(rows[index]);
		}

		public Vector GetColumn(int index)
		{
			int columnsCount = GetColumnsCount();

			if (index >= columnsCount)
			{
				throw new IndexOutOfRangeException("Индекс столбца не входит в диапазон матрицы = [0, " + (columnsCount - 1) +
					"]. Индекс = " + index);
			}

			int rowsCount = rows.Length;

			double[] vectorValues = new double[rowsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				vectorValues[i] = rows[i].GetComponent(index);
			}

			Vector vector = new Vector(vectorValues);

			return vector;
		}

		public void Transpose()
		{
			Matrix tempMatrix = new Matrix(rows);

			if (GetColumnsCount() > GetRowsCount() || GetColumnsCount() < GetRowsCount())
			{
				Array.Resize(ref rows, GetColumnsCount());
			}

			for (int i = 0; i < tempMatrix.GetColumnsCount(); i++)
			{
				rows[i] = tempMatrix.GetColumn(i);
			}
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < rows.Length; i++)
			{
				rows[i].MultiplyByScalar(scalar);
			}
		}

		public double GetDeterminant()
		{
			int rowsCount = rows.Length;
			int columnsCount = rows[0].GetSize();

			if (rowsCount != columnsCount)
			{
				throw new RankException("Матрица не квадратная. Количество строк = " + rowsCount +
					" должно быть равно количеству столбцов = " + columnsCount);
			}

			if (rowsCount == 1)
			{
				return rows[0].GetComponent(0);
			}

			if (rowsCount == 2)
			{
				return rows[0].GetComponent(0) * rows[1].GetComponent(1) -
					rows[0].GetComponent(1) * rows[1].GetComponent(0);
			}

			double[,] matrixValues = new double[rowsCount, columnsCount];

			for (int i = 0; i < rowsCount; i++)
			{
				for (int j = 0; j < columnsCount; j++)
				{
					matrixValues[i, j] = rows[i].GetComponent(j);
				}
			}

			double determinant = 0;

			for (int i = 0; i < columnsCount; i++)
			{
				determinant += Math.Pow(-1, 1 + i) * rows[0].GetComponent(i) * GetMinor(i, matrixValues);
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
			int rowsCount = rows.Length;

			printResult.Append("{");

			for (int i = 0; i < rowsCount - 1; i++)
			{
				printResult.Append(rows[i] + ", ");
			}

			printResult.Append(rows[rowsCount - 1] + "}");

			return printResult.ToString();
		}

		public Vector MultiplyByVector(Vector vector)
		{
			int columnsCount = rows[0].GetSize();
			int rowsCount = rows.Length;
			int vectorLength = vector.GetSize();

			if (columnsCount != vectorLength)
			{
				throw new ArgumentException("Количество столбцов матрицы = " + columnsCount + " должно быть равно длине вектора = "
					+ vectorLength, nameof(vectorLength));
			}

			Vector vectorResulting = new Vector(rowsCount);

			for (int i = 0; i < rowsCount; i++)
			{
				vectorResulting.SetComponent(i, Vector.GetScalarMultiplication(rows[i], vector));
			}

			return vectorResulting;
		}

		public void Add(Matrix matrix)
		{
			int currenMatrixRowsCount = rows.Length;
			int additionMatrixRowsCount = matrix.rows.Length;
			int currenMatrixColumnsCount = rows[0].GetSize();
			int additionMatrixColumnsCount = matrix.rows[0].GetSize();

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
				rows[i].Add(matrix.rows[i]);
			}
		}

		public void Subtract(Matrix matrix)
		{
			int currenMatrixRowsCount = rows.Length;
			int substractionMatrixRowsCount = matrix.rows.Length;
			int currenMatrixColumnsCount = rows[0].GetSize();
			int substractionMatrixColumnsCount = matrix.rows[0].GetSize();

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
				rows[i].Subtract(matrix.rows[i]);
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
			int matrix1RowsCount = matrix1.rows.Length;
			int matrix2ColumnsCount = matrix2.rows[0].GetSize();

			if (matrix1.rows[0].GetSize() != matrix2.rows.Length)
			{
				throw new IndexOutOfRangeException("Количество строк матрицы №1 = " + matrix1RowsCount +
					"должно быть равно количеству столбцов матрицы №2 = " + matrix2ColumnsCount);
			}

			Matrix resultMultiplying = new Matrix(matrix1RowsCount, matrix2ColumnsCount);

			for (int i = 0; i < matrix1RowsCount; i++)
			{
				for (int j = 0; j < matrix2ColumnsCount; j++)
				{
					double vectorComponent = Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j));

					resultMultiplying.rows[i].SetComponent(j, vectorComponent);
				}
			}

			return resultMultiplying;
		}
	}
}
