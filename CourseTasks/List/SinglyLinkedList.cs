using System;
using System.Text;

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
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <  " + count + ". Индекс = " + index);
			}

			ListItem<T> tempNode = head;

			for (int i = 0; i < index; i++)
			{
				tempNode = tempNode.Next;
			}

			return tempNode.Data;
		}

		public T SetValue(int index, T value)
		{
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <  " + count + ". Индекс = " + index);
			}

			ListItem<T> tempNode = head;
			ListItem<T> prevNode = null;

			for (int i = 0; i < index; i++)
			{
				prevNode = tempNode;
				tempNode = tempNode.Next;
			}

			T oldValue = tempNode.Data;

			ListItem<T> newNode = new ListItem<T>(value, tempNode.Next);

			if (prevNode == null)
			{
				head = newNode;
			}
			else
			{
				prevNode.Next = newNode;
			}

			return oldValue;
		}

		public void AddFirst(T data)
		{
			ListItem<T> tempNode = new ListItem<T>(data, head);

			head = tempNode;
			count++;
		}

		public void Add(int index, T value)
		{
			if (index < 0 || index > count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <=  " + count + ". Индекс = " + index);
			}


			ListItem<T> tempNode = head;
			ListItem<T> prevNode = null;

			for (int i = 0; i < index; i++)
			{
				prevNode = tempNode;
				tempNode = tempNode.Next;
			}

			ListItem<T> newNode = new ListItem<T>(value, tempNode);

			if (prevNode == null)
			{
				head = newNode;
			}
			else
			{
				prevNode.Next = newNode;
			}

			count++;
		}

		public T Remove(int index)
		{
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <  " + count + ". Индекс = " + index);
			}

			ListItem<T> tempNode = head;
			ListItem<T> prevNode = null;

			for (int i = 0; i < index; i++)
			{
				prevNode = tempNode;
				tempNode = tempNode.Next;
			}

			T oldValue = tempNode.Data;
			prevNode.Next = tempNode.Next;

			count--;

			return oldValue;
		}

		public bool Remove(T value)
		{
			for (ListItem<T> tempNode = head, prevNode = null; tempNode != null; prevNode = tempNode, tempNode = tempNode.Next)
			{
				if (tempNode.Data.Equals(value))
				{
					prevNode.Next = tempNode.Next;
					count--;
					return true;
				}
			}

			return false;
		}

		public T RemoveFirst()
		{
			ListItem<T> tempNode = head;
			head = tempNode.Next;
			count--;

			return tempNode.Data;
		}

		public void Reverse()
		{
			for (ListItem<T> tempNode = head, prevNode = null; tempNode != null; prevNode = tempNode, tempNode = tempNode.Next)
			{
				tempNode.Next = prevNode;
			}
		}

		public SinglyLinkedList<T> Copy()
		{
			SinglyLinkedList<T> newNodes = new SinglyLinkedList<T>(head.Data);
			int counter = 1;

			for (ListItem<T> tempNode = head; tempNode != null; tempNode = tempNode.Next)
			{
				newNodes.Add(counter, tempNode.Data);
			}

			newNodes.count = count;

			return newNodes;
		}

		public override string ToString()
		{
			StringBuilder printResult = new StringBuilder();
			printResult.Append("[");

			for (ListItem<T> tempNode = head; tempNode != null; tempNode = tempNode.Next)
			{
				printResult.Append(tempNode.Data + ", ");
			}

			printResult.Append("]");

			return printResult.ToString();
		}


	}
}
