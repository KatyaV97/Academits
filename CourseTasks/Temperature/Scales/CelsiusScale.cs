namespace Temperature.Scales
{
	class CelsiusScale : ITemperatureScale
	{
		public string Name { get; set; }

		public CelsiusScale()
		{
			Name = "Градус Цельсия";
		}

		public double ConvertFromCelsius(double value, string scale)
		{
			var convertedValue = ConvertToCelsius(value);

			switch (scale)
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

		public double ConvertToCelsius(double value)
		{
			return value;
		}
	}
}
