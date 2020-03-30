using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas
{
	class Lambdas
	{
		static void Main(string[] args)
		{
			var persons = new List<Person>
			{
				new Person(45, "Иван"),
				new Person(32, "Сергей"),
				new Person(18, "Александр"),
				new Person(1, "Сергей"),
				new Person(8, "Павел"),
				new Person(36, "Тимур"),
				new Person(10, "Антон"),
				new Person(5, "Иван")
			};

			var sortedUniqueNamesPersons = persons
				.Select(p => p.Name)
				.Distinct()
				.OrderBy(p => p)
				.ToList();

			Console.WriteLine(String.Join(", ", sortedUniqueNamesPersons));
			Console.WriteLine("Имена: " + String.Join(", ", sortedUniqueNamesPersons) + ".");
			Console.WriteLine(Environment.NewLine);

			var filteredPersons = persons
				.Where(p => p.Age < 18);

			var filteredPersonsNames = filteredPersons
				.Select(p => p.Name)
				.OrderBy(p => p)
				.ToList();

			double filteredPersonsAverageAge = filteredPersons
				.Select(f => f.Age)
				.Average();

			Console.WriteLine("Имена людей с возрастом < 18 лет: " + String.Join(", ", filteredPersonsNames));
			Console.WriteLine("Средний возраст людей с возрастом < 18 лет: " + filteredPersonsAverageAge);
			Console.WriteLine(Environment.NewLine);

			var personsByName = persons
				.GroupBy(p => p.Name, p => p.Age)
				.OrderBy(p => p.Key)
				.ToDictionary(p => p.Key, p => p.ToList().Average());

			int personNameMaxLength = persons
				.Max(p => p.Name.Length);

			foreach (KeyValuePair<string, double> kvp in personsByName)
			{
				Console.WriteLine("Имя: " + kvp.Key.ToString().PadRight(personNameMaxLength) + " ; Средний возраст: " + kvp.Value);
			}

			Console.WriteLine(Environment.NewLine);

			var filteredNamesPersons = persons
				.Where(p => p.Age >= 20 && p.Age <= 45)
				.OrderByDescending(p => p.Age)
				.Select(p => p.Name);

			Console.WriteLine("Имена людей с возрастом от 20 до 45: " + String.Join(", ", filteredNamesPersons));

			Console.ReadKey();
		}
	}
}
