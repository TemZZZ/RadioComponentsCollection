#define IS_RANDOM_BUTTON_VISIBLE

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Model;

namespace MVVM
{
    internal class AddRadiocomponentViewModel : ViewModelBase
    {
        #region -- Private fields --

        /// <summary>
        /// Типы радиокомпонентов, которые можно будет создавать.
        /// </summary>
        private readonly List<RadiocomponentType> _radiocomponentTypes
            = new List<RadiocomponentType>
            {
                RadiocomponentType.Resistor,
                RadiocomponentType.Inductor,
                RadiocomponentType.Capacitor
            };

        private string _radiocomponentValueAsString = "0";
        private int? _selectedRadiocomponentTypeIndex;
        private bool _isRadiocomponentValueValid;
        private double _radiocomponentValue;
        private RelayCommand _adddRadiocomponentCommand;
        private RelayCommand _generateRandomRadiocomponentProperties;
        private ObservableCollection<RadiocomponentBase> _radiocomponents;

        #endregion

        #region -- Private methods --

        /// <summary>
        /// Формирует и возвращает ассоциативный массив, ставящий в
        /// соответствие строковому представлению типа радиокомпонента
        /// строковые представления его физической величины и единицы
        /// измерения.
        /// </summary>
        /// <param name="radiocomponentTypes">Типы радиокомпонентов.</param>
        /// <returns>Ассоциативный массив, ставящий в соответствие строковому
        /// представлению типа радиокомпонента строковые представления его
        /// физической величины и единицы измерения.</returns>
        private List<(string, string)>
            GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap(
                IEnumerable<RadiocomponentType> radiocomponentTypes)
        {
            var typeAsStringToQuantityUnitAsStringMap
                = new List<(string, string)>();

            foreach (var radiocomponentType in radiocomponentTypes)
            {
                var radiocomponentTypeAsString = RadiocomponentService
                    .ToString(radiocomponentType);

                var radiocomponentQuantity = RadiocomponentService
                    .GetRadiocomponentQuantity(radiocomponentType);
                var radiocomponentQuantityAsString = RadiocomponentService
                    .ToString(radiocomponentQuantity);

                var radiocomponentUnit = RadiocomponentService
                    .GetRadiocomponentUnit(radiocomponentType);
                var radiocomponentUnitAsString = RadiocomponentService
                    .ToString(radiocomponentUnit);

                var quantityUnitAsString
                    = radiocomponentQuantityAsString
                      + ", " + radiocomponentUnitAsString;

                typeAsStringToQuantityUnitAsStringMap.Add(
                    (radiocomponentTypeAsString, quantityUnitAsString));
            }

            return typeAsStringToQuantityUnitAsStringMap;
        }

        /// <summary>
        /// Проверяет, представляет ли строка неотрицательное вещественное
        /// число. Если да, то в true устанавливается соответствующий флаг,
        /// и обновляется значение поля, хранящего значение физической
        /// величины радиокомпонента.
        /// </summary>
        /// <param name="radiocomponentValueAsString">Исходная строка.
        /// </param>
        private void ValidateAndSetRadiocomponentValue(
            string radiocomponentValueAsString)
        {
            _isRadiocomponentValueValid = NotNegativeDoubleValidationRule
                .TryConvertToNotNegativeDouble(radiocomponentValueAsString,
                    out var newRadiocomponentValue);

            if (_isRadiocomponentValueValid)
            {
                _radiocomponentValue = newRadiocomponentValue;
            }
        }

        /// <summary>
        /// Включает радокнопку, соответствующую типу случайного
        /// радиокомпонента, а также вносит в текстовое поле значение
        /// физической величины этого случайного радиокомпонента.
        /// </summary>
        private void SetRandomRadiocomponentProperties()
        {
            var radiocomponent
                = RadiocomponentFactory.CreateRandomRadiocomponent();
            var radiocomponentTypeIndex
                = _radiocomponentTypes.IndexOf(radiocomponent.Type);

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
            if (_selectedRadiocomponentTypeIndex == null
                || _radiocomponents == null)
            {
                return;
            }

            var newRadiocomponent = RadiocomponentFactory.CreateRadiocomponent(
                _radiocomponentTypes[(int)_selectedRadiocomponentTypeIndex],
                _radiocomponentValue);
            _radiocomponents.Add(newRadiocomponent);
        }

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления
        /// <see cref="AddRadiocomponentViewModel"/>.
        /// </summary>
        public AddRadiocomponentViewModel(
            ObservableCollection<RadiocomponentBase> radiocomponents)
        {
            _radiocomponents = radiocomponents;
            ValidateAndSetRadiocomponentValue(_radiocomponentValueAsString);
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
                => GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap(
                    _radiocomponentTypes);

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
                ValidateAndSetRadiocomponentValue(value);
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
            => _adddRadiocomponentCommand ?? (_adddRadiocomponentCommand
                = new RelayCommand(
                    obj => AddRadiocomponent(),
                    obj => _isRadiocomponentValueValid
                           && (SelectedRadiocomponentTypeIndex != null)));

        public RelayCommand GenerateRandomRadiocomponentProperties
            => _generateRandomRadiocomponentProperties
               ?? (_generateRandomRadiocomponentProperties
                   = new RelayCommand(
                       obj => SetRandomRadiocomponentProperties()));

        #endregion
    }
}
