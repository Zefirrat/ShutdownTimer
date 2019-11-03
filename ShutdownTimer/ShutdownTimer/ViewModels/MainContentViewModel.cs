﻿using System;
using System.Timers;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using ShutdownTimer.SupportingClasses;

namespace ShutdownTimer.ViewModels
{
    public class MainContentViewModel : BindableBase
    {
        #region private variables

        private int _second;
        private int _minute;
        private int _hour;
        private int _convertedAllToSeconds => _second + _minute * 60 + _hour * 60 * 60;

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

        #region timer

        public bool DoShowTimer
        {
            get => SettingsProvider.Instance.DoShowTimer;
        }

        private CountDownTimer _countDownTimer;

        public string TimerText => $"Time before shutdown: {_timerToText}";
        private string _timerToText;

        private void _startTimer()
        {
            _countDownTimer = new CountDownTimer();
            _countDownTimer.SetTime(_hour, _minute, _second);
            _countDownTimer.TimeChanged += _timerChanged;
            _countDownTimer.StepMs = 33;
            _countDownTimer.Start();
        }

        private void _timerChanged()
        {
            _timerToText = _countDownTimer.TimeLeftMsStr;
            RaisePropertyChanged(nameof(TimerText));
        }

        private void _stopTimer()
        {
            _countDownTimer.Stop();
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
            int value = _convertedAllToSeconds;
            string command = "shutdown -s -t " + Convert.ToString((value > 0) ? value : 1);

            ExecuteCommand executeCommand = new ExecuteCommand();
            executeCommand.Execute(command);
            _startTimer();
        }

        public void OnAbortCommand()
        {
            string command = "shutdown -a";

            ExecuteCommand executeCommand = new ExecuteCommand();
            executeCommand.Execute(command);
            _stopTimer();
        }

        #endregion


        public MainContentViewModel()
        {
            SettingsProvider.Instance.DoShowTimerChanged += _doShowTimerChanged;
        }

        private void _doShowTimerChanged()
        {
            RaisePropertyChanged(nameof(DoShowTimer));
        }
    }
}
