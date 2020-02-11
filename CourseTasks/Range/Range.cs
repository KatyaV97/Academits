using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public Range GetIntersection(Range range)
		{
			double otherFrom = range.From;
			double otherTo = range.To;

			if (From >= otherTo || To <= otherFrom)
			{
				return null;
			}

			if (From > otherFrom)
			{
				otherFrom = From;
			}

			if (To < otherTo)
			{
				otherTo = To;
			}

			Range newRange = new Range(otherFrom, otherTo);

			return newRange;
		}

		public Range[] GetUnion(Range range)
		{
			double otherFrom = range.From;
			double otherTo = range.To;

			Range[] newRanges = new Range[2];

			if (From > otherTo || To < otherFrom)
			{
				Range newRange1 = new Range(From, To);
				Range newRange2 = new Range(otherFrom, otherTo);

				newRanges[0] = newRange1;
				newRanges[1] = newRange2;

				return newRanges;
			}

			if (From < otherFrom)
			{
				otherFrom = From;
			}

			if (To > range.To)
			{
				otherTo = To;
			}

			Range newRange = new Range(otherFrom, otherTo);
			newRanges[0] = newRange;

			return newRanges;
		}

		public Range[] GetDifference(Range range)
		{
			double otherFrom = range.From;
			double otherTo = range.To;

			Range[] newRanges = new Range[2];

			if (From >= otherTo || To <= otherFrom)
			{
				Range newRange1 = new Range(From, To);
				newRanges[0] = newRange1;

				return newRanges;
			}

			if (otherFrom <= From && otherTo >= To)
			{
				return newRanges;
			}

			if (otherFrom > From && otherTo < To)
			{
				Range newRange1 = new Range(From, otherFrom);
				Range newRange2 = new Range(otherTo, To);
				newRanges[0] = newRange1;
				newRanges[1] = newRange2;

				return newRanges;
			}

			if (otherFrom < From && otherTo < To)
			{
				Range newRange2 = new Range(otherTo, To);
				newRanges[0] = newRange2;

				return newRanges;
			}

			Range newRange = new Range(From, otherFrom);
			newRanges[0] = newRange;

			return newRanges;
		}

		public void Print()
		{
			Console.WriteLine("[(" + From + ";" + To + ")]");
		}
	}
}
