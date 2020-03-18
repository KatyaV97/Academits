using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
	class ListItem<T>
	{
		public T Data { get; }

		public ListItem<T> Next { get; }

		public ListItem(T data)
		{
			Data = data;
		}

		public ListItem(T data, ListItem<T> next)
		{
			Data = data;
			Next = next;
		}


	}
}
