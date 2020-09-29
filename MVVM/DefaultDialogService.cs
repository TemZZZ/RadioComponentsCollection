using System.Windows;
using Microsoft.Win32;

namespace MVVM
{
    /// <summary>
    /// Сервис для работы со стандартными диалогами.
    /// </summary>
    public class DefaultDialogService : IDIalogService
    {
        /// <inheritdoc/>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <inheritdoc/>
        public string FilePath { get; set; }

        /// <inheritdoc/>
        public bool OpenFileDialog(string defaultExtension = "",
            string filter = "")
        {
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = defaultExtension,
                Filter = filter
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public bool SaveFileDialog(string defaultExtension = "",
            string filter = "")
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = defaultExtension,
                Filter = filter
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
    }
}
