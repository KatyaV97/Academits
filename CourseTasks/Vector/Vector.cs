using System;

namespace Vectors
{
	public class Vector
	{
		private double[] values;

		public Vector(int size)
		{
			if (size <= 0)
			{
				throw new ArgumentException("Длина вектора = " + size + " должена быть > 0", nameof(size));
			}

			values = new double[size];
		}

		public Vector(Vector vector)
		{
			int vectorLength = vector.GetSize();

			values = new double[vectorLength];

			Array.Copy(vector.values, values, vectorLength);
		}

		public Vector(double[] values)
		{
			int vectorLength = values.Length;

			if (vectorLength <= 0)
			{
				throw new ArgumentException("Длина вектора = " + vectorLength + " должена быть > 0", nameof(vectorLength));
			}

			this.values = new double[vectorLength];

			Array.Copy(values, this.values, vectorLength);
		}

		public Vector(int size, double[] vector)
		{
			int vectorLength = vector.Length;

			if (size <= 0)
			{
				throw new ArgumentException("Длина вектора должена быть > 0");
			}
			/*
			if (vectorLength > size)
			{
				throw new ArgumentException("Длина вектора = " + vectorLength + " должна быть меньше, либо равна размеру результирующего вектора = " + size);
			}
			*/
			values = new double[size];

			if(size > vectorLength)
			{
				Array.Copy(vector, values, vectorLength);
			}
			else
			{
				Array.Copy(vector, values, size);
			}
		}

		public int GetSize()
		{
			return values.Length;
		}

		public void Add(Vector vector)
		{
			int vectorLength = vector.GetSize();

			if (vectorLength > values.Length)
			{
				Array.Resize(ref values, vectorLength);
			}

			for (int i = 0; i < vectorLength; i++)
			{
				values[i] += vector.values[i];
			}
		}

		public void Subtract(Vector vector)
		{
			int vectorLength = vector.GetSize();

			if (vectorLength > values.Length)
			{
				Array.Resize(ref values, vectorLength);
			}

			for (int i = 0; i < vectorLength; i++)
			{
				values[i] -= vector.values[i];
			}
		}

		public void MultiplyByScalar(double scalar)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] *= scalar;
			}
		}

		public void Reverse()
		{
			MultiplyByScalar(-1);
		}

		public double GetLength()
		{
			double coordinatesSquaresSum = 0;

			foreach (double e in values)
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

		public static double GetScalarMultiplication(Vector vector1, Vector vector2)
		{
			int vector1Length = vector1.GetSize();

			if (vector1Length != vector2.GetSize())
			{
				throw new ArgumentException("Перемножаемые ветора должны быть одинаковой длины.");
			}

			double sum = 0;

			for (int i = 0; i < vector1Length; i++)
			{
				sum += vector1.values[i] * vector2.values[i];
			}

			return sum;
		}

		public double GetComponent(int index)
		{
			int vectorLength = values.Length;

			if (index < 0 || index >= vectorLength)
			{
				throw new IndexOutOfRangeException("Индекс должен быть больше нуля и меньше длины ветора = " + vectorLength + ". Индекс = " + index);
			}

			return values[index];
		}

		public void SetComponent(int index, double component)
		{
			int vectorLength = values.Length;

			if (index < 0 || index >= vectorLength)
			{
				throw new IndexOutOfRangeException("Индекс должен быть больше нуля и меньше длины ветора = " + vectorLength + ". Индекс = " + index);
			}

			values[index] = component;
		}

		public override string ToString()
		{
			return "{" + string.Join(", ", values) + "}";
		}

		public override int GetHashCode()
		{
			int prime = 37;
			int hash = 1;

			foreach (double e in values)
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

			int vectorLength = values.Length;

			if (vectorLength != vector.GetSize())
			{
				return false;
			}

			for (int i = 0; i < vectorLength; i++)
			{
				if (values[i] != vector.values[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}
