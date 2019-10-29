using System;
using System.Diagnostics;
using System.Windows;

namespace ShutdownTimer
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            SecondsTextBox.Text = "0";
            MinutesTextBox.Text = "0";
            HoursTextBox.Text = "0";
        }

        public void Button1_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt16(SecondsTextBox.Text) + Convert.ToInt16(MinutesTextBox.Text) * 60 + Convert.ToInt16(HoursTextBox.Text) * 60 * 60;
            string value2 = "shutdown -s -t " + Convert.ToString((value > 0) ? value : 1);
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine(value2);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
        }

        public void Button2_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("shutdown -a");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
        }

    }
}

