using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace ShutdownTimer
{
    public class MainWindowViewModel : BindableBase
    {
        #region private variables

        private int _second;
        private int _minute;
        private int _hour;

        #endregion

        #region public variables

        public int Second
        {
            get => _second;
            set => _second = value;
        }

        public int Minute
        {
            get => _minute;
            set => _minute = value;
        }

        public int Hour
        {
            get => _hour;
            set => _hour = value;
        }
        #endregion

        #region Commands

        private DelegateCommand _shutdownDelegateCommand;
        public ICommand ShutdownCommand => _shutdownDelegateCommand ?? new DelegateCommand(OnShutdownCommand);

        private DelegateCommand _abortDelegateCommand;
        public ICommand AbortCommand => _abortDelegateCommand ?? new DelegateCommand(OnAbortCommand);

        #endregion

        #region OnCommand

        public void OnShutdownCommand()
        {
            int value = _second + _minute * 60 + _hour * 60 * 60;
            string command = "shutdown -s -t " + Convert.ToString((value > 0) ? value : 1);

            ExecuteCommand executeCommand = new ExecuteCommand();
            executeCommand.Execute(command);
        }

        public void OnAbortCommand()
        {
            string command = "shutdown -a";

            ExecuteCommand executeCommand = new ExecuteCommand();
            executeCommand.Execute(command);
        }

        #endregion

    }
}
