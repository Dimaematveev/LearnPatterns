using System;
using System.Windows.Input;

namespace MVVM
{
    /// <summary>
    /// Мои команды.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Действие.
        /// </summary>
        private Action<object> execute;
        /// <summary>
        /// Функция возвращающая Bool
        /// </summary>
        private Func<object, bool> canExecute;

        /// <summary>
        /// Вызывается при изменении условий, указывающий, может ли команда выполняться.
        /// Для этого используется событие CommandManager.RequerySuggested.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Конструктор команды.
        /// </summary>
        /// <param name="execute"> Действие.</param>
        /// <param name="canExecute"> Функция возвращающая bool.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Определяет, может ли команда выполняться
        /// </summary>
        /// <param name="parameter">Данные, используемые данной командой. Если команда не требует передачи данных, этому объект может быть присвоено значение null.</param>
        /// <returns>Значение true, если эту команду можно выполнить; в противном случае — значение false.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        /// <summary>
        /// Выполняет логику команды
        /// </summary>
        /// <param name="parameter">Данные, используемые данной командой. Если команда не требует передачи данных, этому объект может быть присвоено значение null.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}