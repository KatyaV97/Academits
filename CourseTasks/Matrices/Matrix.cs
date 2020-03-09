using System;
using Vectors;

namespace Matrices
{
	class Matrix
	{
		public int N { get; set; }

		public int M { get; set; }

		public double[,] MatrixValues { get; set; }

		public Matrix(int n, int m)
		{
			M = m;
			N = n;

			MatrixValues = new double[N, M];
		}

		public Matrix(Matrix matrix)
		{
			N = matrix.MatrixValues.GetLength(0);
			M = matrix.MatrixValues.GetLength(1);

			MatrixValues = new double[N, M];

			Array.Copy(matrix.MatrixValues, MatrixValues, matrix.MatrixValues.Length);
		}

		public Matrix(double[,] matrixValues)
		{
			N = matrixValues.GetLength(0);
			M = matrixValues.GetLength(1);

			MatrixValues = new double[N, M];

			Array.Copy(matrixValues, MatrixValues, matrixValues.Length);
		}

		public Matrix(Vector[] vectors)
		{
			M = vectors.Length;

			N = 0;

			for (int i = 0; i < vectors.Length; i++)
			{
				N = Math.Max(N, vectors[i].GetSize());
			}

			MatrixValues = new double[N, M];

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < vectors[i].Values.Length; j++)
				{
					MatrixValues[i, j] = vectors[i].Values[j];
				}
			}
		}

		public int GetSizeN()
		{
			return N;
		}

		public int GetSizeM()
		{
			return M;
		}

		public void SetVector(Vector vector, int index)
		{
			for (int i = 0; i < vector.GetSize(); i++)
			{
				MatrixValues[i, index] = vector.VectorValues[i];
			}
		}

		public Vector GetVectorRow(int index)
		{
			int vectorSize = GetSizeN();

			Vector vector = new Vector(vectorSize);

			for (int i = 0; i < vectorSize; i++)
			{
				vector.VectorValues[i] = MatrixValues[i, index];
			}

			return vector;
		}

		public Vector GetVectorColumn(int index)
		{
			int vectorSize = GetSizeM();

			Vector vector = new Vector(vectorSize);

			for (int i = 0; i < vectorSize; i++)
			{
				vector.VectorValues[i] = MatrixValues[index, i];
			}

			return vector;
		}

		public void Transpose()
		{
			Matrix matrixTransposed = MatrixValues[,];

			for (int i = 0; i < M; i++)
			{
				for (int j = 0; j < N; j++)
				{
					MatrixValues[i, j] = matrixTransposed.MatrixValues[j, i];
				}
			}
		}

	}
}
