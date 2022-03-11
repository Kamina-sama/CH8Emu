using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace Chip8Emu
{
    class Keyboard
    {
        public Keyboard()
        {
            buttonMapping[1] = Keys.D1;
            buttonMapping[2] = Keys.D2;
            buttonMapping[3] = Keys.D3;
            buttonMapping[12] = Keys.D4;
            buttonMapping[4] = Keys.Q;
            buttonMapping[5] = Keys.W;
            buttonMapping[6] = Keys.E;
            buttonMapping[13] = Keys.R;
            buttonMapping[7] = Keys.A;
            buttonMapping[8] = Keys.S;
            buttonMapping[9] = Keys.D;
            buttonMapping[14] = Keys.F;
            buttonMapping[10] = Keys.Z;
            buttonMapping[0] = Keys.X;
            buttonMapping[11] = Keys.C;
            buttonMapping[15] = Keys.V;
        }
        private bool[] pressedKeysBuffer = new bool[16];
        public bool this[byte i]
        {
            get => pressedKeysBuffer[i];
            private set => pressedKeysBuffer[i] = value;
        }
        private Keys[] buttonMapping = new Keys[16];
        public void HandleInputKeyDown(Keys k)
        {
            for (int i = 0; i < 16; ++i)
            {
                if (buttonMapping[i] == k) pressedKeysBuffer[i] = true;
            }
        }
        public (bool, byte) ReceiveWaitedInput(Keys k)
        {
            for (byte i = 0; i < 16; ++i)
            {
                if (buttonMapping[i] == k)
                {
                    pressedKeysBuffer[i] = true;
                    return (true, i);
                }
            }
            return (false,0);
        }
        public void HandleInputKeyUp(Keys k)
        {
            for (int i = 0; i < 16; ++i)
            {
                if (buttonMapping[i] == k) pressedKeysBuffer[i] = false;
            }
        }
    }
}
