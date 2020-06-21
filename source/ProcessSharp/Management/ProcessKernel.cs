using System;
using System.Runtime.InteropServices;

namespace ProcessSharp.Management
{
    internal class ProcessKernel
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        internal static IntPtr OpenProcess(int processId, ProcessAccess access)
        {
            return OpenProcess((int)access, false, processId);
        }

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, long lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        internal static byte[] ReadProcessMemory(IntPtr handle, IntPtr address, int bytes)
        {
            byte[] buffer = new byte[bytes];

            int bytesRead = 0;

            ReadProcessMemory(handle.ToInt32(), address.ToInt64(), buffer, buffer.Length, ref bytesRead);

            return buffer;
        }
    }
}
