using System;

namespace Range
{
	class Range
	{
		public double From { get; set; }

		public double To { get; set; }

		public Range(double from, double to)
		{
			From = from;
			To = to;
		}

		public double GetLength()
		{
			return To - From;
		}

		public bool IsInside(double x)
		{
			return x >= From && x <= To;
		}

		public Range[] GetIntersection(Range range)
		{
			if (From >= range.To || To <= range.From)
			{
				return null;
			}

			return new Range[] { new Range(Math.Max(From, range.From), Math.Min(To, range.To)) };
		}

		public Range[] GetUnion(Range range)
		{
			if (From > range.To || To < range.From)
			{
				return new Range[] { new Range(From, To), new Range(range.From, range.To) };
			}

			return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
		}

		public Range[] GetDifference(Range range)
		{
			if (From >= range.To || To <= range.From)
			{
				return new Range[] { new Range(From, To) };
			}

			if (range.From <= From && range.To >= To)
			{
				return new Range[] { };
			}

			if (range.From > From && range.To < To)
			{
				return new Range[] { new Range(From, range.From), new Range(range.To, To) };
			}

			if (range.From <= From && range.To < To)
			{
				return new Range[] { new Range(range.To, To) };
			}

			return new Range[] { new Range(From, range.From) };
		}

		public static void Print(Range[] ranges)
		{
			if (ranges.Length == 0)
			{
				Console.WriteLine("[]");
			}
			else if(ranges.Length == 1)
			{
				Console.WriteLine("(" + ranges[0].From + ";" + ranges[0].To + ")");
			}
			else
			{
				Console.Write("[");

				for (int i = 0; i < ranges.Length; i++)
				{
					Console.Write("(" + ranges[i].From + ";" + ranges[i].To + ")");

					if (i < ranges.Length - 1)
					{
						Console.Write(",");
					}
				}

				Console.WriteLine("]");
			}
		}
	}
}
