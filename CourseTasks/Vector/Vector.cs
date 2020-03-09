using System;

namespace Vectors
{
	public class Vector
	{
		private int Size;

		private double[] Values;

		public Vector(int size)
		{
			if (size <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(size));
			}

			Size = size;

			Values = new double[Size];
		}

		public Vector(Vector vector)
		{
			Size = vector.Size;

			Values = new double[Size];

			Array.Copy(vector.Values, Values, Size);
		}

		public Vector(double[] vectorValues)
		{
			Size = vectorValues.Length;

			if (Size <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(Size));
			}

			Values = new double[Size];

			Array.Copy(vectorValues, Values, Size);
		}

		public Vector(int size, double[] vector)
		{
			if (size <= 0)
			{
				throw new ArgumentException("n должен быть > 0", nameof(Size));
			}

			Size = size;

			Values = new double[Size];

			Array.Copy(vector, Values, vector.Length);
		}

		public void Add(Vector vector)
		{
			int vectorSize = vector.Size;

			if (vectorSize > Size)
			{
				Array.Resize(ref Values, vectorSize);
				Size = vectorSize;
			}

			for (int i = 0; i < vectorSize; i++)
			{
				Values[i] += vector.Values[i];
			}
		}

		public void Subtract(Vector vector)
		{
			int vectorSize = vector.Size;

			if (vectorSize > Size)
			{
				Array.Resize(ref Values, vectorSize);
				Size = vectorSize;
			}

			for (int i = 0; i < vectorSize; i++)
			{
				Values[i] -= vector.Values[i];
			}
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < Size; i++)
			{
				Values[i] *= scalar;
			}
		}

		public void Reverse()
		{
			MultiplyByScalar(-1);
		}

		public double GetLength()
		{
			double coordinatesSquaresSum = 0;

			foreach (int e in Values)
			{
				coordinatesSquaresSum += Math.Pow(e, 2);
			}

			return Math.Sqrt(coordinatesSquaresSum);
		}

		public static Vector Addition(Vector vector1, Vector vector2)
		{
			Vector resultAddition = new Vector(vector1);

			resultAddition.Add(vector2);

			return resultAddition;
		}

		public static Vector Subtraction(Vector vector1, Vector vector2)
		{
			Vector resultSubtraction = new Vector(vector1);

			resultSubtraction.Subtract(vector2);

			return resultSubtraction;
		}

		public double GetComponent(int index)
		{
			return Values[index];
		}

		public void SetComponent(int index, double component)
		{
			Values[index] = component;
		}

		public override string ToString()
		{
			return "{" + string.Join(", ", Values) + "}";
		}

		public override int GetHashCode()
		{
			int prime = 37;
			int hash = 1;

			foreach (double e in Values)
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

			if (Size != vector.Size)
			{
				return false;
			}

			for (int i = 0; i < Size; i++)
			{
				if (Values[i] != vector.Values[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}
