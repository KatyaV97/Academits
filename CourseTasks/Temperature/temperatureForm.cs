using System;
using System.Windows.Forms;
using Temperature.Units;

namespace Temperature
{
	public partial class TemperatureForm : Form
	{
		public TemperatureForm()
		{
			InitializeComponent();

			initialUnit.SelectedItem = "Кельвин";
			resultingUnit.SelectedItem = "Кельвин";
		}

		private void ConverterButton_Click(object sender, EventArgs e)
		{
			try
			{
				var temperatureValue = Convert.ToDouble(initialValue.Text);

				switch (initialUnit.Text.ToString())
				{
					case "Кельвин":
						var kelvin = new Kelvin(temperatureValue);
						resultingValue.Text = kelvin.ConvertTo(resultingUnit.Text).ToString();
						break;
					case "Градус Цельсия":
						var celsius = new Celsius(temperatureValue);
						resultingValue.Text = celsius.ConvertTo(resultingUnit.Text).ToString();
						break;
					case "Градус Фаренгейта":
						var fahrenheit = new Fahrenheit(temperatureValue);
						resultingValue.Text = fahrenheit.ConvertTo(resultingUnit.Text).ToString();
						break;
				}
			}
			catch (FormatException)
			{
				MessageBox.Show(
					"Некорректное значение исходной температуры",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					MessageBoxOptions.DefaultDesktopOnly);
			}
		}
	}
}
