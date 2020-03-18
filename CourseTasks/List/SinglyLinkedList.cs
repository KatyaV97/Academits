using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
	class SinglyLinkedList<T>
	{
		public ListItem<T> Head;

		public ListItem<T>[] Items = new ListItem<T>[10];

		private int Count;

		public ListItem<T> this[int index]
		{
			get { return Items[index]; }

			set { Items[index] = value; }
		}

		public SinglyLinkedList(T data)
		{
			ListItem<T> item = new ListItem<T>(data, null);

			Head = item;
			Items[0] = item;
			Count++;
		}
		/*
		public SinglyLinkedList(ListItem<T> head)
		{
			Head = head;
		}
		*/
		public int GetSize()
		{
			return Items.Length;
		}

		public T GetFirstValue()
		{
			return Head.Data;
		}

		public void AddFirst(T data)
		{
			ListItem<T> item = new ListItem<T>(data, Head);
			
			for (ListItem<T> i = Head, prev = i.Next; i != null; i = i.Next, prev = i.Next.Next)
			{
				prev = i;
			}

			Items[0] = item; 
			Head = item;
			Count++;
		}

		public void Add(int index)
		{

		}
	}
}
