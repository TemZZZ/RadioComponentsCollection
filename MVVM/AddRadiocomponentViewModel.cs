using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MVVM
{
    class AddRadiocomponentViewModel : ViewModelBase
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
                    .ToString(radiocomponentType);

                var quantityUnitAsString
                    = radiocomponentQuantityAsString
                      + ", " + radiocomponentUnitAsString;

                typeAsStringToQuantityUnitAsStringMap.Add(
                    (radiocomponentTypeAsString, quantityUnitAsString));
            }

            return typeAsStringToQuantityUnitAsStringMap;
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
            set
            {
                RadiocomponentService.ValidatePositiveDouble(value);
                _radiocomponentValue = value;
                RaisePropertyChanged();
            }
        }

        #endregion
    }
}
