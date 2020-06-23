using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProcessSharp;
using ProcessSharp.Management;

namespace ProcessSharpExample
{
    public partial class Form1 : Form
    {
        ProcessCollection processCollection;
        Process opened = null;

        public Form1()
        {
            InitializeComponent();
            InitializeProcessSharp();

            this.Text = "ProcessSharpExample: no process opened!";
        }

        public void InitializeProcessSharp()
        {
            processCollection = ProcessCollection.OpenLocalProcesses();

            foreach (Process process in processCollection.Processes)
            {
                this.comboBox1.Items.Add(process.Instance.ProcessName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.opened = this.processCollection.GetByName(this.comboBox1.Text);
            this.Text = "ProcessSharpExample: " + this.opened.Instance.ProcessName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessReader reader = new ProcessReader(this.opened);

            IntPtr ptr = new IntPtr(0x0A1D7210);

            int by = reader.Read<int>(ptr);

            MessageBox.Show("Read: " + by);
        }
    }
}
