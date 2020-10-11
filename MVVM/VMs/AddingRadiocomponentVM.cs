#define IS_RANDOM_BUTTON_VISIBLE

using System.Collections.Generic;
using System.Globalization;
using Model;
using MVVM.Converters;
using MVVM.ValidationRules;

namespace MVVM.VMs
{
    internal class AddingRadiocomponentVM : VMBase
    {
        #region -- Private fields --

        private List<RadiocomponentType> _availableRadiocomponentTypes;
        private ICollection<RadiocomponentBase> _radiocomponents;
        private bool _isRadiocomponentValueValid;
        private double _radiocomponentValue;

        // Эти поля в коде не трогать! Используй публичные свойства!
        private string _radiocomponentValueAsString = "0";
        private int? _selectedRadiocomponentTypeIndex;
        private RelayCommand _addRadiocomponentCommand;
        private RelayCommand _setRandomRadiocomponentPropertiesCommand;

        #endregion

        #region -- Private methods --

        /// <summary>
        /// Включает радокнопку, соответствующую типу случайного
        /// радиокомпонента, а также вносит в текстовое поле значение
        /// физической величины этого случайного радиокомпонента.
        /// </summary>
        private void SetRandomRadiocomponentProperties()
        {
            var radiocomponent = RadiocomponentFactory
                .GetRandomRadiocomponent();
            var radiocomponentTypeIndex = _availableRadiocomponentTypes
                .IndexOf(radiocomponent.Type);

            if (radiocomponentTypeIndex < 0)
            {
                SelectedRadiocomponentTypeIndex = null;
            }
            else
            {
                SelectedRadiocomponentTypeIndex = radiocomponentTypeIndex;
            }

            RadiocomponentValueAsString = radiocomponent.Value.ToString(
                CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Добавляет новый радиокомпонент в коллекцию.
        /// </summary>
        private void AddRadiocomponent()
        {
            if (SelectedRadiocomponentTypeIndex == null
                || _radiocomponents == null)
            {
                return;
            }

            var radiocomponentType = _availableRadiocomponentTypes[
                (int)SelectedRadiocomponentTypeIndex];
            var radiocomponent = RadiocomponentFactory.GetRadiocomponent(
                radiocomponentType, _radiocomponentValue);
            _radiocomponents.Add(radiocomponent);
        }

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления
        /// <see cref="AddingRadiocomponentVM"/>.
        /// </summary>
        /// <param name="availableRadiocomponentTypes">Типы радиокомпонентов,
        /// которые можно будет создавать.</param>
        /// <param name="radiocomponents">Коллекция радиокомпонентов, в
        /// которую будут добавляться новые радиокомпоненты.</param>
        public AddingRadiocomponentVM(
            List<RadiocomponentType> availableRadiocomponentTypes,
            ICollection<RadiocomponentBase> radiocomponents)
        {
            _availableRadiocomponentTypes = availableRadiocomponentTypes;
            _radiocomponents = radiocomponents;

            _isRadiocomponentValueValid = NotNegativeDoubleValidationRule
                .UpdateIfNotNegativeDouble(RadiocomponentValueAsString,
                    ref _radiocomponentValue);
        }

        #endregion

        #region -- Public properties --

        /// <summary>
        /// Позволяет получить ассоциативный массив, ставящий в соответствие
        /// строковому представлению типа радиокомпонента строковые
        /// представления его физической величины и единицы измерения.
        /// </summary>
        public List<(string, string)>
            RadiocomponentTypeAsStringToQuantityUnitAsStringMap
                => RadiocomponentTypesToStringsDictionaryConverter
                    .GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap(
                        _availableRadiocomponentTypes);

        /// <summary>
        /// Позволяет задать или получить строковое представление значения
        /// физической величины радиокомпонента.
        /// </summary>
        public string RadiocomponentValueAsString
        {
            get => _radiocomponentValueAsString;
            set
            {
                _radiocomponentValueAsString = value;

                _isRadiocomponentValueValid = NotNegativeDoubleValidationRule
                    .UpdateIfNotNegativeDouble(RadiocomponentValueAsString,
                        ref _radiocomponentValue);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить значение видимости кнопки создания случайного
        /// радиокомпонента.
        /// </summary>
#if IS_RANDOM_BUTTON_VISIBLE
        public bool IsRandomRadiocomponentButtonVisible { get; } = true;
#else
        public bool IsRandomRadiocomponentButtonVisible { get; } = false;
#endif

        /// <summary>
        /// Позволяет получить или задать индекс выделенного типа
        /// радиокомпонента.
        /// </summary>
        public int? SelectedRadiocomponentTypeIndex
        {
            get => _selectedRadiocomponentTypeIndex;
            set
            {
                _selectedRadiocomponentTypeIndex = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region -- Commands --

        public RelayCommand AddRadiocomponentCommand
            => _addRadiocomponentCommand ?? (_addRadiocomponentCommand
                = new RelayCommand(obj => AddRadiocomponent(),
                    obj => _isRadiocomponentValueValid
                           && SelectedRadiocomponentTypeIndex != null));

        public RelayCommand SetRandomRadiocomponentPropertiesCommand
            => _setRandomRadiocomponentPropertiesCommand
               ?? (_setRandomRadiocomponentPropertiesCommand
                   = new RelayCommand(
                       obj => SetRandomRadiocomponentProperties()));

        #endregion
    }
}
