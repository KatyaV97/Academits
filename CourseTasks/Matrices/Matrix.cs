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
			int matrixLength1 = matrix.MatrixValues.GetLength(0);
			int matrixLength2 = matrix.MatrixValues.GetLength(1);

			MatrixValues = new double[matrixLength1, matrixLength2];

			Array.Copy(matrix.MatrixValues, MatrixValues, matrix.MatrixValues.Length);
		}

		public Matrix(double[,] matrixValues)
		{
			int matrixLength1 = matrixValues.GetLength(0);
			int matrixLength2 = matrixValues.GetLength(1);

			MatrixValues = new double[matrixLength1, matrixLength2];

			Array.Copy(matrixValues, MatrixValues, matrixValues.Length);
		}

		public Matrix(Vector[] vectors)
		{
			int vectorsCount = vectors.Length;

			int vectorMaxSize = 0;

			for (int i = 0; i < vectors.Length; i++)
			{
				vectorMaxSize = Math.Max(vectorMaxSize, vectors[i].GetSize());
			}

			MatrixValues = new double[vectorMaxSize, vectorsCount];

			for (int i = 0; i < vectorsCount; i++)
			{
				for (int j = 0; j < vectors[i].VectorValues.Length; j++)
				{
					MatrixValues[i, j] = vectors[i].VectorValues[j];
				}
			}
		}


	}
}
