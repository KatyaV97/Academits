using System;

namespace Range
{
	class RangeProgram
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

			if (range1.GetIntersection(range2) == null)
			{
				Console.WriteLine("Второй диапазон не пересекается с первым.");
			}
			else
			{
				Range intersection = range1.GetIntersection(range2);

				Range.Print(intersection);
			}

			Console.WriteLine(Environment.NewLine + "Результат объединения диапазонов:");

			Range[] union = range1.GetUnion(range2);

			Range.Print(union);

			Console.WriteLine(Environment.NewLine + "Результат разности диапазонов:");

			Range[] difference = range1.GetDifference(range2);

			Range.Print(difference);

			Console.ReadKey();
		}
	}
}
