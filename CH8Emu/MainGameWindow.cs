using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CH8Emu
{
    public partial class MainGameWindow : Form
    {
        Bitmap bmp;
        Graphics g;
        bool programLoaded = false;
        Chip8Emu.Emulator emulator = new Chip8Emu.Emulator();
        Color OFF=Color.Black, ON=Color.White;
        public SignalGenerator wave = new SignalGenerator()
        {
            Gain = 0.5,
            Frequency = 500,
            Type = SignalGeneratorType.Sin
        };
        WaveOut wo = new WaveOut();
        public MainGameWindow()
        {
            InitializeComponent();
            bmp = new Bitmap(640, 320);
            g = Graphics.FromImage(bmp);
            wo.Init(wave);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.FileName == "") return; 
            byte[] program = File.ReadAllBytes(openFileDialog1.FileName);
            emulator.Load(program);
            programLoaded = true;
            closeToolStripMenuItem1.Enabled = programLoaded;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
        private void Draw(bool[,] buffer) //64, 32, 10 for old, and 128, 64, 5 for new 
        {
            g.Clear(OFF);
            for(int i=0; i<128;++i)
            {
                for(int j=0; j<64;++j)
                {
                    if (buffer[i, j]) g.FillRectangle(new SolidBrush(ON), 5 * i, 5 * j, 5, 5);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void Timer60Hz_Tick(object sender, EventArgs e)
        {
            //if (!programLoaded) return;
            emulator.TimerAndInputTick();
            Draw(emulator.Display);
            if (emulator.soundTimer == 0) wo.Stop();
            else if (wo.PlaybackState != PlaybackState.Playing) wo.Play();
        }

        private void CPUTimer_Tick(object sender, EventArgs e)
        {
            //if (programLoaded) emulator.CPUTick();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos os arquivos (*.ch8)|*.ch8";
            openFileDialog1.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)=>emulator.HandleInputDown(e.KeyCode);

        private void Form1_KeyUp(object sender, KeyEventArgs e)=>emulator.HandleInputUp(e.KeyCode);

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos os arquivos (*.ch8)|*.ch8";
            openFileDialog1.ShowDialog();
        }

        private void setONPixelColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ON = colorDialog1.Color;
            SaveSettings();
        }

        private void setOFFPixelColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            OFF = colorDialog1.Color;
            SaveSettings();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var controlsSettingsForm = new ControlsSettings(this);
            controlsSettingsForm.Show();
        }

        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var audioSettingsForm = new AudioSettings(this);
            audioSettingsForm.Show();
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            programLoaded = false;
            emulator.ResetEmulator();
            closeToolStripMenuItem1.Enabled = programLoaded;
        }

        public void SaveSettings()
        {
            var settings = new Settings(
                ON, 
                OFF, 
                wave.Frequency, 
                wave.Gain, 
                (int)wave.Type, 
                emulator.newShiftBehaviour, 
                emulator.newStoreLoadBehaviour, 
                emulator.newJumpBehaviour
            );
            var testo = JsonSerializer.Serialize(settings);
            File.WriteAllText("CH8EmuSettings.json", JsonSerializer.Serialize(settings));
        }

        private void bheavioursToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void useNewShiftBehaviourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useNewShiftBehaviourToolStripMenuItem.Checked = !useNewShiftBehaviourToolStripMenuItem.Checked;
            emulator.newShiftBehaviour = useNewShiftBehaviourToolStripMenuItem.Checked;
            SaveSettings();
        }

        private void useNewLoadstoreBehaviourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useNewLoadstoreBehaviourToolStripMenuItem.Checked = !useNewLoadstoreBehaviourToolStripMenuItem.Checked;
            emulator.newStoreLoadBehaviour = useNewLoadstoreBehaviourToolStripMenuItem.Checked;
            SaveSettings();
        }

        private void MainGameWindow_DragEnter(object sender, DragEventArgs e)
        {
            //dynamic x=e.Data.GetData(DataFormats.FileDrop);
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                dynamic filePathStringArray=e.Data.GetData(DataFormats.FileDrop);
                if(filePathStringArray[0].EndsWith(".ch8")) e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainGameWindow_DragDrop(object sender, DragEventArgs e)
        {
            dynamic filePathStringArray = e.Data.GetData(DataFormats.FileDrop);
            if (!filePathStringArray[0].EndsWith(".ch8")) return;
            byte[] program = File.ReadAllBytes(filePathStringArray[0]);
            emulator.Load(program);
            programLoaded = true;
            closeToolStripMenuItem1.Enabled = programLoaded;
        }

        private void useNewJumpBehaviourCHIP48ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useNewJumpBehaviourCHIP48ToolStripMenuItem.Checked = !useNewJumpBehaviourCHIP48ToolStripMenuItem.Checked;
            emulator.newJumpBehaviour = useNewJumpBehaviourCHIP48ToolStripMenuItem.Checked;
            SaveSettings();
        }

        public void LoadSettings()
        {
            try
            {
                string text = File.ReadAllText("CH8EmuSettings.json");
                if (string.IsNullOrEmpty(text)) return;
                Settings settings = (Settings)JsonSerializer.Deserialize(text, typeof(Settings));

                ON = Color.FromArgb(settings.ON);
                OFF = Color.FromArgb(settings.OFF);

                wave.Frequency = settings.toneFrequency;
                wave.Gain = settings.gain;
                wave.Type = (SignalGeneratorType)settings.waveType;

                emulator.newShiftBehaviour = settings.newShiftBehaviour;
                emulator.newStoreLoadBehaviour = settings.newLoadStoreBehaviour;
                emulator.newJumpBehaviour = settings.newJumpBehaviour;
                useNewShiftBehaviourToolStripMenuItem.Checked = emulator.newShiftBehaviour;
                useNewLoadstoreBehaviourToolStripMenuItem.Checked = emulator.newStoreLoadBehaviour;
                useNewJumpBehaviourCHIP48ToolStripMenuItem.Checked = emulator.newJumpBehaviour;
            }
            catch(System.IO.FileNotFoundException _)
            {

            }
        }
    }
}
// x=0 -> pixels 0 to 9
// x=1 -> pixels 10 to 19 (multiply by 10 for the beggining, add 9 for the end)