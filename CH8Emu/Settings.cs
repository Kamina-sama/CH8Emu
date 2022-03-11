using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH8Emu
{
    struct Settings
    {
        public Settings(System.Drawing.Color On, System.Drawing.Color Off, double waveFreq, double waveGain, int waveType, bool shb, bool lsb, bool jmpb)
        {
            ON = On.ToArgb();
            OFF = Off.ToArgb();
            toneFrequency = waveFreq;
            this.gain = waveGain;
            this.waveType = waveType;
            newShiftBehaviour = shb;
            newLoadStoreBehaviour = lsb;
            newJumpBehaviour = jmpb;
        }
        public int ON { get; set; } //video settings
        public int OFF {get; set;} //video settings

        public double toneFrequency { get; set; } //audio settings
        public double gain { get; set; } //audio settings
        public int waveType { get; set; } //audio settings


        public bool newShiftBehaviour { get; set; }
        public bool newLoadStoreBehaviour { get; set; }
        public bool newJumpBehaviour { get; set; }
    }
}
