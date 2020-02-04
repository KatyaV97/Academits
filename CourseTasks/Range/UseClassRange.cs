using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
	class UseClassRange
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите начальное значение диапазона: ");
			double from = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine("Введите конечное значение диапазона: ");
			double to = Convert.ToDouble(Console.ReadLine());

			Range range = new Range(from, to);
			
			Console.WriteLine("Длина заданного диапазона: " + range.GetLength());

			Console.WriteLine("Введите число: ");
			double x = Convert.ToDouble(Console.ReadLine());

			if (range.IsInside(x))
			{
				Console.WriteLine("Введенное число находится в указанном диапазоне.");
			}
			else
			{
				Console.WriteLine("Введенное число не находится в указанном диапазоне.");
			}

			Console.ReadKey();
		}
	}
}
