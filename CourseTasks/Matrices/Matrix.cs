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
				throw new ArgumentException("Количество строк массива должно быть > 0.", nameof(rowsCount));
			}

			if (columnsCount == 0)
			{
				throw new ArgumentException("Количество столбцов массива должно быть > 0.", nameof(columnsCount));
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

			foreach (Vector vector in vectors)
			{
				vectorMaxLength = Math.Max(vectorMaxLength, vector.GetSize());
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
			if (index < 0 || index >= GetRowsCount())
			{
				throw new IndexOutOfRangeException("Индекс строки не входит в диапазон матрицы = [0, " + (GetRowsCount() - 1) +
					"]. Индекс = " + index);
			}

			int vectorLength = vector.GetSize();

			if (vectorLength != GetColumnsCount())
			{
				throw new ArgumentException("Количество элементов вектора = " + vectorLength +
					" должно быть равна количеству столбцов матрицы = " + GetColumnsCount(), nameof(vectorLength));
			}

			rows[index] = new Vector(vector);
		}

		public Vector GetRow(int index)
		{
			if (index < 0 || index >= GetRowsCount())
			{
				throw new IndexOutOfRangeException("Индекс строки не входит в диапазон матрицы = [0, " + (GetRowsCount() - 1) +
					"]. Индекс = " + index);
			}

			return new Vector(rows[index]);
		}

		public Vector GetColumn(int index)
		{
			if (index < 0 || index >= GetColumnsCount())
			{
				throw new IndexOutOfRangeException("Индекс столбца не входит в диапазон матрицы = [0, " + (GetColumnsCount() - 1) +
					"]. Индекс = " + index);
			}

			double[] vectorValues = new double[GetRowsCount()];

			for (int i = 0; i < GetRowsCount(); i++)
			{
				vectorValues[i] = rows[i].GetComponent(index);
			}

			return new Vector(vectorValues);
		}

		public void Transpose()
		{
			Vector[] vectors = new Vector[GetColumnsCount()];

			for (int i = 0; i < GetColumnsCount(); i++)
			{
				vectors[i] = GetColumn(i);
			}

			rows = vectors;
		}

		public void MultiplyByScalar(double scalar)
		{
			foreach (Vector row in rows)
			{
				row.MultiplyByScalar(scalar);
			}
		}

		public double GetDeterminant()
		{
			if (GetRowsCount() != GetColumnsCount())
			{
				throw new InvalidOperationException("Матрица не квадратная. Количество строк = " + GetRowsCount() +
					" должно быть равно количеству столбцов = " + GetColumnsCount());
			}

			double[,] matrixValues = new double[GetRowsCount(), GetColumnsCount()];

			for (int i = 0; i < GetRowsCount(); i++)
			{
				for (int j = 0; j < GetRowsCount(); j++)
				{
					matrixValues[i, j] = rows[i].GetComponent(j);
				}
			}

			return GetDeterminant(-1, matrixValues);
		}

		private static double GetDeterminant(int index, double[,] matrixValues)
		{
			double[,] matrixNewValues = GetValuesMatrixForCalcMinor(index, matrixValues);

			if (matrixNewValues.GetLength(0) == 1)
			{
				return matrixNewValues[0, 0];
			}

			if (matrixNewValues.GetLength(0) == 2)
			{
				return matrixNewValues[0, 0] * matrixNewValues[1, 1] - matrixNewValues[0, 1] * matrixNewValues[1, 0];
			}

			double determinant = 0;

			for (int i = 0; i < matrixNewValues.GetLength(0); i++)
			{
				determinant += Math.Pow(-1, i) * matrixNewValues[0, i] * GetDeterminant(i, matrixNewValues);
			}

			return determinant;
		}

		private static double[,] GetValuesMatrixForCalcMinor(int index, double[,] matrix)
		{
			//Если это исходная матрица, тогда возвращаем массив без изменений
			if (index == -1)
			{
				return matrix;
			}

			double[,] resultingMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

			for (int i = 0; i < resultingMatrix.GetLength(0); i++)
			{
				int nextIndexFlag = 0;

				for (int j = 0; j < resultingMatrix.GetLength(0); j++)
				{
					if (j == index)
					{
						nextIndexFlag++;
					}

					resultingMatrix[i, j] = matrix[i + 1, j + nextIndexFlag];
				}
			}

			return resultingMatrix;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append("{");

			for (int i = 0; i < GetRowsCount() - 1; i++)
			{
				stringBuilder
					.Append(rows[i])
					.Append(", ");
			}

			stringBuilder
				.Append(rows[GetRowsCount() - 1])
				.Append("}");

			return stringBuilder.ToString();
		}

		public Vector MultiplyByVector(Vector vector)
		{
			int vectorLength = vector.GetSize();

			if (GetColumnsCount() != vectorLength)
			{
				throw new ArgumentException("Количество столбцов матрицы = " + GetColumnsCount() +
					" должно быть равно количеству элементов вектора = " + vectorLength, nameof(vectorLength));
			}

			Vector resultingVector = new Vector(GetRowsCount());

			for (int i = 0; i < GetRowsCount(); i++)
			{
				resultingVector.SetComponent(i, Vector.GetScalarMultiplication(rows[i], vector));
			}

			return resultingVector;
		}

		public void Add(Matrix matrix)
		{
			if (GetRowsCount() != matrix.GetRowsCount())
			{
				throw new IndexOutOfRangeException("Количество строк текущей матрицы = " + GetRowsCount() +
					" должно быть равно количеству строк складываемой матрицы = " + matrix.GetRowsCount());
			}

			if (GetColumnsCount() != matrix.GetColumnsCount())
			{
				throw new IndexOutOfRangeException("Количество столбцов текущей матрицы = " + GetColumnsCount() +
					" должно быть равно количеству столбцов складываемой матрицы = " + matrix.GetColumnsCount());
			}

			for (int i = 0; i < GetRowsCount(); i++)
			{
				rows[i].Add(matrix.rows[i]);
			}
		}

		public void Subtract(Matrix matrix)
		{
			if (GetRowsCount() != matrix.GetRowsCount())
			{
				throw new IndexOutOfRangeException("Количество строк текущей матрицы = " + GetRowsCount() +
					" должно быть равно количеству строк вычитаемой матрицы = " + matrix.GetRowsCount());
			}

			if (GetColumnsCount() != matrix.GetColumnsCount())
			{
				throw new IndexOutOfRangeException("Количество столбцов текущей матрицы = " + GetColumnsCount() +
					" должно быть равно количеству столбцов вычитаемой матрицы = " + matrix.GetColumnsCount());
			}

			for (int i = 0; i < GetRowsCount(); i++)
			{
				rows[i].Subtract(matrix.rows[i]);
			}
		}

		public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.GetRowsCount() != matrix2.GetRowsCount())
			{
				throw new IndexOutOfRangeException("Количество строк матрицы №1 = " + matrix1.GetRowsCount() +
					" должно быть равно количеству строк матрицы №2 = " + matrix2.GetRowsCount());
			}

			if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
			{
				throw new IndexOutOfRangeException("Количество столбцов матрицы №1 = " + matrix1.GetColumnsCount() +
					" должно быть равно количеству столбцов матрицы №2 = " + matrix2.GetColumnsCount());
			}

			Matrix additionResult = new Matrix(matrix1);

			additionResult.Add(matrix2);

			return additionResult;
		}

		public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.GetRowsCount() != matrix2.GetRowsCount())
			{
				throw new IndexOutOfRangeException("Количество строк матрицы №1 = " + matrix1.GetRowsCount() +
					" должно быть равно количеству строк матрицы №2 = " + matrix2.GetRowsCount());
			}

			if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
			{
				throw new IndexOutOfRangeException("Количество столбцов матрицы №1 = " + matrix1.GetColumnsCount() +
					" должно быть равно количеству столбцов матрицы №2 = " + matrix2.GetColumnsCount());
			}

			Matrix subtractionResult = new Matrix(matrix1);

			subtractionResult.Subtract(matrix2);

			return subtractionResult;
		}

		public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.GetColumnsCount() != matrix2.GetRowsCount())
			{
				throw new ArgumentException("Количество столбцов матрицы №1 = " + matrix1.GetColumnsCount() +
					"должно быть равно количеству строк матрицы №2 = " + matrix2.GetRowsCount());
			}

			Matrix multiplyingResult = new Matrix(matrix1.GetRowsCount(), matrix2.GetColumnsCount());

			for (int i = 0; i < matrix1.GetRowsCount(); i++)
			{
				for (int j = 0; j < matrix2.GetColumnsCount(); j++)
				{
					double vectorComponent = Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j));

					multiplyingResult.rows[i].SetComponent(j, vectorComponent);
				}
			}

			return multiplyingResult;
		}
	}
}
