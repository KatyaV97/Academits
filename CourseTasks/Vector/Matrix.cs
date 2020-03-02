using System;

namespace Vectors
{
	class Matrix : Vector
	{
		public int M { get; set; }

		public double[,] MatrixValues { get; set; }


		public Matrix(int n, int m) : base(n)
		{
			M = m;

			MatrixValues = new double[N, M];
		}

		public Matrix(Matrix matrix, Vector vector) : base(vector)
		{
			int vectorsCount = matrix.MatrixValues.GetLength(1);

			MatrixValues = new double[VectorValues.Length, vectorsCount];

			Array.Copy(matrix.MatrixValues, MatrixValues, vectorsCount);
		}

		public Matrix(double[,] matrixValues, double[] vectorValues) : base(vectorValues)
		{
			int vectorsCount = matrixValues.GetLength(1);

			MatrixValues = new double[VectorValues.Length, vectorsCount];

			Array.Copy(matrixValues, MatrixValues, vectorsCount);
		}

		public Matrix(Vector[] Vector, Vector vector) : base(vector)
		{
			//int vectorsCount = Vector.Length;

			for (int i = 0; i < Vector.Length; i++)
			{
				for (int j = 0; j < Vector[i].VectorValues.Length; j++)
				{
					MatrixValues[0, i] = Vector[i].VectorValues[j];
				}
			}

		}


	}
}
