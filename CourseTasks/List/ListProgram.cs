using System;

namespace List
{
	class ListProgram
	{
		static void Main(string[] args)
		{
			var charactersList = new SinglyLinkedList<string>();
			Console.WriteLine("Список символов: " + charactersList);
			
			charactersList.AddFirst("a");
			charactersList.Add(1, null);
			charactersList.Add(1, "c");

			var list1Value1 = charactersList.GetData(1);
			var list1Value2 = charactersList.GetData(2);

			Console.WriteLine("Значение под индексом 1: " + list1Value1);
			Console.WriteLine("Значение под индексом 2: " + list1Value2);
			Console.WriteLine(Environment.NewLine);

			charactersList.SetData(1, "b");
			charactersList.Add(0, "e");
			charactersList.Add(2, "f");
			charactersList.Add(4, "g");

			charactersList.Add(null);
			charactersList.SetData(0, null);

			Console.WriteLine("Список символов: " + charactersList);

			charactersList.Remove(null);
			charactersList.RemoveAt(2);
			charactersList.Remove("g");
			charactersList.Remove(null);

			Console.WriteLine("Измененный список символов: " + charactersList);

			charactersList.Reverse();

			Console.WriteLine("Список символов после разворота: " + charactersList);
			Console.WriteLine(Environment.NewLine);

			var numbersList1 = new SinglyLinkedList<int>(3);

			numbersList1.AddFirst(10);
			numbersList1.AddFirst(2);

			Console.WriteLine("Список №1: " + numbersList1);
			Console.WriteLine(Environment.NewLine);

			int list2Value2 = numbersList1.GetData(2);

			Console.WriteLine("Значение по индексу 2 в списке №1 = " + list2Value2);
			Console.WriteLine(Environment.NewLine);

			int list2Value1 = numbersList1.SetData(1, 6);

			Console.WriteLine("Измененный список №1: " + numbersList1 +
				" после установки нового значения по индексу 1. Старое значение = " + list2Value1);
			Console.WriteLine(Environment.NewLine);

			numbersList1.Add(3, 8);
			numbersList1.Add(4, 11);
			numbersList1.Add(3, 0);

			Console.WriteLine("Измененный список №1: " + numbersList1);
			Console.WriteLine("Размер списка №1: " + numbersList1.Count);
			Console.WriteLine(Environment.NewLine);

			numbersList1.RemoveAt(1);

			Console.WriteLine("Измененный список №1, после удаления элемента по индексу 1: " + numbersList1);
			Console.WriteLine(Environment.NewLine);

			numbersList1.RemoveFirst();

			Console.WriteLine("Измененный список №1, после удаления элемента по индексу 0: " + numbersList1);
			Console.WriteLine(Environment.NewLine);

			var numbersList2 = numbersList1.Copy();

			numbersList2.Add(2, 16);

			Console.WriteLine("Список №1: " + numbersList1);
			Console.WriteLine("Список №2: " + numbersList2);
			Console.WriteLine(Environment.NewLine);

			var itemsList2Count = numbersList2.Count;
			Console.WriteLine("Размер списка №2: " + itemsList2Count);

			if (numbersList2.Remove(0))
			{
				Console.WriteLine("Измененный список №2 после удаления значения = 0: " + numbersList2);
			}
			else
			{
				Console.WriteLine("Список №2 не был изменен: " + numbersList2);
			}

			Console.WriteLine(Environment.NewLine);

			var listFirstValue = numbersList2.GetFirstData();

			Console.WriteLine("Первый элемент списка №2: " + listFirstValue);

			Console.ReadKey();
		}
	}
}
