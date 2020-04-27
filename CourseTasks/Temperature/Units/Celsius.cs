namespace Temperature.Units
{
	class Celsius : Unit
	{
		public Celsius(double value) : base(value)
		{
			this.value = value;
		}

		public override double ConvertToCelsius()
		{
			return value;
		}
	}
}
