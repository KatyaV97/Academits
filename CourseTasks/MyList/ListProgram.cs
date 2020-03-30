using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
	class ListProgram
	{
		static void Main()
		{
			var customers = new MyList<string>();

			customers.Add("Игорь");
			customers.Add("Александр");
			customers.Add("Иван");

			Console.WriteLine("Первые покупатели: " + customers);
			Console.WriteLine(Environment.NewLine);

			var customersPerDayCount = new MyList<int>();

			customersPerDayCount.Add(25);
			customersPerDayCount.Add(55);
			customersPerDayCount.Add(85);
			customersPerDayCount[3] = 36;
			customersPerDayCount[4] = 42;
			customersPerDayCount[5] = 3;
			customersPerDayCount[6] = 24;
			customersPerDayCount[7] = 24;
			customersPerDayCount[8] = 24;
			customersPerDayCount[9] = 24;
			customersPerDayCount[10] = 6;
			customersPerDayCount[11] = 8;

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


			int[] customesrCount = new int[customersPerDayCount.Count];

			customersPerDayCount.CopyTo(customesrCount, 0);

			Console.Write("Количество покупателей: ");

			foreach (int e in customesrCount)
			{
				Console.Write(e + " ");
			}

			Console.WriteLine(Environment.NewLine);

			customers.Insert(customers.IndexOf("Александр"), "Саша");

			Console.WriteLine("Первые покупатели: " + customers);
			Console.WriteLine(Environment.NewLine);

			var countries = new MyList<string>(5)
			{
				[0] = "Russia",
				[1] = "USA",
				[2] = "Canada",
				[3] = "Australia"
			};

			Console.WriteLine("Страны: " + countries);
			Console.WriteLine("Вместимость: " + countries.Capacity);
			Console.WriteLine("Количество стран: " + countries.Count);
			Console.WriteLine(Environment.NewLine);

			countries.Remove("Russia");

			Console.WriteLine("Страны после удаления России: " + countries);

			Console.ReadKey();
		}
	}
}
