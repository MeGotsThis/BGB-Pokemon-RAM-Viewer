using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace BGB_Pokemon
{
    class BGBPokemon
    {
        private uint memoryOffset;
        public ProcessMemory Memory
        {
            get;
            private set;
        }

        public BGBPokemon(string process = "bgb")
        {
            Memory = new ProcessMemory(process);
            if(!Memory.Open())
            {
                throw new Exception("No process found");
            }

            memoryOffset = Memory.ReadInt(Memory.BaseAddress + 0x000FE324, BitConverter.IsLittleEndian) + 0x3FF4;
        }

        ~BGBPokemon()
        {
            Memory.Close();
        }

        public bool InBattle
        {
            get
            {
                var b = Memory.ReadByte(0xD057 + memoryOffset);
                return b == 1 || b == 2;
            }
        }

        public byte BattlePokemonId
        {
            get
            {
                return Memory.ReadByte(0xCFD8 + memoryOffset);
            }
        }

        public int BattleLevel
        {
            get
            {
                return Memory.ReadByte(0xCFF3 + memoryOffset);
            }
        }

        public ushort BattleDVs
        {
            get
            {
                return (ushort)((Memory.ReadByte(0xCFF1 + memoryOffset) << 8) | Memory.ReadByte(0xCFF2 + memoryOffset));
            }
        }

        public int MapId
        {
            get
            {
                return Memory.ReadByte(0xD35E + memoryOffset);
            }
        }

        public Position MapPosition
        {
            get
            {
                return new Position(Memory.ReadByte(0xD362 + memoryOffset), Memory.ReadByte(0xD361 + memoryOffset));
            }
        }

        public byte EncounterRate
        {
            get
            {
                return Memory.ReadByte(0xD887 + memoryOffset);
            }
        }

        public ushort Hour
        {
            get
            {
                return Memory.ReadShort(0xDA40 + memoryOffset);
            }
        }

        public ushort Minute
        {
            get
            {
                return Memory.ReadShort(0xDA42 + memoryOffset);
            }
        }

        public byte Seconds
        {
            get
            {
                return Memory.ReadByte(0xDA44 + memoryOffset);
            }
        }

        public byte Frames
        {
            get
            {
                return Memory.ReadByte(0xDA45 + memoryOffset);
            }
        }

        public byte HRandomAdd
        {
            get
            {
                return Memory.ReadByte(0x7FD3 + memoryOffset);
            }
        }

        public byte HRandomSub
        {
            get
            {
                return Memory.ReadByte(0x7FD4 + memoryOffset);
            }
        }

        public uint FindByte(byte b)
        {
            for (uint o = 0; o < 0x10000; o += 1)
            {
                if (Memory.ReadByte(Memory.BaseAddress + o) == b)
                {
                    Console.WriteLine("Found: " + o.ToString("X"));
                    return o;
                }
            }
            return 0;
        }

        public uint FindInt(uint i)
        {
            for (uint o = 0; o < 0x10000; o += 1)
            {
                if(Memory.ReadInt(Memory.BaseAddress + o) == i)
                {
                    Console.WriteLine("Found: " + o.ToString("X"));
                    return o;
                }
            }
            return 0;
        }
    }

    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
