namespace Temperature.Scales
{
	interface ITemperatureScale
	{
		string Name { get; set; }

		double ConvertFromCelsius(double value, string scale);

		double ConvertToCelsius(double value);
	}
}
