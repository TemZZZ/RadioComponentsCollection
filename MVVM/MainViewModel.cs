using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    internal class MainViewModel : ViewModelBase
    {
        #region -- Private fields --

        private readonly PresentationRootRegistry _presentationRootRegistry;
        private RelayCommand _openAddRadiocomponentWindow;

        private readonly AddRadiocomponentViewModel
            _addRadiocomponentViewModel = new AddRadiocomponentViewModel();

        #endregion

        #region -- Constructors --

        public MainViewModel(
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
                => _addRadiocomponentViewModel
                    .RadiocomponentTypeAsStringToQuantityUnitAsStringMap;

        #endregion

        #region -- Commands --

        public RelayCommand OpenAddRadiocomponentWindow
            => _openAddRadiocomponentWindow ?? (_openAddRadiocomponentWindow
                = new RelayCommand(
                    obj =>
                    {
                        var addRadiocomponentWindow = _presentationRootRegistry
                            .CreateWindowWithDataContext(_addRadiocomponentViewModel);
                        addRadiocomponentWindow.WindowStartupLocation
                            = WindowStartupLocation.CenterScreen;
                        addRadiocomponentWindow.ShowDialog();
                    }));

        #endregion
    }
}
