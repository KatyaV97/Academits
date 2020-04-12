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

		public int Capacity { get; set; }

		public T this[int index]
		{
			get
			{
				if (index < 0 || Count < index)
				{
					throw new IndexOutOfRangeException("Индекс = " + index + " должен быть > 0 и < " +
						Count);
				}

				return items[index];
			}

			set
			{
				if (index < 0 || Count < index)
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

			Array.Resize(ref items, Capacity);
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
			if (IndexOf(item) == -1)
			{
				return false;
			}

			return true;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("Массив имеет значение null.");
			}

			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("Значение параметра индекса = " + arrayIndex + " < 0.",
					nameof(arrayIndex));
			}

			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Число элементов в исходной коллекции = " + Count +
					" больше доступного места от положения, заданного значением параметра = " + arrayIndex +
					", до конца массива, длина которого = " + array.Length + ".");
			}

			Array.Copy(items, 0, array, arrayIndex, Count);
		}

		public IEnumerator<T> GetEnumerator()
		{
			var oldModCount = modCount;

			for (var i = 0; i < Count; i++)
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
			for (var i = 0; i < Count; i++)
			{
				if (items[i] != null && items[i].Equals(item) ||
					(items[i] == null && item == null))
				{
					return i;
				}
			}

			return -1;
		}

		public void Insert(int index, T item)
		{
			if (index < 0 || Count < index)
			{
				throw new IndexOutOfRangeException("Индекс = " + index + " должен быть >= 0 и <= " +
					Count);
			}

			if (Count >= Capacity)
			{
				IncreaseCapacity();
			}

			if (index == Count)
			{
				Add(item);
				return;
			}

			Array.Copy(items, index, items, index + 1, Count - index);
			items[index] = item;

			Count++;
			modCount++;
		}

		public bool Remove(T item)
		{
			var itemIndex = IndexOf(item);

			if (itemIndex == -1)
			{
				return false;
			}

			RemoveAt(itemIndex);
			return true;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || Count <= index)
			{
				throw new IndexOutOfRangeException("Индекс = " + index + " должен быть >= 0 и < " +
					Count);
			}

			Array.Copy(items, index + 1, items, index, Count - index - 1);

			Count--;
			modCount++;
		}

		public override string ToString()
		{
			if (Count == 0)
			{
				return "[]";
			}

			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");

			for (var i = 0; i < Count - 1; i++)
			{
				stringBuilder
					.Append(items[i])
					.Append(", ");
			}

			return stringBuilder.Append(items[Count - 1]).Append("]").ToString();
		}
	}
}
