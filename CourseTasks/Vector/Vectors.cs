using System;

namespace Vectors
{
	class Vectors
	{
		public int N { get; set; }

		//public Vectors Vector { get; set; }

		public double[] Vector { get; set; }

		public Vectors(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(n));
			}

			N = n;

			this.Vector = new double[N];
		}

		public Vectors(Vectors vector) { this.Vector = vector.Vector; }

		public Vectors(double[] vectorsValues)
		{
			this.Vector = vectorsValues;
		}

		public Vectors(int n, double[] vector)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(n));
			}

			N = n;

			this.Vector = new double[N];

			int count = 0;

			foreach (int e in vector)
			{
				Vector[count] = e;
				count++;
			}

			if (N > vector.Length)
			{
				for (int i = vector.Length; i < N; i++)
				{
					Vector[i] = 0;
				}
			}
		}

		public int GetSize()
		{
			return Vector.Length;
		}

		public override string ToString()
		{
			return "{" + string.Join(",", Vector) + "}";
		}

		public void AdditionVectors(Vectors vector)
		{
			int vectorSize = vector.GetSize();
			int thisVectorSize = GetSize();

			if (vectorSize > thisVectorSize)
			{
				Vector = ResizeArray(Vector, vectorSize);
			}

			for (int i = 0; i < vectorSize; i++)
			{
				Vector[i] += vector.Vector[i];
			}
		}

		public void SubtractionVectors(Vectors vector)
		{
			int vectorSize = vector.GetSize();
			int thisVectorSize = GetSize();

			if (vectorSize > thisVectorSize)
			{
				Vector = ResizeArray(Vector, vectorSize);
			}

			for (int i = 0; i < vectorSize; i++)
			{
				Vector[i] -= vector.Vector[i];
			}
		}

		public void MultiplyVectorByScalar(double scalar)
		{
			for (int i = 0; i < GetSize(); i++)
			{
				Vector[i] *= scalar;
			}
		}

		public void ReverseVector()
		{
			for (int i = 0; i < GetSize(); i++)
			{
				Vector[i] *= -1;
			}
		}

		public double GetLength()
		{
			double squaresСoordinatesSum = 0;

			for (int i = 0; i < GetSize(); i++)
			{
				squaresСoordinatesSum += Math.Pow(Vector[i], 2);
			}

			return Math.Sqrt(squaresСoordinatesSum);
		}

		public static Vectors AddVectors(Vectors vector1, Vectors vector2)
		{
			int vector1Size = vector1.GetSize();
			int vector2Size = vector2.GetSize();

			double[] additionResult = new double[Math.Max(vector1Size, vector2Size)];

			for (int i = 0; i < Math.Min(vector1Size, vector2Size); i++)
			{
				additionResult[i] = vector1.Vector[i] + vector2.Vector[i];
			}

			if (vector1Size > vector2Size)
			{
				for (int i = vector2Size; i < vector1Size; i++)
				{
					additionResult[i] = vector1.Vector[i];
				}
			}
			else if (vector1Size < vector2Size)
			{
				for (int i = vector1Size; i < vector2Size; i++)
				{
					additionResult[i] = vector2.Vector[i];
				}
			}

			Vectors newVector = new Vectors(additionResult);

			return newVector;
		}

		public static Vectors SubtractVectors(Vectors vector1, Vectors vector2)
		{
			int vector1Size = vector1.GetSize();
			int vector2Size = vector2.GetSize();

			double[] subtractionResult = new double[Math.Max(vector1Size, vector2Size)];

			for (int i = 0; i < Math.Min(vector1Size, vector2Size); i++)
			{
				subtractionResult[i] = vector1.Vector[i] - vector2.Vector[i];
			}

			if (vector1Size > vector2Size)
			{
				for (int i = vector2Size; i < vector1Size; i++)
				{
					subtractionResult[i] = vector1.Vector[i];
				}
			}
			else if (vector1Size < vector2Size)
			{
				for (int i = vector1Size; i < vector2Size; i++)
				{
					subtractionResult[i] = -vector2.Vector[i];
				}
			}

			Vectors newVector = new Vectors(subtractionResult);

			return newVector;
		}

		public static double[] ResizeArray(double[] vector, int newSize)
		{
			double[] newVector = new double[newSize];

			for (int i = 0; i < vector.Length; i++)
			{
				newVector[i] = vector[i];
			}

			return newVector;
		}
	}
}
