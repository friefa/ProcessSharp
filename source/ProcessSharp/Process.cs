using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSharp
{
    public class Process
    {
        public System.Diagnostics.Process Handle { get; set; }

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
            _process.Handle = process;

            return _process;
        }
    }
}
