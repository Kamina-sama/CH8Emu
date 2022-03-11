using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chip8Emu
{
    class Emulator
    {
        public Emulator()
        {
            AssignKeysMemory();
            Task.Run(Loop);
        }
        public bool newStoreLoadBehaviour { get; set; } = true;
        public bool newShiftBehaviour { get; set; } = true;
        public bool newJumpBehaviour { get; set; } = true;

        public bool highRes { get; private set; } = false;

        private Random RNG = new Random();
        private Keyboard keyboard = new Keyboard();

        private byte[] V = new byte[16];
        private System.UInt16 I = 0; //index register
        private System.UInt16[] stack = new System.UInt16[16];
        private sbyte stackPointer = -1;
        private byte delayTimer = 0;
        public byte soundTimer { get; private set; } = 0;
        private bool[,] frameBuffer = new bool[128, 64];

        private System.UInt16 programCounter = 0x200; //valid programs starts at this address
        //program counter must be increased by 2, because the opcodes are 2 bytes long
        private byte[] RAM = new byte[4096]; //4kb memory

        private byte registerToReceiveWaitedInput;
        private bool waitingForInput = false;
        private bool programLoaded = false;

        public void ResetEmulator()
        {
            programLoaded = false;
            programCounter = 0x200;
            V = new byte[16];
            I = 0; //index register
            stack = new System.UInt16[16];
            stackPointer = -1;
            delayTimer = 0;
            soundTimer = 0;
            frameBuffer = new bool[128, 64];


            Array.Clear(RAM, 0x200, 0xFFF - 0x200 + 1);
            waitingForInput = false;
            highRes = false;
        }
        private void AssignKeysMemory()
        {
            //Zero:
            RAM[0] = 0xF0;
            RAM[1] = 0x90;
            RAM[2] = 0x90;
            RAM[3] = 0x90;
            RAM[4] = 0xF0;
            //One:
            RAM[5] = 0x20;
            RAM[6] = 0x60;
            RAM[7] = 0x20;
            RAM[8] = 0x20;
            RAM[9] = 0x70;
            //Two:
            RAM[10] = 0xF0;
            RAM[11] = 0x10;
            RAM[12] = 0xF0;
            RAM[13] = 0x80;
            RAM[14] = 0xF0;
            //Three:
            RAM[15] = 0xF0;
            RAM[16] = 0x10;
            RAM[17] = 0xF0;
            RAM[18] = 0x10;
            RAM[19] = 0xF0;
            //Four:
            RAM[20] = 0x90;
            RAM[21] = 0x90;
            RAM[22] = 0xF0;
            RAM[23] = 0x10;
            RAM[24] = 0x10;
            //Five:
            RAM[25] = 0xF0;
            RAM[26] = 0x80;
            RAM[27] = 0xF0;
            RAM[28] = 0x10;
            RAM[29] = 0xF0;
            //Six:
            RAM[30] = 0xF0;
            RAM[31] = 0x80;
            RAM[32] = 0xF0;
            RAM[33] = 0x90;
            RAM[34] = 0xF0;
            //Seven:
            RAM[35] = 0xF0;
            RAM[36] = 0x10;
            RAM[37] = 0x20;
            RAM[38] = 0x40;
            RAM[39] = 0x40;
            //Eight:
            RAM[40] = 0xF0;
            RAM[41] = 0x90;
            RAM[42] = 0xF0;
            RAM[43] = 0x90;
            RAM[44] = 0xF0;
            //Nine:
            RAM[45] = 0xF0;
            RAM[46] = 0x90;
            RAM[47] = 0xF0;
            RAM[48] = 0x10;
            RAM[49] = 0xF0;
            //Ten (A):
            RAM[50] = 0xF0;
            RAM[51] = 0x90;
            RAM[52] = 0xF0;
            RAM[53] = 0x90;
            RAM[54] = 0x90;
            //Eleven (B):
            RAM[55] = 0xE0;
            RAM[56] = 0x90;
            RAM[57] = 0xE0;
            RAM[58] = 0x90;
            RAM[59] = 0xE0;
            //Twelve (C):
            RAM[60] = 0xF0;
            RAM[61] = 0x80;
            RAM[62] = 0x80;
            RAM[63] = 0x80;
            RAM[64] = 0xF0;
            //Thirteen (D):
            RAM[65] = 0xE0;
            RAM[66] = 0x90;
            RAM[67] = 0x90;
            RAM[68] = 0x90;
            RAM[69] = 0xE0;
            //Fourteen (E):
            RAM[70] = 0xF0;
            RAM[71] = 0x80;
            RAM[72] = 0xF0;
            RAM[73] = 0x80;
            RAM[74] = 0xF0;
            //Fifteen (F):
            RAM[75] = 0xF0;
            RAM[76] = 0x80;
            RAM[77] = 0xF0;
            RAM[78] = 0x80;
            RAM[79] = 0x80;
        }

        #region opcodes methods
        private void CLS()
        {
            Array.Clear(frameBuffer, 0, frameBuffer.Length);
        }//00E0 --PERFECT
        private void RET() => programCounter = stack[stackPointer--]; //00EE --PERFECT
        private void JP(System.UInt16 addr) => programCounter = (ushort)(addr - 2); //1nnn, nnn = 12 bits addr ------PERFECT
        private void CALL(System.UInt16 addr) //2nnn, nnn = 12 bits addr
        {
            ++stackPointer;
            stack[stackPointer] = programCounter;
            JP(addr);
        } //PERFECT
        private void SEVxByte(byte x, byte kk) //3xkk, kk= 1 byte value, x = 4 bits Vindex ---PERFECT
        {
            if (V[x] == kk) programCounter += 2;
        } //--------------PERFECT
        private void SNEVxByte(byte x, byte kk) //4xkk
        {
            if (V[x] != kk) programCounter += 2;
        } //----PERFECT
        private void SEVxVy(byte x, byte y) => SEVxByte(x, V[y]); //5xy0
        private void LDVxByte(byte x, byte kk) => V[x] = kk; //6xkk --------------------PERFECT
        private void ADDVxByte(byte x, byte kk) => V[x] += kk; //7xkk
        private void LDVxVy(byte x, byte y) => LDVxByte(x, V[y]); //8xy0
        private void OR(byte x, byte y) => V[x] |= V[y]; //8xy1
        private void AND(byte x, byte y) => V[x] &= V[y]; //8xy2
        private void XOR(byte x, byte y) => V[x] ^= V[y]; //8xy3
        private void ADDVxVy(byte x, byte y)  //8xy4
        {
            V[0xF] = (byte)((V[x] + V[y] > 255) ? 1 : 0);
            V[x] += V[y];
        }
        private void SUBVxVy(byte x, byte y) //8xy5
        {
            if (V[x] > V[y]) V[0xF] = 1; //some say > instead of >=, so try both
            else V[0xF] = 0;
            V[x] -= V[y];
        }
        private void SHRVx(byte x, byte y) //8xy6
        {
            if (!newShiftBehaviour) V[x] = V[y];
            V[0xF] = (byte)((V[x] % 2 == 1) ? 1 : 0);
            V[x] >>= 1;
        }
        private void SUBNVxVy(byte x, byte y) //8xy7
        {
            if (V[y] > V[x]) V[0xF] = 1;
            else V[0xF] = 0;
            V[x] = (byte)(V[y] - V[x]);
        }
        private void SHLVx(byte x, byte y) //8xyE
        {
            if (!newShiftBehaviour) V[x] = V[y];
            V[0xF] = (byte)(V[x] >> 7);
            V[x] <<= 1;
        }
        private void SNEVxVy(byte x, byte y) => SNEVxByte(x, V[y]); //9xy0
        private void LDIAddr(System.UInt16 nnn) => I = nnn; //Annn --------------------------------------------PERFECT
        private void JMPV0Addr(System.UInt16 nnn) =>JP((ushort)(V[0] + nnn)); //Bnnn
        private void Bxnn(byte x, byte nn) //CHIP48 jump version that replaces the other one above
        {
            var xnn=(x << 8) + nn;
            JP((ushort)(V[x] + xnn));
        }
        private void RNDVxByte(byte x, byte kk) //Cxkk, kk= 1 byte value, x = 4 bits Vindex
        {
            byte randomByte = (byte)RNG.Next(256);
            randomByte &= kk;
            V[x] = randomByte;
        }
        private void DRWVxVyNibble(byte x, byte y, byte nibble) //Dxyn ------PERFECT. x and y arguments are coming WRONG!! WHY???? THIS FUNCTION WORKS PERFECTLY
        {
            V[0xF] = 0;
            uint factor = (uint)(highRes ? 1 : 2);
            for (uint i = I, j = 0; nibble > 0; --nibble, ++i, ++j) //i controls memory pointer for the next byte to draw, j controls the vertical stuff (new bytes are drawn below old ones) and nibble tells us how many bytes are left
            {
                byte toDraw = RAM[i];
                for (uint k = 0; k < 8; ++k) //draw the byte on the same line/row, on x
                {
                    bool bit = Convert.ToBoolean((toDraw >> (int)(7 - k)) % 2);
                    uint xPos = (uint)factor*(V[x] + k) % 128, yPos = (uint)factor*(V[y] + j) % 64; //(x+k)%64
                    if (frameBuffer[xPos, yPos] && bit) V[0xF] = 1;
                    frameBuffer[xPos, yPos] ^= bit;
                    if(!highRes)
                    {
                        frameBuffer[(xPos+1)%128, yPos] ^= bit;
                        frameBuffer[xPos, (yPos+1)%64] ^= bit;
                        frameBuffer[(xPos+1)%128, (yPos+1)%64] ^= bit;
                    }
                }
            }
        }
        //IT DRAWS EXACTLY WHAT IT SHOULD, MEANING: 1-THIS FUNCTION WORKS FLAWLESSLY AND 2-THE MEMORY OF THE IMAGES THEMSELVES ARE NOT CORRUPTED, BUT IT CAN MEAN THAT: 1-THE MEMORY OF THE CODES FOR X AND Y ARE CORRUTED
        //2-IT CANNOT BE THAT THE PROGRAM COUNTER IS DEFASADO, BECAUSE THEN IT WOULD NOT INTERPRET AS DRAW OPERATIONS, AND IT DOES, AND NOT ONLY THAT, IT ALSO GETS EVERYTHING PERFECT EXCEPT THE X AND Y COORDINATES
        private void SKPVx(byte x) //Ex9E
        {
            if (keyboard[V[x]]) programCounter += 2;
        }
        private void SKPNVx(byte x) //ExA1
        {
            if (!keyboard[V[x]]) programCounter += 2;
        }
        private void LDVxDT(byte x) => V[x] = delayTimer; //Fx07
        //private void LDVxK(byte x) => V[x] = keyboard.WaitForKeyPress(); //Fx0A
        private void LDDTVx(byte x) => delayTimer = V[x]; //Fx15
        private void LDSTVx(byte x) => soundTimer = V[x]; //Fx18
        private void ADDIVx(byte x) => I += V[x]; //Fx1E
        private void LDFVx(byte x) => I = (ushort)(V[x] * 5); //Fx29
        private void LDBVx(byte x) //Fx33
        {
            RAM[I] = (byte)(V[x] / 100);
            RAM[I + 1] = (byte)((V[x] / 10) % 10); //194 divide by 10 -> 19 (,4 truncated) now modulo 10 = 9
            RAM[I + 2] = (byte)(V[x] % 10); //194 divided by 10 equals 19 resto 4...
        }
        private void LDIVx(byte x) //Fx55
        {
            //System.UInt16 backup = I;
            for (uint i = 0; i <= x; ++i, ++I) RAM[I] = V[i];
            if (newStoreLoadBehaviour) --I;
        }
        private void LDVxI(byte x) //Fx65
        {
            //System.UInt16 backup = I;
            for (uint i = 0; i <= x; ++i, ++I) V[i] = RAM[I];
            if (newStoreLoadBehaviour) --I;
        }
        #endregion
        #region SCHIP opcodes methods
        private void Dxy0(byte x, byte y) //TODO
        {
            if (!highRes) return;
            //TODO
            V[0xF] = 0;
            for (uint i = I, j = 0, nibble=32; nibble > 0; nibble-=2,i+=2, ++j) //i controls memory pointer for the next byte to draw, j controls the vertical stuff (new bytes are drawn below old ones) and nibble tells us how many bytes are left
            {
                System.UInt16 toDraw = (ushort)((RAM[i] << 8) + RAM[i + 1]);
                for (uint k = 0; k < 16; ++k) //draw the byte on the same line/row, on x
                {
                    bool bit = Convert.ToBoolean((toDraw >> (int)(15 - k)) % 2);
                    uint xPos = (uint)(V[x] + k) % 128, yPos = (uint)(V[y] + j) % 64; //(x+k)%64
                    if (frameBuffer[xPos, yPos] && bit) V[0xF] = 1;
                    frameBuffer[xPos, yPos] ^= bit;
                }
                /*for (uint k = 0; k < 8; ++k) //draw the byte on the same line/row, on x
                {
                    bool bit = Convert.ToBoolean((toDraw >> (int)(15 - k)) % 2);
                    uint xPos = (uint)(V[x] + k) % 128, yPos = (uint)(V[y] + j) % 64; //(x+k)%64
                    if (frameBuffer[xPos, yPos] && bit) V[0xF] = 1;
                    frameBuffer[xPos, yPos] ^= bit;
                }*/
            }
        }
        private void Fx75(byte x)
        {

        }
        private void Fx85(byte x)
        {

        }
        #endregion
        private void ExecuteOpCode()
        {
            byte[] opCode = new byte[2] { RAM[programCounter], RAM[programCounter + 1] };
            byte x = (byte)(opCode[0] & 0x0F);
            byte y = (byte)((opCode[1] & 0xF0) >> 4);
            System.UInt16 nnn = (ushort)(((opCode[0] & 0x0F) << 8) + opCode[1]);
            byte kk = opCode[1];
            switch (opCode[0] >> 4)
            {
                case 0:
                    switch(opCode[1])
                    {
                        case 0xEE:
                            RET();
                            break;
                        case 0xFD:
                            ResetEmulator();
                            break;
                        case 0xFE:
                            highRes = false;
                            break;
                        case 0xFF:
                            highRes = true;
                            break;
                        default:
                        case 0xE0:
                            CLS();
                            break;
                    }
                    break;
                case 1:
                    JP(nnn);
                    break;
                case 2:
                    CALL(nnn);
                    break;
                case 3:
                    SEVxByte(x, kk);
                    break;
                case 4:
                    SNEVxByte(x, kk);
                    break;
                case 5:
                    SEVxVy(x, y);
                    break;
                case 6:
                    LDVxByte(x, kk);
                    break;
                case 7:
                    ADDVxByte(x, kk);
                    break;
                case 8:
                    switch (opCode[1] & 0x0F)
                    {
                        case 0:
                            LDVxVy(x, y);
                            break;
                        case 1:
                            OR(x, y);
                            break;
                        case 2:
                            AND(x, y);
                            break;
                        case 3:
                            XOR(x, y);
                            break;
                        case 4:
                            ADDVxVy(x, y);
                            break;
                        case 5:
                            SUBVxVy(x, y);
                            break;
                        case 6:
                            SHRVx(x,y);
                            break;
                        case 7:
                            SUBNVxVy(x, y);
                            break;
                        case 0xE:
                            SHLVx(x,y);
                            break;
                    }
                    break;
                case 9:
                    SNEVxVy(x, y);
                    break;
                case 0xA:
                    LDIAddr(nnn);
                    break;
                case 0xB:
                    if (newJumpBehaviour) Bxnn(x, kk);
                    else JMPV0Addr(nnn);
                    break;
                case 0xC:
                    RNDVxByte(x, kk);
                    break;
                case 0xD:
                    if ((int)(opCode[1] & 0x0F) == 0) Dxy0(x, y);
                    else DRWVxVyNibble(x, y, (byte)(opCode[1] & 0x0F));
                    break;
                case 0xE:
                    if (opCode[1] == 0x9E) SKPVx(x);
                    else if (opCode[1] == 0xA1) SKPNVx(x);
                    break;
                case 0xF:
                    switch (opCode[1])
                    {
                        case 0x07:
                            LDVxDT(x);
                            break;
                        case 0x0A:
                            //LDVxK(x);
                            registerToReceiveWaitedInput = x;
                            waitingForInput = true;
                            break;
                        case 0x15:
                            LDDTVx(x);
                            break;
                        case 0x18:
                            LDSTVx(x);
                            break;
                        case 0x1E:
                            ADDIVx(x);
                            break;
                        case 0x29:
                            LDFVx(x);
                            break;
                        case 0x33:
                            LDBVx(x);
                            break;
                        case 0x55:
                            LDIVx(x);
                            break;
                        case 0x65:
                            LDVxI(x);
                            break;
                    }
                    break;
            }
        }

        public bool[,] Display => frameBuffer;
        public void Load(byte[] program) //THE PROBLEM: IT IS LOADING THE DRAWING OPS INCORRECLTY FROM THE FILE, FOR SOME GOD FORSAKEN REASON. BETTER TO ASSUME THE ENTIRE FILE LOADING PROCESS IS FLAWED
        {
            ResetEmulator();
            Array.Copy(program, 0, RAM, programCounter, program.Length);
            programLoaded = true;
        }
        public void CPUTick() //should be called with frequency 500 Hz
        {
            if (waitingForInput || !programLoaded) return;
            ExecuteOpCode();
            programCounter += 2;
        }
        private void Loop()
        {
            while(true)
            {
                int timeNow = System.Environment.TickCount;
                //two miliseconds in ticks=2ms=2s/1000=2*Tick*Frequency      X TICK * F/1000=Xms
                //stopWatch.Restart();
                for (int i = 0; i < 20; ++i) CPUTick(); //Frequency=250*reps/s for the Thread sleep number of 4, and 125*reps/s pro Thread.Sleep(8...)
                int timeNow2 = System.Environment.TickCount;
                Thread.Sleep(8-(timeNow2-timeNow));
                //Thread.Sleep(TimeSpan.FromMilliseconds(10 - (double)stopWatch.ElapsedTicks*Stopwatch.Frequency/1000));
                //Thread.Sleep(2-stopWatch.ElapsedTicks); //timeNow2 - timeNow = TimeElapsed. If time elapsed is smaller than 2ms, sleep for the rest of the duration
            }
        }
        public void TimerAndInputTick() //should be used with 60Hz frequency
        {
            if (soundTimer > 0) --soundTimer;
            if (delayTimer > 0) --delayTimer;
        }
        public void HandleInputDown(System.Windows.Forms.Keys k) 
        {
            if (waitingForInput) ReceiveWaitedInput(k);
            else keyboard.HandleInputKeyDown(k);
        }
        public void HandleInputUp(System.Windows.Forms.Keys k) => keyboard.HandleInputKeyUp(k);
        private void ReceiveWaitedInput(System.Windows.Forms.Keys k) 
        {
            (bool validInput, byte keyPressed)=keyboard.ReceiveWaitedInput(k);
            if(validInput)
            {
                V[registerToReceiveWaitedInput] = keyPressed;
                waitingForInput = false;
            }
        }
    }
}
