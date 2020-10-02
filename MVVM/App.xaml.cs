﻿using System;
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
        private readonly PresentationRootRegistry
            _presentationRootRegistry = new PresentationRootRegistry();

        /// <summary>
        /// Регистрирует типы представлений на типы моделей представлений.
        /// </summary>
        private void RegisterWindowsTypes()
        {
            _presentationRootRegistry.RegisterWindowType
                <MainVM, MainWindow>();
            _presentationRootRegistry.RegisterWindowType
                <AddRadiocomponentVM, AddRadiocomponentWindow>();
            _presentationRootRegistry.RegisterWindowType
                <SaveToFileWindowVM, ActionWindow>();
            _presentationRootRegistry.RegisterWindowType
                <LoadFromFileWindowVM, ActionWindow>();
            _presentationRootRegistry.RegisterWindowType
                <SearchRadiocomponentVM, SearchRadiocomponentWindow>();
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

            var mainViewModel = new MainVM(_presentationRootRegistry);
            var mainWindow = _presentationRootRegistry
                .CreateWindowWithDataContext(mainViewModel);
            mainWindow.Show();
        }
    }
}
