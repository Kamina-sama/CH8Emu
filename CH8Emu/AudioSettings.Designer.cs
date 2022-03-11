
namespace CH8Emu
{
    partial class AudioSettings
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
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.hertzLabel = new System.Windows.Forms.Label();
            this.frequencyField = new System.Windows.Forms.NumericUpDown();
            this.waveTypeLabel = new System.Windows.Forms.Label();
            this.sineRadioButton = new System.Windows.Forms.RadioButton();
            this.squareRadioButton = new System.Windows.Forms.RadioButton();
            this.sawtoothRadioButton = new System.Windows.Forms.RadioButton();
            this.triangleRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyField)).BeginInit();
            this.SuspendLayout();
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 10;
            this.volumeBar.Location = new System.Drawing.Point(12, 32);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(253, 45);
            this.volumeBar.TabIndex = 0;
            this.volumeBar.TickFrequency = 5;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.volumeBar.Value = 50;
            this.volumeBar.ValueChanged += new System.EventHandler(this.VolumeBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Volume";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(9, 9);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(85, 13);
            this.frequencyLabel.TabIndex = 3;
            this.frequencyLabel.Text = "Tone frequency:";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(12, 122);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(190, 122);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // hertzLabel
            // 
            this.hertzLabel.AutoSize = true;
            this.hertzLabel.Location = new System.Drawing.Point(190, 9);
            this.hertzLabel.Name = "hertzLabel";
            this.hertzLabel.Size = new System.Drawing.Size(20, 13);
            this.hertzLabel.TabIndex = 7;
            this.hertzLabel.Text = "Hz";
            // 
            // frequencyField
            // 
            this.frequencyField.Location = new System.Drawing.Point(100, 7);
            this.frequencyField.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.frequencyField.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.frequencyField.Name = "frequencyField";
            this.frequencyField.Size = new System.Drawing.Size(84, 20);
            this.frequencyField.TabIndex = 8;
            this.frequencyField.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.frequencyField.ValueChanged += new System.EventHandler(this.FrequencyField_ValueChanged);
            // 
            // waveTypeLabel
            // 
            this.waveTypeLabel.AutoSize = true;
            this.waveTypeLabel.Location = new System.Drawing.Point(12, 80);
            this.waveTypeLabel.Name = "waveTypeLabel";
            this.waveTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.waveTypeLabel.TabIndex = 9;
            this.waveTypeLabel.Text = "Wave type:";
            // 
            // sineRadioButton
            // 
            this.sineRadioButton.AutoSize = true;
            this.sineRadioButton.Checked = true;
            this.sineRadioButton.Location = new System.Drawing.Point(15, 96);
            this.sineRadioButton.Name = "sineRadioButton";
            this.sineRadioButton.Size = new System.Drawing.Size(46, 17);
            this.sineRadioButton.TabIndex = 10;
            this.sineRadioButton.TabStop = true;
            this.sineRadioButton.Text = "Sine";
            this.sineRadioButton.UseVisualStyleBackColor = true;
            this.sineRadioButton.CheckedChanged += new System.EventHandler(this.sineRadioButton_CheckedChanged);
            this.sineRadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // squareRadioButton
            // 
            this.squareRadioButton.AutoSize = true;
            this.squareRadioButton.Location = new System.Drawing.Point(143, 96);
            this.squareRadioButton.Name = "squareRadioButton";
            this.squareRadioButton.Size = new System.Drawing.Size(59, 17);
            this.squareRadioButton.TabIndex = 11;
            this.squareRadioButton.TabStop = true;
            this.squareRadioButton.Text = "Square";
            this.squareRadioButton.UseVisualStyleBackColor = true;
            this.squareRadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // sawtoothRadioButton
            // 
            this.sawtoothRadioButton.AutoSize = true;
            this.sawtoothRadioButton.Location = new System.Drawing.Point(67, 96);
            this.sawtoothRadioButton.Name = "sawtoothRadioButton";
            this.sawtoothRadioButton.Size = new System.Drawing.Size(70, 17);
            this.sawtoothRadioButton.TabIndex = 12;
            this.sawtoothRadioButton.TabStop = true;
            this.sawtoothRadioButton.Text = "Sawtooth";
            this.sawtoothRadioButton.UseVisualStyleBackColor = true;
            this.sawtoothRadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // triangleRadioButton
            // 
            this.triangleRadioButton.AutoSize = true;
            this.triangleRadioButton.Location = new System.Drawing.Point(208, 96);
            this.triangleRadioButton.Name = "triangleRadioButton";
            this.triangleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.triangleRadioButton.TabIndex = 13;
            this.triangleRadioButton.TabStop = true;
            this.triangleRadioButton.Text = "Triangle";
            this.triangleRadioButton.UseVisualStyleBackColor = true;
            this.triangleRadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // AudioSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 157);
            this.Controls.Add(this.triangleRadioButton);
            this.Controls.Add(this.sawtoothRadioButton);
            this.Controls.Add(this.squareRadioButton);
            this.Controls.Add(this.sineRadioButton);
            this.Controls.Add(this.waveTypeLabel);
            this.Controls.Add(this.frequencyField);
            this.Controls.Add(this.hertzLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volumeBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AudioSettings";
            this.Text = "Audio";
            this.Load += new System.EventHandler(this.AudioSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label hertzLabel;
        private System.Windows.Forms.NumericUpDown frequencyField;
        private System.Windows.Forms.Label waveTypeLabel;
        private System.Windows.Forms.RadioButton sineRadioButton;
        private System.Windows.Forms.RadioButton squareRadioButton;
        private System.Windows.Forms.RadioButton sawtoothRadioButton;
        private System.Windows.Forms.RadioButton triangleRadioButton;
    }
}