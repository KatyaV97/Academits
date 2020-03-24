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

			Console.WriteLine("Значение в списке на позиции 3 " + value1);
			Console.WriteLine(Environment.NewLine);

			int value2 = itemsNumbers.SetValue(1, 6);

			Console.WriteLine("Измененный список: " + itemsNumbers + " после устанвоки нового значения на позицию 2, вместо старого значения = " + value2);
			Console.WriteLine(Environment.NewLine);

			itemsNumbers.Add(1, 8);
			itemsNumbers.Add(4, 11);
			itemsNumbers.Add(3, 0);

			Console.WriteLine("Измененный список: " + itemsNumbers);
			Console.WriteLine("Размер списка: " + itemsNumbers.GetSize());
			Console.WriteLine(Environment.NewLine);

			itemsNumbers.Remove(1);

			Console.WriteLine("Измененный список, после удаляения элемента с позиции №2: " + itemsNumbers);
			Console.WriteLine(Environment.NewLine);

			itemsNumbers.RemoveFirst();

			Console.WriteLine("Измененный список, после удаляения элемента с первой позиции: " + itemsNumbers);
			Console.WriteLine(Environment.NewLine);

			SinglyLinkedList<int> newItemsNumbers = itemsNumbers.Copy();

			newItemsNumbers.Add(2, 16);

			Console.WriteLine("Старый список: " + itemsNumbers);
			Console.WriteLine("Новый список: " + newItemsNumbers);
		}
	}
}
