using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace MVVM
{
    /// <summary>
    /// Класс модели представления поиска радиокомпонентов по коллекции.
    /// </summary>
    internal class SearchRadiocomponentViewModel : ViewModelBase
    {
        #region -- Private fields --

        /// <summary>
        /// Функция "меньше, чем".
        /// </summary>
        private Func<double, double, bool> _lessThan
            = (param, otherParam) => param < otherParam;
        /// <summary>
        /// Функция "больше, чем".
        /// </summary>
        private Func<double, double, bool> _moreThan
            = (param, otherParam) => param > otherParam;
        /// <summary>
        /// Функция "равно".
        /// </summary>
        private Func<double, double, bool> _equals
            = (param, otherParam) => param == otherParam;

        private Dictionary<string, RadiocomponentType>
            _typeNameToRadiocomponentTypeMap;
        private List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
            _indexedRadiocomponents;

        private double _lessThanFilterThreshold;
        private double _moreThanFilterThreshold;
        private double _equalsFilterThreshold;

        private bool _isLessThanFilterThresholdValid;
        private bool _isMoreThanFilterThresholdValid;
        private bool _isEqualsFilterThresholdValid;

        // Эти поля в коде не трогать! Используй публичные свойства!
        private bool _isLessThanFilterTurnedOn;
        private bool _isMoreThanFilterTurnedOn;
        private bool _isEqualsFilterTurnedOn;
        private string _lessThanFilterThresholdAsString;
        private string _moreThanFilterThresholdAsString;
        private string _equalsFilterThresholdAsString;

        #endregion

        #region -- Auxiliary private methods --

        /// <summary>
        /// Возвращает проиндексированную коллекцию адаптированных
        /// удобочитаемых компонентов.
        /// </summary>
        /// <param name="radiocomponents">Исходные адаптированные
        /// радиокомпоненты.</param>
        /// <returns>Список пар значений "индекс-адаптированный
        /// радиокомпонент".</returns>
        private List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
            GetIndexedRadiocomponents(
                IList<RadiocomponentToPrintableRadiocomponentAdapter>
                    radiocomponents)
        {
            var indexedRadiocomponents
                = new List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>();
            for (int i = 0; i < radiocomponents.Count; ++i)
            {
                indexedRadiocomponents.Add((i, radiocomponents[i]));
            }
            return indexedRadiocomponents;
        }

        /// <summary>
        /// Создает и возвращает словарь, ставящий в соответствие читаемым
        /// именам типов радиокомпонентов сами типы радиокомпонентов.
        /// </summary>
        /// <param name="radiocomponentTypes">Типы радиокомпонентов.</param>
        /// <returns>Словарь, ставящий в соответствие читаемым именам типов
        /// радиокомпонентов сами типы радиокомпонентов.</returns>
        private Dictionary<string, RadiocomponentType>
            GetTypeNameToRadiocomponentTypeMap(
                IEnumerable<RadiocomponentType> radiocomponentTypes)
        {
            return radiocomponentTypes.ToDictionary(
                RadiocomponentService.ToString);
        }

        /// <summary>
        /// Фильтрует коллекцию проиндексированных адаптированных
        /// радиокомпонентов по типу и возвращает отфильтрованную коллекцию.
        /// </summary>
        /// <param name="desiredType">Желаемый тип радиокомпонентов.</param>
        /// <param name="indexedRadiocomponents">Исходная коллекция
        /// проиндексированных адаптированных радиокомпонентов.</param>
        /// <returns></returns>
        private IEnumerable<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
            GetFilteredByTypeIndexedRadiocomponents(
                RadiocomponentType desiredType,
                IEnumerable<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
                    indexedRadiocomponents)
        {
            if (indexedRadiocomponents == null)
            {
                throw new ArgumentNullException(
                    nameof(indexedRadiocomponents));
            }

            return
                from indexedRadiocomponent in indexedRadiocomponents
                where indexedRadiocomponent.Item2.GetRadiocomponent().Type
                      == desiredType
                select indexedRadiocomponent;
        }

        /// <summary>
        /// Фильтрует проиндексированные адаптированные радиокомпоненты по
        /// значению с использованием компаратора и возвращает индексы
        /// отфильтрованных адаптированных радиокомпонентов. Если компаратор
        /// отключен, то вернутся индексы всех элементов исходной коллекции.
        /// </summary>
        /// <param name="comparator">Компаратор.</param>
        /// <param name="isComparatorTurnedOn">Включен ли компаратор.</param>
        /// <param name="filterThreshold">Параметр фильтра (ограничение).
        /// </param>
        /// <param name="indexedRadiocomponents">Проиндексированные
        /// адаптированные радиокомпоненты.</param>
        /// <returns>Индексы отфильтрованных адаптированных радиокомпонентов.
        /// </returns>
        private IEnumerable<int>
            GetFilteredByValueIndexedRadiocomponentsIndices(
                Func<double, double, bool> comparator,
                bool isComparatorTurnedOn, double filterThreshold,
                IEnumerable<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
                    indexedRadiocomponents)
        {
            if (comparator == null
                || indexedRadiocomponents == null)
            {
                var exceptionMessage
                    = $"{nameof(comparator)} or " +
                      $"{nameof(indexedRadiocomponents)} cannot be null.";
                throw new ArgumentNullException(exceptionMessage);
            }

            if (double.IsNaN(filterThreshold))
            {
                var exceptionMessage = $"{nameof(filterThreshold)} " +
                                       "cannot be NaN.";
                throw new ArgumentException(exceptionMessage);
            }

            if (!isComparatorTurnedOn)
            {
                return
                    from indexedRadiocomponent in indexedRadiocomponents
                    select indexedRadiocomponent.Item1;
            }

            return
                from indexedRadiocomponent in indexedRadiocomponents
                where comparator(indexedRadiocomponent.Item2.Value,
                    filterThreshold)
                select indexedRadiocomponent.Item1;
        }

        #endregion

        #region -- Public properties --

        /// <summary>
        /// Позволяет получить или задать состояние фильтра "меньше, чем".
        /// </summary>
        public bool IsLessThanFilterTurnedOn
        {
            get => _isLessThanFilterTurnedOn;
            set
            {
                _isLessThanFilterTurnedOn = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать состояние фильтра "больше, чем".
        /// </summary>
        public bool IsMoreThanFilterTurnedOn
        {
            get => _isMoreThanFilterTurnedOn;
            set
            {
                _isMoreThanFilterTurnedOn = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать состояние фильтра "равно".
        /// </summary>
        public bool IsEqualsFilterTurnedOn
        {
            get => _isEqualsFilterTurnedOn;
            set
            {
                _isEqualsFilterTurnedOn = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление параметра
        /// фильтра "меньше, чем".
        /// </summary>
        public string LessThanFilterThresholdAsString
        {
            get => _lessThanFilterThresholdAsString;
            set
            {
                _lessThanFilterThresholdAsString = value;

                _isLessThanFilterThresholdValid
                    = NotNegativeDoubleValidationRule
                        .UpdateIfNotNegativeDouble(
                            LessThanFilterThresholdAsString,
                            ref _lessThanFilterThreshold);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление параметра
        /// фильтра "больше, чем".
        /// </summary>
        public string MoreThanFilterThresholdAsString
        {
            get => _moreThanFilterThresholdAsString;
            set
            {
                _moreThanFilterThresholdAsString = value;

                _isMoreThanFilterThresholdValid
                    = NotNegativeDoubleValidationRule
                        .UpdateIfNotNegativeDouble(
                            MoreThanFilterThresholdAsString,
                            ref _moreThanFilterThreshold);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление параметра
        /// фильтра "меньше, чем".
        /// </summary>
        public string EqualsFilterThresholdAsString
        {
            get => _equalsFilterThresholdAsString;
            set
            {
                _equalsFilterThresholdAsString = value;

                _isEqualsFilterThresholdValid
                    = NotNegativeDoubleValidationRule
                        .UpdateIfNotNegativeDouble(
                            EqualsFilterThresholdAsString,
                            ref _equalsFilterThreshold);
                RaisePropertyChanged();
            }
        }

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Создает экземпляр модели представления поиска радиокомпонентов.
        /// </summary>
        /// <param name="availableRadiocomponentTypes">Доступные типы
        /// радиокомпонентов для поиска.</param>
        /// <param name="radiocomponents">Коллекция радиокомпонентов, по
        /// которой производится поиск.</param>
        public SearchRadiocomponentViewModel(
            IEnumerable<RadiocomponentType> availableRadiocomponentTypes,
            IList<RadiocomponentToPrintableRadiocomponentAdapter>
                radiocomponents)
        {
            _typeNameToRadiocomponentTypeMap
                = GetTypeNameToRadiocomponentTypeMap(
                    availableRadiocomponentTypes);
            _indexedRadiocomponents = GetIndexedRadiocomponents(
                radiocomponents);
        }

        #endregion
    }
}
