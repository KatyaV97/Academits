using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyList
{
	class MyList<T> : IList<T>
	{
		private T[] items;
		private int modCount;

		public bool IsReadOnly => false;

		public int Count { get; private set; }

		public int Capacity { get; private set; }

		public T this[int index]
		{
			get
			{
				if (index > Count)
				{
					throw new IndexOutOfRangeException("Индекс = " + index + " должен быть > 0 и < " +
						Count);
				}

				return items[index];
			}

			set
			{
				if (index > Count)
				{
					throw new IndexOutOfRangeException("Индекс = " + index + " должен быть > 0 и < " +
						Count);
				}

				if (Count >= Capacity)
				{
					IncreaseCapacity();
				}

				items[index] = value;
				Count++;
			}
		}

		public MyList()
		{
			Count = 0;
			Capacity = 10;

			items = new T[Capacity];
		}

		public MyList(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentException("Вместимость = " + capacity + " должна быть > 0.", nameof(capacity));
			}

			Capacity = capacity;

			items = new T[Capacity];
		}

		public void TrimExcess()
		{
			if (Count == Capacity)
			{
				return;
			}

			Capacity = Count;
			Array.Resize(ref items, Capacity);
		}

		private void IncreaseCapacity()
		{
			T[] oldItems = items;
			Capacity *= 2;

			items = new T[Capacity];
			Array.Copy(oldItems, items, Count);
		}

		public void Add(T item)
		{
			if (Count >= Capacity)
			{
				IncreaseCapacity();
			}

			items[Count] = item;

			Count++;
			modCount++;
		}

		public void Clear()
		{
			Count = 0;

			modCount++;
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (items[i].Equals(item))
				{
					return true;
				}
			}

			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = arrayIndex; i < Count; i++)
			{
				array.SetValue(items[i], arrayIndex++);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			int oldModCount = modCount;

			for (int i = 0; i < Count; i++)
			{
				if (oldModCount != modCount)
				{
					throw new InvalidOperationException("Список был изменен после создания перечисления.");
				}

				yield return items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int IndexOf(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (items[i].Equals(item))
				{
					return i;
				}
			}

			return -1;
		}

		public void Insert(int index, T item)
		{
			if (index >= Count)
			{
				throw new IndexOutOfRangeException("Индекс = " + index + " должен быть > 0 и < " +
					Count);
			}

			items[index] = item;

			modCount++;
		}

		public bool Remove(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (items[i].Equals(item))
				{
					RemoveAt(i);

					return true;
				}
			}

			return false;
		}

		public void RemoveAt(int index)
		{
			if (index >= Count)
			{
				throw new IndexOutOfRangeException("Индекс = " + index + " должен быть > 0 и < " +
					Count);
			}

			for (int i = index; i < Count - 1; i++)
			{
				items[i] = items[i + 1];
			}

			Count--;
			modCount++;
		}

		public override string ToString()
		{
			StringBuilder printResult = new StringBuilder();
			printResult.Append("[");

			for (int i = 0; i < Count - 1; i++)
			{
				printResult.Append(items[i] + " , ");
			}

			printResult.Append(items[Count - 1] + "]");

			return printResult.ToString();
		}
	}
}
