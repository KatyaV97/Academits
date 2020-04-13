namespace Temperature
{
	partial class TemperatureForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.resultingUnit = new System.Windows.Forms.ComboBox();
			this.initialValueLabel = new System.Windows.Forms.Label();
			this.resultingValue = new System.Windows.Forms.TextBox();
			this.initialUnit = new System.Windows.Forms.ComboBox();
			this.resultingValueLabel = new System.Windows.Forms.Label();
			this.initialValue = new System.Windows.Forms.TextBox();
			this.converterButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// resultingUnit
			// 
			this.resultingUnit.AllowDrop = true;
			this.resultingUnit.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resultingUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.resultingUnit.FormattingEnabled = true;
			this.resultingUnit.Items.AddRange(new object[] {
            "Кельвин",
            "Градус Цельсия",
            "Градус Фаренгейта"});
			this.resultingUnit.Location = new System.Drawing.Point(417, 97);
			this.resultingUnit.Name = "resultingUnit";
			this.resultingUnit.Size = new System.Drawing.Size(326, 21);
			this.resultingUnit.TabIndex = 5;
			this.resultingUnit.TabStop = false;
			// 
			// initialValueLabel
			// 
			this.initialValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.initialValueLabel.AutoSize = true;
			this.initialValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.initialValueLabel.Location = new System.Drawing.Point(12, 9);
			this.initialValueLabel.Name = "initialValueLabel";
			this.initialValueLabel.Size = new System.Drawing.Size(220, 26);
			this.initialValueLabel.TabIndex = 0;
			this.initialValueLabel.Text = "Исходная величина:";
			this.initialValueLabel.UseMnemonic = false;
			// 
			// resultingValue
			// 
			this.resultingValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resultingValue.Location = new System.Drawing.Point(417, 54);
			this.resultingValue.Name = "resultingValue";
			this.resultingValue.ReadOnly = true;
			this.resultingValue.ShortcutsEnabled = false;
			this.resultingValue.Size = new System.Drawing.Size(326, 20);
			this.resultingValue.TabIndex = 1;
			// 
			// initialUnit
			// 
			this.initialUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.initialUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.initialUnit.FormattingEnabled = true;
			this.initialUnit.Items.AddRange(new object[] {
            "Кельвин",
            "Градус Цельсия",
            "Градус Фаренгейта"});
			this.initialUnit.Location = new System.Drawing.Point(17, 97);
			this.initialUnit.Name = "initialUnit";
			this.initialUnit.Size = new System.Drawing.Size(326, 21);
			this.initialUnit.TabIndex = 2;
			this.initialUnit.TabStop = false;
			// 
			// resultingValueLabel
			// 
			this.resultingValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resultingValueLabel.AutoSize = true;
			this.resultingValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.resultingValueLabel.Location = new System.Drawing.Point(412, 9);
			this.resultingValueLabel.Name = "resultingValueLabel";
			this.resultingValueLabel.Size = new System.Drawing.Size(305, 26);
			this.resultingValueLabel.TabIndex = 3;
			this.resultingValueLabel.Text = "Преобразованная величина:";
			// 
			// initialValue
			// 
			this.initialValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.initialValue.Location = new System.Drawing.Point(17, 54);
			this.initialValue.Name = "initialValue";
			this.initialValue.Size = new System.Drawing.Size(326, 20);
			this.initialValue.TabIndex = 4;
			// 
			// converterButton
			// 
			this.converterButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.converterButton.BackColor = System.Drawing.Color.Lime;
			this.converterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.converterButton.ForeColor = System.Drawing.Color.Black;
			this.converterButton.Location = new System.Drawing.Point(306, 149);
			this.converterButton.Name = "converterButton";
			this.converterButton.Size = new System.Drawing.Size(151, 45);
			this.converterButton.TabIndex = 6;
			this.converterButton.Text = "Преобразовать";
			this.converterButton.UseVisualStyleBackColor = false;
			this.converterButton.Click += new System.EventHandler(this.ConverterButton_Click);
			// 
			// temperatureForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(770, 233);
			this.Controls.Add(this.converterButton);
			this.Controls.Add(this.resultingUnit);
			this.Controls.Add(this.initialValue);
			this.Controls.Add(this.resultingValueLabel);
			this.Controls.Add(this.initialUnit);
			this.Controls.Add(this.resultingValue);
			this.Controls.Add(this.initialValueLabel);
			this.Name = "temperatureForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Temperature Converter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label initialValueLabel;
		private System.Windows.Forms.TextBox resultingValue;
		private System.Windows.Forms.ComboBox initialUnit;
		private System.Windows.Forms.Label resultingValueLabel;
		private System.Windows.Forms.TextBox initialValue;
		private System.Windows.Forms.Button converterButton;
		private System.Windows.Forms.ComboBox resultingUnit;
	}
}

