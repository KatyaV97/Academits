namespace Temperature.Units
{
	class Fahrenheit:Unit
	{
		public Fahrenheit(double value) : base(value)
		{
			this.value = value;
		}

		public override double ConvertToCelsius()
		{
			return (value - 32) / 1.8;
		}
	}
}
