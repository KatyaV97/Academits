using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
	class MyHashTable<T> : ICollection<T>
	{
		private List<T>[] items;
		private int modCount;

		public int Count { get; private set; }

		public int Capacity { get; set; }

		public bool IsReadOnly => false;

		public MyHashTable()
		{
			Count = 0;
			Capacity = 100;

			items = new List<T>[Capacity];
		}

		public MyHashTable(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentException("Вместимость = " + capacity + " должна быть > 0.", nameof(capacity));
			}

			Capacity = capacity;

			items = new List<T>[Capacity];
		}

		private int GetIndexForArray(T item)
		{
			return Math.Abs(item.GetHashCode() % Capacity);
		}

		private void CheckItem(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Аргумент = null.");
			}
		}

		private bool HasItemsInList(int index)
		{
			return items[index] != null && items[index].Count != 0;
		}

		public void Add(T item)
		{
			CheckItem(item);

			var index = GetIndexForArray(item);

			if (items[index] == null)
			{
				items[index] = new List<T>();
			}

			if (items[index].Contains(item))
			{
				return;
			}

			items[index].Add(item);

			Count++;
			modCount++;
		}

		public void Clear()
		{
			if (Count == 0)
			{
				return;
			}

			Count = 0;

			for (var i = 0; i < Capacity; i++)
			{
				if (items[i] != null)
				{
					items[i].Clear();
				}
			}

			modCount++;
		}

		public bool Contains(T item)
		{
			CheckItem(item);

			if (items[GetIndexForArray(item)] != null && items[GetIndexForArray(item)].Contains(item))
			{
				return true;
			}

			return false;
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

			var addedItemsCount = 0;

			for (var i = 0; i < Capacity; i++)
			{
				if (HasItemsInList(i))
				{
					items[i].CopyTo(array, arrayIndex + addedItemsCount);

					addedItemsCount += items[i].Count;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			var oldModCount = modCount;

			for (var i = 0; i < Capacity; i++)
			{
				if (oldModCount != modCount)
				{
					throw new InvalidOperationException("Список был изменен после создания перечисления.");
				}

				if (HasItemsInList(i))
				{
					foreach (var item in items[i])
					{
						yield return item;
					}
				}
			}
		}

		public bool Remove(T item)
		{
			CheckItem(item);

			if (items[GetIndexForArray(item)] != null && items[GetIndexForArray(item)].Remove(item))
			{
				modCount++;
				return true;
			}

			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			if (Count == 0)
			{
				return "[]";
			}

			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");

			for (var i = 0; i < Capacity; i++)
			{
				if (HasItemsInList(i))
				{
					foreach (var item in items[i])
					{
						stringBuilder
									.Append(item)
									.Append(", ");
					}
				}
			}

			return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("]").ToString();
		}
	}
}
