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
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
    }
}
