using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс чтения радиокомпонентов из файла/записи радиокомпонентов в
    /// файл.
    /// </summary>
    public class RadiocomponentsReaderWriter
    {
        private readonly TextFilesReaderWriter _textFilesReaderWriter;

        /// <summary>
        /// Создает экземпляр класса чтения радиокомпонентов из файла/записи
        /// радиокомпонентов в файл.
        /// </summary>
        /// <param name="textFilesReaderWriter">Экземпляр класса
        /// чтения/записи текстовых файлов
        /// <see cref="TextFilesReaderWriter"/>.</param>
        public RadiocomponentsReaderWriter(
            TextFilesReaderWriter textFilesReaderWriter)
        {
            _textFilesReaderWriter = textFilesReaderWriter;
        }

        /// <summary>
        /// Стандартное расширение файлов, хранящих радиокомпоненты.
        /// </summary>
        public const string DefaultExtension = "cmp";

        /// <summary>
        /// Стандартный фильтр файлов.
        /// </summary>
        public static string DefaultFilesFilter
            => $"Файлы радиокомпонентов (*.{DefaultExtension})|" +
               $"*.{DefaultExtension}|Все файлы (*.*)|*.*";

        /// <summary>
        /// Опции сохранения радиокомпонентов в файл с описаниями.
        /// </summary>
        public static Dictionary<SaveOption, string>
            SaveOptionToDescriptionDictionary
            => new Dictionary<SaveOption, string>
            {
                [SaveOption.SaveAll] = "Сохранить все радиокомпоненты",
                [SaveOption.SaveSelected]
                    = "Сохранить только выделенные радиокомпоненты"
            };

        /// <summary>
        /// Опции загрузки радиокомпонентов из файла с описаниями.
        /// </summary>
        public static Dictionary<LoadOption, string>
            LoadOptionToDescriptionDictionary
            => new Dictionary<LoadOption, string>
            {
                [LoadOption.AddToEnd] = "Добавить в конец таблицы",
                [LoadOption.ReplaceAll]
                    = "Заменить все радиокомпоненты в таблице новыми"
            };

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
        public bool SaveToFile(SaveOption saveOption,
            string filePath, IList<RadiocomponentBase> allRadiocomponents,
            IList<RadiocomponentBase> selectedRadiocomponents,
            Action<string> errorMessager = null)
        {
            IEnumerable<RadiocomponentBase> savingRadiocomponents;

            switch (saveOption)
            {
                case SaveOption.SaveAll:
                    savingRadiocomponents = allRadiocomponents;
                    break;
                case SaveOption.SaveSelected:
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
        public bool LoadFromFile(LoadOption loadOption,
            string filePath, IList<RadiocomponentBase> targetCollection,
            Action<string> errorMessager = null)
        {
            var newRadiocomponents = _textFilesReaderWriter
                .ReadFileAndDeserialize<List<RadiocomponentBase>>(filePath,
                    errorMessager);

            switch (loadOption)
            {
                case LoadOption.AddToEnd:
                    break;
                case LoadOption.ReplaceAll:
                    targetCollection.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loadOption),
                        loadOption, null);
            }

            foreach (var radiocomponent in newRadiocomponents)
            {
                targetCollection.Add(radiocomponent);
            }
            return true;
        }
    }
}
