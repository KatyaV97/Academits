using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
	class ListProgram
	{
		static void Main(string[] args)
		{
			SinglyLinkedList<int> itemsNumbers = new SinglyLinkedList<int>(3);

			itemsNumbers.AddFirst(10);
		}
	}
}
