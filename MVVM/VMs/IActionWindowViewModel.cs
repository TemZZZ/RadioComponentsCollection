using System.Collections.Generic;
using System.ComponentModel;

namespace MVVM.VMs
{
    /// <summary>
    /// Интерфейс модели представления окна действия с опциями.
    /// </summary>
    interface IActionWindowViewModel : INotifyPropertyChanged
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
        /// Индекс выбранной опции. Если null, то ни одна опция не выбрана.
        /// </summary>
        uint? SelectedOptionIndex { get; set; }

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
