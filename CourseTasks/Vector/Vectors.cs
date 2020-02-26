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
			int vectorMaxSize = Math.Max(GetSize(), vector.GetSize());
			int vectorMinSize = Math.Min(GetSize(), vector.GetSize());

			for (int i = 0; i < vectorMinSize; i++)
			{
				Vector[i] += vector.Vector[i];
			}

			if (vector.GetSize() > GetSize())
			{
				double[] newVector = Vector;

				Array.Resize(ref newVector, vectorMaxSize);

				Vector = newVector;

				for (int i = vectorMinSize; i < vectorMaxSize; i++)
				{
					Vector[i] = vector.Vector[i];
				}
			}
		}

		public void SubtractionVectors(Vectors vector)
		{
			int vectorMaxSize = Math.Max(GetSize(), vector.GetSize());
			int vectorMinSize = Math.Min(GetSize(), vector.GetSize());

			for (int i = 0; i < vectorMinSize; i++)
			{
				Vector[i] = Vector[i] - vector.Vector[i];
			}

			if (vector.GetSize() > GetSize())
			{
				for (int i = vectorMinSize; i < vectorMaxSize; i++)
				{
					Vector[i] = 0 - vector.Vector[i];
				}
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
			int vectorMaxSize = Math.Max(vector1.GetSize(), vector2.GetSize());
			int vectorMinSize = Math.Min(vector1.GetSize(), vector2.GetSize());

			double[] additionResult = new double[vectorMaxSize];

			for (int i = 0; i < vectorMinSize; i++)
			{
				additionResult[i] = vector1.Vector[i] + vector2.Vector[i];
			}

			if (vector1.GetSize() > vector2.GetSize())
			{
				for (int i = vectorMinSize; i < vectorMaxSize; i++)
				{
					additionResult[i] = vector1.Vector[i];
				}
			}
			else if (vector2.GetSize() > vector1.GetSize())
			{
				for (int i = vectorMinSize; i < vectorMaxSize; i++)
				{
					additionResult[i] = vector2.Vector[i];
				}
			}

			Vectors newVector = new Vectors(additionResult);

			return newVector;
		}

		public static Vectors SubtractVectors(Vectors vector1, Vectors vector2)
		{
			int vectorMaxSize = Math.Max(vector1.GetSize(), vector2.GetSize());
			int vectorMinSize = Math.Min(vector1.GetSize(), vector2.GetSize());

			double[] subtractionResult = new double[vectorMaxSize];

			for (int i = 0; i < vectorMinSize; i++)
			{
				subtractionResult[i] = vector1.Vector[i] - vector2.Vector[i];
			}

			if (vector1.GetSize() > vector2.GetSize())
			{
				for (int i = vectorMinSize; i < vectorMaxSize; i++)
				{
					subtractionResult[i] = vector1.Vector[i];
				}
			}
			else if (vector2.GetSize() > vector1.GetSize())
			{
				for (int i = vectorMinSize; i < vectorMaxSize; i++)
				{
					subtractionResult[i] = 0 - vector2.Vector[i];
				}
			}

			Vectors newVector = new Vectors(subtractionResult);

			return newVector;
		}
	}
}
