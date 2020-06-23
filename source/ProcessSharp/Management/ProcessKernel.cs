using System;
using System.Runtime.InteropServices;

namespace ProcessSharp.Management
{
    internal class ProcessKernel
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        public static IntPtr OpenProcess(int processId, ProcessAccess access)
        {
            return OpenProcess((int)access, false, processId);
        }

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static byte[] ReadProcessMemory(IntPtr handle, IntPtr address, int bytes)
        {
            byte[] buffer = new byte[bytes];

            int bytesRead = 0;

            ReadProcessMemory(handle, address, buffer, buffer.Length, ref bytesRead);

            return buffer;
        }

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

        public static bool WriteProcessMemory(IntPtr handle, IntPtr address, byte[] bytes)
        {
            return WriteProcessMemory(handle, address, bytes, bytes.Length, out var bytesread);
        }
    }
}
