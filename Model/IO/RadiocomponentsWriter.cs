using System;
using System.Collections.Generic;

namespace Model.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class RadiocomponentsWriter
    {
        private readonly TextFileWriter _textFileWriter;

        /// <summary>
        /// Создает экземпляр класса чтения радиокомпонентов из файла.
        /// </summary>
        /// <param name="textFileWriter">Экземпляр класса записи объектов в
        /// текстовые файлы <see cref="TextFileWriter"/>.</param>
        public RadiocomponentsWriter(TextFileWriter textFileWriter)
        {
            _textFileWriter = textFileWriter;
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
        public bool SaveToFile(SaveOption saveOption, string filePath,
            IList<RadiocomponentBase> allRadiocomponents,
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

            _textFileWriter.SerializeAndWriteToFile(savingRadiocomponents,
                filePath, errorMessager);
            return true;
        }
    }
}
