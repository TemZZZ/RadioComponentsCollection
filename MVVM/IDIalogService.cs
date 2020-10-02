namespace MVVM
{
    /// <summary>
    /// Интерфейс, определяющий функциональность для работы с диалоговыми
    /// окнами.
    /// </summary>
    public interface IDialogService
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
        /// <param name="defaultExtension">Стандартное расширение.</param>
        /// <param name="filter">Расширения файлов, используемые в качестве
        /// фильтров отображаемых файлов в диалоговом окне.</param>
        /// <returns>Если пользователь кликнул по кнопке OK в диалоговом
        /// окне, то возвращается true, иначе - false. </returns>
        bool OpenFileDialog(string defaultExtension, string filter);

        /// <summary>
        /// Пытается открыть диалоговое окно сохранения файла. В случае удачи
        /// возвращает true, иначе - false.
        /// </summary>
        /// <param name="defaultExtension">Стандартное расширение.</param>
        /// <param name="filter">Расширения файлов, используемые в качестве
        /// фильтров отображаемых файлов в диалоговом окне.</param>
        /// <returns>Если пользователь кликнул по кнопке OK в диалоговом
        /// окне, то возвращается true, иначе - false. </returns>
        bool SaveFileDialog(string defaultExtension, string filter);
    }
}
