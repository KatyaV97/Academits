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
			Console.WriteLine("Введите начальное значение первого диапазона: ");
			double from1 = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine("Введите конечное значение первого диапазона: ");
			double to1 = Convert.ToDouble(Console.ReadLine());

			Range range1 = new Range(from1, to1);

			Console.WriteLine("Длина заданного диапазона: " + range1.GetLength());

			Console.WriteLine("Введите число: ");
			double x = Convert.ToDouble(Console.ReadLine());

			if (range1.IsInside(x))
			{
				Console.WriteLine("Введенное число находится в первом диапазоне.");
			}
			else
			{
				Console.WriteLine("Введенное число не находится в первом диапазоне.");
			}

			Console.WriteLine(Environment.NewLine + "Введите начальное значение второго диапазона: ");
			double from2 = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine("Введите конечное значение второго диапазона: ");
			double to2 = Convert.ToDouble(Console.ReadLine());

			Range range2 = new Range(from2, to2);

			Console.WriteLine("Длина заданного диапазона: " + range2.GetLength());

			Console.WriteLine(Environment.NewLine + "Результат пересечения диапазонов:");

			if (range1.GetIntersection(from2, to2) == null)
			{
				Console.WriteLine("Второй диапазон не пересекается с первым.");
			}
			else
			{
				double[] intersectionRange = range1.GetIntersection(from2, to2);

				Console.WriteLine("Новый диапазон от " + intersectionRange[0] + " до " + intersectionRange[1] + ".");
			}

			double[] unionRange = range1.GetUnion(from2, to2);

			Console.WriteLine(Environment.NewLine + "Результат объединения диапазонов:");

			if (unionRange[2] == 0 && unionRange[3] == 0)
			{
				Console.WriteLine("Новый диапазон от " + unionRange[0] + " до " + unionRange[1] + ".");
			}
			else
			{
				Console.Write("Новый диапазон: от " + unionRange[0] + " до " + unionRange[1] + " и ");
				Console.WriteLine("от " + unionRange[2] + " до " + unionRange[3] + ".");
			}

			Console.WriteLine(Environment.NewLine + "Результат разности диапазонов:");

			if (range1.GetDifference(from2, to2) == null)
			{
				Console.WriteLine("Первый диапазон полностью вычитается из второго.");
			}
			else
			{
				double[] differenceRange = range1.GetDifference(from2, to2);

				if (differenceRange[2] == 0 && differenceRange[3] == 0)
				{
					Console.WriteLine("Новый диапазон от " + differenceRange[0] + " до " + differenceRange[1] + ".");
				}
				else
				{
					Console.Write("Новый диапазон: от " + differenceRange[0] + " до " + differenceRange[1] + " и ");
					Console.WriteLine("от " + differenceRange[2] + " до " + differenceRange[3] + ".");
				}
			}

			Console.ReadKey();
		}
	}
}
