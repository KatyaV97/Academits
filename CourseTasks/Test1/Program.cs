using System;
using System.Collections.Generic;

namespace Test1
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 10;
			Dictionary<string, List<string>> _tagsDic = new Dictionary<string, List<string>>();
			
			for (int i = 0; i < count; i++)
			{
				int count2 = 2;

				List<string> test1 = new List<string>();

				for (int j = 0; j < count2; j++)
				{
					test1.Add(i.ToString());
				}

				_tagsDic.Add(i.ToString(), test1);
			}

			foreach (KeyValuePair<string, List<string>> kvp in _tagsDic)
			{
				foreach (string kvp2 in kvp.Value)
				{
					Console.Write(kvp2);
				}

				Console.WriteLine(Environment.NewLine);
			}
		}
	}
}
