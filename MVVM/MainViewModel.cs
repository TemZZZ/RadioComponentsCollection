using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;

namespace MVVM
{
    internal class MainViewModel : ViewModelBase
    {
        #region -- Private fields --

        /// <summary>
        /// Типы радиокомпонентов, которые можно будет создавать.
        /// </summary>
        private readonly List<RadiocomponentType> _availableRadiocomponentTypes
            = new List<RadiocomponentType>
            {
                RadiocomponentType.Resistor,
                RadiocomponentType.Inductor,
                RadiocomponentType.Capacitor
            };

        private readonly PresentationRootRegistry _presentationRootRegistry;

        private bool _isFrequencyValid;
        private bool _isRadiocomponentValueValid;
        private double _frequency;
        private double _radiocomponentValue;

        // Эти поля в коде не трогать! Используй публичные свойства!
        private string _frequencyAsString;
        private string _radiocomponentValueAsString;
        private uint? _selectedRadiocomponentTypeIndex;
        private RelayCommand _openAddRadiocomponentWindowCommand;
        private RelayCommand _deleteSelectedRadiocomponentsCommand;
        private RelayCommand _modifyRadiocomponentCommand;
        private RelayCommand _openSaveToFileWindowCommand;
        private RelayCommand _openLoadFromFileWindowCommand;
        private RelayCommand _openSearchWindowCommand;
        private IList _selectedRadiocomponents = new List<IPrintableRadiocomponent>();

        #endregion

        #region -- Private methods --

        /// <summary>
        /// Проверяет, представляет ли строковое представление физической
        /// величины радиокомпонента неотрицательное вещественное число. Если
        /// да, то в true устанавливается соответствующий флаг, и обновляется
        /// значение поля, хранящего значение физической величины
        /// радиокомпонента.
        /// </summary>
        private void ValidateAndUpdateRadiocomponentValue()
        {
            _isRadiocomponentValueValid = NotNegativeDoubleValidationRule
                .TryConvertToNotNegativeDouble(_radiocomponentValueAsString,
                    out var newRadiocomponentValue);

            if (_isRadiocomponentValueValid)
            {
                _radiocomponentValue = newRadiocomponentValue;
            }
        }

        /// <summary>
        /// Проверяет, представляет ли строковое представление значения
        /// частоты неотрицательное вещественное число. Если да, то в true
        /// устанавливается соответствующий флаг, и обновляется значение
        /// поля, хранящего значение частоты.
        /// </summary>
        private void ValidateAndUpdateFrequency()
        {
            _isFrequencyValid = NotNegativeDoubleValidationRule
                .TryConvertToNotNegativeDouble(_frequencyAsString,
                    out var newFrequency);

            if (_isFrequencyValid)
            {
                _frequency = newFrequency;
            }
        }

        #endregion

        #region -- Constructors --

        public MainViewModel(PresentationRootRegistry presentationRootRegistry)
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
        public List<(string, string)> RadiocomponentTypeAsStringToQuantityUnitAsStringMap
            => RadiocomponentTypesToTypeAsStringToQuantityUnitAsStringMapConverter
                .GetRadiocomponentTypeAsStringToQuantityUnitAsStringMap(
                    _availableRadiocomponentTypes);

        /// <summary>
        /// Коллекция радиокомпонентов.
        /// </summary>
        public ObservableCollection<IPrintableRadiocomponent> Radiocomponents
            { get; } = new ObservableCollection<IPrintableRadiocomponent>();

        /// <summary>
        /// Коллекция выделенных радиокомпонентов.
        /// </summary>
        public IList SelectedRadiocomponents
        {
            get => _selectedRadiocomponents;
            set
            {
                _selectedRadiocomponents = value;

                if (SelectedRadiocomponents.Count == 1)
                {
                    var selectedPrintableRadiocomponent
                        = (IPrintableRadiocomponent)SelectedRadiocomponents[0];

                    RadiocomponentValueAsString
                        = selectedPrintableRadiocomponent.Value
                            .ToString(CultureInfo.InvariantCulture);

                    var selectedRadiocomponentType
                        = selectedPrintableRadiocomponent.GetRadiocomponent().Type;

                    SelectedRadiocomponentTypeIndex = IndexToRadiocomponentTypeConverter
                        .GetIndexOfRadiocomponentType(
                            selectedRadiocomponentType,
                            _availableRadiocomponentTypes);
                }
                else
                {
                    RadiocomponentValueAsString = null;
                    SelectedRadiocomponentTypeIndex = null;
                }
            }
        }

        /// <summary>
        /// Позволяет получить или задать индекс типа выделенного
        /// радиокомпонента в коллекции типов.
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
                ValidateAndUpdateFrequency();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Позволяет получить или задать строковое представление значения
        /// физической величины радиокомпонента.
        /// </summary>
        public string RadiocomponentValueAsString
        {
            get => _radiocomponentValueAsString;
            set
            {
                _radiocomponentValueAsString = value;
                ValidateAndUpdateRadiocomponentValue();
                RaisePropertyChanged();
            }
        }

        #endregion

        #region -- Commands --

        public RelayCommand OpenAddRadiocomponentWindowCommand
            => _openAddRadiocomponentWindowCommand
               ?? (_openAddRadiocomponentWindowCommand
                   = new RelayCommand(obj =>
                   {
                       var addRadiocomponentViewModel
                           = new AddRadiocomponentViewModel(
                               _availableRadiocomponentTypes, Radiocomponents);
                       var addRadiocomponentWindow = _presentationRootRegistry
                           .CreateWindowWithDataContext(addRadiocomponentViewModel);
                       addRadiocomponentWindow.WindowStartupLocation
                           = WindowStartupLocation.CenterScreen;
                       addRadiocomponentWindow.ShowDialog();
                   }));

        public RelayCommand DeleteSelectedRadiocomponentsCommand
            => _deleteSelectedRadiocomponentsCommand
               ?? (_deleteSelectedRadiocomponentsCommand
                   = new RelayCommand(obj =>
                   {
                       var remainingRadiocomponents = Radiocomponents
                           .Except(SelectedRadiocomponents
                               .Cast<IPrintableRadiocomponent>()).ToList();
                       
                       Radiocomponents.Clear();
                       foreach (var radiocomponent in remainingRadiocomponents)
                       {
                           Radiocomponents.Add(radiocomponent);
                       }
                   }, obj => SelectedRadiocomponents.Count > 0));

        public RelayCommand ModifyRadiocomponentCommand
            => _modifyRadiocomponentCommand ?? (_modifyRadiocomponentCommand
                = new RelayCommand(obj =>
                {

                }, obj => SelectedRadiocomponents.Count == 1
                          && _isRadiocomponentValueValid
                          && SelectedRadiocomponentTypeIndex != null));

        public RelayCommand OpenSaveToFileWindowCommand
            => _openSaveToFileWindowCommand ?? (_openSaveToFileWindowCommand
                = new RelayCommand(obj =>
                {

                }, obj => Radiocomponents.Count > 0));

        public RelayCommand OpenLoadFromFileWindowCommand
            => _openLoadFromFileWindowCommand ?? (_openLoadFromFileWindowCommand
                = new RelayCommand(obj =>
                {

                }));

        public RelayCommand OpenSearchWindowCommand
            => _openSearchWindowCommand ?? (_openSearchWindowCommand
                = new RelayCommand(obj =>
                {

                }, obj => Radiocomponents.Count > 0));

        #endregion
    }
}
