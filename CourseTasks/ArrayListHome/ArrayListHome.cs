using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayListHome
{
	class ArrayListHome
	{
		public static List<string> GetLinesFromFile(string filePath)
		{
			List<string> lines = new List<string>();

			try
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string currentLine;

					while ((currentLine = reader.ReadLine()) != null)
					{
						lines.Add(currentLine);
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Ошибка при чтении файла.");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка при чтении файла.");
			}

			return lines;
		}

		public static void RemoveEvenNumbers(List<int> numbers)
		{
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] % 2 == 0)
				{
					numbers.RemoveAt(i);

					i--;
				}
			}
		}

		public static List<int> GetNumbersWithoutDuplicates(List<int> numbersWithDuplicates)
		{
			List<int> numbersWithoutDuplicates = new List<int>();

			foreach (int e in numbersWithDuplicates)
			{
				if (!numbersWithoutDuplicates.Contains(e))
				{
					numbersWithoutDuplicates.Add(e);
				}
			}

			return numbersWithoutDuplicates;
		}

		static void Main(string[] args)
		{
			string filePath = "..\\..\\TextFile.txt";
			List<string> fileLines = GetLinesFromFile(filePath);

			foreach (string e in fileLines)
			{
				Console.WriteLine(e);
			}

			List<int> numbers1 = new List<int> { 5, 2, 6, 9, 2, 10, 11, 19, 2 };

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Список чисел: " + Environment.NewLine);

			foreach (int e in numbers1)
			{
				Console.Write(e + " ");
			}

			RemoveEvenNumbers(numbers1);

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Список нечетных чисел: " + Environment.NewLine);

			foreach (int e in numbers1)
			{
				Console.Write(e + " ");
			}

			Console.WriteLine(Environment.NewLine);

			List<int> numbers2 = new List<int> { 0, 2, 0, 2, 10, 15, 45, 0 };
			List<int> numbers2WithoutDuplicate = GetNumbersWithoutDuplicates(numbers2);

			Console.WriteLine("Список чисел: " + Environment.NewLine);

			foreach (int e in numbers2)
			{
				Console.Write(e + " ");
			}

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Список чисел без повторений: " + Environment.NewLine);

			foreach (int e in numbers2WithoutDuplicate)
			{
				Console.Write(e + " ");
			}

			Console.ReadKey();
		}
	}
}
