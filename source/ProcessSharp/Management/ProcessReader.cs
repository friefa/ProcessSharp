using System;
using System.Text;

namespace ProcessSharp.Management
{
    public class ProcessReader
    {
        public Process Process { get; private set; }

        public IntPtr ReadingHandle { get; private set; }

        public ProcessReader(Process process)
        {
            this.Process = process;
            this.ReadingHandle = ProcessKernel.OpenProcess(this.Process.Instance.Id, ProcessAccess.VirtualMemoryRead);
        }

        private T Transform<T>(object value)
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            instance = (T)value;

            return instance;
        }

        public T Read<T>(IntPtr address) where T : struct
        {
            object read = default;

            if (typeof(T) == typeof(int))
            {
                read = this.ReadInt(address);
            }
            else if (typeof(T) == typeof(long))
            {
                read = this.ReadLong(address);
            }
            else if (typeof(T) == typeof(byte))
            {
                read = this.ReadByte(address);
            }
            else if(typeof(T) == typeof(float))
            {
                read = this.ReadFloat(address);
            }
            else if (typeof(T) == typeof(double))
            {
                read = this.ReadDouble(address);
            }
            else if (typeof(T) == typeof(short))
            {
                read = this.ReadShort(address);
            }
            else if (typeof(T) == typeof(ushort))
            {
                read = this.ReadUShort(address);
            }
            else if (typeof(T) == typeof(ulong))
            {
                read = this.ReadULong(address);
            }
            else if (typeof(T) == typeof(uint))
            {
                read = this.ReadUInt(address);
            }
            else if (typeof(T) == typeof(sbyte))
            {
                read = this.ReadSByte(address);
            }
            else if (typeof(T) == typeof(char))
            {
                read = this.ReadChar(address);
            }

            return this.Transform<T>(read);
        }

        public int ReadInt(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 4);

            return BitConverter.ToInt32(bytes, 0);
        }

        public long ReadLong(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 8);

            return BitConverter.ToInt64(bytes, 0);
        }

        public byte ReadByte(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 1);

            return bytes[0];
        }

        public float ReadFloat(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 4);

            return BitConverter.ToSingle(bytes, 0);
        }

        public double ReadDouble(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 8);

            return BitConverter.ToDouble(bytes, 0);
        }

        public short ReadShort(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 2);

            return BitConverter.ToInt16(bytes, 0);
        }

        public ushort ReadUShort(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 2);

            return BitConverter.ToUInt16(bytes, 0);
        }

        public uint ReadUInt(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 4);

            return BitConverter.ToUInt32(bytes, 0);
        }

        public ulong ReadULong(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 8);

            return BitConverter.ToUInt64(bytes, 0);
        }

        public sbyte ReadSByte(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 1);

            return (sbyte)bytes[0];
        }

        public char ReadChar(IntPtr address)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, 1);

            return (char)bytes[0];
        }

        public byte[] ReadBytes(IntPtr address, int count)
        {
            return ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, count);
        }

        public string ReadString(IntPtr address, int count, Encoding encoding)
        {
            byte[] bytes = ProcessKernel.ReadProcessMemory(this.ReadingHandle, address, count);

            return encoding.GetString(bytes);
        }
    }
}