using System;
using System.Windows.Input;

namespace MVVM
{
    /// <summary>
    /// Класс команд, используемых в паттерне MVVM.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Делегат метода, содержащего логику команды.
        /// </summary>
        private Action<object> _execute;
        /// <summary>
        /// Делегат метода, результат выполнения которого определяет, может
        /// ли быть выполнена команда или нет.
        /// </summary>
        private Func<object, bool> _canExecute;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Создает команду <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">Делегат метода, содержащего логику команды.
        /// </param>
        /// <param name="canExecute">Делегат метода, результат выполнения
        /// которого определяет, может ли быть выполнена команда или нет.
        /// </param>
        public RelayCommand(Action<object> execute,
            Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Определяет, может ли команда выполняться.
        /// </summary>
        /// <param name="parameter">Данные для метода, определяющего
        /// возможность выполнения команды.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return (_canExecute == null) || _canExecute(parameter);
        }

        /// <summary>
        /// Выполняет логику команды.
        /// </summary>
        /// <param name="parameter">Данные, используемые командой.</param>
        /// <returns></returns>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
