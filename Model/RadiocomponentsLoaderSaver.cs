using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс сохранения в файл/загрузки из файла радиокомпонентов.
    /// </summary>
    public class RadiocomponentsLoaderSaver
    {
        private readonly List<RadiocomponentBase> _allRadiocomponents;
        private readonly List<RadiocomponentBase> _selectedRadiocomponents;
        private readonly FilesReaderWriter _filesReaderWriter;

        /// <summary>
        /// Создает экземпляр класса загрузки из файла/сохранения в файл
        /// радиокомпонентов.
        /// </summary>
        /// <param name="allRadiocomponents">Коллекция всех радиокомпонентов.
        /// </param>
        /// <param name="selectedRadiocomponents">Коллекция выделенных
        /// радиокомпонентов.</param>
        /// <param name="filesReaderWriter">Экземпляр класса
        /// <see cref="FilesReaderWriter"/>.</param>
        public RadiocomponentsLoaderSaver(
            List<RadiocomponentBase> allRadiocomponents,
            List<RadiocomponentBase> selectedRadiocomponents,
            FilesReaderWriter filesReaderWriter)
        {
            _allRadiocomponents = allRadiocomponents;
            _selectedRadiocomponents = selectedRadiocomponents;
            _filesReaderWriter = filesReaderWriter;
        }

        /// <summary>
        /// Сохраняет радиокомпоненты в файл.
        /// </summary>
        /// <param name="saveOption">Опция сохранения в файл.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="errorMessager">Делегат для вывода сообщений об
        /// ошибках.</param>
        /// <returns>true, если радиокомпоненты были сохранены, иначе -
        /// false.</returns>
        public bool SaveToFile(RadiocomponentsSaveOption saveOption,
            string filePath, Action<string> errorMessager = null)
        {
            List<RadiocomponentBase> savingRadiocomponents;

            switch (saveOption)
            {
                case RadiocomponentsSaveOption.SaveAll:
                    savingRadiocomponents = _allRadiocomponents;
                    break;
                case RadiocomponentsSaveOption.SaveSelected:
                    savingRadiocomponents = _selectedRadiocomponents;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(saveOption),
                        saveOption, null);
            }

            _filesReaderWriter.SerializeAndWriteToFile(savingRadiocomponents,
                filePath, errorMessager);
            return true;
        }

        /// <summary>
        /// Загружает радиокомпоненты из файла.
        /// </summary>
        /// <param name="loadOption">Опция загрузки из файла.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="errorMessager">Делегат для вывода сообщений об
        /// ошибках.</param>
        /// <returns>true, если радиокомпоненты были загружены, иначе -
        /// false.</returns>
        public bool LoadFromFile(RadiocomponentsLoadOption loadOption,
            string filePath, Action<string> errorMessager = null)
        {
            var newRadiocomponents = _filesReaderWriter
                .ReadFileAndDeserialize<List<RadiocomponentBase>>(filePath,
                    errorMessager);

            switch (loadOption)
            {
                case RadiocomponentsLoadOption.AddToEnd:
                    break;
                case RadiocomponentsLoadOption.ReplaceAll:
                    _allRadiocomponents.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loadOption),
                        loadOption, null);
            }

            _allRadiocomponents.AddRange(newRadiocomponents);
            return true;
        }
    }
}
