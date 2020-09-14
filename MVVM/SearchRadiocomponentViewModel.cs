using System;
using System.Collections;
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

        private const string _allTypesText = "<Все типы>";

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
        private IList<RadiocomponentToPrintableRadiocomponentAdapter>
            _radiocomponents;
        private IList _selectedObjects;

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
        private string _selectedRadiocomponentTypeName;
        private RelayCommand _searchCommand;

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
        /// отключен, то вернется пустая коллекция.
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
                double filterThreshold,
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

            return
                from indexedRadiocomponent in indexedRadiocomponents
                where comparator(indexedRadiocomponent.Item2.Value,
                    filterThreshold)
                select indexedRadiocomponent.Item1;
        }

        /// <summary>
        /// Обновляет выделенные радиокомпоненты по результатам поиска.
        /// </summary>
        private void SelectFilteredRadiocomponents()
        {
            List<(int, RadiocomponentToPrintableRadiocomponentAdapter)>
                filteredByTypeIndexedRadiocomponents;
            RadiocomponentType selectedRadiocomponentType;
            if (SelectedRadiocomponentTypeName != _allTypesText)
            {
                selectedRadiocomponentType
                    = _typeNameToRadiocomponentTypeMap[
                        SelectedRadiocomponentTypeName];
                filteredByTypeIndexedRadiocomponents
                    = GetFilteredByTypeIndexedRadiocomponents(
                        selectedRadiocomponentType,
                        GetIndexedRadiocomponents(_radiocomponents))
                        .ToList();
            }
            else
            {
                filteredByTypeIndexedRadiocomponents
                    = GetIndexedRadiocomponents(_radiocomponents);
            }

            var filteredByTypeRadiocomponentsIndices
                = filteredByTypeIndexedRadiocomponents.Select(
                    indexedRadiocomponent => indexedRadiocomponent.Item1)
                    .ToList();

            var lessThanFilteredRadiocomponentsIndices
                = filteredByTypeRadiocomponentsIndices;
            if (IsLessThanFilterTurnedOn)
            {
                lessThanFilteredRadiocomponentsIndices
                    = GetFilteredByValueIndexedRadiocomponentsIndices(
                        _lessThan, _lessThanFilterThreshold,
                        filteredByTypeIndexedRadiocomponents).ToList();
            }

            var moreThanFilteredRadiocomponentsIndices
                = filteredByTypeRadiocomponentsIndices;
            if (IsMoreThanFilterTurnedOn)
            {
                moreThanFilteredRadiocomponentsIndices
                    = GetFilteredByValueIndexedRadiocomponentsIndices(
                        _moreThan, _moreThanFilterThreshold,
                        filteredByTypeIndexedRadiocomponents).ToList();
            }

            var equalsFilteredRadiocomponentsIndices = new List<int>();
            if (IsEqualsFilterTurnedOn)
            {
                equalsFilteredRadiocomponentsIndices
                    = GetFilteredByValueIndexedRadiocomponentsIndices(
                        _equals, _equalsFilterThreshold,
                        filteredByTypeIndexedRadiocomponents).ToList();
            }

            var intersectionIndices = lessThanFilteredRadiocomponentsIndices
                .Intersect(moreThanFilteredRadiocomponentsIndices)
                .ToList();

            var selectedByTypeAndValueRadiocomponentsIndices
                = intersectionIndices.Union(
                    equalsFilteredRadiocomponentsIndices).ToList();

            _selectedObjects.Clear();
            foreach (var index
                in selectedByTypeAndValueRadiocomponentsIndices)
            {
                _selectedObjects.Add(_radiocomponents[index]);
            }
        }

        #endregion

        #region -- Public properties --

        /// <summary>
        /// Позволяет получить имена допустимых типов радиокомпонентов для
        /// поиска.
        /// </summary>
        public List<string> AvailableRadiocomponentTypesNames
        {
            get
            {
                var availableRadiocomponentTypesNames = new List<string>
                {
                    _allTypesText
                };

                availableRadiocomponentTypesNames.AddRange(
                    _typeNameToRadiocomponentTypeMap.Keys);

                return availableRadiocomponentTypesNames;
            }
        }

        /// <summary>
        /// Позволяет получить или задать имя выбранного для поиска типа
        /// радиокомпонентов.
        /// </summary>
        public string SelectedRadiocomponentTypeName
        {
            get => _selectedRadiocomponentTypeName;
            set
            {
                _selectedRadiocomponentTypeName = value;
                RaisePropertyChanged();
            }
        }

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
        /// <param name="selectedObjects">Коллекция объектов, которая будет
        /// обновляться по результатам поиска.</param>
        public SearchRadiocomponentViewModel(
            IEnumerable<RadiocomponentType> availableRadiocomponentTypes,
            IList<RadiocomponentToPrintableRadiocomponentAdapter>
                radiocomponents, IList selectedObjects)
        {
            _typeNameToRadiocomponentTypeMap
                = GetTypeNameToRadiocomponentTypeMap(
                    availableRadiocomponentTypes);
            _radiocomponents = radiocomponents;
            _selectedObjects = selectedObjects;
        }

        #endregion

        #region -- Commands --

        public RelayCommand SearchCommand =>
            _searchCommand ?? (_searchCommand = new RelayCommand(
                obj => SelectFilteredRadiocomponents()));

        #endregion
    }
}
