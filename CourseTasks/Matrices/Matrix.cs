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
			if(VectorsCount!=VectorSize)
			{
				throw new Exception("Матрица не квадратная", nameof(VectorsCount));
			}

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
	}
}
