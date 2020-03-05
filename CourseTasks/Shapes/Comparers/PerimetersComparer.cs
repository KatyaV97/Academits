using System.Collections.Generic;

namespace Shapes.Comparers
{
	class PerimetersComparer : IComparer<IShape>
	{
		public int Compare(IShape shape1, IShape shape2)
		{
			return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
		}
	}
}