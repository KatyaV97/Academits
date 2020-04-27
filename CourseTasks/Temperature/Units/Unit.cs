namespace Temperature.Units
{
	public abstract class Unit
	{
		public double value;

		protected Unit(double value)
		{
			this.value = value;
		}

		public double ConvertTo(string unit)
		{
			var convertedValue = ConvertToCelsius();

			switch (unit)
			{
				case "Кельвин":
					return convertedValue + 273.15;
				case "Градус Цельсия":
					return convertedValue;
				case "Градус Фаренгейта":
					return convertedValue * 9 / 5 + 32;
				default:
					return -1;
			}
		}

		public abstract double ConvertToCelsius();
	}
}
