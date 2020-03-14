using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayListHome
{
	class ArrayListHome
	{
		public static void GetWordsFromFile(string filePath, List<string> words)
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				string currentLine;

				while ((currentLine = reader.ReadLine()) != null)
				{
					string[] lineWords = currentLine.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

					foreach (string e in lineWords)
					{
						words.Add(e);
					}
				}
			}
		}

		public static void RemoveAllEvenNumbers(List<int> numbers)
		{
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] % 2 == 0)
				{
					numbers.Remove(numbers[i]);

					i--;
				}
			}
		}

		public static List<int> RemoveDublicateNumbers(List<int> numbersWithDublicates)
		{
			List<int> numbersWithoutDublicates = new List<int>();

			for (int i = 0; i < numbersWithDublicates.Count; i++)
			{
				if (numbersWithoutDublicates.Contains(numbersWithDublicates[i]))
				{
					continue;
				}

				numbersWithoutDublicates.Add(numbersWithDublicates[i]);
			}

			return numbersWithoutDublicates;
		}

		static void Main(string[] args)
		{
			string filePath = "..\\..\\TextFile.txt";
			List<string> words = new List<string>();

			GetWordsFromFile(filePath, words);

			foreach (string e in words)
			{
				Console.WriteLine(e);
			}

			Console.WriteLine(Environment.NewLine);

			List<int> numbers1 = new List<int> { 5, 2, 6, 9, 2, 10, 11, 19, 2 };

			RemoveAllEvenNumbers(numbers1);

			foreach (int e in numbers1)
			{
				Console.WriteLine(e);
			}

			Console.WriteLine(Environment.NewLine);

			List<int> numbers2 = new List<int> { 0, 2, 0, 2 };

			List<int> numbersWithoutDublicate = RemoveDublicateNumbers(numbers2);

			foreach (int e in numbersWithoutDublicate)
			{
				Console.WriteLine(e);
			}

			Console.ReadKey();
		}
	}
}
