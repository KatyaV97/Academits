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
		private int capacity;

		public int Count { get; private set; }

		//public int capacity { get; set; }

		public bool IsReadOnly => false;

		public MyHashTable()
		{
			Count = 0;
			capacity = 100;

			items = new List<T>[capacity];
		}

		public MyHashTable(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentException("Вместимость = " + capacity + " должна быть > 0.", nameof(capacity));
			}

			this.capacity = capacity;

			items = new List<T>[this.capacity];
		}

		private int GetArrayIndex(T item)
		{
			return Math.Abs(item.GetHashCode() % capacity);
		}

		private void CheckItem(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Аргумент = null.");
			}
		}

		private bool HasItemsInList(List<T> item)
		{
			return item != null && item.Count != 0;
		}

		public void Add(T item)
		{
			//CheckItem(item);

			var index = GetArrayIndex(item);

			if (items[index] == null)
			{
				items[index] = new List<T>();
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

			for (var i = 0; i < capacity; i++)
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
			//CheckItem(item);

			return items[GetArrayIndex(item)].Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array), "Массив равен null.");
			}

			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(arrayIndex),
					"Значение параметра индекса = " + arrayIndex + " < 0.");
			}

			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Число элементов в исходной коллекции = " + Count +
					" больше доступного места от положения, заданного значением параметра = " + arrayIndex +
					", до конца массива, длина которого = " + array.Length + ".");
			}

			var index = arrayIndex;

			foreach (var currentItems in items)
			{
				if (HasItemsInList(currentItems))
				{
					currentItems.CopyTo(array, index);

					index += currentItems.Count;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			var oldModCount = modCount;

			foreach (var currentItems in items)
			{
				if (oldModCount != modCount)
				{
					throw new InvalidOperationException("Список был изменен после создания перечисления.");
				}

				if (HasItemsInList(currentItems))
				{
					foreach (var item in currentItems)
					{
						yield return item;
					}
				}
			}
		}

		public bool Remove(T item)
		{
			//CheckItem(item);

			if (items[GetArrayIndex(item)] != null && items[GetArrayIndex(item)].Remove(item))
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

			for (var i = 0; i < capacity; i++)
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
