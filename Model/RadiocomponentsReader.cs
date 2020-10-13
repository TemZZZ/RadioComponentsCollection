using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс чтения радиокомпонентов из файла.
    /// </summary>
    public class RadiocomponentsReader
    {
        private readonly TextFileReader _textFileReader;

        /// <summary>
        /// Создает экземпляр класса чтения радиокомпонентов из файла.
        /// </summary>
        /// <param name="textFileReader">Экземпляр класса чтения текстовых
        /// файлов <see cref="TextFileReader"/>.</param>
        public RadiocomponentsReader(TextFileReader textFileReader)
        {
            _textFileReader = textFileReader;
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
        public bool LoadFromFile(LoadOption loadOption, string filePath,
            IList<RadiocomponentBase> targetCollection,
            Action<string> errorMessager = null)
        {
            var newRadiocomponents = _textFileReader
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
