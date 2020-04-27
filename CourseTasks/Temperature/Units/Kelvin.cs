namespace Temperature.Units
{
	class Kelvin : Unit
	{
		public Kelvin(double value): base (value)
		{
			this.value = value;
		}

		public override double ConvertToCelsius()
		{
			return value - 273.15;
		}
	}
}
