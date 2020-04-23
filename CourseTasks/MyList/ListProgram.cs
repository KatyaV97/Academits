using System;

namespace MyList
{
	class ListProgram
	{
		static void Main()
		{
			var customers = new MyList<string> {"Игорь", "Александр", "Иван" };
			
			Console.WriteLine("Первые покупатели: " + customers);
			Console.WriteLine(Environment.NewLine);

			var customersPerDayCount = new MyList<int>() { 25, 55, 85, 36, 42, 3, 24, 6, 8, 4, 9, 12, 18 };

			Console.WriteLine("Количество покупателей в день: " + customersPerDayCount);
			Console.WriteLine("Вместимость: " + customersPerDayCount.Capacity);
			Console.WriteLine("Количество заполненных дней: " + customersPerDayCount.Count);
			Console.WriteLine(Environment.NewLine);

			customersPerDayCount.TrimExcess();

			Console.WriteLine("Количество покупателей в день: " + customersPerDayCount);
			Console.WriteLine("Вместимость: " + customersPerDayCount.Capacity);
			Console.WriteLine("Количество заполненных дней: " + customersPerDayCount.Count);
			Console.WriteLine(Environment.NewLine);

			customersPerDayCount.Clear();

			customersPerDayCount[0] = 36;
			customersPerDayCount[1] = 42;
			customersPerDayCount[2] = 52;

			if (customersPerDayCount.Contains(0))
			{
				Console.WriteLine("Есть дни с количеством покупателей = 0.");
			}
			else
			{
				Console.WriteLine("Нет дней с количеством покупателей = 0.");
			}

			Console.WriteLine(Environment.NewLine);


			var customersCount = new int[3];

			customersPerDayCount.CopyTo(customersCount, 0);

			Console.Write("Количество покупателей: ");

			foreach (int e in customersCount)
			{
				Console.Write(e + " ");
			}

			Console.WriteLine(Environment.NewLine);

			customers.Insert(customers.IndexOf("Александр"), "Саша");

			Console.WriteLine("Первые покупатели: " + customers);
			Console.WriteLine(Environment.NewLine);

			var countries = new MyList<string>(5)
			{
				"Russia",
				 "USA",
				"Canada",
				null,
				"Australia"
			};

			Console.WriteLine("Страны: " + countries);
			Console.WriteLine("Вместимость: " + countries.Capacity);
			Console.WriteLine("Количество стран: " + countries.Count);
			Console.WriteLine(Environment.NewLine);

			countries.Remove("Russia");

			Console.WriteLine("Страны после удаления России: " + countries);
			Console.WriteLine(Environment.NewLine);

			countries.Insert(3, "UK");
			Console.WriteLine("Страны после добавления Великобритании: " + countries);

			var emptyIndex = countries.IndexOf(null);
			Console.WriteLine("Индекс пустого элемента: " + emptyIndex);

			Console.ReadKey();
		}
	}
}
