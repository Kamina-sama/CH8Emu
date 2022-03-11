using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Threading;

namespace CH8Emu
{
    public partial class AudioSettings : Form
    {
        MainGameWindow owner;
        SignalGenerator wave;
        WaveOut wo = new WaveOut();
        public AudioSettings()
        {
            InitializeComponent();
        }
        public AudioSettings(MainGameWindow owner)
        {
            InitializeComponent();
            this.owner = owner;
            wave = (SignalGenerator)new SignalGenerator()
            {
                Gain = (double)owner.wave.Gain,
                Frequency = (double)owner.wave.Frequency,
                Type = owner.wave.Type
            };
            wo.Init(wave);
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            wo.Play();
            Thread.Sleep(500);
            wo.Stop();
        }

        private void AudioSettings_Load(object sender, EventArgs e)
        {
            volumeBar.Value = (int)(wave.Gain * 100);
            frequencyField.Value = (decimal)wave.Frequency;
            var x = wave.Type.ToString(); //debug purpose
            switch(wave.Type.ToString())
            {
                case "Square":
                    squareRadioButton.Checked = true;
                    break;
                case "SawTooth":
                    sawtoothRadioButton.Checked = true;
                    break;
                case "Triangle":
                    triangleRadioButton.Checked = true;
                    break;
                case "Sin":
                default:
                    sineRadioButton.Checked = true;
                    break;
            }
        }
        private void FrequencyField_ValueChanged(object sender, EventArgs e)
        {
            wave.Frequency = (double)frequencyField.Value;
        }

        private void VolumeBar_ValueChanged(object sender, EventArgs e)
        {
            wave.Gain = (double)volumeBar.Value / 100;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            owner.wave.Frequency = wave.Frequency;
            owner.wave.Gain = wave.Gain;
            owner.wave.Type = wave.Type;
            owner.SaveSettings();
            Close();
        }

        private void sineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            RadioButton whoDidThis = sender as RadioButton;
            whoDidThis.Checked = true;
            switch (whoDidThis.Text)
            {
                case "Square":
                    wave.Type = SignalGeneratorType.Square;
                    break;
                case "Sawtooth":
                    wave.Type = SignalGeneratorType.SawTooth;
                    break;
                case "Triangle":
                    wave.Type = SignalGeneratorType.Triangle;
                    break;
                case "Sine":
                default:
                    wave.Type = SignalGeneratorType.Sin;
                    break;
            }
        }
    }
}
