using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownTimer
{
    public class ExecuteCommand
    {
        private string _fileName;

        public ExecuteCommand()
        {
            _fileName = "cmd.exe";
        }

        public ExecuteCommand(string fileName) : base()
        {
            _fileName = fileName;
        }

        public void Execute(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = _fileName;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            process.Dispose();
        }
    }
}
