using System.Windows;

namespace MVVM
{
    public static class WindowCommands
    {
        /// <summary>
        /// Закрывает окно.
        /// </summary>
        public static RelayCommand Close
            => new RelayCommand(obj => (obj as Window)?.Close());
    }
}
