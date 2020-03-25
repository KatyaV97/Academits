using System;

namespace List
{
	class ListProgram
	{
		static void Main(string[] args)
		{
			SinglyLinkedList<int> itemsNumbers = new SinglyLinkedList<int>(3);

			itemsNumbers.AddFirst(10);
			itemsNumbers.AddFirst(2);

			Console.WriteLine("Односвязный список: " + itemsNumbers);
			Console.WriteLine(Environment.NewLine);

			int value1 = itemsNumbers.GetValue(2);

			Console.WriteLine("Значение №3 в списке = " + value1);
			Console.WriteLine(Environment.NewLine);

			int value2 = itemsNumbers.SetValue(1, 6);

			Console.WriteLine("Измененный список: " + itemsNumbers + " после установки нового значения на позицию 2. Старое значение = " + value2);
			Console.WriteLine(Environment.NewLine);

			itemsNumbers.Add(3, 8);
			itemsNumbers.Add(4, 11);
			itemsNumbers.Add(3, 0);

			Console.WriteLine("Измененный список: " + itemsNumbers);
			Console.WriteLine("Размер списка: " + itemsNumbers.GetSize());
			Console.WriteLine(Environment.NewLine);

			itemsNumbers.RemoveAt(1);

			Console.WriteLine("Измененный список, после удаления элемента с позиции №2: " + itemsNumbers);
			Console.WriteLine(Environment.NewLine);

			itemsNumbers.RemoveFirst();

			Console.WriteLine("Измененный список, после удаления элемента с первой позиции: " + itemsNumbers);
			Console.WriteLine(Environment.NewLine);

			SinglyLinkedList<int> newItemsNumbers = itemsNumbers.Copy();

			newItemsNumbers.Add(2, 16);

			Console.WriteLine("Старый список: " + itemsNumbers);
			Console.WriteLine("Новый список: " + newItemsNumbers);
			Console.WriteLine("Размер нового списка: " + newItemsNumbers.GetSize());

			if (newItemsNumbers.Remove(0))
			{
				Console.WriteLine("Измененный список после удаления значения = 0: " + newItemsNumbers);
			}
			else
			{
				Console.WriteLine("Список не был изменен: " + newItemsNumbers);
			}

			Console.WriteLine(Environment.NewLine);

			SinglyLinkedList<int>  reverseResulting = newItemsNumbers.Reverse();

			Console.WriteLine("Разворот списка: " + reverseResulting);
			Console.WriteLine(Environment.NewLine);

			Console.WriteLine("Первый элемент списка: " + newItemsNumbers.GetFirstValue());

			Console.ReadKey();
		}
	}
}
