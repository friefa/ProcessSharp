using ProcessSharp.Management;
using System;
using System.Linq;

namespace ProcessSharp
{
    public class Process
    {
        public System.Diagnostics.Process Instance { get; set; }

        public IntPtr Handle
        {
            get { return this.Instance.Handle; }
        }

        public static Process Open(string name)
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessesByName(name).FirstOrDefault();

            return Open(process);
        }

        public static Process Open(int id)
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(id);

            return Open(process);
        }

        public static Process Open(System.Diagnostics.Process process)
        {
            Process _process = new Process();
            _process.Instance = process;

            return _process;
        }
    }
}
