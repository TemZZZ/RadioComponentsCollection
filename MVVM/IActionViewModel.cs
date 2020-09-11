using System.Collections.Generic;
using System.ComponentModel;

namespace MVVM
{
    /// <summary>
    /// Интерфейс модели представления действия с опциями.
    /// </summary>
    interface IActionViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        string WindowTitle { get; }

        /// <summary>
        /// Дополнительные опции для действия. Нужно для отображения
        /// коллекции радиокнопок с именами опций. Вторые части кортежей
        /// могут быть любыми и не участвуют в формировании разметки.
        /// </summary>
        List<(string, string)> Options { get; }

        /// <summary>
        /// Имя действия.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Команда, выполняющая действие.
        /// </summary>
        RelayCommand ActionCommand { get; }
    }
}
