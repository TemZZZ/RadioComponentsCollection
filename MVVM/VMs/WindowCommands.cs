using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace MVVM.VMs
{
    public static class WindowCommands
    {
        /// <summary>
        /// Закрывает окно.
        /// </summary>
        public static RelayCommand<object> Close
            => new RelayCommand<object>(obj => (obj as Window)?.Close());
    }
}
