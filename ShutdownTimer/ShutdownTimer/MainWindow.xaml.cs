// Shutdown_Timer.MainWindow
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

public class MainWindow : Window, IComponentConnector
{
    internal Button button1;

    internal Button button2;

    internal TextBox hours;

    internal TextBox minutes;

    internal TextBox seconds;

    internal TextBlock textBlock1;

    internal TextBlock textBlock2;

    internal TextBlock textBlock3;

    private bool _contentLoaded;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        int value = Convert.ToInt16(seconds.Text) + Convert.ToInt16(minutes.Text) * 60 + Convert.ToInt16(hours.Text) * 60 * 60;
        string value2 = "shutdown -s -t " + Convert.ToString(value);
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

    private void button2_Click(object sender, RoutedEventArgs e)
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

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
        if (!_contentLoaded)
        {
            _contentLoaded = true;
            Uri resourceLocator = new Uri("/Shutdown Timer;component/mainwindow.xaml", UriKind.Relative);
            Application.LoadComponent(this, resourceLocator);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    void IComponentConnector.Connect(int connectionId, object target)
    {
        switch (connectionId)
        {
            case 1:
                button1 = (Button)target;
                button1.Click += button1_Click;
                break;
            case 2:
                button2 = (Button)target;
                button2.Click += button2_Click;
                break;
            case 3:
                hours = (TextBox)target;
                break;
            case 4:
                minutes = (TextBox)target;
                break;
            case 5:
                seconds = (TextBox)target;
                break;
            case 6:
                textBlock1 = (TextBlock)target;
                break;
            case 7:
                textBlock2 = (TextBlock)target;
                break;
            case 8:
                textBlock3 = (TextBlock)target;
                break;
            default:
                _contentLoaded = true;
                break;
        }
    }
}

