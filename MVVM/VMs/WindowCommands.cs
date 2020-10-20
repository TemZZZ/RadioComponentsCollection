using System.Windows;

namespace MVVM.VMs
{
    public static class WindowCommands
    {
        /// <summary>
        /// Закрывает окно.
        /// </summary>
        public static CustomRelayCommand Close
            => new CustomRelayCommand(obj => (obj as Window)?.Close());
    }
}
