using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigitallyInspired.GUI.Command
{
    public class AsyncRelayCommand : ICommand
    {
        protected readonly Predicate<object> AsyncCanExecute;
        protected Func<object, Task> AsyncExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public AsyncRelayCommand(Func<object, Task> execute) : this(execute, null)
        {

        }

        public AsyncRelayCommand(Func<object, Task> asyncExecute, Predicate<object> canExecute)
        {
            AsyncExecute = asyncExecute;
            AsyncCanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return AsyncCanExecute == null || AsyncCanExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        protected virtual async Task ExecuteAsync(object parameter)
        {
            await AsyncExecute(parameter);
        }
    }
}