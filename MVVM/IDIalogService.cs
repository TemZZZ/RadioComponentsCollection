namespace MVVM
{
    /// <summary>
    /// Интерфейс, определяющий функциональность для работы с диалоговыми
    /// окнами.
    /// </summary>
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
        /// <returns>Если пользователь кликнул по кнопке OK в диалоговом
        /// окне, то возвращается true, иначе - false. </returns>
        bool OpenFileDialog();

        /// <summary>
        /// Пытается открыть диалоговое окно сохранения файла. В случае удачи
        /// возвращает true, иначе - false.
        /// </summary>
        /// <returns>Если пользователь кликнул по кнопке OK в диалоговом
        /// окне, то возвращается true, иначе - false. </returns>
        bool SaveFileDialog();
    }
}
