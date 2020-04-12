using System;
using System.Text;

namespace List
{
	class SinglyLinkedList<T>
	{
		private ListItem<T> head;

		public int Count { get; private set; }

		public SinglyLinkedList() { }

		public SinglyLinkedList(T data)
		{
			head = new ListItem<T>(data, null);

			Count++;
		}

		public T GetFirstValue()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Невозможно получить первое значение, так как список пуст.");
			}

			return head.Data;
		}

		public T GetValue(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <  " + Count + ". Индекс = " + index);
			}

			return GetNodeByIndex(index).Data;
		}

		private ListItem<T> GetNodeByIndex(int index)
		{
			var currentNode = head;

			for (int i = 0; i < index; i++)
			{
				currentNode = currentNode.Next;
			}

			return currentNode;
		}

		public T SetValue(int index, T value)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <  " + Count + ". Индекс = " + index);
			}

			var currentNode = GetNodeByIndex(index);
			var oldValue = currentNode.Data;
			currentNode.Data = value;

			return oldValue;
		}

		public void AddFirst(T data)
		{
			var currentNode = new ListItem<T>(data, head);

			head = currentNode;

			Count++;
		}

		public void Add(int index, T value)
		{
			if (index < 0 || index > Count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <=  " + Count + ". Индекс = " + index);
			}

			if (index == 0)
			{
				AddFirst(value);

				return;
			}

			var previousNode = GetNodeByIndex(index - 1);
			var currentNode = previousNode.Next;

			var newNode = new ListItem<T>(value, currentNode);
			previousNode.Next = newNode;

			Count++;
		}

		public void Add(T value)
		{
			GetNodeByIndex(Count - 1).Next = new ListItem<T>(value);

			Count++;
		}

		public T RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException("Индекс должен быть >= 0 и <  " + Count + ". Индекс = " + index);
			}

			if (index == 0)
			{
				return RemoveFirst();
			}

			var previousNode = GetNodeByIndex(index - 1);
			var currentNode = previousNode.Next;

			T oldValue = currentNode.Data;
			previousNode.Next = currentNode.Next;

			Count--;

			return oldValue;
		}

		public bool Remove(T value)
		{
			if (head == null)
			{
				throw new InvalidOperationException("Список пуст. Невозможно удалить значение.");
			}

			if (head.Data != null && head.Data.Equals(value) ||
				(head.Data == null && value == null))
			{
				head = head.Next;

				Count--;

				return true;
			}

			for (ListItem<T> currentNode = head.Next, previousNode = head; currentNode != null;
				previousNode = currentNode, currentNode = currentNode.Next)
			{
				if (currentNode.Data != null && currentNode.Data.Equals(value) ||
					(currentNode.Data == null && value == null))
				{
					previousNode.Next = currentNode.Next;

					Count--;

					return true;
				}
			}

			return false;
		}

		public T RemoveFirst()
		{
			if (head == null)
			{
				throw new InvalidOperationException("Список пуст. Невозможно удалить первый элемент.");
			}

			var tempNode = head;
			head = tempNode.Next;

			Count--;

			return tempNode.Data;
		}

		public void Reverse()
		{
			if (head == null)
			{
				return;
			}

			var currentNode = head;
			ListItem<T> previousNode = null;

			for (ListItem<T> nextNode = head.Next; nextNode != null;
				previousNode = currentNode, currentNode = nextNode, nextNode = nextNode.Next)
			{
				currentNode.Next = previousNode;
			}

			currentNode.Next = previousNode;
			head = currentNode;
		}

		public SinglyLinkedList<T> Copy()
		{
			if (head == null)
			{
				return new SinglyLinkedList<T>();
			}

			var newList = new SinglyLinkedList<T>(head.Data);

			for (ListItem<T> oldCurrentNode = head.Next, newPreviousNode = newList.head;
				oldCurrentNode != null; oldCurrentNode = oldCurrentNode.Next, newPreviousNode = newPreviousNode.Next)
			{
				var newCurrentNode = new ListItem<T>(oldCurrentNode.Data, oldCurrentNode.Next);

				newPreviousNode.Next = newCurrentNode;
			}

			newList.Count = Count;

			return newList;
		}

		public override string ToString()
		{
			if (head == null)
			{
				return "[]";
			}

			var stringBuilder = new StringBuilder();
			var tempNode = head;

			stringBuilder.Append("[");

			while (tempNode.Next != null)
			{
				stringBuilder
					.Append(tempNode.Data)
					.Append(", ");

				tempNode = tempNode.Next;
			}

			return stringBuilder.Append(tempNode.Data).Append("]").ToString();
		}
	}
}
