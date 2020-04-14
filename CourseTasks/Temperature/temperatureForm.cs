using System;
using System.Windows.Forms;

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
				var conversionResult = new TemperatureConversion(Convert.ToDouble(initialValue.Text), initialUnit.Text, resultingUnit.Text);
				resultingValue.Text = (conversionResult.GetConversion()).ToString();
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
