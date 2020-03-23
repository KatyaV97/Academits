using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
	class SinglyLinkedList<T>
	{
		private ListItem<T> head;

		private int count;

		public SinglyLinkedList(T data)
		{
			head = new ListItem<T>(data, null);

			count++;
		}

		public int GetSize()
		{
			return count;
		}

		public T GetFirstValue()
		{
			return head.Data;
		}

		public T GetValue(int index)
		{
			if (index <= 0 || index >= count)
			{
				throw new ArgumentOutOfRangeException("Индекс должен быть > 0 и <  " + count + ". Индекс = " + index);
			}

			ListItem<T> tempList = head;

			for (int i = 1; i <= index; i++)
			{
				tempList = tempList.Next;
			}

			return tempList.Data;
		}

		public T SetValue(int index, T value)
		{
			if (index <= 0 || index >= count)
			{
				throw new ArgumentOutOfRangeException("Индекс должен быть > 0 и <  " + count + ". Индекс = " + index);
			}

			ListItem<T> tempList = head;
			ListItem<T> prev = null;

			for (int i = 0; i < index; i++)
			{
				prev = tempList;
				tempList = tempList.Next;
			}

			T oldValue = tempList.Data;

			ListItem<T> newNode = new ListItem<T>(value, tempList.Next);

			if (prev == null)
			{
				head = newNode;
			}
			else
			{
				prev.Next = newNode;
			}

			return oldValue;
		}

		public void AddFirst(T data)
		{
			ListItem<T> temp = new ListItem<T>(data, head);

			head = temp;
			count++;
		}






	}
}
