using Prism.Commands;
using Prism.Mvvm;
using ShutdownTimer.Properties;

namespace ShutdownTimer.SupportingClasses
{
    public class SettingsProvider : BindableBase
    {
        private static SettingsProvider _instance;

        public static SettingsProvider Instance
        {
            get
            {
                _instance = _instance ?? new SettingsProvider();
                return _instance;
            }
        }

        public SettingsProvider()
        {
            DoShowTimerChanged += _doShowTimerChanged;
        }

        public bool DoShowTimer
        {
            get => (bool)Settings.Default[(nameof(DoShowTimer))];
            set
            {
                Settings.Default[nameof(DoShowTimer)] = value;
                DoShowTimerChanged();
            }
        }

        public delegate void OnDoShowTimerChanged();

        public OnDoShowTimerChanged DoShowTimerChanged;

        private void _doShowTimerChanged()
        {
            RaisePropertyChanged(nameof(DoShowTimer));
        }
    }
}
