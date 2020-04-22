using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv
{
	class CsvProgram
	{
		public static void TransformCsvToHtml(string csvPath, string htmlPath)
		{
			try
			{
				using (StreamReader reader = new StreamReader(csvPath))
				{
					string currentLine;

					while ((currentLine = reader.ReadLine()) != null)
					{
						
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не найден.");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка при чтении файла.");
			}
		}

		static void Main(string[] args)
		{
			string csvPath = "..\\..\\test.csv";
			string htmlPath = "..\\..\\test1.html";

			TransformCsvToHtml(csvPath, htmlPath);
		}
	}
}
