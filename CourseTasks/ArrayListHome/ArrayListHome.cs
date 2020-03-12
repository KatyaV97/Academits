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
			foreach (int e in numbers)
			{
				if (e % 2 == 0)
				{
					numbers.Remove(e);

					RemoveAllEvenNumbers(numbers);
					break;
				}
			}
		}

		public static void RemoveDublicateNumbers(List<int> numbers)
		{
			for (int i = 0; i < numbers.Count - 1; i++)
			{
				for (int j = i + 1; j < numbers.Count; j++)
				{
					if (numbers[i] == numbers[j])
					{
						numbers.RemoveAt(j);

						RemoveDublicateNumbers(numbers);
						break;
					}
				}
			}
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

			List<int> numbers1 = new List<int> { 5, 2, 6, 9, 2, 10, 11, 19 };

			RemoveAllEvenNumbers(numbers1);

			foreach (int e in numbers1)
			{
				Console.WriteLine(e);
			}

			Console.WriteLine(Environment.NewLine);

			List<int> numbers2 = new List<int> { 48, 56, 9, 3, 2, 5, 48, 2 };

			RemoveDublicateNumbers(numbers2);

			foreach (int e in numbers2)
			{
				Console.WriteLine(e);
			}

			Console.ReadKey();
		}
	}
}
