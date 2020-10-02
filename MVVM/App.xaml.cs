using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM.VMs;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly PresentationRootRegistry
            _presentationRootRegistry = new PresentationRootRegistry();

        /// <summary>
        /// Регистрирует типы представлений на типы моделей представлений.
        /// </summary>
        private void RegisterWindowsTypes()
        {
            _presentationRootRegistry.RegisterWindowType
                <MainViewModel, MainWindow>();
            _presentationRootRegistry.RegisterWindowType
                <AddRadiocomponentViewModel, AddRadiocomponentWindow>();
            _presentationRootRegistry.RegisterWindowType
                <SaveToFileWindowViewModel, ActionWindow>();
            _presentationRootRegistry.RegisterWindowType
                <LoadFromFileWindowViewModel, ActionWindow>();
            _presentationRootRegistry.RegisterWindowType
                <SearchRadiocomponentViewModel, SearchRadiocomponentWindow>();
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

            var mainViewModel = new MainViewModel(_presentationRootRegistry);
            var mainWindow = _presentationRootRegistry
                .CreateWindowWithDataContext(mainViewModel);
            mainWindow.Show();
        }
    }
}
