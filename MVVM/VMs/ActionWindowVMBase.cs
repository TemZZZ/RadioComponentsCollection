using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM.VMs
{
    /// <summary>
    /// Базовый класс, содержащий минимальную функциональность модели
    /// представления окна действия с опциями.
    /// </summary>
    /// <typeparam name="TOption">Тип опций.</typeparam>
    internal abstract class ActionWindowVMBase<TOption> : VMBase
        where TOption : Enum
    {
        private uint? _selectedOptionIndex;

        /// <summary>
        /// Возвращает словарь, ставящий в соответствие опции ее описание.
        /// </summary>
        /// <returns>Словарь, ставящий в соответствие опции ее описание.
        /// </returns>
        protected abstract IDictionary<TOption, string>
            GetOptionToDescriptionDictionary();

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public abstract string WindowTitle { get; }

        /// <summary>
        /// Дополнительные опции для действия. Нужно для отображения
        /// коллекции радиокнопок с именами опций. Вторые части кортежей
        /// могут быть любыми и не участвуют в формировании разметки.
        /// </summary>
        public List<(string, string)> Options
            => GetOptionToDescriptionDictionary().Values.Select(
                description => new ValueTuple<string, string>(
                    description, null)).ToList();

        /// <summary>
        /// Индекс выбранной опции. Если null, то ни одна опция не выбрана.
        /// </summary>
        public uint? SelectedOptionIndex
        {
            get => _selectedOptionIndex;
            set
            {
                _selectedOptionIndex = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Имя действия.
        /// </summary>
        public abstract string ActionName { get; }

        /// <summary>
        /// Команда, выполняющая действие.
        /// </summary>
        public abstract RelayCommand ActionCommand { get; }
    }
}
