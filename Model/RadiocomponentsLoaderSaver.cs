using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс сохранения в файл/загрузки из файла радиокомпонентов.
    /// </summary>
    public class RadiocomponentsLoaderSaver
    {
        private readonly TextFilesReaderWriter _textFilesReaderWriter;

        /// <summary>
        /// Создает экземпляр класса загрузки радиокомпонентов из
        /// файла/сохранения радиокомпонентов в файл.
        /// </summary>
        /// <param name="textFilesReaderWriter">Экземпляр класса
        /// <see cref="TextFilesReaderWriter"/>.</param>
        public RadiocomponentsLoaderSaver(
            TextFilesReaderWriter textFilesReaderWriter)
        {
            _textFilesReaderWriter = textFilesReaderWriter;
        }

        /// <summary>
        /// Сохраняет радиокомпоненты в файл.
        /// </summary>
        /// <param name="saveOption">Опция сохранения в файл.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="allRadiocomponents">Все радиокомпоненты.</param>
        /// /// <param name="selectedRadiocomponents">Выделенные
        /// радиокомпоненты.</param>
        /// /// <param name="errorMessager">Делегат для вывода сообщений об
        /// ошибках.</param>
        /// <returns>true, если радиокомпоненты были сохранены, иначе -
        /// false.</returns>
        public bool SaveToFile(RadiocomponentsSaveOption saveOption,
            string filePath, IEnumerable<RadiocomponentBase> allRadiocomponents,
            IEnumerable<RadiocomponentBase> selectedRadiocomponents,
            Action<string> errorMessager = null)
        {
            IEnumerable<RadiocomponentBase> savingRadiocomponents;

            switch (saveOption)
            {
                case RadiocomponentsSaveOption.SaveAll:
                    savingRadiocomponents = allRadiocomponents;
                    break;
                case RadiocomponentsSaveOption.SaveSelected:
                    savingRadiocomponents = selectedRadiocomponents;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(saveOption),
                        saveOption, null);
            }

            _textFilesReaderWriter.SerializeAndWriteToFile(
                savingRadiocomponents, filePath, errorMessager);
            return true;
        }

        /// <summary>
        /// Загружает радиокомпоненты из файла.
        /// </summary>
        /// <param name="loadOption">Опция загрузки из файла.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="targetCollection">Коллекция для добавления/замещения
        /// радиокомпонентов.</param>
        /// <param name="errorMessager">Делегат для вывода сообщений об
        /// ошибках.</param>
        /// <returns>true, если радиокомпоненты были загружены, иначе -
        /// false.</returns>
        public bool LoadFromFile(RadiocomponentsLoadOption loadOption,
            string filePath, List<RadiocomponentBase> targetCollection,
            Action<string> errorMessager = null)
        {
            var newRadiocomponents = _textFilesReaderWriter
                .ReadFileAndDeserialize<List<RadiocomponentBase>>(filePath,
                    errorMessager);

            switch (loadOption)
            {
                case RadiocomponentsLoadOption.AddToEnd:
                    break;
                case RadiocomponentsLoadOption.ReplaceAll:
                    targetCollection.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loadOption),
                        loadOption, null);
            }

            targetCollection.AddRange(newRadiocomponents);
            return true;
        }
    }
}
