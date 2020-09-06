#define IS_RANDOM_BUTTON_VISIBLE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MVVM
{
    internal class AddRadiocomponentViewModel : ViewModelBase, IDataErrorInfo
    {
        #region -- Private fields --

        /// <summary>
        /// Типы радиокомпонентов, которые можно будет создавать.
        /// </summary>
        private readonly RadiocomponentType[] _radiocomponentTypes =
        {
            RadiocomponentType.Resistor,
            RadiocomponentType.Inductor,
            RadiocomponentType.Capacitor
        };

        private string _radiocomponentValueAsString;
        private int? _selectedRadiocomponentTypeIndex;
        private bool _isRadiocomponentValueValid;
        private double _radiocomponentValue;
        private RelayCommand _adddRadiocomponentCommand;

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
        /// Проверяет, представляет ли строка положительное вещественное
        /// число.
        /// </summary>
        /// <param name="radiocomponentValueAsString">Исходная строка.
        /// </param>
        private void ValidateAndSetRadiocomponentValue(
            string radiocomponentValueAsString)
        {
            double doubleValue;
            var isDoubleParsedOk = double.TryParse(
                radiocomponentValueAsString, NumberStyles.Any,
                CultureInfo.InvariantCulture, out doubleValue);

            _isRadiocomponentValueValid = false;

            if (!isDoubleParsedOk)
            {
                return;
            }
            
            if (doubleValue >= 0)
            {
                _isRadiocomponentValueValid = true;
                _radiocomponentValue = doubleValue;
            }
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
                ValidateAndSetRadiocomponentValue(
                    _radiocomponentValueAsString);
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
                    obj => { SelectedRadiocomponentTypeIndex = null; },
                    obj => _isRadiocomponentValueValid
                           && (SelectedRadiocomponentTypeIndex != null)));

        #endregion

        #region -- IDataErrorInfo implementation --

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(RadiocomponentValueAsString):
                        
                        if (!_isRadiocomponentValueValid)
                        {
                            return "Radiocomponent value must be a " +
                                   "positive double value.";
                        }
                        break;
                }
                return null;
            }
        }

        public string Error => throw new NotImplementedException();

        #endregion
    }
}
