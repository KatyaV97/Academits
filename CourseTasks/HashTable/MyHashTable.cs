using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
	class MyHashTable<T> : ICollection<T>
	{
		private readonly List<T>[] hashList;
		private int modCount;

		public int Count { get; private set; }

		public bool IsReadOnly => false;

		public MyHashTable()
		{
			hashList = new List<T>[100];
		}

		public MyHashTable(int tableSize)
		{
			if (tableSize <= 0)
			{
				throw new ArgumentException("Размер таблицы = " + tableSize + " должен быть > 0.", nameof(tableSize));
			}

			hashList = new List<T>[tableSize];
		}

		private int GetListIndex(T item)
		{
			if (item == null)
			{
				return 0;
			}

			return Math.Abs(item.GetHashCode() % hashList.Length);
		}

		private static bool HasItemsInList(List<T> itemsList)
		{
			return itemsList != null && itemsList.Count != 0;
		}

		public void Add(T item)
		{
			var index = GetListIndex(item);

			if (hashList[index] == null)
			{
				hashList[index] = new List<T>();
			}

			hashList[index].Add(item);

			Count++;
			modCount++;
		}

		public void Clear()
		{
			if (Count == 0)
			{
				return;
			}

			foreach (var itemsList in hashList)
			{
				if (HasItemsInList(itemsList))
				{
					itemsList.Clear();
				}
			}

			Count = 0;
			modCount++;
		}

		public bool Contains(T item)
		{
			var index = GetListIndex(item);

			return HasItemsInList(hashList[index]) && hashList[index].Contains(item);
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

			foreach (var itemsList in hashList)
			{
				if (HasItemsInList(itemsList))
				{
					itemsList.CopyTo(array, index);

					index += itemsList.Count;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			var oldModCount = modCount;

			foreach (var itemsList in hashList)
			{
				if (oldModCount != modCount)
				{
					throw new InvalidOperationException("Список был изменен после создания перечисления.");
				}

				if (HasItemsInList(itemsList))
				{
					foreach (var item in itemsList)
					{
						yield return item;
					}
				}
			}
		}

		public bool Remove(T item)
		{
			var index = GetListIndex(item);

			if (hashList[index] != null && hashList[index].Remove(item))
			{
				Count--;
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

			var stringBuilder = new StringBuilder();
			stringBuilder.Append("[");

			foreach (var item in this)
			{
				if (item == null)
				{
					stringBuilder
						.Append("null, ");
				}
				else
				{
					stringBuilder
						.Append(item)
						.Append(", ");
				}
			}

			return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("]").ToString();
		}
	}
}
