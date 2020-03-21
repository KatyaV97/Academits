using System;

namespace Vectors
{
	public class Vector
	{
		private double[] Values;

		public Vector(int size)
		{
			if (size <= 0)
			{
				throw new ArgumentException("Длина вектора должена быть > 0", nameof(size));
			}

			Values = new double[size];
		}

		public Vector(Vector vector)
		{
			int vectorLength = vector.GetSize();

			Values = new double[vectorLength];

			Array.Copy(vector.Values, Values, vectorLength);
		}

		public Vector(double[] values)
		{
			int vectorLength = values.Length;

			if (vectorLength <= 0)
			{
				throw new ArgumentException("Длина вектора должена быть > 0", nameof(vectorLength));
			}

			Values = new double[vectorLength];

			Array.Copy(values, Values, vectorLength);
		}

		public Vector(int size, double[] vector)
		{
			int vectorLength = vector.Length;

			if (size <= 0)
			{
				throw new ArgumentException("Длина вектора должена быть > 0");
			}

			if (vectorLength > size)
			{
				throw new ArgumentException("Некорректный ввод данных");
			}

			Values = new double[size];

			Array.Copy(vector, Values, vector.Length);
		}

		public int GetSize()
		{
			return Values.Length;
		}

		public void Add(Vector vector)
		{
			int vectorLength = vector.GetSize();

			if (vectorLength > Values.Length)
			{
				Array.Resize(ref Values, vectorLength);
			}

			for (int i = 0; i < vectorLength; i++)
			{
				Values[i] += vector.Values[i];
			}
		}

		public void Subtract(Vector vector)
		{
			int vectorLength = vector.GetSize();

			if (vectorLength > Values.Length)
			{
				Array.Resize(ref Values, vectorLength);
			}

			for (int i = 0; i < vectorLength; i++)
			{
				Values[i] -= vector.Values[i];
			}
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < Values.Length; i++)
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

			foreach (double e in Values)
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
			if (index < 0 || index >= Values.Length)
			{
				throw new ArgumentException("Индекс должен быть больше нуля и меньше длины ветора.");
			}

			return Values[index];
		}

		public void SetComponent(int index, double component)
		{
			if (index < 0 || index >= Values.Length)
			{
				throw new ArgumentException("Индекс должен быть больше нуля и меньше длины ветора.");
			}

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

			int vectorLength = Values.Length;

			if (vectorLength != vector.GetSize())
			{
				return false;
			}

			for (int i = 0; i < vectorLength; i++)
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
