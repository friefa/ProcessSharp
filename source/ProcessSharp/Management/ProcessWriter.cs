using System;
using System.Text;

namespace ProcessSharp.Management
{
    public class ProcessWriter
    {
        public Process Process { get; private set; }

        public IntPtr WritingHandle { get; private set; }

        public ProcessWriter(Process process)
        {
            this.Process = process;
            this.WritingHandle = ProcessKernel.OpenProcess(this.Process.Instance.Id, ProcessAccess.VirtualMemoryWrite);
        }

        private T Transform<T>(object value)
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            instance = (T)value;

            return instance;
        }

        public bool Write<T>(IntPtr address, T value) where T : struct
        {
            bool result = false;

            if (typeof(T) == typeof(int))
            {
                int _value = this.Transform<int>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(long))
            {
                long _value = this.Transform<long>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(byte))
            {
                byte _value = this.Transform<byte>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(float))
            {
                float _value = this.Transform<float>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(double))
            {
                double _value = this.Transform<double>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(short))
            {
                short _value = this.Transform<short>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(ushort))
            {
                ushort _value = this.Transform<ushort>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(ulong))
            {
                ulong _value = this.Transform<ulong>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(uint))
            {
                uint _value = this.Transform<uint>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(sbyte))
            {
                sbyte _value = this.Transform<sbyte>(value);
                result = this.Write(address, _value);
            }
            else if (typeof(T) == typeof(char))
            {
                char _value = this.Transform<char>(value);
                result = this.Write(address, _value);
            }

            return result;
        }

        public bool Write(IntPtr address, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, long value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, byte value)
        {
            byte[] bytes = new byte[] { value };

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, sbyte value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, char value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }

        public bool Write(IntPtr address, byte[] value)
        {
            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, value);
        }

        public bool Write(IntPtr address, string value, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(value);

            return ProcessKernel.WriteProcessMemory(this.WritingHandle, address, bytes);
        }
    }
}
