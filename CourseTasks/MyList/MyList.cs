using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{
	class MyList<T> : IList<T>
	{
		private T[] items;
		private int modCount;

		public bool IsReadOnly => false;

		public int Count { get; private set; }

		public int Capacity
		{
			get
			{
				return items.Length;
			}
			set
			{
				if (value < Count)
				{
					throw new ArgumentOutOfRangeException(nameof(value), "Вместимость = " + value +
						" должна быть >= количеству заполненных элементов = " + Count);
				}

				Array.Resize(ref items, value);
			}
		}

		public MyList()
		{
			Capacity = 10;
			Count = 0;
		}

		public MyList(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentException("Вместимость = " + capacity + " должна быть >= 0.", nameof(capacity));
			}

			Capacity = capacity;
		}

		public T this[int index]
		{
			get
			{
				CheckIndex(index);

				return items[index];
			}

			set
			{
				CheckIndex(index);

				items[index] = value;
				modCount++;
			}
		}

		public void TrimExcess()
		{
			if (Count == Capacity)
			{
				return;
			}

			Capacity = Count;
			modCount++;
		}

		private void IncreaseCapacity()
		{
			if (Capacity == 0)
			{
				Capacity = 10;
				return;
			}

			Capacity *= 2;
		}

		public void Add(T item)
		{
			CheckExcessCapacity();

			items[Count] = item;

			Count++;
			modCount++;
		}

		public void Clear()
		{
			Array.Clear(items, 0, Count);

			Count = 0;

			modCount++;
		}

		public bool Contains(T item)
		{
			return IndexOf(item) != -1;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("Массив имеет значение null.");
			}

			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Значение параметра индекса = " +
					arrayIndex + " < 0.");
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
				if (Equals(items[i], item))
				{
					return i;
				}
			}

			return -1;
		}

		public void Insert(int index, T item)
		{
			if (index < 0 || index > Count)
			{
				throw new IndexOutOfRangeException("Индекс = " + index + " должен быть >= 0 и <= " +
					Count);
			}

			CheckExcessCapacity();

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
			CheckIndex(index);

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

			return "[" + string.Join(", ", this) + "]";
		}

		private void CheckIndex(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException("Индекс = " + index + " должен быть >= 0 и < " + Count);
			}
		}

		private void CheckExcessCapacity()
		{
			if (Count >= Capacity)
			{
				IncreaseCapacity();
			}
		}
	}
}
