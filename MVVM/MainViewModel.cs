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

        #endregion

        #region -- Constructors --

        public MainViewModel(
            PresentationRootRegistry presentationRootRegistry)
        {
            _presentationRootRegistry = presentationRootRegistry;
        }

        #endregion

        #region -- Commands --

        public RelayCommand OpenAddRadiocomponentWindow
            => _openAddRadiocomponentWindow ?? (_openAddRadiocomponentWindow
                = new RelayCommand(
                    obj =>
                    {
                        var addRadiocomponentViewModel
                            = new AddRadiocomponentViewModel();
                        var addRadiocomponentWindow = _presentationRootRegistry
                            .CreateWindowWithDataContext(addRadiocomponentViewModel);
                        addRadiocomponentWindow.WindowStartupLocation
                            = WindowStartupLocation.CenterScreen;
                        addRadiocomponentWindow.ShowDialog();
                    }));

        #endregion
    }
}
