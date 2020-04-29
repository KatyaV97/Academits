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
				using (var writer = new StreamWriter(htmlPath))
				{
					writer.Write("<table>");

					using (var reader = new StreamReader(csvPath))
					{
						string currentLine;

						while ((currentLine = reader.ReadLine()) != null)
						{
							writer.Write("<tr>");

							if (!HasQuotes(currentLine))
							{
								var cellsData = currentLine.Split(new string[] { "," }, StringSplitOptions.None);

								foreach (var data in cellsData)
								{
									writer.Write("<td>" + data + "</td>");
								}
							}
							else
							{
								var startIndex = 0;
								var endIndex = currentLine.Length;

								while (currentLine.Length != 0)
								{
									currentLine = currentLine.Substring(startIndex, endIndex);

									writer.Write("<td>" + GetCellData(currentLine) + "</td>");

									startIndex = currentLine.Length;
								}
							}
							writer.Write("</tr>");
						}

					}

					writer.Write("</table>");
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

		private static bool HasQuotes(string line)
		{
			return line.Contains("\"");
		}

		private static string GetCellData(string line)
		{
			var quotesIndex = line.IndexOf("\"");
			var commaIndex = line.IndexOf(",");

			//Перенос строки
			if (quotesIndex > commaIndex)
			{
				return line.Substring(0, commaIndex);
			}
			else if (quotesIndex < commaIndex)
			{
				var cellData = line.Substring(0, quotesIndex);
				line.Substring(quotesIndex);

				ChangeLine(line);
			}
		}
			   
		private static string ChangeLine(string line)
		{
			if (line.StartsWith("\",\""))
			{
				return line.Replace("\",\"", ",");
			}

			if (line.StartsWith("\"\"\"\""))
			{
				return line.Replace("\"\"\"\"", "\"");
			}

			if (line.StartsWith("\"\",\""))
			{
				return line.Replace("\"\",\"", "\",");
			}

			if (line.StartsWith("\""))
			{
				return line.Replace("\"", "");
			}

			return line;
		}

		static void Main(string[] args)
		{
			var csvPath = "..\\..\\test.csv";
			var htmlPath = "..\\..\\test1.html";

			TransformCsvToHtml(csvPath, htmlPath);
		}
	}
}

