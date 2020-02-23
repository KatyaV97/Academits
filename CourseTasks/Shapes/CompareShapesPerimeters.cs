using System.Collections.Generic;

namespace Shapes
{
	class CompareShapesPerimeters : IComparer<IShape>
	{
		public int Compare(IShape shape1, IShape shape2)
		{
			if (shape1.GetPerimeter().CompareTo(shape2.GetPerimeter()) != 0)
			{
				return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
			}
			else
			{
				return 0;
			}
		}
	}
}
