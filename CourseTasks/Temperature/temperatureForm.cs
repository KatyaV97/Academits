using System;
using System.Windows.Forms;
using Temperature.Scales;
using System.Collections.Generic;

namespace Temperature
{
	public partial class TemperatureForm : Form
	{
		private readonly List<ITemperatureScale> temperatureScales;

		public TemperatureForm()
		{
			InitializeComponent();

			initialScale.SelectedItem = "Кельвин";
			resultingScale.SelectedItem = "Кельвин";

			temperatureScales = new List<ITemperatureScale> { new KelvinScale(), new CelsiusScale(), new FahrenheitScale() };
		}

		private void ConverterButton_Click(object sender, EventArgs e)
		{
			try
			{
				var temperatureValue = Convert.ToDouble(initialValue.Text);

				foreach (var scale in temperatureScales)
				{
					if (scale.Name == initialScale.Text)
					{
						resultingValue.Text = (scale.ConvertFromCelsius(temperatureValue, resultingScale.Text)).ToString();
						break;
					}
				}
			}
			catch (FormatException)
			{
				MessageBox.Show(
					"Некорректное значение исходной температуры!",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					MessageBoxOptions.DefaultDesktopOnly);
			}
		}
	}
}
