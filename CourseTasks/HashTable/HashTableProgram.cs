using System;

namespace HashTable
{
	class HashTableProgram
	{
		static void Main(string[] args)
		{
			var words = new MyHashTable<string>();

			words.Add("long");
			words.Add("blue");
			words.Add("long");

			Console.WriteLine("Слова из хэш таблицы: " + words + Environment.NewLine);

			words.Clear();

			words.Add("word");
			words.Add("line");
			words.Add("smile");
			words.Add("web");

			Console.WriteLine("Слова из хэш таблицы: " + words + Environment.NewLine);

			words.Remove("word");

			if (words.Contains("word"))
			{
				Console.WriteLine("Таблица содержит слово: word." + Environment.NewLine);
			}
			else
			{
				Console.WriteLine("Таблица не содержит слово: word." + Environment.NewLine);
			}

			for (var i = 0; i < words.Capacity / 10; i++)
			{
				words.Add("word" + i);
			}

			var currentWords = new string[50];

			words.CopyTo(currentWords, 0);

			Console.Write("Слова из массива: ");

			foreach (var word in currentWords)
			{
				Console.Write(word + " ");
			}

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Слова из хэш таблицы: " + words + Environment.NewLine);

			words.Remove("word");
			words.Remove("word8");
			words.Remove("word2");

			Console.WriteLine("Слова из хэш таблицы после удаления нескольких слов: " + words + Environment.NewLine);

			var numbersArrays = new MyHashTable<double[]>(50);

			numbersArrays.Add(new double[] { 2, 9, 3 });
			numbersArrays.Add(new double[] { 48, 36, 36, 45, 20 });
			numbersArrays.Add(new double[] { 10, 25 });
			numbersArrays.Add(new double[] { 7, 3 });

			Console.WriteLine("Числа из хэш таблицы:" + Environment.NewLine);

			foreach (var numbers in numbersArrays)
			{
				foreach (var number in numbers)
				{
					Console.Write(number + " ");
				}

				Console.WriteLine(Environment.NewLine);
			}

			var currentNumbers = new double[4][];

			numbersArrays.CopyTo(currentNumbers, 0);

			Console.WriteLine("Числа из массива:" + Environment.NewLine);

			foreach (var numbers in currentNumbers)
			{
				foreach (var number in numbers)
				{
					Console.Write(number + " ");
				}

				Console.WriteLine(Environment.NewLine);
			}

			Console.ReadKey();
		}
	}
}
