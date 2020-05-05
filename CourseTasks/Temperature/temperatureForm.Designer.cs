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
			this.resultingScale = new System.Windows.Forms.ComboBox();
			this.initialValueLabel = new System.Windows.Forms.Label();
			this.resultingValue = new System.Windows.Forms.TextBox();
			this.initialScale = new System.Windows.Forms.ComboBox();
			this.resultingValueLabel = new System.Windows.Forms.Label();
			this.initialValue = new System.Windows.Forms.TextBox();
			this.converterButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// resultingScale
			// 
			this.resultingScale.AllowDrop = true;
			this.resultingScale.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resultingScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.resultingScale.FormattingEnabled = true;
			this.resultingScale.Items.AddRange(new object[] {
            "Кельвин",
            "Градус Цельсия",
            "Градус Фаренгейта"});
			this.resultingScale.Location = new System.Drawing.Point(404, 97);
			this.resultingScale.Name = "resultingScale";
			this.resultingScale.Size = new System.Drawing.Size(326, 21);
			this.resultingScale.TabIndex = 5;
			this.resultingScale.TabStop = false;
			// 
			// initialValueLabel
			// 
			this.initialValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.initialValueLabel.AutoSize = true;
			this.initialValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.initialValueLabel.Location = new System.Drawing.Point(19, 9);
			this.initialValueLabel.Name = "initialValueLabel";
			this.initialValueLabel.Size = new System.Drawing.Size(220, 26);
			this.initialValueLabel.TabIndex = 0;
			this.initialValueLabel.Text = "Исходная величина:";
			this.initialValueLabel.UseMnemonic = false;
			// 
			// resultingValue
			// 
			this.resultingValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resultingValue.Location = new System.Drawing.Point(404, 54);
			this.resultingValue.Name = "resultingValue";
			this.resultingValue.ReadOnly = true;
			this.resultingValue.ShortcutsEnabled = false;
			this.resultingValue.Size = new System.Drawing.Size(326, 20);
			this.resultingValue.TabIndex = 1;
			// 
			// initialScale
			// 
			this.initialScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.initialScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.initialScale.FormattingEnabled = true;
			this.initialScale.Items.AddRange(new object[] {
            "Кельвин",
            "Градус Цельсия",
            "Градус Фаренгейта"});
			this.initialScale.Location = new System.Drawing.Point(24, 97);
			this.initialScale.Name = "initialScale";
			this.initialScale.Size = new System.Drawing.Size(326, 21);
			this.initialScale.TabIndex = 2;
			this.initialScale.TabStop = false;
			// 
			// resultingValueLabel
			// 
			this.resultingValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.resultingValueLabel.AutoSize = true;
			this.resultingValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.resultingValueLabel.Location = new System.Drawing.Point(407, 9);
			this.resultingValueLabel.Name = "resultingValueLabel";
			this.resultingValueLabel.Size = new System.Drawing.Size(305, 26);
			this.resultingValueLabel.TabIndex = 3;
			this.resultingValueLabel.Text = "Преобразованная величина:";
			// 
			// initialValue
			// 
			this.initialValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.initialValue.Location = new System.Drawing.Point(24, 54);
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
			this.converterButton.Location = new System.Drawing.Point(293, 149);
			this.converterButton.Name = "converterButton";
			this.converterButton.Size = new System.Drawing.Size(151, 45);
			this.converterButton.TabIndex = 6;
			this.converterButton.Text = "Преобразовать";
			this.converterButton.UseVisualStyleBackColor = false;
			this.converterButton.Click += new System.EventHandler(this.ConverterButton_Click);
			// 
			// TemperatureForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(764, 231);
			this.Controls.Add(this.converterButton);
			this.Controls.Add(this.resultingScale);
			this.Controls.Add(this.initialValue);
			this.Controls.Add(this.resultingValueLabel);
			this.Controls.Add(this.initialScale);
			this.Controls.Add(this.resultingValue);
			this.Controls.Add(this.initialValueLabel);
			this.MinimumSize = new System.Drawing.Size(780, 270);
			this.Name = "TemperatureForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Temperature Converter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label initialValueLabel;
		private System.Windows.Forms.TextBox resultingValue;
		private System.Windows.Forms.ComboBox initialScale;
		private System.Windows.Forms.Label resultingValueLabel;
		private System.Windows.Forms.TextBox initialValue;
		private System.Windows.Forms.Button converterButton;
		private System.Windows.Forms.ComboBox resultingScale;
	}
}

