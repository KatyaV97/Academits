using System;

namespace Vectors
{
	public class Vector
	{
		public int N { get; set; }

		public double[] VectorValues { get; set; }

		public Vector(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(n));
			}

			N = n;

			VectorValues = new double[N];
		}

		public Vector(Vector vector)
		{
			int vectorLength = vector.VectorValues.Length;
			VectorValues = new double[vectorLength];

			Array.Copy(vector.VectorValues, VectorValues, vectorLength);
		}

		public Vector(double[] vectorValues)
		{
			int vectorLength = vectorValues.Length;
			VectorValues = new double[vectorLength];

			Array.Copy(vectorValues, VectorValues, vectorLength);
		}

		public Vector(int n, double[] vector)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(n));
			}

			N = n;
			VectorValues = new double[N];

			int vectorLength = vector.Length;

			for (int i = 0; i < vectorLength; i++)
			{
				VectorValues[i] = vector[i];
			}

			if (N > vector.Length)
			{
				for (int i = vectorLength; i < N; i++)
				{
					VectorValues[i] = 0;
				}
			}
		}

		public int GetSize()
		{
			return VectorValues.Length;
		}

		public void AddVector(Vector vector)
		{
			int vectorSize = vector.GetSize();
			int thisVectorSize = GetSize();

			if (vectorSize > thisVectorSize)
			{
				VectorValues = ResizeArray(VectorValues, vectorSize);
			}

			for (int i = 0; i < vectorSize; i++)
			{
				VectorValues[i] += vector.VectorValues[i];
			}
		}

		public void SubtractVector(Vector vector)
		{
			int vectorSize = vector.GetSize();
			int thisVectorSize = GetSize();

			if (vectorSize > thisVectorSize)
			{
				VectorValues = ResizeArray(VectorValues, vectorSize);
			}

			for (int i = 0; i < vectorSize; i++)
			{
				VectorValues[i] -= vector.VectorValues[i];
			}
		}

		public void MultiplyVectorByScalar(double scalar)
		{
			for (int i = 0; i < GetSize(); i++)
			{
				VectorValues[i] *= scalar;
			}
		}

		public void ReverseVector()
		{
			for (int i = 0; i < GetSize(); i++)
			{
				VectorValues[i] *= -1;
			}
		}

		public double GetLength()
		{
			double squaresСoordinatesSum = 0;

			for (int i = 0; i < GetSize(); i++)
			{
				squaresСoordinatesSum += Math.Pow(VectorValues[i], 2);
			}

			return Math.Sqrt(squaresСoordinatesSum);
		}

		public static Vector AdditionVectors(Vector vector1, Vector vector2)
		{
			int vector1Size = vector1.GetSize();
			int vector2Size = vector2.GetSize();

			double[] additionResult = new double[Math.Max(vector1Size, vector2Size)];

			for (int i = 0; i < Math.Min(vector1Size, vector2Size); i++)
			{
				additionResult[i] = vector1.VectorValues[i] + vector2.VectorValues[i];
			}

			if (vector1Size > vector2Size)
			{
				for (int i = vector2Size; i < vector1Size; i++)
				{
					additionResult[i] = vector1.VectorValues[i];
				}
			}
			else if (vector1Size < vector2Size)
			{
				for (int i = vector1Size; i < vector2Size; i++)
				{
					additionResult[i] = vector2.VectorValues[i];
				}
			}

			Vector vectorsResultAddition = new Vector(additionResult);

			return vectorsResultAddition;
		}

		public static Vector SubtractionVectors(Vector vector1, Vector vector2)
		{
			int vector1Size = vector1.GetSize();
			int vector2Size = vector2.GetSize();

			double[] subtractionResult = new double[Math.Max(vector1Size, vector2Size)];
			for (int i = 0; i < Math.Min(vector1Size, vector2Size); i++)
			{
				subtractionResult[i] = vector1.VectorValues[i] - vector2.VectorValues[i];
			}

			if (vector1Size > vector2Size)
			{
				for (int i = vector2Size; i < vector1Size; i++)
				{
					subtractionResult[i] = vector1.VectorValues[i];
				}
			}
			else if (vector1Size < vector2Size)
			{
				for (int i = vector1Size; i < vector2Size; i++)
				{
					subtractionResult[i] = -vector2.VectorValues[i];
				}
			}

			Vector vectorsResultSubtraction = new Vector(subtractionResult);

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
			return VectorValues[index];
		}

		public void SetComponent(double component, int index)
		{
			VectorValues[index] = component;
		}

		public override string ToString()
		{
			return "{" + string.Join(",", VectorValues) + "}";
		}

		public override int GetHashCode()
		{
			int prime = 37;
			int hash = 1;

			foreach (double e in VectorValues)
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

			Vector vector = (Vector)obj;

			if (GetSize() != vector.GetSize())
			{
				return false;
			}
			else
			{
				for (int i = 0; i < GetSize(); i++)
				{
					if (VectorValues[i] != vector.VectorValues[i])
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
