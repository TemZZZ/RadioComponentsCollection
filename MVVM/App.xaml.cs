using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM.Views;
using MVVM.VMs;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ViewRootRegistry
            _viewRootRegistry = new ViewRootRegistry();

        /// <summary>
        /// Регистрирует типы представлений на типы моделей представлений.
        /// </summary>
        private void RegisterWindowsTypes()
        {
            _viewRootRegistry.RegisterWindowType
                <MainVM, MainWindow>();
            _viewRootRegistry.RegisterWindowType
                <AddingRadiocomponentVM, AddingRadiocomponentWindow>();
            _viewRootRegistry.RegisterWindowType
                <SavingRadiocomponentsWindowVM, ActionWindow>();
            _viewRootRegistry.RegisterWindowType
                <LoadingFromFileWindowVM, ActionWindow>();
            _viewRootRegistry.RegisterWindowType
                <SearchingRadiocomponentVM, SearchingRadiocomponentWindow>();
        }

        static App()
        {
            // Добавлено для возможности ввода десятичной точки в элемент
            // управления TextBox, когда свойство Text последнего привязано
            // к свойству зависимости типа double или decimal.
            FrameworkCompatibilityPreferences
                .KeepTextBoxDisplaySynchronizedWithTextProperty = false;
        }

        public App()
        {
            RegisterWindowsTypes();

            var mainVM = new MainVM(_viewRootRegistry);
            var mainWindow = _viewRootRegistry
                .CreateWindowWithDataContext(mainVM);
            mainWindow.Show();
        }
    }
}
