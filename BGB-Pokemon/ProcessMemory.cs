using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BGB_Pokemon
{
    public class ProcessMemory
    {
        public enum ProcessAccessType : int
        {
            PROCESS_TERMINATE = (0x0001),
            PROCESS_CREATE_THREAD = (0x0002),
            PROCESS_SET_SESSIONID = (0x0004),
            PROCESS_VM_OPERATION = (0x0008),
            PROCESS_VM_READ = (0x0010),
            PROCESS_VM_WRITE = (0x0020),
            PROCESS_DUP_HANDLE = (0x0040),
            PROCESS_CREATE_PROCESS = (0x0080),
            PROCESS_SET_QUOTA = (0x0100),
            PROCESS_SET_INFORMATION = (0x0200),
            PROCESS_QUERY_INFORMATION = (0x0400),
            PROCESS_DELETE = (0x00010000),
            PROCESS_READ_CONTROL = (0x00020000),
            PROCESS_WRITE_DAC = (0x00040000),
            PROCESS_WRITE_OWNER = (0x00080000),
            PROCESS_SYNCHRONIZE = (0x00100000),

            PROCESS_ALL = (0x001F0FFF)
        }

        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(ProcessAccessType dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          uint lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, int lpNumberOfBytesWritten);

        private string processName;
        private int processHandle;
        public Process Process
        {
            get;
            private set;
        }

        public uint BaseAddress
        {
            get
            {
                return (uint)Process.MainModule.BaseAddress;
            }
        }

        public ProcessMemory(string name)
        {
            processName = name;
        }

        public bool Open()
        {
            Process[] processList = Process.GetProcessesByName(processName);
            if (processList.Length == 0)
                return false;
            Process = processList[0];
            processHandle = OpenProcess(ProcessAccessType.PROCESS_VM_READ, false, Process.Id);
            return true;
        }

        public void Close()
        {
            CloseHandle(processHandle);
        }

        private byte[] ReadMem(uint pOffset, int pSize, bool littleEndian = false)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[pSize];
            ReadProcessMemory(processHandle, pOffset, buffer, pSize, ref bytesRead);
            if (!littleEndian)
            {
                Array.Reverse(buffer);
            }
            return buffer;
        }

        public float ReadFloat(uint offset, bool littleEndian = false)
        {
            return BitConverter.ToSingle(ReadMem(offset, 4, littleEndian), 0);
        }

        public uint ReadInt(uint offset, bool littleEndian = false)
        {
            return BitConverter.ToUInt32(ReadMem(offset, 4, littleEndian), 0);
        }

        public ushort ReadShort(uint offset, bool littleEndian = false)
        {
            return BitConverter.ToUInt16(ReadMem(offset, 2, littleEndian), 0);
        }

        public byte ReadByte(uint offset)
        {
            return ReadMem(offset, 1)[0];
        }
    }
}