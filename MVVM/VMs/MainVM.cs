using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Model;
using MVVM.Converters;

namespace MVVM.VMs
{
    internal class MainVM : VMBase
    {
        #region -- Private fields --

        /// <summary>
        /// Типы радиокомпонентов, которые можно будет создавать.
        /// </summary>
        private readonly List<RadiocomponentType>
            _availableRadiocomponentTypes = new List<RadiocomponentType>
            {
                RadiocomponentType.Resistor,
                RadiocomponentType.Inductor,
                RadiocomponentType.Capacitor
            };

        private readonly PresentationRootRegistry _presentationRootRegistry;

        private bool _isFrequencyValid;
        private bool _isSelectedRadiocomponentValueValid;
        private double _frequency;
        private double _selectedRadiocomponentValue;

        private RadiocomponentToRadiocomponentVMAdapter
            _singleSelectedRadiocomponentVM;

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
            if (_singleSelectedRadiocomponentVM != null
                && _isFrequencyValid)
            {
                SelectedRadiocomponentImpedanceAsString
                    = _singleSelectedRadiocomponentVM.Radiocomponent
                        .GetImpedance(_frequency).ToString(
                            CultureInfo.InvariantCulture);
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
            if (_singleSelectedRadiocomponentVM != null)
            {
                SelectedRadiocomponentValueAsString
                    = _singleSelectedRadiocomponentVM.Value.ToString(
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
            if (_singleSelectedRadiocomponentVM != null)
            {
                var selectedRadiocomponentType
                    = _singleSelectedRadiocomponentVM.Radiocomponent
                        .Type;

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
        /// Преобразует каждый объект коллекции IEnumerable в адаптированный
        /// удобочитаемый радиокомпонент и возвращает коллекцию
        /// адаптированных радиокомпонентов.
        /// </summary>
        /// <param name="objects">Коллекция объектов.</param>
        /// <returns>Коллекция адаптированных удобочитаемых радиокомпонентов.
        /// </returns>
        private IEnumerable<RadiocomponentToRadiocomponentVMAdapter>
            ToPrintableRadiocomponents(IEnumerable objects)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            return objects
                .Cast<RadiocomponentToRadiocomponentVMAdapter>()
                .ToList();
        }

        #endregion

        #region -- Constructors --

        public MainVM(
            PresentationRootRegistry presentationRootRegistry)
        {
            _presentationRootRegistry = presentationRootRegistry;
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
        /// Коллекция радиокомпонентов для добавления/удаления.
        /// </summary>
        public ObservableCollection<RadiocomponentToRadiocomponentVMAdapter>
            Radiocomponents { get; }
                = new BrowsableObservableCollection<RadiocomponentToRadiocomponentVMAdapter>();

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
                    _singleSelectedRadiocomponentVM
                        = (RadiocomponentToRadiocomponentVMAdapter)SelectedObjects[0];
                    IsSingleRadiocomponentSelected = true;
                }
                else
                {
                    _singleSelectedRadiocomponentVM = null;
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

        public RelayCommand OpenAddRadiocomponentWindowCommand
            => _openAddRadiocomponentWindowCommand
               ?? (_openAddRadiocomponentWindowCommand = new RelayCommand(
                   obj =>
                   {
                       var addRadiocomponentViewModel
                           = new AddRadiocomponentVM(
                               _availableRadiocomponentTypes,
                               Radiocomponents);

                       var addRadiocomponentWindow
                           = _presentationRootRegistry
                               .CreateWindowWithDataContext(
                                   addRadiocomponentViewModel);

                       addRadiocomponentWindow.WindowStartupLocation
                           = WindowStartupLocation.CenterScreen;

                       addRadiocomponentWindow.ShowDialog();
                   }));
        
        public RelayCommand DeleteSelectedRadiocomponentsCommand
            => _deleteSelectedRadiocomponentsCommand
               ?? (_deleteSelectedRadiocomponentsCommand = new RelayCommand(
                   obj =>
                   {
                       var remainingRadiocomponents = Radiocomponents.Except(
                           SelectedObjects
                               .Cast<RadiocomponentToRadiocomponentVMAdapter>())
                           .ToList();

                       Radiocomponents.Clear();
                       foreach (var radiocomponent
                           in remainingRadiocomponents)
                       {
                           Radiocomponents.Add(radiocomponent);
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
                            .CreateRadiocomponent(newRadiocomponentType,
                                _selectedRadiocomponentValue);

                        var selectedRadiocomponentIndex = Radiocomponents
                            .IndexOf(_singleSelectedRadiocomponentVM);

                        Radiocomponents[selectedRadiocomponentIndex]
                            = new RadiocomponentToRadiocomponentVMAdapter(
                                newRadiocomponent);

                        SelectedObjects.Add(
                            Radiocomponents[selectedRadiocomponentIndex]);
                    },
                    obj => SelectedObjects != null
                           && SelectedObjects.Count == 1
                           && _isSelectedRadiocomponentValueValid
                           && SelectedRadiocomponentTypeIndex != null));
        
        public RelayCommand OpenSaveToFileWindowCommand
            => _openSaveToFileWindowCommand ?? (_openSaveToFileWindowCommand
                = new RelayCommand(
                    obj =>
                    {
                        var selectedPrintableRadiocomponents
                            = new List<RadiocomponentToRadiocomponentVMAdapter>();
                        if (SelectedObjects != null)
                        {
                            selectedPrintableRadiocomponents.AddRange(
                                ToPrintableRadiocomponents(SelectedObjects));
                        }

                        var saveToFileViewModel = new SaveToFileWindowVM(
                            Radiocomponents,
                            selectedPrintableRadiocomponents);
                        var saveToFileWindow = _presentationRootRegistry
                            .CreateWindowWithDataContext(
                                saveToFileViewModel);
                        saveToFileWindow.WindowStartupLocation
                            = WindowStartupLocation.CenterScreen;
                        saveToFileWindow.ShowDialog();
                    },
                    obj => Radiocomponents.Count > 0));
        
        public RelayCommand OpenLoadFromFileWindowCommand
            => _openLoadFromFileWindowCommand
               ?? (_openLoadFromFileWindowCommand = new RelayCommand(
                   obj =>
                   {
                       var loadFromFileViewModel = new LoadFromFileWindowVM(
                           Radiocomponents);
                       var loadFromFileWindow = _presentationRootRegistry
                           .CreateWindowWithDataContext(
                               loadFromFileViewModel);
                       loadFromFileWindow.WindowStartupLocation
                           = WindowStartupLocation.CenterScreen;
                       loadFromFileWindow.ShowDialog();
                   }));
        
        public RelayCommand OpenSearchWindowCommand
            => _openSearchWindowCommand ?? (_openSearchWindowCommand
                = new RelayCommand(
                    obj =>
                    {
                        var searchRadiocomponentViewModel
                            = new SearchRadiocomponentVM(
                                _availableRadiocomponentTypes,
                                Radiocomponents, SelectedObjects);
                        var searchRadiocomponentWindow =
                            _presentationRootRegistry
                                .CreateWindowWithDataContext(
                                    searchRadiocomponentViewModel);
                        searchRadiocomponentWindow.WindowStartupLocation
                            = WindowStartupLocation.CenterScreen;
                        searchRadiocomponentWindow.ShowDialog();
                    },
                    obj => Radiocomponents.Count > 0));

        #endregion
    }
}
