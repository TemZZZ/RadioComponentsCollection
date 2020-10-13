using System;
using System.Collections.Generic;
using System.IO;

namespace Model.Services
{
    /// <summary>
    /// Вспомогательный класс для работы с текстовыми файлами.
    /// </summary>
    public static class TextFileIOService
    {
        #region -- Private fields --

        /// <summary>
        /// Возможные в процессе работы с файлами типы исключений и
        /// соответствующие им сообщения об ошибках.
        /// </summary>
        private static readonly Dictionary<Type, string>
            _fileIoExceptionTypeToErrorMessageDictionary
                = new Dictionary<Type, string>
                {
                    [typeof(ArgumentNullException)]
                        = "Имя файла не может быть пустым.",
                    [typeof(DirectoryNotFoundException)]
                        = "Не удается найти часть файла или каталога.",
                    [typeof(PathTooLongException)]
                        = "Слишком длинный путь к файлу или его имя.",
                    [typeof(UnauthorizedAccessException)]
                        = "Доступ к файлу запрещен. Возможно, у Вас не " +
                          "достаточно прав для доступа к файлу.",
                    [typeof(FileNotFoundException)] = "Файл не найден.",
                    [typeof(IOException)]
                        = "Доступ к файлу запрещен. Возможно, он " +
                          "используется другим процессом."
                };

        #endregion

        #region -- Public methods --

        /// <summary>
        /// Создает или перезаписывает текстовый файл по указанному пути.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        /// <param name="errorMessager">Делегат для передачи сообщений об
        /// ошибках.</param>
        /// <returns>Объект <see cref="StreamWriter"/> или null.</returns>
        public static StreamWriter GetStreamWriter(string fileName,
            Action<string> errorMessager = null)
        {
            return ExceptionHandler.CallFunction(File.CreateText, fileName,
                _fileIoExceptionTypeToErrorMessageDictionary, errorMessager);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="StreamReader"/>
        /// для указанного имени файла.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        /// <param name="errorMessager">Делегат для передачи сообщений об
        /// ошибках.</param>
        /// <returns>Объект <see cref="StreamReader"/> или null.</returns>
        public static StreamReader GetStreamReader(string fileName,
            Action<string> errorMessager = null)
        {
            Func<string, StreamReader> CreateStreamReader =
                _fileName => new StreamReader(_fileName);
            return ExceptionHandler.CallFunction(CreateStreamReader,
                fileName, _fileIoExceptionTypeToErrorMessageDictionary,
                errorMessager);
        }

        #endregion
    }
}
