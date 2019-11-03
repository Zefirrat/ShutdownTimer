using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using ShutdownTimer.Views;

namespace ShutdownTimer.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private MainContent _mainContent;
        private SettingsContent _settingsContent;

        private UserControl _currentMainContent;

        public UserControl CurrentMainContent
        {
            get => _currentMainContent ?? new UserControl();
            set
            {
                _currentMainContent = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            _mainContent = new MainContent();
            _settingsContent = new SettingsContent();
            CurrentMainContent = _mainContent;
        }

        private DelegateCommand _changeMainContentDelegateCommand;

        public ICommand ChangeMainContentCommand => _changeMainContentDelegateCommand ?? new DelegateCommand(_changeMainContent);

        private void _changeMainContent()
        {
            switch (CurrentMainContent)
            {
                case MainContent mainContent:
                    CurrentMainContent = _settingsContent;
                    break;
                default:
                    CurrentMainContent = _mainContent;
                    break;
            }
        }
    }
}
