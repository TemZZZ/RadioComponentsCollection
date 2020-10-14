using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows;
using Model;
using Model.Services;
using MVVM.Converters;
using MVVM.ValidationRules;
using MVVM.Views;

namespace MVVM.VMs
{
    internal class MainVM : VMBase
    {
        #region -- Private fields --

        private readonly ObservableCollection<RadiocomponentBase>
            _radiocomponents = new ObservableCollection<RadiocomponentBase>();

        /// <summary>
        /// Типы радиокомпонентов, которые можно будет создавать.
        /// </summary>
        private readonly List<RadiocomponentType>
            _availableRadiocomponentTypes = RadiocomponentService
                .GetAvailableRadiocomponentTypes();

        private readonly ViewRootRegistry _viewRootRegistry;

        private bool _isFrequencyValid;
        private bool _isSelectedRadiocomponentValueValid;
        private double _frequency;
        private double _selectedRadiocomponentValue;

        private RadiocomponentBase _singleSelectedRadiocomponent;

        // Эти поля в коде не трогать! Используй публичные свойства!
        private string _frequencyAsString;
        private string _selectedRadiocomponentValueAsString;
        private string _selectedRadiocomponentImpedanceAsString;
        private uint? _selectedRadiocomponentTypeIndex;
        private RelayCommand _openAddRadiocomponentWindowCommand;
        private RelayCommand _deleteSelectedRadiocomponentsCommand;
        private RelayCommand _modifyRadiocomponentCommand;
        private RelayCommand _openSaveToFileWindowCommand;
        private RelayCommand _openLoadFromFileWindowCommand;
        private RelayCommand _openSearchWindowCommand;
        private IList _selectedObjects;
        private bool _isSingleRadiocomponentSelected;

        #endregion

        #region -- Private methods --

        /// <summary>
        /// Обновляет текстовое представление импеданса выделенного
        /// радиокомпонента.
        /// </summary>
        private void UpdateSelectedRadiocomponentImpedanceAsString()
        {
            if (_singleSelectedRadiocomponent != null && _isFrequencyValid)
            {
                SelectedRadiocomponentImpedanceAsString = ComplexToString(
                    _singleSelectedRadiocomponent.GetImpedance(_frequency));
            }
            else
            {
                SelectedRadiocomponentImpedanceAsString = null;
            }
        }

        /// <summary>
        /// Обновляет текстовое представление значения физической величины
        /// выделенного радиокомпонента.
        /// </summary>
        private void UpdateRadiocomponentValueAsString()
        {
            if (_singleSelectedRadiocomponent != null)
            {
                SelectedRadiocomponentValueAsString
                    = _singleSelectedRadiocomponent.Value.ToString(
                        CultureInfo.InvariantCulture);
            }
            else
            {
                SelectedRadiocomponentValueAsString = null;
            }
        }

        /// <summary>
        /// Обновляет индекс типа выделенного радиокомпонента в коллекции
        /// доступных для создания типов радиокомпонентов.
        /// </summary>
        private void UpdateSelectedRadiocomponentTypeIndex()
        {
            if (_singleSelectedRadiocomponent != null)
            {
                var selectedRadiocomponentType
                    = _singleSelectedRadiocomponent.Type;

                SelectedRadiocomponentTypeIndex
                    = IndexToRadiocomponentTypeConverter
                        .GetIndexOfRadiocomponentType(
                            selectedRadiocomponentType,
                            _availableRadiocomponentTypes);
            }
            else
            {
                SelectedRadiocomponentTypeIndex = null;
            }
        }

        /// <summary>
        /// Возвращает строковое представление комплексного числа.
        /// </summary>
        /// <param name="number">Комплексное число.</param>
        /// <returns>Строковое представление комплексного числа.</returns>
        public static string ComplexToString(Complex number)
        {
            const int decimalDigitsCount = 4;
            var imaginarySign = number.Imaginary < 0 ? "-" : "+";
            var realAsString = number.Real.ToString($"G{decimalDigitsCount}",
                CultureInfo.InvariantCulture);
            var imaginaryAsString = Math.Abs(number.Imaginary).ToString(
                $"G{decimalDigitsCount}", CultureInfo.InvariantCulture);

            return $"{realAsString} {imaginarySign} {imaginaryAsString}*j";
        }

        #endregion

        #region -- Constructors --

        public MainVM(ViewRootRegistry viewRootRegistry)
        {
            _viewRootRegistry = viewRootRegistry;

            RadiocomponentVMs = new SyncObservableViewModelCollection
                <RadiocomponentVM, RadiocomponentBase>(_radiocomponents,
                    radiocomponent => new RadiocomponentVM(radiocomponent));

            const double defaultFrequency = 0;
            FrequencyAsString = defaultFrequency.ToString(
                CultureInfo.InvariantCulture);
        }

        #endregion

        #region -- Public properties --

        /// <summary>
        /// Позволяет получить ассоциативный массив, ставящий в соответствие
        /// строковому представлению типа радиокомпонента строковые
        /// представления его физической величины и единицы измерения.
        /// </summary>
        public List<(string, string)> RadiocomponentPropertiesTuples
            => RadiocomponentTypesToPropertiesTuplesConverter
                .GetRadiocomponentPropertiesTuples(
                    _availableRadiocomponentTypes);

        /// <summary>
        /// Коллекция вьюмоделей радиокомпонентов для показа пользователю.
        /// </summary>
        public SyncObservableViewModelCollection
            <RadiocomponentVM, RadiocomponentBase> RadiocomponentVMs { get; }

        /// <summary>
        /// Коллекция выделенных объектов.
        /// </summary>
        public IList SelectedObjects
        {
            get => _selectedObjects;
            set
            {
                _selectedObjects = value;

                if (SelectedObjects.Count == 1)
                {
                    _singleSelectedRadiocomponent
                        = ((RadiocomponentVM)SelectedObjects[0])
                        .Radiocomponent;
                    IsSingleRadiocomponentSelected = true;
                }
                else
                {
                    _singleSelectedRadiocomponent = null;
                    IsSingleRadiocomponentSelected = false;
                }

                UpdateRadiocomponentValueAsString();
                UpdateSelectedRadiocomponentImpedanceAsString();
                UpdateSelectedRadiocomponentTypeIndex();
            }
        }

        /// <summary>
        /// Позволяет получить или задать индекс типа выделенного
        /// радиокомпонента в коллекции доступных для создания типов.
        /// </summary>
        public uint? SelectedRadiocomponentTypeIndex
        {
            get => _selectedRadiocomponentTypeIndex;
            set
            {
                _selectedRadiocomponentTypeIndex = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление частоты.
        /// </summary>
        public string FrequencyAsString
        {
            get => _frequencyAsString;
            set
            {
                _frequencyAsString = value;

                _isFrequencyValid = NotNegativeDoubleValidationRule
                    .UpdateIfNotNegativeDouble(FrequencyAsString,
                        ref _frequency);
                UpdateSelectedRadiocomponentImpedanceAsString();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление значения
        /// физической величины радиокомпонента.
        /// </summary>
        public string SelectedRadiocomponentValueAsString
        {
            get => _selectedRadiocomponentValueAsString;
            set
            {
                _selectedRadiocomponentValueAsString = value;

                _isSelectedRadiocomponentValueValid
                    = NotNegativeDoubleValidationRule
                        .UpdateIfNotNegativeDouble(
                            SelectedRadiocomponentValueAsString,
                            ref _selectedRadiocomponentValue);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление импеданса
        /// выделенного радиокомпонента.
        /// </summary>
        public string SelectedRadiocomponentImpedanceAsString
        {
            get => _selectedRadiocomponentImpedanceAsString;
            set
            {
                _selectedRadiocomponentImpedanceAsString = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Выделен ли всего один радиокомпонент?
        /// </summary>
        public bool IsSingleRadiocomponentSelected
        {
            get => _isSingleRadiocomponentSelected;
            set
            {
                _isSingleRadiocomponentSelected = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region -- Commands --

        public RelayCommand OpenAddingRadiocomponentWindowCommand
            => _openAddRadiocomponentWindowCommand
               ?? (_openAddRadiocomponentWindowCommand = new RelayCommand(
                   obj =>
                   {
                       var addingRadiocomponentVM
                           = new AddingRadiocomponentVM(
                               _availableRadiocomponentTypes,
                               _radiocomponents);

                       var addingRadiocomponentWindow = _viewRootRegistry
                           .CreateWindowWithDataContext(
                               addingRadiocomponentVM);

                       addingRadiocomponentWindow.WindowStartupLocation
                           = WindowStartupLocation.CenterScreen;

                       addingRadiocomponentWindow.ShowDialog();
                   }));
        
        public RelayCommand DeleteSelectedRadiocomponentsCommand
            => _deleteSelectedRadiocomponentsCommand
               ?? (_deleteSelectedRadiocomponentsCommand = new RelayCommand(
                   obj =>
                   {
                       var selectedRadiocomponents = SelectedObjects
                           .Cast<RadiocomponentVM>()
                           .Select(radiocomponentVM
                               => radiocomponentVM.Radiocomponent);
                       var remainingRadiocomponents = _radiocomponents
                           .Except(selectedRadiocomponents).ToList();

                       _radiocomponents.Clear();
                       foreach (var radiocomponent
                           in remainingRadiocomponents)
                       {
                           _radiocomponents.Add(radiocomponent);
                       }
                   },
                   obj => SelectedObjects != null
                          && SelectedObjects.Count > 0));
        
        public RelayCommand ModifyRadiocomponentCommand
            => _modifyRadiocomponentCommand ?? (_modifyRadiocomponentCommand
                = new RelayCommand(
                    obj =>
                    {
                        var newRadiocomponentType
                            = IndexToRadiocomponentTypeConverter
                                .GetRadiocomponentTypeByIndex(
                                    (uint)SelectedRadiocomponentTypeIndex,
                                    _availableRadiocomponentTypes);

                        var newRadiocomponent = RadiocomponentFactory
                            .GetRadiocomponent(newRadiocomponentType,
                                _selectedRadiocomponentValue);

                        var selectedRadiocomponentIndex = _radiocomponents
                            .IndexOf(_singleSelectedRadiocomponent);

                        _radiocomponents[selectedRadiocomponentIndex]
                            = newRadiocomponent;

                        SelectedObjects.Add(
                            RadiocomponentVMs[selectedRadiocomponentIndex]);
                    },
                    obj => SelectedObjects != null
                           && SelectedObjects.Count == 1
                           && _isSelectedRadiocomponentValueValid
                           && SelectedRadiocomponentTypeIndex != null));
        
        public RelayCommand OpenSavingToFileWindowCommand
            => _openSaveToFileWindowCommand ?? (_openSaveToFileWindowCommand
                = new RelayCommand(
                    obj =>
                    {
                        var selectedRadiocomponents
                            = new List<RadiocomponentBase>();
                        if (SelectedObjects != null)
                        {
                            selectedRadiocomponents.AddRange(
                                SelectedObjects.Cast<RadiocomponentVM>()
                                    .Select(radiocomponentVM
                                        => radiocomponentVM.Radiocomponent));
                        }

                        var savingToFileVM
                            = new SavingRadiocomponentsWindowVM(
                                _radiocomponents, selectedRadiocomponents);
                        var savingToFileWindow = _viewRootRegistry
                            .CreateWindowWithDataContext(savingToFileVM);
                        savingToFileWindow.WindowStartupLocation
                            = WindowStartupLocation.CenterScreen;
                        savingToFileWindow.ShowDialog();
                    },
                    obj => _radiocomponents.Count > 0));
        
        public RelayCommand OpenLoadingFromFileWindowCommand
            => _openLoadFromFileWindowCommand
               ?? (_openLoadFromFileWindowCommand = new RelayCommand(
                   obj =>
                   {
                       var loadingFromFileVM
                           = new LoadingRadiocomponentsWindowVM(
                               _radiocomponents);
                       var loadingFromFileWindow = _viewRootRegistry
                           .CreateWindowWithDataContext(loadingFromFileVM);
                       loadingFromFileWindow.WindowStartupLocation
                           = WindowStartupLocation.CenterScreen;
                       loadingFromFileWindow.ShowDialog();
                   }));
        
        public RelayCommand OpenSearchingRadiocomponentsWindowCommand
            => _openSearchWindowCommand ?? (_openSearchWindowCommand
                = new RelayCommand(
                    obj =>
                    {
                        var searchingRadiocomponentsVM
                            = new SearchingRadiocomponentsVM(
                                _availableRadiocomponentTypes,
                                _radiocomponents, RadiocomponentVMs,
                                SelectedObjects);
                        var searchingRadiocomponentsWindow
                            = _viewRootRegistry.CreateWindowWithDataContext(
                                searchingRadiocomponentsVM);
                        searchingRadiocomponentsWindow.WindowStartupLocation
                            = WindowStartupLocation.CenterScreen;
                        searchingRadiocomponentsWindow.ShowDialog();
                    },
                    obj => _radiocomponents.Count > 0));

        #endregion
    }
}
