using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM
{
    /// <summary>
    /// Базовый класс, содержащий минимальную функциональность модели
    /// представления действия с опциями.
    /// </summary>
    /// <typeparam name="TOption">Тип опций.</typeparam>
    internal abstract class ActionViewModelBase<TOption>
        : ViewModelBase, IActionViewModel
        where TOption : Enum
    {
        private uint? _selectedOptionIndex;

        /// <summary>
        /// Возвращает словарь, ставящий в соответствие опции ее описание.
        /// </summary>
        /// <returns>Словарь, ставящий в соответствие опции ее описание.
        /// </returns>
        protected abstract
            IDictionary<TOption, string> GetOptionToDescriptionMap();

        /// <inheritdoc/>
        public abstract string WindowTitle { get; }

        /// <inheritdoc/>
        public List<(string, string)> Options
            => GetOptionToDescriptionMap().Values.Select(description
                => new ValueTuple<string, string>(description, null))
                .ToList();

        /// <inheritdoc/>
        public uint? SelectedOptionIndex
        {
            get => _selectedOptionIndex;
            set
            {
                _selectedOptionIndex = value;
                RaisePropertyChanged();
            }
        }

        /// <inheritdoc/>
        public abstract string ActionName { get; }

        /// <inheritdoc/>
        public abstract RelayCommand ActionCommand { get; }
    }
}
