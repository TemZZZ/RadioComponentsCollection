using System.Collections.Generic;
using Model.IO;

namespace Model.Services
{
    /// <summary>
    /// Вспомогательный класс для работы с чтением-записью радиокомпонентов.
    /// </summary>
    public static class RadiocomponentsIOService
    {
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
    }
}
