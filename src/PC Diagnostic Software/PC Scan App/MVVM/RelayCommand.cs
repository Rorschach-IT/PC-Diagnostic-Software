// Ignore Spelling: App MVVM

using System.Windows.Input;

namespace PC_Scan_App.MVVM
{
    // Template for Relay Commands (MVVM buttons)
    public class RelayCommand(Action<object> execute, Func<object, bool> canExecute) : ICommand
    {
        private readonly Action<object> _execute = execute;
        private readonly Func<object, bool> _canExecute = canExecute ?? (x => true);

        public RelayCommand(Action<object> execute) : this(execute, x => true) { }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter!);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter!);
        }
    }
}