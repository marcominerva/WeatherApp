namespace WeatherApp.WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CityLabel = new System.Windows.Forms.Label();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.GetWeatherButton = new System.Windows.Forms.Button();
            this.ConditionCityLabel = new System.Windows.Forms.Label();
            this.ConditionImage = new System.Windows.Forms.PictureBox();
            this.ConditionLabel = new System.Windows.Forms.Label();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionImage)).BeginInit();
            this.SuspendLayout();
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(25, 30);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(50, 28);
            this.CityLabel.TabIndex = 0;
            this.CityLabel.Text = "&City:";
            // 
            // CityTextBox
            // 
            this.CityTextBox.Location = new System.Drawing.Point(81, 28);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(257, 34);
            this.CityTextBox.TabIndex = 1;
            // 
            // GetWeatherButton
            // 
            this.GetWeatherButton.Location = new System.Drawing.Point(354, 25);
            this.GetWeatherButton.Name = "GetWeatherButton";
            this.GetWeatherButton.Size = new System.Drawing.Size(257, 39);
            this.GetWeatherButton.TabIndex = 2;
            this.GetWeatherButton.Text = "Get Current Weather";
            this.GetWeatherButton.Click += new System.EventHandler(this.GetWeatherButton_Click);
            // 
            // ConditionCityLabel
            // 
            this.ConditionCityLabel.Location = new System.Drawing.Point(25, 103);
            this.ConditionCityLabel.Name = "ConditionCityLabel";
            this.ConditionCityLabel.Size = new System.Drawing.Size(586, 28);
            this.ConditionCityLabel.TabIndex = 0;
            this.ConditionCityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConditionImage
            // 
            this.ConditionImage.Location = new System.Drawing.Point(273, 134);
            this.ConditionImage.Name = "ConditionImage";
            this.ConditionImage.Size = new System.Drawing.Size(100, 100);
            this.ConditionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ConditionImage.TabIndex = 3;
            this.ConditionImage.TabStop = false;
            // 
            // ConditionLabel
            // 
            this.ConditionLabel.Location = new System.Drawing.Point(25, 237);
            this.ConditionLabel.Name = "ConditionLabel";
            this.ConditionLabel.Size = new System.Drawing.Size(586, 28);
            this.ConditionLabel.TabIndex = 0;
            this.ConditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.Location = new System.Drawing.Point(25, 265);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(586, 28);
            this.TemperatureLabel.TabIndex = 0;
            this.TemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 385);
            this.Controls.Add(this.TemperatureLabel);
            this.Controls.Add(this.ConditionLabel);
            this.Controls.Add(this.ConditionImage);
            this.Controls.Add(this.ConditionCityLabel);
            this.Controls.Add(this.CityTextBox);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.GetWeatherButton);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weather Client";
            ((System.ComponentModel.ISupportInitialize)(this.ConditionImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.Button GetWeatherButton;
        private System.Windows.Forms.Label ConditionCityLabel;
        private System.Windows.Forms.PictureBox ConditionImage;
        private System.Windows.Forms.Label ConditionLabel;
        private System.Windows.Forms.Label TemperatureLabel;
    }
}

