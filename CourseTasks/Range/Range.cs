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

		public double[] GetIntersection(double otherFrom, double otherTo)
		{
			double[] range = new double[] { otherFrom, otherTo };

			if (From > range[1] || To < range[0])
			{
				return null;
			}

			if (From > range[0])
			{
				range[0] = From;
			}

			if (To < range[1])
			{
				range[1] = To;
			}

			return range;
		}

		public double[] GetUnion(double otherFrom, double otherTo)
		{
			double[] range = new double[4] { otherFrom, otherTo, 0, 0 };

			if (From > range[1] || To < range[0])
			{
				range[0] = From;
				range[1] = To;
				range[2] = otherFrom;
				range[3] = otherTo;
				return range;
			}

			if (From < range[0])
			{
				range[0] = From;
			}

			if (To > range[1])
			{
				range[1] = To;
			}

			return range;
		}

		public double[] GetDifference(double otherFrom, double otherTo)
		{
			double[] range = new double[4] { otherFrom, otherTo, 0, 0 };

			if (From > range[1] || To < range[0])
			{
				range[0] = From;
				range[1] = To;

				return range;
			}

			if (range[0] < From && range[1] > To)
			{
				return null;
			}

			if (range[0] > From && range[1] < To)
			{
				range[0] = From;
				range[1] = otherFrom;
				range[2] = otherTo;
				range[3] = To;

				return range;
			}

			if (range[0] < From && range[1] < To)
			{
				range[0] = range[1];
				range[1] = To;

				return range;
			}

			range[0] = From;
			range[1] = range[0];

			return range;
		}
	}
}
