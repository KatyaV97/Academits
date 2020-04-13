namespace Temperature
{
	class TemperatureConversion
	{
		private readonly double value;
		private readonly string initialUnit;
		private readonly string resultingUnit;

		public TemperatureConversion(double value, string initialUnit, string resultingUnit)
		{
			this.value = value;
			this.initialUnit = initialUnit;
			this.resultingUnit = resultingUnit;
		}

		public double GetConversion()
		{
			switch (resultingUnit)
			{
				case "Кельвин":
					return ConvertToKelvin();
				case "Градус Цельсия":
					return ConvertToCelsius();
				case "Градус Фаренгейта":
					return ConvertToFahrenheit();
				default:
					return -1;
			}
		}

		public double ConvertToKelvin()
		{
			switch (initialUnit)
			{
				case "Кельвин":
					return value;
				case "Градус Цельсия":
					return value + 273.15;
				case "Градус Фаренгейта":
					return (value - 32) / 1.8 + 273.15;
				default:
					return -1;
			}
		}

		public double ConvertToCelsius()
		{
			switch (initialUnit)
			{
				case "Кельвин":
					return value - 273.15;
				case "Градус Цельсия":
					return value;
				case "Градус Фаренгейта":
					return (value - 32) / 1.8;
				default:
					return -1;
			}
		}

		public double ConvertToFahrenheit()
		{
			switch (initialUnit)
			{
				case "Кельвин":
					return (value - 273.15) * 9 / 5 + 32;
				case "Градус Цельсия":
					return value * 9 / 5 + 32;
				case "Градус Фаренгейта":
					return value;
				default:
					return -1;
			}
		}
	}
}
