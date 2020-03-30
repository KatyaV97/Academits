namespace Lambdas
{
	class Person
	{
		public string Name { get; set; }

		public int Age { get; set; }

		public Person(int age, string name)
		{
			Age = age;
			Name = name;
		}
	}
}
