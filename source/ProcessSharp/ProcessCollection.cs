using System;

namespace ProcessSharp
{
    public class ProcessCollection
    {
        public Process[] Processes { get; private set; }

        public DateTime CreationTimeUtc { get; private set; }

        public static ProcessCollection OpenLocalProcesses()
        {
            ProcessCollection collection = new ProcessCollection();

            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            Process[] _processes = new Process[processes.Length];

            for (int i = 0; i < processes.Length; i++)
            {
                _processes[i] = Process.Open(processes[i]);
            }

            collection.Processes = _processes;
            collection.CreationTimeUtc = DateTime.UtcNow;

            return collection;
        }
    }
}