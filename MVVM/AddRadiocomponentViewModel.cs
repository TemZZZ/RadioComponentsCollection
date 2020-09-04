﻿#define IS_RANDOM_BUTTON_VISIBLE

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private double _radiocomponentValue;
        private int? _selectedRadiocomponentTypeIndex;
        private bool _isRadiocomponentValueValid;

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

        private bool IsRadiocomponentValueValid(double radiocomponentValue)
        {
            bool isCorrectRadiocomponentValue = true;
            try
            {
                RadiocomponentService.ValidatePositiveDouble(
                    radiocomponentValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                isCorrectRadiocomponentValue = false;
            }
            catch (ArgumentException)
            {
                isCorrectRadiocomponentValue = false;
            }
            return isCorrectRadiocomponentValue;
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
        /// Позволяет задать значение физической величины радиокомпонента.
        /// </summary>
        public double RadiocomponentValue
        {
            get => _radiocomponentValue;
            set
            {
                _radiocomponentValue = value;
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

        private RelayCommand _adddRadiocomponentCommand;
        public RelayCommand AddRadiocomponentCommand
        {
            get => _adddRadiocomponentCommand ??
                   (_adddRadiocomponentCommand
                       = new RelayCommand(
                           obj => { SelectedRadiocomponentTypeIndex = null; },
                           obj => _isRadiocomponentValueValid && SelectedRadiocomponentTypeIndex != null));
        }

        #region -- IDataErrorInfo implementation --

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(RadiocomponentValue):
                        
                        if (!_isRadiocomponentValueValid)
                        {
                            return "Incorrect radiocomponent value.";
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
