using System.Collections.Generic;

namespace Shapes
{
	class CompareShapesAreas : IComparer<IShape>
	{
		public int Compare(IShape shape1, IShape shape2)
		{
			if (shape1.GetArea().CompareTo(shape2.GetArea()) != 0)
			{
				return shape1.GetArea().CompareTo(shape2.GetArea());
			}
			else
			{
				return 0;
			}
		}
	}
}
