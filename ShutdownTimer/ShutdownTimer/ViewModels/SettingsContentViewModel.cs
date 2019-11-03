using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using ShutdownTimer.Properties;
using ShutdownTimer.SupportingClasses;

namespace ShutdownTimer.ViewModels
{
    public class SettingsContentViewModel : BindableBase
    {
        public bool DoShowTimer
        {
            get => SettingsProvider.Instance.DoShowTimer;
            set
            {
                SettingsProvider.Instance.DoShowTimer = value;
                RaisePropertyChanged();
            }
        }

        private DelegateCommand _saveSettingsDelegateCommand;
        public ICommand SaveSettingsCommand => _saveSettingsDelegateCommand ?? new DelegateCommand(_saveSettings);

        private void _saveSettings()
        {
            Settings.Default.Save();
            RaisePropertyChanged(nameof(DoShowTimer));
        }
    }
}
