using System;

namespace Vectors
{
	class Vectors
	{
		public int N { get; set; }

		public double[] Vector { get; set; }

		public Vectors(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(n));
			}

			N = n;

			Vector = new double[N];
		}

		public Vectors(Vectors vector)
		{
			int vectorLength = vector.Vector.Length;
			Vector = new double[vectorLength];

			Array.Copy(vector.Vector, Vector, vectorLength);
		}

		public Vectors(double[] vectorsValues)
		{
			int vectorLength = vectorsValues.Length;
			Vector = new double[vectorLength];

			Array.Copy(vectorsValues, Vector, vectorLength);
		}

		public Vectors(int n, double[] vector)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(n));
			}

			N = n;
			Vector = new double[N];

			int vectorLength = vector.Length;

			for (int i = 0; i < vectorLength; i++)
			{
				Vector[i] = vector[i];
			}

			if (N > vector.Length)
			{
				for (int i = vectorLength; i < N; i++)
				{
					Vector[i] = 0;
				}
			}
		}

		public int GetSize()
		{
			return Vector.Length;
		}

		public void AddVector(Vectors vector)
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

		public void SubtractVector(Vectors vector)
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

		public static Vectors AdditionVectors(Vectors vector1, Vectors vector2)
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

			Vectors vectorsResultAddition = new Vectors(additionResult);

			return vectorsResultAddition;
		}

		public static Vectors SubtractionVectors(Vectors vector1, Vectors vector2)
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

			Vectors vectorsResultSubtraction = new Vectors(subtractionResult);

			return vectorsResultSubtraction;
		}

		public static double[] ResizeArray(double[] vector, int newSize)
		{
			double[] modifiedVector = new double[newSize];

			for (int i = 0; i < vector.Length; i++)
			{
				modifiedVector[i] = vector[i];
			}

			return modifiedVector;
		}

		public double GetComponent(int index)
		{
			return Vector[index];
		}

		public void SetComponent(double component, int index)
		{
			Vector[index] = component;
		}

		public override string ToString()
		{
			return "{" + string.Join(",", Vector) + "}";
		}

		public override int GetHashCode()
		{
			int prime = 37;
			int hash = 1;

			foreach (double e in Vector)
			{
				hash = prime * hash + e.GetHashCode();
			}

			return hash;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, this))
			{
				return true;
			}

			if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
			{
				return false;
			}

			Vectors vector = (Vectors)obj;

			if (GetSize() != vector.GetSize())
			{
				return false;
			}
			else
			{
				for (int i = 0; i < GetSize(); i++)
				{
					if (Vector[i] != vector.Vector[i])
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
