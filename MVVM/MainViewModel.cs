using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private readonly PresentationRootRegistry _presentationRootRegistry;
        private RelayCommand _openAddRadiocomponentWindowCommand;
        private RelayCommand _deleteSelectedRadiocomponentsCommand;

        private readonly AddRadiocomponentViewModel
            _addRadiocomponentViewModel;

        #endregion

        #region -- Constructors --

        public MainViewModel(PresentationRootRegistry presentationRootRegistry)
        {
            _presentationRootRegistry = presentationRootRegistry;
            _addRadiocomponentViewModel
                = new AddRadiocomponentViewModel(Radiocomponents);
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
                => _addRadiocomponentViewModel
                    .RadiocomponentTypeAsStringToQuantityUnitAsStringMap;

        /// <summary>
        /// Коллекция радиокомпонентов.
        /// </summary>
        public ObservableCollection<IPrintableRadiocomponent> Radiocomponents
            { get; } = new ObservableCollection<IPrintableRadiocomponent>();

        /// <summary>
        /// Коллекция выделенных радиокомпонентов.
        /// </summary>
        public IList SelectedRadiocomponents { get; set; }
            = new List<IPrintableRadiocomponent>();

        #endregion

        #region -- Commands --

        public RelayCommand OpenAddRadiocomponentWindowCommand
            => _openAddRadiocomponentWindowCommand
               ?? (_openAddRadiocomponentWindowCommand
                   = new RelayCommand(obj =>
                   {
                       var addRadiocomponentWindow = _presentationRootRegistry
                           .CreateWindowWithDataContext(_addRadiocomponentViewModel);
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

        #endregion
    }
}
