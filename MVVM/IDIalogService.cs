namespace MVVM
{
    public interface IDIalogService
    {
        /// <summary>
        /// Показ сообщения в диалоговом окне.
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Пытается открыть диалоговое окно открытия файла. В случае удачи
        /// возвращает true, иначе - false.
        /// </summary>
        /// <returns>Удалось ли открыть диалоговое окно (true) или нет
        /// (false).
        /// </returns>
        bool OpenFileDialog();

        /// <summary>
        /// Пытается открыть диалоговое окно сохранения файла. В случае удачи
        /// возвращает true, иначе - false.
        /// </summary>
        /// <returns>Удалось ли открыть диалоговое окно (true) или нет
        /// (false).
        /// </returns>
        bool SaveFileDialog();
    }
}
